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
	public partial class wsCliparmodesortie
	{
        public List<HT_Stock.BOJ.clsCliparmodesortie> TestContrainte(HT_Stock.BOJ.clsCliparmodesortie Objet)

        {
            List<HT_Stock.BOJ.clsCliparmodesortie> clsCliparmodesorties = new List<HT_Stock.BOJ.clsCliparmodesortie>();
            HT_Stock.BOJ.clsCliparmodesortie clsCliparmodesortie = new HT_Stock.BOJ.clsCliparmodesortie();
            clsCliparmodesortie.clsObjetRetour = new Common.clsObjetRetour();
            clsCliparmodesortie.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCliparmodesortie.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCliparmodesortie.clsObjetRetour.SL_MESSAGE = "";
            clsCliparmodesorties.Add(clsCliparmodesortie);
            return clsCliparmodesorties;
        }



        public List<HT_Stock.BOJ.clsCliparmodesortie> TestTestContrainteListe(HT_Stock.BOJ.clsCliparmodesortie Objet)
        {
            List<HT_Stock.BOJ.clsCliparmodesortie> clsCliparmodesorties = new List<HT_Stock.BOJ.clsCliparmodesortie>();
            HT_Stock.BOJ.clsCliparmodesortie clsCliparmodesortie = new HT_Stock.BOJ.clsCliparmodesortie();
            clsCliparmodesortie.clsObjetRetour = new Common.clsObjetRetour();
            clsCliparmodesortie.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCliparmodesortie.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCliparmodesortie.clsObjetRetour.SL_MESSAGE = "";
            clsCliparmodesorties.Add(clsCliparmodesortie);
            return clsCliparmodesorties;
        }
    }
}
