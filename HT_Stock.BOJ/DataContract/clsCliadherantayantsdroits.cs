using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsCliadherantayantsdroits
	{
		#region VARIABLES LOCALES

		private string _AG_CODEAGENCE = "";
		private string _EN_CODEENTREPOT = "";
		private string _TI_IDTIERSADHERANT = "";
		private string _TI_IDTIERSAYANTDROIT = "";
		private DateTime _AY_DATESAISIE = DateTime.Parse("01/01/1900");
		private DateTime _AY_DATECLOTURE = DateTime.Parse("01/01/1900");
		private string _TA_CODETITREAYANTDROIT = "";
		private string _OP_CODEOPERATEUR = "";
		private string _AY_MATRICULE = "";
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

		public string TI_IDTIERSADHERANT
		{
			get { return _TI_IDTIERSADHERANT; }
			set {  _TI_IDTIERSADHERANT = value; }
		}

		public string TI_IDTIERSAYANTDROIT
		{
			get { return _TI_IDTIERSAYANTDROIT; }
			set {  _TI_IDTIERSAYANTDROIT = value; }
		}

		public DateTime AY_DATESAISIE
		{
			get { return _AY_DATESAISIE; }
			set {  _AY_DATESAISIE = value; }
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
        public string AY_MATRICULE
        {
	        get { return _AY_MATRICULE; }
	        set { _AY_MATRICULE = value; }
        }

		#endregion

		#region INSTANCIATEURS

		public clsCliadherantayantsdroits(){}
		
		public clsCliadherantayantsdroits(clsCliadherantayantsdroits clsCliadherantayantsdroits)
		{
			this.AG_CODEAGENCE = clsCliadherantayantsdroits.AG_CODEAGENCE;
			this.EN_CODEENTREPOT = clsCliadherantayantsdroits.EN_CODEENTREPOT;
			this.TI_IDTIERSADHERANT = clsCliadherantayantsdroits.TI_IDTIERSADHERANT;
			this.TI_IDTIERSAYANTDROIT = clsCliadherantayantsdroits.TI_IDTIERSAYANTDROIT;
			this.AY_DATESAISIE = clsCliadherantayantsdroits.AY_DATESAISIE;
			this.AY_DATECLOTURE = clsCliadherantayantsdroits.AY_DATECLOTURE;
			this.TA_CODETITREAYANTDROIT = clsCliadherantayantsdroits.TA_CODETITREAYANTDROIT;
			this.OP_CODEOPERATEUR = clsCliadherantayantsdroits.OP_CODEOPERATEUR;
			this.AY_MATRICULE = clsCliadherantayantsdroits.AY_MATRICULE;

		}

		#endregion

	}
}
