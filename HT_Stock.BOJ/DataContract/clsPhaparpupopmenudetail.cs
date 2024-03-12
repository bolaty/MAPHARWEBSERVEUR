using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsPhaparpupopmenudetail
	{
		#region VARIABLES LOCALES

		private string _DP_CODEDETAIL = "";
		private string _PP_CODEPUPOPMENU = "";
		private string _DP_NOMMENU = "";
		private string _DP_LIBELLE = "";
		private string _DP_AFFICHER = "";

		#endregion

		#region ACCESSEURS

		public string DP_CODEDETAIL
		{
			get { return _DP_CODEDETAIL; }
			set {  _DP_CODEDETAIL = value; }
		}

		public string PP_CODEPUPOPMENU
		{
			get { return _PP_CODEPUPOPMENU; }
			set {  _PP_CODEPUPOPMENU = value; }
		}

		public string DP_NOMMENU
		{
			get { return _DP_NOMMENU; }
			set {  _DP_NOMMENU = value; }
		}

		public string DP_LIBELLE
		{
			get { return _DP_LIBELLE; }
			set {  _DP_LIBELLE = value; }
		}

		public string DP_AFFICHER
		{
			get { return _DP_AFFICHER; }
			set {  _DP_AFFICHER = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsPhaparpupopmenudetail(){}
		public clsPhaparpupopmenudetail( string DP_CODEDETAIL,string PP_CODEPUPOPMENU,string DP_NOMMENU,string DP_LIBELLE,string DP_AFFICHER)
		{
			this.DP_CODEDETAIL = DP_CODEDETAIL;
			this.PP_CODEPUPOPMENU = PP_CODEPUPOPMENU;
			this.DP_NOMMENU = DP_NOMMENU;
			this.DP_LIBELLE = DP_LIBELLE;
			this.DP_AFFICHER = DP_AFFICHER;
		}
		public clsPhaparpupopmenudetail(clsPhaparpupopmenudetail clsPhaparpupopmenudetail)
		{
			this.DP_CODEDETAIL = clsPhaparpupopmenudetail.DP_CODEDETAIL;
			this.PP_CODEPUPOPMENU = clsPhaparpupopmenudetail.PP_CODEPUPOPMENU;
			this.DP_NOMMENU = clsPhaparpupopmenudetail.DP_NOMMENU;
			this.DP_LIBELLE = clsPhaparpupopmenudetail.DP_LIBELLE;
			this.DP_AFFICHER = clsPhaparpupopmenudetail.DP_AFFICHER;
		}

		#endregion

	}
}
