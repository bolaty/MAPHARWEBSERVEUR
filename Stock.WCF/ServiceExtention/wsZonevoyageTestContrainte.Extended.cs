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
	public partial class wsZonevoyage
	{
        public List<HT_Stock.BOJ.clsZonevoyage> TestContrainte(HT_Stock.BOJ.clsZonevoyage Objet)

        {
            List<HT_Stock.BOJ.clsZonevoyage> clsZonevoyages = new List<HT_Stock.BOJ.clsZonevoyage>();
            HT_Stock.BOJ.clsZonevoyage clsZonevoyage = new HT_Stock.BOJ.clsZonevoyage();
            clsZonevoyage.clsObjetRetour = new Common.clsObjetRetour();
            clsZonevoyage.clsObjetRetour.SL_CODEMESSAGE = "";
            clsZonevoyage.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsZonevoyage.clsObjetRetour.SL_MESSAGE = "";
            clsZonevoyages.Add(clsZonevoyage);
            return clsZonevoyages;
        }



        public List<HT_Stock.BOJ.clsZonevoyage> TestTestContrainteListe(HT_Stock.BOJ.clsZonevoyage Objet)
        {
            List<HT_Stock.BOJ.clsZonevoyage> clsZonevoyages = new List<HT_Stock.BOJ.clsZonevoyage>();
            HT_Stock.BOJ.clsZonevoyage clsZonevoyage = new HT_Stock.BOJ.clsZonevoyage();
            clsZonevoyage.clsObjetRetour = new Common.clsObjetRetour();
            clsZonevoyage.clsObjetRetour.SL_CODEMESSAGE = "";
            clsZonevoyage.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsZonevoyage.clsObjetRetour.SL_MESSAGE = "";
            clsZonevoyages.Add(clsZonevoyage);
            return clsZonevoyages;
        }
    }
}
