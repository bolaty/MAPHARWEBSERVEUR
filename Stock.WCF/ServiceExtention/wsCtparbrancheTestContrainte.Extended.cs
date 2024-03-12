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
	public partial class wsCtparbranche
	{
        public List<HT_Stock.BOJ.clsCtparbranche> TestContrainte(HT_Stock.BOJ.clsCtparbranche Objet)

        {
            List<HT_Stock.BOJ.clsCtparbranche> clsCtparbranches = new List<HT_Stock.BOJ.clsCtparbranche>();
            HT_Stock.BOJ.clsCtparbranche clsCtparbranche = new HT_Stock.BOJ.clsCtparbranche();
            clsCtparbranche.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparbranche.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparbranche.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparbranche.clsObjetRetour.SL_MESSAGE = "";
            clsCtparbranches.Add(clsCtparbranche);
            return clsCtparbranches;
        }



        public List<HT_Stock.BOJ.clsCtparbranche> TestTestContrainteListe(HT_Stock.BOJ.clsCtparbranche Objet)
        {
            List<HT_Stock.BOJ.clsCtparbranche> clsCtparbranches = new List<HT_Stock.BOJ.clsCtparbranche>();
            HT_Stock.BOJ.clsCtparbranche clsCtparbranche = new HT_Stock.BOJ.clsCtparbranche();
            clsCtparbranche.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparbranche.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparbranche.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparbranche.clsObjetRetour.SL_MESSAGE = "";
            clsCtparbranches.Add(clsCtparbranche);
            return clsCtparbranches;
        }
    }
}
