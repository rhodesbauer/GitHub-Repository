using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Factory.Interfaces;
using Factory.Models;
using Factory.Exceptions;
using System;

namespace Data.Fin
{
	public class BillGroupDataAccess : BaseDataAccess
	{
		#region Properties
		
		private EntBillGroup _entlocal;
		private EntBillGroup entLocal
		{
			get { if (_entlocal == null) _entlocal = new EntBillGroup(); return _entlocal; }
			set { _entlocal = value; }
		}
		#endregion
		
		#region Constructors
		
		public BillGroupDataAccess () 
		{}
		public BillGroupDataAccess ( Context _context ) :base(_context)
		{}
		#endregion
		
		#region Generated Methods
		
		internal override IEntity ValidateData ( IEntity entToValidate )  => throw new System.NotImplementedException();
		

		public override IEntity Save ( IEntity entToSave ) 
		{
			entLocal = (BillGroup)ValidateData(base.Save(entToSave));
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
			entLocal = (BillGroup)ValidateData(base.Update(entToUpdate));
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
				Context.BillGroup.Update(entLocal);
				Context.SaveChanges();
			}
			return entLocal;
		}

		public override bool Delete ( IEntity entToDelete ) 
		{
			entLocal = (BillGroup)entToDelete;
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
			 	isDeletable = Context.BillGroup.Remove(entLocal).State == EntityState.Deleted;
			}
			return isDeletable;
		}

		public  IEnumerable<IEntity> GetAll ()  => Context.#CLASSOBJECT#.ToList();
		

		public  IEntity Get ( string _id )  => Context.#CLASSOBJECT#.Find(_id);
		

		public  IEntity Get ( IEntity entToSearch ) 
		{
			if (entToSearch.GetType().Equals(entLocal.GetType())){
				if (!string.IsNullOrEmpty(((BillGroup)entToSearch).ConId))
					return Get(((BillGroup)entToSearch).ConId);
				else {
					entLocal = (BillGroup)entToSearch;
					if (entLocal.ConCode > 0)
						return Context.BillGroup.Where(x=> x.ConCode.Equals(entLocal.ConCode)).FirstOrDefault();
					if (!string.IsNullOrEmpty(entLocal.ConFirstName) && !string.IsNullOrEmpty(entLocal.ConLastname))
						return Context.BillGroup.Where(x=> x.ConLastname.Equals(entLocal.ConLastname) && x.ConFirstName.Equals(entLocal.ConFirstName)).FirstOrDefault();
				}
			}
			return null;
		}

		#endregion
	}
}