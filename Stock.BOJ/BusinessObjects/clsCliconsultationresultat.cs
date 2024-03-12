using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsCliconsultationresultat
	{
		#region VARIABLES LOCALES

		private string _AG_CODEAGENCE = "";
		private string _CO_CODECONSULTATION = "";
		private string _RE_NUMSEQUENCE = "";
		private DateTime _RE_DATESAISIE = DateTime.Parse("01/01/1900");
		private string _AR_CODEARTICLE = "";
        private string _OP_CODEOPERATEUR = "";
        private string _PA_CODEPATHOLOGIE = "";
		private DateTime _RE_DATERESULTAT = DateTime.Parse("01/01/1900");
		private string _RE_VALEURRESULTAT = "";

		#endregion

		#region ACCESSEURS

		public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set {  _AG_CODEAGENCE = value; }
		}

		public string CO_CODECONSULTATION
		{
			get { return _CO_CODECONSULTATION; }
			set {  _CO_CODECONSULTATION = value; }
		}

		public string RE_NUMSEQUENCE
		{
			get { return _RE_NUMSEQUENCE; }
			set {  _RE_NUMSEQUENCE = value; }
		}

		public DateTime RE_DATESAISIE
		{
			get { return _RE_DATESAISIE; }
			set {  _RE_DATESAISIE = value; }
		}

		public string AR_CODEARTICLE
		{
			get { return _AR_CODEARTICLE; }
			set {  _AR_CODEARTICLE = value; }
		}


        public string OP_CODEOPERATEUR
        {
            get { return _OP_CODEOPERATEUR; }
            set { _OP_CODEOPERATEUR = value; }
        }

        public string PA_CODEPATHOLOGIE
		{
			get { return _PA_CODEPATHOLOGIE; }
			set {  _PA_CODEPATHOLOGIE = value; }
		}

		public DateTime RE_DATERESULTAT
		{
			get { return _RE_DATERESULTAT; }
			set {  _RE_DATERESULTAT = value; }
		}

		public string RE_VALEURRESULTAT
		{
			get { return _RE_VALEURRESULTAT; }
			set {  _RE_VALEURRESULTAT = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCliconsultationresultat(){}
		public clsCliconsultationresultat( string AG_CODEAGENCE,string CO_CODECONSULTATION,string RE_NUMSEQUENCE,DateTime RE_DATESAISIE,string AR_CODEARTICLE, string OP_CODEOPERATEUR, string PA_CODEPATHOLOGIE,DateTime RE_DATERESULTAT,string RE_VALEURRESULTAT)
		{
			this.AG_CODEAGENCE = AG_CODEAGENCE;
			this.CO_CODECONSULTATION = CO_CODECONSULTATION;
			this.RE_NUMSEQUENCE = RE_NUMSEQUENCE;
			this.RE_DATESAISIE = RE_DATESAISIE;
			this.AR_CODEARTICLE = AR_CODEARTICLE;
            this.OP_CODEOPERATEUR = OP_CODEOPERATEUR;
			this.PA_CODEPATHOLOGIE = PA_CODEPATHOLOGIE;
			this.RE_DATERESULTAT = RE_DATERESULTAT;
			this.RE_VALEURRESULTAT = RE_VALEURRESULTAT;
		}
		public clsCliconsultationresultat(clsCliconsultationresultat clsCliconsultationresultat)
		{
			this.AG_CODEAGENCE = clsCliconsultationresultat.AG_CODEAGENCE;
			this.CO_CODECONSULTATION = clsCliconsultationresultat.CO_CODECONSULTATION;
			this.RE_NUMSEQUENCE = clsCliconsultationresultat.RE_NUMSEQUENCE;
			this.RE_DATESAISIE = clsCliconsultationresultat.RE_DATESAISIE;
			this.AR_CODEARTICLE = clsCliconsultationresultat.AR_CODEARTICLE;
            this.OP_CODEOPERATEUR = clsCliconsultationresultat.OP_CODEOPERATEUR;
			this.PA_CODEPATHOLOGIE = clsCliconsultationresultat.PA_CODEPATHOLOGIE;
			this.RE_DATERESULTAT = clsCliconsultationresultat.RE_DATERESULTAT;
			this.RE_VALEURRESULTAT = clsCliconsultationresultat.RE_VALEURRESULTAT;
		}

		#endregion

	}
}
