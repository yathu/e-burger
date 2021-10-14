using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADproject.Models
{
    public partial class tblRegistration
    {
        [Key]
        public int User_Id { get; set; }
        public string FName { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}