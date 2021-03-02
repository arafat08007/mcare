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
	public partial class HcDoctorassesmentBLL
	{
		public object GetAllHcDoctorassesmentRecord(object param)
		{
			object retObj = null;
			HcDoctorassesmentDAL hcDoctorassesmentDAL = new HcDoctorassesmentDAL();
			retObj = (object)hcDoctorassesmentDAL.GetAllHcDoctorassesmentRecord(param);
			return retObj;
		}

	}
}

