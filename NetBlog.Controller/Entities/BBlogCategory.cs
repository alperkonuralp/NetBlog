using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetBlog.Controller.Common;

namespace NetBlog.Controller.Entities
{
    /// <summary>
    /// Blog Category Business Entity
    /// </summary>
    public class BBlogCategory : BusinessEntityBase
    {
        #region Fields (7)

        private int _categoryID;
        private string _categoryName;
        private List<BBlogCategory> _children;
        private int _orderNo;
        private BBlogCategory _parent;
        private int? _parentCategoryID;
        private List<BBlogPost> _posts;

        #endregion Fields

        #region Properties (7)

        /// <summary>
        /// Gets or sets the category ID.
        /// </summary>
        /// <value>The category ID.</value>
        public int CategoryID
        {
            get { return _categoryID; }
            set {
                FirePropertyChanging("CategoryID");
                _categoryID = value;
                FirePropertyChanged("CategoryID");
            }
        }

        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        /// <value>The name of the category.</value>
        public string CategoryName
        {
            get { return _categoryName; }
            set {
                FirePropertyChanging("CategoryName");
                _categoryName = value;
                FirePropertyChanged("CategoryName");
            }
        }

        /// <summary>
        /// Gets the children.
        /// </summary>
        /// <value>The children.</value>
        public List<BBlogCategory> Children
        {
            get { return _children; }

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
        /// Gets the parent.
        /// </summary>
        /// <value>The parent.</value>
        public BBlogCategory Parent
        {
            get { return _parent; }

        }

        /// <summary>
        /// Gets or sets the parent category ID.
        /// </summary>
        /// <value>The parent category ID.</value>
        public int? ParentCategoryID
        {
            get { return _parentCategoryID; }
            set {
                FirePropertyChanging("ParentCategoryID");
                _parentCategoryID = value;
                FirePropertyChanged("ParentCategoryID");
            }
        }

        /// <summary>
        /// Gets the posts.
        /// </summary>
        /// <value>The posts.</value>
        public List<BBlogPost> Posts
        {
            get { return _posts; }

        }

        #endregion Properties
    }
}
