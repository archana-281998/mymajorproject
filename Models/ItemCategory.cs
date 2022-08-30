using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;
using System.Text.Json.Serialization;

namespace EFashion.Web.Models
{
    [Table(name: "ItemCategories")]
    public class ItemCategory
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        virtual public int ItemCategoryId { get; set; }

        [Required]
        [StringLength(100)]
        virtual public string ItemCategoryName { get; set; }

        [Required]
        [DefaultValue(true)]
        virtual public bool IsAvailable { get; set; }
        [StringLength(1000)]
       virtual public string ImageUrl { get; set; }

        #region Navigation Properties to the Item Model
        

        [JsonIgnore]
        public ICollection<Item> Items { get; set; }

        #endregion

    }
}

