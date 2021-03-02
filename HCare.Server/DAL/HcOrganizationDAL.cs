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
	public partial class HcOrganizationDAL
	{
		#region Auto Generated 

		public bool SaveHcOrganizationInfo(HcOrganizationEntity hcOrganizationEntity, Database db, DbTransaction transaction)
		{
			string sql = "INSERT INTO HC_Organization ( Organizationname, Address, countryid, logo, isActive) VALUES (  @Organizationname,  @Address,  @Countryid,  @Logo,  @Isactive )";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);

			db.AddInParameter(dbCommand, "Organizationname", DbType.String, hcOrganizationEntity.Organizationname);
			db.AddInParameter(dbCommand, "Address", DbType.String, hcOrganizationEntity.Address);
			db.AddInParameter(dbCommand, "Countryid", DbType.String, hcOrganizationEntity.Countryid);
			db.AddInParameter(dbCommand, "Logo", DbType.String, hcOrganizationEntity.Logo);
			db.AddInParameter(dbCommand, "Isactive", DbType.String, hcOrganizationEntity.Isactive);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;		}

		public bool UpdateHcOrganizationInfo(HcOrganizationEntity hcOrganizationEntity, Database db, DbTransaction transaction)
		{
			string sql = "UPDATE HC_Organization SET Organizationname= @Organizationname, Address= @Address, countryid= @Countryid, logo= @Logo, isActive= @Isactive WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id",DbType.String, hcOrganizationEntity.Id);
			db.AddInParameter(dbCommand, "Organizationname", DbType.String, hcOrganizationEntity.Organizationname);
			db.AddInParameter(dbCommand, "Address", DbType.String, hcOrganizationEntity.Address);
			db.AddInParameter(dbCommand, "Countryid", DbType.String, hcOrganizationEntity.Countryid);
			db.AddInParameter(dbCommand, "Logo", DbType.String, hcOrganizationEntity.Logo);
			db.AddInParameter(dbCommand, "Isactive", DbType.String, hcOrganizationEntity.Isactive);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public bool DeleteHcOrganizationInfoById(object param, Database db, DbTransaction transaction)
		{
			string sql = "DELETE FROM HC_Organization WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public HcOrganizationEntity GetSingleHcOrganizationRecordById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sql = "SELECT ID, Organizationname, Address, countryid, logo, isActive FROM HC_Organization WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);
			HcOrganizationEntity hcOrganizationEntity = null;
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
			{
				if (dataReader.Read())
				{
					hcOrganizationEntity = new HcOrganizationEntity();
					if (dataReader["ID"] != DBNull.Value)
					{
						hcOrganizationEntity.Id = dataReader["ID"].ToString();
					}
					if (dataReader["Organizationname"] != DBNull.Value)
					{
						hcOrganizationEntity.Organizationname = dataReader["Organizationname"].ToString();
					}
					if (dataReader["Address"] != DBNull.Value)
					{
						hcOrganizationEntity.Address = dataReader["Address"].ToString();
					}
					if (dataReader["countryid"] != DBNull.Value)
					{
						hcOrganizationEntity.Countryid = dataReader["countryid"].ToString();
					}
					if (dataReader["logo"] != DBNull.Value)
					{
						hcOrganizationEntity.Logo = dataReader["logo"].ToString();
					}
					if (dataReader["isActive"] != DBNull.Value)
					{
						hcOrganizationEntity.Isactive = dataReader["isActive"].ToString();
					}
				}
			}
			return hcOrganizationEntity;
		}

		#endregion

	}
}

