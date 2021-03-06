﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetBlog.Controller.Common;
using NetBlog.Controller.DataContexts;

namespace NetBlog.Controller.Entities
{
    /// <summary>
    /// Blog Comment Business Entity
    /// </summary>
    public class BBlogComment : BusinessEntityBase
    {
        #region Fields (8)

        private bool _approved;
        private DateTime _commentDate;
        private int _commentID;
        private string _content;
        private int _postID;
        private string _title;
        private Guid? _userID;
        private string _writerName;


        private BBlogPost _post;

        public BBlogPost Post
        {
            get
            {
                if (_post == null)
                {
                    _post = new BlogPostDataContext().GetPostByPostID(PostID);
                }
                return _post;
            }
            internal set { _post = value; }
        }
        #endregion Fields

        #region Properties (8)

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="BBlogComment"/> is approved.
        /// </summary>
        /// <value><c>true</c> if approved; otherwise, <c>false</c>.</value>
        public bool Approved
        {
            get { return _approved; }
            set
            {
                FirePropertyChanging("Approved");
                _approved = value;
                FirePropertyChanged("Approved");
            }
        }

        /// <summary>
        /// Gets or sets the comment date.
        /// </summary>
        /// <value>The comment date.</value>
        public DateTime CommentDate
        {
            get { return _commentDate; }
            set
            {
                FirePropertyChanging("CommentDate");
                _commentDate = value;
                FirePropertyChanged("CommentDate");
            }
        }

        /// <summary>
        /// Gets or sets the comment ID.
        /// </summary>
        /// <value>The comment ID.</value>
        public int CommentID
        {
            get { return _commentID; }
            set
            {
                FirePropertyChanging("CommentID");
                _commentID = value;
                FirePropertyChanged("CommentID");
            }
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
        /// Gets or sets the user ID.
        /// </summary>
        /// <value>The user ID.</value>
        public Guid? UserID
        {
            get { return _userID; }
            set
            {
                FirePropertyChanging("UserID");
                _userID = value;
                FirePropertyChanged("UserID");
            }
        }

        /// <summary>
        /// Gets or sets the name of the writer.
        /// </summary>
        /// <value>The name of the writer.</value>
        public string WriterName
        {
            get { return _writerName; }
            set
            {
                FirePropertyChanging("WriterName");
                _writerName = value;
                FirePropertyChanged("WriterName");
            }
        }

        #endregion Properties
    }
}
