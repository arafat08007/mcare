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
	public partial class HcBlogDAL
	{
		#region Auto Generated 

		public bool SaveHcBlogInfo(HcBlogEntity hcBlogEntity, Database db, DbTransaction transaction)
		{
			string sql = "INSERT INTO HC_Blog ( Id, BlogTitle, BlogDetail, isActive, BlogImage, BlogLink, CreatedBy, CreatedDate, UpdateBy, UpdateDate) VALUES (  @Id,  @Blogtitle,  @Blogdetail,  @Isactive,  @Blogimage,  @Bloglink,  @Createdby,  @Createddate,  @Updateby,  @Updatedate )";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);

			db.AddInParameter(dbCommand, "Id", DbType.String, hcBlogEntity.Id);
			db.AddInParameter(dbCommand, "Blogtitle", DbType.String, hcBlogEntity.Blogtitle);
			db.AddInParameter(dbCommand, "Blogdetail", DbType.String, hcBlogEntity.Blogdetail);
			db.AddInParameter(dbCommand, "Isactive", DbType.String, hcBlogEntity.Isactive);
			db.AddInParameter(dbCommand, "Blogimage", DbType.String, hcBlogEntity.Blogimage);
			db.AddInParameter(dbCommand, "Bloglink", DbType.String, hcBlogEntity.Bloglink);
			db.AddInParameter(dbCommand, "Createdby", DbType.String, hcBlogEntity.Createdby);
			db.AddInParameter(dbCommand, "Createddate", DbType.String, hcBlogEntity.Createddate);
			db.AddInParameter(dbCommand, "Updateby", DbType.String, hcBlogEntity.Updateby);
			db.AddInParameter(dbCommand, "Updatedate", DbType.String, hcBlogEntity.Updatedate);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;		}

		public bool UpdateHcBlogInfo(HcBlogEntity hcBlogEntity, Database db, DbTransaction transaction)
		{
			string sql = "UPDATE HC_Blog SET BlogTitle= @Blogtitle, BlogDetail= @Blogdetail, isActive= @Isactive, BlogImage= @Blogimage, BlogLink= @Bloglink, CreatedBy= @Createdby, CreatedDate= @Createddate, UpdateBy= @Updateby, UpdateDate= @Updatedate WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id",DbType.String, hcBlogEntity.Id);
			db.AddInParameter(dbCommand, "Blogtitle", DbType.String, hcBlogEntity.Blogtitle);
			db.AddInParameter(dbCommand, "Blogdetail", DbType.String, hcBlogEntity.Blogdetail);
			db.AddInParameter(dbCommand, "Isactive", DbType.String, hcBlogEntity.Isactive);
			db.AddInParameter(dbCommand, "Blogimage", DbType.String, hcBlogEntity.Blogimage);
			db.AddInParameter(dbCommand, "Bloglink", DbType.String, hcBlogEntity.Bloglink);
			db.AddInParameter(dbCommand, "Createdby", DbType.String, hcBlogEntity.Createdby);
			db.AddInParameter(dbCommand, "Createddate", DbType.String, hcBlogEntity.Createddate);
			db.AddInParameter(dbCommand, "Updateby", DbType.String, hcBlogEntity.Updateby);
			db.AddInParameter(dbCommand, "Updatedate", DbType.String, hcBlogEntity.Updatedate);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public bool DeleteHcBlogInfoById(object param, Database db, DbTransaction transaction)
		{
			string sql = "DELETE FROM HC_Blog WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public HcBlogEntity GetSingleHcBlogRecordById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sql = "SELECT Id, BlogTitle, BlogDetail, isActive, BlogImage, BlogLink, CreatedBy, CreatedDate, UpdateBy, UpdateDate FROM HC_Blog WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);
			HcBlogEntity hcBlogEntity = null;
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
			{
				if (dataReader.Read())
				{
					hcBlogEntity = new HcBlogEntity();
					if (dataReader["Id"] != DBNull.Value)
					{
						hcBlogEntity.Id = dataReader["Id"].ToString();
					}
					if (dataReader["BlogTitle"] != DBNull.Value)
					{
						hcBlogEntity.Blogtitle = dataReader["BlogTitle"].ToString();
					}
					if (dataReader["BlogDetail"] != DBNull.Value)
					{
						hcBlogEntity.Blogdetail = dataReader["BlogDetail"].ToString();
					}
					if (dataReader["isActive"] != DBNull.Value)
					{
						hcBlogEntity.Isactive = dataReader["isActive"].ToString();
					}
					if (dataReader["BlogImage"] != DBNull.Value)
					{
						hcBlogEntity.Blogimage = dataReader["BlogImage"].ToString();
					}
					if (dataReader["BlogLink"] != DBNull.Value)
					{
						hcBlogEntity.Bloglink = dataReader["BlogLink"].ToString();
					}
					if (dataReader["CreatedBy"] != DBNull.Value)
					{
						hcBlogEntity.Createdby = dataReader["CreatedBy"].ToString();
					}
					if (dataReader["CreatedDate"] != DBNull.Value)
					{
						hcBlogEntity.Createddate = dataReader["CreatedDate"].ToString();
					}
					if (dataReader["UpdateBy"] != DBNull.Value)
					{
						hcBlogEntity.Updateby = dataReader["UpdateBy"].ToString();
					}
					if (dataReader["UpdateDate"] != DBNull.Value)
					{
						hcBlogEntity.Updatedate = dataReader["UpdateDate"].ToString();
					}
				}
			}
			return hcBlogEntity;
		}

		#endregion

	}
}

