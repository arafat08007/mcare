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
	public partial class HcUsersDAL
	{
		#region Auto Generated 

		public object SaveHcUsersInfo(HcUsersEntity hcUsersEntity, Database db, DbTransaction transaction)
		{
            string sql = "INSERT INTO HC_Users ( LogName, LogPass, SecurPass, Email, FirstName, LastName, Gender, Address, UserType, UserID, RoleID, IsActive, CreatedBy, CreatedTime ) output inserted.ID VALUES (  @Logname,  @Logpass,  @SecurPass,  @Email,  @FirstName,  @LastName,  @Gender,  @Address,  @Usertype,  @Userid,  @Roleid,  @Isactive,  @Createdby,  @Createdtime )";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);

			db.AddInParameter(dbCommand, "Logname", DbType.String, hcUsersEntity.Logname);
			db.AddInParameter(dbCommand, "Logpass", DbType.String, hcUsersEntity.Logpass);
            db.AddInParameter(dbCommand, "SecurPass", DbType.String, hcUsersEntity.SecurPass);
            db.AddInParameter(dbCommand, "Email", DbType.String, hcUsersEntity.Email);
            db.AddInParameter(dbCommand, "FirstName", DbType.String, hcUsersEntity.FirstName);
            db.AddInParameter(dbCommand, "LastName", DbType.String, hcUsersEntity.LastName);
            db.AddInParameter(dbCommand, "Gender", DbType.String, hcUsersEntity.Gender);
            db.AddInParameter(dbCommand, "Address", DbType.String, hcUsersEntity.Address);
			db.AddInParameter(dbCommand, "Usertype", DbType.String, hcUsersEntity.Usertype);
			db.AddInParameter(dbCommand, "Userid", DbType.String, hcUsersEntity.Userid);
			db.AddInParameter(dbCommand, "Roleid", DbType.String, hcUsersEntity.Roleid);
			db.AddInParameter(dbCommand, "Isactive", DbType.String, hcUsersEntity.Isactive);
			db.AddInParameter(dbCommand, "Createdby", DbType.String, hcUsersEntity.Createdby);
			db.AddInParameter(dbCommand, "Createdtime", DbType.String, hcUsersEntity.Createdtime);

            var id = db.ExecuteScalar(dbCommand, transaction).ToString();
            return id;
        }

		public bool UpdateHcUsersInfo(HcUsersEntity hcUsersEntity, Database db, DbTransaction transaction)
		{
            string sql = "UPDATE HC_Users SET LogName= @Logname, LogPass= @Logpass, userImageUrl=@userImageUrl, SecurPass= @SecurPass, Email= @Email, FirstName= @FirstName, LastName= @LastName, Gender= @Gender, Address= @Address, UserType= @Usertype, UserID= @Userid, RoleID= @Roleid, IsActive= @Isactive, UpdatedBy= @Updatedby, UpdatedTime= @Updatedtime WHERE Id=@Id";
             
            if (hcUsersEntity.QueryFlag == "LastLogIn")
                sql = "UPDATE HC_Users SET LastLogIn= @Lastlogin WHERE Id=@Id";
            else if (hcUsersEntity.QueryFlag == "LogPass")
                sql = "UPDATE HC_Users SET LogPass= @Logpass WHERE Id=@Id";

			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id",DbType.String, hcUsersEntity.Id);
			db.AddInParameter(dbCommand, "Logname", DbType.String, hcUsersEntity.Logname);
            db.AddInParameter(dbCommand, "Logpass", DbType.String, hcUsersEntity.Logpass);
            db.AddInParameter(dbCommand, "SecurPass", DbType.String, hcUsersEntity.SecurPass);
            db.AddInParameter(dbCommand, "Email", DbType.String, hcUsersEntity.Email);
            db.AddInParameter(dbCommand, "FirstName", DbType.String, hcUsersEntity.FirstName);
            db.AddInParameter(dbCommand, "LastName", DbType.String, hcUsersEntity.LastName);
            db.AddInParameter(dbCommand, "Gender", DbType.String, hcUsersEntity.Gender);
            db.AddInParameter(dbCommand, "Address", DbType.String, hcUsersEntity.Address);
			db.AddInParameter(dbCommand, "Usertype", DbType.String, hcUsersEntity.Usertype);
			db.AddInParameter(dbCommand, "Userid", DbType.String, hcUsersEntity.Userid);
			db.AddInParameter(dbCommand, "Roleid", DbType.String, hcUsersEntity.Roleid);
			db.AddInParameter(dbCommand, "Isactive", DbType.String, hcUsersEntity.Isactive);
            db.AddInParameter(dbCommand, "Updatedby", DbType.String, hcUsersEntity.Updatedby);
            db.AddInParameter(dbCommand, "Updatedtime", DbType.String, hcUsersEntity.Updatedtime);
			db.AddInParameter(dbCommand, "Lastlogin", DbType.String, hcUsersEntity.Lastlogin);
            db.AddInParameter(dbCommand, "userImageUrl", DbType.String, hcUsersEntity.Lastlogin);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public bool DeleteHcUsersInfoById(object param, Database db, DbTransaction transaction)
		{
			string sql = "DELETE FROM HC_Users WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public HcUsersEntity GetSingleHcUsersRecordById(object param)
		{
            Database db = DatabaseFactory.CreateDatabase();
            string sql = "SELECT ID, LogName, LogPass, SecurPass, Email, FirstName, LastName, Gender, Address, UserType, UserID, RoleID, IsActive, CreatedBy, CreatedTime, UpdatedBy, UpdatedTime, LastLogIn FROM HC_Users WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);
			HcUsersEntity hcUsersEntity = null;
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
			{
				if (dataReader.Read())
				{
					hcUsersEntity = new HcUsersEntity();
					if (dataReader["ID"] != DBNull.Value)
					{
						hcUsersEntity.Id = dataReader["ID"].ToString();
					}
					if (dataReader["LogName"] != DBNull.Value)
					{
						hcUsersEntity.Logname = dataReader["LogName"].ToString();
					}
					if (dataReader["LogPass"] != DBNull.Value)
					{
						hcUsersEntity.Logpass = dataReader["LogPass"].ToString();
                    }
                    if (dataReader["SecurPass"] != DBNull.Value)
					{
                        hcUsersEntity.SecurPass = dataReader["SecurPass"].ToString();
					}
                    if (dataReader["Email"] != DBNull.Value)
					{
                        hcUsersEntity.Email = dataReader["Email"].ToString();
                    }
                    if (dataReader["FirstName"] != DBNull.Value)
					{
                        hcUsersEntity.FirstName = dataReader["FirstName"].ToString();
					}
                    if (dataReader["LastName"] != DBNull.Value)
					{
                        hcUsersEntity.LastName = dataReader["LastName"].ToString();
					}
                    if (dataReader["Gender"] != DBNull.Value)
					{
                        hcUsersEntity.Gender = dataReader["Gender"].ToString();
					}
                    if (dataReader["Address"] != DBNull.Value)
					{
                        hcUsersEntity.Address = dataReader["Address"].ToString();
					}
					if (dataReader["UserType"] != DBNull.Value)
					{
						hcUsersEntity.Usertype = dataReader["UserType"].ToString();
					}
					if (dataReader["UserID"] != DBNull.Value)
					{
						hcUsersEntity.Userid = dataReader["UserID"].ToString();
					}
					if (dataReader["RoleID"] != DBNull.Value)
					{
						hcUsersEntity.Roleid = dataReader["RoleID"].ToString();
					}
					if (dataReader["IsActive"] != DBNull.Value)
					{
						hcUsersEntity.Isactive = dataReader["IsActive"].ToString();
					}
					if (dataReader["CreatedBy"] != DBNull.Value)
					{
						hcUsersEntity.Createdby = dataReader["CreatedBy"].ToString();
					}
					if (dataReader["CreatedTime"] != DBNull.Value)
					{
						hcUsersEntity.Createdtime = dataReader["CreatedTime"].ToString();
                    }
                    if (dataReader["UpdatedBy"] != DBNull.Value)
					{
                        hcUsersEntity.Updatedby = dataReader["UpdatedBy"].ToString();
					}
                    if (dataReader["UpdatedTime"] != DBNull.Value)
					{
                        hcUsersEntity.Updatedtime = dataReader["UpdatedTime"].ToString();
					}
					if (dataReader["LastLogIn"] != DBNull.Value)
					{
						hcUsersEntity.Lastlogin = dataReader["LastLogIn"].ToString();
					}
				}
			}
			return hcUsersEntity;
		}
        public HcUsersEntity GetLoginUser(object param)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sql = "SELECT ID, LogName, LogPass, SecurPass, Email, FirstName, LastName, Gender, Address, UserType, UserID, RoleID, IsActive, CreatedBy, CreatedTime, UpdatedBy, UpdatedTime, LastLogIn FROM HC_Users WHERE Email=@Email and LogPass=@LogPass";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            db.AddInParameter(dbCommand, "Email", DbType.String, param);
            db.AddInParameter(dbCommand, "LogPass", DbType.String, param);
            HcUsersEntity hcUsersEntity = null;
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    hcUsersEntity = new HcUsersEntity();
                    if (dataReader["ID"] != DBNull.Value)
                    {
                        hcUsersEntity.Id = dataReader["ID"].ToString();
                    }
                    if (dataReader["LogName"] != DBNull.Value)
                    {
                        hcUsersEntity.Logname = dataReader["LogName"].ToString();
                    }
                    if (dataReader["LogPass"] != DBNull.Value)
                    {
                        hcUsersEntity.Logpass = dataReader["LogPass"].ToString();
                    }
                    if (dataReader["SecurPass"] != DBNull.Value)
                    {
                        hcUsersEntity.SecurPass = dataReader["SecurPass"].ToString();
                    }
                    if (dataReader["Email"] != DBNull.Value)
                    {
                        hcUsersEntity.Email = dataReader["Email"].ToString();
                    }
                    if (dataReader["FirstName"] != DBNull.Value)
                    {
                        hcUsersEntity.FirstName = dataReader["FirstName"].ToString();
                    }
                    if (dataReader["LastName"] != DBNull.Value)
                    {
                        hcUsersEntity.LastName = dataReader["LastName"].ToString();
                    }
                    if (dataReader["Gender"] != DBNull.Value)
                    {
                        hcUsersEntity.Gender = dataReader["Gender"].ToString();
                    }
                    if (dataReader["Address"] != DBNull.Value)
                    {
                        hcUsersEntity.Address = dataReader["Address"].ToString();
                    }
                    if (dataReader["UserType"] != DBNull.Value)
                    {
                        hcUsersEntity.Usertype = dataReader["UserType"].ToString();
                    }
                    if (dataReader["UserID"] != DBNull.Value)
                    {
                        hcUsersEntity.Userid = dataReader["UserID"].ToString();
                    }
                    if (dataReader["RoleID"] != DBNull.Value)
                    {
                        hcUsersEntity.Roleid = dataReader["RoleID"].ToString();
                    }
                    if (dataReader["IsActive"] != DBNull.Value)
                    {
                        hcUsersEntity.Isactive = dataReader["IsActive"].ToString();
                    }
                    if (dataReader["CreatedBy"] != DBNull.Value)
                    {
                        hcUsersEntity.Createdby = dataReader["CreatedBy"].ToString();
                    }
                    if (dataReader["CreatedTime"] != DBNull.Value)
                    {
                        hcUsersEntity.Createdtime = dataReader["CreatedTime"].ToString();
                    }
                    if (dataReader["UpdatedBy"] != DBNull.Value)
                    {
                        hcUsersEntity.Updatedby = dataReader["UpdatedBy"].ToString();
                    }
                    if (dataReader["UpdatedTime"] != DBNull.Value)
                    {
                        hcUsersEntity.Updatedtime = dataReader["UpdatedTime"].ToString();
                    }
                    if (dataReader["LastLogIn"] != DBNull.Value)
                    {
                        hcUsersEntity.Lastlogin = dataReader["LastLogIn"].ToString();
                    }
                }
            }
            return hcUsersEntity;
        }

		#endregion

	}
}

