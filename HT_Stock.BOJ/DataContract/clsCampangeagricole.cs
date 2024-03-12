using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsCampangeagricole
	{
		#region VARIABLES LOCALES

		private string _CA_CODECAMPAGNE = "";
		private string _AG_CODEAGENCE ="";
		private double _CA_LIBELLEANNEEDEBUT = 0;
		private DateTime _CA_DATEDEBUT = DateTime.Parse("01/01/1900");
		private DateTime _CA_DATECLOTURE = DateTime.Parse("01/01/1900");
		private double _CA_LIBELLEANNEEFIN = 0;
        private int _TYPEOPERATION = 0;

		#endregion

		#region ACCESSEURS

		public string CA_CODECAMPAGNE
		{
			get { return _CA_CODECAMPAGNE; }
			set {  _CA_CODECAMPAGNE = value; }
		}

		public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set {  _AG_CODEAGENCE = value; }
		}

        public double CA_LIBELLEANNEEDEBUT
		{
			get { return _CA_LIBELLEANNEEDEBUT; }
			set {  _CA_LIBELLEANNEEDEBUT = value; }
		}

		public DateTime CA_DATEDEBUT
		{
			get { return _CA_DATEDEBUT; }
			set {  _CA_DATEDEBUT = value; }
		}

		public DateTime CA_DATECLOTURE
		{
			get { return _CA_DATECLOTURE; }
			set {  _CA_DATECLOTURE = value; }
		}

		public double CA_LIBELLEANNEEFIN
		{
			get { return _CA_LIBELLEANNEEFIN; }
			set {  _CA_LIBELLEANNEEFIN = value; }
		}
         public int TYPEOPERATION
        {
            get { return _TYPEOPERATION; }
            set { _TYPEOPERATION = value; }
        }


		#endregion

		#region INSTANCIATEURS

		public clsCampangeagricole(){}
        public clsCampangeagricole(string CA_CODECAMPAGNE, string AG_CODEAGENCE, double CA_LIBELLEANNEEDEBUT, DateTime CA_DATEDEBUT, DateTime CA_DATECLOTURE, double CA_LIBELLEANNEEFIN, int TYPEOPERATION)
		{
			this.CA_CODECAMPAGNE = CA_CODECAMPAGNE;
			this.AG_CODEAGENCE = AG_CODEAGENCE;
			this.CA_LIBELLEANNEEDEBUT = CA_LIBELLEANNEEDEBUT;
			this.CA_DATEDEBUT = CA_DATEDEBUT;
			this.CA_DATECLOTURE = CA_DATECLOTURE;
			this.CA_LIBELLEANNEEFIN = CA_LIBELLEANNEEFIN;
            this.TYPEOPERATION = TYPEOPERATION;
		}
		public clsCampangeagricole(clsCampangeagricole clsCampangeagricole)
		{
			this.CA_CODECAMPAGNE = clsCampangeagricole.CA_CODECAMPAGNE;
			this.AG_CODEAGENCE = clsCampangeagricole.AG_CODEAGENCE;
			this.CA_LIBELLEANNEEDEBUT = clsCampangeagricole.CA_LIBELLEANNEEDEBUT;
			this.CA_DATEDEBUT = clsCampangeagricole.CA_DATEDEBUT;
			this.CA_DATECLOTURE = clsCampangeagricole.CA_DATECLOTURE;
			this.CA_LIBELLEANNEEFIN = clsCampangeagricole.CA_LIBELLEANNEEFIN;
            this.TYPEOPERATION = clsCampangeagricole.TYPEOPERATION;
		}

		#endregion

	}
}
