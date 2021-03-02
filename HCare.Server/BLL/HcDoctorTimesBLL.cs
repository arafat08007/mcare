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
	public partial class HcDoctorTimesBLL
	{
		#region Auto Generated 

		public object SaveHcDoctorTimesInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcDoctorTimesEntity hcDoctorTimesEntity = (HcDoctorTimesEntity)param;
					HcDoctorTimesDAL hcDoctorTimesDAL = new HcDoctorTimesDAL();
					retObj = (object)hcDoctorTimesDAL.SaveHcDoctorTimesInfo(hcDoctorTimesEntity, db, transaction);
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

		public object UpdateHcDoctorTimesInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcDoctorTimesEntity hcDoctorTimesEntity = (HcDoctorTimesEntity)param;
					HcDoctorTimesDAL hcDoctorTimesDAL = new HcDoctorTimesDAL();
					retObj = (object)hcDoctorTimesDAL.UpdateHcDoctorTimesInfo(hcDoctorTimesEntity, db, transaction);
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

		public object DeleteHcDoctorTimesInfoById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcDoctorTimesDAL hcDoctorTimesDAL = new HcDoctorTimesDAL();
					retObj = (object)hcDoctorTimesDAL.DeleteHcDoctorTimesInfoById(param , db, transaction);
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

		public object GetSingleHcDoctorTimesRecordById(object param)
		{
			object retObj = null;
			HcDoctorTimesDAL hcDoctorTimesDAL = new HcDoctorTimesDAL();
			retObj = (object)hcDoctorTimesDAL.GetSingleHcDoctorTimesRecordById(param);
			return retObj;
		}

		#endregion

	}
}

