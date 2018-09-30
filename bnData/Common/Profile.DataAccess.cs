using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Factory.Interfaces;
using Factory.Models;
using Factory.Exceptions;
using System;

namespace Data.Common
{
	public class ProfileDataAccess : BaseDataAccess
	{
		#region Properties
		
		private EntProfiles _entlocal;
		private EntProfiles entLocal
		{
			get { if (_entlocal == null) _entlocal = new EntProfiles(); return _entlocal; }
			set { _entlocal = value; }
		}
		#endregion
		
		#region Constructors
		
		public ProfileDataAccess () 
		{}
		public ProfileDataAccess ( Context _context ) :base(_context)
		{}
		#endregion
		
		#region Generated Methods
		
		internal override IEntity ValidateData ( IEntity entToValidate )  => throw new System.NotImplementedException();
		

		public override IEntity Save ( IEntity entToSave ) 
		{
			entLocal = (Profile)ValidateData(base.Save(entToSave));
			if (lstValidations.Count > 0)
			{
				string strValidations = "";
				foreach(var item in lstValidations)
					strValidations += item + Environment.NewLine;
				throw new InvalidDataException(strValidations);
			}
			else
			{
					entLocal.ConId = NewID();
					entLocal.userIDCreation = Context.loggedUser.UserId;
					entLocal.userIDLastChange = Context.loggedUser.UserId;
					entLocal.dtCreation = DateTime.Now;
					entLocal.dtLastChange = DateTime.Now;
					Context.Add(entLocal);
					Context.SaveChanges(); 
			}
			return entLocal; 
		}

		public override IEntity Update ( IEntity entToUpdate ) 
		{
			entLocal = (Profile)ValidateData(base.Update(entToUpdate));
			if (lstValidations.Count > 0)
			{
				string strValidations = "";
				foreach(var item in lstValidations)
					strValidations += item + Environment.NewLine;
				throw new InvalidDataException(strValidations);
			 }
			 else
			 {
				entLocal.userIDLastChange = Context.loggedUser.UserId;
				entLocal.dtLastChange = DateTime.Now;
				Context.Profile.Update(entLocal);
				Context.SaveChanges();
			}
			return entLocal;
		}

		public override bool Delete ( IEntity entToDelete ) 
		{
			entLocal = (Profile)entToDelete;
			var isDeletable = base.Delete(entToDelete);
			if ((!isDeletable || lstValidations.Count > 0))
			{
				string strValidations = "";
				foreach(var item in lstValidations)
					strValidations += item + Environment.NewLine;
				throw new InvalidDataException(strValidations);
			}
			else
			{
			 	isDeletable = Context.Profile.Remove(entLocal).State == EntityState.Deleted;
			}
			return isDeletable;
		}

		public  IEnumerable<IEntity> GetAll ()  => Context.#CLASSOBJECT#.ToList();
		

		public  IEntity Get ( string _id )  => Context.#CLASSOBJECT#.Find(_id);
		

		public  IEntity Get ( IEntity entToSearch ) 
		{
			if (entToSearch.GetType().Equals(entLocal.GetType())){
				if (!string.IsNullOrEmpty(((Profile)entToSearch).ConId))
					return Get(((Profile)entToSearch).ConId);
				else {
					entLocal = (Profile)entToSearch;
					if (entLocal.ConCode > 0)
						return Context.Profile.Where(x=> x.ConCode.Equals(entLocal.ConCode)).FirstOrDefault();
					if (!string.IsNullOrEmpty(entLocal.ConFirstName) && !string.IsNullOrEmpty(entLocal.ConLastname))
						return Context.Profile.Where(x=> x.ConLastname.Equals(entLocal.ConLastname) && x.ConFirstName.Equals(entLocal.ConFirstName)).FirstOrDefault();
				}
			}
			return null;
		}

		#endregion
	}
}