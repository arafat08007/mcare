using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using HCare.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;


namespace HCare.Server.DAL
{
	public partial class HcCommunicationchannelDAL
	{
		#region Auto Generated 

		public bool SaveHcCommunicationchannelInfo(HcCommunicationchannelEntity hcCommunicationchannelEntity, Database db, DbTransaction transaction)
		{
			string sql = "INSERT INTO HC_CommunicationChannel ( Id, Type, ModuleIdentifier, Modulename, isActive) VALUES (  @Id,  @Type,  @Moduleidentifier,  @Modulename,  @Isactive )";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);

			db.AddInParameter(dbCommand, "Id", DbType.String, hcCommunicationchannelEntity.Id);
			db.AddInParameter(dbCommand, "Type", DbType.String, hcCommunicationchannelEntity.Type);
			db.AddInParameter(dbCommand, "Moduleidentifier", DbType.String, hcCommunicationchannelEntity.Moduleidentifier);
			db.AddInParameter(dbCommand, "Modulename", DbType.String, hcCommunicationchannelEntity.Modulename);
			db.AddInParameter(dbCommand, "Isactive", DbType.String, hcCommunicationchannelEntity.Isactive);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;		}

		public bool UpdateHcCommunicationchannelInfo(HcCommunicationchannelEntity hcCommunicationchannelEntity, Database db, DbTransaction transaction)
		{
			string sql = "UPDATE HC_CommunicationChannel SET Type= @Type, ModuleIdentifier= @Moduleidentifier, Modulename= @Modulename, isActive= @Isactive WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id",DbType.String, hcCommunicationchannelEntity.Id);
			db.AddInParameter(dbCommand, "Type", DbType.String, hcCommunicationchannelEntity.Type);
			db.AddInParameter(dbCommand, "Moduleidentifier", DbType.String, hcCommunicationchannelEntity.Moduleidentifier);
			db.AddInParameter(dbCommand, "Modulename", DbType.String, hcCommunicationchannelEntity.Modulename);
			db.AddInParameter(dbCommand, "Isactive", DbType.String, hcCommunicationchannelEntity.Isactive);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public bool DeleteHcCommunicationchannelInfoById(object param, Database db, DbTransaction transaction)
		{
			string sql = "DELETE FROM HC_CommunicationChannel WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public HcCommunicationchannelEntity GetSingleHcCommunicationchannelRecordById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sql = "SELECT Id, Type, ModuleIdentifier, Modulename, isActive FROM HC_CommunicationChannel WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);
			HcCommunicationchannelEntity hcCommunicationchannelEntity = null;
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
			{
				if (dataReader.Read())
				{
					hcCommunicationchannelEntity = new HcCommunicationchannelEntity();
					if (dataReader["Id"] != DBNull.Value)
					{
						hcCommunicationchannelEntity.Id = dataReader["Id"].ToString();
					}
					if (dataReader["Type"] != DBNull.Value)
					{
						hcCommunicationchannelEntity.Type = dataReader["Type"].ToString();
					}
					if (dataReader["ModuleIdentifier"] != DBNull.Value)
					{
						hcCommunicationchannelEntity.Moduleidentifier = dataReader["ModuleIdentifier"].ToString();
					}
					if (dataReader["Modulename"] != DBNull.Value)
					{
						hcCommunicationchannelEntity.Modulename = dataReader["Modulename"].ToString();
					}
					if (dataReader["isActive"] != DBNull.Value)
					{
						hcCommunicationchannelEntity.Isactive = dataReader["isActive"].ToString();
					}
				}
			}
			return hcCommunicationchannelEntity;
		}

		#endregion

	}
}

