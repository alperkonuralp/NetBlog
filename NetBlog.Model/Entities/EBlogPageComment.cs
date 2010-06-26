using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetBlog.Model.Common;

namespace NetBlog.Model.Entities
{
    public class EBlogPageComment : EntityBase
    {
        #region Fields (8)

        private bool _approved;
        private DateTime _commentDate;
        private int _commentID;
        private string _content;
        private int _pageID;
        private string _title;
        private Guid? _userID;
        private string _writerName;

        #endregion Fields

        #region Properties (8)

        public bool Approved
        {
            get { return _approved; }
            set { _approved = value; }
        }

        public DateTime CommentDate
        {
            get { return _commentDate; }
            set { _commentDate = value; }
        }

        public int CommentID
        {
            get { return _commentID; }
            set { _commentID = value; }
        }

        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }

        public int PageID
        {
            get { return _pageID; }
            set { _pageID = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public Guid? UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        public string WriterName
        {
            get { return _writerName; }
            set { _writerName = value; }
        }

        #endregion Properties 
    }
}
