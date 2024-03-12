using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsPhaparsectiontiers
	{
		#region VARIABLES LOCALES
        private string _AG_CODEAGENCE = "";
		private string _SC_CODESECTION = "";
		private string _TI_IDTIERS = "";
        private string _COCHER = "";
		private DateTime _ST_DATESAISIE = DateTime.Parse("01/01/1900");
		private DateTime _ST_DATEDEPART = DateTime.Parse("01/01/1900");
        private string _OP_CODEOPERATEUR = "";
		#endregion

		#region ACCESSEURS

        public string AG_CODEAGENCE
        {
            get { return _AG_CODEAGENCE; }
            set { _AG_CODEAGENCE = value; }
        }

		public string SC_CODESECTION
		{
			get { return _SC_CODESECTION; }
			set {  _SC_CODESECTION = value; }
		}

		public string TI_IDTIERS
		{
			get { return _TI_IDTIERS; }
			set {  _TI_IDTIERS = value; }
		}
        public string COCHER
        {
            get { return _COCHER; }
            set { _COCHER = value; }
        }
		public DateTime ST_DATESAISIE
		{
			get { return _ST_DATESAISIE; }
			set {  _ST_DATESAISIE = value; }
		}

		public DateTime ST_DATEDEPART
		{
			get { return _ST_DATEDEPART; }
			set {  _ST_DATEDEPART = value; }
		}

        public string OP_CODEOPERATEUR
        {
            get { return _OP_CODEOPERATEUR; }
            set { _OP_CODEOPERATEUR = value; }
        }

		#endregion

		#region INSTANCIATEURS

		public clsPhaparsectiontiers(){}
		
		public clsPhaparsectiontiers(clsPhaparsectiontiers clsPhaparsectiontiers)
		{
            this.AG_CODEAGENCE = clsPhaparsectiontiers.AG_CODEAGENCE;
            this.SC_CODESECTION = clsPhaparsectiontiers.SC_CODESECTION;
			this.TI_IDTIERS = clsPhaparsectiontiers.TI_IDTIERS;
            this.COCHER = clsPhaparsectiontiers.COCHER;
			this.ST_DATESAISIE = clsPhaparsectiontiers.ST_DATESAISIE;
			this.ST_DATEDEPART = clsPhaparsectiontiers.ST_DATEDEPART;
            this.OP_CODEOPERATEUR = clsPhaparsectiontiers.OP_CODEOPERATEUR;
		}

		#endregion

	}
}
