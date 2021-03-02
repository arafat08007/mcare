using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace HCare.Models
{
	public class HcUsersEntity
	{
		public string Id
		{
			get;
			set;
		}
		public string Logname
		{
			get;
			set;
		}
		public string Logpass
		{
			get;
			set;
		}
        public string SecurPass
        {
            get;
            set;
        }
        public string Email
        {
            get;
            set;
        }
        public string FirstName
        {
            get;
            set;
        }
        public string LastName
        {
            get;
            set;
        }
        public string username
        {
            get;
            set;
        }
        public string userphone
        {
            get;
            set;
        }
        public string Gender
        {
            get;
            set;
        }
        public string userdob
        {
            get;
            set;
        }
        public string Address
        {
            get;
            set;
        }
        public string Usertype // Admin, Doctor, Patient, Staff
		{
			get;
			set;
		}
		public string Userid
		{
			get;
			set;
		}
		public string Roleid
		{
			get;
			set;
		}
		public string Isactive
		{
			get;
			set;
		}
		public string Createdby
		{
			get;
			set;
		}
		public string Createdtime
		{
			get;
			set;
		}
		public string Updatedby
		{
			get;
			set;
		}
		public string Updatedtime
		{
			get;
			set;
		}
		public string Lastlogin
		{
			get;
			set;
		}
        public string userImageUrl
        {
            get;
            set;
        }


		public string QueryFlag { get; set; }
		public string ConfirmPass { get; set; }
	}
}

