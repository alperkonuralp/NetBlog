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
    /// Blog Page Comment Data Context
    /// </summary>
    public class BlogPageCommentDataContext : DataContextBase
    {

        /// <summary>
        /// Gets all comments.
        /// </summary>
        /// <returns></returns>
        public List<BBlogPageComment> GetAllComments()
        {
            using (var datas = new BlogPageCommentDataManager())
            {
                return datas
                    .GetAllComments()
                    .Select(x => Change(x))
                    .ToList();
            }
        }

        /// <summary>
        /// Gets the comments by page.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        public List<BBlogPageComment> GetCommentsByPage(
            BBlogPage page)
        {
            using (var datas = new BlogPageCommentDataManager())
            {
                return datas
                    .GetCommentsByPageID(page.PageID)
                    .Select(x => { var a = Change(x); a.Page = page; return a; })
                    .ToList();
            }
        }





        /// <summary>
        /// Changes the specified comment.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <returns></returns>
        protected BBlogPageComment Change(EBlogPageComment comment)
        {
            return new BBlogPageComment()
            {
                Approved = comment.Approved,
                CommentDate = comment.CommentDate,
                CommentID = comment.CommentID,
                Content = comment.Content,
                PageID = comment.PageID,
                Title = comment.Title,
                UserID = comment.UserID,
                WriterName = comment.WriterName
            };
        }
    }
}
