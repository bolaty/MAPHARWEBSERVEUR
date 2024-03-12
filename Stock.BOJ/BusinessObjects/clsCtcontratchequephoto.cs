using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsCtcontratchequephoto
	{
		#region VARIABLES LOCALES

		private string _AG_CODEAGENCE = "";
		private DateTime _CH_DATESAISIECHEQUE = DateTime.Parse("01/01/1900");
		private string _CH_IDEXCHEQUE = "";
		private string _CH_NUMSEQUENCEPHOTO = "";
		private string _CH_CHEMINPHOTOCHEQUE = "";
		private string _CH_LIBELLEPHOTOCHEQUE = "";
		private int _TYPEOPERATION = 0;
		#endregion

		#region ACCESSEURS

		public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set {  _AG_CODEAGENCE = value; }
		}

		public DateTime CH_DATESAISIECHEQUE
		{
			get { return _CH_DATESAISIECHEQUE; }
			set {  _CH_DATESAISIECHEQUE = value; }
		}

		public string CH_IDEXCHEQUE
		{
			get { return _CH_IDEXCHEQUE; }
			set {  _CH_IDEXCHEQUE = value; }
		}

		public string CH_NUMSEQUENCEPHOTO
		{
			get { return _CH_NUMSEQUENCEPHOTO; }
			set {  _CH_NUMSEQUENCEPHOTO = value; }
		}

		public string CH_CHEMINPHOTOCHEQUE
		{
			get { return _CH_CHEMINPHOTOCHEQUE; }
			set {  _CH_CHEMINPHOTOCHEQUE = value; }
		}

		public string CH_LIBELLEPHOTOCHEQUE
		{
			get { return _CH_LIBELLEPHOTOCHEQUE; }
			set {  _CH_LIBELLEPHOTOCHEQUE = value; }
		}
        public int TYPEOPERATION
        {
	        get { return _TYPEOPERATION; }
	        set { _TYPEOPERATION = value; }
        }

		#endregion

		#region INSTANCIATEURS

		public clsCtcontratchequephoto(){}
		
		public clsCtcontratchequephoto(clsCtcontratchequephoto clsCtcontratchequephoto)
		{
			this.AG_CODEAGENCE = clsCtcontratchequephoto.AG_CODEAGENCE;
			this.CH_DATESAISIECHEQUE = clsCtcontratchequephoto.CH_DATESAISIECHEQUE;
			this.CH_IDEXCHEQUE = clsCtcontratchequephoto.CH_IDEXCHEQUE;
			this.CH_NUMSEQUENCEPHOTO = clsCtcontratchequephoto.CH_NUMSEQUENCEPHOTO;
			this.CH_CHEMINPHOTOCHEQUE = clsCtcontratchequephoto.CH_CHEMINPHOTOCHEQUE;
			this.CH_LIBELLEPHOTOCHEQUE = clsCtcontratchequephoto.CH_LIBELLEPHOTOCHEQUE;
			this.TYPEOPERATION = clsCtcontratchequephoto.TYPEOPERATION;
		}

		#endregion

	}
}
