using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetBlog.Model.Common;

namespace NetBlog.Model.Entities
{
    public class EBlogTag : EntityBase
    {
		#region Fields (2) 

        private int _postID;
        private string _tag;

		#endregion Fields 

		#region Properties (2) 

        public int PostID
        {
            get { return _postID; }
            set { _postID = value; }
        }

        public string Tag
        {
            get { return _tag; }
            set { _tag = value; }
        }

		#endregion Properties 
    }
}
