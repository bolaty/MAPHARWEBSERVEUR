using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsPhaparpathologie
	{
		#region VARIABLES LOCALES

		private string _PA_CODEPATHOLOGIE = "";
		private string _SR_CODESERVICE = "";
		private string _PA_LIBELLE = "";

		#endregion

		#region ACCESSEURS

		public string PA_CODEPATHOLOGIE
		{
			get { return _PA_CODEPATHOLOGIE; }
			set {  _PA_CODEPATHOLOGIE = value; }
		}

		public string SR_CODESERVICE
		{
			get { return _SR_CODESERVICE; }
			set {  _SR_CODESERVICE = value; }
		}

		public string PA_LIBELLE
		{
			get { return _PA_LIBELLE; }
			set {  _PA_LIBELLE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsPhaparpathologie(){}
		public clsPhaparpathologie( string PA_CODEPATHOLOGIE,string SR_CODESERVICE,string PA_LIBELLE)
		{
			this.PA_CODEPATHOLOGIE = PA_CODEPATHOLOGIE;
			this.SR_CODESERVICE = SR_CODESERVICE;
			this.PA_LIBELLE = PA_LIBELLE;
		}
		public clsPhaparpathologie(clsPhaparpathologie clsPhaparpathologie)
		{
			this.PA_CODEPATHOLOGIE = clsPhaparpathologie.PA_CODEPATHOLOGIE;
			this.SR_CODESERVICE = clsPhaparpathologie.SR_CODESERVICE;
			this.PA_LIBELLE = clsPhaparpathologie.PA_LIBELLE;
		}

		#endregion

	}
}
