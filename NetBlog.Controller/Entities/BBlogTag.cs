using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetBlog.Controller.Common;

namespace NetBlog.Controller.Entities
{
    /// <summary>
    /// Blog Tag Business Entity
    /// </summary>
    public class BBlogTag : BusinessEntityBase
    {
        #region Fields (2)

        private int _postID;
        private string _tag;

        #endregion Fields

        #region Properties (2)

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
        /// Gets or sets the tag.
        /// </summary>
        /// <value>The tag.</value>
        public string Tag
        {
            get { return _tag; }
            set
            {
                FirePropertyChanging("Tag");
                _tag = value;
                FirePropertyChanged("Tag");
            }
        }

        #endregion Properties
    }
}
