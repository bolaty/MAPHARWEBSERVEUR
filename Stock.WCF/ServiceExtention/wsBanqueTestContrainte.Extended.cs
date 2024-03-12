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
	public partial class wsBanque
	{
        public List<HT_Stock.BOJ.clsBanque> TestContrainte(HT_Stock.BOJ.clsBanque Objet)

        {
            List<HT_Stock.BOJ.clsBanque> clsBanques = new List<HT_Stock.BOJ.clsBanque>();
            HT_Stock.BOJ.clsBanque clsBanque = new HT_Stock.BOJ.clsBanque();
            clsBanque.clsObjetRetour = new Common.clsObjetRetour();
            clsBanque.clsObjetRetour.SL_CODEMESSAGE = "";
            clsBanque.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsBanque.clsObjetRetour.SL_MESSAGE = "";
            clsBanques.Add(clsBanque);
            return clsBanques;
        }



        public List<HT_Stock.BOJ.clsBanque> TestTestContrainteListe(HT_Stock.BOJ.clsBanque Objet)
        {
            List<HT_Stock.BOJ.clsBanque> clsBanques = new List<HT_Stock.BOJ.clsBanque>();
            HT_Stock.BOJ.clsBanque clsBanque = new HT_Stock.BOJ.clsBanque();
            clsBanque.clsObjetRetour = new Common.clsObjetRetour();
            clsBanque.clsObjetRetour.SL_CODEMESSAGE = "";
            clsBanque.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsBanque.clsObjetRetour.SL_MESSAGE = "";
            clsBanques.Add(clsBanque);
            return clsBanques;
        }
    }
}
