using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetBlog.Model.Common;

namespace NetBlog.Model.Entities
{
    public class EBlogCategory : EntityBase
    {
		#region Fields (4) 

        private int _categoryID;
        private string _categoryName;
        private int _orderNo;
        private int? _parentCategoryID;

		#endregion Fields 

		#region Properties (4) 

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

        public int OrderNo
        {
            get { return _orderNo; }
            set { _orderNo = value; }
        }

        public int? ParentCategoryID
        {
            get { return _parentCategoryID; }
            set { _parentCategoryID = value; }
        }

		#endregion Properties 
    }
}
