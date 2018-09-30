using System;
using System.Collections.Generic;
using Data;
using Data.Config;
using Factory.Interfaces;

namespace biz
{
    public abstract class BaseBiz:IDisposable
    {
        private Context _context;
        internal Context Context
        {get {if(_context == null) _context = new Data.Context(); return _context;}
         private set {_context = value;}}

        public BaseBiz (Context context){Context = context;}
        public BaseBiz (){}

        public abstract IEntity Save();
        public abstract IEntity Update();
        public abstract bool Delete();
        public abstract IEnumerable<IEntity> RetrieveAll();
        public abstract IEntity RetrieveByID(string _id);
        public abstract IEntity RetrieveBySome(IEntity _entity);

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
                disposedValue = true;
        }
        public void Dispose() => Dispose(true);
        #endregion

    }
}