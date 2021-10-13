using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADproject.Models;

namespace ADproject.Controllers
{
    
    public class HomeController : Controller
    {

        DB_Entities db = new DB_Entities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Admin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Autherize(Admin userModel)
        {
            using (DB_Entities db = new DB_Entities())
            {
                var userDetails = db.Admin.Where(x => x.UserName == userModel.UserName && x.Password == userModel.Password).FirstOrDefault();
                if(userDetails==null)
                {
                    ViewBag.error = "Invalid Account";
                    return View("Admin", userModel);
                }
                else
                {
                    Session["UserId"] = userDetails.UserId;
                    return RedirectToAction("Item", "Home");
                }
            }
               // return View();
                
        }
        
        public ActionResult Item()
        {
            return View(db.Item.ToList());
        }

        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase file,Item emp)
        {
            string filename = Path.GetFileName(file.FileName);
            string _filename = DateTime.Now.ToString("yymmssfff") + filename;
            string extension = Path.GetExtension(file.FileName);
            string path = Path.Combine(Server.MapPath("~/images/"), _filename);
            emp.Img = "~/images/" + _filename;
            if(extension.ToLower()==".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png")
            {
                if(file.ContentLength<=1000000)
                {
                    db.Item.Add(emp);
                    if(db.SaveChanges()>0)
                    {
                        file.SaveAs(path);
                        ViewBag.msg = "Record Added";
                        ModelState.Clear();
                    }
                }
                else
                {
                    ViewBag.msg = "Size is not valid";
                }
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            var item = db.Item.Where(x => x.ProductId == id).First();
            db.Item.Remove(item);
            db.SaveChanges();
            var item1 = db.Item.ToList();
            return View("Item", item1);
        }
        public ActionResult Edit(int id)
        {
            var item = db.Item.Where(x => x.ProductId == id).First();
            return View(item);
        }
        [HttpPost]
        public ActionResult Edit(Item model)
        {
            var item = db.Item.Where(x => x.ProductId == model.ProductId).First();
            item.ProductName = model.ProductName;
            item.Price = model.Price;
            item.Img = model.Img;
            db.SaveChanges();
            return View();
        }
        
        public ActionResult Details(int id)
        {
            var item = db.Item.Where(x => x.ProductId == id).First();
            return View(item);
        }

        [HttpPost]
        public ActionResult Details(Item model)
        {
            var item = db.Item.Where(x => x.ProductId == model.ProductId).First();
            item.ProductName = model.ProductName;
            item.Price = model.Price;
            item.Img = model.Img;
            return View();
        }
        public ActionResult Customer()
        {
            return View();
        }
        //-------------------------------------------------------------
        public ActionResult GetData()
        {
            var data = from als in db.Item select new { als.ProductName, als.Price};
            return Json(data.ToList(), JsonRequestBehavior.AllowGet);
        }

    }
}