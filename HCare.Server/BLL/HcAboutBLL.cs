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
	public partial class HcAboutBLL
	{
		#region Auto Generated 

		public object SaveHcAboutInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcAboutEntity hcAboutEntity = (HcAboutEntity)param;
					HcAboutDAL hcAboutDAL = new HcAboutDAL();
					retObj = (object)hcAboutDAL.SaveHcAboutInfo(hcAboutEntity, db, transaction);
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

		public object UpdateHcAboutInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcAboutEntity hcAboutEntity = (HcAboutEntity)param;
					HcAboutDAL hcAboutDAL = new HcAboutDAL();
					retObj = (object)hcAboutDAL.UpdateHcAboutInfo(hcAboutEntity, db, transaction);
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

		public object DeleteHcAboutInfoById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcAboutDAL hcAboutDAL = new HcAboutDAL();
					retObj = (object)hcAboutDAL.DeleteHcAboutInfoById(param , db, transaction);
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

		public object GetSingleHcAboutRecordById(object param)
		{
			object retObj = null;
			HcAboutDAL hcAboutDAL = new HcAboutDAL();
			retObj = (object)hcAboutDAL.GetSingleHcAboutRecordById(param);
			return retObj;
		}

		#endregion

	}
}

