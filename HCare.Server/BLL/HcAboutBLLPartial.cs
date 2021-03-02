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
	public partial class HcAboutBLL
	{
		public object GetAllHcAboutRecord(object param)
		{
			object retObj = null;
			HcAboutDAL hcAboutDAL = new HcAboutDAL();
			retObj = (object)hcAboutDAL.GetAllHcAboutRecord(param);
			return retObj;
		}

	}
}

