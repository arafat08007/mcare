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
	public partial class AdmRolemasterBLL
	{
		public object GetAllAdmRolemasterRecord(object param)
		{
			object retObj = null;
			AdmRolemasterDAL admRolemasterDAL = new AdmRolemasterDAL();
			retObj = (object)admRolemasterDAL.GetAllAdmRolemasterRecord(param);
			return retObj;
		}

	}
}

