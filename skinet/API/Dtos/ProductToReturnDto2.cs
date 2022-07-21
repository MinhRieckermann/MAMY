using System;

namespace API.Dtos
{
    public class ProductToReturnDto2
    {   public int Id { get; set; }
        public string Name { get; set; }
        public decimal price { get; set; }
        public int stock { get; set; }
        public decimal salePrice { get; set; }
        public int discount { get; set; }
        public string pictures { get; set; }
        public string description { get; set; }
        public string shortDetails { get; set; }
       
        public Boolean sale { get; set; }
        public Boolean newPro { get; set; }
        public string state { get; set; }
        public string category { get; set; }
    }
}