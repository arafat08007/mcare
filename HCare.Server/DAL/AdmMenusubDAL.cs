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
	public partial class AdmMenusubDAL
	{
		#region Auto Generated 

		public object SaveAdmMenusubInfo(AdmMenusubEntity admMenusubEntity, Database db, DbTransaction transaction)
        {
            string sql = "SELECT isnull(MAX(SortBy),0)+1  FROM Adm_MenuSub ";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            if (string.IsNullOrEmpty(admMenusubEntity.Sortby))
                admMenusubEntity.Sortby = db.ExecuteScalar(dbCommand, transaction).ToString();

            sql = "INSERT INTO Adm_MenuSub ( MenuId, SortBy, SubIcon, SubName, SubUrl, IsActive, CreatedBy, CreatedTime ) output inserted.ID VALUES (  @Menuid,  @Sortby,  @Subicon,  @Subname,  @Suburl,  @Isactive,  @Createdby,  @Createdtime )";
			dbCommand = db.GetSqlStringCommand(sql);

			db.AddInParameter(dbCommand, "Menuid", DbType.String, admMenusubEntity.Menuid);
			db.AddInParameter(dbCommand, "Sortby", DbType.String, admMenusubEntity.Sortby);
			db.AddInParameter(dbCommand, "Subicon", DbType.String, admMenusubEntity.Subicon);
			db.AddInParameter(dbCommand, "Subname", DbType.String, admMenusubEntity.Subname);
			db.AddInParameter(dbCommand, "Suburl", DbType.String, admMenusubEntity.Suburl);
			db.AddInParameter(dbCommand, "Isactive", DbType.String, admMenusubEntity.Isactive);
			db.AddInParameter(dbCommand, "Createdby", DbType.String, admMenusubEntity.Createdby);
			db.AddInParameter(dbCommand, "Createdtime", DbType.String, admMenusubEntity.Createdtime);

            var id = db.ExecuteScalar(dbCommand, transaction).ToString();
            return id;
        }

		public bool UpdateAdmMenusubInfo(AdmMenusubEntity admMenusubEntity, Database db, DbTransaction transaction)
		{
			string sql = "UPDATE Adm_MenuSub SET MenuId= @Menuid, SortBy= @Sortby, SubIcon= @Subicon, SubName= @Subname, SubUrl= @Suburl, IsActive= @Isactive, UpdatedBy= @Updatedby, UpdatedTime= @Updatedtime WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id",DbType.String, admMenusubEntity.Id);
			db.AddInParameter(dbCommand, "Menuid", DbType.String, admMenusubEntity.Menuid);
			db.AddInParameter(dbCommand, "Sortby", DbType.String, admMenusubEntity.Sortby);
			db.AddInParameter(dbCommand, "Subicon", DbType.String, admMenusubEntity.Subicon);
			db.AddInParameter(dbCommand, "Subname", DbType.String, admMenusubEntity.Subname);
			db.AddInParameter(dbCommand, "Suburl", DbType.String, admMenusubEntity.Suburl);
			db.AddInParameter(dbCommand, "Isactive", DbType.String, admMenusubEntity.Isactive);
			db.AddInParameter(dbCommand, "Updatedby", DbType.String, admMenusubEntity.Updatedby);
			db.AddInParameter(dbCommand, "Updatedtime", DbType.String, admMenusubEntity.Updatedtime);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public bool DeleteAdmMenusubInfoById(object param, Database db, DbTransaction transaction)
		{
			string sql = "DELETE FROM Adm_MenuSub WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public AdmMenusubEntity GetSingleAdmMenusubRecordById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sql = "SELECT ID, MenuId, SortBy, SubIcon, SubName, SubUrl, IsActive, CreatedBy, CreatedTime, UpdatedBy, UpdatedTime FROM Adm_MenuSub WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);
			AdmMenusubEntity admMenusubEntity = null;
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
			{
				if (dataReader.Read())
				{
					admMenusubEntity = new AdmMenusubEntity();
					if (dataReader["ID"] != DBNull.Value)
					{
						admMenusubEntity.Id = dataReader["ID"].ToString();
					}
					if (dataReader["MenuId"] != DBNull.Value)
					{
						admMenusubEntity.Menuid = dataReader["MenuId"].ToString();
					}
					if (dataReader["SortBy"] != DBNull.Value)
					{
						admMenusubEntity.Sortby = dataReader["SortBy"].ToString();
					}
					if (dataReader["SubIcon"] != DBNull.Value)
					{
						admMenusubEntity.Subicon = dataReader["SubIcon"].ToString();
					}
					if (dataReader["SubName"] != DBNull.Value)
					{
						admMenusubEntity.Subname = dataReader["SubName"].ToString();
					}
					if (dataReader["SubUrl"] != DBNull.Value)
					{
						admMenusubEntity.Suburl = dataReader["SubUrl"].ToString();
					}
					if (dataReader["IsActive"] != DBNull.Value)
					{
						admMenusubEntity.Isactive = dataReader["IsActive"].ToString();
					}
					if (dataReader["CreatedBy"] != DBNull.Value)
					{
						admMenusubEntity.Createdby = dataReader["CreatedBy"].ToString();
					}
					if (dataReader["CreatedTime"] != DBNull.Value)
					{
						admMenusubEntity.Createdtime = dataReader["CreatedTime"].ToString();
					}
					if (dataReader["UpdatedBy"] != DBNull.Value)
					{
						admMenusubEntity.Updatedby = dataReader["UpdatedBy"].ToString();
					}
					if (dataReader["UpdatedTime"] != DBNull.Value)
					{
						admMenusubEntity.Updatedtime = dataReader["UpdatedTime"].ToString();
					}
				}
			}
			return admMenusubEntity;
		}

		#endregion

	}
}

