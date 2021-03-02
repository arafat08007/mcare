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
	public partial class HcEmergencycontactDAL
	{
		#region Auto Generated 

		public object SaveHcEmergencycontactInfo(HcEmergencycontactEntity hcEmergencycontactEntity, Database db, DbTransaction transaction)
		{
            string sql = @"INSERT INTO HC_EmergencyContact ( UserId, UserPhone,emergencyContactPerson, emergencycontactPhone, createdBy, createdAt, updateBy, upadateAt) output inserted.ID VALUES (  @Userid,  @Userphone, @Emergencycontactperson,  @Emergencycontactphone,  @Createdby,  @Createdat,  @Updateby,  @Upadateat )";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);

			db.AddInParameter(dbCommand, "Userid", DbType.String, hcEmergencycontactEntity.Userid);
            db.AddInParameter(dbCommand, "Userphone", DbType.String, hcEmergencycontactEntity.Userphone);
			db.AddInParameter(dbCommand, "Emergencycontactperson", DbType.String, hcEmergencycontactEntity.Emergencycontactperson);
			db.AddInParameter(dbCommand, "Emergencycontactphone", DbType.String, hcEmergencycontactEntity.Emergencycontactphone);
			db.AddInParameter(dbCommand, "Createdby", DbType.String, hcEmergencycontactEntity.Createdby);
			db.AddInParameter(dbCommand, "Createdat", DbType.String, hcEmergencycontactEntity.Createdat);
			db.AddInParameter(dbCommand, "Updateby", DbType.String, hcEmergencycontactEntity.Updateby);
			db.AddInParameter(dbCommand, "Upadateat", DbType.String, hcEmergencycontactEntity.Upadateat);
           

			//db.ExecuteNonQuery(dbCommand, transaction);
			//return true;	
            var id = db.ExecuteScalar(dbCommand, transaction).ToString();
            return id;
        }

		public bool UpdateHcEmergencycontactInfo(HcEmergencycontactEntity hcEmergencycontactEntity, Database db, DbTransaction transaction)
		{
			string sql = "UPDATE HC_EmergencyContact SET UserId= @Userid, emergencyContactPerson= @Emergencycontactperson, emergencycontactPhone= @Emergencycontactphone, createdBy= @Createdby, createdAt= @Createdat, updateBy= @Updateby, upadateAt= @Upadateat WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id",DbType.String, hcEmergencycontactEntity.Id);
			db.AddInParameter(dbCommand, "Userid", DbType.String, hcEmergencycontactEntity.Userid);
			db.AddInParameter(dbCommand, "Emergencycontactperson", DbType.String, hcEmergencycontactEntity.Emergencycontactperson);
			db.AddInParameter(dbCommand, "Emergencycontactphone", DbType.String, hcEmergencycontactEntity.Emergencycontactphone);
			db.AddInParameter(dbCommand, "Createdby", DbType.String, hcEmergencycontactEntity.Createdby);
			db.AddInParameter(dbCommand, "Createdat", DbType.String, hcEmergencycontactEntity.Createdat);
			db.AddInParameter(dbCommand, "Updateby", DbType.String, hcEmergencycontactEntity.Updateby);
			db.AddInParameter(dbCommand, "Upadateat", DbType.String, hcEmergencycontactEntity.Upadateat);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public bool DeleteHcEmergencycontactInfoById(object param, Database db, DbTransaction transaction)
		{
            string sql = @"DELETE FROM HC_EmergencyContact";

            HcEmergencycontactEntity iGet = new HcEmergencycontactEntity();
            if (param != null) iGet = (HcEmergencycontactEntity)param;

            if (!string.IsNullOrEmpty(iGet.Userid))
                sql += " WHERE UserId = '" + iGet.Userid + "' ";

			DbCommand dbCommand = db.GetSqlStringCommand(sql);
           // db.AddInParameter(dbCommand, "UserId", DbType.String, param);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public HcEmergencycontactEntity GetSingleHcEmergencycontactRecordById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sql = "SELECT ID, UserId, emergencyContactPerson, emergencycontactPhone, createdBy, createdAt, updateBy, upadateAt FROM HC_EmergencyContact WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);
			HcEmergencycontactEntity hcEmergencycontactEntity = null;
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
			{
				if (dataReader.Read())
				{
					hcEmergencycontactEntity = new HcEmergencycontactEntity();
					if (dataReader["ID"] != DBNull.Value)
					{
						hcEmergencycontactEntity.Id = dataReader["ID"].ToString();
					}
					if (dataReader["UserId"] != DBNull.Value)
					{
						hcEmergencycontactEntity.Userid = dataReader["UserId"].ToString();
					}
					if (dataReader["emergencyContactPerson"] != DBNull.Value)
					{
						hcEmergencycontactEntity.Emergencycontactperson = dataReader["emergencyContactPerson"].ToString();
					}
					if (dataReader["emergencycontactPhone"] != DBNull.Value)
					{
						hcEmergencycontactEntity.Emergencycontactphone = dataReader["emergencycontactPhone"].ToString();
					}
					if (dataReader["createdBy"] != DBNull.Value)
					{
						hcEmergencycontactEntity.Createdby = dataReader["createdBy"].ToString();
					}
					if (dataReader["createdAt"] != DBNull.Value)
					{
						hcEmergencycontactEntity.Createdat = dataReader["createdAt"].ToString();
					}
					if (dataReader["updateBy"] != DBNull.Value)
					{
						hcEmergencycontactEntity.Updateby = dataReader["updateBy"].ToString();
					}
					if (dataReader["upadateAt"] != DBNull.Value)
					{
						hcEmergencycontactEntity.Upadateat = dataReader["upadateAt"].ToString();
					}
				}
			}
			return hcEmergencycontactEntity;
		}

		#endregion

	}
}

