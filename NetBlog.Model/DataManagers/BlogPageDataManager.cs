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
    /// Blog Page Data Manager
    /// </summary>
    public class BlogPageDataManager : DataManagerBase
    {
        /// <summary>
        /// Gets all blog pages.
        /// </summary>
        /// <returns></returns>
        public List<EBlogPage> GetAllBlogPages()
        {
            return ExecuteToList<EBlogPage>(
                "SELECT * FROM TBlogPage;",
                Change);
        }



        /// <summary>
        /// Gets the blog pages by blog ID.
        /// </summary>
        /// <param name="blogID">The blog ID.</param>
        /// <returns></returns>
        public List<EBlogPage> GetBlogPagesByBlogID(
            int blogID)
        {
            return ExecuteToList<EBlogPage>(
                @"SELECT TBlogPage.*
FROM TBlogPage
WHERE BlogID = @BlogID",
                Change,
                CreateParameter("@BlogID", blogID));
        }




        /// <summary>
        /// Ges the T blog page by page ID.
        /// </summary>
        /// <param name="pageID">The page ID.</param>
        /// <returns></returns>
        public EBlogPage GetBlogPageByPageID(
            int pageID)
        {
            return ExecuteToSingleRow<EBlogPage>(
                "SELECT * FROM TBlogPage WHERE PageID = @PageID",
                Change,
                CreateParameter("@PageID", pageID));
        }

        /// <summary>
        /// Gets the blog pages by parent page ID.
        /// </summary>
        /// <param name="parentPageID">The parent page ID.</param>
        /// <returns></returns>
        public List<EBlogPage> GetBlogPagesByParentPageID(
            int? parentPageID)
        {
            return ExecuteToList<EBlogPage>(
                "SELECT * FROM TBlogPage WHERE ParentPageID = @ParentPageID",
                Change,
                CreateParameter("@ParentPageID", parentPageID));
        }


        /// <summary>
        /// Insertpages the specified page.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        public int Insertpage(EBlogPage page)
        {
            return ExecuteInsertQueryReturnID(
                "TBlogPage",
                new Dictionary<string, object>() { 
                    {"BlogID", page.BlogID},
                    {"Title", page.Title},
                    {"Content", page.Content},
                    {"Summary", page.Summary},
                    {"PublishDate", page.PublishDate},
                    {"LastModifiedDate", page.LastModifiedDate},
                    {"Author", page.Author},
                    {"IsPublished", page.IsPublished},
                    {"Visible", page.Visible},
                    {"ReadCount", page.ReadCount},
                    {"OrderNo", page.OrderNo},
                    {"ParentPageID", page.ParentPageID},
                });
        }


        /// <summary>
        /// Insertpages the specified blog ID.
        /// </summary>
        /// <param name="blogID">The blog ID.</param>
        /// <param name="parentPageID">The parent page ID.</param>
        /// <param name="title">The title.</param>
        /// <param name="content">The content.</param>
        /// <param name="summary">The summary.</param>
        /// <param name="publishDate">The publish date.</param>
        /// <param name="lastModifiedDate">The last modified date.</param>
        /// <param name="author">The author.</param>
        /// <param name="isPublished">The is published.</param>
        /// <param name="visible">The visible.</param>
        /// <param name="readCount">The read count.</param>
        /// <param name="orderNo">The order no.</param>
        /// <returns></returns>
        public int Insertpage(
            int blogID,
            int? parentPageID,
            string title,
            string content,
            string summary,
            DateTime? publishDate,
            DateTime? lastModifiedDate,
            Guid author,
            bool? isPublished,
            bool? visible,
            int? readCount,
            int orderNo)
        {
            return ExecuteNonQuery(
                @"INSERT INTO TBlogPage(
BlogID, Title, [Content], Summary, PublishDate, LastModifiedDate, Author, IsPublished, Visible, ReadCount, OrderNo, ParentPageID) 
VALUES (
@BlogID, @Title, @Content, @Summary, @PublishDate, @LastModifiedDate, @Author, @IsPublished, @Visible, @ReadCount, @OrderNo, @ParentPageID);",
                CreateParameter("@BlogID", blogID),
                CreateParameter("@Title", title),
                CreateParameter("@Content", content),
                CreateParameter("@Summary", summary),
                CreateParameter("@PublishDate", publishDate ?? DateTime.Now),
                CreateParameter("@LastModifiedDate", lastModifiedDate ?? DateTime.Now),
                CreateParameter("@Author", author),
                CreateParameter("@IsPublished", isPublished ?? false),
                CreateParameter("@Visible", visible ?? true),
                CreateParameter("@ReadCount", readCount ?? 1),
                CreateParameter("@OrderNo", orderNo),
                CreateParameter("@ParentPageID", parentPageID)
                );
        }



        /// <summary>
        /// Updatepages the specified page.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        public int Updatepage(EBlogPage page)
        {
            return ExecuteNonQuery(
                @"UPDATE TBlogPage 
SET 
    BlogID = @BlogID,
    Title = @Title,
    [Content] = @Content,
    Summary = @Summary,
    PublishDate = @PublishDate,
    LastModifiedDate = @LastModifiedDate,
    Author = @Author,
    IsPublished = @IsPublished,
    Visible = @Visible,
    ReadCount = @ReadCount,
    OrderNo = @OrderNo,
    ParentPageID = @ParentPageID
WHERE 
    pageID = @pageID;",
                CreateParameter("@BlogID", page.BlogID),
                CreateParameter("@Title", page.Title),
                CreateParameter("@Content", page.Content),
                CreateParameter("@Summary", page.Summary),
                CreateParameter("@PublishDate", page.PublishDate),
                CreateParameter("@LastModifiedDate", page.LastModifiedDate),
                CreateParameter("@Author", page.Author),
                CreateParameter("@IsPublished", page.IsPublished),
                CreateParameter("@Visible", page.Visible),
                CreateParameter("@ReadCount", page.ReadCount),
                CreateParameter("@OrderNo", page.OrderNo),
                CreateParameter("@ParentPageID", page.ParentPageID),
                CreateParameter("@pageID", page.PageID));

        }


        /// <summary>
        /// Updatepages the specified page ID.
        /// </summary>
        /// <param name="pageID">The page ID.</param>
        /// <param name="parentPageID">The parent page ID.</param>
        /// <param name="blogID">The blog ID.</param>
        /// <param name="title">The title.</param>
        /// <param name="content">The content.</param>
        /// <param name="summary">The summary.</param>
        /// <param name="publishDate">The publish date.</param>
        /// <param name="lastModifiedDate">The last modified date.</param>
        /// <param name="author">The author.</param>
        /// <param name="isPublished">The is published.</param>
        /// <param name="visible">The visible.</param>
        /// <param name="readCount">The read count.</param>
        /// <param name="orderNo">The order no.</param>
        /// <returns></returns>
        public int Updatepage(
            int pageID,
            int? parentPageID,
            int blogID,
            string title,
            string content,
            string summary,
            DateTime? publishDate,
            DateTime? lastModifiedDate,
            Guid author,
            bool? isPublished,
            bool? visible,
            int? readCount,
            int orderNo)
        {
            return ExecuteNonQuery(
                @"UPDATE TBlogPage 
SET 
    BlogID = @BlogID,
    Title = @Title,
    [Content] = @Content,
    Summary = @Summary,
    PublishDate = @PublishDate,
    LastModifiedDate = @LastModifiedDate,
    Author = @Author,
    IsPublished = @IsPublished,
    Visible = @Visible,
    ReadCount = @ReadCount,
    OrderNo = @OrderNo,
    ParentPageID = @ParentPageID
WHERE 
    pageID = @pageID;",
                CreateParameter("@BlogID", blogID),
                CreateParameter("@Title", title),
                CreateParameter("@Content", content),
                CreateParameter("@Summary", summary),
                CreateParameter("@PublishDate", publishDate),
                CreateParameter("@LastModifiedDate", lastModifiedDate),
                CreateParameter("@Author", author),
                CreateParameter("@IsPublished", isPublished),
                CreateParameter("@Visible", visible),
                CreateParameter("@ReadCount", readCount),
                CreateParameter("@OrderNo", orderNo),
                CreateParameter("@ParentPageID", parentPageID),
                CreateParameter("@pageID", pageID));

        }



        /// <summary>
        /// Deletepages the specified page.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        public int Deletepage(EBlogPage page)
        {
            return ExecuteNonQuery(
                @"Delete TBlogPage 
WHERE 
    pageID = @pageID;",
                CreateParameter("@pageID", page.PageID));

        }


        /// <summary>
        /// Deletepages the specified page ID.
        /// </summary>
        /// <param name="pageID">The page ID.</param>
        /// <returns></returns>
        public int Deletepage(int pageID)
        {
            return ExecuteNonQuery(
                @"Delete TBlogPage 
WHERE 
    pageID = @pageID;",
                CreateParameter("@pageID", pageID));

        }







        /// <summary>
        /// Changes the specified SDR.
        /// </summary>
        /// <param name="sdr">The SDR.</param>
        /// <returns></returns>
        protected EBlogPage Change(IDataReader sdr)
        {
            return new EBlogPage()
            {
                PageID = sdr.GetInt32(sdr.GetOrdinal("PageID")),
                BlogID = sdr.GetInt32(sdr.GetOrdinal("BlogID")),
                Title = GetStringFromDataReader(sdr, "Title"),
                Content = GetStringFromDataReader(sdr, "Content"),
                Summary = GetStringFromDataReader(sdr, "Summary"),
                PublishDate = sdr.GetDateTime(sdr.GetOrdinal("PublishDate")),
                LastModifiedDate = sdr.GetDateTime(sdr.GetOrdinal("LastModifiedDate")),
                IsPublished = sdr.GetBoolean(sdr.GetOrdinal("IsPublished")),
                Visible = sdr.GetBoolean(sdr.GetOrdinal("Visible")),
                Author = sdr.GetGuid(sdr.GetOrdinal("AuthorID")),
                ReadCount = sdr.GetInt32(sdr.GetOrdinal("ReadCount")),
                OrderNo = sdr.GetInt32(sdr.GetOrdinal("OrderNo")),
                ParentPageID = GetInt32FromDataReader(sdr, "PatentPageID")
            };
        }
    }
}

