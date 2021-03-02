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
	public partial class HcLabTestBLL
	{
		#region Auto Generated 

		public object SaveHcLabTestInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcLabTestEntity hcLabTestEntity = (HcLabTestEntity)param;
					HcLabTestDAL hcLabTestDAL = new HcLabTestDAL();
					retObj = (object)hcLabTestDAL.SaveHcLabTestInfo(hcLabTestEntity, db, transaction);
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

		public object UpdateHcLabTestInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcLabTestEntity hcLabTestEntity = (HcLabTestEntity)param;
					HcLabTestDAL hcLabTestDAL = new HcLabTestDAL();
					retObj = (object)hcLabTestDAL.UpdateHcLabTestInfo(hcLabTestEntity, db, transaction);
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

		public object DeleteHcLabTestInfoById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcLabTestDAL hcLabTestDAL = new HcLabTestDAL();
					retObj = (object)hcLabTestDAL.DeleteHcLabTestInfoById(param , db, transaction);
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

		public object GetSingleHcLabTestRecordById(object param)
		{
			object retObj = null;
			HcLabTestDAL hcLabTestDAL = new HcLabTestDAL();
			retObj = (object)hcLabTestDAL.GetSingleHcLabTestRecordById(param);
			return retObj;
		}

		#endregion

	}
}

