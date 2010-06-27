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
    /// Blog Tag Data Context
    /// </summary>
    public class BlogTagDataContext : DataContextBase
    {

        /// <summary>
        /// Gets all tags.
        /// </summary>
        /// <returns></returns>
        public List<BBlogTag> GetAllTags()
        {
            using (var datas = new BlogTagDataManager())
            {
                return datas.GetAllTags()
                    .Select(x => Change(x))
                    .ToList();
            }
        }

        /// <summary>
        /// Gets the tags by post.
        /// </summary>
        /// <param name="post">The post.</param>
        /// <returns></returns>
        public List<BBlogTag> GetTagsByPost(BBlogPost post)
        {
            using (var datas = new BlogTagDataManager())
            {
                return datas.GetTagsByPostID(post.PostID)
                    .Select(x => { var a = Change(x); a.Post = post; return a; })
                    .ToList();
            }
        }


        /// <summary>
        /// Changes the specified tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <returns></returns>
        protected BBlogTag Change(EBlogTag tag)
        {
            return new BBlogTag()
            {
                PostID = tag.PostID,
                Tag = tag.Tag
            };
        }
    }
}
