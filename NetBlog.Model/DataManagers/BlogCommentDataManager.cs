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
    /// Blog Comment Data Manager
    /// </summary>
    public class BlogCommentDataManager : DataManagerBase
    {

        /// <summary>
        /// Gets all comments.
        /// </summary>
        /// <returns></returns>
        public List<EBlogComment> GetAllComments()
        {
            return ExecuteToList<EBlogComment>(
                "SELECT * FROM TBlogComment;",
                Change);
        }

        public List<EBlogComment> GetCommentsByPostID(
            int postID)
        {
            return ExecuteToList<EBlogComment>(
                "SELECT * FROM TBlogComment WHERE PostID = @PostID;",
                Change,
                CreateParameter("@PostID", postID));
        }


        /// <summary>
        /// Inserts the comment.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <returns></returns>
        public int InsertComment(EBlogComment comment)
        {
            return ExecuteInsertQueryReturnID(
                "TBlogComment",
                new Dictionary<string, object>() { 
                    {"PostID", comment.PostID},
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
        /// <param name="postID">The post ID.</param>
        /// <param name="userID">The user ID.</param>
        /// <param name="writerName">Name of the writer.</param>
        /// <param name="title">The title.</param>
        /// <param name="content">The content.</param>
        /// <param name="commentDate">The comment date.</param>
        /// <param name="approved">The approved.</param>
        /// <returns></returns>
        public int InsertComment(int postID,
            Guid? userID, string writerName,
            string title, string content,
            DateTime? commentDate, bool? approved)
        {
            return ExecuteInsertQueryReturnID(
                "TBlogComment",
                new Dictionary<string, object>() { 
                    {"PostID", postID},
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
        public int UpdateComment(EBlogComment comment)
        {
            return ExecuteNonQuery(
                @"UPDATE TBlogComment
SET
    PostID = @PostID,
    UserID = @UserID,
    WriterName = @WriterName,
    Title = @Title,
    [Content] = @Content,
    CommentDate = @CommentDate,
    Approved = @Approved
WHERE CommentID = @CommentID",
                CreateParameter("@CommentID", DbType.Int32, comment.CommentID),
                CreateParameter("@PostID", DbType.Int32, comment.PostID),
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
        /// <param name="postID">The post ID.</param>
        /// <param name="userID">The user ID.</param>
        /// <param name="writerName">Name of the writer.</param>
        /// <param name="title">The title.</param>
        /// <param name="content">The content.</param>
        /// <param name="commentDate">The comment date.</param>
        /// <param name="approved">The approved.</param>
        /// <returns></returns>
        public int UpdateComment(int commentID, int postID,
            Guid? userID, string writerName,
            string title, string content,
            DateTime? commentDate, bool? approved)
        {
            return ExecuteNonQuery(
                @"UPDATE TBlogComment
SET
    PostID = @PostID,
    UserID = @UserID,
    WriterName = @WriterName,
    Title = @Title,
    [Content] = @Content,
    CommentDate = @CommentDate,
    Approved = @Approved
WHERE CommentID = @CommentID",
                CreateParameter("@CommentID", DbType.Int32, commentID),
                CreateParameter("@PostID", DbType.Int32, postID),
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
        public int DeleteComment(EBlogComment comment)
        {
            return ExecuteNonQuery(
                "DELETE TBlogComment WHERE CommentID = @CommentID;",
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
                "DELETE TBlogComment WHERE CommentID = @CommentID;",
                CreateParameter("CommentID", commentID)
                );
        }





        /// <summary>
        /// Changes the specified SDR.
        /// </summary>
        /// <param name="sdr">The SDR.</param>
        /// <returns>EBlogComment</returns>
        protected EBlogComment Change(IDataReader sdr)
        {
            return new EBlogComment()
            {
                CommentID = sdr.GetInt32(sdr.GetOrdinal("CommentID")),
                PostID = sdr.GetInt32(sdr.GetOrdinal("PostID")),
                Title = GetStringFromDataReader(sdr, "Title"),
                UserID = GetGuidFromDataReader(sdr, "UserID"),
                WriterName = GetStringFromDataReader(sdr, "WriterName"),
                CommentDate = sdr.GetDateTime(sdr.GetOrdinal("CommentDate")),
                Approved = sdr.GetBoolean(sdr.GetOrdinal("Approved")),
                Content = GetStringFromDataReader(sdr, "Content")
            };
        }
    }
}
