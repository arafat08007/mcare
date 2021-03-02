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
	public partial class HcDoctorassesmentDAL
	{
		public DataTable GetAllHcDoctorassesmentRecord(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sql = "SELECT Id, PatientId, DoctorId, DiseaseId, isAttachment, AttachmentPath, isRx, RxPath, AssesmentType, AssementCommunication, AssesmentDate, AssesmentStartTime, AssesmentEndTime, AssesmentDuration, Status FROM HC_DoctorAssesment";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			DataSet ds = db.ExecuteDataSet(dbCommand);
			return ds.Tables[0];
		}

	}
}

