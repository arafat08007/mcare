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
	public partial class AdmMenusubBLL
	{
		#region Auto Generated 

		public object SaveAdmMenusubInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					AdmMenusubEntity admMenusubEntity = (AdmMenusubEntity)param;
					AdmMenusubDAL admMenusubDAL = new AdmMenusubDAL();
					retObj = (object)admMenusubDAL.SaveAdmMenusubInfo(admMenusubEntity, db, transaction);
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

		public object UpdateAdmMenusubInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					AdmMenusubEntity admMenusubEntity = (AdmMenusubEntity)param;
					AdmMenusubDAL admMenusubDAL = new AdmMenusubDAL();
					retObj = (object)admMenusubDAL.UpdateAdmMenusubInfo(admMenusubEntity, db, transaction);
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

		public object DeleteAdmMenusubInfoById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					AdmMenusubDAL admMenusubDAL = new AdmMenusubDAL();
					retObj = (object)admMenusubDAL.DeleteAdmMenusubInfoById(param , db, transaction);
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

		public object GetSingleAdmMenusubRecordById(object param)
		{
			object retObj = null;
			AdmMenusubDAL admMenusubDAL = new AdmMenusubDAL();
			retObj = (object)admMenusubDAL.GetSingleAdmMenusubRecordById(param);
			return retObj;
		}

		#endregion

	}
}

