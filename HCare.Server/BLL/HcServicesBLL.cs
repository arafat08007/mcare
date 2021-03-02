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
	public partial class HcServicesBLL
	{
		#region Auto Generated 

		public object SaveHcServicesInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcServicesEntity hcServicesEntity = (HcServicesEntity)param;
					HcServicesDAL hcServicesDAL = new HcServicesDAL();
					retObj = (object)hcServicesDAL.SaveHcServicesInfo(hcServicesEntity, db, transaction);
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

		public object UpdateHcServicesInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcServicesEntity hcServicesEntity = (HcServicesEntity)param;
					HcServicesDAL hcServicesDAL = new HcServicesDAL();
					retObj = (object)hcServicesDAL.UpdateHcServicesInfo(hcServicesEntity, db, transaction);
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

		public object DeleteHcServicesInfoById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcServicesDAL hcServicesDAL = new HcServicesDAL();
					retObj = (object)hcServicesDAL.DeleteHcServicesInfoById(param , db, transaction);
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

		public object GetSingleHcServicesRecordById(object param)
		{
			object retObj = null;
			HcServicesDAL hcServicesDAL = new HcServicesDAL();
			retObj = (object)hcServicesDAL.GetSingleHcServicesRecordById(param);
			return retObj;
		}

		#endregion

	}
}

