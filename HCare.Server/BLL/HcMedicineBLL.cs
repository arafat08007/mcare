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
	public partial class HcMedicineBLL
	{
		#region Auto Generated 

		public object SaveHcMedicineInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcMedicineEntity hcMedicineEntity = (HcMedicineEntity)param;
					HcMedicineDAL hcMedicineDAL = new HcMedicineDAL();
					retObj = (object)hcMedicineDAL.SaveHcMedicineInfo(hcMedicineEntity, db, transaction);
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

		public object UpdateHcMedicineInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcMedicineEntity hcMedicineEntity = (HcMedicineEntity)param;
					HcMedicineDAL hcMedicineDAL = new HcMedicineDAL();
					retObj = (object)hcMedicineDAL.UpdateHcMedicineInfo(hcMedicineEntity, db, transaction);
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

		public object DeleteHcMedicineInfoById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcMedicineDAL hcMedicineDAL = new HcMedicineDAL();
					retObj = (object)hcMedicineDAL.DeleteHcMedicineInfoById(param , db, transaction);
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

		public object GetSingleHcMedicineRecordById(object param)
		{
			object retObj = null;
			HcMedicineDAL hcMedicineDAL = new HcMedicineDAL();
			retObj = (object)hcMedicineDAL.GetSingleHcMedicineRecordById(param);
			return retObj;
		}

		#endregion

	}
}

