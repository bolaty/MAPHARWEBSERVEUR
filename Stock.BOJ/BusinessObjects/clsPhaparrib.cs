using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsPhaparrib
	{
		#region VARIABLES LOCALES

		private string _RIB_CODERIB = "";
		private string _DE_CODEDEVISE = "";
		private string _PY_CODEPAYS = "";
		private string _LO_CODELOCALE = "";
		private string _RIB_CODEBANQUE = "";
		private string _RIB_CODEQUICHET = "";
		private string _RIB_NUMCOMPTE = "";
		private string _RIB_CLE = "";
		private string _RIB_COMMENTAIRE = "";
		private string _JO_CODEJOURNAL = "";
        private string _RIB_ABREGE = "";

        private string _AB_CODEAGENCEBANCAIRE = "";


		#endregion

		#region ACCESSEURS

		public string RIB_CODERIB
		{
			get { return _RIB_CODERIB; }
			set {  _RIB_CODERIB = value; }
		}

		public string DE_CODEDEVISE
		{
			get { return _DE_CODEDEVISE; }
			set {  _DE_CODEDEVISE = value; }
		}

		public string PY_CODEPAYS
		{
			get { return _PY_CODEPAYS; }
			set {  _PY_CODEPAYS = value; }
		}

		public string LO_CODELOCALE
		{
			get { return _LO_CODELOCALE; }
			set {  _LO_CODELOCALE = value; }
		}

		public string RIB_CODEBANQUE
		{
			get { return _RIB_CODEBANQUE; }
			set {  _RIB_CODEBANQUE = value; }
		}

		public string RIB_CODEQUICHET
		{
			get { return _RIB_CODEQUICHET; }
			set {  _RIB_CODEQUICHET = value; }
		}

		public string RIB_NUMCOMPTE
		{
			get { return _RIB_NUMCOMPTE; }
			set {  _RIB_NUMCOMPTE = value; }
		}

		public string RIB_CLE
		{
			get { return _RIB_CLE; }
			set {  _RIB_CLE = value; }
		}

		public string RIB_COMMENTAIRE
		{
			get { return _RIB_COMMENTAIRE; }
			set {  _RIB_COMMENTAIRE = value; }
		}

		public string JO_CODEJOURNAL
		{
			get { return _JO_CODEJOURNAL; }
			set {  _JO_CODEJOURNAL = value; }
		}

        public string RIB_ABREGE
        {
            get { return _RIB_ABREGE; }
            set { _RIB_ABREGE = value; }
        }

        public string AB_CODEAGENCEBANCAIRE
        {
            get { return _AB_CODEAGENCEBANCAIRE; }
            set { _AB_CODEAGENCEBANCAIRE = value; }
        }


		#endregion

		#region INSTANCIATEURS

		public clsPhaparrib(){}
		
		public clsPhaparrib(clsPhaparrib clsPhaparrib)
		{
			this.RIB_CODERIB = clsPhaparrib.RIB_CODERIB;
			this.DE_CODEDEVISE = clsPhaparrib.DE_CODEDEVISE;
			this.PY_CODEPAYS = clsPhaparrib.PY_CODEPAYS;
			this.LO_CODELOCALE = clsPhaparrib.LO_CODELOCALE;
			this.RIB_CODEBANQUE = clsPhaparrib.RIB_CODEBANQUE;
			this.RIB_CODEQUICHET = clsPhaparrib.RIB_CODEQUICHET;
			this.RIB_NUMCOMPTE = clsPhaparrib.RIB_NUMCOMPTE;
			this.RIB_CLE = clsPhaparrib.RIB_CLE;
			this.RIB_COMMENTAIRE = clsPhaparrib.RIB_COMMENTAIRE;
			this.JO_CODEJOURNAL = clsPhaparrib.JO_CODEJOURNAL;
            this.RIB_ABREGE = clsPhaparrib.RIB_ABREGE;
            this.AB_CODEAGENCEBANCAIRE = clsPhaparrib.AB_CODEAGENCEBANCAIRE;
		}

		#endregion

	}
}
