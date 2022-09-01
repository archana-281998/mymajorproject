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
        //details of customer
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        virtual public int CustomerId { get; set; }//customer.Id

        [Required]
        [StringLength(50)]
        virtual public string CustomerName { get; set; }//customer.Name

        [Required]
        virtual public string Email { get; set; }//email

        [Required]
        [StringLength(10)]
        virtual public string Phonenumber { get; set; }//Phoneno

        

        #region Navigation to Collections

        [JsonIgnore]                                         // Suppress the information about the FK Collection to the API.
        public ICollection<Order> Orders { get; set; }
       
        [JsonIgnore]                                 // Suppress the information about the FK Collection to the API.
        public ICollection<Payment> Payments { get; set; }

        #endregion
    }
}
