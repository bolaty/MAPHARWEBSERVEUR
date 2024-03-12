using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsPhaparnaturetypearticle : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _NT_CODENATURETYPEARTICLE = "";
		private string _TA_CODETYPEARTICLE = "";
		private string _PS_CODEPRESTATION = "";
		private string _AR_CODEARTICLE = "";
		private string _NT_LIBELLE = "";
		private string _PP_CODEMODEGESTION = "";
		#endregion

		#region ACCESSEURS

		public string NT_CODENATURETYPEARTICLE
		{
			get { return _NT_CODENATURETYPEARTICLE; }
			set {  _NT_CODENATURETYPEARTICLE = value; }
		}

		public string TA_CODETYPEARTICLE
		{
			get { return _TA_CODETYPEARTICLE; }
			set {  _TA_CODETYPEARTICLE = value; }
		}

		public string PS_CODEPRESTATION
		{
			get { return _PS_CODEPRESTATION; }
			set {  _PS_CODEPRESTATION = value; }
		}

		public string AR_CODEARTICLE
		{
			get { return _AR_CODEARTICLE; }
			set {  _AR_CODEARTICLE = value; }
		}

		public string NT_LIBELLE
		{
			get { return _NT_LIBELLE; }
			set {  _NT_LIBELLE = value; }
		}
        public string PP_CODEMODEGESTION
        {
	        get { return _PP_CODEMODEGESTION; }
	        set { _PP_CODEMODEGESTION = value; }
        }

		#endregion

		#region INSTANCIATEURS

		public clsPhaparnaturetypearticle(){}

		public clsPhaparnaturetypearticle(clsPhaparnaturetypearticle clsPhaparnaturetypearticle)
		{
			this.NT_CODENATURETYPEARTICLE = clsPhaparnaturetypearticle.NT_CODENATURETYPEARTICLE;
			this.TA_CODETYPEARTICLE = clsPhaparnaturetypearticle.TA_CODETYPEARTICLE;
			this.PS_CODEPRESTATION = clsPhaparnaturetypearticle.PS_CODEPRESTATION;
			this.AR_CODEARTICLE = clsPhaparnaturetypearticle.AR_CODEARTICLE;
			this.NT_LIBELLE = clsPhaparnaturetypearticle.NT_LIBELLE;
			this.PP_CODEMODEGESTION = clsPhaparnaturetypearticle.PP_CODEMODEGESTION;
		}

		#endregion

	}
}
