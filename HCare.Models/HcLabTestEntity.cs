using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace HCare.Models
{
	public class HcLabTestEntity
	{
		public string Id
		{
			get;
			set;
		}
		public string Testid
		{
			get;
			set;
		}
		public string Testname
		{
			get;
			set;
		}
		public string Testamount
		{
			get;
			set;
		}
		public string Teststatus
		{
			get;
			set;
		}
		public string Testcategory
		{
			get;
			set;
		}
		public string Createby
		{
			get;
			set;
		}
		public string CreatedAt
		{
			get;
			set;
		}
		public string Updateby
		{
			get;
			set;
		}
		public string Updatedate
		{
			get;
			set;
		}

        public string catTestName { get; set; }
    }
}

