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
	public partial class wsActivite
	{
        public List<HT_Stock.BOJ.clsActivite> TestContrainte(HT_Stock.BOJ.clsActivite Objet)

        {
            List<HT_Stock.BOJ.clsActivite> clsActivites = new List<HT_Stock.BOJ.clsActivite>();
            HT_Stock.BOJ.clsActivite clsActivite = new HT_Stock.BOJ.clsActivite();
            clsActivite.clsObjetRetour = new Common.clsObjetRetour();
            clsActivite.clsObjetRetour.SL_CODEMESSAGE = "";
            clsActivite.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsActivite.clsObjetRetour.SL_MESSAGE = "";
            clsActivites.Add(clsActivite);
            return clsActivites;
        }



        public List<HT_Stock.BOJ.clsActivite> TestTestContrainteListe(HT_Stock.BOJ.clsActivite Objet)
        {
            List<HT_Stock.BOJ.clsActivite> clsActivites = new List<HT_Stock.BOJ.clsActivite>();
            HT_Stock.BOJ.clsActivite clsActivite = new HT_Stock.BOJ.clsActivite();
            clsActivite.clsObjetRetour = new Common.clsObjetRetour();
            clsActivite.clsObjetRetour.SL_CODEMESSAGE = "";
            clsActivite.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsActivite.clsObjetRetour.SL_MESSAGE = "";
            clsActivites.Add(clsActivite);
            return clsActivites;
        }
    }
}
