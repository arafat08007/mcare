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
	public partial class AdmRoledetailsBLL
	{
		public object GetAllAdmRoledetailsRecord(object param)
		{
			object retObj = null;
			AdmRoledetailsDAL admRoledetailsDAL = new AdmRoledetailsDAL();
			retObj = (object)admRoledetailsDAL.GetAllAdmRoledetailsRecord(param);
			return retObj;
		}

	}
}

