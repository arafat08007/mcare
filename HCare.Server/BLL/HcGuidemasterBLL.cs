using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCare.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using HCare.Server.DAL;

namespace HCare.Server.BLL
{
	public partial class HcGuidemasterBLL
	{
		#region Auto Generated 

		public object SaveHcGuidemasterInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcGuidemasterEntity hcGuidemasterEntity = (HcGuidemasterEntity)param;
					HcGuidemasterDAL hcGuidemasterDAL = new HcGuidemasterDAL();
					retObj = (object)hcGuidemasterDAL.SaveHcGuidemasterInfo(hcGuidemasterEntity, db, transaction);
					transaction.Commit();
				}
				catch
				{
					transaction.Rollback();
					throw;
				}
				finally
				{
					connection.Close();
				}
			}
			return retObj;
		}

		public object UpdateHcGuidemasterInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcGuidemasterEntity hcGuidemasterEntity = (HcGuidemasterEntity)param;
					HcGuidemasterDAL hcGuidemasterDAL = new HcGuidemasterDAL();
					retObj = (object)hcGuidemasterDAL.UpdateHcGuidemasterInfo(hcGuidemasterEntity, db, transaction);
					transaction.Commit();
				}
				catch
				{
					transaction.Rollback();
					throw;
				}
				finally
				{
					connection.Close();
				}
			}
			return retObj;
		}

		public object DeleteHcGuidemasterInfoById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcGuidemasterDAL hcGuidemasterDAL = new HcGuidemasterDAL();
					retObj = (object)hcGuidemasterDAL.DeleteHcGuidemasterInfoById(param , db, transaction);
					transaction.Commit();
				}
				catch
				{
					transaction.Rollback();
					throw;
				}
				finally
				{
					connection.Close();
				}
			}
			return retObj;
		}

		public object GetSingleHcGuidemasterRecordById(object param)
		{
			object retObj = null;
			HcGuidemasterDAL hcGuidemasterDAL = new HcGuidemasterDAL();
			retObj = (object)hcGuidemasterDAL.GetSingleHcGuidemasterRecordById(param);
			return retObj;
		}

		#endregion

	}
}

