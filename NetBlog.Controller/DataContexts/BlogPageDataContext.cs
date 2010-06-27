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
    /// 
    /// </summary>
    public class BlogPageDataContext : DataContextBase
    {
        /// <summary>
        /// Gets all pages.
        /// </summary>
        /// <returns></returns>
        public List<BBlogPage> GetAllPages()
        {
            using (var datas = new BlogPageDataManager())
            {
                return
                    datas.GetAllBlogPages()
                    .Select(x => Change(x))
                    .ToList();
            }
        }


        /// <summary>
        /// Gets the pages by blog.
        /// </summary>
        /// <param name="blog">The blog.</param>
        /// <returns></returns>
        public List<BBlogPage> GetPagesByBlog(
            BBlog blog)
        {
            using (var datas = new BlogPageDataManager())
            {
                return
                    datas.GetBlogPagesByBlogID(blog.BlogID)
                    .Select(x => { var a = Change(x); a.Blog = blog; return a; })
                    .ToList();
            }
        }



        /// <summary>
        /// Gets the pages by parent page.
        /// </summary>
        /// <param name="parentPage">The parent page.</param>
        /// <returns></returns>
        public List<BBlogPage> GetPagesByParentPage(
           BBlogPage parentPage)
        {
            using (var datas = new BlogPageDataManager())
            {
                return
                    datas.GetBlogPagesByParentPageID(parentPage.PageID)
                    .Select(x => { var a = Change(x); a.Parent = parentPage; return a; })
                    .ToList();
            }
        }


        /// <summary>
        /// Gets the page by page ID.
        /// </summary>
        /// <param name="pageID">The page ID.</param>
        /// <returns></returns>
        public BBlogPage GetPageByPageID(
           int pageID)
        {
            using (var datas = new BlogPageDataManager())
            {
                return
                    Change(datas.GetBlogPageByPageID(pageID));
            }
        }


        /// <summary>
        /// Changes the specified page.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        protected BBlogPage Change(EBlogPage page)
        {
            return new BBlogPage()
            {
                PageID = page.PageID,
                ParentPageID = page.ParentPageID,
                Author = page.Author,
                BlogID = page.BlogID,
                Content = page.Content,
                IsPublished = page.IsPublished,
                LastModifiedDate = page.LastModifiedDate,
                PublishDate = page.PublishDate,
                ReadCount = page.ReadCount,
                Summary = page.Summary,
                Title = page.Title,
                Visible = page.Visible,
                OrderNo = page.OrderNo
            };
        }


    }
}
