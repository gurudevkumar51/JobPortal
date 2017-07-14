using JobPortalDAL.Common;
using JobPortalDAL.Entity;
using JobPortalDAL.Manager;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalDAL.DataAccess
{
    public class AccountRepository : IAccount
    {
        public string ApiUrl = ConfigurationManager.AppSettings["ApiUrl"].ToString();

        //HttpClient cons = new HttpClient();
        //cons.BaseAddress = new Uri(ApiUrl);
        //cons.DefaultRequestHeaders.Accept.Clear();
        //cons.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        public string Login(string username, string pass)
        {
            var token = GenericClass.GetToken(ApiUrl, username, pass);            
            return token;
        }

        public async Task<string> GetUserDetailsAsync(string token)
        {
            ApiUrl = ApiUrl + "api/Account/GetUserDetails";
            string response = await GenericClass.CallApi(ApiUrl, token);
            return response;
        }

        //public User GetUserDetails(string token, string API)
        //{
        //    var response = JsonConvert.DeserializeObject<User>(GetUserDetailsAsync(token, API));
        //    return response;
        //}
    }
}
