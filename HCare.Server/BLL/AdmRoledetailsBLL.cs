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
	public partial class AdmRoledetailsBLL
	{
		#region Auto Generated 

		public object SaveAdmRoledetailsInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					AdmRoledetailsEntity admRoledetailsEntity = (AdmRoledetailsEntity)param;
					AdmRoledetailsDAL admRoledetailsDAL = new AdmRoledetailsDAL();
					retObj = (object)admRoledetailsDAL.SaveAdmRoledetailsInfo(admRoledetailsEntity, db, transaction);
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

		public object UpdateAdmRoledetailsInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					AdmRoledetailsEntity admRoledetailsEntity = (AdmRoledetailsEntity)param;
					AdmRoledetailsDAL admRoledetailsDAL = new AdmRoledetailsDAL();
					retObj = (object)admRoledetailsDAL.UpdateAdmRoledetailsInfo(admRoledetailsEntity, db, transaction);
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

		public object DeleteAdmRoledetailsInfoById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					AdmRoledetailsDAL admRoledetailsDAL = new AdmRoledetailsDAL();
					retObj = (object)admRoledetailsDAL.DeleteAdmRoledetailsInfoById(param , db, transaction);
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

		public object GetSingleAdmRoledetailsRecordById(object param)
		{
			object retObj = null;
			AdmRoledetailsDAL admRoledetailsDAL = new AdmRoledetailsDAL();
			retObj = (object)admRoledetailsDAL.GetSingleAdmRoledetailsRecordById(param);
			return retObj;
		}

		#endregion

	}
}

