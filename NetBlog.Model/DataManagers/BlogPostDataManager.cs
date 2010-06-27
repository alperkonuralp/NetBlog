using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetBlog.Model.Common;
using NetBlog.Model.Entities;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace NetBlog.Model.DataManagers
{
    /// <summary>
    /// Blog Post Data Manager
    /// </summary>
    public class BlogPostDataManager : DataManagerBase
    {
        /// <summary>
        /// Gets all blog posts.
        /// </summary>
        /// <returns></returns>
        public List<EBlogPost> GetAllBlogPosts()
        {
            return ExecuteToList<EBlogPost>(
                "SELECT * FROM TBlogPost;",
                Change);
        }

        /// <summary>
        /// Gets the blog posts by category.
        /// </summary>
        /// <param name="categoryID">The category ID.</param>
        /// <returns></returns>
        public List<EBlogPost> GetBlogPostsByCategory(
            int categoryID)
        {
            return ExecuteToList<EBlogPost>(
                @"SELECT TBlogPost.*
FROM TBlogPost
INNER JOIN TBlogPostCategory
ON TBlogPost.PostID = TBlogPostCategory.PostID
WHERE TBlogPostCategory.CategoryID = @CategoryID",
                Change,
                CreateParameter("@CategoryID", categoryID));
        }

        /// <summary>
        /// Gets the blog posts by blog ID.
        /// </summary>
        /// <param name="blogID">The blog ID.</param>
        /// <returns></returns>
        public List<EBlogPost> GetBlogPostsByBlogID(
            int blogID)
        {
            return ExecuteToList<EBlogPost>(
                @"SELECT TBlogPost.*
FROM TBlogPost
WHERE BlogID = @BlogID",
                Change,
                CreateParameter("@BlogID", blogID));
        }

        /// <summary>
        /// Gets the blog posts by tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <returns></returns>
        public List<EBlogPost> GetBlogPostsByTag(
            string tag)
        {
            return ExecuteToList<EBlogPost>(
                @"SELECT TBlogPost.*
FROM TBlogPost
INNER JOIN TBlogPostTag
ON TBlogPost.PostID = TBlogPostTag.PostID
WHERE TBlogPostTag.Tag = @Tag",
                Change,
                CreateParameter("@Tag", tag));
        }

        /// <summary>
        /// Gets the blog post by post ID.
        /// </summary>
        /// <param name="postID">The post ID.</param>
        /// <returns></returns>
        public EBlogPost GetBlogPostByPostID(
            int postID)
        {
            return ExecuteToSingleRow<EBlogPost>(
                "SELECT * FROM TBlogPost WHERE PostID = @PostID",
                Change,
                CreateParameter("@PostID", postID));
        }


        /// <summary>
        /// Inserts the post.
        /// </summary>
        /// <param name="post">The post.</param>
        /// <returns></returns>
        public int InsertPost(EBlogPost post)
        {
            //            return ExecuteNonQuery(
            //                @"INSERT INTO TBlogPost(
            //BlogID, Title, [Content], Summary, PublishDate, LastModifiedDate, Author, IsPublished, Visible, ReadCount) 
            //VALUES (
            //@BlogID, @Title, @Content, @Summary, @PublishDate, @LastModifiedDate, @Author, @IsPublished, @Visible, @ReadCount)",
            //                CreateParameter("@BlogID", post.BlogID),
            //                CreateParameter("@Title", post.Title),
            //                CreateParameter("@Content", post.Content),
            //                CreateParameter("@Summary", post.Summary),
            //                CreateParameter("@PublishDate", post.PublishDate),
            //                CreateParameter("@LastModifiedDate", post.LastModifiedDate),
            //                CreateParameter("@Author", post.Author),
            //                CreateParameter("@IsPublished", post.IsPublished),
            //                CreateParameter("@Visible", post.Visible),
            //                CreateParameter("@ReadCount", post.ReadCount)
            //                );

            return ExecuteInsertQueryReturnID(
                "TBlogPost",
                new Dictionary<string, object>() { 
                    {"BlogID", post.BlogID},
                    {"Title", post.Title},
                    {"Content", post.Content},
                    {"Summary", post.Summary},
                    {"PublishDate", post.PublishDate},
                    {"LastModifiedDate", post.LastModifiedDate},
                    {"Author", post.Author},
                    {"IsPublished", post.IsPublished},
                    {"Visible", post.Visible},
                    {"ReadCount", post.ReadCount},
                });
        }

        /// <summary>
        /// Inserts the post.
        /// </summary>
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
        /// <returns></returns>
        public int InsertPost(
            int blogID,
            string title,
            string content,
            string summary,
            DateTime? publishDate,
            DateTime? lastModifiedDate,
            Guid author,
            bool? isPublished,
            bool? visible,
            int? readCount)
        {
            return ExecuteNonQuery(
                @"INSERT INTO TBlogPost(
BlogID, Title, [Content], Summary, PublishDate, LastModifiedDate, Author, IsPublished, Visible, ReadCount) 
VALUES (
@BlogID, @Title, @Content, @Summary, @PublishDate, @LastModifiedDate, @Author, @IsPublished, @Visible, @ReadCount)",
                CreateParameter("@BlogID", blogID),
                CreateParameter("@Title", title),
                CreateParameter("@Content", content),
                CreateParameter("@Summary", summary),
                CreateParameter("@PublishDate", publishDate ?? DateTime.Now),
                CreateParameter("@LastModifiedDate", lastModifiedDate ?? DateTime.Now),
                CreateParameter("@Author", author),
                CreateParameter("@IsPublished", isPublished ?? false),
                CreateParameter("@Visible", visible ?? true),
                CreateParameter("@ReadCount", readCount ?? 1)
                );
        }


        /// <summary>
        /// Updates the post.
        /// </summary>
        /// <param name="post">The post.</param>
        /// <returns></returns>
        public int UpdatePost(EBlogPost post)
        {
            return ExecuteNonQuery(
                @"UPDATE TBlogPost 
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
    ReadCount = @ReadCount
WHERE 
    PostID = @PostID;",
                CreateParameter("@BlogID", post.BlogID),
                CreateParameter("@Title", post.Title),
                CreateParameter("@Content", post.Content),
                CreateParameter("@Summary", post.Summary),
                CreateParameter("@PublishDate", post.PublishDate),
                CreateParameter("@LastModifiedDate", post.LastModifiedDate),
                CreateParameter("@Author", post.Author),
                CreateParameter("@IsPublished", post.IsPublished),
                CreateParameter("@Visible", post.Visible),
                CreateParameter("@ReadCount", post.ReadCount),
                CreateParameter("@PostID", post.PostID));

        }

        /// <summary>
        /// Updates the post.
        /// </summary>
        /// <param name="postID">The post ID.</param>
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
        /// <returns></returns>
        public int UpdatePost(
            int postID,
            int blogID,
            string title,
            string content,
            string summary,
            DateTime? publishDate,
            DateTime? lastModifiedDate,
            Guid author,
            bool? isPublished,
            bool? visible,
            int? readCount)
        {
            return ExecuteNonQuery(
                @"UPDATE TBlogPost 
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
    ReadCount = @ReadCount
WHERE 
    PostID = @PostID;",
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
                CreateParameter("@PostID", postID));

        }



        /// <summary>
        /// Deletes the post.
        /// </summary>
        /// <param name="post">The post.</param>
        /// <returns></returns>
        public int DeletePost(EBlogPost post)
        {
            return ExecuteNonQuery(
                @"Delete TBlogPost 
WHERE 
    PostID = @PostID;",
                CreateParameter("@PostID", post.PostID));

        }

        /// <summary>
        /// Deletes the post.
        /// </summary>
        /// <param name="postID">The post ID.</param>
        /// <returns></returns>
        public int DeletePost(int postID)
        {
            return ExecuteNonQuery(
                @"Delete TBlogPost 
WHERE 
    PostID = @PostID;",
                CreateParameter("@PostID", postID));

        }


        /// <summary>
        /// Adds the post to categories.
        /// </summary>
        /// <param name="postID">The post ID.</param>
        /// <param name="categoryIDs">The category I ds.</param>
        /// <returns></returns>
        public int AddPostToCategories(
            int postID,
            params int[] categoryIDs)
        {
            StringBuilder sb = new StringBuilder();
            IDataParameter[] spa =
                new IDataParameter[categoryIDs.Length + 1];
            int i = 0;
            foreach (var item in categoryIDs)
            {
                sb.AppendFormat(@"
INSERT TBlogPostCategory(PostID, CategoryID) 
VALUES (@PostID,@CategoryID{0});", i);
                spa[i] =
                    CreateParameter("@CategoryID" + i, item);
                i++;
            }
            spa[categoryIDs.Length] =
                CreateParameter("@PostID", postID);

            return ExecuteNonQuery(
                sb.ToString(),
                spa);

        }

        /// <summary>
        /// Removes the post to categories.
        /// </summary>
        /// <param name="postID">The post ID.</param>
        /// <param name="categoryIDs">The category I ds.</param>
        /// <returns></returns>
        public int RemovePostToCategories(
            int postID,
            params int[] categoryIDs)
        {

            return ExecuteNonQuery(
                string.Format(@"DELETE TBlogPostCategory 
WHERE PostID = @PostID AND CategoryID IN ({0})",
                string.Join(", ", categoryIDs.Select(x => x.ToString()).ToArray())),
                CreateParameter("@PostID", postID));

        }





        protected EBlogPost Change(IDataReader sdr)
        {
            return new EBlogPost()
            {
                PostID = sdr.GetInt32(sdr.GetOrdinal("PostID")),
                BlogID = sdr.GetInt32(sdr.GetOrdinal("BlogID")),
                Title = GetStringFromDataReader(sdr, "Title"),
                Content = GetStringFromDataReader(sdr, "Content"),
                Summary = GetStringFromDataReader(sdr, "Summary"),
                PublishDate = sdr.GetDateTime(sdr.GetOrdinal("PublishDate")),
                LastModifiedDate = sdr.GetDateTime(sdr.GetOrdinal("LastModifiedDate")),
                IsPublished = sdr.GetBoolean(sdr.GetOrdinal("IsPublished")),
                Visible = sdr.GetBoolean(sdr.GetOrdinal("Visible")),
                Author = sdr.GetGuid(sdr.GetOrdinal("AuthorID")),
                ReadCount = sdr.GetInt32(sdr.GetOrdinal("ReadCount"))
            };
        }
    }
}
