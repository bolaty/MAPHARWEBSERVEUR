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
	public partial class wsCtparprimerisqueassuranceliaison
	{
        public List<HT_Stock.BOJ.clsCtparprimerisqueassuranceliaison> TestContrainte(HT_Stock.BOJ.clsCtparprimerisqueassuranceliaison Objet)

        {
            List<HT_Stock.BOJ.clsCtparprimerisqueassuranceliaison> clsCtparprimerisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparprimerisqueassuranceliaison>();
            HT_Stock.BOJ.clsCtparprimerisqueassuranceliaison clsCtparprimerisqueassuranceliaison = new HT_Stock.BOJ.clsCtparprimerisqueassuranceliaison();
            clsCtparprimerisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparprimerisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparprimerisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparprimerisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = "";
            clsCtparprimerisqueassuranceliaisons.Add(clsCtparprimerisqueassuranceliaison);
            return clsCtparprimerisqueassuranceliaisons;
        }



        public List<HT_Stock.BOJ.clsCtparprimerisqueassuranceliaison> TestTestContrainteListe(HT_Stock.BOJ.clsCtparprimerisqueassuranceliaison Objet)
        {
            List<HT_Stock.BOJ.clsCtparprimerisqueassuranceliaison> clsCtparprimerisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparprimerisqueassuranceliaison>();
            HT_Stock.BOJ.clsCtparprimerisqueassuranceliaison clsCtparprimerisqueassuranceliaison = new HT_Stock.BOJ.clsCtparprimerisqueassuranceliaison();
            clsCtparprimerisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparprimerisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparprimerisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparprimerisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = "";
            clsCtparprimerisqueassuranceliaisons.Add(clsCtparprimerisqueassuranceliaison);
            return clsCtparprimerisqueassuranceliaisons;
        }
    }
}
