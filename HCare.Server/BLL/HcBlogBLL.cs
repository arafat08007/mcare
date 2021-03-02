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
	public partial class HcBlogBLL
	{
		#region Auto Generated 

		public object SaveHcBlogInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcBlogEntity hcBlogEntity = (HcBlogEntity)param;
					HcBlogDAL hcBlogDAL = new HcBlogDAL();
					retObj = (object)hcBlogDAL.SaveHcBlogInfo(hcBlogEntity, db, transaction);
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

		public object UpdateHcBlogInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcBlogEntity hcBlogEntity = (HcBlogEntity)param;
					HcBlogDAL hcBlogDAL = new HcBlogDAL();
					retObj = (object)hcBlogDAL.UpdateHcBlogInfo(hcBlogEntity, db, transaction);
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

		public object DeleteHcBlogInfoById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcBlogDAL hcBlogDAL = new HcBlogDAL();
					retObj = (object)hcBlogDAL.DeleteHcBlogInfoById(param , db, transaction);
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

		public object GetSingleHcBlogRecordById(object param)
		{
			object retObj = null;
			HcBlogDAL hcBlogDAL = new HcBlogDAL();
			retObj = (object)hcBlogDAL.GetSingleHcBlogRecordById(param);
			return retObj;
		}

		#endregion

	}
}

