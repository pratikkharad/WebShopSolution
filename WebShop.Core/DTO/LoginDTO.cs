using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Core.DTO
{
    public class LoginDTO
    {
        
        
        [Required(ErrorMessage = "Username is required.")]
        [StringLength(50)]
        [EmailAddress]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 8)]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}
