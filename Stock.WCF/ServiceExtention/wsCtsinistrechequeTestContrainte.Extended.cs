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
	public partial class wsCtsinistrecheque
	{
        public List<HT_Stock.BOJ.clsCtsinistrecheque> TestContrainte(HT_Stock.BOJ.clsCtsinistrecheque Objet)

        {
            List<HT_Stock.BOJ.clsCtsinistrecheque> clsCtsinistrecheques = new List<HT_Stock.BOJ.clsCtsinistrecheque>();
            HT_Stock.BOJ.clsCtsinistrecheque clsCtsinistrecheque = new HT_Stock.BOJ.clsCtsinistrecheque();
            clsCtsinistrecheque.clsObjetRetour = new Common.clsObjetRetour();
            clsCtsinistrecheque.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtsinistrecheque.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtsinistrecheque.clsObjetRetour.SL_MESSAGE = "";
            clsCtsinistrecheques.Add(clsCtsinistrecheque);
            return clsCtsinistrecheques;
        }



        public List<HT_Stock.BOJ.clsCtsinistrecheque> TestTestContrainteListe(HT_Stock.BOJ.clsCtsinistrecheque Objet)
        {
            List<HT_Stock.BOJ.clsCtsinistrecheque> clsCtsinistrecheques = new List<HT_Stock.BOJ.clsCtsinistrecheque>();
            HT_Stock.BOJ.clsCtsinistrecheque clsCtsinistrecheque = new HT_Stock.BOJ.clsCtsinistrecheque();
            clsCtsinistrecheque.clsObjetRetour = new Common.clsObjetRetour();
            clsCtsinistrecheque.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtsinistrecheque.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtsinistrecheque.clsObjetRetour.SL_MESSAGE = "";
            clsCtsinistrecheques.Add(clsCtsinistrecheque);
            return clsCtsinistrecheques;
        }
    }
}
