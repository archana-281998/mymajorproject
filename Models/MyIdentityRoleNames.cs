using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EFashion.Web.Models
{
    public enum MyIdentityRoleNames
    {
       
            [Display(Name = "Admin Role")]
            AppAdmin,



       [Display(Name = "User Role")]
            AppUser
        }
    }

