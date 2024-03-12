using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsModereglement
	{
		#region VARIABLES LOCALES

		private string _MR_CODEMODEREGLEMENT = "";
		private string _MR_LIBELLE = "";
		private string _MR_ACTIF = "";

		#endregion

		#region ACCESSEURS

		public string MR_CODEMODEREGLEMENT
		{
			get { return _MR_CODEMODEREGLEMENT; }
			set {  _MR_CODEMODEREGLEMENT = value; }
		}

		public string MR_LIBELLE
		{
			get { return _MR_LIBELLE; }
			set {  _MR_LIBELLE = value; }
		}

		public string MR_ACTIF
		{
			get { return _MR_ACTIF; }
			set {  _MR_ACTIF = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsModereglement(){}
		public clsModereglement( string MR_CODEMODEREGLEMENT,string MR_LIBELLE,string MR_ACTIF)
		{
			this.MR_CODEMODEREGLEMENT = MR_CODEMODEREGLEMENT;
			this.MR_LIBELLE = MR_LIBELLE;
			this.MR_ACTIF = MR_ACTIF;
		}
		public clsModereglement(clsModereglement clsModereglement)
		{
			this.MR_CODEMODEREGLEMENT = clsModereglement.MR_CODEMODEREGLEMENT;
			this.MR_LIBELLE = clsModereglement.MR_LIBELLE;
			this.MR_ACTIF = clsModereglement.MR_ACTIF;
		}

		#endregion

	}
}
