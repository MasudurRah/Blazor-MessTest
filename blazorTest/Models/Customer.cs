using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace blazorTest.Models
{
    public class Customer
    {
        [Required]
        [MinLength(2)]
        [StringLength(maximumLength:20, ErrorMessage = "Name can only be 20 characters.")]

        public string Name { get; set; }
    }
}
