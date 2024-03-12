using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Stock.BOJ
{
	public class clsPhaparparametre
	{

        private string _PA_CODEPARAMETRE = "";
		private string _PA_LIBELLE = "";
        //private double _PA_MONTANTMINI = 0;
        //private double _PA_MONTANTMAXI = 0;
        //private float _PA_TAUX = 0;
        //private double _PA_MONTANT = 0;



        public string PA_CODEPARAMETRE
		{
			get { return _PA_CODEPARAMETRE; }
			set { _PA_CODEPARAMETRE = value; }
		}
		public string PA_LIBELLE
		{
			get { return _PA_LIBELLE; }
			set { _PA_LIBELLE = value; }
		}
        //public double PA_MONTANTMINI
        //{
        //    get { return _PA_MONTANTMINI; }
        //    set { _PA_MONTANTMINI = value; }
        //}
        //public double PA_MONTANTMAXI
        //{
        //    get { return _PA_MONTANTMAXI; }
        //    set { _PA_MONTANTMAXI = value; }
        //}
        //public float PA_TAUX
        //{
        //    get { return _PA_TAUX; }
        //    set { _PA_TAUX = value; }
        //}
        //public double PA_MONTANT
        //{
        //    get { return _PA_MONTANT; }
        //    set { _PA_MONTANT = value; }
        //}



        public clsPhaparparametre() {}

        public clsPhaparparametre(string PA_CODEPARAMETRE, string PA_LIBELLE, double PA_MONTANTMINI, double PA_MONTANTMAXI, float PA_TAUX, double PA_MONTANT)
		{
			this.PA_CODEPARAMETRE = PA_CODEPARAMETRE;
			this.PA_LIBELLE = PA_LIBELLE;
            //this.PA_MONTANTMINI = PA_MONTANTMINI;
            //this.PA_MONTANTMAXI = PA_MONTANTMAXI;
            //this.PA_TAUX = PA_TAUX;
            //this.PA_MONTANT = PA_MONTANT;
		}

		public clsPhaparparametre(clsPhaparparametre clsPhaparparametre)
		{
			PA_CODEPARAMETRE = clsPhaparparametre.PA_CODEPARAMETRE;
			PA_LIBELLE = clsPhaparparametre.PA_LIBELLE;
            //PA_MONTANTMINI = clsPhaparparametre.PA_MONTANTMINI;
            //PA_MONTANTMAXI = clsPhaparparametre.PA_MONTANTMAXI;
            //PA_TAUX = clsPhaparparametre.PA_TAUX;
            //PA_MONTANT = clsPhaparparametre.PA_MONTANT;
		}

        }
}