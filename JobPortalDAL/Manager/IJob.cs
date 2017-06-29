using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobPortalDAL.Entity;

namespace JobPortalDAL.Manager
{
    public interface IJob
    {
        Task<List<Job>> GetAllJobs();

        Task<string> SeekerCount();
    }
}
