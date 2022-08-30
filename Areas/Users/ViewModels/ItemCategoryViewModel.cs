using EFashion.Web.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EFashion.Web.Areas.Users.ViewModels
{
    public class ItemCategoryViewModel:ItemCategory
    {
        [Display(Name = "Item Category Name")]
        [Required(ErrorMessage = "{0} cannot be empty")]
        [MinLength(4, ErrorMessage = "{0} should have at least {1} characters")]
        [MaxLength(100, ErrorMessage = "{0} can have a maximum of {1} characters")]

        public override string ItemCategoryName
        {
            get { return base.ItemCategoryName; }
            set { base.ItemCategoryName = value; }
        }
        [Display(Name = "Is Available?")]

        public override bool IsAvailable
        {
            get => base.IsAvailable;
            set => base.IsAvailable = value;
        }

        public override string ImageUrl { 
            get => base.ImageUrl;
            set => base.ImageUrl = value;
        }

    }
    }

