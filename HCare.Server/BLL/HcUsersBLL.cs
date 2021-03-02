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
	public partial class HcUsersBLL
	{
		#region Auto Generated 

		public object SaveHcUsersInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcUsersEntity hcUsersEntity = (HcUsersEntity)param;
					HcUsersDAL hcUsersDAL = new HcUsersDAL();
					retObj = (object)hcUsersDAL.SaveHcUsersInfo(hcUsersEntity, db, transaction);
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

		public object UpdateHcUsersInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcUsersEntity hcUsersEntity = (HcUsersEntity)param;
					HcUsersDAL hcUsersDAL = new HcUsersDAL();
					retObj = (object)hcUsersDAL.UpdateHcUsersInfo(hcUsersEntity, db, transaction);
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

		public object DeleteHcUsersInfoById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcUsersDAL hcUsersDAL = new HcUsersDAL();
					retObj = (object)hcUsersDAL.DeleteHcUsersInfoById(param , db, transaction);
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

		public object GetSingleHcUsersRecordById(object param)
		{
			object retObj = null;
			HcUsersDAL hcUsersDAL = new HcUsersDAL();
			retObj = (object)hcUsersDAL.GetSingleHcUsersRecordById(param);
			return retObj;
		}

		#endregion

	}
}

