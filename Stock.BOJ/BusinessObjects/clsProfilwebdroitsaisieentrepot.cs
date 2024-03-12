using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsProfilwebdroitsaisieentrepot
	{
		#region VARIABLES LOCALES

		private string _PO_CODEPROFILWEB = "";
		private string _EN_CODEENTREPOT = "";
        private string _COCHER = "";
		#endregion

		#region ACCESSEURS

		public string PO_CODEPROFILWEB
		{
			get { return _PO_CODEPROFILWEB; }
			set {  _PO_CODEPROFILWEB = value; }
		}

		public string EN_CODEENTREPOT
		{
			get { return _EN_CODEENTREPOT; }
			set {  _EN_CODEENTREPOT = value; }
		}
        public string COCHER
		{
            get { return _COCHER; }
            set { _COCHER = value; }
		}

		#endregion

		#region INSTANCIATEURS

		public clsProfilwebdroitsaisieentrepot(){}
		public clsProfilwebdroitsaisieentrepot( string PO_CODEPROFILWEB,string EN_CODEENTREPOT)
		{
			this.PO_CODEPROFILWEB = PO_CODEPROFILWEB;
			this.EN_CODEENTREPOT = EN_CODEENTREPOT;
		}
		public clsProfilwebdroitsaisieentrepot(clsProfilwebdroitsaisieentrepot clsProfilwebdroitsaisieentrepot)
		{
			this.PO_CODEPROFILWEB = clsProfilwebdroitsaisieentrepot.PO_CODEPROFILWEB;
			this.EN_CODEENTREPOT = clsProfilwebdroitsaisieentrepot.EN_CODEENTREPOT;
            this.COCHER = clsProfilwebdroitsaisieentrepot.COCHER;

		}

		#endregion

	}
}
