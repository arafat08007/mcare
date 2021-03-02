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
	public partial class HcDoctorTimesDAL
	{
		#region Auto Generated 

		public object SaveHcDoctorTimesInfo(HcDoctorTimesEntity hcDoctorTimesEntity, Database db, DbTransaction transaction)
		{
            string sql = "INSERT INTO HC_Doctor_Times ( DoctorID, Days, Times, IsActive, CreatedBy, CreatedTime ) output inserted.ID VALUES (  @Doctorid,  @Days,  @Times,  @Isactive,  @Createdby,  @Createdtime )";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);

			db.AddInParameter(dbCommand, "Doctorid", DbType.String, hcDoctorTimesEntity.Doctorid);
			db.AddInParameter(dbCommand, "Days", DbType.String, hcDoctorTimesEntity.Days);
			db.AddInParameter(dbCommand, "Times", DbType.String, hcDoctorTimesEntity.Times);
			db.AddInParameter(dbCommand, "Isactive", DbType.String, hcDoctorTimesEntity.Isactive);
			db.AddInParameter(dbCommand, "Createdby", DbType.String, hcDoctorTimesEntity.Createdby);
			db.AddInParameter(dbCommand, "Createdtime", DbType.String, hcDoctorTimesEntity.Createdtime);

            var id = db.ExecuteScalar(dbCommand, transaction).ToString();
            return id;
        }

		public bool UpdateHcDoctorTimesInfo(HcDoctorTimesEntity hcDoctorTimesEntity, Database db, DbTransaction transaction)
		{
			string sql = "UPDATE HC_Doctor_Times SET DoctorID= @Doctorid, Days= @Days, Times= @Times, IsActive= @Isactive, UpdatedBy= @Updatedby, UpdatedTime= @Updatedtime WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id",DbType.String, hcDoctorTimesEntity.Id);
			db.AddInParameter(dbCommand, "Doctorid", DbType.String, hcDoctorTimesEntity.Doctorid);
			db.AddInParameter(dbCommand, "Days", DbType.String, hcDoctorTimesEntity.Days);
			db.AddInParameter(dbCommand, "Times", DbType.String, hcDoctorTimesEntity.Times);
			db.AddInParameter(dbCommand, "Isactive", DbType.String, hcDoctorTimesEntity.Isactive);
			db.AddInParameter(dbCommand, "Updatedby", DbType.String, hcDoctorTimesEntity.Updatedby);
			db.AddInParameter(dbCommand, "Updatedtime", DbType.String, hcDoctorTimesEntity.Updatedtime);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public bool DeleteHcDoctorTimesInfoById(object param, Database db, DbTransaction transaction)
		{
			string sql = "DELETE FROM HC_Doctor_Times WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public HcDoctorTimesEntity GetSingleHcDoctorTimesRecordById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sql = "SELECT ID, DoctorID, Days, Times, IsActive, CreatedBy, CreatedTime, UpdatedBy, UpdatedTime FROM HC_Doctor_Times WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);
			HcDoctorTimesEntity hcDoctorTimesEntity = null;
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
			{
				if (dataReader.Read())
				{
					hcDoctorTimesEntity = new HcDoctorTimesEntity();
					if (dataReader["ID"] != DBNull.Value)
					{
						hcDoctorTimesEntity.Id = dataReader["ID"].ToString();
					}
					if (dataReader["DoctorID"] != DBNull.Value)
					{
						hcDoctorTimesEntity.Doctorid = dataReader["DoctorID"].ToString();
					}
					if (dataReader["Days"] != DBNull.Value)
					{
						hcDoctorTimesEntity.Days = dataReader["Days"].ToString();
					}
					if (dataReader["Times"] != DBNull.Value)
					{
						hcDoctorTimesEntity.Times = dataReader["Times"].ToString();
					}
					if (dataReader["IsActive"] != DBNull.Value)
					{
						hcDoctorTimesEntity.Isactive = dataReader["IsActive"].ToString();
					}
					if (dataReader["CreatedBy"] != DBNull.Value)
					{
						hcDoctorTimesEntity.Createdby = dataReader["CreatedBy"].ToString();
					}
					if (dataReader["CreatedTime"] != DBNull.Value)
					{
						hcDoctorTimesEntity.Createdtime = dataReader["CreatedTime"].ToString();
					}
					if (dataReader["UpdatedBy"] != DBNull.Value)
					{
						hcDoctorTimesEntity.Updatedby = dataReader["UpdatedBy"].ToString();
					}
					if (dataReader["UpdatedTime"] != DBNull.Value)
					{
						hcDoctorTimesEntity.Updatedtime = dataReader["UpdatedTime"].ToString();
					}
				}
			}
			return hcDoctorTimesEntity;
		}

		#endregion

	}
}

