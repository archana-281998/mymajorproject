using EFashion.Web.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;

namespace EFashion.Web.Areas.Users.ViewModels
{
    public class PaymentViewModel:Payment
    {
        [Display(Name ="Payment Id")]
        override public int PaymentId { get; set; }

        [Display(Name = "Payment Name")]
        [Required]
        [StringLength(50)]
        [DefaultValue("PhonePe,GPay,Cash")]
        override public string PaymentName { get; set; }
        [Display(Name ="Created Date")]
        [Required]
        override public DateTime? CreatedDate { get; set; } = DateTime.Now;


        [Display(Name ="Customer")]
        override public int CustomerId { get; set; }

       


       

    }
}
