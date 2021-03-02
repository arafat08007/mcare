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
	public partial class HcProductcategoryBLL
	{
		#region Auto Generated 

		public object SaveHcProductcategoryInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcProductcategoryEntity hcProductcategoryEntity = (HcProductcategoryEntity)param;
					HcProductcategoryDAL hcProductcategoryDAL = new HcProductcategoryDAL();
					retObj = (object)hcProductcategoryDAL.SaveHcProductcategoryInfo(hcProductcategoryEntity, db, transaction);
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

		public object UpdateHcProductcategoryInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcProductcategoryEntity hcProductcategoryEntity = (HcProductcategoryEntity)param;
					HcProductcategoryDAL hcProductcategoryDAL = new HcProductcategoryDAL();
					retObj = (object)hcProductcategoryDAL.UpdateHcProductcategoryInfo(hcProductcategoryEntity, db, transaction);
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

		public object DeleteHcProductcategoryInfoById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcProductcategoryDAL hcProductcategoryDAL = new HcProductcategoryDAL();
					retObj = (object)hcProductcategoryDAL.DeleteHcProductcategoryInfoById(param , db, transaction);
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

		public object GetSingleHcProductcategoryRecordById(object param)
		{
			object retObj = null;
			HcProductcategoryDAL hcProductcategoryDAL = new HcProductcategoryDAL();
			retObj = (object)hcProductcategoryDAL.GetSingleHcProductcategoryRecordById(param);
			return retObj;
		}

		#endregion

	}
}

