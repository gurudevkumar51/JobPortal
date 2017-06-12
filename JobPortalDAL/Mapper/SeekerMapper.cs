using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalDAL.Mapper
{
    public class SeekerMapper
    {
        public List<ExcelFile> Map(IDataReader reader)
        {
            List<ExcelFile> DBfiles = new List<ExcelFile>();
            while (reader.Read())
            {
                ExcelFile Filedata = new ExcelFile();
                Filedata.FileID = Convert.ToInt32(reader["File_id"]);
                Filedata.Filename = reader["File_name"].ToString();
                Filedata.FromDate = Convert.ToDateTime(reader["StartDate"]);
                Filedata.FileExtnsn = reader["File_extension"].ToString();
                Filedata.ToDate = Convert.ToDateTime(reader["EndDate"]);
                Filedata.UploadDate = Convert.ToDateTime(reader["UploadDate"]);
                Filedata.ProcessStatus = Convert.ToBoolean(reader["Process_status"]);
                DBfiles.Add(Filedata);
            }
            return DBfiles;
        }
    }
}
