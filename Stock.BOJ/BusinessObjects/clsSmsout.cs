using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsSmsout
	{
		#region VARIABLES LOCALES

		private string _AG_CODEAGENCE = "";
		private string _SM_DATEPIECE = "";
		private string _SM_NUMPIECE = "";
		private string _SM_NUMSEQUENCE = "";
		private string _CO_CODECOMPTE = "";
		private string _SM_MESSAGE = "";
		private string _SM_TELEPHONE = "";
		private string _SM_STATUT = "";
        private DateTime _SM_DATESAISIE = DateTime.Parse("01/01/1900");


        private string _TE_CODESMSTYPEOPERATION = "";
        private string _SL_CODEMESSAGE = "";
        private string _SL_RESULTAT = "";
        private string _SL_MESSAGE = "";
        private string _SL_MESSAGEOBJET = "";
        private string _AG_EMAIL = "";
        private string _AG_EMAILMOTDEPASSE = "";
       

        #endregion

        #region ACCESSEURS

        public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set {  _AG_CODEAGENCE = value; }
		}

		public string SM_DATEPIECE
		{
			get { return _SM_DATEPIECE; }
			set {  _SM_DATEPIECE = value; }
		}

		public string SM_NUMPIECE
		{
			get { return _SM_NUMPIECE; }
			set {  _SM_NUMPIECE = value; }
		}

		public string SM_NUMSEQUENCE
		{
			get { return _SM_NUMSEQUENCE; }
			set {  _SM_NUMSEQUENCE = value; }
		}

		public string CO_CODECOMPTE
		{
			get { return _CO_CODECOMPTE; }
			set {  _CO_CODECOMPTE = value; }
		}

		public string SM_MESSAGE
		{
			get { return _SM_MESSAGE; }
			set {  _SM_MESSAGE = value; }
		}

		public string SM_TELEPHONE
		{
			get { return _SM_TELEPHONE; }
			set {  _SM_TELEPHONE = value; }
		}

		public string SM_STATUT
		{
			get { return _SM_STATUT; }
			set {  _SM_STATUT = value; }
		}


        public DateTime SM_DATESAISIE
        {
            get { return _SM_DATESAISIE; }
            set { _SM_DATESAISIE = value; }
        }
        public string TE_CODESMSTYPEOPERATION
        {
            get { return _TE_CODESMSTYPEOPERATION; }
            set { _TE_CODESMSTYPEOPERATION = value; }
        }


        public string SL_CODEMESSAGE
        {
            get { return _SL_CODEMESSAGE; }
            set { _SL_CODEMESSAGE = value; }
        }

        public string SL_RESULTAT
        {
            get { return _SL_RESULTAT; }
            set { _SL_RESULTAT = value; }
        }

        public string SL_MESSAGE
        {
            get { return _SL_MESSAGE; }
            set { _SL_MESSAGE = value; }
        }
        public string SL_MESSAGEOBJET
        {
            get { return _SL_MESSAGEOBJET; }
            set { _SL_MESSAGEOBJET = value; }
        }
        public string AG_EMAIL
        {
            get { return _AG_EMAIL; }
            set { _AG_EMAIL = value; }
        }
        public string AG_EMAILMOTDEPASSE
        {
            get { return _AG_EMAILMOTDEPASSE; }
            set { _AG_EMAILMOTDEPASSE = value; }
        }
        


        #endregion

        #region INSTANCIATEURS

        public clsSmsout(){}
	
		public clsSmsout(clsSmsout clsSmsout)
		{
			this.AG_CODEAGENCE = clsSmsout.AG_CODEAGENCE;
			this.SM_DATEPIECE = clsSmsout.SM_DATEPIECE;
			this.SM_NUMPIECE = clsSmsout.SM_NUMPIECE;
			this.SM_NUMSEQUENCE = clsSmsout.SM_NUMSEQUENCE;
			this.CO_CODECOMPTE = clsSmsout.CO_CODECOMPTE;
			this.SM_MESSAGE = clsSmsout.SM_MESSAGE;
			this.SM_TELEPHONE = clsSmsout.SM_TELEPHONE;
			this.SM_STATUT = clsSmsout.SM_STATUT;
            this.SM_DATESAISIE = clsSmsout.SM_DATESAISIE;
            this.TE_CODESMSTYPEOPERATION = clsSmsout.TE_CODESMSTYPEOPERATION;
            this.SL_CODEMESSAGE = clsSmsout.SL_CODEMESSAGE;
            this.SL_RESULTAT = clsSmsout.SL_RESULTAT;
            this.SL_MESSAGE = clsSmsout.SL_MESSAGE;
            this.SL_MESSAGEOBJET = clsSmsout.SL_MESSAGEOBJET;
            this.AG_EMAIL = clsSmsout.AG_EMAIL;
            this.AG_EMAILMOTDEPASSE = clsSmsout.AG_EMAILMOTDEPASSE;
            //clsParams.SL_MESSAGEOBJET = clsSmsouts[0].SL_MESSAGEOBJET;
            //clsParams.AG_EMAIL = clsSmsouts[0].AG_EMAIL;
            //clsParams.AG_EMAILMOTDEPASSE = clsSmsouts[0].AG_EMAILMOTDEPASSE;


        }

        #endregion

    }
}
