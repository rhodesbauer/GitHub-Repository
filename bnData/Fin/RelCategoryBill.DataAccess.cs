using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Factory.Interfaces;
using Factory.Models;
using Factory.Exceptions;
using System;

namespace Data.Relation
{
	public class RelCategoryBillDataAccess : BaseDataAccess
	{
		#region Properties
		
		private RelCategoryBill _entlocal;
		private RelCategoryBill entLocal
		{
			get { if (_entlocal == null) _entlocal = new RelCategoryBill(); return _entlocal; }
			set { _entlocal = value; }
		}
		#endregion
		
		#region Constructors
		
		public RelCategoryBillDataAccess () 
		{}
		public RelCategoryBillDataAccess ( Context _context ) :base(_context)
		{}
		#endregion
		
		#region Generated Methods
		
		internal override IEntity ValidateData ( IEntity entToValidate )  => throw new System.NotImplementedException();
		

		public override IEntity Save ( IEntity entToSave ) 
		{
			entLocal = (RelCategoryBill)ValidateData(base.Save(entToSave));
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
			entLocal = (RelCategoryBill)ValidateData(base.Update(entToUpdate));
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
				Context.RelCategoryBill.Update(entLocal);
				Context.SaveChanges();
			}
			return entLocal;
		}

		public override bool Delete ( IEntity entToDelete ) 
		{
			entLocal = (RelCategoryBill)entToDelete;
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
			 	isDeletable = Context.RelCategoryBill.Remove(entLocal).State == EntityState.Deleted;
			}
			return isDeletable;
		}

		public  IEnumerable<IEntity> GetAll ()  => Context.#CLASSOBJECT#.ToList();
		

		public  IEntity Get ( string _id )  => Context.#CLASSOBJECT#.Find(_id);
		

		public  IEntity Get ( IEntity entToSearch ) 
		{
			if (entToSearch.GetType().Equals(entLocal.GetType())){
				if (!string.IsNullOrEmpty(((RelCategoryBill)entToSearch).ConId))
					return Get(((RelCategoryBill)entToSearch).ConId);
				else {
					entLocal = (RelCategoryBill)entToSearch;
					if (entLocal.ConCode > 0)
						return Context.RelCategoryBill.Where(x=> x.ConCode.Equals(entLocal.ConCode)).FirstOrDefault();
					if (!string.IsNullOrEmpty(entLocal.ConFirstName) && !string.IsNullOrEmpty(entLocal.ConLastname))
						return Context.RelCategoryBill.Where(x=> x.ConLastname.Equals(entLocal.ConLastname) && x.ConFirstName.Equals(entLocal.ConFirstName)).FirstOrDefault();
				}
			}
			return null;
		}

		#endregion
	}
}