using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Stock.BOJ
{
	public class clsPhaparprixtypeclient
	{
        private string _AG_CODEAGENCE = "";
        private string _AR_CODEARTICLE = "";
		private string _NT_CODENATURETIERS = "";
		private double _PY_PRIXVENTE = 0;
        private double _PY_PRIXVENTEHT = 0;
		private double _PY_TAUXREMISE = 0;
		private double _PY_MONTANTREMISE = 0;
		private double _PY_TAUXCOMMISSION = 0;
		private double _PY_MONTANTCOMMISSION = 0;
		private DateTime _PY_DATEREMISE1 = DateTime.Parse("01/01/1900");
		private DateTime _PY_DATEREMISE2 = DateTime.Parse("01/01/1900");
		private DateTime _PY_DATETARIFICATION = DateTime.Parse("01/01/1900");
        private string _PY_TYPEECRAN = "";
        private string _EN_CODEENTREPOT = "";
        private string _OP_CODEOPERATEUR = "";
        private string _JF_CODETYPEJOURFACTURATION = "";
        private string _LF_CODELIEUFACTURATION = "";
		private double _PY_VALEURCOEFICIENT = 0;
		private double _PY_COUTCOEFICIENT = 0;
        public string AG_CODEAGENCE
        {
            get { return _AG_CODEAGENCE; }
            set { _AG_CODEAGENCE = value; }
        }
        public string AR_CODEARTICLE
		{
			get { return _AR_CODEARTICLE; }
			set { _AR_CODEARTICLE = value; }
		}
		public string NT_CODENATURETIERS
		{
			get { return _NT_CODENATURETIERS; }
			set { _NT_CODENATURETIERS = value; }
		}
		public double PY_PRIXVENTE
		{
			get { return _PY_PRIXVENTE; }
			set { _PY_PRIXVENTE = value; }
		}
        public double PY_PRIXVENTEHT
		{
            get { return _PY_PRIXVENTEHT; }
            set { _PY_PRIXVENTEHT = value; }
		}
		public double PY_TAUXREMISE
		{
			get { return _PY_TAUXREMISE; }
			set { _PY_TAUXREMISE = value; }
		}
		public double PY_MONTANTREMISE
		{
			get { return _PY_MONTANTREMISE; }
			set { _PY_MONTANTREMISE = value; }
		}
		public double PY_TAUXCOMMISSION
		{
			get { return _PY_TAUXCOMMISSION; }
			set { _PY_TAUXCOMMISSION = value; }
		}
		public double PY_MONTANTCOMMISSION
		{
			get { return _PY_MONTANTCOMMISSION; }
			set { _PY_MONTANTCOMMISSION = value; }
		}
		public DateTime PY_DATEREMISE1
		{
			get { return _PY_DATEREMISE1; }
			set { _PY_DATEREMISE1 = value; }
		}
		public DateTime PY_DATEREMISE2
		{
			get { return _PY_DATEREMISE2; }
			set { _PY_DATEREMISE2 = value; }
		}
		public DateTime PY_DATETARIFICATION
		{
			get { return _PY_DATETARIFICATION; }
			set { _PY_DATETARIFICATION = value; }
		}
        public string PY_TYPEECRAN
		{
            get { return _PY_TYPEECRAN; }
            set { _PY_TYPEECRAN = value; }
		}
        public string EN_CODEENTREPOT
		{
            get { return _EN_CODEENTREPOT; }
            set { _EN_CODEENTREPOT = value; }
		}

        public string OP_CODEOPERATEUR
        {
            get { return _OP_CODEOPERATEUR; }
            set { _OP_CODEOPERATEUR = value; }
        }

        public string JF_CODETYPEJOURFACTURATION
        {
            get { return _JF_CODETYPEJOURFACTURATION; }
            set { _JF_CODETYPEJOURFACTURATION = value; }
        }

        public string LF_CODELIEUFACTURATION
        {
            get { return _LF_CODELIEUFACTURATION; }
            set { _LF_CODELIEUFACTURATION = value; }
        }


        public double PY_VALEURCOEFICIENT
        {
            get { return _PY_VALEURCOEFICIENT; }
            set { _PY_VALEURCOEFICIENT = value; }
        }
        public double PY_COUTCOEFICIENT
        {
            get { return _PY_COUTCOEFICIENT; }
            set { _PY_COUTCOEFICIENT = value; }
        }




        public clsPhaparprixtypeclient() {}

      

		public clsPhaparprixtypeclient(clsPhaparprixtypeclient clsPhaparprixtypeclient)
		{

            this.AG_CODEAGENCE = clsPhaparprixtypeclient.AG_CODEAGENCE;
            AR_CODEARTICLE = clsPhaparprixtypeclient.AR_CODEARTICLE;
			NT_CODENATURETIERS = clsPhaparprixtypeclient.NT_CODENATURETIERS;
			PY_PRIXVENTE = clsPhaparprixtypeclient.PY_PRIXVENTE;
            PY_PRIXVENTEHT = clsPhaparprixtypeclient.PY_PRIXVENTEHT;
			PY_TAUXREMISE = clsPhaparprixtypeclient.PY_TAUXREMISE;
			PY_MONTANTREMISE = clsPhaparprixtypeclient.PY_MONTANTREMISE;
			PY_TAUXCOMMISSION = clsPhaparprixtypeclient.PY_TAUXCOMMISSION;
			PY_MONTANTCOMMISSION = clsPhaparprixtypeclient.PY_MONTANTCOMMISSION;
			PY_DATEREMISE1 = clsPhaparprixtypeclient.PY_DATEREMISE1;
			PY_DATEREMISE2 = clsPhaparprixtypeclient.PY_DATEREMISE2;
			PY_DATETARIFICATION = clsPhaparprixtypeclient.PY_DATETARIFICATION;
            PY_TYPEECRAN = clsPhaparprixtypeclient.PY_TYPEECRAN;
            EN_CODEENTREPOT = clsPhaparprixtypeclient.EN_CODEENTREPOT;
            this.OP_CODEOPERATEUR = clsPhaparprixtypeclient.OP_CODEOPERATEUR;
            this.JF_CODETYPEJOURFACTURATION = clsPhaparprixtypeclient.JF_CODETYPEJOURFACTURATION;
            this.LF_CODELIEUFACTURATION = clsPhaparprixtypeclient.LF_CODELIEUFACTURATION;
            this.PY_VALEURCOEFICIENT = clsPhaparprixtypeclient.PY_VALEURCOEFICIENT;
            this.PY_COUTCOEFICIENT = clsPhaparprixtypeclient.PY_COUTCOEFICIENT;
		}
        }
}