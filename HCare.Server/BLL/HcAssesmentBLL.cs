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
	public partial class HcAssesmentBLL
	{
		#region Auto Generated 

		public object SaveHcAssesmentInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcAssesmentEntity hcAssesmentEntity = (HcAssesmentEntity)param;
					HcAssesmentDAL hcAssesmentDAL = new HcAssesmentDAL();
					retObj = (object)hcAssesmentDAL.SaveHcAssesmentInfo(hcAssesmentEntity, db, transaction);
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

		public object UpdateHcAssesmentInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcAssesmentEntity hcAssesmentEntity = (HcAssesmentEntity)param;
					HcAssesmentDAL hcAssesmentDAL = new HcAssesmentDAL();
					retObj = (object)hcAssesmentDAL.UpdateHcAssesmentInfo(hcAssesmentEntity, db, transaction);
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

		public object DeleteHcAssesmentInfoById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcAssesmentDAL hcAssesmentDAL = new HcAssesmentDAL();
					retObj = (object)hcAssesmentDAL.DeleteHcAssesmentInfoById(param , db, transaction);
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

		public object GetSingleHcAssesmentRecordById(object param)
		{
			object retObj = null;
			HcAssesmentDAL hcAssesmentDAL = new HcAssesmentDAL();
			retObj = (object)hcAssesmentDAL.GetSingleHcAssesmentRecordById(param);
			return retObj;
		}

		#endregion

	}
}

