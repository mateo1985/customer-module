namespace Customer.Module.Common.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Class represents single customer
    /// </summary>
    public class Customer
    {
        public long? Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Surrname { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression(@"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$", ErrorMessage = "The Telephone field has incorrect format")]
        public string Telephone { get; set; }

        [Required]
        [StringLength(50)]
        public string Address { get; set; }
    }
}
