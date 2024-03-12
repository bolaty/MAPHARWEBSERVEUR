using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsPhapartyperemisedetail
	{
		#region VARIABLES LOCALES

		private string _TR_CODETYPEQUANTITE = "";
		private string _AR_CODEARTICLE = "";
		private double _TR_MONTANT = 0;
		private string _TR_PERSONNECONCERNEE = "";

		#endregion

		#region ACCESSEURS

		public string TR_CODETYPEQUANTITE
		{
			get { return _TR_CODETYPEQUANTITE; }
			set {  _TR_CODETYPEQUANTITE = value; }
		}

		public string AR_CODEARTICLE
		{
			get { return _AR_CODEARTICLE; }
			set {  _AR_CODEARTICLE = value; }
		}

		public double TR_MONTANT
		{
			get { return _TR_MONTANT; }
			set {  _TR_MONTANT = value; }
		}

		public string TR_PERSONNECONCERNEE
		{
			get { return _TR_PERSONNECONCERNEE; }
			set {  _TR_PERSONNECONCERNEE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsPhapartyperemisedetail(){}
		public clsPhapartyperemisedetail( string TR_CODETYPEQUANTITE,string AR_CODEARTICLE,double TR_MONTANT,string TR_PERSONNECONCERNEE)
		{
			this.TR_CODETYPEQUANTITE = TR_CODETYPEQUANTITE;
			this.AR_CODEARTICLE = AR_CODEARTICLE;
			this.TR_MONTANT = TR_MONTANT;
			this.TR_PERSONNECONCERNEE = TR_PERSONNECONCERNEE;
		}
		public clsPhapartyperemisedetail(clsPhapartyperemisedetail clsPhapartyperemisedetail)
		{
			this.TR_CODETYPEQUANTITE = clsPhapartyperemisedetail.TR_CODETYPEQUANTITE;
			this.AR_CODEARTICLE = clsPhapartyperemisedetail.AR_CODEARTICLE;
			this.TR_MONTANT = clsPhapartyperemisedetail.TR_MONTANT;
			this.TR_PERSONNECONCERNEE = clsPhapartyperemisedetail.TR_PERSONNECONCERNEE;
		}

		#endregion

	}
}
