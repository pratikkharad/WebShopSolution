using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.DataAccess
{
    public static class UserSqlConstants
    {
        
        public const string GetUserList = "User_GetUserList";
        public const string GetUserPageNumberAndSize = "User_GetPageNumberAndSize";
        public const string GetSortedUsers = "User_GetSortedUsers";
        public const string GetTotalUserCount = "User_GetTotalUserCount";
        public const string GetPersonByUserName = "User_GetPersonByUserName";
        

    }
}
