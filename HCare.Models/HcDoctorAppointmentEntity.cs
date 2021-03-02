using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace HCare.Models
{
	public class HcDoctorAppointmentEntity
	{
		public string Id
		{
			get;
			set;
		}
		public string Patientuid
		{
			get;
			set;
		}
        public string PatientName
        {
            get;
            set;
        }

		public string Doctorid
		{
			get;
			set;
		}
		public string Dates
		{
			get;
			set;
		}
		public string Timeid
		{
			get;
			set;
		}
		public string Reasons
		{
			get;
			set;
		}
		public string Paymethod
		{
			get;
			set;
		}
        public string Status // Upcoming, Completed, Cancelled 
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
        public string doctorName
        {
            get;
            set;
        }
        public string speciality
        {
            get;
            set;
        }
          public string doctorDept
                {
                    get;
                    set;
                }
          public string appointmentTime
          {
              get;
              set;
          }

          public string Gender
          {
              get;
              set;
          }
          public string Age
          {
              get;
              set;
          }
          public string SymptompImage
          {
              get;
              set;
          }
          public string RxImg
          {
              get;
              set;
          }

		public string QueryFlag { get; set; }
	}
}

