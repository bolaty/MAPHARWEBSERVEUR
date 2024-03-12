using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsSmsgateway
	{
		#region VARIABLES LOCALES

		private double _GW_CODEGATEWAY = 0;
		private string _GW_MARQUE = "";
		private string _GW_MODELE = "";
		private string _GW_PORT = "";
		private string _GW_ADRESSEIP = "";
		private string _GW_PIN = "";
		private string _GW_ACTIF = "";

		#endregion

		#region ACCESSEURS

		public double GW_CODEGATEWAY
		{
			get { return _GW_CODEGATEWAY; }
			set {  _GW_CODEGATEWAY = value; }
		}

		public string GW_MARQUE
		{
			get { return _GW_MARQUE; }
			set {  _GW_MARQUE = value; }
		}

		public string GW_MODELE
		{
			get { return _GW_MODELE; }
			set {  _GW_MODELE = value; }
		}

		public string GW_PORT
		{
			get { return _GW_PORT; }
			set {  _GW_PORT = value; }
		}

		public string GW_ADRESSEIP
		{
			get { return _GW_ADRESSEIP; }
			set {  _GW_ADRESSEIP = value; }
		}

		public string GW_PIN
		{
			get { return _GW_PIN; }
			set {  _GW_PIN = value; }
		}

		public string GW_ACTIF
		{
			get { return _GW_ACTIF; }
			set {  _GW_ACTIF = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsSmsgateway(){}
		public clsSmsgateway( double GW_CODEGATEWAY,string GW_MARQUE,string GW_MODELE,string GW_PORT,string GW_ADRESSEIP,string GW_PIN,string GW_ACTIF)
		{
			this.GW_CODEGATEWAY = GW_CODEGATEWAY;
			this.GW_MARQUE = GW_MARQUE;
			this.GW_MODELE = GW_MODELE;
			this.GW_PORT = GW_PORT;
			this.GW_ADRESSEIP = GW_ADRESSEIP;
			this.GW_PIN = GW_PIN;
			this.GW_ACTIF = GW_ACTIF;
		}
		public clsSmsgateway(clsSmsgateway clsSmsgateway)
		{
			this.GW_CODEGATEWAY = clsSmsgateway.GW_CODEGATEWAY;
			this.GW_MARQUE = clsSmsgateway.GW_MARQUE;
			this.GW_MODELE = clsSmsgateway.GW_MODELE;
			this.GW_PORT = clsSmsgateway.GW_PORT;
			this.GW_ADRESSEIP = clsSmsgateway.GW_ADRESSEIP;
			this.GW_PIN = clsSmsgateway.GW_PIN;
			this.GW_ACTIF = clsSmsgateway.GW_ACTIF;
		}

		#endregion

	}
}
