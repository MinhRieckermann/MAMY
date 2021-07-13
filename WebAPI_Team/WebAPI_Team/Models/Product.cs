using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_Team.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int ProductsId { get; set; }
        public string Name { get; set; }
        public int Prices { get; set; }
        public int Stock { get; set; }
        public int  SalePrice { get; set; }
        public int Discount { get; set; }
        public string Images { get; set; }
        public string Short_desc{ get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public bool NewPro { get; set; }
        public bool Sale { get; set; }
        public string State { get; set; }
        public int  Category_Id { get; set; }
        
    }
}