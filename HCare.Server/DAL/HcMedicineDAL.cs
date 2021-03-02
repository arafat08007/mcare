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
	public partial class HcMedicineDAL
	{
		#region Auto Generated 

		public bool SaveHcMedicineInfo(HcMedicineEntity hcMedicineEntity, Database db, DbTransaction transaction)
		{
			string sql = "INSERT INTO HC_Medicine ( MedicineName, MedicineCompany, MedicineType, ProductCategory, MedicinePrice, MedicineImage, UoM, StockQnty, CreatedBy, CreatedAt, UpdateBy, UpdatedAt, Status) VALUES (  @Medicinename,  @Medicinecompany,  @Medicinetype,  @Productcategory,  @Medicineprice,  @Medicineimage,  @Uom,  @Stockqnty,  @Createdby,  @Createdat,  @Updateby,  @Updatedat,  @Status )";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);

			db.AddInParameter(dbCommand, "Medicinename", DbType.String, hcMedicineEntity.Medicinename);
			db.AddInParameter(dbCommand, "Medicinecompany", DbType.String, hcMedicineEntity.Medicinecompany);
			db.AddInParameter(dbCommand, "Medicinetype", DbType.String, hcMedicineEntity.Medicinetype);
			db.AddInParameter(dbCommand, "Productcategory", DbType.String, hcMedicineEntity.Productcategory);
			db.AddInParameter(dbCommand, "Medicineprice", DbType.String, hcMedicineEntity.Medicineprice);
			db.AddInParameter(dbCommand, "Medicineimage", DbType.String, hcMedicineEntity.Medicineimage);
			db.AddInParameter(dbCommand, "Uom", DbType.String, hcMedicineEntity.Uom);
			db.AddInParameter(dbCommand, "Stockqnty", DbType.String, hcMedicineEntity.Stockqnty);
			db.AddInParameter(dbCommand, "Createdby", DbType.String, hcMedicineEntity.Createdby);
			db.AddInParameter(dbCommand, "Createdat", DbType.String, hcMedicineEntity.Createdat);
			db.AddInParameter(dbCommand, "Updateby", DbType.String, hcMedicineEntity.Updateby);
			db.AddInParameter(dbCommand, "Updatedat", DbType.String, hcMedicineEntity.Updatedat);
			db.AddInParameter(dbCommand, "Status", DbType.String, hcMedicineEntity.Status);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;		}

		public bool UpdateHcMedicineInfo(HcMedicineEntity hcMedicineEntity, Database db, DbTransaction transaction)
		{
			string sql = "UPDATE HC_Medicine SET MedicineName= @Medicinename, MedicineCompany= @Medicinecompany, MedicineType= @Medicinetype, ProductCategory= @Productcategory, MedicinePrice= @Medicineprice, MedicineImage= @Medicineimage, UoM= @Uom, StockQnty= @Stockqnty, CreatedBy= @Createdby, CreatedAt= @Createdat, UpdateBy= @Updateby, UpdatedAt= @Updatedat, Status= @Status WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id",DbType.String, hcMedicineEntity.Id);
			db.AddInParameter(dbCommand, "Medicinename", DbType.String, hcMedicineEntity.Medicinename);
			db.AddInParameter(dbCommand, "Medicinecompany", DbType.String, hcMedicineEntity.Medicinecompany);
			db.AddInParameter(dbCommand, "Medicinetype", DbType.String, hcMedicineEntity.Medicinetype);
			db.AddInParameter(dbCommand, "Productcategory", DbType.String, hcMedicineEntity.Productcategory);
			db.AddInParameter(dbCommand, "Medicineprice", DbType.String, hcMedicineEntity.Medicineprice);
			db.AddInParameter(dbCommand, "Medicineimage", DbType.String, hcMedicineEntity.Medicineimage);
			db.AddInParameter(dbCommand, "Uom", DbType.String, hcMedicineEntity.Uom);
			db.AddInParameter(dbCommand, "Stockqnty", DbType.String, hcMedicineEntity.Stockqnty);
			db.AddInParameter(dbCommand, "Createdby", DbType.String, hcMedicineEntity.Createdby);
			db.AddInParameter(dbCommand, "Createdat", DbType.String, hcMedicineEntity.Createdat);
			db.AddInParameter(dbCommand, "Updateby", DbType.String, hcMedicineEntity.Updateby);
			db.AddInParameter(dbCommand, "Updatedat", DbType.String, hcMedicineEntity.Updatedat);
			db.AddInParameter(dbCommand, "Status", DbType.String, hcMedicineEntity.Status);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public bool DeleteHcMedicineInfoById(object param, Database db, DbTransaction transaction)
		{
			string sql = "DELETE FROM HC_Medicine WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public HcMedicineEntity GetSingleHcMedicineRecordById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sql = "SELECT ID, MedicineName, MedicineCompany, MedicineType, ProductCategory, MedicinePrice, MedicineImage, UoM, StockQnty, CreatedBy, CreatedAt, UpdateBy, UpdatedAt, Status FROM HC_Medicine WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);
			HcMedicineEntity hcMedicineEntity = null;
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
			{
				if (dataReader.Read())
				{
					hcMedicineEntity = new HcMedicineEntity();
					if (dataReader["ID"] != DBNull.Value)
					{
						hcMedicineEntity.Id = dataReader["ID"].ToString();
					}
					if (dataReader["MedicineName"] != DBNull.Value)
					{
						hcMedicineEntity.Medicinename = dataReader["MedicineName"].ToString();
					}
					if (dataReader["MedicineCompany"] != DBNull.Value)
					{
						hcMedicineEntity.Medicinecompany = dataReader["MedicineCompany"].ToString();
					}
					if (dataReader["MedicineType"] != DBNull.Value)
					{
						hcMedicineEntity.Medicinetype = dataReader["MedicineType"].ToString();
					}
					if (dataReader["ProductCategory"] != DBNull.Value)
					{
						hcMedicineEntity.Productcategory = dataReader["ProductCategory"].ToString();
					}
					if (dataReader["MedicinePrice"] != DBNull.Value)
					{
						hcMedicineEntity.Medicineprice = dataReader["MedicinePrice"].ToString();
					}
					if (dataReader["MedicineImage"] != DBNull.Value)
					{
						hcMedicineEntity.Medicineimage = dataReader["MedicineImage"].ToString();
					}
					if (dataReader["UoM"] != DBNull.Value)
					{
						hcMedicineEntity.Uom = dataReader["UoM"].ToString();
					}
					if (dataReader["StockQnty"] != DBNull.Value)
					{
						hcMedicineEntity.Stockqnty = dataReader["StockQnty"].ToString();
					}
					if (dataReader["CreatedBy"] != DBNull.Value)
					{
						hcMedicineEntity.Createdby = dataReader["CreatedBy"].ToString();
					}
					if (dataReader["CreatedAt"] != DBNull.Value)
					{
						hcMedicineEntity.Createdat = dataReader["CreatedAt"].ToString();
					}
					if (dataReader["UpdateBy"] != DBNull.Value)
					{
						hcMedicineEntity.Updateby = dataReader["UpdateBy"].ToString();
					}
					if (dataReader["UpdatedAt"] != DBNull.Value)
					{
						hcMedicineEntity.Updatedat = dataReader["UpdatedAt"].ToString();
					}
					if (dataReader["Status"] != DBNull.Value)
					{
						hcMedicineEntity.Status = dataReader["Status"].ToString();
					}
				}
			}
			return hcMedicineEntity;
		}

		#endregion

	}
}

