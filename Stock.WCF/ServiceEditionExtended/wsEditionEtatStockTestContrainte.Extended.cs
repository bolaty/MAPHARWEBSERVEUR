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
	public partial class wsEditionEtatStock
	{
        public List<HT_Stock.BOJ.clsEditionEtatStock> TestContrainte(HT_Stock.BOJ.clsEditionEtatStock Objet)

        {
            List<HT_Stock.BOJ.clsEditionEtatStock> clsEditionEtatStocks = new List<HT_Stock.BOJ.clsEditionEtatStock>();
            HT_Stock.BOJ.clsEditionEtatStock clsEditionEtatStock = new HT_Stock.BOJ.clsEditionEtatStock();
            clsEditionEtatStock.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatStock.clsObjetRetour.SL_CODEMESSAGE = "";
            clsEditionEtatStock.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsEditionEtatStock.clsObjetRetour.SL_MESSAGE = "";
            clsEditionEtatStocks.Add(clsEditionEtatStock);
            return clsEditionEtatStocks;
        }



        public List<HT_Stock.BOJ.clsEditionEtatStock> TestTestContrainteListe(HT_Stock.BOJ.clsEditionEtatStock Objet)
        {
            List<HT_Stock.BOJ.clsEditionEtatStock> clsEditionEtatStocks = new List<HT_Stock.BOJ.clsEditionEtatStock>();
            HT_Stock.BOJ.clsEditionEtatStock clsEditionEtatStock = new HT_Stock.BOJ.clsEditionEtatStock();
            clsEditionEtatStock.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatStock.clsObjetRetour.SL_CODEMESSAGE = "";
            clsEditionEtatStock.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsEditionEtatStock.clsObjetRetour.SL_MESSAGE = "";
            clsEditionEtatStocks.Add(clsEditionEtatStock);
            return clsEditionEtatStocks;
        }
    }
}
