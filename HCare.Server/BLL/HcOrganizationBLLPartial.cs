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
	public partial class HcOrganizationBLL
	{
		public object GetAllHcOrganizationRecord(object param)
		{
			object retObj = null;
			HcOrganizationDAL hcOrganizationDAL = new HcOrganizationDAL();
			retObj = (object)hcOrganizationDAL.GetAllHcOrganizationRecord(param);
			return retObj;
		}

	}
}

