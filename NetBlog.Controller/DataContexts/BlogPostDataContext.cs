using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetBlog.Controller.Common;
using NetBlog.Model.Entities;
using NetBlog.Controller.Entities;
using NetBlog.Model.DataManagers;

namespace NetBlog.Controller.DataContexts
{
    /// <summary>
    /// Blog Post Data Context
    /// </summary>
    public class BlogPostDataContext : DataContextBase
    {

        /// <summary>
        /// Gets all posts.
        /// </summary>
        /// <returns></returns>
        public List<BBlogPost> GetAllPosts()
        {
            using (var datas = new BlogPostDataManager())
            {
                return
                    datas.GetAllBlogPosts()
                    .Select(x => Change(x))
                    .ToList();
            }
        }

        /// <summary>
        /// Gets the posts by category ID.
        /// </summary>
        /// <param name="categoryID">The category ID.</param>
        /// <returns></returns>
        public List<BBlogPost> GetPostsByCategoryID(
            int categoryID)
        {
            using (var datas = new BlogPostDataManager())
            {
                return
                    datas.GetBlogPostsByCategory(categoryID)
                    .Select(x => Change(x))
                    .ToList();
            }
        }



        /// <summary>
        /// Gets the posts by blog.
        /// </summary>
        /// <param name="blog">The blog.</param>
        /// <returns></returns>
        public List<BBlogPost> GetPostsByBlog(
            BBlog blog)
        {
            using (var datas = new BlogPostDataManager())
            {
                return
                    datas.GetBlogPostsByBlogID(blog.BlogID)
                    .Select(x => { var a = Change(x); a.Blog = blog; return a; })
                    .ToList();
            }
        }

        /// <summary>
        /// Gets the post by post ID.
        /// </summary>
        /// <param name="postID">The post ID.</param>
        /// <returns></returns>
        public BBlogPost GetPostByPostID(
            int postID)
        {
            using (var datas = new BlogPostDataManager())
            {
                return Change(datas.GetBlogPostByPostID(postID));
            }
        }

        /// <summary>
        /// Changes the specified post.
        /// </summary>
        /// <param name="post">The post.</param>
        /// <returns></returns>
        protected BBlogPost Change(EBlogPost post)
        {
            return new BBlogPost()
            {
                PostID = post.PostID,
                Author = post.Author,
                BlogID = post.BlogID,
                Content = post.Content,
                IsPublished = post.IsPublished,
                LastModifiedDate = post.LastModifiedDate,
                PublishDate = post.PublishDate,
                ReadCount = post.ReadCount,
                Summary = post.Summary,
                Title = post.Title,
                Visible = post.Visible
            };
        }
    }
}
