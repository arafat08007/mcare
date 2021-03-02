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
	public partial class HcPackagemasterDAL
	{
		#region Auto Generated 

		public bool SaveHcPackagemasterInfo(HcPackagemasterEntity hcPackagemasterEntity, Database db, DbTransaction transaction)
		{
			string sql = "INSERT INTO HC_PackageMaster ( id, PackageName, PackageShorDesc, PackagePrice, createdby, createdDate, updateby, updateDate, isactive) VALUES (  @Id,  @Packagename,  @Packageshordesc,  @Packageprice,  @Createdby,  @Createddate,  @Updateby,  @Updatedate,  @Isactive )";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);

			db.AddInParameter(dbCommand, "Id", DbType.String, hcPackagemasterEntity.Id);
			db.AddInParameter(dbCommand, "Packagename", DbType.String, hcPackagemasterEntity.Packagename);
			db.AddInParameter(dbCommand, "Packageshordesc", DbType.String, hcPackagemasterEntity.Packageshordesc);
			db.AddInParameter(dbCommand, "Packageprice", DbType.String, hcPackagemasterEntity.Packageprice);
			db.AddInParameter(dbCommand, "Createdby", DbType.String, hcPackagemasterEntity.Createdby);
			db.AddInParameter(dbCommand, "Createddate", DbType.String, hcPackagemasterEntity.Createddate);
			db.AddInParameter(dbCommand, "Updateby", DbType.String, hcPackagemasterEntity.Updateby);
			db.AddInParameter(dbCommand, "Updatedate", DbType.String, hcPackagemasterEntity.Updatedate);
			db.AddInParameter(dbCommand, "Isactive", DbType.String, hcPackagemasterEntity.Isactive);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;		}

		public bool UpdateHcPackagemasterInfo(HcPackagemasterEntity hcPackagemasterEntity, Database db, DbTransaction transaction)
		{
			string sql = "UPDATE HC_PackageMaster SET PackageName= @Packagename, PackageShorDesc= @Packageshordesc, PackagePrice= @Packageprice, createdby= @Createdby, createdDate= @Createddate, updateby= @Updateby, updateDate= @Updatedate, isactive= @Isactive WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id",DbType.String, hcPackagemasterEntity.Id);
			db.AddInParameter(dbCommand, "Packagename", DbType.String, hcPackagemasterEntity.Packagename);
			db.AddInParameter(dbCommand, "Packageshordesc", DbType.String, hcPackagemasterEntity.Packageshordesc);
			db.AddInParameter(dbCommand, "Packageprice", DbType.String, hcPackagemasterEntity.Packageprice);
			db.AddInParameter(dbCommand, "Createdby", DbType.String, hcPackagemasterEntity.Createdby);
			db.AddInParameter(dbCommand, "Createddate", DbType.String, hcPackagemasterEntity.Createddate);
			db.AddInParameter(dbCommand, "Updateby", DbType.String, hcPackagemasterEntity.Updateby);
			db.AddInParameter(dbCommand, "Updatedate", DbType.String, hcPackagemasterEntity.Updatedate);
			db.AddInParameter(dbCommand, "Isactive", DbType.String, hcPackagemasterEntity.Isactive);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public bool DeleteHcPackagemasterInfoById(object param, Database db, DbTransaction transaction)
		{
			string sql = "DELETE FROM HC_PackageMaster WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public HcPackagemasterEntity GetSingleHcPackagemasterRecordById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sql = "SELECT id, PackageName, PackageShorDesc, PackagePrice, createdby, createdDate, updateby, updateDate, isactive FROM HC_PackageMaster WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);
			HcPackagemasterEntity hcPackagemasterEntity = null;
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
			{
				if (dataReader.Read())
				{
					hcPackagemasterEntity = new HcPackagemasterEntity();
					if (dataReader["id"] != DBNull.Value)
					{
						hcPackagemasterEntity.Id = dataReader["id"].ToString();
					}
					if (dataReader["PackageName"] != DBNull.Value)
					{
						hcPackagemasterEntity.Packagename = dataReader["PackageName"].ToString();
					}
					if (dataReader["PackageShorDesc"] != DBNull.Value)
					{
						hcPackagemasterEntity.Packageshordesc = dataReader["PackageShorDesc"].ToString();
					}
					if (dataReader["PackagePrice"] != DBNull.Value)
					{
						hcPackagemasterEntity.Packageprice = dataReader["PackagePrice"].ToString();
					}
					if (dataReader["createdby"] != DBNull.Value)
					{
						hcPackagemasterEntity.Createdby = dataReader["createdby"].ToString();
					}
					if (dataReader["createdDate"] != DBNull.Value)
					{
						hcPackagemasterEntity.Createddate = dataReader["createdDate"].ToString();
					}
					if (dataReader["updateby"] != DBNull.Value)
					{
						hcPackagemasterEntity.Updateby = dataReader["updateby"].ToString();
					}
					if (dataReader["updateDate"] != DBNull.Value)
					{
						hcPackagemasterEntity.Updatedate = dataReader["updateDate"].ToString();
					}
					if (dataReader["isactive"] != DBNull.Value)
					{
						hcPackagemasterEntity.Isactive = dataReader["isactive"].ToString();
					}
				}
			}
			return hcPackagemasterEntity;
		}

		#endregion

	}
}

