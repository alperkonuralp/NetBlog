using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetBlog.Controller.Common;
using NetBlog.Controller.Entities;
using NetBlog.Controller.DataContexts;

namespace NetBlog.Controller
{
    /// <summary>
    /// Net Blog Data Context
    /// </summary>
    public class NetBlogDataContext : IDisposable
    {
        #region Fields (7)

        private List<BBlog> _blogs;
        private List<BBlogCategory> _categories;
        private List<BBlogComment> _comments;
        private List<BBlogPageComment> _pageComments;
        private List<BBlogPage> _pages;
        private List<BBlogPost> _posts;
        private List<BBlogTag> _tags;

        #endregion Fields

        #region Properties (7)

        /// <summary>
        /// Gets the blogs.
        /// </summary>
        /// <value>The blogs.</value>
        public List<BBlog> Blogs
        {
            get
            {
                if (_blogs == null)
                {
                    _blogs = new BlogDataContext().GetAllBlogs();
                }
                return _blogs;
            }
        }

        /// <summary>
        /// Gets the categories.
        /// </summary>
        /// <value>The categories.</value>
        public List<BBlogCategory> Categories
        {
            get
            {
                if (_categories == null)
                {
                    _categories = new BlogCategoryDataContext().GetAllCategories();
                }

                return _categories;
            }
        }

        /// <summary>
        /// Gets the comments.
        /// </summary>
        /// <value>The comments.</value>
        public List<BBlogComment> Comments
        {
            get
            {
                if (_comments == null)
                {
                    _comments = new BlogCommentDataContext().GetAllComments();
                }
                return _comments;
            }
        }

        /// <summary>
        /// Gets the page comments.
        /// </summary>
        /// <value>The page comments.</value>
        public List<BBlogPageComment> PageComments
        {
            get
            {
                if (_pageComments == null)
                {
                    _pageComments = new BlogPageCommentDataContext().GetAllComments();
                }
                return _pageComments;
            }
        }

        /// <summary>
        /// Gets the pages.
        /// </summary>
        /// <value>The pages.</value>
        public List<BBlogPage> Pages
        {
            get
            {
                if (_pages == null)
                {
                    _pages = new BlogPageDataContext().GetAllPages();
                }
                return _pages;
            }
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
                    _posts = new BlogPostDataContext().GetAllPosts();
                }
                return _posts;
            }
        }

        /// <summary>
        /// Gets the tags.
        /// </summary>
        /// <value>The tags.</value>
        public List<BBlogTag> Tags
        {
            get
            {
                if (_tags == null)
                {
                    _tags = new BlogTagDataContext().GetAllTags();
                }
                return _tags;
            }
        }

        #endregion Properties

        #region IDisposable Members
        private bool _isDisposed = false;

        /// <summary>
        /// Gets a value indicating whether this instance is disposed.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is disposed; otherwise, <c>false</c>.
        /// </value>
        public bool IsDisposed
        {
            get { return _isDisposed; }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public virtual void Dispose()
        {
            if (!_isDisposed)
            {
                _isDisposed = true;
            }
        }

        #endregion

    }
}
