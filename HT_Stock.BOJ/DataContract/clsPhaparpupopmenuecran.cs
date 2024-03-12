using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsPhaparpupopmenuecran
	{
		#region VARIABLES LOCALES

		private string _EC_CODECRAN = "";
		private string _EC_NOM = "";
		private string _EC_LIBELLE = "";

		#endregion

		#region ACCESSEURS

		public string EC_CODECRAN
		{
			get { return _EC_CODECRAN; }
			set {  _EC_CODECRAN = value; }
		}

		public string EC_NOM
		{
			get { return _EC_NOM; }
			set {  _EC_NOM = value; }
		}

		public string EC_LIBELLE
		{
			get { return _EC_LIBELLE; }
			set {  _EC_LIBELLE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsPhaparpupopmenuecran(){}
		public clsPhaparpupopmenuecran( string EC_CODECRAN,string EC_NOM,string EC_LIBELLE)
		{
			this.EC_CODECRAN = EC_CODECRAN;
			this.EC_NOM = EC_NOM;
			this.EC_LIBELLE = EC_LIBELLE;
		}
		public clsPhaparpupopmenuecran(clsPhaparpupopmenuecran clsPhaparpupopmenuecran)
		{
			this.EC_CODECRAN = clsPhaparpupopmenuecran.EC_CODECRAN;
			this.EC_NOM = clsPhaparpupopmenuecran.EC_NOM;
			this.EC_LIBELLE = clsPhaparpupopmenuecran.EC_LIBELLE;
		}

		#endregion

	}
}
