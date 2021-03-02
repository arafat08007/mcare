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
	public partial class HcOffersBLL
	{
		public object GetAllHcOffersRecord(object param)
		{
			object retObj = null;
			HcOffersDAL hcOffersDAL = new HcOffersDAL();
			retObj = (object)hcOffersDAL.GetAllHcOffersRecord(param);
			return retObj;
		}

	}
}

