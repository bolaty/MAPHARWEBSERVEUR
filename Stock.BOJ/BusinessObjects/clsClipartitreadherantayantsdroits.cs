using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsClipartitreadherantayantsdroits
	{
		#region VARIABLES LOCALES

		private string _TA_CODETITREAYANTDROIT = "";
		private string _TA_LIBELLETITREAYANTDROIT = "";
		private string _TA_ACTIF = "";
		private int _TA_NUMEROORDRE = 0;

		#endregion

		#region ACCESSEURS

		public string TA_CODETITREAYANTDROIT
		{
			get { return _TA_CODETITREAYANTDROIT; }
			set {  _TA_CODETITREAYANTDROIT = value; }
		}

		public string TA_LIBELLETITREAYANTDROIT
		{
			get { return _TA_LIBELLETITREAYANTDROIT; }
			set {  _TA_LIBELLETITREAYANTDROIT = value; }
		}

		public string TA_ACTIF
		{
			get { return _TA_ACTIF; }
			set {  _TA_ACTIF = value; }
		}

		public int TA_NUMEROORDRE
		{
			get { return _TA_NUMEROORDRE; }
			set {  _TA_NUMEROORDRE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsClipartitreadherantayantsdroits(){}
		public clsClipartitreadherantayantsdroits( string TA_CODETITREAYANTDROIT,string TA_LIBELLETITREAYANTDROIT,string TA_ACTIF,int TA_NUMEROORDRE)
		{
			this.TA_CODETITREAYANTDROIT = TA_CODETITREAYANTDROIT;
			this.TA_LIBELLETITREAYANTDROIT = TA_LIBELLETITREAYANTDROIT;
			this.TA_ACTIF = TA_ACTIF;
			this.TA_NUMEROORDRE = TA_NUMEROORDRE;
		}
		public clsClipartitreadherantayantsdroits(clsClipartitreadherantayantsdroits clsClipartitreadherantayantsdroits)
		{
			this.TA_CODETITREAYANTDROIT = clsClipartitreadherantayantsdroits.TA_CODETITREAYANTDROIT;
			this.TA_LIBELLETITREAYANTDROIT = clsClipartitreadherantayantsdroits.TA_LIBELLETITREAYANTDROIT;
			this.TA_ACTIF = clsClipartitreadherantayantsdroits.TA_ACTIF;
			this.TA_NUMEROORDRE = clsClipartitreadherantayantsdroits.TA_NUMEROORDRE;
		}

		#endregion

	}
}
