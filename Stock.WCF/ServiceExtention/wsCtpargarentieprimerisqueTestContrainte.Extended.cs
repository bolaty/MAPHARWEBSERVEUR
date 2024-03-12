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
	public partial class wsCtpargarentieprimerisque
	{
        public List<HT_Stock.BOJ.clsCtpargarentieprimerisque> TestContrainte(HT_Stock.BOJ.clsCtpargarentieprimerisque Objet)

        {
            List<HT_Stock.BOJ.clsCtpargarentieprimerisque> clsCtpargarentieprimerisques = new List<HT_Stock.BOJ.clsCtpargarentieprimerisque>();
            HT_Stock.BOJ.clsCtpargarentieprimerisque clsCtpargarentieprimerisque = new HT_Stock.BOJ.clsCtpargarentieprimerisque();
            clsCtpargarentieprimerisque.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpargarentieprimerisque.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtpargarentieprimerisque.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtpargarentieprimerisque.clsObjetRetour.SL_MESSAGE = "";
            clsCtpargarentieprimerisques.Add(clsCtpargarentieprimerisque);
            return clsCtpargarentieprimerisques;
        }



        public List<HT_Stock.BOJ.clsCtpargarentieprimerisque> TestTestContrainteListe(HT_Stock.BOJ.clsCtpargarentieprimerisque Objet)
        {
            List<HT_Stock.BOJ.clsCtpargarentieprimerisque> clsCtpargarentieprimerisques = new List<HT_Stock.BOJ.clsCtpargarentieprimerisque>();
            HT_Stock.BOJ.clsCtpargarentieprimerisque clsCtpargarentieprimerisque = new HT_Stock.BOJ.clsCtpargarentieprimerisque();
            clsCtpargarentieprimerisque.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpargarentieprimerisque.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtpargarentieprimerisque.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtpargarentieprimerisque.clsObjetRetour.SL_MESSAGE = "";
            clsCtpargarentieprimerisques.Add(clsCtpargarentieprimerisque);
            return clsCtpargarentieprimerisques;
        }
    }
}
