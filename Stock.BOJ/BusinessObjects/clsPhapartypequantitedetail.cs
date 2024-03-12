using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsPhapartypequantitedetail
	{
		#region VARIABLES LOCALES

		private string _TQ_CODETYPEQUANTITE = "";
		private string _AR_CODEARTICLE = "";
		private int _TQ_QUANTITE = 0;
		private string _TQ_PERSONNECONCERNEE = "";

		#endregion

		#region ACCESSEURS

		public string TQ_CODETYPEQUANTITE
		{
			get { return _TQ_CODETYPEQUANTITE; }
			set {  _TQ_CODETYPEQUANTITE = value; }
		}

		public string AR_CODEARTICLE
		{
			get { return _AR_CODEARTICLE; }
			set {  _AR_CODEARTICLE = value; }
		}

		public int TQ_QUANTITE
		{
			get { return _TQ_QUANTITE; }
			set {  _TQ_QUANTITE = value; }
		}

		public string TQ_PERSONNECONCERNEE
		{
			get { return _TQ_PERSONNECONCERNEE; }
			set {  _TQ_PERSONNECONCERNEE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsPhapartypequantitedetail(){}
		public clsPhapartypequantitedetail( string TQ_CODETYPEQUANTITE,string AR_CODEARTICLE,int TQ_QUANTITE,string TQ_PERSONNECONCERNEE)
		{
			this.TQ_CODETYPEQUANTITE = TQ_CODETYPEQUANTITE;
			this.AR_CODEARTICLE = AR_CODEARTICLE;
			this.TQ_QUANTITE = TQ_QUANTITE;
			this.TQ_PERSONNECONCERNEE = TQ_PERSONNECONCERNEE;
		}
		public clsPhapartypequantitedetail(clsPhapartypequantitedetail clsPhapartypequantitedetail)
		{
			this.TQ_CODETYPEQUANTITE = clsPhapartypequantitedetail.TQ_CODETYPEQUANTITE;
			this.AR_CODEARTICLE = clsPhapartypequantitedetail.AR_CODEARTICLE;
			this.TQ_QUANTITE = clsPhapartypequantitedetail.TQ_QUANTITE;
			this.TQ_PERSONNECONCERNEE = clsPhapartypequantitedetail.TQ_PERSONNECONCERNEE;
		}

		#endregion

	}
}
