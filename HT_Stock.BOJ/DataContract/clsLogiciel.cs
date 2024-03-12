using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsLogiciel : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _LO_CODELOGICIEL = "";
		private string _LO_LIBELLE = "";
		private string _LO_NUMEROORDRE ="";
		private string _LO_STATUTLOGICIEL = "";

		#endregion

		#region ACCESSEURS

		public string LO_CODELOGICIEL
		{
			get { return _LO_CODELOGICIEL; }
			set {  _LO_CODELOGICIEL = value; }
		}

		public string LO_LIBELLE
		{
			get { return _LO_LIBELLE; }
			set {  _LO_LIBELLE = value; }
		}

		public string LO_NUMEROORDRE
		{
			get { return _LO_NUMEROORDRE; }
			set {  _LO_NUMEROORDRE = value; }
		}

		public string LO_STATUTLOGICIEL
		{
			get { return _LO_STATUTLOGICIEL; }
			set {  _LO_STATUTLOGICIEL = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsLogiciel(){}
		public clsLogiciel( string LO_CODELOGICIEL,string LO_LIBELLE,string LO_NUMEROORDRE,string LO_STATUTLOGICIEL)
		{
			this.LO_CODELOGICIEL = LO_CODELOGICIEL;
			this.LO_LIBELLE = LO_LIBELLE;
			this.LO_NUMEROORDRE = LO_NUMEROORDRE;
			this.LO_STATUTLOGICIEL = LO_STATUTLOGICIEL;
		}
		public clsLogiciel(clsLogiciel clsLogiciel)
		{
			this.LO_CODELOGICIEL = clsLogiciel.LO_CODELOGICIEL;
			this.LO_LIBELLE = clsLogiciel.LO_LIBELLE;
			this.LO_NUMEROORDRE = clsLogiciel.LO_NUMEROORDRE;
			this.LO_STATUTLOGICIEL = clsLogiciel.LO_STATUTLOGICIEL;
		}

		#endregion

	}
}
