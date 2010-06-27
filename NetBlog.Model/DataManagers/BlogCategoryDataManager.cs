using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetBlog.Model.Common;
using NetBlog.Model.Entities;
using System.Data.SqlClient;
using System.Data;

namespace NetBlog.Model.DataManagers
{
    /// <summary>
    /// Blog Category Data Manager
    /// </summary>
    public class BlogCategoryDataManager : DataManagerBase
    {
        /// <summary>
        /// Gets all categories.
        /// </summary>
        /// <returns></returns>
        public List<EBlogCategory> GetAllCategories()
        {
            return ExecuteToList<EBlogCategory>(
                "SELECT * FROM TBlogCategory;",
                Change);
        }

        /// <summary>
        /// Gets the categories by parent ID.
        /// </summary>
        /// <param name="parentID">The parent ID.</param>
        /// <returns></returns>
        public List<EBlogCategory> GetCategoriesByParentID(
            int? parentID)
        {
            return ExecuteToList<EBlogCategory>(
                "SELECT * FROM TBlogCategory WHERE ParentCategoryID = @ParentCategoryID;",
                Change,
                CreateParameter("@ParentCategoryID", DbType.Int32, parentID));
        }


        public List<EBlogCategory> GetCategoriesByPostID(
            int postID)
        {
            return ExecuteToList<EBlogCategory>(
                @"SELECT * FROM TBlogCategory 
INNER JOIN TBlogPostCategory
ON TBlogCategory.CategoryID = TBlogPostCategory.CategoryID
WHERE TBlogPostCategory.PostID = @PostID;",
                Change,
                CreateParameter("@PostID", postID));
        }

        /// <summary>
        /// Gets the category by ID.
        /// </summary>
        /// <param name="categoryID">The category ID.</param>
        /// <returns></returns>
        public EBlogCategory GetCategoryByID(
            int categoryID)
        {
            return ExecuteToSingleRow<EBlogCategory>(
                "SELECT * FROM TBlogCategory WHERE CategoryID = @CategoryID;",
                Change,
                CreateParameter("@CategoryID", categoryID));
        }


        /// <summary>
        /// Inserts the category.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns></returns>
        public int InsertCategory(EBlogCategory category)
        {
            return ExecuteInsertQueryReturnID(
                "TBlogCategory",
                new Dictionary<string, object>() { 
                    {"ParentCategoryID",category.ParentCategoryID},
                    {"CategoryName",category.CategoryName},
                    {"OrderNo",category.OrderNo}                
                });
        }

        /// <summary>
        /// Inserts the category.
        /// </summary>
        /// <param name="parentCategoryID">The parent category ID.</param>
        /// <param name="categoryName">Name of the category.</param>
        /// <param name="orderNo">The order no.</param>
        /// <returns></returns>
        public int InsertCategory(int? parentCategoryID,
            string categoryName,
            int orderNo)
        {
            return ExecuteInsertQueryReturnID(
                "TBlogCategory",
                new Dictionary<string, object>() { 
                    {"ParentCategoryID",parentCategoryID},
                    {"CategoryName",categoryName},
                    {"OrderNo",orderNo}                
                });
        }




        /// <summary>
        /// Updates the category.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns></returns>
        public int UpdateCategory(EBlogCategory category)
        {
            return ExecuteNonQuery(
                @"UPDATE TBlogCategory
SET
    ParentCategoryID = @ParentCategoryID,
    CategoryName = @CategoryName,
    OrderNo = @OrderNo
WHERE 
    CategoryID = @CategoryID;",
                CreateParameter("@ParentCategoryID", category.ParentCategoryID),
                CreateParameter("@CategoryName", category.CategoryName),
                CreateParameter("@OrderNo", category.OrderNo),
                CreateParameter("@CategoryID", category.CategoryID)
);
        }

        /// <summary>
        /// Updates the category.
        /// </summary>
        /// <param name="categoryID">The category ID.</param>
        /// <param name="parentCategoryID">The parent category ID.</param>
        /// <param name="categoryName">Name of the category.</param>
        /// <param name="orderNo">The order no.</param>
        /// <returns></returns>
        public int UpdateCategory(
            int categoryID,
            int? parentCategoryID,
            string categoryName,
            int orderNo)
        {
            return ExecuteNonQuery(
                @"UPDATE TBlogCategory
SET
    ParentCategoryID = @ParentCategoryID,
    CategoryName = @CategoryName,
    OrderNo = @OrderNo
WHERE 
    CategoryID = @CategoryID;",
                CreateParameter("@ParentCategoryID", parentCategoryID),
                CreateParameter("@CategoryName", categoryName),
                CreateParameter("@OrderNo", orderNo),
                CreateParameter("@CategoryID", categoryID)
);
        }

        /// <summary>
        /// Deletes the category.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns></returns>
        public int DeleteCategory(EBlogCategory category)
        {
            return ExecuteNonQuery(
                "DELETE TBlogCategory WHERE CategoryID = @CategoryID;",
                CreateParameter("@CategoryID", category.CategoryID)
                );
        }

        /// <summary>
        /// Deletes the category.
        /// </summary>
        /// <param name="categoryID">The category ID.</param>
        /// <returns></returns>
        public int DeleteCategory(int categoryID)
        {
            return ExecuteNonQuery(
                "DELETE TBlogCategory WHERE CategoryID = @CategoryID;",
                CreateParameter("@CategoryID", categoryID)
                );
        }




        /// <summary>
        /// Adds the category to posts.
        /// </summary>
        /// <param name="categoryID">The category ID.</param>
        /// <param name="postIDs">The post I ds.</param>
        /// <returns></returns>
        public int AddCategoryToPosts(
            int categoryID,
            params int[] postIDs)
        {
            StringBuilder sb = new StringBuilder();
            SqlParameter[] spa =
                new SqlParameter[postIDs.Length + 1];
            int i = 0;
            foreach (var item in postIDs)
            {
                sb.AppendFormat(@"
INSERT TBlogPostCategory(PostID, CategoryID) 
VALUES (@PostID{0},@CategoryID);", i);
                spa[i] =
                    new SqlParameter("@PostID" + i, item);
                i++;
            }
            spa[postIDs.Length] =
                new SqlParameter("@CategoryID", categoryID);

            return ExecuteNonQuery(
                sb.ToString(),
                spa);

        }


        /// <summary>
        /// Removes the category to posts.
        /// </summary>
        /// <param name="categoryID">The category ID.</param>
        /// <param name="postIDs">The post I ds.</param>
        /// <returns></returns>
        public int RemoveCategoryToPosts(
            int categoryID,
            params int[] postIDs)
        {

            return ExecuteNonQuery(
                string.Format(@"DELETE TBlogPostCategory 
WHERE CategoryID = @CategoryID AND PostID IN ({0})",
                string.Join(", ", postIDs.Select(x => x.ToString()).ToArray())),
                new SqlParameter("@CategoryID", categoryID));

        }


















        /// <summary>
        /// Changes the specified SDR.
        /// </summary>
        /// <param name="sdr">The SDR.</param>
        /// <returns></returns>
        private EBlogCategory Change(IDataReader sdr)
        {
            return new EBlogCategory()
            {
                CategoryID = sdr.GetInt32(sdr.GetOrdinal("CategoryID")),
                ParentCategoryID = GetInt32FromDataReader(sdr, "CategoryID"),
                CategoryName = GetStringFromDataReader(sdr, "CategoryName"),
                OrderNo = sdr.GetInt32(sdr.GetOrdinal("OrderNo"))
            };
        }
    }
}
