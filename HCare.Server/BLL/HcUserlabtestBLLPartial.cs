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
	public partial class HcUserlabtestBLL
	{
		public object GetAllHcUserlabtestRecord(object param)
		{
			object retObj = null;
			HcUserlabtestDAL hcUserlabtestDAL = new HcUserlabtestDAL();
			retObj = (object)hcUserlabtestDAL.GetAllHcUserlabtestRecord(param);
			return retObj;
		}

	}
}

