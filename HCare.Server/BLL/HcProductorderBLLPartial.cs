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
	public partial class HcProductorderBLL
	{
		public object GetAllHcProductorderRecord(object param)
		{
			object retObj = null;
			HcProductorderDAL hcProductorderDAL = new HcProductorderDAL();
			retObj = (object)hcProductorderDAL.GetAllHcProductorderRecord(param);
			return retObj;
		}

	}
}

