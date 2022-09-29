using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;

namespace FluentValidationApp.Web.Models
{
    public class Customer
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "Name boş olamaz.( DataAnnotation uyarısı )")]
        public string Name { get; set; }

        public string Email { get; set; }
        public int Age { get; set; }
        
        public DateTime? BirthDay { get; set; }

        // index ulaşabilmek için ICollection<> değil IList<> kullandık.
        public IList<Address> Addresses { get; set; }

        public Gender Gender { get; set; }
    }
}
