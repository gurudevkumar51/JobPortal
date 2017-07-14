using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobPortalDAL.Manager;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using JobPortalDAL.Entity;
using JobPortalDAL.Common;
using System.Configuration;

namespace JobPortalDAL.DataAccess
{
    public class JobRepository : IJob
    {
        //HttpClient client;
        
        public string url = ConfigurationManager.AppSettings["ApiUrl"].ToString();
        //public JobRepository()
        //{
        //    client = new HttpClient();
        //    client.BaseAddress = new Uri(url);
        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //}

        public async Task<List<Job>> GetAllJobs()
        {
            url += "/api/job/alljobs";
            var responseData = await GenericClass.CallApi(url, null);

            if(responseData != string.Empty)
            {
                var allJobs = JsonConvert.DeserializeObject<APIJobResponse>(responseData);
                Job[] JobArray= allJobs.responseText;
                
                return JobArray.ToList();
            }
            return null;            
        }

        public Boolean AddJob(Job jb, string token)
        {            
            url = url + "api/Job/Add";
            GenericClass.CallPostApi(url, token, JsonConvert.SerializeObject(jb));
            return true;
        }

        public async Task<string> SeekerCount()
        {
            url += "api/User/SeekerCount";
            var responseData = await GenericClass.CallApi(url, null);

            if (responseData != string.Empty)
            {               
                return responseData;
            }
            return null;
        }
    }
}
