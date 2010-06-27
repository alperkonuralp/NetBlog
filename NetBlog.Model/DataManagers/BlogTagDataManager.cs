using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetBlog.Model.Common;
using NetBlog.Model.Entities;
using System.Data;
using System.Data.SqlClient;

namespace NetBlog.Model.DataManagers
{
    /// <summary>
    /// Blog Tag Data Manager
    /// </summary>
    public class BlogTagDataManager : DataManagerBase
    {
        public List<EBlogTag> GetAllTags()
        {
            return ExecuteToList<EBlogTag>(
                "SELECT * FROM TBlogTag;",
                Change);
        }


        public List<EBlogTag> GetTagsByPostID(
            int postID)
        {
            return ExecuteToList<EBlogTag>(
                "SELECT * FROM TBlogTag WHERE PostID = @PostID;",
                Change,
                CreateParameter("@PostID", postID));
        }


        protected EBlogTag Change(IDataReader sdr)
        {
            return new EBlogTag()
            {
                PostID = sdr.GetInt32(sdr.GetOrdinal("PostID")),
                Tag = GetStringFromDataReader(sdr, "Tag")
            };
        }
    }
}
