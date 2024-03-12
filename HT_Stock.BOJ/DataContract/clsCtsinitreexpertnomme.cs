using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsCtsinitreexpertnomme : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _EP_CODEEXPERTNOMME = "";
		private string _EP_DENOMMINATIONEXPERTNOMME = "";
		private string _EP_CONTACTEXPERTNOMME = "";
		private string _EP_DATESAISIE = "";
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

		public string EP_DATESAISIE
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
