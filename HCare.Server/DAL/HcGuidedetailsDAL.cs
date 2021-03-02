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
	public partial class HcGuidedetailsDAL
	{
		#region Auto Generated 

		public bool SaveHcGuidedetailsInfo(HcGuidedetailsEntity hcGuidedetailsEntity, Database db, DbTransaction transaction)
		{
			string sql = "INSERT INTO HC_GuideDetails ( id, refid, Chapter, ChapterDetails) VALUES (  @Id,  @Refid,  @Chapter,  @Chapterdetails )";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);

			db.AddInParameter(dbCommand, "Id", DbType.String, hcGuidedetailsEntity.Id);
			db.AddInParameter(dbCommand, "Refid", DbType.String, hcGuidedetailsEntity.Refid);
			db.AddInParameter(dbCommand, "Chapter", DbType.String, hcGuidedetailsEntity.Chapter);
			db.AddInParameter(dbCommand, "Chapterdetails", DbType.String, hcGuidedetailsEntity.Chapterdetails);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;		}

		public bool UpdateHcGuidedetailsInfo(HcGuidedetailsEntity hcGuidedetailsEntity, Database db, DbTransaction transaction)
		{
			string sql = "UPDATE HC_GuideDetails SET refid= @Refid, Chapter= @Chapter, ChapterDetails= @Chapterdetails WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id",DbType.String, hcGuidedetailsEntity.Id);
			db.AddInParameter(dbCommand, "Refid", DbType.String, hcGuidedetailsEntity.Refid);
			db.AddInParameter(dbCommand, "Chapter", DbType.String, hcGuidedetailsEntity.Chapter);
			db.AddInParameter(dbCommand, "Chapterdetails", DbType.String, hcGuidedetailsEntity.Chapterdetails);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public bool DeleteHcGuidedetailsInfoById(object param, Database db, DbTransaction transaction)
		{
			string sql = "DELETE FROM HC_GuideDetails WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public HcGuidedetailsEntity GetSingleHcGuidedetailsRecordById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sql = "SELECT id, refid, Chapter, ChapterDetails FROM HC_GuideDetails WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);
			HcGuidedetailsEntity hcGuidedetailsEntity = null;
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
			{
				if (dataReader.Read())
				{
					hcGuidedetailsEntity = new HcGuidedetailsEntity();
					if (dataReader["id"] != DBNull.Value)
					{
						hcGuidedetailsEntity.Id = dataReader["id"].ToString();
					}
					if (dataReader["refid"] != DBNull.Value)
					{
						hcGuidedetailsEntity.Refid = dataReader["refid"].ToString();
					}
					if (dataReader["Chapter"] != DBNull.Value)
					{
						hcGuidedetailsEntity.Chapter = dataReader["Chapter"].ToString();
					}
					if (dataReader["ChapterDetails"] != DBNull.Value)
					{
						hcGuidedetailsEntity.Chapterdetails = dataReader["ChapterDetails"].ToString();
					}
				}
			}
			return hcGuidedetailsEntity;
		}

		#endregion

	}
}

