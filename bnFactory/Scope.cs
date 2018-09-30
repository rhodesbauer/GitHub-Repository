using System;
using Newtonsoft.Json;
using Factory.Models;
using Factory.Exceptions;

namespace Factory
{
    /// <summary>
    /// This class controls the scope of the user accessing the protected system
    /// If the system are expected to be used concurrently, probably will be here that 
    ///  most of the changes will have to be made to allow different scopes;
    /// </summary>
    public class Scope : IDisposable
    {
        private ObjScopeData _objScopeData;
        internal ObjScopeData ObjScopeData
        {
            get
            {
                if (_objScopeData == null) throw new LoggedUserNotLoadedException();
                else return _objScopeData;
            }
        }

        public string loggedUserID {get; private set;}
        public TimeSpan timeToLive {get; private set;}
        public DateTime dtLogin {get; private set;}


        //public Scope (){}
        public Scope (string jsonData)
        {
            _objScopeData = (ObjScopeData)JsonConvert.DeserializeObject(jsonData, _objScopeData.GetType());
            this.loggedUserID = ObjScopeData.loggedUserID;
            this.timeToLive = ObjScopeData.timeToLive;
            this.dtLogin = ObjScopeData.dtLogin;
        }

        #region IDisposable Support
        private bool disposedValue = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
                disposedValue = true;
        }
        public void Dispose() => Dispose(true);
        #endregion
    }
}