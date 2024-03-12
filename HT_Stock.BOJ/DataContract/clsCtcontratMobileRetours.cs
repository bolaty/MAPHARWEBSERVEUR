using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsCtcontratMobileRetours : clsEntitieBase
    {
		#region VARIABLES LOCALES
		private string _CA_CODECONTRAT = "";
		private string _AG_CODEAGENCE = "";
		private string _EN_CODEENTREPOT = "";
		private string _CA_NUMPOLICE = "";
		private string _CA_DATESAISIE = "";
		private string _TI_IDTIERS = "";
		private string _CA_DATEEFFET = "";
		private string _CA_DATEECHEANCE = "";
		private String _TI_NUMTIERS = "";
		private String _TI_DENOMINATION = "";
        private string _CA_LIEUNAISSANCE = "";
        private string _MONTANTTTCPLUSAIRSI = "0";
        private string _MONTANTTTCPLUSAIRSINF = "0";
        private string _MONTANTREGLE = "0";
        private string _SOLDE= "0";

        private string _PL_NUMCOMPTETIERS = "";
        private string _NUMEROBORDEREAU = "";
        private string _MS_NUMPIECE = "";
        private string _TI_EMAIL = "";                  	       
        #endregion

		#region ACCESSEURS

		public string CA_CODECONTRAT
		{
			get { return _CA_CODECONTRAT; }
			set {  _CA_CODECONTRAT = value; }
		}

		public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set {  _AG_CODEAGENCE = value; }
		}

		public string EN_CODEENTREPOT
		{
			get { return _EN_CODEENTREPOT; }
			set {  _EN_CODEENTREPOT = value; }
		}

		public string CA_NUMPOLICE
		{
			get { return _CA_NUMPOLICE; }
			set {  _CA_NUMPOLICE = value; }
		}

		public string CA_DATESAISIE
		{
			get { return _CA_DATESAISIE; }
			set {  _CA_DATESAISIE = value; }
		}

		public string TI_IDTIERS
		{
			get { return _TI_IDTIERS; }
			set {  _TI_IDTIERS = value; }
		}

		public string CA_DATEEFFET
		{
			get { return _CA_DATEEFFET; }
			set {  _CA_DATEEFFET = value; }
		}

		public string CA_DATEECHEANCE
		{
			get { return _CA_DATEECHEANCE; }
			set {  _CA_DATEECHEANCE = value; }
		}
        public String TI_NUMTIERS
        {
	        get { return _TI_NUMTIERS; }
	        set { _TI_NUMTIERS = value; }
        }
        public String TI_DENOMINATION
        {
	        get { return _TI_DENOMINATION; }
	        set { _TI_DENOMINATION = value; }
        }

        public String CA_LIEUNAISSANCE
        {
	        get { return _CA_LIEUNAISSANCE; }
	        set { _CA_LIEUNAISSANCE = value; }
        }
        public String MONTANTTTCPLUSAIRSI
        {
	        get { return _MONTANTTTCPLUSAIRSI; }
	        set { _MONTANTTTCPLUSAIRSI = value; }
        }

        public String MONTANTTTCPLUSAIRSINF
        {
	        get { return _MONTANTTTCPLUSAIRSINF; }
	        set { _MONTANTTTCPLUSAIRSINF = value; }
        }

        public String MONTANTREGLE
        {
	        get { return _MONTANTREGLE; }
	        set { _MONTANTREGLE = value; }
        }
        public String SOLDE
        {
	        get { return _SOLDE; }
	        set { _SOLDE = value; }
        }
     
        public String PL_NUMCOMPTETIERS
        {
	        get { return _PL_NUMCOMPTETIERS; }
	        set { _PL_NUMCOMPTETIERS = value; }
        }
        public String NUMEROBORDEREAU
        {
	        get { return _NUMEROBORDEREAU; }
	        set { _NUMEROBORDEREAU = value; }
        }

        public String MS_NUMPIECE
        {
	        get { return _MS_NUMPIECE; }
	        set { _MS_NUMPIECE = value; }
        }
        public String TI_EMAIL
        {
	        get { return _TI_EMAIL; }
	        set { _TI_EMAIL = value; }
        }


		#endregion

		#region INSTANCIATEURS

		public clsCtcontratMobileRetours(){}
		
		public clsCtcontratMobileRetours(clsCtcontratMobileRetours clsCtcontratMobileRetours)
		{
			this.CA_CODECONTRAT = clsCtcontratMobileRetours.CA_CODECONTRAT;
			this.AG_CODEAGENCE = clsCtcontratMobileRetours.AG_CODEAGENCE;
			this.EN_CODEENTREPOT = clsCtcontratMobileRetours.EN_CODEENTREPOT;
			this.CA_NUMPOLICE = clsCtcontratMobileRetours.CA_NUMPOLICE;
			this.CA_DATESAISIE = clsCtcontratMobileRetours.CA_DATESAISIE;
			this.TI_IDTIERS = clsCtcontratMobileRetours.TI_IDTIERS;
			this.CA_DATEEFFET = clsCtcontratMobileRetours.CA_DATEEFFET;
			this.CA_DATEECHEANCE = clsCtcontratMobileRetours.CA_DATEECHEANCE;
			this.TI_NUMTIERS = clsCtcontratMobileRetours.TI_NUMTIERS;
			this.TI_DENOMINATION = clsCtcontratMobileRetours.TI_DENOMINATION;
			this.CA_LIEUNAISSANCE = clsCtcontratMobileRetours.CA_LIEUNAISSANCE;
			this.MONTANTTTCPLUSAIRSI = clsCtcontratMobileRetours.MONTANTTTCPLUSAIRSI;
			this.MONTANTTTCPLUSAIRSINF = clsCtcontratMobileRetours.MONTANTTTCPLUSAIRSINF;
			this.MONTANTREGLE = clsCtcontratMobileRetours.MONTANTREGLE;
			this.SOLDE = clsCtcontratMobileRetours.SOLDE;
			this.NUMEROBORDEREAU = clsCtcontratMobileRetours.NUMEROBORDEREAU;
			this.MS_NUMPIECE = clsCtcontratMobileRetours.MS_NUMPIECE;
			this.TI_EMAIL = clsCtcontratMobileRetours.TI_EMAIL;
		}

		#endregion

	}
}
