using System;
using System.Collections.Generic;
using Data;
using Data.Common;
using Factory;
using Factory.Exceptions;
using Factory.Interfaces;
using Factory.Models;

namespace biz.Relation
{
	public class RelBillGroupingBiz : BaseBiz
	{
		#region Properties
		
		private IEntity _entity;
		private IEntity Entity
		{
			get { if (_entity == null) _entity = new IEntity(); return _entity; }
			set { _entity = value; }
		}
		private RelBillGroupingDataAccess _datalayer;
		private RelBillGroupingDataAccess DataLayer
		{
			get { if (_datalayer == null) _datalayer = new RelBillGroupingDataAccess(); return _datalayer; }
			set { _datalayer = value; }
		}
		#endregion
		#region Constructors
		
		public RelBillGroupingBiz () 
		{}
		public RelBillGroupingBiz ( Context _context ) :base(_context)
		{}
		#endregion
		#region Generated Methods
		
		public override IEntity Save () => DataLayer.Save(Entity);
		

		public override IEntity Update () => DataLayer.Update(Entity);
		

		public override bool Delete () => DataLayer.Delete(Entity);
		

		public override IEnumerable<IEntity> RetrieveAll ()  => DataLayer.GetAll();
		

		public override IEntity RetrieveByID ( string _id )  => DataLayer.Get(_id);
		

		public override IEntity RetrieveBySome ( IEntity _entity )  => DataLayer.Get(_entity);
		

		#endregion
	}
}