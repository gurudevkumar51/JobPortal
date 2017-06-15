using JobPortalDAL.Common;
using JobPortalDAL.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalDAL.DataAccess
{
    public class AccountRepository : IAccount
    {
        public string Login()
        {
           var gg= GenericClass.GetToken("http://localhost:58463/", "123", "123");
            return gg;
        }
    }
}
