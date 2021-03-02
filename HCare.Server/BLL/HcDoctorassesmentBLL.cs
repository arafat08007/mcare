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
	public partial class HcDoctorassesmentBLL
	{
		#region Auto Generated 

		public object SaveHcDoctorassesmentInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcDoctorassesmentEntity hcDoctorassesmentEntity = (HcDoctorassesmentEntity)param;
					HcDoctorassesmentDAL hcDoctorassesmentDAL = new HcDoctorassesmentDAL();
					retObj = (object)hcDoctorassesmentDAL.SaveHcDoctorassesmentInfo(hcDoctorassesmentEntity, db, transaction);
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

		public object UpdateHcDoctorassesmentInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcDoctorassesmentEntity hcDoctorassesmentEntity = (HcDoctorassesmentEntity)param;
					HcDoctorassesmentDAL hcDoctorassesmentDAL = new HcDoctorassesmentDAL();
					retObj = (object)hcDoctorassesmentDAL.UpdateHcDoctorassesmentInfo(hcDoctorassesmentEntity, db, transaction);
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

		public object DeleteHcDoctorassesmentInfoById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcDoctorassesmentDAL hcDoctorassesmentDAL = new HcDoctorassesmentDAL();
					retObj = (object)hcDoctorassesmentDAL.DeleteHcDoctorassesmentInfoById(param , db, transaction);
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

		public object GetSingleHcDoctorassesmentRecordById(object param)
		{
			object retObj = null;
			HcDoctorassesmentDAL hcDoctorassesmentDAL = new HcDoctorassesmentDAL();
			retObj = (object)hcDoctorassesmentDAL.GetSingleHcDoctorassesmentRecordById(param);
			return retObj;
		}

		#endregion

	}
}

