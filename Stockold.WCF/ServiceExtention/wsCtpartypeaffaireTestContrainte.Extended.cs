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
	public partial class wsCtpartypeaffaire
	{
        public List<HT_Stock.BOJ.clsCtpartypeaffaire> TestContrainte(HT_Stock.BOJ.clsCtpartypeaffaire Objet)

        {
            List<HT_Stock.BOJ.clsCtpartypeaffaire> clsCtpartypeaffaires = new List<HT_Stock.BOJ.clsCtpartypeaffaire>();
            HT_Stock.BOJ.clsCtpartypeaffaire clsCtpartypeaffaire = new HT_Stock.BOJ.clsCtpartypeaffaire();
            clsCtpartypeaffaire.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpartypeaffaire.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtpartypeaffaire.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtpartypeaffaire.clsObjetRetour.SL_MESSAGE = "";
            clsCtpartypeaffaires.Add(clsCtpartypeaffaire);
            return clsCtpartypeaffaires;
        }



        public List<HT_Stock.BOJ.clsCtpartypeaffaire> TestTestContrainteListe(HT_Stock.BOJ.clsCtpartypeaffaire Objet)
        {
            List<HT_Stock.BOJ.clsCtpartypeaffaire> clsCtpartypeaffaires = new List<HT_Stock.BOJ.clsCtpartypeaffaire>();
            HT_Stock.BOJ.clsCtpartypeaffaire clsCtpartypeaffaire = new HT_Stock.BOJ.clsCtpartypeaffaire();
            clsCtpartypeaffaire.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpartypeaffaire.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtpartypeaffaire.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtpartypeaffaire.clsObjetRetour.SL_MESSAGE = "";
            clsCtpartypeaffaires.Add(clsCtpartypeaffaire);
            return clsCtpartypeaffaires;
        }
    }
}
