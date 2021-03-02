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
	public partial class HcDoctorDepartmentsDAL
	{
		#region Auto Generated 

		public object SaveHcDoctorDepartmentsInfo(HcDoctorDepartmentsEntity hcDoctorDepartmentsEntity, Database db, DbTransaction transaction)
		{
            string sql = "INSERT INTO HC_Doctor_Departments ( Name, About, IsActive, CreatedBy, CreatedTime ) output inserted.ID VALUES (  @Name,  @About,  @Isactive,  @Createdby,  @Createdtime )";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);

			db.AddInParameter(dbCommand, "Name", DbType.String, hcDoctorDepartmentsEntity.Name);
			db.AddInParameter(dbCommand, "About", DbType.String, hcDoctorDepartmentsEntity.About);
			db.AddInParameter(dbCommand, "Isactive", DbType.String, hcDoctorDepartmentsEntity.Isactive);
			db.AddInParameter(dbCommand, "Createdby", DbType.String, hcDoctorDepartmentsEntity.Createdby);
			db.AddInParameter(dbCommand, "Createdtime", DbType.String, hcDoctorDepartmentsEntity.Createdtime);

            var id = db.ExecuteScalar(dbCommand, transaction).ToString();
            return id;
        }

		public bool UpdateHcDoctorDepartmentsInfo(HcDoctorDepartmentsEntity hcDoctorDepartmentsEntity, Database db, DbTransaction transaction)
		{
			string sql = "UPDATE HC_Doctor_Departments SET Name= @Name, About= @About, IsActive= @Isactive, UpdatedBy= @Updatedby, UpdatedTime= @Updatedtime WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id",DbType.String, hcDoctorDepartmentsEntity.Id);
			db.AddInParameter(dbCommand, "Name", DbType.String, hcDoctorDepartmentsEntity.Name);
			db.AddInParameter(dbCommand, "About", DbType.String, hcDoctorDepartmentsEntity.About);
			db.AddInParameter(dbCommand, "Isactive", DbType.String, hcDoctorDepartmentsEntity.Isactive);
			db.AddInParameter(dbCommand, "Updatedby", DbType.String, hcDoctorDepartmentsEntity.Updatedby);
			db.AddInParameter(dbCommand, "Updatedtime", DbType.String, hcDoctorDepartmentsEntity.Updatedtime);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public bool DeleteHcDoctorDepartmentsInfoById(object param, Database db, DbTransaction transaction)
		{
			string sql = "DELETE FROM HC_Doctor_Departments WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public HcDoctorDepartmentsEntity GetSingleHcDoctorDepartmentsRecordById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sql = "SELECT ID, Name, About, IsActive, CreatedBy, CreatedTime, UpdatedBy, UpdatedTime FROM HC_Doctor_Departments WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);
			HcDoctorDepartmentsEntity hcDoctorDepartmentsEntity = null;
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
			{
				if (dataReader.Read())
				{
					hcDoctorDepartmentsEntity = new HcDoctorDepartmentsEntity();
					if (dataReader["ID"] != DBNull.Value)
					{
						hcDoctorDepartmentsEntity.Id = dataReader["ID"].ToString();
					}
					if (dataReader["Name"] != DBNull.Value)
					{
						hcDoctorDepartmentsEntity.Name = dataReader["Name"].ToString();
					}
					if (dataReader["About"] != DBNull.Value)
					{
						hcDoctorDepartmentsEntity.About = dataReader["About"].ToString();
					}
					if (dataReader["IsActive"] != DBNull.Value)
					{
						hcDoctorDepartmentsEntity.Isactive = dataReader["IsActive"].ToString();
					}
					if (dataReader["CreatedBy"] != DBNull.Value)
					{
						hcDoctorDepartmentsEntity.Createdby = dataReader["CreatedBy"].ToString();
					}
					if (dataReader["CreatedTime"] != DBNull.Value)
					{
						hcDoctorDepartmentsEntity.Createdtime = dataReader["CreatedTime"].ToString();
					}
					if (dataReader["UpdatedBy"] != DBNull.Value)
					{
						hcDoctorDepartmentsEntity.Updatedby = dataReader["UpdatedBy"].ToString();
					}
					if (dataReader["UpdatedTime"] != DBNull.Value)
					{
						hcDoctorDepartmentsEntity.Updatedtime = dataReader["UpdatedTime"].ToString();
					}
				}
			}
			return hcDoctorDepartmentsEntity;
		}

		#endregion

	}
}

