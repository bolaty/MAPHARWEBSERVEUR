using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsPhaparpupopmenu
	{
		#region VARIABLES LOCALES

		private string _PP_CODEPUPOPMENU = "";
		private string _EC_CODECRAN = "";
		private string _PP_NOMPUPOPMENU = "";
		private string _PP_LIBELLE = "";

		#endregion

		#region ACCESSEURS

		public string PP_CODEPUPOPMENU
		{
			get { return _PP_CODEPUPOPMENU; }
			set {  _PP_CODEPUPOPMENU = value; }
		}

		public string EC_CODECRAN
		{
			get { return _EC_CODECRAN; }
			set {  _EC_CODECRAN = value; }
		}

		public string PP_NOMPUPOPMENU
		{
			get { return _PP_NOMPUPOPMENU; }
			set {  _PP_NOMPUPOPMENU = value; }
		}

		public string PP_LIBELLE
		{
			get { return _PP_LIBELLE; }
			set {  _PP_LIBELLE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsPhaparpupopmenu(){}
		public clsPhaparpupopmenu( string PP_CODEPUPOPMENU,string EC_CODECRAN,string PP_NOMPUPOPMENU,string PP_LIBELLE)
		{
			this.PP_CODEPUPOPMENU = PP_CODEPUPOPMENU;
			this.EC_CODECRAN = EC_CODECRAN;
			this.PP_NOMPUPOPMENU = PP_NOMPUPOPMENU;
			this.PP_LIBELLE = PP_LIBELLE;
		}
		public clsPhaparpupopmenu(clsPhaparpupopmenu clsPhaparpupopmenu)
		{
			this.PP_CODEPUPOPMENU = clsPhaparpupopmenu.PP_CODEPUPOPMENU;
			this.EC_CODECRAN = clsPhaparpupopmenu.EC_CODECRAN;
			this.PP_NOMPUPOPMENU = clsPhaparpupopmenu.PP_NOMPUPOPMENU;
			this.PP_LIBELLE = clsPhaparpupopmenu.PP_LIBELLE;
		}

		#endregion

	}
}
