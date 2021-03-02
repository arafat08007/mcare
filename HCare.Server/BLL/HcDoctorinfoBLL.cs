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
	public partial class HcDoctorinfoBLL
	{
		#region Auto Generated 

		public object SaveHcDoctorinfoInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcDoctorinfoEntity hcDoctorinfoEntity = (HcDoctorinfoEntity)param;
					HcDoctorinfoDAL hcDoctorinfoDAL = new HcDoctorinfoDAL();
					retObj = (object)hcDoctorinfoDAL.SaveHcDoctorinfoInfo(hcDoctorinfoEntity, db, transaction);
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

		public object UpdateHcDoctorinfoInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcDoctorinfoEntity hcDoctorinfoEntity = (HcDoctorinfoEntity)param;
					HcDoctorinfoDAL hcDoctorinfoDAL = new HcDoctorinfoDAL();
					retObj = (object)hcDoctorinfoDAL.UpdateHcDoctorinfoInfo(hcDoctorinfoEntity, db, transaction);
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

		public object DeleteHcDoctorinfoInfoById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcDoctorinfoDAL hcDoctorinfoDAL = new HcDoctorinfoDAL();
					retObj = (object)hcDoctorinfoDAL.DeleteHcDoctorinfoInfoById(param , db, transaction);
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

		public object GetSingleHcDoctorinfoRecordById(object param)
		{
			object retObj = null;
			HcDoctorinfoDAL hcDoctorinfoDAL = new HcDoctorinfoDAL();
			retObj = (object)hcDoctorinfoDAL.GetSingleHcDoctorinfoRecordById(param);
			return retObj;
		}

		#endregion

	}
}

