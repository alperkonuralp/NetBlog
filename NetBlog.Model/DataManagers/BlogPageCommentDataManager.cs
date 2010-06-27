using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetBlog.Model.Common;
using NetBlog.Model.Entities;
using System.Data;

namespace NetBlog.Model.DataManagers
{
    /// <summary>
    /// Blog Page Comment Data Manager
    /// </summary>
    public class BlogPageCommentDataManager : DataManagerBase
    {
        /// <summary>
        /// Gets all comments.
        /// </summary>
        /// <returns></returns>
        public List<EBlogPageComment> GetAllComments()
        {
            return ExecuteToList<EBlogPageComment>(
                "SELECT * FROM TBlogPageComment;",
                Change);
        }

        /// <summary>
        /// Gets the comments by page ID.
        /// </summary>
        /// <param name="pageID">The page ID.</param>
        /// <returns></returns>
        public List<EBlogPageComment> GetCommentsByPageID(
            int pageID)
        {
            return ExecuteToList<EBlogPageComment>(
                "SELECT * FROM TBlogPageComment WHERE PageID = @PageID;",
                Change,
                CreateParameter("@PageID", pageID));
        }

        /// <summary>
        /// Gets the comment by comment ID.
        /// </summary>
        /// <param name="commentID">The comment ID.</param>
        /// <returns></returns>
        public EBlogPageComment GetCommentByCommentID(
            int commentID)
        {
            return ExecuteToSingleRow<EBlogPageComment>(
                "SELECT * FROM TBlogPageComment WHERE CommentID = @CommentID;",
                Change,
                CreateParameter("@CommentID", commentID));
        }

        /// <summary>
        /// Inserts the comment.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <returns></returns>
        public int InsertComment(EBlogPageComment comment)
        {
            return ExecuteInsertQueryReturnID(
                "TBlogPageComment",
                new Dictionary<string, object>() { 
                    {"PageID", comment.PageID},
                    {"UserID", comment.UserID},
                    {"WriterName", comment.WriterName},
                    {"Title", comment.Title},
                    {"Content", comment.Content},
                    {"CommentDate", comment.CommentDate},
                    {"Approved", comment.Approved},

                });
        }


        /// <summary>
        /// Inserts the comment.
        /// </summary>
        /// <param name="pageID">The page ID.</param>
        /// <param name="userID">The user ID.</param>
        /// <param name="writerName">Name of the writer.</param>
        /// <param name="title">The title.</param>
        /// <param name="content">The content.</param>
        /// <param name="commentDate">The comment date.</param>
        /// <param name="approved">The approved.</param>
        /// <returns></returns>
        public int InsertComment(int pageID,
            Guid? userID, string writerName,
            string title, string content,
            DateTime? commentDate, bool? approved)
        {
            return ExecuteInsertQueryReturnID(
                "TBlogPageComment",
                new Dictionary<string, object>() { 
                    {"PageID", pageID},
                    {"UserID", userID},
                    {"WriterName", writerName},
                    {"Title", title},
                    {"Content", content},
                    {"CommentDate", commentDate ?? DateTime.Now},
                    {"Approved", approved ?? false}
                });
        }




        /// <summary>
        /// Updates the comment.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <returns></returns>
        public int UpdateComment(EBlogPageComment comment)
        {
            return ExecuteNonQuery(
                @"UPDATE TBlogPageComment
SET
    PageID = @PageID,
    UserID = @UserID,
    WriterName = @WriterName,
    Title = @Title,
    [Content] = @Content,
    CommentDate = @CommentDate,
    Approved = @Approved
WHERE CommentID = @CommentID",
                CreateParameter("@CommentID", DbType.Int32, comment.CommentID),
                CreateParameter("@PageID", DbType.Int32, comment.PageID),
                CreateParameter("@UserID", DbType.Guid, comment.UserID),
                CreateParameter("@WriterName", DbType.String, comment.WriterName),
                CreateParameter("@Title", DbType.String, comment.Title),
                CreateParameter("@Content", DbType.String, comment.Content),
                CreateParameter("@CommentDate", DbType.DateTime, comment.CommentDate),
                CreateParameter("@Approved", DbType.Boolean, comment.Approved));
        }


        /// <summary>
        /// Updates the comment.
        /// </summary>
        /// <param name="commentID">The comment ID.</param>
        /// <param name="pageID">The page ID.</param>
        /// <param name="userID">The user ID.</param>
        /// <param name="writerName">Name of the writer.</param>
        /// <param name="title">The title.</param>
        /// <param name="content">The content.</param>
        /// <param name="commentDate">The comment date.</param>
        /// <param name="approved">The approved.</param>
        /// <returns></returns>
        public int UpdateComment(int commentID, int pageID,
            Guid? userID, string writerName,
            string title, string content,
            DateTime? commentDate, bool? approved)
        {
            return ExecuteNonQuery(
                @"UPDATE TBlogPageComment
SET
    PageID = @PageID,
    UserID = @UserID,
    WriterName = @WriterName,
    Title = @Title,
    [Content] = @Content,
    CommentDate = @CommentDate,
    Approved = @Approved
WHERE CommentID = @CommentID",
                CreateParameter("@CommentID", DbType.Int32, commentID),
                CreateParameter("@PageID", DbType.Int32, pageID),
                CreateParameter("@UserID", DbType.Guid, userID),
                CreateParameter("@WriterName", DbType.String, writerName),
                CreateParameter("@Title", DbType.String, title),
                CreateParameter("@Content", DbType.String, content),
                CreateParameter("@CommentDate", DbType.DateTime, commentDate),
                CreateParameter("@Approved", DbType.Boolean, approved));
        }



        /// <summary>
        /// Deletes the comment.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <returns></returns>
        public int DeleteComment(EBlogPageComment comment)
        {
            return ExecuteNonQuery(
                "DELETE TBlogPageComment WHERE CommentID = @CommentID;",
                CreateParameter("CommentID", comment.CommentID)
                );
        }



        /// <summary>
        /// Deletes the comment.
        /// </summary>
        /// <param name="commentID">The comment ID.</param>
        /// <returns></returns>
        public int DeleteComment(int commentID)
        {
            return ExecuteNonQuery(
                "DELETE TBlogPageComment WHERE CommentID = @CommentID;",
                CreateParameter("CommentID", commentID)
                );
        }












        /// <summary>
        /// Changes the specified SDR.
        /// </summary>
        /// <param name="sdr">The SDR.</param>
        /// <returns></returns>
        protected EBlogPageComment Change(IDataReader sdr)
        {
            return new EBlogPageComment()
            {
                CommentID = sdr.GetInt32(sdr.GetOrdinal("CommentID")),
                PageID = sdr.GetInt32(sdr.GetOrdinal("PageID")),
                Title = GetStringFromDataReader(sdr, "Title"),
                Content = GetStringFromDataReader(sdr, "Content"),
                CommentDate = sdr.GetDateTime(sdr.GetOrdinal("CommentDate")),
                UserID = GetGuidFromDataReader(sdr, "UserID"),
                WriterName = GetStringFromDataReader(sdr, "WriterName"),
                Approved = sdr.GetBoolean(sdr.GetOrdinal("Approved"))
            };
        }
    }
}
