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
	public partial class HcCountryBLL
	{
		#region Auto Generated 

		public object SaveHcCountryInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcCountryEntity hcCountryEntity = (HcCountryEntity)param;
					HcCountryDAL hcCountryDAL = new HcCountryDAL();
					retObj = (object)hcCountryDAL.SaveHcCountryInfo(hcCountryEntity, db, transaction);
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

		public object UpdateHcCountryInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcCountryEntity hcCountryEntity = (HcCountryEntity)param;
					HcCountryDAL hcCountryDAL = new HcCountryDAL();
					retObj = (object)hcCountryDAL.UpdateHcCountryInfo(hcCountryEntity, db, transaction);
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

		public object DeleteHcCountryInfoById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcCountryDAL hcCountryDAL = new HcCountryDAL();
					retObj = (object)hcCountryDAL.DeleteHcCountryInfoById(param , db, transaction);
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

		public object GetSingleHcCountryRecordById(object param)
		{
			object retObj = null;
			HcCountryDAL hcCountryDAL = new HcCountryDAL();
			retObj = (object)hcCountryDAL.GetSingleHcCountryRecordById(param);
			return retObj;
		}

		#endregion

	}
}

