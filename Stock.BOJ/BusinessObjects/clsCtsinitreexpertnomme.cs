using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsCtsinitreexpertnomme
	{
		#region VARIABLES LOCALES

		private string _EP_CODEEXPERTNOMME = "";
		private string _EP_DENOMMINATIONEXPERTNOMME = "";
		private string _EP_CONTACTEXPERTNOMME = "";
		private DateTime _EP_DATESAISIE = DateTime.Parse("01/01/1900");
		private string _OP_CODEOPERATEUR = "";

		#endregion

		#region ACCESSEURS

		public string EP_CODEEXPERTNOMME
		{
			get { return _EP_CODEEXPERTNOMME; }
			set {  _EP_CODEEXPERTNOMME = value; }
		}

		public string EP_DENOMMINATIONEXPERTNOMME
		{
			get { return _EP_DENOMMINATIONEXPERTNOMME; }
			set {  _EP_DENOMMINATIONEXPERTNOMME = value; }
		}

		public string EP_CONTACTEXPERTNOMME
		{
			get { return _EP_CONTACTEXPERTNOMME; }
			set {  _EP_CONTACTEXPERTNOMME = value; }
		}

		public DateTime EP_DATESAISIE
		{
			get { return _EP_DATESAISIE; }
			set {  _EP_DATESAISIE = value; }
		}

		public string OP_CODEOPERATEUR
		{
			get { return _OP_CODEOPERATEUR; }
			set {  _OP_CODEOPERATEUR = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCtsinitreexpertnomme(){}
		public clsCtsinitreexpertnomme( string EP_CODEEXPERTNOMME,string EP_DENOMMINATIONEXPERTNOMME,string EP_CONTACTEXPERTNOMME,DateTime EP_DATESAISIE,string OP_CODEOPERATEUR)
		{
			this.EP_CODEEXPERTNOMME = EP_CODEEXPERTNOMME;
			this.EP_DENOMMINATIONEXPERTNOMME = EP_DENOMMINATIONEXPERTNOMME;
			this.EP_CONTACTEXPERTNOMME = EP_CONTACTEXPERTNOMME;
			this.EP_DATESAISIE = EP_DATESAISIE;
			this.OP_CODEOPERATEUR = OP_CODEOPERATEUR;
		}
		public clsCtsinitreexpertnomme(clsCtsinitreexpertnomme clsCtsinitreexpertnomme)
		{
			this.EP_CODEEXPERTNOMME = clsCtsinitreexpertnomme.EP_CODEEXPERTNOMME;
			this.EP_DENOMMINATIONEXPERTNOMME = clsCtsinitreexpertnomme.EP_DENOMMINATIONEXPERTNOMME;
			this.EP_CONTACTEXPERTNOMME = clsCtsinitreexpertnomme.EP_CONTACTEXPERTNOMME;
			this.EP_DATESAISIE = clsCtsinitreexpertnomme.EP_DATESAISIE;
			this.OP_CODEOPERATEUR = clsCtsinitreexpertnomme.OP_CODEOPERATEUR;
		}

		#endregion

	}
}
