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
	public partial class HcEmergencycontactBLL
	{
		#region Auto Generated 

		public object SaveHcEmergencycontactInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcEmergencycontactEntity hcEmergencycontactEntity = (HcEmergencycontactEntity)param;
					HcEmergencycontactDAL hcEmergencycontactDAL = new HcEmergencycontactDAL();
					retObj = (object)hcEmergencycontactDAL.SaveHcEmergencycontactInfo(hcEmergencycontactEntity, db, transaction);
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

		public object UpdateHcEmergencycontactInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcEmergencycontactEntity hcEmergencycontactEntity = (HcEmergencycontactEntity)param;
					HcEmergencycontactDAL hcEmergencycontactDAL = new HcEmergencycontactDAL();
					retObj = (object)hcEmergencycontactDAL.UpdateHcEmergencycontactInfo(hcEmergencycontactEntity, db, transaction);
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

		public object DeleteHcEmergencycontactInfoById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcEmergencycontactDAL hcEmergencycontactDAL = new HcEmergencycontactDAL();
					retObj = (object)hcEmergencycontactDAL.DeleteHcEmergencycontactInfoById(param , db, transaction);
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

		public object GetSingleHcEmergencycontactRecordById(object param)
		{
			object retObj = null;
			HcEmergencycontactDAL hcEmergencycontactDAL = new HcEmergencycontactDAL();
			retObj = (object)hcEmergencycontactDAL.GetSingleHcEmergencycontactRecordById(param);
			return retObj;
		}

		#endregion

	}
}

