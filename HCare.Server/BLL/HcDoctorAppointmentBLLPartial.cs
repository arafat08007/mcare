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
	public partial class HcDoctorAppointmentBLL
	{
		public object GetAllHcDoctorAppointmentRecord(object param)
		{
			object retObj = null;
			HcDoctorAppointmentDAL hcDoctorAppointmentDAL = new HcDoctorAppointmentDAL();
			retObj = (object)hcDoctorAppointmentDAL.GetAllHcDoctorAppointmentRecord(param);
			return retObj;
		}

	}
}

