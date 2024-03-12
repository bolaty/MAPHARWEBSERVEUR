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
	public partial class wsCtparintermediaire
	{
        public List<HT_Stock.BOJ.clsCtparintermediaire> TestContrainte(HT_Stock.BOJ.clsCtparintermediaire Objet)

        {
            List<HT_Stock.BOJ.clsCtparintermediaire> clsCtparintermediaires = new List<HT_Stock.BOJ.clsCtparintermediaire>();
            HT_Stock.BOJ.clsCtparintermediaire clsCtparintermediaire = new HT_Stock.BOJ.clsCtparintermediaire();
            clsCtparintermediaire.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparintermediaire.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparintermediaire.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparintermediaire.clsObjetRetour.SL_MESSAGE = "";
            clsCtparintermediaires.Add(clsCtparintermediaire);
            return clsCtparintermediaires;
        }



        public List<HT_Stock.BOJ.clsCtparintermediaire> TestTestContrainteListe(HT_Stock.BOJ.clsCtparintermediaire Objet)
        {
            List<HT_Stock.BOJ.clsCtparintermediaire> clsCtparintermediaires = new List<HT_Stock.BOJ.clsCtparintermediaire>();
            HT_Stock.BOJ.clsCtparintermediaire clsCtparintermediaire = new HT_Stock.BOJ.clsCtparintermediaire();
            clsCtparintermediaire.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparintermediaire.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparintermediaire.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparintermediaire.clsObjetRetour.SL_MESSAGE = "";
            clsCtparintermediaires.Add(clsCtparintermediaire);
            return clsCtparintermediaires;
        }
    }
}
