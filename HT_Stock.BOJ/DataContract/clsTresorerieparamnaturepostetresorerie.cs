using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsTresorerieparamnaturepostetresorerie
	{
		#region VARIABLES LOCALES

		private string _TN_CODENATUREPOSTETRESORERIE = "";
		private string _TN_LIBELLE = "";
		private string _TN_NUMEROORDRE = "";

		#endregion

		#region ACCESSEURS

		public string TN_CODENATUREPOSTETRESORERIE
		{
			get { return _TN_CODENATUREPOSTETRESORERIE; }
			set {  _TN_CODENATUREPOSTETRESORERIE = value; }
		}

		public string TN_LIBELLE
		{
			get { return _TN_LIBELLE; }
			set {  _TN_LIBELLE = value; }
		}

		public string TN_NUMEROORDRE
		{
			get { return _TN_NUMEROORDRE; }
			set {  _TN_NUMEROORDRE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsTresorerieparamnaturepostetresorerie(){}
		public clsTresorerieparamnaturepostetresorerie( string TN_CODENATUREPOSTETRESORERIE,string TN_LIBELLE,string TN_NUMEROORDRE)
		{
			this.TN_CODENATUREPOSTETRESORERIE = TN_CODENATUREPOSTETRESORERIE;
			this.TN_LIBELLE = TN_LIBELLE;
			this.TN_NUMEROORDRE = TN_NUMEROORDRE;
		}
		public clsTresorerieparamnaturepostetresorerie(clsTresorerieparamnaturepostetresorerie clsTresorerieparamnaturepostetresorerie)
		{
			this.TN_CODENATUREPOSTETRESORERIE = clsTresorerieparamnaturepostetresorerie.TN_CODENATUREPOSTETRESORERIE;
			this.TN_LIBELLE = clsTresorerieparamnaturepostetresorerie.TN_LIBELLE;
			this.TN_NUMEROORDRE = clsTresorerieparamnaturepostetresorerie.TN_NUMEROORDRE;
		}

		#endregion

	}
}
