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
    /// Blog Category Data Context
    /// </summary>
    public class BlogCategoryDataContext : DataContextBase
    {

        /// <summary>
        /// Gets all categories.
        /// </summary>
        /// <returns></returns>
        public List<BBlogCategory> GetAllCategories()
        {
            using (var datas = new BlogCategoryDataManager())
            {
                return datas
                    .GetAllCategories()
                    .Select(x => Change(x))
                    .ToList();
            }
        }
        /// <summary>
        /// Gets the categories by post.
        /// </summary>
        /// <param name="post">The post.</param>
        /// <returns></returns>
        public List<BBlogCategory> GetCategoriesByPost(
            BBlogPost post)
        {
            using (var datas = new BlogCategoryDataManager())
            {
                return datas
                    .GetCategoriesByPostID(post.PostID)
                    .Select(x => Change(x))
                    .ToList();
            }
        }

        /// <summary>
        /// Gets the categories by parent category.
        /// </summary>
        /// <param name="parentCategory">The parent category.</param>
        /// <returns></returns>
        public List<BBlogCategory> GetCategoriesByParentCategory(
            BBlogCategory parentCategory)
        {
            using (var datas = new BlogCategoryDataManager())
            {
                return datas
                    .GetCategoriesByParentID(parentCategory.CategoryID)
                    .Select(x => { var a = Change(x); a.Parent = parentCategory; return a; })
                    .ToList();
            }
        }

        /// <summary>
        /// Gets the category by category ID.
        /// </summary>
        /// <param name="categoryID">The category ID.</param>
        /// <returns></returns>
        public BBlogCategory GetCategoryByCategoryID(
            int categoryID)
        {
            using (var datas = new BlogCategoryDataManager())
            {
                return Change(datas.GetCategoryByID(categoryID));
            }
        }



        /// <summary>
        /// Changes the specified cat.
        /// </summary>
        /// <param name="cat">The cat.</param>
        /// <returns></returns>
        protected BBlogCategory Change(EBlogCategory cat)
        {
            return new BBlogCategory()
            {
                CategoryID = cat.CategoryID,
                CategoryName = cat.CategoryName,
                ParentCategoryID = cat.ParentCategoryID,
                OrderNo = cat.OrderNo
            };
        }
    }
}
