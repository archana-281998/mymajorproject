using EFashion.Web.Models;
using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFashion.Web.Areas.Users.ViewModels
{
    public class OrderViewModel:Order
    {
        [Display(Name ="OrderId")]
        override public int OrderId { get; set; }
        [Required]
        [Display(Name = "Order Date")]
        override public System.DateTime OrderDate { get; set; } = DateTime.Now;

        [Display(Name = "Discount Offered")]
        override public decimal Discount { get; set; }
        [Required]
        [Display(Name = "Quantities")]
        override public decimal Quantity { get; set; }
        [Required]
        [Display(Name = "Items Price")]
        override public decimal Price { get; set; }
        [Required]
        override public int CustomerId { get; set; }
       
       
        [Required]

        override public int ItemId { get; set; }
        

    }
}
