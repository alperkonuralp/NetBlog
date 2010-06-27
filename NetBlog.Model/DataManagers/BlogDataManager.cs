using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetBlog.Model.Common;
using NetBlog.Model.Entities;
using System.Data.SqlClient;
using System.Data;

namespace NetBlog.Model.DataManagers
{
    /// <summary>
    /// Blog Data Manager
    /// </summary>
    public class BlogDataManager : DataManagerBase
    {
        /// <summary>
        /// Gets all blogs.
        /// </summary>
        /// <returns></returns>
        public List<EBlog> GetAllBlogs()
        {
            return ExecuteToList<EBlog>(
                "SELECT * FROM EBlog;",
                Change);
        }

        /// <summary>
        /// Gets the blog by ID.
        /// </summary>
        /// <param name="blogID">The blog ID.</param>
        /// <returns></returns>
        public EBlog GetBlogByID(int blogID)
        {
            return ExecuteToSingleRow<EBlog>(
                "SELECT * FROM EBlog WHERE BlogID = @BlogID;",
                Change,
                CreateParameter("BlogID", blogID));
        }


        /// <summary>
        /// Inserts the blog.
        /// </summary>
        /// <param name="blog">The blog.</param>
        /// <returns></returns>
        public int InsertBlog(EBlog blog)
        {
            return ExecuteInsertQueryReturnID(
                "TBlog",
                new Dictionary<string, object>() { 
                    {"BlogName", blog.BlogName}
                });
        }


        /// <summary>
        /// Inserts the blog.
        /// </summary>
        /// <param name="blogName">Name of the blog.</param>
        /// <returns></returns>
        public int InsertBlog(string blogName)
        {
            return ExecuteInsertQueryReturnID(
                "TBlog",
                new Dictionary<string, object>() { 
                    {"BlogName", blogName}
                });
        }


        /// <summary>
        /// Updates the blog.
        /// </summary>
        /// <param name="blog">The blog.</param>
        /// <returns></returns>
        public int UpdateBlog(EBlog blog)
        {
            return ExecuteNonQuery(
                @"UPDATE TBlog
SET 
    BlogName = @BlogName
WHERE BlogID = @BlogID",
                CreateParameter("@BlogName", blog.BlogName),
                CreateParameter("@BlogID", blog.BlogID)
                );
        }

        /// <summary>
        /// Updates the blog.
        /// </summary>
        /// <param name="blogID">The blog ID.</param>
        /// <param name="blogName">Name of the blog.</param>
        /// <returns></returns>
        public int UpdateBlog(int blogID, string blogName)
        {
            return ExecuteNonQuery(
                @"UPDATE TBlog
SET 
    BlogName = @BlogName
WHERE BlogID = @BlogID",
                CreateParameter("@BlogName", blogName),
                CreateParameter("@BlogID", blogID)
            );
        }

        /// <summary>
        /// Deletes the blog.
        /// </summary>
        /// <param name="blog">The blog.</param>
        /// <returns></returns>
        public int DeleteBlog(EBlog blog)
        {
            return ExecuteNonQuery(
                @"DELETE TBlog WHERE BlogID = @BlogID;",
                CreateParameter("@BlogID", blog.BlogID)
            );
        }

        /// <summary>
        /// Deletes the blog.
        /// </summary>
        /// <param name="blogID">The blog ID.</param>
        /// <returns></returns>
        public int DeleteBlog(int blogID)
        {
            return ExecuteNonQuery(
                @"DELETE TBlog WHERE BlogID = @BlogID;",
                CreateParameter("@BlogID", blogID)
            );
        }





        /// <summary>
        /// Changes the specified SDR.
        /// </summary>
        /// <param name="sdr">The SDR.</param>
        /// <returns></returns>
        protected EBlog Change(IDataReader sdr)
        {
            return new EBlog()
            {
                BlogID = sdr.GetInt32(sdr.GetOrdinal("BlogID")),
                BlogName = sdr.GetString(sdr.GetOrdinal("BlogName"))
            };
        }
    }
}
