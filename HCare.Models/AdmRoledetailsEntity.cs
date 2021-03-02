using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace HCare.Models
{
	public class AdmRoledetailsEntity
	{
		public string Id
		{
			get;
			set;
		}
		public string Roleid
		{
			get;
			set;
		}
		public string Featureid
		{
			get;
			set;
		}
		public string Isview
		{
			get;
			set;
		}
		public string Isadd
		{
			get;
			set;
		}
		public string Isedit
		{
			get;
			set;
		}
		public string Isdelete
		{
			get;
			set;
		}

        public string Isactive { get; set; }
	}
}

