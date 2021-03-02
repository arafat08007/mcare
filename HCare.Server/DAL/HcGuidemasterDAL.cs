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
	public partial class HcGuidemasterDAL
	{
		#region Auto Generated 

		public bool SaveHcGuidemasterInfo(HcGuidemasterEntity hcGuidemasterEntity, Database db, DbTransaction transaction)
		{
			string sql = "INSERT INTO HC_guideMaster ( Id, GuideTitle, GuideImage, createdby, createddate, updateby, updatedate, isactive) VALUES (  @Id,  @Guidetitle,  @Guideimage,  @Createdby,  @Createddate,  @Updateby,  @Updatedate,  @Isactive )";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);

			db.AddInParameter(dbCommand, "Id", DbType.String, hcGuidemasterEntity.Id);
			db.AddInParameter(dbCommand, "Guidetitle", DbType.String, hcGuidemasterEntity.Guidetitle);
			db.AddInParameter(dbCommand, "Guideimage", DbType.String, hcGuidemasterEntity.Guideimage);
			db.AddInParameter(dbCommand, "Createdby", DbType.String, hcGuidemasterEntity.Createdby);
			db.AddInParameter(dbCommand, "Createddate", DbType.String, hcGuidemasterEntity.Createddate);
			db.AddInParameter(dbCommand, "Updateby", DbType.String, hcGuidemasterEntity.Updateby);
			db.AddInParameter(dbCommand, "Updatedate", DbType.String, hcGuidemasterEntity.Updatedate);
			db.AddInParameter(dbCommand, "Isactive", DbType.String, hcGuidemasterEntity.Isactive);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;		}

		public bool UpdateHcGuidemasterInfo(HcGuidemasterEntity hcGuidemasterEntity, Database db, DbTransaction transaction)
		{
			string sql = "UPDATE HC_guideMaster SET GuideTitle= @Guidetitle, GuideImage= @Guideimage, createdby= @Createdby, createddate= @Createddate, updateby= @Updateby, updatedate= @Updatedate, isactive= @Isactive WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id",DbType.String, hcGuidemasterEntity.Id);
			db.AddInParameter(dbCommand, "Guidetitle", DbType.String, hcGuidemasterEntity.Guidetitle);
			db.AddInParameter(dbCommand, "Guideimage", DbType.String, hcGuidemasterEntity.Guideimage);
			db.AddInParameter(dbCommand, "Createdby", DbType.String, hcGuidemasterEntity.Createdby);
			db.AddInParameter(dbCommand, "Createddate", DbType.String, hcGuidemasterEntity.Createddate);
			db.AddInParameter(dbCommand, "Updateby", DbType.String, hcGuidemasterEntity.Updateby);
			db.AddInParameter(dbCommand, "Updatedate", DbType.String, hcGuidemasterEntity.Updatedate);
			db.AddInParameter(dbCommand, "Isactive", DbType.String, hcGuidemasterEntity.Isactive);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public bool DeleteHcGuidemasterInfoById(object param, Database db, DbTransaction transaction)
		{
			string sql = "DELETE FROM HC_guideMaster WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public HcGuidemasterEntity GetSingleHcGuidemasterRecordById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sql = "SELECT Id, GuideTitle, GuideImage, createdby, createddate, updateby, updatedate, isactive FROM HC_guideMaster WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);
			HcGuidemasterEntity hcGuidemasterEntity = null;
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
			{
				if (dataReader.Read())
				{
					hcGuidemasterEntity = new HcGuidemasterEntity();
					if (dataReader["Id"] != DBNull.Value)
					{
						hcGuidemasterEntity.Id = dataReader["Id"].ToString();
					}
					if (dataReader["GuideTitle"] != DBNull.Value)
					{
						hcGuidemasterEntity.Guidetitle = dataReader["GuideTitle"].ToString();
					}
					if (dataReader["GuideImage"] != DBNull.Value)
					{
						hcGuidemasterEntity.Guideimage = dataReader["GuideImage"].ToString();
					}
					if (dataReader["createdby"] != DBNull.Value)
					{
						hcGuidemasterEntity.Createdby = dataReader["createdby"].ToString();
					}
					if (dataReader["createddate"] != DBNull.Value)
					{
						hcGuidemasterEntity.Createddate = dataReader["createddate"].ToString();
					}
					if (dataReader["updateby"] != DBNull.Value)
					{
						hcGuidemasterEntity.Updateby = dataReader["updateby"].ToString();
					}
					if (dataReader["updatedate"] != DBNull.Value)
					{
						hcGuidemasterEntity.Updatedate = dataReader["updatedate"].ToString();
					}
					if (dataReader["isactive"] != DBNull.Value)
					{
						hcGuidemasterEntity.Isactive = dataReader["isactive"].ToString();
					}
				}
			}
			return hcGuidemasterEntity;
		}

		#endregion

	}
}

