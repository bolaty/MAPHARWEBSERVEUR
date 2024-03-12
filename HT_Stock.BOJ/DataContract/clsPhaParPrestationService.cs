using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Stock.BOJ
{
	public class clsPhaparprestationservice
	{

        private string _PS_CODEPRESTATION = "";
		private string _TP_CODETYPEPRESTATION = "";
		private string _PS_NOMPRESATION = "";
		private string _PS_DESCRIPTION = "";
        private string _PS_STATUT = "N";
		private string _PS_ASDI = "N";
		private string _PS_TVA = "O";
        private DateTime  _PS_DATECLOTURE = DateTime.Parse("01/01/1900");



        public string PS_CODEPRESTATION
		{
			get { return _PS_CODEPRESTATION; }
			set { _PS_CODEPRESTATION = value; }
		}
		public string TP_CODETYPEPRESTATION
		{
			get { return _TP_CODETYPEPRESTATION; }
			set { _TP_CODETYPEPRESTATION = value; }
		}
		public string PS_NOMPRESATION
		{
			get { return _PS_NOMPRESATION; }
			set { _PS_NOMPRESATION = value; }
		}
		public string PS_DESCRIPTION
		{
			get { return _PS_DESCRIPTION; }
			set { _PS_DESCRIPTION = value; }
		}
		public string PS_STATUT
		{
			get { return _PS_STATUT; }
			set { _PS_STATUT = value; }
		}
		public string PS_ASDI
		{
			get { return _PS_ASDI; }
			set { _PS_ASDI = value; }
		}
		public string PS_TVA
		{
			get { return _PS_TVA; }
			set { _PS_TVA = value; }
		}
        public  DateTime PS_DATECLOTURE
        {
            get { return _PS_DATECLOTURE; }
            set { _PS_DATECLOTURE = value; }
		}


        public clsPhaparprestationservice() {}

        public clsPhaparprestationservice(string PS_CODEPRESTATION, string TP_CODETYPEPRESTATION, string PS_NOMPRESATION, string PS_DESCRIPTION, string PS_STATUT, string PS_ASDI, string PS_TVA, DateTime PS_DATECLOTURE)
		{
			this.PS_CODEPRESTATION = PS_CODEPRESTATION;
			this.TP_CODETYPEPRESTATION = TP_CODETYPEPRESTATION;
			this.PS_NOMPRESATION = PS_NOMPRESATION;
			this.PS_DESCRIPTION = PS_DESCRIPTION;
			this.PS_STATUT = PS_STATUT;
			this.PS_ASDI = PS_ASDI;
			this.PS_TVA = PS_TVA;
            this._PS_DATECLOTURE = PS_DATECLOTURE;
		}

		public clsPhaparprestationservice(clsPhaparprestationservice clsPhaparprestationservice)
		{
			PS_CODEPRESTATION = clsPhaparprestationservice.PS_CODEPRESTATION;
			TP_CODETYPEPRESTATION = clsPhaparprestationservice.TP_CODETYPEPRESTATION;
			PS_NOMPRESATION = clsPhaparprestationservice.PS_NOMPRESATION;
			PS_DESCRIPTION = clsPhaparprestationservice.PS_DESCRIPTION;
			PS_STATUT = clsPhaparprestationservice.PS_STATUT;
			PS_ASDI = clsPhaparprestationservice.PS_ASDI;
			PS_TVA = clsPhaparprestationservice.PS_TVA;
            PS_DATECLOTURE = clsPhaparprestationservice.PS_DATECLOTURE;

		}

        }
}