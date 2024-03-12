using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsPhamouvementstockfiltragedestockm2
	{
		#region VARIABLES LOCALES

		private string _MF_IDFILTRAGEDESTOCKM2 = "";
		private string _MF_NUMEROLOTFILTRAGEDESTOCKM2 = "";
		private string _MF_DESCRIPTIONFILTRAGEDESTOCKM2 = "";
		private string _OP_CODEOPERATEUR = "";
		private DateTime _MF_DATESAISIEFILTRAGEDESTOCKM2 = DateTime.Parse("01/01/1900");
		private DateTime _MF_DATECLOTUREFILTRAGEDESTOCKM2 = DateTime.Parse("01/01/1900");
		private string _TYPEOPERATION = "";
		#endregion

		#region ACCESSEURS

		public string MF_IDFILTRAGEDESTOCKM2
		{
			get { return _MF_IDFILTRAGEDESTOCKM2; }
			set {  _MF_IDFILTRAGEDESTOCKM2 = value; }
		}

		public string MF_NUMEROLOTFILTRAGEDESTOCKM2
		{
			get { return _MF_NUMEROLOTFILTRAGEDESTOCKM2; }
			set {  _MF_NUMEROLOTFILTRAGEDESTOCKM2 = value; }
		}

		public string MF_DESCRIPTIONFILTRAGEDESTOCKM2
		{
			get { return _MF_DESCRIPTIONFILTRAGEDESTOCKM2; }
			set {  _MF_DESCRIPTIONFILTRAGEDESTOCKM2 = value; }
		}

		public string OP_CODEOPERATEUR
		{
			get { return _OP_CODEOPERATEUR; }
			set {  _OP_CODEOPERATEUR = value; }
		}

		public DateTime MF_DATESAISIEFILTRAGEDESTOCKM2
		{
			get { return _MF_DATESAISIEFILTRAGEDESTOCKM2; }
			set {  _MF_DATESAISIEFILTRAGEDESTOCKM2 = value; }
		}

		public DateTime MF_DATECLOTUREFILTRAGEDESTOCKM2
		{
			get { return _MF_DATECLOTUREFILTRAGEDESTOCKM2; }
			set {  _MF_DATECLOTUREFILTRAGEDESTOCKM2 = value; }
		}
        public string TYPEOPERATION
        {
	        get { return _TYPEOPERATION; }
	        set { _TYPEOPERATION = value; }
        }

		#endregion

		#region INSTANCIATEURS

		public clsPhamouvementstockfiltragedestockm2(){}
		
		public clsPhamouvementstockfiltragedestockm2(clsPhamouvementstockfiltragedestockm2 clsPhamouvementstockfiltragedestockm2)
		{
			this.MF_IDFILTRAGEDESTOCKM2 = clsPhamouvementstockfiltragedestockm2.MF_IDFILTRAGEDESTOCKM2;
			this.MF_NUMEROLOTFILTRAGEDESTOCKM2 = clsPhamouvementstockfiltragedestockm2.MF_NUMEROLOTFILTRAGEDESTOCKM2;
			this.MF_DESCRIPTIONFILTRAGEDESTOCKM2 = clsPhamouvementstockfiltragedestockm2.MF_DESCRIPTIONFILTRAGEDESTOCKM2;
			this.OP_CODEOPERATEUR = clsPhamouvementstockfiltragedestockm2.OP_CODEOPERATEUR;
			this.MF_DATESAISIEFILTRAGEDESTOCKM2 = clsPhamouvementstockfiltragedestockm2.MF_DATESAISIEFILTRAGEDESTOCKM2;
			this.MF_DATECLOTUREFILTRAGEDESTOCKM2 = clsPhamouvementstockfiltragedestockm2.MF_DATECLOTUREFILTRAGEDESTOCKM2;
			this.TYPEOPERATION = clsPhamouvementstockfiltragedestockm2.TYPEOPERATION;
		}

		#endregion

	}
}
