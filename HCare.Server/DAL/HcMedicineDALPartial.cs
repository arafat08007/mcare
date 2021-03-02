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
		public DataTable GetAllHcMedicineRecord(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
            string sql = "";
            HcMedicineEntity obj = new HcMedicineEntity();
            if (param != null) obj = (HcMedicineEntity)param;
            if (obj.FullView)
            {
                sql = @" SELECT A.ID, A.MedicineName, A.MedicineCompany,A.ImageUrl, A.MedicineDesc, A.MedicineType, B.MedicineTypeName, A.ProductCategory,C.categoryName, A.MedicinePrice, A.MedicineImage, A.UoM, A.StockQnty, A.CreatedBy, A.CreatedAt, A.UpdateBy, A.UpdatedAt, A.Status 
                            FROM HC_Medicine  A , HC_MedicineType B , HC_ProductCategory C
                            where 1=1
                            And A.Status = 'Active'
                            and A.MedicineType = B.ID
                            and A.ProductCategory = C.ID";
            }
            else { 
                 sql = @"  SELECT A.ID, A.MedicineName, A.MedicineCompany,A.ImageUrl, A.MedicineDesc, A.MedicineType, B.MedicineTypeName, A.ProductCategory,C.categoryName, A.MedicinePrice, A.MedicineImage, A.UoM, A.StockQnty, A.CreatedBy, A.CreatedAt, A.UpdateBy, A.UpdatedAt, A.Status 
                            FROM HC_Medicine  A , HC_MedicineType B , HC_ProductCategory C
                            where 1=1
                            And A.Status = 'Active'
                            and A.MedicineType = B.ID
                            and A.ProductCategory = C.ID";

            }

              

            if (!string.IsNullOrEmpty(obj.Id))
            {
                sql += " And A.ID = '" + obj.Id + "'";

            }
          
            
            if (!string.IsNullOrEmpty(obj.Medicinetype))
                sql += " And A.MedicineType = '" + obj.Medicinetype + "'";
            if (!string.IsNullOrEmpty(obj.Medicinecompany))
                sql += " And A.MedicineCompany Like '%"+ obj.Medicinecompany +"%'";
            if (!string.IsNullOrEmpty(obj.Productcategory))
                sql += " And A.ProductCategory = '" + obj.Productcategory + "'";

            sql += " Order by A.MedicineName Asc";




			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			DataSet ds = db.ExecuteDataSet(dbCommand);
			return ds.Tables[0];
		}
      

	}
}

