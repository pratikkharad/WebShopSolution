using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Domain.Entities
{
    public class Person
    {
        public string? UserGuid { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string? UserName { get; set; }
        public string PasswordHash { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public bool PhoneNumberConfirmed { get; set; }
        public string JwtToken { get; set; } = string.Empty;
        public DateTime Expiration { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int? AccessFailedCount { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int? TotalRecords { get; set; }


    }

    
}
