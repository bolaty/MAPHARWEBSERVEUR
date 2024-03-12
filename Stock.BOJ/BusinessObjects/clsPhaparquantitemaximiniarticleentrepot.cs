using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsPhaparquantitemaximiniarticleentrepot
	{
		#region VARIABLES LOCALES
        private string _AG_CODEAGENCE = "";
		private string _EN_CODEENTREPOT = "";
		private string _AR_CODEARTICLE = "";
		private double _EN_STOCKMINI = 0;
		private double _EN_STOCKMAXI = 0;
        private string _OP_CODEOPERATEUR = "";

		#endregion

		#region ACCESSEURS

        public string AG_CODEAGENCE
        {
            get { return _AG_CODEAGENCE; }
            set { _AG_CODEAGENCE = value; }
        }

		public string EN_CODEENTREPOT
		{
			get { return _EN_CODEENTREPOT; }
			set {  _EN_CODEENTREPOT = value; }
		}

		public string AR_CODEARTICLE
		{
			get { return _AR_CODEARTICLE; }
			set {  _AR_CODEARTICLE = value; }
		}

		public double EN_STOCKMINI
		{
			get { return _EN_STOCKMINI; }
			set {  _EN_STOCKMINI = value; }
		}

		public double EN_STOCKMAXI
		{
			get { return _EN_STOCKMAXI; }
			set {  _EN_STOCKMAXI = value; }
		}

        public string OP_CODEOPERATEUR
        {
            get { return _OP_CODEOPERATEUR; }
            set { _OP_CODEOPERATEUR = value; }
        }
		#endregion

		#region INSTANCIATEURS

		public clsPhaparquantitemaximiniarticleentrepot(){}
		
		public clsPhaparquantitemaximiniarticleentrepot(clsPhaparquantitemaximiniarticleentrepot clsPhaparquantitemaximiniarticleentrepot)
		{
            this.AG_CODEAGENCE = clsPhaparquantitemaximiniarticleentrepot.AG_CODEAGENCE;
			this.EN_CODEENTREPOT = clsPhaparquantitemaximiniarticleentrepot.EN_CODEENTREPOT;
			this.AR_CODEARTICLE = clsPhaparquantitemaximiniarticleentrepot.AR_CODEARTICLE;
			this.EN_STOCKMINI = clsPhaparquantitemaximiniarticleentrepot.EN_STOCKMINI;
			this.EN_STOCKMAXI = clsPhaparquantitemaximiniarticleentrepot.EN_STOCKMAXI;
            this.OP_CODEOPERATEUR = clsPhaparquantitemaximiniarticleentrepot.OP_CODEOPERATEUR;
		}

		#endregion

	}
}
