using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stock.Common;
using System.Runtime.Serialization;
using Stock.BOJ;
using Stock.WSBLL;
using Stock.WSTOOLS;

namespace Stock.WCF
{
	public partial class wsPhamouvementStock
	{
        public List<HT_Stock.BOJ.clsPhamouvementStock> TestContrainte(HT_Stock.BOJ.clsPhamouvementStock Objet)

        {
            List<HT_Stock.BOJ.clsPhamouvementStock> clsPhamouvementStocks = new List<HT_Stock.BOJ.clsPhamouvementStock>();
            HT_Stock.BOJ.clsPhamouvementStock clsPhamouvementStock = new HT_Stock.BOJ.clsPhamouvementStock();
            clsPhamouvementStock.clsObjetRetour = new Common.clsObjetRetour();
            clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhamouvementStock.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = "";
            clsPhamouvementStocks.Add(clsPhamouvementStock);
            return clsPhamouvementStocks;
        }



        public List<HT_Stock.BOJ.clsPhamouvementStock> TestTestContrainteListe(HT_Stock.BOJ.clsPhamouvementStock Objet)
        {
            List<HT_Stock.BOJ.clsPhamouvementStock> clsPhamouvementStocks = new List<HT_Stock.BOJ.clsPhamouvementStock>();
            HT_Stock.BOJ.clsPhamouvementStock clsPhamouvementStock = new HT_Stock.BOJ.clsPhamouvementStock();
            clsPhamouvementStock.clsObjetRetour = new Common.clsObjetRetour();
            clsPhamouvementStock.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhamouvementStock.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhamouvementStock.clsObjetRetour.SL_MESSAGE = "";
            clsPhamouvementStocks.Add(clsPhamouvementStock);
            return clsPhamouvementStocks;
        }
    }
}
