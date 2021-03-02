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
	public partial class HcMedicinetypeDAL
	{
		public DataTable GetAllHcMedicinetypeRecord(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
            string sql = "SELECT ID, MedicineTypeName, status , imageUrl FROM HC_MedicineType Where status = 'Active'";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			DataSet ds = db.ExecuteDataSet(dbCommand);
			return ds.Tables[0];
		}

	}
}

