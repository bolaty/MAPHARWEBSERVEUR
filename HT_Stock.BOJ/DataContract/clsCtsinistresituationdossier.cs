using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsCtsinistresituationdossier : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _SI_CODESINISTRE = "";
		private string _SD_CODESITUATIONDOSSIER = "";
        private string _SD_LIBELLESITUATIONDOSSIER = "";
        private string _SI_DATESAISIE = "01-01-1900";
		private string _OP_CODEOPERATEUR = "";
		private string _COCHER = "";
		#endregion

		#region ACCESSEURS

		public string SI_CODESINISTRE
		{
			get { return _SI_CODESINISTRE; }
			set {  _SI_CODESINISTRE = value; }
		}

		public string SD_CODESITUATIONDOSSIER
		{
			get { return _SD_CODESITUATIONDOSSIER; }
			set {  _SD_CODESITUATIONDOSSIER = value; }
		}

        public string SD_LIBELLESITUATIONDOSSIER
        {
            get { return _SD_LIBELLESITUATIONDOSSIER; }
            set { _SD_LIBELLESITUATIONDOSSIER = value; }
        }

        public string SI_DATESAISIE
		{
			get { return _SI_DATESAISIE; }
			set {  _SI_DATESAISIE = value; }
		}

		public string OP_CODEOPERATEUR
		{
			get { return _OP_CODEOPERATEUR; }
			set {  _OP_CODEOPERATEUR = value; }
		}
        public string COCHER
        {
	        get { return _COCHER; }
	        set { _COCHER = value; }
        }

		#endregion

		#region INSTANCIATEURS

		public clsCtsinistresituationdossier(){}

		public clsCtsinistresituationdossier(clsCtsinistresituationdossier clsCtsinistresituationdossier)
		{
			this.SI_CODESINISTRE = clsCtsinistresituationdossier.SI_CODESINISTRE;
			this.SD_CODESITUATIONDOSSIER = clsCtsinistresituationdossier.SD_CODESITUATIONDOSSIER;
            this.SD_LIBELLESITUATIONDOSSIER = clsCtsinistresituationdossier.SD_LIBELLESITUATIONDOSSIER;
            this.SI_DATESAISIE = clsCtsinistresituationdossier.SI_DATESAISIE;
			this.OP_CODEOPERATEUR = clsCtsinistresituationdossier.OP_CODEOPERATEUR;
			this.COCHER = clsCtsinistresituationdossier.COCHER;
		}

		#endregion

	}
}
