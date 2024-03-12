using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsPhachangementchambrehistorisation
	{
		#region VARIABLES LOCALES
        private string _AG_CODEAGENCE = "";
		private string _MD_NUMSEQUENCE = "";
		private string _AR_CODEARTICLEDEPART = "";
		private string _AR_CODEARTICLEDESTINATION = "";
		private DateTime _CH_DATECHANGEMENT = DateTime.Parse("01/01/1900");
        private string _OP_CODEOPERATEUR = "";
        private string _CH_MOTIF = "";
        private string _TI_IDATTRIBUTION = "";

		#endregion

        public string AG_CODEAGENCE
        {
            get { return _AG_CODEAGENCE; }
            set { _AG_CODEAGENCE = value; }
        }

		#region ACCESSEURS

		public string MD_NUMSEQUENCE
		{
			get { return _MD_NUMSEQUENCE; }
			set {  _MD_NUMSEQUENCE = value; }
		}

		public string AR_CODEARTICLEDEPART
		{
			get { return _AR_CODEARTICLEDEPART; }
			set {  _AR_CODEARTICLEDEPART = value; }
		}

		public string AR_CODEARTICLEDESTINATION
		{
			get { return _AR_CODEARTICLEDESTINATION; }
			set {  _AR_CODEARTICLEDESTINATION = value; }
		}

		public DateTime CH_DATECHANGEMENT
		{
			get { return _CH_DATECHANGEMENT; }
			set {  _CH_DATECHANGEMENT = value; }
		}

        public string CH_MOTIF
		{
            get { return _CH_MOTIF; }
            set { _CH_MOTIF = value; }
		}
        public string OP_CODEOPERATEUR 
		{
            get { return _OP_CODEOPERATEUR; }
            set { _OP_CODEOPERATEUR = value; }
		}

        public string TI_IDATTRIBUTION 
		{
            get { return _TI_IDATTRIBUTION; }
            set { _TI_IDATTRIBUTION = value; }
		}
		#endregion

		#region INSTANCIATEURS

		public clsPhachangementchambrehistorisation(){}
		
		public clsPhachangementchambrehistorisation(clsPhachangementchambrehistorisation clsPhachangementchambrehistorisation)
		{
            this.AG_CODEAGENCE = clsPhachangementchambrehistorisation.AG_CODEAGENCE;
			this.MD_NUMSEQUENCE = clsPhachangementchambrehistorisation.MD_NUMSEQUENCE;
			this.AR_CODEARTICLEDEPART = clsPhachangementchambrehistorisation.AR_CODEARTICLEDEPART;
			this.AR_CODEARTICLEDESTINATION = clsPhachangementchambrehistorisation.AR_CODEARTICLEDESTINATION;
			this.CH_DATECHANGEMENT = clsPhachangementchambrehistorisation.CH_DATECHANGEMENT;
            this.CH_MOTIF = clsPhachangementchambrehistorisation.CH_MOTIF;
            this.OP_CODEOPERATEUR = clsPhachangementchambrehistorisation.OP_CODEOPERATEUR;
            this.TI_IDATTRIBUTION = clsPhachangementchambrehistorisation.TI_IDATTRIBUTION;

		}

		#endregion

	}
}
