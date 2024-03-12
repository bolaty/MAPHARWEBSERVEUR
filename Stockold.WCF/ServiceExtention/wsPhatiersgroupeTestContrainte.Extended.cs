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
	public partial class wsPhatiersgroupe
	{
        public List<HT_Stock.BOJ.clsPhatiersgroupe> TestContrainte(HT_Stock.BOJ.clsPhatiersgroupe Objet)

        {
            List<HT_Stock.BOJ.clsPhatiersgroupe> clsPhatiersgroupes = new List<HT_Stock.BOJ.clsPhatiersgroupe>();
            HT_Stock.BOJ.clsPhatiersgroupe clsPhatiersgroupe = new HT_Stock.BOJ.clsPhatiersgroupe();
            clsPhatiersgroupe.clsObjetRetour = new Common.clsObjetRetour();
            clsPhatiersgroupe.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhatiersgroupe.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhatiersgroupe.clsObjetRetour.SL_MESSAGE = "";
            clsPhatiersgroupes.Add(clsPhatiersgroupe);
            return clsPhatiersgroupes;
        }



        public List<HT_Stock.BOJ.clsPhatiersgroupe> TestTestContrainteListe(HT_Stock.BOJ.clsPhatiersgroupe Objet)
        {
            List<HT_Stock.BOJ.clsPhatiersgroupe> clsPhatiersgroupes = new List<HT_Stock.BOJ.clsPhatiersgroupe>();
            HT_Stock.BOJ.clsPhatiersgroupe clsPhatiersgroupe = new HT_Stock.BOJ.clsPhatiersgroupe();
            clsPhatiersgroupe.clsObjetRetour = new Common.clsObjetRetour();
            clsPhatiersgroupe.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhatiersgroupe.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhatiersgroupe.clsObjetRetour.SL_MESSAGE = "";
            clsPhatiersgroupes.Add(clsPhatiersgroupe);
            return clsPhatiersgroupes;
        }
    }
}
