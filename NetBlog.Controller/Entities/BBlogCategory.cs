using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetBlog.Controller.Common;

namespace NetBlog.Controller.Entities
{
    public class BBlogCategory : EntityBase
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

        public int CategoryID
        {
            get { return _categoryID; }
            set { _categoryID = value; }
        }

        public string CategoryName
        {
            get { return _categoryName; }
            set { _categoryName = value; }
        }

        public List<BBlogCategory> Children
        {
            get { return _children; }

        }

        public int OrderNo
        {
            get { return _orderNo; }
            set { _orderNo = value; }
        }

        public BBlogCategory Parent
        {
            get { return _parent; }

        }

        public int? ParentCategoryID
        {
            get { return _parentCategoryID; }
            set { _parentCategoryID = value; }
        }

        public List<BBlogPost> Posts
        {
            get { return _posts; }

        }

        #endregion Properties
    }
}
