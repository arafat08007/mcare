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
	public partial class AdmMenuDAL
	{
		#region Auto Generated 

		public object SaveAdmMenuInfo(AdmMenuEntity admMenuEntity, Database db, DbTransaction transaction)
		{
            string sql = "SELECT isnull(MAX(SortBy),0)+1  FROM Adm_Menu ";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            if (string.IsNullOrEmpty(admMenuEntity.Sortby))
                admMenuEntity.Sortby = db.ExecuteScalar(dbCommand, transaction).ToString();

            sql = "INSERT INTO Adm_Menu ( SortBy, MenuIcon, MenuName, MenuUrl, IsActive, CreatedBy, CreatedTime) output inserted.ID VALUES (  @Sortby,  @Menuicon,  @Menuname,  @Menuurl,  @Isactive,  @Createdby,  @Createdtime )";
			dbCommand = db.GetSqlStringCommand(sql);

			db.AddInParameter(dbCommand, "Sortby", DbType.String, admMenuEntity.Sortby);
			db.AddInParameter(dbCommand, "Menuicon", DbType.String, admMenuEntity.Menuicon);
			db.AddInParameter(dbCommand, "Menuname", DbType.String, admMenuEntity.Menuname);
			db.AddInParameter(dbCommand, "Menuurl", DbType.String, admMenuEntity.Menuurl);
			db.AddInParameter(dbCommand, "Isactive", DbType.String, admMenuEntity.Isactive);
			db.AddInParameter(dbCommand, "Createdby", DbType.String, admMenuEntity.Createdby);
			db.AddInParameter(dbCommand, "Createdtime", DbType.String, admMenuEntity.Createdtime);

            var id = db.ExecuteScalar(dbCommand, transaction).ToString();
            return id;
        }

		public bool UpdateAdmMenuInfo(AdmMenuEntity admMenuEntity, Database db, DbTransaction transaction)
		{
			string sql = "UPDATE Adm_Menu SET SortBy= @Sortby, MenuIcon= @Menuicon, MenuName= @Menuname, MenuUrl= @Menuurl, IsActive= @Isactive, UpdatedBy= @Updatedby, UpdatedTime= @Updatedtime WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id",DbType.String, admMenuEntity.Id);
			db.AddInParameter(dbCommand, "Sortby", DbType.String, admMenuEntity.Sortby);
			db.AddInParameter(dbCommand, "Menuicon", DbType.String, admMenuEntity.Menuicon);
			db.AddInParameter(dbCommand, "Menuname", DbType.String, admMenuEntity.Menuname);
			db.AddInParameter(dbCommand, "Menuurl", DbType.String, admMenuEntity.Menuurl);
			db.AddInParameter(dbCommand, "Isactive", DbType.String, admMenuEntity.Isactive);
			db.AddInParameter(dbCommand, "Updatedby", DbType.String, admMenuEntity.Updatedby);
			db.AddInParameter(dbCommand, "Updatedtime", DbType.String, admMenuEntity.Updatedtime);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public bool DeleteAdmMenuInfoById(object param, Database db, DbTransaction transaction)
		{
			string sql = "DELETE FROM Adm_Menu WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public AdmMenuEntity GetSingleAdmMenuRecordById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sql = "SELECT ID, SortBy, MenuIcon, MenuName, MenuUrl, IsActive, CreatedBy, CreatedTime, UpdatedBy, UpdatedTime FROM Adm_Menu WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);
			AdmMenuEntity admMenuEntity = null;
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
			{
				if (dataReader.Read())
				{
					admMenuEntity = new AdmMenuEntity();
					if (dataReader["ID"] != DBNull.Value)
					{
						admMenuEntity.Id = dataReader["ID"].ToString();
					}
					if (dataReader["SortBy"] != DBNull.Value)
					{
						admMenuEntity.Sortby = dataReader["SortBy"].ToString();
					}
					if (dataReader["MenuIcon"] != DBNull.Value)
					{
						admMenuEntity.Menuicon = dataReader["MenuIcon"].ToString();
					}
					if (dataReader["MenuName"] != DBNull.Value)
					{
						admMenuEntity.Menuname = dataReader["MenuName"].ToString();
					}
					if (dataReader["MenuUrl"] != DBNull.Value)
					{
						admMenuEntity.Menuurl = dataReader["MenuUrl"].ToString();
					}
					if (dataReader["IsActive"] != DBNull.Value)
					{
						admMenuEntity.Isactive = dataReader["IsActive"].ToString();
					}
					if (dataReader["CreatedBy"] != DBNull.Value)
					{
						admMenuEntity.Createdby = dataReader["CreatedBy"].ToString();
					}
					if (dataReader["CreatedTime"] != DBNull.Value)
					{
						admMenuEntity.Createdtime = dataReader["CreatedTime"].ToString();
					}
					if (dataReader["UpdatedBy"] != DBNull.Value)
					{
						admMenuEntity.Updatedby = dataReader["UpdatedBy"].ToString();
					}
					if (dataReader["UpdatedTime"] != DBNull.Value)
					{
						admMenuEntity.Updatedtime = dataReader["UpdatedTime"].ToString();
					}
				}
			}
			return admMenuEntity;
		}

		#endregion

	}
}

