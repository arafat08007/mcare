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
	public partial class HcServicesDAL
	{
		#region Auto Generated 

		public object SaveHcServicesInfo(HcServicesEntity hcServicesEntity, Database db, DbTransaction transaction)
		{
            string sql = "select Isnull(MAX(SortBy),0)+1 from HC_Services";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
            if (string.IsNullOrEmpty(hcServicesEntity.Sortby)) 
                hcServicesEntity.Sortby = db.ExecuteScalar(dbCommand, transaction).ToString();

            sql = "INSERT INTO HC_Services ( Name, Description, Icon, Type, IsActive, CreatedBy, CreatedTime, SortBy, IsView, ViewBy, ViewTime ) output inserted.ID VALUES (  @Name,  @Description,  @Icon,  @Type,  @Isactive,  @Createdby,  @Createdtime,  @Sortby,  @Isview,  @Viewby,  @Viewtime )";
			dbCommand = db.GetSqlStringCommand(sql);

			db.AddInParameter(dbCommand, "Name", DbType.String, hcServicesEntity.Name);
			db.AddInParameter(dbCommand, "Description", DbType.String, hcServicesEntity.Description);
			db.AddInParameter(dbCommand, "Icon", DbType.String, hcServicesEntity.Icon);
            db.AddInParameter(dbCommand, "Type", DbType.String, hcServicesEntity.Type);
			db.AddInParameter(dbCommand, "Isactive", DbType.String, hcServicesEntity.Isactive);
			db.AddInParameter(dbCommand, "Createdby", DbType.String, hcServicesEntity.Createdby);
			db.AddInParameter(dbCommand, "Createdtime", DbType.String, hcServicesEntity.Createdtime);
            db.AddInParameter(dbCommand, "SortBy", DbType.String, hcServicesEntity.Sortby);
			db.AddInParameter(dbCommand, "Isview", DbType.String, hcServicesEntity.Isview);
			db.AddInParameter(dbCommand, "Viewby", DbType.String, hcServicesEntity.Viewby);
			db.AddInParameter(dbCommand, "Viewtime", DbType.String, hcServicesEntity.Viewtime);

            var id = db.ExecuteScalar(dbCommand, transaction).ToString();
            return id;
        }

		public bool UpdateHcServicesInfo(HcServicesEntity hcServicesEntity, Database db, DbTransaction transaction)
		{
            string sql = "UPDATE HC_Services SET Name= @Name, Description= @Description, Icon= @Icon, Type= @Type, IsActive= @Isactive, UpdatedBy= @Updatedby, UpdatedTime= @Updatedtime, SortBy= @Sortby, IsView= @Isview, ViewBy= @Viewby, ViewTime= @Viewtime WHERE Id=@Id";

            if (hcServicesEntity.QueryFlag == "EmptyView")
                sql = "UPDATE HC_Services SET IsView= @Isview, ViewBy= @Viewby, ViewTime= @Viewtime";
            if (hcServicesEntity.QueryFlag == "SetView")
                sql = "UPDATE HC_Services SET IsView= 'checked', ViewBy= @Viewby, ViewTime= @Viewtime WHERE Id=@Id";

			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id",DbType.String, hcServicesEntity.Id);
			db.AddInParameter(dbCommand, "Name", DbType.String, hcServicesEntity.Name);
			db.AddInParameter(dbCommand, "Description", DbType.String, hcServicesEntity.Description);
			db.AddInParameter(dbCommand, "Icon", DbType.String, hcServicesEntity.Icon);
            db.AddInParameter(dbCommand, "Type", DbType.String, hcServicesEntity.Type);
			db.AddInParameter(dbCommand, "Isactive", DbType.String, hcServicesEntity.Isactive);
			db.AddInParameter(dbCommand, "Updatedby", DbType.String, hcServicesEntity.Updatedby);
			db.AddInParameter(dbCommand, "Updatedtime", DbType.String, hcServicesEntity.Updatedtime);
            db.AddInParameter(dbCommand, "SortBy", DbType.String, hcServicesEntity.Sortby);
			db.AddInParameter(dbCommand, "Isview", DbType.String, hcServicesEntity.Isview);
			db.AddInParameter(dbCommand, "Viewby", DbType.String, hcServicesEntity.Viewby);
			db.AddInParameter(dbCommand, "Viewtime", DbType.String, hcServicesEntity.Viewtime);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public bool DeleteHcServicesInfoById(object param, Database db, DbTransaction transaction)
		{
			string sql = "DELETE FROM HC_Services WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public HcServicesEntity GetSingleHcServicesRecordById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
            string sql = "SELECT ID, Name, Description, Icon, Type, IsActive, CreatedBy, CreatedTime, UpdatedBy, UpdatedTime, SortBy, IsView, ViewBy, ViewTime FROM HC_Services WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);
			HcServicesEntity hcServicesEntity = null;
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
			{
				if (dataReader.Read())
				{
					hcServicesEntity = new HcServicesEntity();
					if (dataReader["ID"] != DBNull.Value)
					{
						hcServicesEntity.Id = dataReader["ID"].ToString();
					}
					if (dataReader["Name"] != DBNull.Value)
					{
						hcServicesEntity.Name = dataReader["Name"].ToString();
					}
					if (dataReader["Description"] != DBNull.Value)
					{
						hcServicesEntity.Description = dataReader["Description"].ToString();
					}
					if (dataReader["Icon"] != DBNull.Value)
					{
						hcServicesEntity.Icon = dataReader["Icon"].ToString();
					}
                    if (dataReader["Type"] != DBNull.Value)
					{
                        hcServicesEntity.Type = dataReader["Type"].ToString();
					}
					if (dataReader["IsActive"] != DBNull.Value)
					{
						hcServicesEntity.Isactive = dataReader["IsActive"].ToString();
					}
					if (dataReader["CreatedBy"] != DBNull.Value)
					{
						hcServicesEntity.Createdby = dataReader["CreatedBy"].ToString();
					}
					if (dataReader["CreatedTime"] != DBNull.Value)
					{
						hcServicesEntity.Createdtime = dataReader["CreatedTime"].ToString();
					}
					if (dataReader["UpdatedBy"] != DBNull.Value)
					{
						hcServicesEntity.Updatedby = dataReader["UpdatedBy"].ToString();
					}
					if (dataReader["UpdatedTime"] != DBNull.Value)
					{
						hcServicesEntity.Updatedtime = dataReader["UpdatedTime"].ToString();
					}
                    if (dataReader["SortBy"] != DBNull.Value)
					{
                        hcServicesEntity.Sortby = dataReader["SortBy"].ToString();
					}
					if (dataReader["IsView"] != DBNull.Value)
					{
						hcServicesEntity.Isview = dataReader["IsView"].ToString();
					}
					if (dataReader["ViewBy"] != DBNull.Value)
					{
						hcServicesEntity.Viewby = dataReader["ViewBy"].ToString();
					}
					if (dataReader["ViewTime"] != DBNull.Value)
					{
						hcServicesEntity.Viewtime = dataReader["ViewTime"].ToString();
					}
				}
			}
			return hcServicesEntity;
		}

		#endregion

	}
}

