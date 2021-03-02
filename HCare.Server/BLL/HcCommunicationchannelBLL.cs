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
	public partial class HcCommunicationchannelBLL
	{
		#region Auto Generated 

		public object SaveHcCommunicationchannelInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcCommunicationchannelEntity hcCommunicationchannelEntity = (HcCommunicationchannelEntity)param;
					HcCommunicationchannelDAL hcCommunicationchannelDAL = new HcCommunicationchannelDAL();
					retObj = (object)hcCommunicationchannelDAL.SaveHcCommunicationchannelInfo(hcCommunicationchannelEntity, db, transaction);
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

		public object UpdateHcCommunicationchannelInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcCommunicationchannelEntity hcCommunicationchannelEntity = (HcCommunicationchannelEntity)param;
					HcCommunicationchannelDAL hcCommunicationchannelDAL = new HcCommunicationchannelDAL();
					retObj = (object)hcCommunicationchannelDAL.UpdateHcCommunicationchannelInfo(hcCommunicationchannelEntity, db, transaction);
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

		public object DeleteHcCommunicationchannelInfoById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					HcCommunicationchannelDAL hcCommunicationchannelDAL = new HcCommunicationchannelDAL();
					retObj = (object)hcCommunicationchannelDAL.DeleteHcCommunicationchannelInfoById(param , db, transaction);
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

		public object GetSingleHcCommunicationchannelRecordById(object param)
		{
			object retObj = null;
			HcCommunicationchannelDAL hcCommunicationchannelDAL = new HcCommunicationchannelDAL();
			retObj = (object)hcCommunicationchannelDAL.GetSingleHcCommunicationchannelRecordById(param);
			return retObj;
		}

		#endregion

	}
}

