using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsCliconsultationpreference
	{
		#region VARIABLES LOCALES

		private string _AG_CODEAGENCE = "";
		private string _TI_IDTIERS = "";
		private string _PR_NUMSEQUENCE = "";
		private DateTime _PR_DATESAISIE = DateTime.Parse("01/01/1900");
		private string _TP_CODETYPEPREFERENCE = "";
		private string _PR_DESCRIPTION = "";
		private string _OP_CODEOPERATEUR = "";

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

		public string PR_NUMSEQUENCE
		{
			get { return _PR_NUMSEQUENCE; }
			set {  _PR_NUMSEQUENCE = value; }
		}

		public DateTime PR_DATESAISIE
		{
			get { return _PR_DATESAISIE; }
			set {  _PR_DATESAISIE = value; }
		}

		public string TP_CODETYPEPREFERENCE
		{
			get { return _TP_CODETYPEPREFERENCE; }
			set {  _TP_CODETYPEPREFERENCE = value; }
		}

		public string PR_DESCRIPTION
		{
			get { return _PR_DESCRIPTION; }
			set {  _PR_DESCRIPTION = value; }
		}

		public string OP_CODEOPERATEUR
		{
			get { return _OP_CODEOPERATEUR; }
			set {  _OP_CODEOPERATEUR = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCliconsultationpreference(){}
		public clsCliconsultationpreference( string AG_CODEAGENCE,string TI_IDTIERS,string PR_NUMSEQUENCE,DateTime PR_DATESAISIE,string TP_CODETYPEPREFERENCE,string PR_DESCRIPTION,string OP_CODEOPERATEUR)
		{
			this.AG_CODEAGENCE = AG_CODEAGENCE;
			this.TI_IDTIERS = TI_IDTIERS;
			this.PR_NUMSEQUENCE = PR_NUMSEQUENCE;
			this.PR_DATESAISIE = PR_DATESAISIE;
			this.TP_CODETYPEPREFERENCE = TP_CODETYPEPREFERENCE;
			this.PR_DESCRIPTION = PR_DESCRIPTION;
			this.OP_CODEOPERATEUR = OP_CODEOPERATEUR;
		}
		public clsCliconsultationpreference(clsCliconsultationpreference clsCliconsultationpreference)
		{
			this.AG_CODEAGENCE = clsCliconsultationpreference.AG_CODEAGENCE;
			this.TI_IDTIERS = clsCliconsultationpreference.TI_IDTIERS;
			this.PR_NUMSEQUENCE = clsCliconsultationpreference.PR_NUMSEQUENCE;
			this.PR_DATESAISIE = clsCliconsultationpreference.PR_DATESAISIE;
			this.TP_CODETYPEPREFERENCE = clsCliconsultationpreference.TP_CODETYPEPREFERENCE;
			this.PR_DESCRIPTION = clsCliconsultationpreference.PR_DESCRIPTION;
			this.OP_CODEOPERATEUR = clsCliconsultationpreference.OP_CODEOPERATEUR;
		}

		#endregion

	}
}
