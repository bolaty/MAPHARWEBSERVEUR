using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsPhaparpupopmenuecranmodecalculeparam
	{
		#region VARIABLES LOCALES

		private string _EC_CODECRAN = "";
		private string _TP_CODETYPEPRIX = "";
		private string _MC_CODEMODECALCUE = "";
        private string _MC_LIBELLE = "";
		#endregion

		#region ACCESSEURS

		public string EC_CODECRAN
		{
			get { return _EC_CODECRAN; }
			set {  _EC_CODECRAN = value; }
		}

		public string TP_CODETYPEPRIX
		{
			get { return _TP_CODETYPEPRIX; }
			set {  _TP_CODETYPEPRIX = value; }
		}

		public string MC_CODEMODECALCUE
		{
			get { return _MC_CODEMODECALCUE; }
			set {  _MC_CODEMODECALCUE = value; }
		}
        public string MC_LIBELLE
		{
            get { return _MC_LIBELLE; }
            set { _MC_LIBELLE = value; }
		}

		#endregion

		#region INSTANCIATEURS

		public clsPhaparpupopmenuecranmodecalculeparam(){}
		
		public clsPhaparpupopmenuecranmodecalculeparam(clsPhaparpupopmenuecranmodecalculeparam clsPhaparpupopmenuecranmodecalculeparam)
		{
			this.EC_CODECRAN = clsPhaparpupopmenuecranmodecalculeparam.EC_CODECRAN;
			this.TP_CODETYPEPRIX = clsPhaparpupopmenuecranmodecalculeparam.TP_CODETYPEPRIX;
			this.MC_CODEMODECALCUE = clsPhaparpupopmenuecranmodecalculeparam.MC_CODEMODECALCUE;
            this.MC_LIBELLE = clsPhaparpupopmenuecranmodecalculeparam.MC_LIBELLE;
		}

		#endregion

	}
}
