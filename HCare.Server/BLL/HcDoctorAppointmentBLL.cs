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
	public partial class HcDoctorAppointmentBLL
	{
		#region Auto Generated 

		public object SaveHcDoctorAppointmentInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcDoctorAppointmentEntity hcDoctorAppointmentEntity = (HcDoctorAppointmentEntity)param;
					HcDoctorAppointmentDAL hcDoctorAppointmentDAL = new HcDoctorAppointmentDAL();
					retObj = (object)hcDoctorAppointmentDAL.SaveHcDoctorAppointmentInfo(hcDoctorAppointmentEntity, db, transaction);
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

		public object UpdateHcDoctorAppointmentInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcDoctorAppointmentEntity hcDoctorAppointmentEntity = (HcDoctorAppointmentEntity)param;
					HcDoctorAppointmentDAL hcDoctorAppointmentDAL = new HcDoctorAppointmentDAL();
					retObj = (object)hcDoctorAppointmentDAL.UpdateHcDoctorAppointmentInfo(hcDoctorAppointmentEntity, db, transaction);
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

		public object DeleteHcDoctorAppointmentInfoById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcDoctorAppointmentDAL hcDoctorAppointmentDAL = new HcDoctorAppointmentDAL();
					retObj = (object)hcDoctorAppointmentDAL.DeleteHcDoctorAppointmentInfoById(param , db, transaction);
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

		public object GetSingleHcDoctorAppointmentRecordById(object param)
		{
			object retObj = null;
			HcDoctorAppointmentDAL hcDoctorAppointmentDAL = new HcDoctorAppointmentDAL();
			retObj = (object)hcDoctorAppointmentDAL.GetSingleHcDoctorAppointmentRecordById(param);
			return retObj;
		}

		#endregion

	}
}

