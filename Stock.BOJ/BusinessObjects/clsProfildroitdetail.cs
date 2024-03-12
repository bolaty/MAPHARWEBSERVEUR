using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsProfildroitdetail
	{
		#region VARIABLES LOCALES

		private string _PO_CODEPROFIL = "";
		private string _OP_CODEOBJET = "";
		private string _PD_AUTORISER = "";
		private int _PD_NUMEROORDRE = 0;

		#endregion

		#region ACCESSEURS

		public string PO_CODEPROFIL
		{
			get { return _PO_CODEPROFIL; }
			set {  _PO_CODEPROFIL = value; }
		}

		public string OP_CODEOBJET
		{
			get { return _OP_CODEOBJET; }
			set {  _OP_CODEOBJET = value; }
		}

		public string PD_AUTORISER
		{
			get { return _PD_AUTORISER; }
			set {  _PD_AUTORISER = value; }
		}

		public int PD_NUMEROORDRE
		{
			get { return _PD_NUMEROORDRE; }
			set {  _PD_NUMEROORDRE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsProfildroitdetail(){}
		public clsProfildroitdetail( string PO_CODEPROFIL,string OP_CODEOBJET,string PD_AUTORISER,int PD_NUMEROORDRE)
		{
			this.PO_CODEPROFIL = PO_CODEPROFIL;
			this.OP_CODEOBJET = OP_CODEOBJET;
			this.PD_AUTORISER = PD_AUTORISER;
			this.PD_NUMEROORDRE = PD_NUMEROORDRE;
		}
		public clsProfildroitdetail(clsProfildroitdetail clsProfildroitdetail)
		{
			this.PO_CODEPROFIL = clsProfildroitdetail.PO_CODEPROFIL;
			this.OP_CODEOBJET = clsProfildroitdetail.OP_CODEOBJET;
			this.PD_AUTORISER = clsProfildroitdetail.PD_AUTORISER;
			this.PD_NUMEROORDRE = clsProfildroitdetail.PD_NUMEROORDRE;
		}

		#endregion

	}
}
