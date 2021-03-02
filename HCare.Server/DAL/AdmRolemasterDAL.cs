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
	public partial class AdmRolemasterDAL
	{
		#region Auto Generated 

		public object SaveAdmRolemasterInfo(AdmRolemasterEntity admRolemasterEntity, Database db, DbTransaction transaction)
		{
            string sql = "INSERT INTO Adm_RoleMaster ( RoleName, RoleDescription, DefaultBoard, AllDashboard, IsActive, CreatedBy, CreatedTime) output inserted.ID VALUES (  @Rolename,  @Roledescription,  @DefaultBoard,  @AllDashboard,  @Isactive,  @Createdby,  @Createdtime )";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);

			db.AddInParameter(dbCommand, "Rolename", DbType.String, admRolemasterEntity.Rolename);
            db.AddInParameter(dbCommand, "Roledescription", DbType.String, admRolemasterEntity.Roledescription);
            db.AddInParameter(dbCommand, "DefaultBoard", DbType.String, admRolemasterEntity.DefaultBoard);
            db.AddInParameter(dbCommand, "AllDashboard", DbType.String, admRolemasterEntity.AllDashboard);
            db.AddInParameter(dbCommand, "Isactive", DbType.String, admRolemasterEntity.Isactive);
			db.AddInParameter(dbCommand, "Createdby", DbType.String, admRolemasterEntity.Createdby);
			db.AddInParameter(dbCommand, "Createdtime", DbType.String, admRolemasterEntity.Createdtime);

            var id = db.ExecuteScalar(dbCommand, transaction).ToString();
            return id;
        }

		public bool UpdateAdmRolemasterInfo(AdmRolemasterEntity admRolemasterEntity, Database db, DbTransaction transaction)
		{
            string sql = "UPDATE Adm_RoleMaster SET RoleName= @Rolename, RoleDescription= @Roledescription, DefaultBoard= @DefaultBoard, AllDashboard= @AllDashboard, IsActive= @Isactive, UpdatedBy= @Updatedby, UpdatedTime= @Updatedtime WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id",DbType.String, admRolemasterEntity.Id);
			db.AddInParameter(dbCommand, "Rolename", DbType.String, admRolemasterEntity.Rolename);
            db.AddInParameter(dbCommand, "Roledescription", DbType.String, admRolemasterEntity.Roledescription);
            db.AddInParameter(dbCommand, "DefaultBoard", DbType.String, admRolemasterEntity.DefaultBoard);
            db.AddInParameter(dbCommand, "AllDashboard", DbType.String, admRolemasterEntity.AllDashboard);
			db.AddInParameter(dbCommand, "Isactive", DbType.String, admRolemasterEntity.Isactive);
			db.AddInParameter(dbCommand, "Updatedby", DbType.String, admRolemasterEntity.Updatedby);
			db.AddInParameter(dbCommand, "Updatedtime", DbType.String, admRolemasterEntity.Updatedtime);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public bool DeleteAdmRolemasterInfoById(object param, Database db, DbTransaction transaction)
		{
			string sql = "DELETE FROM Adm_RoleMaster WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public AdmRolemasterEntity GetSingleAdmRolemasterRecordById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
            string sql = "SELECT ID, RoleName, RoleDescription, DefaultBoard, AllDashboard, IsActive, CreatedBy, CreatedTime, UpdatedBy, UpdatedTime FROM Adm_RoleMaster WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);
			AdmRolemasterEntity admRolemasterEntity = null;
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
			{
				if (dataReader.Read())
				{
					admRolemasterEntity = new AdmRolemasterEntity();
					if (dataReader["ID"] != DBNull.Value)
					{
						admRolemasterEntity.Id = dataReader["ID"].ToString();
					}
					if (dataReader["RoleName"] != DBNull.Value)
					{
						admRolemasterEntity.Rolename = dataReader["RoleName"].ToString();
					}
					if (dataReader["RoleDescription"] != DBNull.Value)
					{
						admRolemasterEntity.Roledescription = dataReader["RoleDescription"].ToString();
					}
                    if (dataReader["DefaultBoard"] != DBNull.Value)
					{
                        admRolemasterEntity.DefaultBoard = dataReader["DefaultBoard"].ToString();
					}
                    if (dataReader["AllDashboard"] != DBNull.Value)
					{
                        admRolemasterEntity.AllDashboard = dataReader["AllDashboard"].ToString();
					}
					if (dataReader["IsActive"] != DBNull.Value)
					{
						admRolemasterEntity.Isactive = dataReader["IsActive"].ToString();
					}
					if (dataReader["CreatedBy"] != DBNull.Value)
					{
						admRolemasterEntity.Createdby = dataReader["CreatedBy"].ToString();
					}
					if (dataReader["CreatedTime"] != DBNull.Value)
					{
						admRolemasterEntity.Createdtime = dataReader["CreatedTime"].ToString();
					}
					if (dataReader["UpdatedBy"] != DBNull.Value)
					{
						admRolemasterEntity.Updatedby = dataReader["UpdatedBy"].ToString();
					}
					if (dataReader["UpdatedTime"] != DBNull.Value)
					{
						admRolemasterEntity.Updatedtime = dataReader["UpdatedTime"].ToString();
					}
				}
			}
			return admRolemasterEntity;
		}

		#endregion

	}
}

