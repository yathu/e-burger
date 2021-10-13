using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ADproject.Models
{
    public class OrderDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderDetailsId { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}