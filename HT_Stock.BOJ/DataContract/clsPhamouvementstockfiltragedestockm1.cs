using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsPhamouvementstockfiltragedestockm1
	{
		#region VARIABLES LOCALES

		private string _MF_IDFILTRAGEDESTOCKM1 = "";
		private string _MF_LIBELLEFILTRAGEDESTOCKM1 = "";
		private string _OP_CODEOPERATEUR = "";
		private DateTime _MF_DATEFABRICATIONFILTRAGEDESTOCKM1 = DateTime.Parse("01/01/1900");
		private DateTime _MF_DATESAISIEFILTRAGEDESTOCKM1 = DateTime.Parse("01/01/1900");
		private DateTime _MF_DATECLOTUREFILTRAGEDESTOCKM1 = DateTime.Parse("01/01/1900");
		private string _TYPEOPERATION = "";
		#endregion

		#region ACCESSEURS

		public string MF_IDFILTRAGEDESTOCKM1
		{
			get { return _MF_IDFILTRAGEDESTOCKM1; }
			set {  _MF_IDFILTRAGEDESTOCKM1 = value; }
		}

		public string MF_LIBELLEFILTRAGEDESTOCKM1
		{
			get { return _MF_LIBELLEFILTRAGEDESTOCKM1; }
			set {  _MF_LIBELLEFILTRAGEDESTOCKM1 = value; }
		}

		public string OP_CODEOPERATEUR
		{
			get { return _OP_CODEOPERATEUR; }
			set {  _OP_CODEOPERATEUR = value; }
		}


		public DateTime MF_DATEFABRICATIONFILTRAGEDESTOCKM1
        {
			get { return _MF_DATEFABRICATIONFILTRAGEDESTOCKM1; }
			set { _MF_DATEFABRICATIONFILTRAGEDESTOCKM1 = value; }
		}

		public DateTime MF_DATESAISIEFILTRAGEDESTOCKM1
		{
			get { return _MF_DATESAISIEFILTRAGEDESTOCKM1; }
			set {  _MF_DATESAISIEFILTRAGEDESTOCKM1 = value; }
		}

		public DateTime MF_DATECLOTUREFILTRAGEDESTOCKM1
		{
			get { return _MF_DATECLOTUREFILTRAGEDESTOCKM1; }
			set {  _MF_DATECLOTUREFILTRAGEDESTOCKM1 = value; }
		}

        public string TYPEOPERATION
        {
	        get { return _TYPEOPERATION; }
	        set { _TYPEOPERATION = value; }
        }

		#endregion

		#region INSTANCIATEURS

		public clsPhamouvementstockfiltragedestockm1(){}
		
		public clsPhamouvementstockfiltragedestockm1(clsPhamouvementstockfiltragedestockm1 clsPhamouvementstockfiltragedestockm1)
		{
			this.MF_IDFILTRAGEDESTOCKM1 = clsPhamouvementstockfiltragedestockm1.MF_IDFILTRAGEDESTOCKM1;
			this.MF_LIBELLEFILTRAGEDESTOCKM1 = clsPhamouvementstockfiltragedestockm1.MF_LIBELLEFILTRAGEDESTOCKM1;
			this.OP_CODEOPERATEUR = clsPhamouvementstockfiltragedestockm1.OP_CODEOPERATEUR;
			this.MF_DATEFABRICATIONFILTRAGEDESTOCKM1 = clsPhamouvementstockfiltragedestockm1.MF_DATEFABRICATIONFILTRAGEDESTOCKM1;
			this.MF_DATESAISIEFILTRAGEDESTOCKM1 = clsPhamouvementstockfiltragedestockm1.MF_DATESAISIEFILTRAGEDESTOCKM1;
			this.MF_DATECLOTUREFILTRAGEDESTOCKM1 = clsPhamouvementstockfiltragedestockm1.MF_DATECLOTUREFILTRAGEDESTOCKM1;
			this.TYPEOPERATION = clsPhamouvementstockfiltragedestockm1.TYPEOPERATION;
		}

		#endregion

	}
}
