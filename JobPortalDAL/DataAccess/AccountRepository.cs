using JobPortalDAL.Common;
using JobPortalDAL.Entity;
using JobPortalDAL.Manager;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalDAL.DataAccess
{
    public class AccountRepository : IAccount
    {
        public static string url = ConfigurationManager.AppSettings["ApiUrl"].ToString();

        public string Login(string username, string pass)
        {
            var token = GenericClass.GetToken(url, username, pass);
            
            return token;
        }
    }
}
