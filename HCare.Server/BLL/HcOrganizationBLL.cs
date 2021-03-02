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
	public partial class HcOrganizationBLL
	{
		#region Auto Generated 

		public object SaveHcOrganizationInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcOrganizationEntity hcOrganizationEntity = (HcOrganizationEntity)param;
					HcOrganizationDAL hcOrganizationDAL = new HcOrganizationDAL();
					retObj = (object)hcOrganizationDAL.SaveHcOrganizationInfo(hcOrganizationEntity, db, transaction);
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

		public object UpdateHcOrganizationInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcOrganizationEntity hcOrganizationEntity = (HcOrganizationEntity)param;
					HcOrganizationDAL hcOrganizationDAL = new HcOrganizationDAL();
					retObj = (object)hcOrganizationDAL.UpdateHcOrganizationInfo(hcOrganizationEntity, db, transaction);
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

		public object DeleteHcOrganizationInfoById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcOrganizationDAL hcOrganizationDAL = new HcOrganizationDAL();
					retObj = (object)hcOrganizationDAL.DeleteHcOrganizationInfoById(param , db, transaction);
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

		public object GetSingleHcOrganizationRecordById(object param)
		{
			object retObj = null;
			HcOrganizationDAL hcOrganizationDAL = new HcOrganizationDAL();
			retObj = (object)hcOrganizationDAL.GetSingleHcOrganizationRecordById(param);
			return retObj;
		}

		#endregion

	}
}

