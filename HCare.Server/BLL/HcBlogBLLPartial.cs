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
	public partial class HcBlogBLL
	{
		public object GetAllHcBlogRecord(object param)
		{
			object retObj = null;
			HcBlogDAL hcBlogDAL = new HcBlogDAL();
			retObj = (object)hcBlogDAL.GetAllHcBlogRecord(param);
			return retObj;
		}

	}
}

