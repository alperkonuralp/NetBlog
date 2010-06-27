using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetBlog.Controller.Common;
using NetBlog.Controller.Entities;
using NetBlog.Model.DataManagers;

namespace NetBlog.Controller.DataContexts
{
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
                    .Select(x => new BBlog() { BlogID = x.BlogID, BlogName = x.BlogName })
                    .ToList();
        }
    }
}
