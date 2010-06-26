using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetBlog.Controller.Common;
using NetBlog.Model.DataManagers;

namespace NetBlog.Controller.Entities
{
    /// <summary>
    /// Blog Business Entity
    /// </summary>
    public class BBlog : BusinessEntityBase
    {
        #region Fields (4)

        private int _blogID;
        private string _blogName;
        private List<BBlogPage> _pages;
        private List<BBlogPost> _posts;

        #endregion Fields

        #region Properties (4)

        /// <summary>
        /// Gets or sets the blog ID.
        /// </summary>
        /// <value>The blog ID.</value>
        public int BlogID
        {
            get { return _blogID; }
            set {
                FirePropertyChanging("BlogID");
                _blogID = value;
                FirePropertyChanged("BlogID");
            }
        }

        /// <summary>
        /// Gets or sets the name of the blog.
        /// </summary>
        /// <value>The name of the blog.</value>
        public string BlogName
        {
            get { return _blogName; }
            set {
                FirePropertyChanging("BlogName");
                _blogName = value;
                FirePropertyChanged("BlogName");
            }
        }

        /// <summary>
        /// Gets the pages.
        /// </summary>
        /// <value>The pages.</value>
        public List<BBlogPage> Pages
        {
            get { return _pages; }
        }

        /// <summary>
        /// Gets the posts.
        /// </summary>
        /// <value>The posts.</value>
        public List<BBlogPost> Posts
        {
            get
            {
                if (_posts == null)
                {
                    _posts = new List<BBlogPost>();

                    using (var data = new BlogPostDataManager())
                    {
                        var posts = data.GetBlogPostsByBlogID(_blogID);
                        _posts.AddRange(
                            posts.Select(x =>
                            new BBlogPost() { 
                                PostID = x.PostID,
                                BlogID = x.BlogID,
                                Blog = this,
                                Title = x.Title,
                                Content = x.Content,
                                Summary = x.Summary,
                                PublishDate = x.PublishDate,
                                LastModifiedDate = x.LastModifiedDate,
                                Author = x.Author,
                                IsPublished = x.IsPublished,
                                Visible = x.Visible,
                                ReadCount = x.ReadCount
                            }));
                    }

                }
                return _posts;
            }
        }

        #endregion Properties
    }


}
