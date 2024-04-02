using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core.Domain.Entities;

namespace WebShop.Core.DTO
{
    public class AddPerson
    {
        public string? UserGuid { get; set; }
        [Required(ErrorMessage ="First Name is required")]
        public string FirstName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
        [Required(ErrorMessage = "Email Name is required")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Phone Number is required")]
        public string PhoneNumber { get; set; } = string.Empty;

        public static Person ToPerson(AddPerson addPerson)
        {
            return new Person()
            {
                FirstName = addPerson.FirstName,
                LastName = addPerson.LastName,
                DateOfBirth = addPerson.DateOfBirth,
                Email = addPerson.Email,
                PhoneNumber = addPerson.PhoneNumber
            };
        }
    }
}
