using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetBlog.Controller.Common;
using NetBlog.Model.DataManagers;

namespace NetBlog.Controller.Entities
{
    public class BBlog : EntityBase
    {
        #region Fields (4)

        private int _blogID;
        private string _blogName;
        private List<BBlogPage> _pages;
        private List<BBlogPost> _posts;

        #endregion Fields

        #region Properties (4)

        public int BlogID
        {
            get { return _blogID; }
            set { _blogID = value; }
        }

        public string BlogName
        {
            get { return _blogName; }
            set { _blogName = value; }
        }

        public List<BBlogPage> Pages
        {
            get { return _pages; }
        }

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
