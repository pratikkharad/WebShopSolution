
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Helpers
{
    public class PasswordHelper
    {
        public static string HashPassword(string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password is null");
            }

            // adjust workFactor as needed
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password, workFactor: 10);
            return passwordHash;
        }

        public static bool ValidationPassword(string password,string passwordHash)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password is null");
            }
            
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, passwordHash);

            return isPasswordValid;
        }
    }
}
