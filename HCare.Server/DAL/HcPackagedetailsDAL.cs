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
	public partial class HcPackagedetailsDAL
	{
		#region Auto Generated 

		public bool SaveHcPackagedetailsInfo(HcPackagedetailsEntity hcPackagedetailsEntity, Database db, DbTransaction transaction)
		{
			string sql = "INSERT INTO HC_PackageDetails ( Id, refid, PackageCovers, PackageIncludes, PackageProcess, LabPartner, Packagebenifits, createdby, createdDate, updateby, updateDate, isactive) VALUES (  @Id,  @Refid,  @Packagecovers,  @Packageincludes,  @Packageprocess,  @Labpartner,  @Packagebenifits,  @Createdby,  @Createddate,  @Updateby,  @Updatedate,  @Isactive )";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);

			db.AddInParameter(dbCommand, "Id", DbType.String, hcPackagedetailsEntity.Id);
			db.AddInParameter(dbCommand, "Refid", DbType.String, hcPackagedetailsEntity.Refid);
			db.AddInParameter(dbCommand, "Packagecovers", DbType.String, hcPackagedetailsEntity.Packagecovers);
			db.AddInParameter(dbCommand, "Packageincludes", DbType.String, hcPackagedetailsEntity.Packageincludes);
			db.AddInParameter(dbCommand, "Packageprocess", DbType.String, hcPackagedetailsEntity.Packageprocess);
			db.AddInParameter(dbCommand, "Labpartner", DbType.String, hcPackagedetailsEntity.Labpartner);
			db.AddInParameter(dbCommand, "Packagebenifits", DbType.String, hcPackagedetailsEntity.Packagebenifits);
			db.AddInParameter(dbCommand, "Createdby", DbType.String, hcPackagedetailsEntity.Createdby);
			db.AddInParameter(dbCommand, "Createddate", DbType.String, hcPackagedetailsEntity.Createddate);
			db.AddInParameter(dbCommand, "Updateby", DbType.String, hcPackagedetailsEntity.Updateby);
			db.AddInParameter(dbCommand, "Updatedate", DbType.String, hcPackagedetailsEntity.Updatedate);
			db.AddInParameter(dbCommand, "Isactive", DbType.String, hcPackagedetailsEntity.Isactive);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;		}

		public bool UpdateHcPackagedetailsInfo(HcPackagedetailsEntity hcPackagedetailsEntity, Database db, DbTransaction transaction)
		{
			string sql = "UPDATE HC_PackageDetails SET refid= @Refid, PackageCovers= @Packagecovers, PackageIncludes= @Packageincludes, PackageProcess= @Packageprocess, LabPartner= @Labpartner, Packagebenifits= @Packagebenifits, createdby= @Createdby, createdDate= @Createddate, updateby= @Updateby, updateDate= @Updatedate, isactive= @Isactive WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id",DbType.String, hcPackagedetailsEntity.Id);
			db.AddInParameter(dbCommand, "Refid", DbType.String, hcPackagedetailsEntity.Refid);
			db.AddInParameter(dbCommand, "Packagecovers", DbType.String, hcPackagedetailsEntity.Packagecovers);
			db.AddInParameter(dbCommand, "Packageincludes", DbType.String, hcPackagedetailsEntity.Packageincludes);
			db.AddInParameter(dbCommand, "Packageprocess", DbType.String, hcPackagedetailsEntity.Packageprocess);
			db.AddInParameter(dbCommand, "Labpartner", DbType.String, hcPackagedetailsEntity.Labpartner);
			db.AddInParameter(dbCommand, "Packagebenifits", DbType.String, hcPackagedetailsEntity.Packagebenifits);
			db.AddInParameter(dbCommand, "Createdby", DbType.String, hcPackagedetailsEntity.Createdby);
			db.AddInParameter(dbCommand, "Createddate", DbType.String, hcPackagedetailsEntity.Createddate);
			db.AddInParameter(dbCommand, "Updateby", DbType.String, hcPackagedetailsEntity.Updateby);
			db.AddInParameter(dbCommand, "Updatedate", DbType.String, hcPackagedetailsEntity.Updatedate);
			db.AddInParameter(dbCommand, "Isactive", DbType.String, hcPackagedetailsEntity.Isactive);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public bool DeleteHcPackagedetailsInfoById(object param, Database db, DbTransaction transaction)
		{
			string sql = "DELETE FROM HC_PackageDetails WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public HcPackagedetailsEntity GetSingleHcPackagedetailsRecordById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sql = "SELECT Id, refid, PackageCovers, PackageIncludes, PackageProcess, LabPartner, Packagebenifits, createdby, createdDate, updateby, updateDate, isactive FROM HC_PackageDetails WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);
			HcPackagedetailsEntity hcPackagedetailsEntity = null;
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
			{
				if (dataReader.Read())
				{
					hcPackagedetailsEntity = new HcPackagedetailsEntity();
					if (dataReader["Id"] != DBNull.Value)
					{
						hcPackagedetailsEntity.Id = dataReader["Id"].ToString();
					}
					if (dataReader["refid"] != DBNull.Value)
					{
						hcPackagedetailsEntity.Refid = dataReader["refid"].ToString();
					}
					if (dataReader["PackageCovers"] != DBNull.Value)
					{
						hcPackagedetailsEntity.Packagecovers = dataReader["PackageCovers"].ToString();
					}
					if (dataReader["PackageIncludes"] != DBNull.Value)
					{
						hcPackagedetailsEntity.Packageincludes = dataReader["PackageIncludes"].ToString();
					}
					if (dataReader["PackageProcess"] != DBNull.Value)
					{
						hcPackagedetailsEntity.Packageprocess = dataReader["PackageProcess"].ToString();
					}
					if (dataReader["LabPartner"] != DBNull.Value)
					{
						hcPackagedetailsEntity.Labpartner = dataReader["LabPartner"].ToString();
					}
					if (dataReader["Packagebenifits"] != DBNull.Value)
					{
						hcPackagedetailsEntity.Packagebenifits = dataReader["Packagebenifits"].ToString();
					}
					if (dataReader["createdby"] != DBNull.Value)
					{
						hcPackagedetailsEntity.Createdby = dataReader["createdby"].ToString();
					}
					if (dataReader["createdDate"] != DBNull.Value)
					{
						hcPackagedetailsEntity.Createddate = dataReader["createdDate"].ToString();
					}
					if (dataReader["updateby"] != DBNull.Value)
					{
						hcPackagedetailsEntity.Updateby = dataReader["updateby"].ToString();
					}
					if (dataReader["updateDate"] != DBNull.Value)
					{
						hcPackagedetailsEntity.Updatedate = dataReader["updateDate"].ToString();
					}
					if (dataReader["isactive"] != DBNull.Value)
					{
						hcPackagedetailsEntity.Isactive = dataReader["isactive"].ToString();
					}
				}
			}
			return hcPackagedetailsEntity;
		}

		#endregion

	}
}

