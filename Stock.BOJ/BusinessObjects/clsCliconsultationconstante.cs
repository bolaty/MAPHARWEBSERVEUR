using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsCliconsultationconstante
	{
		#region VARIABLES LOCALES

		private string _AG_CODEAGENCE = "";
		private string _CO_CODECONSULTATION = "";
		private string _CC_NUMSEQUENCE = "";
		private DateTime _CC_DATESAISIE = DateTime.Parse("01/01/1900");
		private string _IN_CODEINGREDIENT= "";
		private string _CC_VALEUR = "";
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

		public string CC_NUMSEQUENCE
		{
			get { return _CC_NUMSEQUENCE; }
			set {  _CC_NUMSEQUENCE = value; }
		}

		public DateTime CC_DATESAISIE
		{
			get { return _CC_DATESAISIE; }
			set {  _CC_DATESAISIE = value; }
		}

		public string IN_CODEINGREDIENT
		{
			get { return _IN_CODEINGREDIENT; }
			set {  _IN_CODEINGREDIENT= value; }
		}

		public string CC_VALEUR
		{
			get { return _CC_VALEUR; }
			set {  _CC_VALEUR = value; }
		}

		public string OP_CODEOPERATEUR
		{
			get { return _OP_CODEOPERATEUR; }
			set {  _OP_CODEOPERATEUR = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCliconsultationconstante(){}
		public clsCliconsultationconstante( string AG_CODEAGENCE,string CO_CODECONSULTATION,string CC_NUMSEQUENCE,DateTime CC_DATESAISIE,string IN_CODEINGREDIENT,string CC_VALEUR,string OP_CODEOPERATEUR)
		{
			this.AG_CODEAGENCE = AG_CODEAGENCE;
			this.CO_CODECONSULTATION = CO_CODECONSULTATION;
			this.CC_NUMSEQUENCE = CC_NUMSEQUENCE;
			this.CC_DATESAISIE = CC_DATESAISIE;
			this.IN_CODEINGREDIENT= IN_CODEINGREDIENT;
			this.CC_VALEUR = CC_VALEUR;
			this.OP_CODEOPERATEUR = OP_CODEOPERATEUR;
		}
		public clsCliconsultationconstante(clsCliconsultationconstante clsCliconsultationconstante)
		{
			this.AG_CODEAGENCE = clsCliconsultationconstante.AG_CODEAGENCE;
			this.CO_CODECONSULTATION = clsCliconsultationconstante.CO_CODECONSULTATION;
			this.CC_NUMSEQUENCE = clsCliconsultationconstante.CC_NUMSEQUENCE;
			this.CC_DATESAISIE = clsCliconsultationconstante.CC_DATESAISIE;
			this.IN_CODEINGREDIENT= clsCliconsultationconstante.IN_CODEINGREDIENT;
			this.CC_VALEUR = clsCliconsultationconstante.CC_VALEUR;
			this.OP_CODEOPERATEUR = clsCliconsultationconstante.OP_CODEOPERATEUR;
		}

		#endregion

	}
}
