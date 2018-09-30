using System;
using System.Collections.Generic;
using Data;
using Data.Common;
using Factory;
using Factory.Exceptions;
using Factory.Interfaces;
using Factory.Models;

namespace biz.Common
{
	public class FeatureBiz : BaseBiz
	{
		#region Properties
		
		private IEntity _entity;
		private IEntity Entity
		{
			get { if (_entity == null) _entity = new IEntity(); return _entity; }
			set { _entity = value; }
		}
		private FeatureDataAccess _datalayer;
		private FeatureDataAccess DataLayer
		{
			get { if (_datalayer == null) _datalayer = new FeatureDataAccess(); return _datalayer; }
			set { _datalayer = value; }
		}
		#endregion
		#region Constructors
		
		public FeatureBiz () 
		{}
		public FeatureBiz ( Context _context ) :base(_context)
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