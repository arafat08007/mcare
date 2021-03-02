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
	public partial class AdmMenuBLL
	{
		#region Auto Generated 

		public object SaveAdmMenuInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					AdmMenuEntity admMenuEntity = (AdmMenuEntity)param;
					AdmMenuDAL admMenuDAL = new AdmMenuDAL();
					retObj = (object)admMenuDAL.SaveAdmMenuInfo(admMenuEntity, db, transaction);
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

		public object UpdateAdmMenuInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					AdmMenuEntity admMenuEntity = (AdmMenuEntity)param;
					AdmMenuDAL admMenuDAL = new AdmMenuDAL();
					retObj = (object)admMenuDAL.UpdateAdmMenuInfo(admMenuEntity, db, transaction);
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

		public object DeleteAdmMenuInfoById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					AdmMenuDAL admMenuDAL = new AdmMenuDAL();
					retObj = (object)admMenuDAL.DeleteAdmMenuInfoById(param , db, transaction);
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

		public object GetSingleAdmMenuRecordById(object param)
		{
			object retObj = null;
			AdmMenuDAL admMenuDAL = new AdmMenuDAL();
			retObj = (object)admMenuDAL.GetSingleAdmMenuRecordById(param);
			return retObj;
		}

		#endregion

	}
}

