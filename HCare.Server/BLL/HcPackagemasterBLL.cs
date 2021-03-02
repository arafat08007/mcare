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
	public partial class HcPackagemasterBLL
	{
		#region Auto Generated 

		public object SaveHcPackagemasterInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcPackagemasterEntity hcPackagemasterEntity = (HcPackagemasterEntity)param;
					HcPackagemasterDAL hcPackagemasterDAL = new HcPackagemasterDAL();
					retObj = (object)hcPackagemasterDAL.SaveHcPackagemasterInfo(hcPackagemasterEntity, db, transaction);
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

		public object UpdateHcPackagemasterInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcPackagemasterEntity hcPackagemasterEntity = (HcPackagemasterEntity)param;
					HcPackagemasterDAL hcPackagemasterDAL = new HcPackagemasterDAL();
					retObj = (object)hcPackagemasterDAL.UpdateHcPackagemasterInfo(hcPackagemasterEntity, db, transaction);
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

		public object DeleteHcPackagemasterInfoById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcPackagemasterDAL hcPackagemasterDAL = new HcPackagemasterDAL();
					retObj = (object)hcPackagemasterDAL.DeleteHcPackagemasterInfoById(param , db, transaction);
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

		public object GetSingleHcPackagemasterRecordById(object param)
		{
			object retObj = null;
			HcPackagemasterDAL hcPackagemasterDAL = new HcPackagemasterDAL();
			retObj = (object)hcPackagemasterDAL.GetSingleHcPackagemasterRecordById(param);
			return retObj;
		}

		#endregion

	}
}

