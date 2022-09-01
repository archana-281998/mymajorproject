using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Text.Json.Serialization;

namespace EFashion.Web.Models
{
    [Table(name:"Orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        virtual public int OrderId { get; set; }//orderid
        [Required]
        virtual public System.DateTime OrderDate { get; set; } = DateTime.Now;//orderdate

        virtual public decimal Discount { get; set; }//discount
        [Required]
        virtual public decimal Quantity { get; set; }//quantity
        [Required]
        virtual public decimal Price { get; set; }//price



        #region Navigation Properties to the Customer Model 

        [Required]
        virtual public int CustomerId { get; set; }
        [JsonIgnore]                                       // Suppress the information about the FK Object to the API.
        [ForeignKey(nameof(Order.CustomerId))]

        public Customer Customer { get; set; }

        #endregion

        #region Navigation Properties to the Item Model 
        [Required]

        virtual public int ItemId { get; set; }
        [JsonIgnore]

        [ForeignKey(nameof(Order.ItemId))]

        public Item Item { get; set; }

        #endregion

        //public ICollection<Payment> Payments { get; set; }
    }

}

