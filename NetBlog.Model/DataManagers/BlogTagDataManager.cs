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
        /// <summary>
        /// Gets all tags.
        /// </summary>
        /// <returns></returns>
        public List<EBlogTag> GetAllTags()
        {
            return ExecuteToList<EBlogTag>(
                "SELECT * FROM TBlogTag;",
                Change);
        }


        /// <summary>
        /// Gets the tags by post ID.
        /// </summary>
        /// <param name="postID">The post ID.</param>
        /// <returns></returns>
        public List<EBlogTag> GetTagsByPostID(
            int postID)
        {
            return ExecuteToList<EBlogTag>(
                "SELECT * FROM TBlogTag WHERE PostID = @PostID;",
                Change,
                CreateParameter("@PostID", postID));
        }


        /// <summary>
        /// Inserts the tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <returns></returns>
        public int InsertTag(EBlogTag tag)
        {
            return ExecuteNonQuery(
                @"INSERT INTO TBlogTag (PostID, Tag)
VALUES (@PostID, @Tag)",
                       CreateParameter("@PostID", tag.PostID),
                       CreateParameter("@Tag", tag.Tag));
        }


        /// <summary>
        /// Inserts the tag.
        /// </summary>
        /// <param name="postID">The post ID.</param>
        /// <param name="tag">The tag.</param>
        /// <returns></returns>
        public int InsertTag(
            int postID,
            string tag)
        {
            return ExecuteNonQuery(
                @"INSERT INTO TBlogTag (PostID, Tag)
VALUES (@PostID, @Tag)",
                       CreateParameter("@PostID", postID),
                       CreateParameter("@Tag", tag));
        }


        /// <summary>
        /// Deletes the tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <returns></returns>
        public int DeleteTag(EBlogTag tag)
        {
            return ExecuteNonQuery(
                @"Delete TBlogTag WHERE PostID = @PostID AND Tag = @Tag",
                       CreateParameter("@PostID", tag.PostID),
                       CreateParameter("@Tag", tag.Tag));
        }

        /// <summary>
        /// Deletes the tag.
        /// </summary>
        /// <param name="postID">The post ID.</param>
        /// <param name="tag">The tag.</param>
        /// <returns></returns>
        public int DeleteTag(int postID, string tag)
        {
            return ExecuteNonQuery(
                @"Delete TBlogTag WHERE PostID = @PostID AND Tag = @Tag",
                       CreateParameter("@PostID", postID),
                       CreateParameter("@Tag", tag));
        }




        /// <summary>
        /// Changes the specified SDR.
        /// </summary>
        /// <param name="sdr">The SDR.</param>
        /// <returns></returns>
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
