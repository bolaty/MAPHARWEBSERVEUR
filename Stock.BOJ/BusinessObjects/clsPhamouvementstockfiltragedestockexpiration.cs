using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsPhamouvementstockfiltragedestockexpiration
	{
		#region VARIABLES LOCALES

		private string _ME_IDFILTRAGEDESTOCKEXPIRATION = "";
		private string _ME_LIBELLEFILTRAGEDESTOCKEXPIRATION = "";
		private string _OP_CODEOPERATEUR = "";
		private DateTime _ME_DATEEXPIRATIONFILTRAGEDESTOCKEXPIRATION = DateTime.Parse("01/01/1900");
		private DateTime _ME_DATESAISIEFILTRAGEDESTOCKEXPIRATION = DateTime.Parse("01/01/1900");
		private DateTime _ME_DATECLOTUREFILTRAGEDESTOCKEXPIRATION = DateTime.Parse("01/01/1900");
		private string _TYPEOPERATION = "";


		#endregion

		#region ACCESSEURS

		public string ME_IDFILTRAGEDESTOCKEXPIRATION
		{
			get { return _ME_IDFILTRAGEDESTOCKEXPIRATION; }
			set {  _ME_IDFILTRAGEDESTOCKEXPIRATION = value; }
		}

		public string ME_LIBELLEFILTRAGEDESTOCKEXPIRATION
		{
			get { return _ME_LIBELLEFILTRAGEDESTOCKEXPIRATION; }
			set {  _ME_LIBELLEFILTRAGEDESTOCKEXPIRATION = value; }
		}

		public string OP_CODEOPERATEUR
		{
			get { return _OP_CODEOPERATEUR; }
			set {  _OP_CODEOPERATEUR = value; }
		}

		public DateTime ME_DATEEXPIRATIONFILTRAGEDESTOCKEXPIRATION
		{
			get { return _ME_DATEEXPIRATIONFILTRAGEDESTOCKEXPIRATION; }
			set {  _ME_DATEEXPIRATIONFILTRAGEDESTOCKEXPIRATION = value; }
		}

		public DateTime ME_DATESAISIEFILTRAGEDESTOCKEXPIRATION
		{
			get { return _ME_DATESAISIEFILTRAGEDESTOCKEXPIRATION; }
			set {  _ME_DATESAISIEFILTRAGEDESTOCKEXPIRATION = value; }
		}

		public DateTime ME_DATECLOTUREFILTRAGEDESTOCKEXPIRATION
		{
			get { return _ME_DATECLOTUREFILTRAGEDESTOCKEXPIRATION; }
			set {  _ME_DATECLOTUREFILTRAGEDESTOCKEXPIRATION = value; }
		}

        public string TYPEOPERATION
        {
	        get { return _TYPEOPERATION; }
	        set { _TYPEOPERATION = value; }
        }

		#endregion

		#region INSTANCIATEURS

		public clsPhamouvementstockfiltragedestockexpiration(){}
		
		public clsPhamouvementstockfiltragedestockexpiration(clsPhamouvementstockfiltragedestockexpiration clsPhamouvementstockfiltragedestockexpiration)
		{
			this.ME_IDFILTRAGEDESTOCKEXPIRATION = clsPhamouvementstockfiltragedestockexpiration.ME_IDFILTRAGEDESTOCKEXPIRATION;
			this.ME_LIBELLEFILTRAGEDESTOCKEXPIRATION = clsPhamouvementstockfiltragedestockexpiration.ME_LIBELLEFILTRAGEDESTOCKEXPIRATION;
			this.OP_CODEOPERATEUR = clsPhamouvementstockfiltragedestockexpiration.OP_CODEOPERATEUR;
			this.ME_DATEEXPIRATIONFILTRAGEDESTOCKEXPIRATION = clsPhamouvementstockfiltragedestockexpiration.ME_DATEEXPIRATIONFILTRAGEDESTOCKEXPIRATION;
			this.ME_DATESAISIEFILTRAGEDESTOCKEXPIRATION = clsPhamouvementstockfiltragedestockexpiration.ME_DATESAISIEFILTRAGEDESTOCKEXPIRATION;
			this.ME_DATECLOTUREFILTRAGEDESTOCKEXPIRATION = clsPhamouvementstockfiltragedestockexpiration.ME_DATECLOTUREFILTRAGEDESTOCKEXPIRATION;
			this.TYPEOPERATION = clsPhamouvementstockfiltragedestockexpiration.TYPEOPERATION;


		}

		#endregion

	}
}
