using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetBlog.Controller.Common;
using NetBlog.Controller.Entities;
using NetBlog.Model.DataManagers;
using NetBlog.Model.Entities;

namespace NetBlog.Controller.DataContexts
{
    /// <summary>
    /// Blog Data Context
    /// </summary>
    public class BlogDataContext : DataContextBase
    {
        /// <summary>
        /// Get All Blogs Data
        /// </summary>
        /// <returns></returns>
        public List<BBlog> GetAllBlogs()
        {
            return
                new BlogDataManager()
                    .GetAllBlogs()
                    .Select(x => Change(x))
                    .ToList();
        }

        /// <summary>
        /// Gets the blog by blog ID.
        /// </summary>
        /// <param name="blogID">The blog ID.</param>
        /// <returns></returns>
        public BBlog GetBlogByBlogID(
            int blogID)
        {
            return Change(new BlogDataManager().GetBlogByID(blogID));
        }


        /// <summary>
        /// Changes the specified blog.
        /// </summary>
        /// <param name="blog">The blog.</param>
        /// <returns></returns>
        protected BBlog Change(EBlog blog)
        {
            return new BBlog()
            {
                BlogID = blog.BlogID,
                BlogName = blog.BlogName
            };
        }
    }
}
