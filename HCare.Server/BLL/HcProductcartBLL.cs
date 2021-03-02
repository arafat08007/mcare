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
	public partial class HcProductcartBLL
	{
		#region Auto Generated 

		public object SaveHcProductcartInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcProductcartEntity hcProductcartEntity = (HcProductcartEntity)param;
					HcProductcartDAL hcProductcartDAL = new HcProductcartDAL();
					retObj = (object)hcProductcartDAL.SaveHcProductcartInfo(hcProductcartEntity, db, transaction);
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

		public object UpdateHcProductcartInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcProductcartEntity hcProductcartEntity = (HcProductcartEntity)param;
					HcProductcartDAL hcProductcartDAL = new HcProductcartDAL();
					retObj = (object)hcProductcartDAL.UpdateHcProductcartInfo(hcProductcartEntity, db, transaction);
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

		public object DeleteHcProductcartInfoById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcProductcartDAL hcProductcartDAL = new HcProductcartDAL();
					retObj = (object)hcProductcartDAL.DeleteHcProductcartInfoById(param , db, transaction);
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

		public object GetSingleHcProductcartRecordById(object param)
		{
			object retObj = null;
			HcProductcartDAL hcProductcartDAL = new HcProductcartDAL();
			retObj = (object)hcProductcartDAL.GetSingleHcProductcartRecordById(param);
			return retObj;
		}

		#endregion

	}
}

