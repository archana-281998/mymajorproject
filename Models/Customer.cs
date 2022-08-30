using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Text.Json.Serialization;

namespace EFashion.Web.Models
{
    [Table(name: "Customers")]
    public class Customer
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        virtual public int CustomerId { get; set; }

        [Required]
        [StringLength(50)]
        virtual public string CustomerName { get; set; }

        [Required]
        virtual public string Email { get; set; }

        [Required]
        [StringLength(10)]
        virtual public string Phonenumber { get; set; }

        

        #region Navigation to Collections

        [JsonIgnore]                                         // Suppress the information about the FK Collection to the API.
        public ICollection<Order> Orders { get; set; }
       
        [JsonIgnore]                                 // Suppress the information about the FK Collection to the API.
        public ICollection<Payment> Payments { get; set; }

        #endregion
    }
}
