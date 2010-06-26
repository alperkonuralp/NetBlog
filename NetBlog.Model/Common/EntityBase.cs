using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace NetBlog.Model.Common
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class EntityBase : IDisposable, INotifyPropertyChanging, INotifyPropertyChanged
    {
		#region Methods (2) 

		// Protected Methods (2) 

        /// <summary>
        /// Fire Property Changed
        /// </summary>
        /// <param name="pn"></param>
        protected void FirePropertyChanged(string pn)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(pn));
            }
        }

        /// <summary>
        /// Fire Property Changing
        /// </summary>
        /// <param name="pn"></param>
        protected void FirePropertyChanging(string pn)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(pn));
            }
        }

		#endregion Methods 



        #region IDisposable Members
        private bool _isDisposed = false;

        /// <summary>
        /// Gets a value indicating whether this instance is disposed.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is disposed; otherwise, <c>false</c>.
        /// </value>
        public bool IsDisposed
        {
            get { return _isDisposed; }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public virtual void Dispose()
        {
            if (!_isDisposed)
            {
                _isDisposed = true;
            }
        }

        #endregion

        #region INotifyPropertyChanged Members

        /// <summary>
        /// Property Changed Event
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region INotifyPropertyChanging Members

        /// <summary>
        /// Property Changing Event
        /// </summary>
        public event PropertyChangingEventHandler PropertyChanging;

        #endregion
    }
}
