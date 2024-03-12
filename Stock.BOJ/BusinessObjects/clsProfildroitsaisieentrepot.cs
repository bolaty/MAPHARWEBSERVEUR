using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsProfildroitsaisieentrepot
	{
		#region VARIABLES LOCALES

		private string _PO_CODEPROFIL = "";
		private string _EN_CODEENTREPOT = "";
        private string _COCHER = "";
		#endregion

		#region ACCESSEURS

		public string PO_CODEPROFIL
		{
			get { return _PO_CODEPROFIL; }
			set {  _PO_CODEPROFIL = value; }
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

		public clsProfildroitsaisieentrepot(){}
		public clsProfildroitsaisieentrepot( string PO_CODEPROFIL,string EN_CODEENTREPOT)
		{
			this.PO_CODEPROFIL = PO_CODEPROFIL;
			this.EN_CODEENTREPOT = EN_CODEENTREPOT;
		}
		public clsProfildroitsaisieentrepot(clsProfildroitsaisieentrepot clsProfildroitsaisieentrepot)
		{
			this.PO_CODEPROFIL = clsProfildroitsaisieentrepot.PO_CODEPROFIL;
			this.EN_CODEENTREPOT = clsProfildroitsaisieentrepot.EN_CODEENTREPOT;
            this.COCHER = clsProfildroitsaisieentrepot.COCHER;

		}

		#endregion

	}
}
