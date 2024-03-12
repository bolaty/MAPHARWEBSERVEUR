using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsPhaparpneu
	{
		#region VARIABLES LOCALES
        private string _AG_CODEAGENCE = "";
		private string _PN_CODEPNEU = "";
		private string _AR_CODEARTICLE = "";
        private string _TP_CODETYPEPNEU = "";
		private int _PN_TAILLE = 0;
		private string _PN_DESCRIPTION = "";
        private string _OP_CODEOPERATEUR = "";
		#endregion

		#region ACCESSEURS

        public string AG_CODEAGENCE
		{
            get { return _AG_CODEAGENCE; }
            set { _AG_CODEAGENCE = value; }
		}

		public string PN_CODEPNEU
		{
			get { return _PN_CODEPNEU; }
			set {  _PN_CODEPNEU = value; }
		}

		public string AR_CODEARTICLE
		{
			get { return _AR_CODEARTICLE; }
			set {  _AR_CODEARTICLE = value; }
		}

        public string TP_CODETYPEPNEU
		{
            get { return _TP_CODETYPEPNEU; }
            set { _TP_CODETYPEPNEU = value; }
		}

		public int PN_TAILLE
		{
			get { return _PN_TAILLE; }
			set {  _PN_TAILLE = value; }
		}

		public string PN_DESCRIPTION
		{
			get { return _PN_DESCRIPTION; }
			set {  _PN_DESCRIPTION = value; }
		}

        public string OP_CODEOPERATEUR
		{
            get { return _OP_CODEOPERATEUR; }
            set { _OP_CODEOPERATEUR = value; }
		}
		#endregion

		#region INSTANCIATEURS

		public clsPhaparpneu(){}
		
		public clsPhaparpneu(clsPhaparpneu clsPhaparpneu)
		{
            this.AG_CODEAGENCE = clsPhaparpneu.AG_CODEAGENCE;
            this.PN_CODEPNEU = clsPhaparpneu.PN_CODEPNEU;
			this.AR_CODEARTICLE = clsPhaparpneu.AR_CODEARTICLE;
            this.TP_CODETYPEPNEU = clsPhaparpneu.TP_CODETYPEPNEU;
			this.PN_TAILLE = clsPhaparpneu.PN_TAILLE;
			this.PN_DESCRIPTION = clsPhaparpneu.PN_DESCRIPTION;
            this.OP_CODEOPERATEUR = clsPhaparpneu.OP_CODEOPERATEUR;

		}

		#endregion

	}
}
