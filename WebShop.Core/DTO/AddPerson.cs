using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Domain.Entities;

namespace WebShop.Core.DTO
{
    public class AddPerson
    {
        [Required(ErrorMessage = "FirstName can't be blank")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "LastName can't be blank")]
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }


        public Person ToStudent()
        {
            return new Person()
            {
                FirstName = FirstName,
                LastName = LastName

            };
        }
    }
}
