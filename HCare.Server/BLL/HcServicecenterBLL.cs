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
	public partial class HcServicecenterBLL
	{
		#region Auto Generated 

		public object SaveHcServicecenterInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcServicecenterEntity hcServicecenterEntity = (HcServicecenterEntity)param;
					HcServicecenterDAL hcServicecenterDAL = new HcServicecenterDAL();
					retObj = (object)hcServicecenterDAL.SaveHcServicecenterInfo(hcServicecenterEntity, db, transaction);
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

		public object UpdateHcServicecenterInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcServicecenterEntity hcServicecenterEntity = (HcServicecenterEntity)param;
					HcServicecenterDAL hcServicecenterDAL = new HcServicecenterDAL();
					retObj = (object)hcServicecenterDAL.UpdateHcServicecenterInfo(hcServicecenterEntity, db, transaction);
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

		public object DeleteHcServicecenterInfoById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcServicecenterDAL hcServicecenterDAL = new HcServicecenterDAL();
					retObj = (object)hcServicecenterDAL.DeleteHcServicecenterInfoById(param , db, transaction);
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

		public object GetSingleHcServicecenterRecordById(object param)
		{
			object retObj = null;
			HcServicecenterDAL hcServicecenterDAL = new HcServicecenterDAL();
			retObj = (object)hcServicecenterDAL.GetSingleHcServicecenterRecordById(param);
			return retObj;
		}

		#endregion

	}
}

