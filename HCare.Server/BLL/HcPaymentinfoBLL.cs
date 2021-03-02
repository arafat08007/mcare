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
	public partial class HcPaymentinfoBLL
	{
		#region Auto Generated 

		public object SaveHcPaymentinfoInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcPaymentinfoEntity hcPaymentinfoEntity = (HcPaymentinfoEntity)param;
					HcPaymentinfoDAL hcPaymentinfoDAL = new HcPaymentinfoDAL();
					retObj = (object)hcPaymentinfoDAL.SaveHcPaymentinfoInfo(hcPaymentinfoEntity, db, transaction);
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

		public object UpdateHcPaymentinfoInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcPaymentinfoEntity hcPaymentinfoEntity = (HcPaymentinfoEntity)param;
					HcPaymentinfoDAL hcPaymentinfoDAL = new HcPaymentinfoDAL();
					retObj = (object)hcPaymentinfoDAL.UpdateHcPaymentinfoInfo(hcPaymentinfoEntity, db, transaction);
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

		public object DeleteHcPaymentinfoInfoById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcPaymentinfoDAL hcPaymentinfoDAL = new HcPaymentinfoDAL();
					retObj = (object)hcPaymentinfoDAL.DeleteHcPaymentinfoInfoById(param , db, transaction);
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

		public object GetSingleHcPaymentinfoRecordById(object param)
		{
			object retObj = null;
			HcPaymentinfoDAL hcPaymentinfoDAL = new HcPaymentinfoDAL();
			retObj = (object)hcPaymentinfoDAL.GetSingleHcPaymentinfoRecordById(param);
			return retObj;
		}

		#endregion

	}
}

