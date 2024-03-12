using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsPhaparpupopmenumodegestion
	{
		#region VARIABLES LOCALES

		private string _MG_CODEMODEGESTION = "";
		private string _MG_LIBELLE = "";
		private string _MG_ACTIF = "";
        private string _MG_ENTREPOTOBLIGATOIRE = "";
		#endregion

		#region ACCESSEURS

		public string MG_CODEMODEGESTION
		{
			get { return _MG_CODEMODEGESTION; }
			set {  _MG_CODEMODEGESTION = value; }
		}

		public string MG_LIBELLE
		{
			get { return _MG_LIBELLE; }
			set {  _MG_LIBELLE = value; }
		}

		public string MG_ACTIF
		{
			get { return _MG_ACTIF; }
			set {  _MG_ACTIF = value; }
		}

        public string MG_ENTREPOTOBLIGATOIRE
        {
            get { return _MG_ENTREPOTOBLIGATOIRE; }
            set { _MG_ENTREPOTOBLIGATOIRE = value; }
        }
		#endregion

		#region INSTANCIATEURS

		public clsPhaparpupopmenumodegestion(){}
		public clsPhaparpupopmenumodegestion( string MG_CODEMODEGESTION,string MG_LIBELLE,string MG_ACTIF)
		{
			this.MG_CODEMODEGESTION = MG_CODEMODEGESTION;
			this.MG_LIBELLE = MG_LIBELLE;
			this.MG_ACTIF = MG_ACTIF;
            this.MG_ENTREPOTOBLIGATOIRE = MG_ENTREPOTOBLIGATOIRE;
		}
		public clsPhaparpupopmenumodegestion(clsPhaparpupopmenumodegestion clsPhaparpupopmenumodegestion)
		{
			this.MG_CODEMODEGESTION = clsPhaparpupopmenumodegestion.MG_CODEMODEGESTION;
			this.MG_LIBELLE = clsPhaparpupopmenumodegestion.MG_LIBELLE;
			this.MG_ACTIF = clsPhaparpupopmenumodegestion.MG_ACTIF;
            this.MG_ENTREPOTOBLIGATOIRE = clsPhaparpupopmenumodegestion.MG_ENTREPOTOBLIGATOIRE;

		}

		#endregion

	}
}
