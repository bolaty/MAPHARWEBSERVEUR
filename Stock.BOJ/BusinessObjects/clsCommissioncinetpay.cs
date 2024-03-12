using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.BOJ
{
    public class clsCommissioncinetpay
    {

        private double _SL_MONTANT = 0;
        private double _SL_TAUX =0;
        private double _SL_COMMISSION = 0;
        private string _SL_CODEMESSAGE = "";
        private string _SL_MESSAGE = "";
        private string _SL_RESULTAT = "";


        public double SL_MONTANT
        {
            get { return _SL_MONTANT; }
            set { _SL_MONTANT= value; }
        }
        public double SL_TAUX
        {
            get { return _SL_TAUX; }
            set { _SL_TAUX= value; }
        }
        public double SL_COMMISSION
        {
            get { return _SL_COMMISSION; }
            set { _SL_COMMISSION = value; }
        }

        public string SL_CODEMESSAGE
        {
            get { return _SL_CODEMESSAGE; }
            set { _SL_CODEMESSAGE = value; }
        }


        public string SL_MESSAGE
        {
            get { return _SL_MESSAGE; }
            set { _SL_MESSAGE = value; }
        }


        public string SL_RESULTAT
        {
            get { return _SL_RESULTAT; }
            set { _SL_RESULTAT = value; }
        }

        public clsCommissioncinetpay() { }

        public clsCommissioncinetpay(clsCommissioncinetpay clsCommissioncinetpay)
        {
            this.SL_MONTANT = clsCommissioncinetpay.SL_MONTANT;
            this.SL_TAUX = clsCommissioncinetpay.SL_TAUX;
            this.SL_COMMISSION = clsCommissioncinetpay.SL_COMMISSION;
            this.SL_CODEMESSAGE = clsCommissioncinetpay.SL_CODEMESSAGE;
            this.SL_MESSAGE = clsCommissioncinetpay.SL_MESSAGE;
            this.SL_RESULTAT = clsCommissioncinetpay.SL_RESULTAT;



        }
    }
}