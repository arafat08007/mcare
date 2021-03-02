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
	public partial class HcDoctorDepartmentsBLL
	{
		#region Auto Generated 

		public object SaveHcDoctorDepartmentsInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcDoctorDepartmentsEntity hcDoctorDepartmentsEntity = (HcDoctorDepartmentsEntity)param;
					HcDoctorDepartmentsDAL hcDoctorDepartmentsDAL = new HcDoctorDepartmentsDAL();
					retObj = (object)hcDoctorDepartmentsDAL.SaveHcDoctorDepartmentsInfo(hcDoctorDepartmentsEntity, db, transaction);
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

		public object UpdateHcDoctorDepartmentsInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcDoctorDepartmentsEntity hcDoctorDepartmentsEntity = (HcDoctorDepartmentsEntity)param;
					HcDoctorDepartmentsDAL hcDoctorDepartmentsDAL = new HcDoctorDepartmentsDAL();
					retObj = (object)hcDoctorDepartmentsDAL.UpdateHcDoctorDepartmentsInfo(hcDoctorDepartmentsEntity, db, transaction);
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

		public object DeleteHcDoctorDepartmentsInfoById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcDoctorDepartmentsDAL hcDoctorDepartmentsDAL = new HcDoctorDepartmentsDAL();
					retObj = (object)hcDoctorDepartmentsDAL.DeleteHcDoctorDepartmentsInfoById(param , db, transaction);
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

		public object GetSingleHcDoctorDepartmentsRecordById(object param)
		{
			object retObj = null;
			HcDoctorDepartmentsDAL hcDoctorDepartmentsDAL = new HcDoctorDepartmentsDAL();
			retObj = (object)hcDoctorDepartmentsDAL.GetSingleHcDoctorDepartmentsRecordById(param);
			return retObj;
		}

		#endregion

	}
}

