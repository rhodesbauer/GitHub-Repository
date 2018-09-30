using System;
using Factory.Exceptions;

namespace Factory.Models
{
    public class ObjScopeData : IDisposable
    {
        private string _loggedUserID;
        public string loggedUserID 
        {
            get 
            { 
                if (string.IsNullOrEmpty(_loggedUserID)) throw new LoggedUserNotLoadedException(this.GetType().ToString());
                else return _loggedUserID;
            }
            set {_loggedUserID = value;}
        }

        private TimeSpan _timeToLive;
        public TimeSpan timeToLive
        {
            get 
            {
                if (_timeToLive == null || _timeToLive == TimeSpan.MinValue) throw new LoggedUserNotLoadedException(this.GetType().ToString());
                else return _timeToLive;
            }
            set {_timeToLive = value;}
        }

        private DateTime _dtLogin;
        public DateTime dtLogin
        {
            get
            {
                if (_dtLogin == null || _dtLogin == DateTime.MinValue) throw new LoggedUserNotLoadedException(this.GetType().ToString());
                else return _dtLogin;
            }
            set {_dtLogin = value;}
        }

        #region IDisposable Support
        private bool disposedValue = false; 

            protected virtual void Dispose(bool disposing)
            {
                if (!disposedValue)
                    disposedValue = true;
            }

            public void Dispose() {Dispose(true);}
        #endregion
    }
}