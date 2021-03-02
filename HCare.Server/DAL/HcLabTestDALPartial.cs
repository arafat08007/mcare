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
	public partial class HcLabTestDAL
	{
		public DataTable GetAllHcLabTestRecord(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			//string sql = "SELECT Id, testId, testName, testAmount, testStatus, testCategory, createBy, created_at AS CreatedAt, updateBy, updateDate FROM HC_Lab_test where 1=1";
            string sql = @"SELECT A.Id, A.testId, A.testName, A.testAmount, A.testStatus, A.testCategory, B.catTestName, A.createBy, A.created_at, A.updateBy, A.updateDate FROM HC_Lab_test A , HC_Test_category B WHERE A.testCategory = B.Id And A.testStatus='Active' AND 1=1";
            HcLabTestEntity obj = new HcLabTestEntity();
            if (param != null) obj = (HcLabTestEntity)param;

            if (string.IsNullOrEmpty(obj.Testname))
            {

                if (!string.IsNullOrEmpty(obj.Testcategory))
                    sql += " And A.testCategory = '" + obj.Testcategory + "'";
                if (!string.IsNullOrEmpty(obj.Id))
                    sql += " And A.ID = '" + obj.Id + "'";
            }
            else
            {
                if (!string.IsNullOrEmpty(obj.Testname))
                    sql += " And  UPPER(A.testName)like Upper('%" + obj.Testname + "%')";
            }


			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			DataSet ds = db.ExecuteDataSet(dbCommand);
			return ds.Tables[0];
		}

	}
}

