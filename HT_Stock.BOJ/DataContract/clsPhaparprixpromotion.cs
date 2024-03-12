using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsPhaparprixpromotion
	{
		#region VARIABLES LOCALES
        private string _AG_CODEAGENCE = "";
		private string _AR_CODEARTICLE = "";
		private string _NT_CODENATURETIERS = "";
		private DateTime _PY_DATEREMISE1 = DateTime.Parse("01/01/1900");
		private DateTime _PY_DATEREMISE2 = DateTime.Parse("01/01/1900");
        private DateTime _PY_DATECLOTURE = DateTime.Parse("01/01/1900");
		private float _PY_TAUXREMISE = 0;
		private double _PY_MONTANTREMISE = 0;
        private int _TYPEOPERATION = 0;
        private string _CONFIRMATION = "N";
        private string _OP_CODEOPERATEUR = "";

		#endregion

		#region ACCESSEURS
        public string AG_CODEAGENCE
        {
            get { return _AG_CODEAGENCE; }
            set { _AG_CODEAGENCE = value; }
        }
		public string AR_CODEARTICLE
		{
			get { return _AR_CODEARTICLE; }
			set {  _AR_CODEARTICLE = value; }
		}

		public string NT_CODENATURETIERS
		{
			get { return _NT_CODENATURETIERS; }
			set {  _NT_CODENATURETIERS = value; }
		}

		public DateTime PY_DATEREMISE1
		{
			get { return _PY_DATEREMISE1; }
			set {  _PY_DATEREMISE1 = value; }
		}

		public DateTime PY_DATEREMISE2
		{
			get { return _PY_DATEREMISE2; }
			set {  _PY_DATEREMISE2 = value; }
		}

        public DateTime PY_DATECLOTURE
        {
            get { return _PY_DATECLOTURE; }
            set { _PY_DATECLOTURE = value; }
        }

		public float PY_TAUXREMISE
		{
			get { return _PY_TAUXREMISE; }
			set {  _PY_TAUXREMISE = value; }
		}

		public double PY_MONTANTREMISE
		{
			get { return _PY_MONTANTREMISE; }
			set {  _PY_MONTANTREMISE = value; }
		}
        public int TYPEOPERATION
        {
            get { return _TYPEOPERATION; }
            set { _TYPEOPERATION = value; }
        }
        public string CONFIRMATION
        {
            get { return _CONFIRMATION; }
            set { _CONFIRMATION = value; }
        }

        public string OP_CODEOPERATEUR
        {
            get { return _OP_CODEOPERATEUR; }
            set { _OP_CODEOPERATEUR = value; }
        }
		#endregion

		#region INSTANCIATEURS

		public clsPhaparprixpromotion(){}
		
		public clsPhaparprixpromotion(clsPhaparprixpromotion clsPhaparprixpromotion)
		{
            this.AG_CODEAGENCE = clsPhaparprixpromotion.AG_CODEAGENCE;
            this.AR_CODEARTICLE = clsPhaparprixpromotion.AR_CODEARTICLE;
			this.NT_CODENATURETIERS = clsPhaparprixpromotion.NT_CODENATURETIERS;
			this.PY_DATEREMISE1 = clsPhaparprixpromotion.PY_DATEREMISE1;
			this.PY_DATEREMISE2 = clsPhaparprixpromotion.PY_DATEREMISE2;
            this.PY_DATECLOTURE = clsPhaparprixpromotion.PY_DATECLOTURE;
			this.PY_TAUXREMISE = clsPhaparprixpromotion.PY_TAUXREMISE;
			this.PY_MONTANTREMISE = clsPhaparprixpromotion.PY_MONTANTREMISE;
            this.TYPEOPERATION = clsPhaparprixpromotion.TYPEOPERATION;
            this.CONFIRMATION = clsPhaparprixpromotion.CONFIRMATION;
            this.OP_CODEOPERATEUR = clsPhaparprixpromotion.OP_CODEOPERATEUR;

		}

		#endregion

	}
}
