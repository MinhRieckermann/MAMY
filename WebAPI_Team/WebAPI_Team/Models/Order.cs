using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebAPI_Team.Models
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public int OrdersId { get; set; }
        
        public int AccountId { get; set; }
        
    }
}