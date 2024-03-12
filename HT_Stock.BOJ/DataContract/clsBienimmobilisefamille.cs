using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsBienimmobilisefamille : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _PS_CODESOUSPRODUIT = "";
		private string _PL_CODENUMCOMPTE = "";
        private string _NT_CODENATUREBIEN = "";
        private string _PS_CODESOUSPRODUITCOMPTEAMORTISSEMENT = "";
		private string _PS_LIBELLE = "";
		private string _PS_DUREEMINIMUM = "0";
		private string _PS_DUREEMAXIMUM = "0";
		private string _PS_AMORTISSEMENTDIRECT = "";
		private string _PS_AMORTISSEMENTBIEN = "";
		private string _PS_AMORTISSEMENTVALEURRESIDUELLEZERO = "0";
		private string _PS_ACTIF = "";
		private string _PS_NUMEROORDRE = "0";
		private string _PS_DATESAISIE = "01/01/1900";
		private string _PL_NUMCOMPTE = "";


		#endregion

		#region ACCESSEURS

		public string PS_CODESOUSPRODUIT
		{
			get { return _PS_CODESOUSPRODUIT; }
			set {  _PS_CODESOUSPRODUIT = value; }
		}

		public string PL_CODENUMCOMPTE
		{
			get { return _PL_CODENUMCOMPTE; }
			set {  _PL_CODENUMCOMPTE = value; }
		}


        public string NT_CODENATUREBIEN
        {
	        get { return _NT_CODENATUREBIEN; }
	        set { _NT_CODENATUREBIEN = value; }
        }

        public string PS_CODESOUSPRODUITCOMPTEAMORTISSEMENT
        {
	        get { return _PS_CODESOUSPRODUITCOMPTEAMORTISSEMENT; }
	        set { _PS_CODESOUSPRODUITCOMPTEAMORTISSEMENT = value; }
        }

		public string PS_LIBELLE
		{
			get { return _PS_LIBELLE; }
			set {  _PS_LIBELLE = value; }
		}

		public string PS_DUREEMINIMUM
		{
			get { return _PS_DUREEMINIMUM; }
			set {  _PS_DUREEMINIMUM = value; }
		}

		public string PS_DUREEMAXIMUM
		{
			get { return _PS_DUREEMAXIMUM; }
			set {  _PS_DUREEMAXIMUM = value; }
		}

		public string PS_AMORTISSEMENTDIRECT
		{
			get { return _PS_AMORTISSEMENTDIRECT; }
			set {  _PS_AMORTISSEMENTDIRECT = value; }
		}

		public string PS_AMORTISSEMENTBIEN
		{
			get { return _PS_AMORTISSEMENTBIEN; }
			set {  _PS_AMORTISSEMENTBIEN = value; }
		}

		public string PS_AMORTISSEMENTVALEURRESIDUELLEZERO
		{
			get { return _PS_AMORTISSEMENTVALEURRESIDUELLEZERO; }
			set {  _PS_AMORTISSEMENTVALEURRESIDUELLEZERO = value; }
		}

		public string PS_ACTIF
		{
			get { return _PS_ACTIF; }
			set {  _PS_ACTIF = value; }
		}

		public string PS_NUMEROORDRE
		{
			get { return _PS_NUMEROORDRE; }
			set {  _PS_NUMEROORDRE = value; }
		}

		public string PS_DATESAISIE
		{
			get { return _PS_DATESAISIE; }
			set {  _PS_DATESAISIE = value; }
		}
		public string PL_NUMCOMPTE
        {
			get { return _PL_NUMCOMPTE; }
			set { _PL_NUMCOMPTE = value; }
		}

		#endregion

		#region INSTANCIATEURS

		public clsBienimmobilisefamille(){}
		
		public clsBienimmobilisefamille(clsBienimmobilisefamille clsBienimmobilisefamille)
		{
			this.PS_CODESOUSPRODUIT = clsBienimmobilisefamille.PS_CODESOUSPRODUIT;
			this.PL_CODENUMCOMPTE = clsBienimmobilisefamille.PL_CODENUMCOMPTE;
            this.NT_CODENATUREBIEN = clsBienimmobilisefamille.NT_CODENATUREBIEN;
            this.PS_CODESOUSPRODUITCOMPTEAMORTISSEMENT = clsBienimmobilisefamille.PS_CODESOUSPRODUITCOMPTEAMORTISSEMENT;

			this.PS_LIBELLE = clsBienimmobilisefamille.PS_LIBELLE;
			this.PS_DUREEMINIMUM = clsBienimmobilisefamille.PS_DUREEMINIMUM;
			this.PS_DUREEMAXIMUM = clsBienimmobilisefamille.PS_DUREEMAXIMUM;
			this.PS_AMORTISSEMENTDIRECT = clsBienimmobilisefamille.PS_AMORTISSEMENTDIRECT;
			this.PS_AMORTISSEMENTBIEN = clsBienimmobilisefamille.PS_AMORTISSEMENTBIEN;
			this.PS_AMORTISSEMENTVALEURRESIDUELLEZERO = clsBienimmobilisefamille.PS_AMORTISSEMENTVALEURRESIDUELLEZERO;
			this.PS_ACTIF = clsBienimmobilisefamille.PS_ACTIF;
			this.PS_NUMEROORDRE = clsBienimmobilisefamille.PS_NUMEROORDRE;
			this.PS_DATESAISIE = clsBienimmobilisefamille.PS_DATESAISIE;
			this.PL_NUMCOMPTE = clsBienimmobilisefamille.PL_NUMCOMPTE;
		}

		#endregion

	}
}
