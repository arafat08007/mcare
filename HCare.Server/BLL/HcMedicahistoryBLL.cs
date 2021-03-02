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
	public partial class HcMedicahistoryBLL
	{
		#region Auto Generated 

		public object SaveHcMedicahistoryInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcMedicahistoryEntity hcMedicahistoryEntity = (HcMedicahistoryEntity)param;
					HcMedicahistoryDAL hcMedicahistoryDAL = new HcMedicahistoryDAL();
					retObj = (object)hcMedicahistoryDAL.SaveHcMedicahistoryInfo(hcMedicahistoryEntity, db, transaction);
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

		public object UpdateHcMedicahistoryInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcMedicahistoryEntity hcMedicahistoryEntity = (HcMedicahistoryEntity)param;
					HcMedicahistoryDAL hcMedicahistoryDAL = new HcMedicahistoryDAL();
					retObj = (object)hcMedicahistoryDAL.UpdateHcMedicahistoryInfo(hcMedicahistoryEntity, db, transaction);
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

		public object DeleteHcMedicahistoryInfoById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcMedicahistoryDAL hcMedicahistoryDAL = new HcMedicahistoryDAL();
					retObj = (object)hcMedicahistoryDAL.DeleteHcMedicahistoryInfoById(param , db, transaction);
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

		public object GetSingleHcMedicahistoryRecordById(object param)
		{
			object retObj = null;
			HcMedicahistoryDAL hcMedicahistoryDAL = new HcMedicahistoryDAL();
			retObj = (object)hcMedicahistoryDAL.GetSingleHcMedicahistoryRecordById(param);
			return retObj;
		}

		#endregion

	}
}

