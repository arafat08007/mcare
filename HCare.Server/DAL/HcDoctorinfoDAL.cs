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
	public partial class HcDoctorinfoDAL
	{
		#region Auto Generated 

		public object SaveHcDoctorinfoInfo(HcDoctorinfoEntity hcDoctorinfoEntity, Database db, DbTransaction transaction)
		{
            string sql = "select Isnull(MAX(SortBy),0)+1 from HC_DoctorInfo";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            if (string.IsNullOrEmpty(hcDoctorinfoEntity.Sortby))
                hcDoctorinfoEntity.Sortby = db.ExecuteScalar(dbCommand, transaction).ToString();

            sql = "INSERT INTO HC_DoctorInfo ( Name, Department, Specialist, Education, Experience, About, Fees, JoinDate, Photo, Gender, IsActive, CreatedBy, CreatedTime, SortBy, IsView, ViewBy, ViewTime ) output inserted.ID VALUES (  @Name,  @Department,  @Specialist,  @Education,  @Experience,  @About,  @Fees,  @Joindate,  @Photo,  @Gender,  @Isactive,  @Createdby,  @Createdtime,  @Sortby,  @Isview,  @Viewby,  @Viewtime )";
			dbCommand = db.GetSqlStringCommand(sql);

			db.AddInParameter(dbCommand, "Name", DbType.String, hcDoctorinfoEntity.Name);
			db.AddInParameter(dbCommand, "Department", DbType.String, hcDoctorinfoEntity.Department);
			db.AddInParameter(dbCommand, "Specialist", DbType.String, hcDoctorinfoEntity.Specialist);
			db.AddInParameter(dbCommand, "Education", DbType.String, hcDoctorinfoEntity.Education);
			db.AddInParameter(dbCommand, "Experience", DbType.String, hcDoctorinfoEntity.Experience);
			db.AddInParameter(dbCommand, "About", DbType.String, hcDoctorinfoEntity.About);
			db.AddInParameter(dbCommand, "Fees", DbType.String, hcDoctorinfoEntity.Fees);
			db.AddInParameter(dbCommand, "Joindate", DbType.String, hcDoctorinfoEntity.Joindate);
            db.AddInParameter(dbCommand, "Photo", DbType.String, hcDoctorinfoEntity.Photo);
            db.AddInParameter(dbCommand, "Gender", DbType.String, hcDoctorinfoEntity.Gender);
			db.AddInParameter(dbCommand, "Isactive", DbType.String, hcDoctorinfoEntity.Isactive);
			db.AddInParameter(dbCommand, "Createdby", DbType.String, hcDoctorinfoEntity.Createdby);
            db.AddInParameter(dbCommand, "Createdtime", DbType.String, hcDoctorinfoEntity.Createdtime);
            db.AddInParameter(dbCommand, "SortBy", DbType.String, hcDoctorinfoEntity.Sortby);
            db.AddInParameter(dbCommand, "Isview", DbType.String, hcDoctorinfoEntity.Isview);
            db.AddInParameter(dbCommand, "Viewby", DbType.String, hcDoctorinfoEntity.Viewby);
            db.AddInParameter(dbCommand, "Viewtime", DbType.String, hcDoctorinfoEntity.Viewtime);

            var id = db.ExecuteScalar(dbCommand, transaction).ToString();
            return id;
        }

		public bool UpdateHcDoctorinfoInfo(HcDoctorinfoEntity hcDoctorinfoEntity, Database db, DbTransaction transaction)
		{
            string sql = "UPDATE HC_DoctorInfo SET Name= @Name, Department= @Department, Specialist= @Specialist, Education= @Education, Experience= @Experience, About= @About, Fees= @Fees, JoinDate= @Joindate, Photo= @Photo, Gender= @Gender, IsActive= @Isactive, UpdatedBy= @Updatedby, UpdatedTime= @Updatedtime, SortBy= @Sortby, IsView= @Isview, ViewBy= @Viewby, ViewTime= @Viewtime WHERE Id=@Id";

            if (hcDoctorinfoEntity.QueryFlag == "EmptyView")
                sql = "UPDATE HC_DoctorInfo SET IsView= @Isview, ViewBy= @Viewby, ViewTime= @Viewtime";
            if (hcDoctorinfoEntity.QueryFlag == "SetView")
                sql = "UPDATE HC_DoctorInfo SET IsView= 'checked', ViewBy= @Viewby, ViewTime= @Viewtime WHERE Id=@Id";

            DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id",DbType.String, hcDoctorinfoEntity.Id);
			db.AddInParameter(dbCommand, "Name", DbType.String, hcDoctorinfoEntity.Name);
			db.AddInParameter(dbCommand, "Department", DbType.String, hcDoctorinfoEntity.Department);
			db.AddInParameter(dbCommand, "Specialist", DbType.String, hcDoctorinfoEntity.Specialist);
			db.AddInParameter(dbCommand, "Education", DbType.String, hcDoctorinfoEntity.Education);
			db.AddInParameter(dbCommand, "Experience", DbType.String, hcDoctorinfoEntity.Experience);
			db.AddInParameter(dbCommand, "About", DbType.String, hcDoctorinfoEntity.About);
			db.AddInParameter(dbCommand, "Fees", DbType.String, hcDoctorinfoEntity.Fees);
			db.AddInParameter(dbCommand, "Joindate", DbType.String, hcDoctorinfoEntity.Joindate);
            db.AddInParameter(dbCommand, "Photo", DbType.String, hcDoctorinfoEntity.Photo);
            db.AddInParameter(dbCommand, "Gender", DbType.String, hcDoctorinfoEntity.Gender);
			db.AddInParameter(dbCommand, "Isactive", DbType.String, hcDoctorinfoEntity.Isactive);
			db.AddInParameter(dbCommand, "Updatedby", DbType.String, hcDoctorinfoEntity.Updatedby);
            db.AddInParameter(dbCommand, "Updatedtime", DbType.String, hcDoctorinfoEntity.Updatedtime);
            db.AddInParameter(dbCommand, "SortBy", DbType.String, hcDoctorinfoEntity.Sortby);
            db.AddInParameter(dbCommand, "Isview", DbType.String, hcDoctorinfoEntity.Isview);
            db.AddInParameter(dbCommand, "Viewby", DbType.String, hcDoctorinfoEntity.Viewby);
            db.AddInParameter(dbCommand, "Viewtime", DbType.String, hcDoctorinfoEntity.Viewtime);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public bool DeleteHcDoctorinfoInfoById(object param, Database db, DbTransaction transaction)
		{
			string sql = "DELETE FROM HC_DoctorInfo WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public HcDoctorinfoEntity GetSingleHcDoctorinfoRecordById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
            string sql = "SELECT ID, Name, Department, Specialist, Education, Experience, About, Fees, JoinDate, Photo, Gender, IsActive, CreatedBy, CreatedTime, UpdatedBy, UpdatedTime, SortBy, IsView, ViewBy, ViewTime FROM HC_DoctorInfo WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);
			HcDoctorinfoEntity hcDoctorinfoEntity = null;
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
			{
				if (dataReader.Read())
				{
					hcDoctorinfoEntity = new HcDoctorinfoEntity();
					if (dataReader["ID"] != DBNull.Value)
					{
						hcDoctorinfoEntity.Id = dataReader["ID"].ToString();
					}
					if (dataReader["Name"] != DBNull.Value)
					{
						hcDoctorinfoEntity.Name = dataReader["Name"].ToString();
					}
					if (dataReader["Department"] != DBNull.Value)
					{
						hcDoctorinfoEntity.Department = dataReader["Department"].ToString();
					}
					if (dataReader["Specialist"] != DBNull.Value)
					{
						hcDoctorinfoEntity.Specialist = dataReader["Specialist"].ToString();
					}
					if (dataReader["Education"] != DBNull.Value)
					{
						hcDoctorinfoEntity.Education = dataReader["Education"].ToString();
					}
					if (dataReader["Experience"] != DBNull.Value)
					{
						hcDoctorinfoEntity.Experience = dataReader["Experience"].ToString();
					}
					if (dataReader["About"] != DBNull.Value)
					{
						hcDoctorinfoEntity.About = dataReader["About"].ToString();
					}
					if (dataReader["Fees"] != DBNull.Value)
					{
						hcDoctorinfoEntity.Fees = dataReader["Fees"].ToString();
					}
					if (dataReader["JoinDate"] != DBNull.Value)
					{
						hcDoctorinfoEntity.Joindate = dataReader["JoinDate"].ToString();
					}
                    if (dataReader["Photo"] != DBNull.Value)
					{
                        hcDoctorinfoEntity.Photo = dataReader["Photo"].ToString();
					}
                    if (dataReader["Gender"] != DBNull.Value)
					{
                        hcDoctorinfoEntity.Gender = dataReader["Gender"].ToString();
					}
					if (dataReader["IsActive"] != DBNull.Value)
					{
						hcDoctorinfoEntity.Isactive = dataReader["IsActive"].ToString();
					}
					if (dataReader["CreatedBy"] != DBNull.Value)
					{
						hcDoctorinfoEntity.Createdby = dataReader["CreatedBy"].ToString();
					}
					if (dataReader["CreatedTime"] != DBNull.Value)
					{
						hcDoctorinfoEntity.Createdtime = dataReader["CreatedTime"].ToString();
					}
					if (dataReader["UpdatedBy"] != DBNull.Value)
					{
						hcDoctorinfoEntity.Updatedby = dataReader["UpdatedBy"].ToString();
					}
					if (dataReader["UpdatedTime"] != DBNull.Value)
					{
						hcDoctorinfoEntity.Updatedtime = dataReader["UpdatedTime"].ToString();
                    }
                    if (dataReader["SortBy"] != DBNull.Value)
                    {
                        hcDoctorinfoEntity.Sortby = dataReader["SortBy"].ToString();
                    }
                    if (dataReader["IsView"] != DBNull.Value)
                    {
                        hcDoctorinfoEntity.Isview = dataReader["IsView"].ToString();
                    }
                    if (dataReader["ViewBy"] != DBNull.Value)
                    {
                        hcDoctorinfoEntity.Viewby = dataReader["ViewBy"].ToString();
                    }
                    if (dataReader["ViewTime"] != DBNull.Value)
                    {
                        hcDoctorinfoEntity.Viewtime = dataReader["ViewTime"].ToString();
                    }
				}
			}
			return hcDoctorinfoEntity;
		}

		#endregion

	}
}

