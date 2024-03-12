using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsBienimmobiliseamortissement
	{
		#region VARIABLES LOCALES

		private string _AG_CODEAGENCE = "";
		private string _TI_IDTIERS = "";
		private DateTime _IA_DATE = DateTime.Parse("01/01/1900");
		private string _IA_PERIODE = "";
		private double _IA_DOTATIONANTERIEUR = 0;
		private double _IA_DOTATIONEXERCICE = 0;
		private double _IA_CUMUL = 0;
		private double _IA_VALEURRESIDUELLE = 0;

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

		public DateTime IA_DATE
		{
			get { return _IA_DATE; }
			set {  _IA_DATE = value; }
		}

		public string IA_PERIODE
		{
			get { return _IA_PERIODE; }
			set {  _IA_PERIODE = value; }
		}

		public double IA_DOTATIONANTERIEUR
		{
			get { return _IA_DOTATIONANTERIEUR; }
			set {  _IA_DOTATIONANTERIEUR = value; }
		}

		public double IA_DOTATIONEXERCICE
		{
			get { return _IA_DOTATIONEXERCICE; }
			set {  _IA_DOTATIONEXERCICE = value; }
		}

		public double IA_CUMUL
		{
			get { return _IA_CUMUL; }
			set {  _IA_CUMUL = value; }
		}

		public double IA_VALEURRESIDUELLE
		{
			get { return _IA_VALEURRESIDUELLE; }
			set {  _IA_VALEURRESIDUELLE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsBienimmobiliseamortissement(){}
		public clsBienimmobiliseamortissement( string AG_CODEAGENCE,string TI_IDTIERS,DateTime IA_DATE,string IA_PERIODE,double IA_DOTATIONANTERIEUR,double IA_DOTATIONEXERCICE,double IA_CUMUL,double IA_VALEURRESIDUELLE)
		{
			this.AG_CODEAGENCE = AG_CODEAGENCE;
			this.TI_IDTIERS = TI_IDTIERS;
			this.IA_DATE = IA_DATE;
			this.IA_PERIODE = IA_PERIODE;
			this.IA_DOTATIONANTERIEUR = IA_DOTATIONANTERIEUR;
			this.IA_DOTATIONEXERCICE = IA_DOTATIONEXERCICE;
			this.IA_CUMUL = IA_CUMUL;
			this.IA_VALEURRESIDUELLE = IA_VALEURRESIDUELLE;
		}
		public clsBienimmobiliseamortissement(clsBienimmobiliseamortissement clsBienimmobiliseamortissement)
		{
			this.AG_CODEAGENCE = clsBienimmobiliseamortissement.AG_CODEAGENCE;
			this.TI_IDTIERS = clsBienimmobiliseamortissement.TI_IDTIERS;
			this.IA_DATE = clsBienimmobiliseamortissement.IA_DATE;
			this.IA_PERIODE = clsBienimmobiliseamortissement.IA_PERIODE;
			this.IA_DOTATIONANTERIEUR = clsBienimmobiliseamortissement.IA_DOTATIONANTERIEUR;
			this.IA_DOTATIONEXERCICE = clsBienimmobiliseamortissement.IA_DOTATIONEXERCICE;
			this.IA_CUMUL = clsBienimmobiliseamortissement.IA_CUMUL;
			this.IA_VALEURRESIDUELLE = clsBienimmobiliseamortissement.IA_VALEURRESIDUELLE;
		}

		#endregion

	}
}
