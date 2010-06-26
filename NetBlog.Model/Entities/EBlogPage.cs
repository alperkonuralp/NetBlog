using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetBlog.Model.Common;

namespace NetBlog.Model.Entities
{
    /// <summary>
    /// Blog Page Entity
    /// </summary>
    public class EBlogPage : EntityBase
    {
		#region Fields (13) 

        private Guid _author;
        private int _blogID;
        private string _content;
        private bool _isPublished;
        private DateTime _lastModifiedDate;
        private int _orderNo;
        private int _pageID;
        private int? _parentPageID;
        private DateTime _publishDate;
        private int _readCount;
        private string _summary;
        private string _title;
        private bool _visible;

		#endregion Fields 

		#region Properties (13) 

        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        /// <value>The author.</value>
        public Guid Author
        {
            get { return _author; }
            set {
                FirePropertyChanging("Author");
                _author = value;
                FirePropertyChanged("Author");
            }
        }

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
        /// Gets or sets the content.
        /// </summary>
        /// <value>The content.</value>
        public string Content
        {
            get { return _content; }
            set {
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
            set {
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
            set {
                FirePropertyChanging("LastModifiedDate");
                _lastModifiedDate = value;
                FirePropertyChanged("LastModifiedDate");
            }
        }

        /// <summary>
        /// Gets or sets the order no.
        /// </summary>
        /// <value>The order no.</value>
        public int OrderNo
        {
            get { return _orderNo; }
            set {
                FirePropertyChanging("OrderNo");
                _orderNo = value;
                FirePropertyChanged("OrderNo");
            }
        }

        /// <summary>
        /// Gets or sets the page ID.
        /// </summary>
        /// <value>The page ID.</value>
        public int PageID
        {
            get { return _pageID; }
            set {
                FirePropertyChanging("PageID");
                _pageID = value;
                FirePropertyChanged("PageID");
            }
        }

        /// <summary>
        /// Gets or sets the parent page ID.
        /// </summary>
        /// <value>The parent page ID.</value>
        public int? ParentPageID
        {
            get { return _parentPageID; }
            set {
                FirePropertyChanging("ParentPageID");
                _parentPageID = value;
                FirePropertyChanged("ParentPageID");
            }
        }

        /// <summary>
        /// Gets or sets the publish date.
        /// </summary>
        /// <value>The publish date.</value>
        public DateTime PublishDate
        {
            get { return _publishDate; }
            set {
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
            set {
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
            set {
                FirePropertyChanging("Summary");
                _summary = value;
                FirePropertyChanged("Summary");
            }
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title
        {
            get { return _title; }
            set {
                FirePropertyChanging("Title");
                _title = value;
                FirePropertyChanged("Title");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="EBlogPost"/> is visible.
        /// </summary>
        /// <value><c>true</c> if visible; otherwise, <c>false</c>.</value>
        public bool Visible
        {
            get { return _visible; }
            set {
                FirePropertyChanging("Visible");
                _visible = value;
                FirePropertyChanged("Visible");
            }
        }

		#endregion Properties 
    }
}
