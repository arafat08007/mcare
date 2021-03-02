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
	public partial class HcLabTestBLL
	{
		public object GetAllHcLabTestRecord(object param)
		{
			object retObj = null;
			HcLabTestDAL hcLabTestDAL = new HcLabTestDAL();
			retObj = (object)hcLabTestDAL.GetAllHcLabTestRecord(param);
			return retObj;
		}

	}
}

