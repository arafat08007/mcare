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
	public partial class HcPackagedetailsBLL
	{
		#region Auto Generated 

		public object SaveHcPackagedetailsInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcPackagedetailsEntity hcPackagedetailsEntity = (HcPackagedetailsEntity)param;
					HcPackagedetailsDAL hcPackagedetailsDAL = new HcPackagedetailsDAL();
					retObj = (object)hcPackagedetailsDAL.SaveHcPackagedetailsInfo(hcPackagedetailsEntity, db, transaction);
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

		public object UpdateHcPackagedetailsInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcPackagedetailsEntity hcPackagedetailsEntity = (HcPackagedetailsEntity)param;
					HcPackagedetailsDAL hcPackagedetailsDAL = new HcPackagedetailsDAL();
					retObj = (object)hcPackagedetailsDAL.UpdateHcPackagedetailsInfo(hcPackagedetailsEntity, db, transaction);
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

		public object DeleteHcPackagedetailsInfoById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcPackagedetailsDAL hcPackagedetailsDAL = new HcPackagedetailsDAL();
					retObj = (object)hcPackagedetailsDAL.DeleteHcPackagedetailsInfoById(param , db, transaction);
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

		public object GetSingleHcPackagedetailsRecordById(object param)
		{
			object retObj = null;
			HcPackagedetailsDAL hcPackagedetailsDAL = new HcPackagedetailsDAL();
			retObj = (object)hcPackagedetailsDAL.GetSingleHcPackagedetailsRecordById(param);
			return retObj;
		}

		#endregion

	}
}

