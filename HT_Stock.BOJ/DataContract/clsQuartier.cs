using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsQuartier
	{
		#region VARIABLES LOCALES

		private string _QU_CODEQUARTIER = "";
		private string _CO_CODECOMMUNE = "";
		private string _QU_LIBELLE = "";

		#endregion

		#region ACCESSEURS

		public string QU_CODEQUARTIER
		{
			get { return _QU_CODEQUARTIER; }
			set {  _QU_CODEQUARTIER = value; }
		}

		public string CO_CODECOMMUNE
		{
			get { return _CO_CODECOMMUNE; }
			set {  _CO_CODECOMMUNE = value; }
		}

		public string QU_LIBELLE
		{
			get { return _QU_LIBELLE; }
			set {  _QU_LIBELLE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsQuartier(){}
		public clsQuartier( string QU_CODEQUARTIER,string CO_CODECOMMUNE,string QU_LIBELLE)
		{
			this.QU_CODEQUARTIER = QU_CODEQUARTIER;
			this.CO_CODECOMMUNE = CO_CODECOMMUNE;
			this.QU_LIBELLE = QU_LIBELLE;
		}
		public clsQuartier(clsQuartier clsQuartier)
		{
			this.QU_CODEQUARTIER = clsQuartier.QU_CODEQUARTIER;
			this.CO_CODECOMMUNE = clsQuartier.CO_CODECOMMUNE;
			this.QU_LIBELLE = clsQuartier.QU_LIBELLE;
		}

		#endregion

	}
}
