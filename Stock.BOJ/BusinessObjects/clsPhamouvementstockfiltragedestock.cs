using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsPhamouvementstockfiltragedestock
	{
		#region VARIABLES LOCALES

		private string _MF_IDFILTRAGEDESTOCK = "";
		private string _MF_NUMEROLOTFILTRAGEDESTOCK = "";
		private string _MF_DESCRIPTIONFILTRAGEDESTOCK = "";
		private string _OP_CODEOPERATEUR = "";
		private DateTime _MF_DATESAISIEFILTRAGEDESTOCK = DateTime.Parse("01/01/1900");
		private DateTime _MF_DATECLOTUREFILTRAGEDESTOCK = DateTime.Parse("01/01/1900");
		private string _TYPEOPERATION = "";


		#endregion

		#region ACCESSEURS

		public string MF_IDFILTRAGEDESTOCK
		{
			get { return _MF_IDFILTRAGEDESTOCK; }
			set {  _MF_IDFILTRAGEDESTOCK = value; }
		}

		public string MF_NUMEROLOTFILTRAGEDESTOCK
		{
			get { return _MF_NUMEROLOTFILTRAGEDESTOCK; }
			set {  _MF_NUMEROLOTFILTRAGEDESTOCK = value; }
		}

		public string MF_DESCRIPTIONFILTRAGEDESTOCK
		{
			get { return _MF_DESCRIPTIONFILTRAGEDESTOCK; }
			set {  _MF_DESCRIPTIONFILTRAGEDESTOCK = value; }
		}

		public string OP_CODEOPERATEUR
		{
			get { return _OP_CODEOPERATEUR; }
			set {  _OP_CODEOPERATEUR = value; }
		}

		public DateTime MF_DATESAISIEFILTRAGEDESTOCK
		{
			get { return _MF_DATESAISIEFILTRAGEDESTOCK; }
			set {  _MF_DATESAISIEFILTRAGEDESTOCK = value; }
		}

		public DateTime MF_DATECLOTUREFILTRAGEDESTOCK
		{
			get { return _MF_DATECLOTUREFILTRAGEDESTOCK; }
			set {  _MF_DATECLOTUREFILTRAGEDESTOCK = value; }
		}
        public string TYPEOPERATION
        {
	        get { return _TYPEOPERATION; }
	        set { _TYPEOPERATION = value; }
        }

		#endregion

		#region INSTANCIATEURS

		public clsPhamouvementstockfiltragedestock(){}

		public clsPhamouvementstockfiltragedestock(clsPhamouvementstockfiltragedestock clsPhamouvementstockfiltragedestock)
		{
			this.MF_IDFILTRAGEDESTOCK = clsPhamouvementstockfiltragedestock.MF_IDFILTRAGEDESTOCK;
			this.MF_NUMEROLOTFILTRAGEDESTOCK = clsPhamouvementstockfiltragedestock.MF_NUMEROLOTFILTRAGEDESTOCK;
			this.MF_DESCRIPTIONFILTRAGEDESTOCK = clsPhamouvementstockfiltragedestock.MF_DESCRIPTIONFILTRAGEDESTOCK;
			this.OP_CODEOPERATEUR = clsPhamouvementstockfiltragedestock.OP_CODEOPERATEUR;
			this.MF_DATESAISIEFILTRAGEDESTOCK = clsPhamouvementstockfiltragedestock.MF_DATESAISIEFILTRAGEDESTOCK;
			this.MF_DATECLOTUREFILTRAGEDESTOCK = clsPhamouvementstockfiltragedestock.MF_DATECLOTUREFILTRAGEDESTOCK;
			this.TYPEOPERATION = clsPhamouvementstockfiltragedestock.TYPEOPERATION;

		}

		#endregion

	}
}
