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
	public partial class HcOffersDAL
	{
		#region Auto Generated 

		public bool SaveHcOffersInfo(HcOffersEntity hcOffersEntity, Database db, DbTransaction transaction)
		{
			string sql = "INSERT INTO HC_Offers ( Id, OfferTitle, OfferOn, OfferProduct, isActive, CreatedBy, CreatedDate, UpdateBy, UpdateDate) VALUES (  @Id,  @Offertitle,  @Offeron,  @Offerproduct,  @Isactive,  @Createdby,  @Createddate,  @Updateby,  @Updatedate )";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);

			db.AddInParameter(dbCommand, "Id", DbType.String, hcOffersEntity.Id);
			db.AddInParameter(dbCommand, "Offertitle", DbType.String, hcOffersEntity.Offertitle);
			db.AddInParameter(dbCommand, "Offeron", DbType.String, hcOffersEntity.Offeron);
			db.AddInParameter(dbCommand, "Offerproduct", DbType.String, hcOffersEntity.Offerproduct);
			db.AddInParameter(dbCommand, "Isactive", DbType.String, hcOffersEntity.Isactive);
			db.AddInParameter(dbCommand, "Createdby", DbType.String, hcOffersEntity.Createdby);
			db.AddInParameter(dbCommand, "Createddate", DbType.String, hcOffersEntity.Createddate);
			db.AddInParameter(dbCommand, "Updateby", DbType.String, hcOffersEntity.Updateby);
			db.AddInParameter(dbCommand, "Updatedate", DbType.String, hcOffersEntity.Updatedate);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;		}

		public bool UpdateHcOffersInfo(HcOffersEntity hcOffersEntity, Database db, DbTransaction transaction)
		{
			string sql = "UPDATE HC_Offers SET OfferTitle= @Offertitle, OfferOn= @Offeron, OfferProduct= @Offerproduct, isActive= @Isactive, CreatedBy= @Createdby, CreatedDate= @Createddate, UpdateBy= @Updateby, UpdateDate= @Updatedate WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id",DbType.String, hcOffersEntity.Id);
			db.AddInParameter(dbCommand, "Offertitle", DbType.String, hcOffersEntity.Offertitle);
			db.AddInParameter(dbCommand, "Offeron", DbType.String, hcOffersEntity.Offeron);
			db.AddInParameter(dbCommand, "Offerproduct", DbType.String, hcOffersEntity.Offerproduct);
			db.AddInParameter(dbCommand, "Isactive", DbType.String, hcOffersEntity.Isactive);
			db.AddInParameter(dbCommand, "Createdby", DbType.String, hcOffersEntity.Createdby);
			db.AddInParameter(dbCommand, "Createddate", DbType.String, hcOffersEntity.Createddate);
			db.AddInParameter(dbCommand, "Updateby", DbType.String, hcOffersEntity.Updateby);
			db.AddInParameter(dbCommand, "Updatedate", DbType.String, hcOffersEntity.Updatedate);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public bool DeleteHcOffersInfoById(object param, Database db, DbTransaction transaction)
		{
			string sql = "DELETE FROM HC_Offers WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public HcOffersEntity GetSingleHcOffersRecordById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sql = "SELECT Id, OfferTitle, OfferOn, OfferProduct, isActive, CreatedBy, CreatedDate, UpdateBy, UpdateDate FROM HC_Offers WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);
			HcOffersEntity hcOffersEntity = null;
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
			{
				if (dataReader.Read())
				{
					hcOffersEntity = new HcOffersEntity();
					if (dataReader["Id"] != DBNull.Value)
					{
						hcOffersEntity.Id = dataReader["Id"].ToString();
					}
					if (dataReader["OfferTitle"] != DBNull.Value)
					{
						hcOffersEntity.Offertitle = dataReader["OfferTitle"].ToString();
					}
					if (dataReader["OfferOn"] != DBNull.Value)
					{
						hcOffersEntity.Offeron = dataReader["OfferOn"].ToString();
					}
					if (dataReader["OfferProduct"] != DBNull.Value)
					{
						hcOffersEntity.Offerproduct = dataReader["OfferProduct"].ToString();
					}
					if (dataReader["isActive"] != DBNull.Value)
					{
						hcOffersEntity.Isactive = dataReader["isActive"].ToString();
					}
					if (dataReader["CreatedBy"] != DBNull.Value)
					{
						hcOffersEntity.Createdby = dataReader["CreatedBy"].ToString();
					}
					if (dataReader["CreatedDate"] != DBNull.Value)
					{
						hcOffersEntity.Createddate = dataReader["CreatedDate"].ToString();
					}
					if (dataReader["UpdateBy"] != DBNull.Value)
					{
						hcOffersEntity.Updateby = dataReader["UpdateBy"].ToString();
					}
					if (dataReader["UpdateDate"] != DBNull.Value)
					{
						hcOffersEntity.Updatedate = dataReader["UpdateDate"].ToString();
					}
				}
			}
			return hcOffersEntity;
		}

		#endregion

	}
}

