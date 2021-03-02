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
	public partial class HcOffersBLL
	{
		#region Auto Generated 

		public object SaveHcOffersInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcOffersEntity hcOffersEntity = (HcOffersEntity)param;
					HcOffersDAL hcOffersDAL = new HcOffersDAL();
					retObj = (object)hcOffersDAL.SaveHcOffersInfo(hcOffersEntity, db, transaction);
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

		public object UpdateHcOffersInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcOffersEntity hcOffersEntity = (HcOffersEntity)param;
					HcOffersDAL hcOffersDAL = new HcOffersDAL();
					retObj = (object)hcOffersDAL.UpdateHcOffersInfo(hcOffersEntity, db, transaction);
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

		public object DeleteHcOffersInfoById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcOffersDAL hcOffersDAL = new HcOffersDAL();
					retObj = (object)hcOffersDAL.DeleteHcOffersInfoById(param , db, transaction);
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

		public object GetSingleHcOffersRecordById(object param)
		{
			object retObj = null;
			HcOffersDAL hcOffersDAL = new HcOffersDAL();
			retObj = (object)hcOffersDAL.GetSingleHcOffersRecordById(param);
			return retObj;
		}

		#endregion

	}
}

