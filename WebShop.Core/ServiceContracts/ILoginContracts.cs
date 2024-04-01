using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core.DTO;

namespace WebShop.Core.ServiceContracts
{
    public interface ILoginContracts
    {
        Task<bool> LoginAsync(LoginDTO loginRequest);
    }
}
