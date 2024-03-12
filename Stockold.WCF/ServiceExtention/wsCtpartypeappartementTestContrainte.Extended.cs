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
	public partial class wsCtpartypeappartement
	{
        public List<HT_Stock.BOJ.clsCtpartypeappartement> TestContrainte(HT_Stock.BOJ.clsCtpartypeappartement Objet)

        {
            List<HT_Stock.BOJ.clsCtpartypeappartement> clsCtpartypeappartements = new List<HT_Stock.BOJ.clsCtpartypeappartement>();
            HT_Stock.BOJ.clsCtpartypeappartement clsCtpartypeappartement = new HT_Stock.BOJ.clsCtpartypeappartement();
            clsCtpartypeappartement.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpartypeappartement.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtpartypeappartement.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtpartypeappartement.clsObjetRetour.SL_MESSAGE = "";
            clsCtpartypeappartements.Add(clsCtpartypeappartement);
            return clsCtpartypeappartements;
        }



        public List<HT_Stock.BOJ.clsCtpartypeappartement> TestTestContrainteListe(HT_Stock.BOJ.clsCtpartypeappartement Objet)
        {
            List<HT_Stock.BOJ.clsCtpartypeappartement> clsCtpartypeappartements = new List<HT_Stock.BOJ.clsCtpartypeappartement>();
            HT_Stock.BOJ.clsCtpartypeappartement clsCtpartypeappartement = new HT_Stock.BOJ.clsCtpartypeappartement();
            clsCtpartypeappartement.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpartypeappartement.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtpartypeappartement.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtpartypeappartement.clsObjetRetour.SL_MESSAGE = "";
            clsCtpartypeappartements.Add(clsCtpartypeappartement);
            return clsCtpartypeappartements;
        }
    }
}
