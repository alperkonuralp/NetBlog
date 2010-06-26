using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetBlog.Model.Common;
using NetBlog.Model.Entities;
using System.Data.SqlClient;

namespace NetBlog.Model.DataManagers
{
    public class BlogDataManager : DataManagerBase
    {
        public List<EBlog> GetAllBlogs()
        {
            return ExecuteToList<EBlog>(
                "SELECT * FROM EBlog;",
                Change);
        }

        protected EBlog Change(SqlDataReader sdr)
        {
            return new EBlog()
            {
                BlogID = sdr.GetInt32(sdr.GetOrdinal("BlogID")),
                BlogName = sdr.GetString(sdr.GetOrdinal("BlogName"))
            };
        }
    }
}
