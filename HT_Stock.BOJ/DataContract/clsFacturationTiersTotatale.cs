using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Stock.BOJ
{
	public class clsFacturationTiersTotatale
	{

        private double _MONTANTFACTURE = 0;

        public double MONTANTFACTURE
        {
            get { return _MONTANTFACTURE; }
            set { _MONTANTFACTURE = value; }
        }

        public clsFacturationTiersTotatale() {}

       
		public clsFacturationTiersTotatale(clsFacturationTiersTotatale clsFacturationTiersTotatale)
		{
            MONTANTFACTURE = clsFacturationTiersTotatale.MONTANTFACTURE;
		}
        }
}