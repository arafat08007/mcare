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
	public partial class HcProductorderBLL
	{
		#region Auto Generated 

		public object SaveHcProductorderInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcProductorderEntity hcProductorderEntity = (HcProductorderEntity)param;
					HcProductorderDAL hcProductorderDAL = new HcProductorderDAL();
					retObj = (object)hcProductorderDAL.SaveHcProductorderInfo(hcProductorderEntity, db, transaction);
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

		public object UpdateHcProductorderInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcProductorderEntity hcProductorderEntity = (HcProductorderEntity)param;
					HcProductorderDAL hcProductorderDAL = new HcProductorderDAL();
					retObj = (object)hcProductorderDAL.UpdateHcProductorderInfo(hcProductorderEntity, db, transaction);
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

		public object DeleteHcProductorderInfoById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcProductorderDAL hcProductorderDAL = new HcProductorderDAL();
                    HcProductorderEntity hcProductorderEntity = (HcProductorderEntity)param;
                    retObj = (object)hcProductorderDAL.DeleteHcProductorderInfoById(hcProductorderEntity, db, transaction);
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

		public object GetSingleHcProductorderRecordById(object param)
		{
			object retObj = null;
			HcProductorderDAL hcProductorderDAL = new HcProductorderDAL();
			retObj = (object)hcProductorderDAL.GetSingleHcProductorderRecordById(param);
			return retObj;
		}

		#endregion

	}
}

