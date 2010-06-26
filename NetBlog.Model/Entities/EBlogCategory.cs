using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetBlog.Model.Common;

namespace NetBlog.Model.Entities
{
    /// <summary>
    /// Blog Category Entity
    /// </summary>
    public class EBlogCategory : EntityBase
    {
        #region Fields (4)

        private int _categoryID;
        private string _categoryName;
        private int _orderNo;
        private int? _parentCategoryID;

        #endregion Fields

        #region Properties (4)

        /// <summary>
        /// Gets or sets the category ID.
        /// </summary>
        /// <value>The category ID.</value>
        public int CategoryID
        {
            get { return _categoryID; }
            set
            {
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
            set
            {
                FirePropertyChanging("CategoryName");
                _categoryName = value;
                FirePropertyChanged("CategoryName");
            }
        }

        /// <summary>
        /// Gets or sets the order no.
        /// </summary>
        /// <value>The order no.</value>
        public int OrderNo
        {
            get { return _orderNo; }
            set
            {
                FirePropertyChanging("OrderNo");
                _orderNo = value;
                FirePropertyChanged("OrderNo");
            }
        }

        /// <summary>
        /// Gets or sets the parent category ID.
        /// </summary>
        /// <value>The parent category ID.</value>
        public int? ParentCategoryID
        {
            get { return _parentCategoryID; }
            set
            {
                FirePropertyChanging("ParentCategoryID");
                _parentCategoryID = value;
                FirePropertyChanged("ParentCategoryID");
            }
        }

        #endregion Properties
    }
}
