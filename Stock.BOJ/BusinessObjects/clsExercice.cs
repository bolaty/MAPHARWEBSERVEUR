using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.BOJ
{
	public class clsExercice
	{

        private string _AG_CODEAGENCE = "";
		private string _EX_EXERCICE = "";
        private DateTime _JT_DATEJOURNEETRAVAIL = DateTime.Parse("01/01/1900");
		private DateTime _EX_DATEDEBUT = DateTime.Parse("01/01/1900");
		private DateTime _EX_DATEFIN = DateTime.Parse("01/01/1900");
		private string _EX_DESCEXERCICE = "";
		private string _EX_ETATEXERCICE = "";
		private DateTime _EX_DATESAISIE = DateTime.Parse("01/01/1900");
		private string _EX_EXERCICEENCOURS = "";


        public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set { _AG_CODEAGENCE = value; }
		}
		public string EX_EXERCICE
		{
			get { return _EX_EXERCICE; }
			set { _EX_EXERCICE = value; }
		}

        public DateTime JT_DATEJOURNEETRAVAIL
		{
            get { return _JT_DATEJOURNEETRAVAIL; }
            set { _JT_DATEJOURNEETRAVAIL = value; }
		}
		public DateTime EX_DATEDEBUT
		{
			get { return _EX_DATEDEBUT; }
			set { _EX_DATEDEBUT = value; }
		}
		public DateTime EX_DATEFIN
		{
			get { return _EX_DATEFIN; }
			set { _EX_DATEFIN = value; }
		}
		public string EX_DESCEXERCICE
		{
			get { return _EX_DESCEXERCICE; }
			set { _EX_DESCEXERCICE = value; }
		}
		public string EX_ETATEXERCICE
		{
			get { return _EX_ETATEXERCICE; }
			set { _EX_ETATEXERCICE = value; }
		}
		public DateTime EX_DATESAISIE
		{
			get { return _EX_DATESAISIE; }
			set { _EX_DATESAISIE = value; }
		}

        public string EX_EXERCICEENCOURS
        {
	        get { return _EX_EXERCICEENCOURS; }
	        set { _EX_EXERCICEENCOURS = value; }
        }

        public clsExercice() {}

      

		public clsExercice(clsExercice clsExercice)
		{
			AG_CODEAGENCE = clsExercice.AG_CODEAGENCE;
			EX_EXERCICE = clsExercice.EX_EXERCICE;
            JT_DATEJOURNEETRAVAIL = clsExercice.JT_DATEJOURNEETRAVAIL;
			EX_DATEDEBUT = clsExercice.EX_DATEDEBUT;
			EX_DATEFIN = clsExercice.EX_DATEFIN;
			EX_DESCEXERCICE = clsExercice.EX_DESCEXERCICE;
			EX_ETATEXERCICE = clsExercice.EX_ETATEXERCICE;
			EX_DATESAISIE = clsExercice.EX_DATESAISIE;
            EX_EXERCICEENCOURS = clsExercice.EX_EXERCICEENCOURS;
		}
        }
}