using System;
using System.Collections.Generic;
using Data.Interfaces;
using Factory.Interfaces;

namespace Data
{
    public abstract class BaseDataAccess : IBasicDataAccess
    {
        private Context _context;
        internal Context Context 
        {
            get
            {
                if (_context == null) {_context = new Context(); return _context;}
                else return _context;
            }
        }

        public List<string> lstValidations {get; private set;}

        public BaseDataAccess ()
        {
            if (Context.EntUsers.Find("5801F6E0FF954D5A9593507075B930D9") == null)
                Config.DefaultSeeding.startSeeding(Context);
        }
        public BaseDataAccess (Context context):this(){_context = context;}

        public string NewID() => Guid.NewGuid().ToString().Replace("-","");

        //Base functions with intention to be overwrited but with basic security validations
        public virtual IEntity Save(IEntity entToSave){lstValidations = new List<string>(); return entToSave;}
        public virtual IEntity Update(IEntity entToUpdate){lstValidations = new List<string>(); return entToUpdate;}
        public virtual bool Delete(IEntity entToDelete){lstValidations = new List<string>(); return true;}
        
        /// <summary>
        /// Each entity type has it's own validation rules, so this method is abstract to ensure every dataaccess will have validation
        /// </summary>
        /// <param name="entToValidate"></param>
        /// <returns></returns>
        internal abstract IEntity ValidateData(IEntity entToValidate);
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