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
	public partial class HcDoctorTimesBLL
	{
		public object GetAllHcDoctorTimesRecord(object param)
		{
			object retObj = null;
			HcDoctorTimesDAL hcDoctorTimesDAL = new HcDoctorTimesDAL();
			retObj = (object)hcDoctorTimesDAL.GetAllHcDoctorTimesRecord(param);
			return retObj;
		}

	}
}

