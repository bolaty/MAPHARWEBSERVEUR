using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.BOJ
{
	public class clsPhaparprixprestation
	{

        private string _PS_CODEPRESTATION = "";
		private string _TP_CODETYPECLIENT = "";
		private double _PP_MONTANTPRESATION = 0;
		private double _PP_TAUXREMISE = 0;
		private double _PP_MONTANTREMISE = 0;
		private double _PP_TAUXCOMMISSION = 0;
		private double _PP_MONTANTCOMMISSION = 0;
		private DateTime _PP_DATEREMISE1 = DateTime.Parse("01/01/1900");
		private DateTime _PP_DATEREMISE2 = DateTime.Parse("01/01/1900");
		private DateTime _PP_DATETARIFICATION = DateTime.Parse("01/01/1900");



        public string PS_CODEPRESTATION
		{
			get { return _PS_CODEPRESTATION; }
			set { _PS_CODEPRESTATION = value; }
		}
		public string TP_CODETYPECLIENT
		{
			get { return _TP_CODETYPECLIENT; }
			set { _TP_CODETYPECLIENT = value; }
		}
		public double PP_MONTANTPRESATION
		{
			get { return _PP_MONTANTPRESATION; }
			set { _PP_MONTANTPRESATION = value; }
		}
		public double PP_TAUXREMISE
		{
			get { return _PP_TAUXREMISE; }
			set { _PP_TAUXREMISE = value; }
		}
		public double PP_MONTANTREMISE
		{
			get { return _PP_MONTANTREMISE; }
			set { _PP_MONTANTREMISE = value; }
		}
		public double PP_TAUXCOMMISSION
		{
			get { return _PP_TAUXCOMMISSION; }
			set { _PP_TAUXCOMMISSION = value; }
		}
		public double PP_MONTANTCOMMISSION
		{
			get { return _PP_MONTANTCOMMISSION; }
			set { _PP_MONTANTCOMMISSION = value; }
		}
		public DateTime PP_DATEREMISE1
		{
			get { return _PP_DATEREMISE1; }
			set { _PP_DATEREMISE1 = value; }
		}
		public DateTime PP_DATEREMISE2
		{
			get { return _PP_DATEREMISE2; }
			set { _PP_DATEREMISE2 = value; }
		}
		public DateTime PP_DATETARIFICATION
		{
			get { return _PP_DATETARIFICATION; }
			set { _PP_DATETARIFICATION = value; }
		}



        public clsPhaparprixprestation() {} 

		public clsPhaparprixprestation(string PS_CODEPRESTATION,string TP_CODETYPECLIENT,double PP_MONTANTPRESATION,double PP_TAUXREMISE,double PP_MONTANTREMISE,double PP_TAUXCOMMISSION,double PP_MONTANTCOMMISSION,DateTime PP_DATEREMISE1,DateTime PP_DATEREMISE2,DateTime PP_DATETARIFICATION)
		{
			this.PS_CODEPRESTATION = PS_CODEPRESTATION;
			this.TP_CODETYPECLIENT = TP_CODETYPECLIENT;
			this.PP_MONTANTPRESATION = PP_MONTANTPRESATION;
			this.PP_TAUXREMISE = PP_TAUXREMISE;
			this.PP_MONTANTREMISE = PP_MONTANTREMISE;
			this.PP_TAUXCOMMISSION = PP_TAUXCOMMISSION;
			this.PP_MONTANTCOMMISSION = PP_MONTANTCOMMISSION;
			this.PP_DATEREMISE1 = PP_DATEREMISE1;
			this.PP_DATEREMISE2 = PP_DATEREMISE2;
			this.PP_DATETARIFICATION = PP_DATETARIFICATION;
		}

		public clsPhaparprixprestation(clsPhaparprixprestation clsPhaparprixprestation)
		{
			PS_CODEPRESTATION = clsPhaparprixprestation.PS_CODEPRESTATION;
			TP_CODETYPECLIENT = clsPhaparprixprestation.TP_CODETYPECLIENT;
			PP_MONTANTPRESATION = clsPhaparprixprestation.PP_MONTANTPRESATION;
			PP_TAUXREMISE = clsPhaparprixprestation.PP_TAUXREMISE;
			PP_MONTANTREMISE = clsPhaparprixprestation.PP_MONTANTREMISE;
			PP_TAUXCOMMISSION = clsPhaparprixprestation.PP_TAUXCOMMISSION;
			PP_MONTANTCOMMISSION = clsPhaparprixprestation.PP_MONTANTCOMMISSION;
			PP_DATEREMISE1 = clsPhaparprixprestation.PP_DATEREMISE1;
			PP_DATEREMISE2 = clsPhaparprixprestation.PP_DATEREMISE2;
			PP_DATETARIFICATION = clsPhaparprixprestation.PP_DATETARIFICATION;
		}
        }
}