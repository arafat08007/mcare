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
	public partial class HcTestCategoryBLL
	{
		#region Auto Generated 

		public object SaveHcTestCategoryInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcTestCategoryEntity hcTestCategoryEntity = (HcTestCategoryEntity)param;
					HcTestCategoryDAL hcTestCategoryDAL = new HcTestCategoryDAL();
					retObj = (object)hcTestCategoryDAL.SaveHcTestCategoryInfo(hcTestCategoryEntity, db, transaction);
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

		public object UpdateHcTestCategoryInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcTestCategoryEntity hcTestCategoryEntity = (HcTestCategoryEntity)param;
					HcTestCategoryDAL hcTestCategoryDAL = new HcTestCategoryDAL();
					retObj = (object)hcTestCategoryDAL.UpdateHcTestCategoryInfo(hcTestCategoryEntity, db, transaction);
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

		public object DeleteHcTestCategoryInfoById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcTestCategoryDAL hcTestCategoryDAL = new HcTestCategoryDAL();
					retObj = (object)hcTestCategoryDAL.DeleteHcTestCategoryInfoById(param , db, transaction);
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

		public object GetSingleHcTestCategoryRecordById(object param)
		{
			object retObj = null;
			HcTestCategoryDAL hcTestCategoryDAL = new HcTestCategoryDAL();
			retObj = (object)hcTestCategoryDAL.GetSingleHcTestCategoryRecordById(param);
			return retObj;
		}

		#endregion

	}
}

