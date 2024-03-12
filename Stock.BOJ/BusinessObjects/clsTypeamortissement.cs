using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsTypeamortissement
	{
		#region VARIABLES LOCALES

		private string _TI_CODETYPEAMORTISSEMENT = "";
		private string _TI_LIBELLE = "";
		private string _TI_ACTIF = "";
		private string _TI_AMORTISSEMENTCREDIT = "";
		private int _TI_NUMEROORDRE = 0;
		private string _TI_AMORTISSEMENTIMMOBILISATION = "";

		#endregion

		#region ACCESSEURS

		public string TI_CODETYPEAMORTISSEMENT
		{
			get { return _TI_CODETYPEAMORTISSEMENT; }
			set {  _TI_CODETYPEAMORTISSEMENT = value; }
		}

		public string TI_LIBELLE
		{
			get { return _TI_LIBELLE; }
			set {  _TI_LIBELLE = value; }
		}

		public string TI_ACTIF
		{
			get { return _TI_ACTIF; }
			set {  _TI_ACTIF = value; }
		}

		public string TI_AMORTISSEMENTCREDIT
		{
			get { return _TI_AMORTISSEMENTCREDIT; }
			set {  _TI_AMORTISSEMENTCREDIT = value; }
		}

		public int TI_NUMEROORDRE
		{
			get { return _TI_NUMEROORDRE; }
			set {  _TI_NUMEROORDRE = value; }
		}

		public string TI_AMORTISSEMENTIMMOBILISATION
		{
			get { return _TI_AMORTISSEMENTIMMOBILISATION; }
			set {  _TI_AMORTISSEMENTIMMOBILISATION = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsTypeamortissement(){}
		public clsTypeamortissement( string TI_CODETYPEAMORTISSEMENT,string TI_LIBELLE,string TI_ACTIF,string TI_AMORTISSEMENTCREDIT,int TI_NUMEROORDRE,string TI_AMORTISSEMENTIMMOBILISATION)
		{
			this.TI_CODETYPEAMORTISSEMENT = TI_CODETYPEAMORTISSEMENT;
			this.TI_LIBELLE = TI_LIBELLE;
			this.TI_ACTIF = TI_ACTIF;
			this.TI_AMORTISSEMENTCREDIT = TI_AMORTISSEMENTCREDIT;
			this.TI_NUMEROORDRE = TI_NUMEROORDRE;
			this.TI_AMORTISSEMENTIMMOBILISATION = TI_AMORTISSEMENTIMMOBILISATION;
		}
		public clsTypeamortissement(clsTypeamortissement clsTypeamortissement)
		{
			this.TI_CODETYPEAMORTISSEMENT = clsTypeamortissement.TI_CODETYPEAMORTISSEMENT;
			this.TI_LIBELLE = clsTypeamortissement.TI_LIBELLE;
			this.TI_ACTIF = clsTypeamortissement.TI_ACTIF;
			this.TI_AMORTISSEMENTCREDIT = clsTypeamortissement.TI_AMORTISSEMENTCREDIT;
			this.TI_NUMEROORDRE = clsTypeamortissement.TI_NUMEROORDRE;
			this.TI_AMORTISSEMENTIMMOBILISATION = clsTypeamortissement.TI_AMORTISSEMENTIMMOBILISATION;
		}

		#endregion

	}
}
