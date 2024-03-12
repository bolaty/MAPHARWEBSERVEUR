using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsProfildroitagence
	{
		#region VARIABLES LOCALES

		private string _PO_CODEPROFIL = "";
		private string _AG_CODEAGENCE = "";

		#endregion

		#region ACCESSEURS

		public string PO_CODEPROFIL
		{
			get { return _PO_CODEPROFIL; }
			set {  _PO_CODEPROFIL = value; }
		}

		public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set {  _AG_CODEAGENCE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsProfildroitagence(){}
		public clsProfildroitagence( string PO_CODEPROFIL,string AG_CODEAGENCE)
		{
			this.PO_CODEPROFIL = PO_CODEPROFIL;
			this.AG_CODEAGENCE = AG_CODEAGENCE;
		}
		public clsProfildroitagence(clsProfildroitagence clsProfildroitagence)
		{
			this.PO_CODEPROFIL = clsProfildroitagence.PO_CODEPROFIL;
			this.AG_CODEAGENCE = clsProfildroitagence.AG_CODEAGENCE;
		}

		#endregion

	}
}
