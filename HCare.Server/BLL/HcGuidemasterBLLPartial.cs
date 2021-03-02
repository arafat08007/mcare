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
	public partial class HcGuidemasterBLL
	{
		public object GetAllHcGuidemasterRecord(object param)
		{
			object retObj = null;
			HcGuidemasterDAL hcGuidemasterDAL = new HcGuidemasterDAL();
			retObj = (object)hcGuidemasterDAL.GetAllHcGuidemasterRecord(param);
			return retObj;
		}

	}
}

