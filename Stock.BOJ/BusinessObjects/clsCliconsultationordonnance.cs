using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsCliconsultationordonnance
	{
		#region VARIABLES LOCALES

		private string _AG_CODEAGENCE = "";
		private string _CO_CODECONSULTATION = "";
		private string _OR_NUMSEQUENCE = "";
		private DateTime _OR_DATESAISIE = DateTime.Parse("01/01/1900");
		private string _CT_CODECATEGORIEORDONNANCE = "";
		private string _OR_PRESCRIPTION = "";
		private string _TI_IDTIERSMEDECIN = "";
		private string _OP_CODEOPERATEUR = "";

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

		public string OR_NUMSEQUENCE
		{
			get { return _OR_NUMSEQUENCE; }
			set {  _OR_NUMSEQUENCE = value; }
		}

		public DateTime OR_DATESAISIE
		{
			get { return _OR_DATESAISIE; }
			set {  _OR_DATESAISIE = value; }
		}

		public string CT_CODECATEGORIEORDONNANCE
		{
			get { return _CT_CODECATEGORIEORDONNANCE; }
			set {  _CT_CODECATEGORIEORDONNANCE = value; }
		}

		public string OR_PRESCRIPTION
		{
			get { return _OR_PRESCRIPTION; }
			set {  _OR_PRESCRIPTION = value; }
		}

		public string TI_IDTIERSMEDECIN
		{
			get { return _TI_IDTIERSMEDECIN; }
			set {  _TI_IDTIERSMEDECIN = value; }
		}

		public string OP_CODEOPERATEUR
		{
			get { return _OP_CODEOPERATEUR; }
			set {  _OP_CODEOPERATEUR = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCliconsultationordonnance(){}
		public clsCliconsultationordonnance( string AG_CODEAGENCE,string CO_CODECONSULTATION,string OR_NUMSEQUENCE,DateTime OR_DATESAISIE,string CT_CODECATEGORIEORDONNANCE,string OR_PRESCRIPTION,string TI_IDTIERSMEDECIN,string OP_CODEOPERATEUR)
		{
			this.AG_CODEAGENCE = AG_CODEAGENCE;
			this.CO_CODECONSULTATION = CO_CODECONSULTATION;
			this.OR_NUMSEQUENCE = OR_NUMSEQUENCE;
			this.OR_DATESAISIE = OR_DATESAISIE;
			this.CT_CODECATEGORIEORDONNANCE = CT_CODECATEGORIEORDONNANCE;
			this.OR_PRESCRIPTION = OR_PRESCRIPTION;
			this.TI_IDTIERSMEDECIN = TI_IDTIERSMEDECIN;
			this.OP_CODEOPERATEUR = OP_CODEOPERATEUR;
		}
		public clsCliconsultationordonnance(clsCliconsultationordonnance clsCliconsultationordonnance)
		{
			this.AG_CODEAGENCE = clsCliconsultationordonnance.AG_CODEAGENCE;
			this.CO_CODECONSULTATION = clsCliconsultationordonnance.CO_CODECONSULTATION;
			this.OR_NUMSEQUENCE = clsCliconsultationordonnance.OR_NUMSEQUENCE;
			this.OR_DATESAISIE = clsCliconsultationordonnance.OR_DATESAISIE;
			this.CT_CODECATEGORIEORDONNANCE = clsCliconsultationordonnance.CT_CODECATEGORIEORDONNANCE;
			this.OR_PRESCRIPTION = clsCliconsultationordonnance.OR_PRESCRIPTION;
			this.TI_IDTIERSMEDECIN = clsCliconsultationordonnance.TI_IDTIERSMEDECIN;
			this.OP_CODEOPERATEUR = clsCliconsultationordonnance.OP_CODEOPERATEUR;
		}

		#endregion

	}
}
