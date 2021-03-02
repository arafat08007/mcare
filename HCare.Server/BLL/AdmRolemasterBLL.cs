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
	public partial class AdmRolemasterBLL
	{
		#region Auto Generated 

		public object SaveAdmRolemasterInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					AdmRolemasterEntity admRolemasterEntity = (AdmRolemasterEntity)param;
					AdmRolemasterDAL admRolemasterDAL = new AdmRolemasterDAL();
					retObj = (object)admRolemasterDAL.SaveAdmRolemasterInfo(admRolemasterEntity, db, transaction);
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

		public object UpdateAdmRolemasterInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					AdmRolemasterEntity admRolemasterEntity = (AdmRolemasterEntity)param;
					AdmRolemasterDAL admRolemasterDAL = new AdmRolemasterDAL();
					retObj = (object)admRolemasterDAL.UpdateAdmRolemasterInfo(admRolemasterEntity, db, transaction);
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

		public object DeleteAdmRolemasterInfoById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					AdmRolemasterDAL admRolemasterDAL = new AdmRolemasterDAL();
					retObj = (object)admRolemasterDAL.DeleteAdmRolemasterInfoById(param , db, transaction);
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

		public object GetSingleAdmRolemasterRecordById(object param)
		{
			object retObj = null;
			AdmRolemasterDAL admRolemasterDAL = new AdmRolemasterDAL();
			retObj = (object)admRolemasterDAL.GetSingleAdmRolemasterRecordById(param);
			return retObj;
		}

		#endregion

	}
}

