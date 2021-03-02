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
	public partial class HcMedicinetypeBLL
	{
		#region Auto Generated 

		public object SaveHcMedicinetypeInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcMedicinetypeEntity hcMedicinetypeEntity = (HcMedicinetypeEntity)param;
					HcMedicinetypeDAL hcMedicinetypeDAL = new HcMedicinetypeDAL();
					retObj = (object)hcMedicinetypeDAL.SaveHcMedicinetypeInfo(hcMedicinetypeEntity, db, transaction);
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

		public object UpdateHcMedicinetypeInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcMedicinetypeEntity hcMedicinetypeEntity = (HcMedicinetypeEntity)param;
					HcMedicinetypeDAL hcMedicinetypeDAL = new HcMedicinetypeDAL();
					retObj = (object)hcMedicinetypeDAL.UpdateHcMedicinetypeInfo(hcMedicinetypeEntity, db, transaction);
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

		public object DeleteHcMedicinetypeInfoById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcMedicinetypeDAL hcMedicinetypeDAL = new HcMedicinetypeDAL();
					retObj = (object)hcMedicinetypeDAL.DeleteHcMedicinetypeInfoById(param , db, transaction);
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

		public object GetSingleHcMedicinetypeRecordById(object param)
		{
			object retObj = null;
			HcMedicinetypeDAL hcMedicinetypeDAL = new HcMedicinetypeDAL();
			retObj = (object)hcMedicinetypeDAL.GetSingleHcMedicinetypeRecordById(param);
			return retObj;
		}

		#endregion

	}
}

