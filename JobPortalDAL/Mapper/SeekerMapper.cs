using JobPortalDAL.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalDAL.Mapper
{
    public class SeekerMapper
    {
        public List<SeekerProfile> Map(IDataReader reader)
        {
            List<SeekerProfile> Seekers = new List<SeekerProfile>();
            while (reader.Read())
            {
                SeekerProfile seeker = new SeekerProfile();
                seeker.UserID= Convert.ToInt32(reader["File_id"]);
                seeker.FirstName = reader["File_name"].ToString();
                seeker.LastName = reader["StartDate"].ToString();
                seeker.CurrentSalary = Convert.ToDecimal(reader["File_extension"].ToString());
                seeker.ExpectedSalary = Convert.ToDecimal(reader["EndDate"]);
                seeker.DOB = Convert.ToDateTime(reader["UploadDate"]);
                seeker.SalaryCurrency = reader["Process_status"].ToString();
                seeker.Gender = reader["Process_status"].ToString();
                seeker.ResumePath = reader["Process_status"].ToString();
                seeker.Introduction = reader["Process_status"].ToString();
                Seekers.Add(seeker);
            }
            return Seekers;
        }
    }
}
