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
	public partial class AdmRoledetailsDAL
	{
		#region Auto Generated 

		public bool SaveAdmRoledetailsInfo(AdmRoledetailsEntity admRoledetailsEntity, Database db, DbTransaction transaction)
		{
			string sql = "INSERT INTO Adm_RoleDetails ( RoleId, FeatureId, IsView, IsAdd, IsEdit, IsDelete) VALUES (  @Roleid,  @Featureid,  @Isview,  @Isadd,  @Isedit,  @Isdelete )";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);

			db.AddInParameter(dbCommand, "Roleid", DbType.String, admRoledetailsEntity.Roleid);
			db.AddInParameter(dbCommand, "Featureid", DbType.String, admRoledetailsEntity.Featureid);
			db.AddInParameter(dbCommand, "Isview", DbType.String, admRoledetailsEntity.Isview);
			db.AddInParameter(dbCommand, "Isadd", DbType.String, admRoledetailsEntity.Isadd);
			db.AddInParameter(dbCommand, "Isedit", DbType.String, admRoledetailsEntity.Isedit);
			db.AddInParameter(dbCommand, "Isdelete", DbType.String, admRoledetailsEntity.Isdelete);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;		}

		public bool UpdateAdmRoledetailsInfo(AdmRoledetailsEntity admRoledetailsEntity, Database db, DbTransaction transaction)
		{
			string sql = "UPDATE Adm_RoleDetails SET RoleId= @Roleid, FeatureId= @Featureid, IsView= @Isview, IsAdd= @Isadd, IsEdit= @Isedit, IsDelete= @Isdelete WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id",DbType.String, admRoledetailsEntity.Id);
			db.AddInParameter(dbCommand, "Roleid", DbType.String, admRoledetailsEntity.Roleid);
			db.AddInParameter(dbCommand, "Featureid", DbType.String, admRoledetailsEntity.Featureid);
			db.AddInParameter(dbCommand, "Isview", DbType.String, admRoledetailsEntity.Isview);
			db.AddInParameter(dbCommand, "Isadd", DbType.String, admRoledetailsEntity.Isadd);
			db.AddInParameter(dbCommand, "Isedit", DbType.String, admRoledetailsEntity.Isedit);
			db.AddInParameter(dbCommand, "Isdelete", DbType.String, admRoledetailsEntity.Isdelete);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public bool DeleteAdmRoledetailsInfoById(object param, Database db, DbTransaction transaction)
		{
			string sql = "DELETE FROM Adm_RoleDetails WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public AdmRoledetailsEntity GetSingleAdmRoledetailsRecordById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sql = "SELECT ID, RoleId, FeatureId, IsView, IsAdd, IsEdit, IsDelete FROM Adm_RoleDetails WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);
			AdmRoledetailsEntity admRoledetailsEntity = null;
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
			{
				if (dataReader.Read())
				{
					admRoledetailsEntity = new AdmRoledetailsEntity();
					if (dataReader["ID"] != DBNull.Value)
					{
						admRoledetailsEntity.Id = dataReader["ID"].ToString();
					}
					if (dataReader["RoleId"] != DBNull.Value)
					{
						admRoledetailsEntity.Roleid = dataReader["RoleId"].ToString();
					}
					if (dataReader["FeatureId"] != DBNull.Value)
					{
						admRoledetailsEntity.Featureid = dataReader["FeatureId"].ToString();
					}
					if (dataReader["IsView"] != DBNull.Value)
					{
						admRoledetailsEntity.Isview = dataReader["IsView"].ToString();
					}
					if (dataReader["IsAdd"] != DBNull.Value)
					{
						admRoledetailsEntity.Isadd = dataReader["IsAdd"].ToString();
					}
					if (dataReader["IsEdit"] != DBNull.Value)
					{
						admRoledetailsEntity.Isedit = dataReader["IsEdit"].ToString();
					}
					if (dataReader["IsDelete"] != DBNull.Value)
					{
						admRoledetailsEntity.Isdelete = dataReader["IsDelete"].ToString();
					}
				}
			}
			return admRoledetailsEntity;
		}

		#endregion

	}
}

