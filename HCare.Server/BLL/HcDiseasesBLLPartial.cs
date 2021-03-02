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
	public partial class HcDiseasesBLL
	{
		public object GetAllHcDiseasesRecord(object param)
		{
			object retObj = null;
			HcDiseasesDAL hcDiseasesDAL = new HcDiseasesDAL();
			retObj = (object)hcDiseasesDAL.GetAllHcDiseasesRecord(param);
			return retObj;
		}

	}
}

