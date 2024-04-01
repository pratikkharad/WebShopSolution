using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Core.Helper
{
    public static class ClaimsPrincipalHelper
    {
        public static ClaimsPrincipal ClaimsPrincipal(string username)
        {
            // Create claims principal for the authenticated user
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                // Add additional claims as needed
            };

            var identity = new ClaimsIdentity(claims, "cookie");
            return new ClaimsPrincipal(identity);
        }
    }
}
