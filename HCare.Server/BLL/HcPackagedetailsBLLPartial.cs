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
	public partial class HcPackagedetailsBLL
	{
		public object GetAllHcPackagedetailsRecord(object param)
		{
			object retObj = null;
			HcPackagedetailsDAL hcPackagedetailsDAL = new HcPackagedetailsDAL();
			retObj = (object)hcPackagedetailsDAL.GetAllHcPackagedetailsRecord(param);
			return retObj;
		}

	}
}

