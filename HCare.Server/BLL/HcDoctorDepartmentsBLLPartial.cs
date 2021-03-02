using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCare.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using HCare.Server.DAL;

namespace HCare.Server.BLL
{
	public partial class HcDoctorDepartmentsBLL
	{
		public object GetAllHcDoctorDepartmentsRecord(object param)
		{
			object retObj = null;
			HcDoctorDepartmentsDAL hcDoctorDepartmentsDAL = new HcDoctorDepartmentsDAL();
			retObj = (object)hcDoctorDepartmentsDAL.GetAllHcDoctorDepartmentsRecord(param);
			return retObj;
		}

	}
}

