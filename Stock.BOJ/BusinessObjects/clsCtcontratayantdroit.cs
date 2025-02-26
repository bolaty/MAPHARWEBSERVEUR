using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsCtcontratayantdroit
	{
		#region VARIABLES LOCALES

		private string _AG_CODEAGENCE = "";
		private string _EN_CODEENTREPOT = "";
		private string _CA_CODECONTRAT = "";
		private string _AY_DENOMMINATIONAYANTDROIT = "";
		private DateTime _AY_DATESAISIE = DateTime.Parse("01/01/1900");
		private string _AY_INDEX = "";
		private DateTime _AY_DATECLOTURE = DateTime.Parse("01/01/1900");
		private string _TA_CODETITREAYANTDROIT = "";
		private string _OP_CODEOPERATEUR = "";
		private double _AY_TAUX = 0;
		#endregion

		#region ACCESSEURS

		public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set {  _AG_CODEAGENCE = value; }
		}

		public string EN_CODEENTREPOT
		{
			get { return _EN_CODEENTREPOT; }
			set {  _EN_CODEENTREPOT = value; }
		}

		public string CA_CODECONTRAT
		{
			get { return _CA_CODECONTRAT; }
			set {  _CA_CODECONTRAT = value; }
		}

		public string AY_DENOMMINATIONAYANTDROIT
		{
			get { return _AY_DENOMMINATIONAYANTDROIT; }
			set {  _AY_DENOMMINATIONAYANTDROIT = value; }
		}

		public DateTime AY_DATESAISIE
		{
			get { return _AY_DATESAISIE; }
			set {  _AY_DATESAISIE = value; }
		}

		public string AY_INDEX
		{
			get { return _AY_INDEX; }
			set {  _AY_INDEX = value; }
		}

		public DateTime AY_DATECLOTURE
		{
			get { return _AY_DATECLOTURE; }
			set {  _AY_DATECLOTURE = value; }
		}

		public string TA_CODETITREAYANTDROIT
		{
			get { return _TA_CODETITREAYANTDROIT; }
			set {  _TA_CODETITREAYANTDROIT = value; }
		}

		public string OP_CODEOPERATEUR
		{
			get { return _OP_CODEOPERATEUR; }
			set {  _OP_CODEOPERATEUR = value; }
		}
		public double AY_TAUX
        {
			get { return _AY_TAUX; }
			set { _AY_TAUX = value; }
		}

		#endregion

		#region INSTANCIATEURS

		public clsCtcontratayantdroit(){}
		
		public clsCtcontratayantdroit(clsCtcontratayantdroit clsCtcontratayantdroit)
		{
			this.AG_CODEAGENCE = clsCtcontratayantdroit.AG_CODEAGENCE;
			this.EN_CODEENTREPOT = clsCtcontratayantdroit.EN_CODEENTREPOT;
			this.CA_CODECONTRAT = clsCtcontratayantdroit.CA_CODECONTRAT;
			this.AY_DENOMMINATIONAYANTDROIT = clsCtcontratayantdroit.AY_DENOMMINATIONAYANTDROIT;
			this.AY_DATESAISIE = clsCtcontratayantdroit.AY_DATESAISIE;
			this.AY_INDEX = clsCtcontratayantdroit.AY_INDEX;
			this.AY_DATECLOTURE = clsCtcontratayantdroit.AY_DATECLOTURE;
			this.TA_CODETITREAYANTDROIT = clsCtcontratayantdroit.TA_CODETITREAYANTDROIT;
			this.AY_TAUX = clsCtcontratayantdroit.AY_TAUX;
			this.OP_CODEOPERATEUR = clsCtcontratayantdroit.OP_CODEOPERATEUR;
		}

		#endregion

	}
}
