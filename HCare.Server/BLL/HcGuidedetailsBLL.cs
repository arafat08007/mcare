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
	public partial class HcGuidedetailsBLL
	{
		#region Auto Generated 

		public object SaveHcGuidedetailsInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcGuidedetailsEntity hcGuidedetailsEntity = (HcGuidedetailsEntity)param;
					HcGuidedetailsDAL hcGuidedetailsDAL = new HcGuidedetailsDAL();
					retObj = (object)hcGuidedetailsDAL.SaveHcGuidedetailsInfo(hcGuidedetailsEntity, db, transaction);
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

		public object UpdateHcGuidedetailsInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcGuidedetailsEntity hcGuidedetailsEntity = (HcGuidedetailsEntity)param;
					HcGuidedetailsDAL hcGuidedetailsDAL = new HcGuidedetailsDAL();
					retObj = (object)hcGuidedetailsDAL.UpdateHcGuidedetailsInfo(hcGuidedetailsEntity, db, transaction);
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

		public object DeleteHcGuidedetailsInfoById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcGuidedetailsDAL hcGuidedetailsDAL = new HcGuidedetailsDAL();
					retObj = (object)hcGuidedetailsDAL.DeleteHcGuidedetailsInfoById(param , db, transaction);
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

		public object GetSingleHcGuidedetailsRecordById(object param)
		{
			object retObj = null;
			HcGuidedetailsDAL hcGuidedetailsDAL = new HcGuidedetailsDAL();
			retObj = (object)hcGuidedetailsDAL.GetSingleHcGuidedetailsRecordById(param);
			return retObj;
		}

		#endregion

	}
}

