using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsCliconsultationantecedant
	{
		#region VARIABLES LOCALES

		private string _AG_CODEAGENCE = "";
		private string _TI_IDTIERS = "";
		private string _AT_NUMSEQUENCE = "";
		private DateTime _AT_DATESAISIE = DateTime.Parse("01/01/1900");
        private DateTime _AT_DATEANTECEDANT = DateTime.Parse("01/01/1900");
		private string _TA_CODETYPEANTECEDANT = "";
		private string _PA_CODEPATHOLOGIE = "";
		private string _OP_CODEOPERATEUR = "";
		private string _AT_DESCRIPTION = "";

		#endregion

		#region ACCESSEURS

		public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set {  _AG_CODEAGENCE = value; }
		}

		public string TI_IDTIERS
		{
			get { return _TI_IDTIERS; }
			set {  _TI_IDTIERS = value; }
		}

		public string AT_NUMSEQUENCE
		{
			get { return _AT_NUMSEQUENCE; }
			set {  _AT_NUMSEQUENCE = value; }
		}

		public DateTime AT_DATESAISIE
		{
			get { return _AT_DATESAISIE; }
			set {  _AT_DATESAISIE = value; }
		}

        public DateTime AT_DATEANTECEDANT
        {
	        get { return _AT_DATEANTECEDANT; }
	        set { _AT_DATEANTECEDANT = value; }
        }

		public string TA_CODETYPEANTECEDANT
		{
			get { return _TA_CODETYPEANTECEDANT; }
			set {  _TA_CODETYPEANTECEDANT = value; }
		}

		public string PA_CODEPATHOLOGIE
		{
			get { return _PA_CODEPATHOLOGIE; }
			set {  _PA_CODEPATHOLOGIE = value; }
		}

		public string OP_CODEOPERATEUR
		{
			get { return _OP_CODEOPERATEUR; }
			set {  _OP_CODEOPERATEUR = value; }
		}

		public string AT_DESCRIPTION
		{
			get { return _AT_DESCRIPTION; }
			set {  _AT_DESCRIPTION = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCliconsultationantecedant(){}
		public clsCliconsultationantecedant( string AG_CODEAGENCE,string TI_IDTIERS,string AT_NUMSEQUENCE,DateTime AT_DATESAISIE,DateTime AT_DATEANTECEDANT, string TA_CODETYPEANTECEDANT,string PA_CODEPATHOLOGIE,string OP_CODEOPERATEUR,string AT_DESCRIPTION)
		{
			this.AG_CODEAGENCE = AG_CODEAGENCE;
			this.TI_IDTIERS = TI_IDTIERS;
			this.AT_NUMSEQUENCE = AT_NUMSEQUENCE;
			this.AT_DATESAISIE = AT_DATESAISIE;
            this.AT_DATEANTECEDANT = AT_DATEANTECEDANT;
			this.TA_CODETYPEANTECEDANT = TA_CODETYPEANTECEDANT;
			this.PA_CODEPATHOLOGIE = PA_CODEPATHOLOGIE;
			this.OP_CODEOPERATEUR = OP_CODEOPERATEUR;
			this.AT_DESCRIPTION = AT_DESCRIPTION;
		}
		public clsCliconsultationantecedant(clsCliconsultationantecedant clsCliconsultationantecedant)
		{
			this.AG_CODEAGENCE = clsCliconsultationantecedant.AG_CODEAGENCE;
			this.TI_IDTIERS = clsCliconsultationantecedant.TI_IDTIERS;
			this.AT_NUMSEQUENCE = clsCliconsultationantecedant.AT_NUMSEQUENCE;
			this.AT_DATESAISIE = clsCliconsultationantecedant.AT_DATESAISIE;
            this.AT_DATEANTECEDANT = clsCliconsultationantecedant.AT_DATEANTECEDANT;
			this.TA_CODETYPEANTECEDANT = clsCliconsultationantecedant.TA_CODETYPEANTECEDANT;
			this.PA_CODEPATHOLOGIE = clsCliconsultationantecedant.PA_CODEPATHOLOGIE;
			this.OP_CODEOPERATEUR = clsCliconsultationantecedant.OP_CODEOPERATEUR;
			this.AT_DESCRIPTION = clsCliconsultationantecedant.AT_DESCRIPTION;
		}

		#endregion

	}
}
