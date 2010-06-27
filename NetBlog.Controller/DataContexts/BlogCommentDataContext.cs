using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetBlog.Controller.Common;
using NetBlog.Controller.Entities;
using NetBlog.Model.Entities;
using NetBlog.Model.DataManagers;

namespace NetBlog.Controller.DataContexts
{
    /// <summary>
    /// Blog Comment Data Context
    /// </summary>
    public class BlogCommentDataContext : DataContextBase
    {
        /// <summary>
        /// Gets all comments.
        /// </summary>
        /// <returns></returns>
        public List<BBlogComment> GetAllComments()
        {
            using (var datas = new BlogCommentDataManager())
            {
                return datas
                    .GetAllComments()
                    .Select(x => Change(x))
                    .ToList();
            }
        }


        /// <summary>
        /// Gets the comments by post.
        /// </summary>
        /// <param name="post">The post.</param>
        /// <returns></returns>
        public List<BBlogComment> GetCommentsByPost(
            BBlogPost post)
        {
            using (var datas = new BlogCommentDataManager())
            {
                return datas
                    .GetCommentsByPostID(post.PostID)
                    .Select(x => { var a = Change(x); a.Post = post; return a; })
                    .ToList();
            }
        }


        /// <summary>
        /// Changes the specified comment.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <returns></returns>
        protected BBlogComment Change(EBlogComment comment)
        {
            return new BBlogComment()
            {
                Approved = comment.Approved,
                CommentDate = comment.CommentDate,
                CommentID = comment.CommentID,
                Content = comment.Content,
                PostID = comment.PostID,
                Title = comment.Title,
                UserID = comment.UserID,
                WriterName = comment.WriterName
            };
        }
    }
}
