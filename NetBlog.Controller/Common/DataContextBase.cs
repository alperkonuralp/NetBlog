using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetBlog.Controller.Common
{
    public abstract class DataContextBase : IDisposable
    {
        #region IDisposable Members
        private bool _isDisposed = false;

        public bool IsDisposed
        {
            get { return _isDisposed; }
        }

        public virtual void Dispose()
        {
            if (!_isDisposed)
            {
                _isDisposed = true;
            }
        }

        #endregion
    }
}
