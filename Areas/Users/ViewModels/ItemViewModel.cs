using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using EFashion.Web.Models;

namespace EFashion.Web.Areas.Users.ViewModels
{
    public class ItemViewModel:Item
    {
        [Display(Name ="Products Name")]
        [StringLength(150)]
        override public string ItemName { get; set; }
        [Display(Name ="Product Type")]
        [Required]
        [StringLength(20)]
        override public string ItemType { get; set; }
        [Display(Name ="Description")]
        [StringLength(350)]
        override public string ItemDescription { get; set; }

        [Required]
        [DefaultValue(true)]
        override public bool IsAvailable { get; set; }

        [Required]
        override public decimal? Price { get; set; }

        public override string ImageUrl { get => base.ImageUrl; set => base.ImageUrl = value; }

    }
}
