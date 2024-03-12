using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsPhaparpupopmenumodegestionlibelleparametre
	{
		#region VARIABLES LOCALES

		private string _MG_CODEMODEGESTION = "";
		private string _LB_CODELIBELLE = "";
        private string _LB_MOTUTILISE = "";
        private string _LB_MOTAREMPLACER = "";

		#endregion

		#region ACCESSEURS

		public string MG_CODEMODEGESTION
		{
			get { return _MG_CODEMODEGESTION; }
			set {  _MG_CODEMODEGESTION = value; }
		}

		public string LB_CODELIBELLE
		{
			get { return _LB_CODELIBELLE; }
			set {  _LB_CODELIBELLE = value; }
		}
        public string LB_MOTUTILISE
		{
            get { return _LB_MOTUTILISE; }
            set { _LB_MOTUTILISE = value; }
		}
        public string LB_MOTAREMPLACER
		{
            get { return _LB_MOTAREMPLACER; }
            set { _LB_MOTAREMPLACER = value; }
		}
		#endregion

		#region INSTANCIATEURS

		public clsPhaparpupopmenumodegestionlibelleparametre(){}
		
		public clsPhaparpupopmenumodegestionlibelleparametre(clsPhaparpupopmenumodegestionlibelleparametre clsPhaparpupopmenumodegestionlibelleparametre)
		{
			this.MG_CODEMODEGESTION = clsPhaparpupopmenumodegestionlibelleparametre.MG_CODEMODEGESTION;
			this.LB_CODELIBELLE = clsPhaparpupopmenumodegestionlibelleparametre.LB_CODELIBELLE;
            this.LB_MOTUTILISE = clsPhaparpupopmenumodegestionlibelleparametre.LB_MOTUTILISE;
            this.LB_MOTAREMPLACER = clsPhaparpupopmenumodegestionlibelleparametre.LB_MOTAREMPLACER;

		}

		#endregion

	}
}
