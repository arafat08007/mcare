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
	public partial class HcDiseasesBLL
	{
		#region Auto Generated 

		public object SaveHcDiseasesInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcDiseasesEntity hcDiseasesEntity = (HcDiseasesEntity)param;
					HcDiseasesDAL hcDiseasesDAL = new HcDiseasesDAL();
					retObj = (object)hcDiseasesDAL.SaveHcDiseasesInfo(hcDiseasesEntity, db, transaction);
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

		public object UpdateHcDiseasesInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcDiseasesEntity hcDiseasesEntity = (HcDiseasesEntity)param;
					HcDiseasesDAL hcDiseasesDAL = new HcDiseasesDAL();
					retObj = (object)hcDiseasesDAL.UpdateHcDiseasesInfo(hcDiseasesEntity, db, transaction);
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

		public object DeleteHcDiseasesInfoById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcDiseasesDAL hcDiseasesDAL = new HcDiseasesDAL();
					retObj = (object)hcDiseasesDAL.DeleteHcDiseasesInfoById(param , db, transaction);
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

		public object GetSingleHcDiseasesRecordById(object param)
		{
			object retObj = null;
			HcDiseasesDAL hcDiseasesDAL = new HcDiseasesDAL();
			retObj = (object)hcDiseasesDAL.GetSingleHcDiseasesRecordById(param);
			return retObj;
		}

		#endregion

	}
}

