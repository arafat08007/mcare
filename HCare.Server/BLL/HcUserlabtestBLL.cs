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
	public partial class HcUserlabtestBLL
	{
		#region Auto Generated 

		public object SaveHcUserlabtestInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcUserlabtestEntity hcUserlabtestEntity = (HcUserlabtestEntity)param;
					HcUserlabtestDAL hcUserlabtestDAL = new HcUserlabtestDAL();
					retObj = (object)hcUserlabtestDAL.SaveHcUserlabtestInfo(hcUserlabtestEntity, db, transaction);
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

		public object UpdateHcUserlabtestInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcUserlabtestEntity hcUserlabtestEntity = (HcUserlabtestEntity)param;
					HcUserlabtestDAL hcUserlabtestDAL = new HcUserlabtestDAL();
					retObj = (object)hcUserlabtestDAL.UpdateHcUserlabtestInfo(hcUserlabtestEntity, db, transaction);
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

		public object DeleteHcUserlabtestInfoById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcUserlabtestDAL hcUserlabtestDAL = new HcUserlabtestDAL();
					retObj = (object)hcUserlabtestDAL.DeleteHcUserlabtestInfoById(param , db, transaction);
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

		public object GetSingleHcUserlabtestRecordById(object param)
		{
			object retObj = null;
			HcUserlabtestDAL hcUserlabtestDAL = new HcUserlabtestDAL();
			retObj = (object)hcUserlabtestDAL.GetSingleHcUserlabtestRecordById(param);
			return retObj;
		}

		#endregion

	}
}

