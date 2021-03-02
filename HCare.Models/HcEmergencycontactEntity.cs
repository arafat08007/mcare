using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace HCare.Models
{
	public class HcEmergencycontactEntity
	{
		
		public string Userid
		{
			get;
			set;
		}
        public string Address
        {
            get;
            set;
        }
        public string Userphone
        {
            get;
            set;
        }
        public string postcode
        {
            get;
            set;
        }
		
		public string Createdby
		{
			get;
			set;
		}
		public string Createdat
		{
			get;
			set;
		}
		public string Updateby
		{
			get;
			set;
		}
		public string Upadateat
		{
			get;
			set;
		}

        public string Id
        {
            get;
            set;
        }
        public string Emergencycontactperson
        {
            get;
            set;
        }
        public string Emergencycontactphone
        {
            get;
            set;
        }

        public List<HcEmergencyContactDetails> EmergencyList { get; set; }

	}

    public class HcEmergencyContactDetails {
        public string Id
        {
            get;
            set;
        }
        public string Emergencycontactperson
        {
            get;
            set;
        }
        public string Emergencycontactphone
        {
            get;
            set;
        }
    }

}

