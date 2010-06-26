using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetBlog.Controller.Common;

namespace NetBlog.Controller.Entities
{
    /// <summary>
    /// Blog Post Business Entity
    /// </summary>
    public class BBlogPost : BusinessEntityBase
    {
        #region Fields (15)

        private Guid _author;
        private BBlog _blog;
        private int _blogID;
        private List<BBlogCategory> _categories;
        private List<BBlogComment> _comments;
        private string _content;
        private bool _isPublished;
        private DateTime _lastModifiedDate;
        private int _postID;
        private DateTime _publishDate;
        private int _readCount;
        private string _summary;
        private List<BBlogTag> _tags;
        private string _title;
        private bool _visible;

        #endregion Fields

        #region Properties (15)

        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        /// <value>The author.</value>
        public Guid Author
        {
            get { return _author; }
            set
            {
                FirePropertyChanging("Author");
                _author = value;
                FirePropertyChanged("Author");
            }
        }

        /// <summary>
        /// Gets the blog.
        /// </summary>
        /// <value>The blog.</value>
        public BBlog Blog
        {
            get { return _blog; }
            internal set {
                FirePropertyChanging("Blog");
                _blog = value;
                FirePropertyChanged("Blog");
            }
        }

        /// <summary>
        /// Gets or sets the blog ID.
        /// </summary>
        /// <value>The blog ID.</value>
        public int BlogID
        {
            get { return _blogID; }
            set
            {
                FirePropertyChanging("BlogID");
                _blogID = value;
                FirePropertyChanged("BlogID");
            }
        }

        /// <summary>
        /// Gets the categories.
        /// </summary>
        /// <value>The categories.</value>
        public List<BBlogCategory> Categories
        {
            get { return _categories; }

        }

        /// <summary>
        /// Gets the comments.
        /// </summary>
        /// <value>The comments.</value>
        public List<BBlogComment> Comments
        {
            get { return _comments; }

        }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>The content.</value>
        public string Content
        {
            get { return _content; }
            set
            {
                FirePropertyChanging("Content");
                _content = value;
                FirePropertyChanged("Content");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is published.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is published; otherwise, <c>false</c>.
        /// </value>
        public bool IsPublished
        {
            get { return _isPublished; }
            set
            {
                FirePropertyChanging("IsPublished");
                _isPublished = value;
                FirePropertyChanged("IsPublished");
            }
        }

        /// <summary>
        /// Gets or sets the last modified date.
        /// </summary>
        /// <value>The last modified date.</value>
        public DateTime LastModifiedDate
        {
            get { return _lastModifiedDate; }
            set
            {
                FirePropertyChanging("LastModifiedDate");
                _lastModifiedDate = value;
                FirePropertyChanged("LastModifiedDate");
            }
        }

        /// <summary>
        /// Gets or sets the post ID.
        /// </summary>
        /// <value>The post ID.</value>
        public int PostID
        {
            get { return _postID; }
            set
            {
                FirePropertyChanging("PostID");
                _postID = value;
                FirePropertyChanged("PostID");
            }
        }

        /// <summary>
        /// Gets or sets the publish date.
        /// </summary>
        /// <value>The publish date.</value>
        public DateTime PublishDate
        {
            get { return _publishDate; }
            set
            {
                FirePropertyChanging("PublishDate");
                _publishDate = value;
                FirePropertyChanged("PublishDate");
            }
        }

        /// <summary>
        /// Gets or sets the read count.
        /// </summary>
        /// <value>The read count.</value>
        public int ReadCount
        {
            get { return _readCount; }
            set
            {
                FirePropertyChanging("ReadCount");
                _readCount = value;
                FirePropertyChanged("ReadCount");
            }
        }

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        /// <value>The summary.</value>
        public string Summary
        {
            get { return _summary; }
            set
            {
                FirePropertyChanging("Summary");
                _summary = value;
                FirePropertyChanged("Summary");
            }
        }

        /// <summary>
        /// Gets the tags.
        /// </summary>
        /// <value>The tags.</value>
        public List<BBlogTag> Tags
        {
            get { return _tags; }

        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title
        {
            get { return _title; }
            set
            {
                FirePropertyChanging("Title");
                _title = value;
                FirePropertyChanged("Title");
            }
        }


        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="BBlogPost"/> is visible.
        /// </summary>
        /// <value><c>true</c> if visible; otherwise, <c>false</c>.</value>
        public bool Visible
        {
            get { return _visible; }
            set
            {
                FirePropertyChanging("Visible");
                _visible = value;
                FirePropertyChanged("Visible");
            }
        }

        #endregion Properties
    }
}
