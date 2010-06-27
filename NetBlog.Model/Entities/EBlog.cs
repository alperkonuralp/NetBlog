using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetBlog.Model.Common;

namespace NetBlog.Model.Entities
{
    public class EBlog : EntityBase
    {
        #region Fields (2)

        private int _blogID;
        private string _blogName;

        #endregion Fields

        #region Properties (2)

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

        public string BlogName
        {
            get { return _blogName; }
            set
            {
                FirePropertyChanging("BlogName");
                _blogName = value;
                FirePropertyChanged("BlogName");
            }
        }

        #endregion Properties
    }
}
