using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsPhaparqualite
	{
		#region VARIABLES LOCALES

		private string _QT_CODEQUALITE = "";
		private string _QT_LIBELLE = "";
		private string _QT_ACTIF = "";

		#endregion

		#region ACCESSEURS

		public string QT_CODEQUALITE
		{
			get { return _QT_CODEQUALITE; }
			set {  _QT_CODEQUALITE = value; }
		}

		public string QT_LIBELLE
		{
			get { return _QT_LIBELLE; }
			set {  _QT_LIBELLE = value; }
		}

		public string QT_ACTIF
		{
			get { return _QT_ACTIF; }
			set {  _QT_ACTIF = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsPhaparqualite(){}
		public clsPhaparqualite( string QT_CODEQUALITE,string QT_LIBELLE,string QT_ACTIF)
		{
			this.QT_CODEQUALITE = QT_CODEQUALITE;
			this.QT_LIBELLE = QT_LIBELLE;
			this.QT_ACTIF = QT_ACTIF;
		}
		public clsPhaparqualite(clsPhaparqualite clsPhaparqualite)
		{
			this.QT_CODEQUALITE = clsPhaparqualite.QT_CODEQUALITE;
			this.QT_LIBELLE = clsPhaparqualite.QT_LIBELLE;
			this.QT_ACTIF = clsPhaparqualite.QT_ACTIF;
		}

		#endregion

	}
}
