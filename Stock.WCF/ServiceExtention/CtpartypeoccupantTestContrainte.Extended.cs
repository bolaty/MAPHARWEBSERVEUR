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
	public partial class wsCtpartypeoccupant
	{
        public List<HT_Stock.BOJ.clsCtpartypeoccupant> TestContrainte(HT_Stock.BOJ.clsCtpartypeoccupant Objet)

        {
            List<HT_Stock.BOJ.clsCtpartypeoccupant> clsCtpartypeoccupants = new List<HT_Stock.BOJ.clsCtpartypeoccupant>();
            HT_Stock.BOJ.clsCtpartypeoccupant clsCtpartypeoccupant = new HT_Stock.BOJ.clsCtpartypeoccupant();
            clsCtpartypeoccupant.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpartypeoccupant.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtpartypeoccupant.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtpartypeoccupant.clsObjetRetour.SL_MESSAGE = "";
            clsCtpartypeoccupants.Add(clsCtpartypeoccupant);
            return clsCtpartypeoccupants;
        }



        public List<HT_Stock.BOJ.clsCtpartypeoccupant> TestTestContrainteListe(HT_Stock.BOJ.clsCtpartypeoccupant Objet)
        {
            List<HT_Stock.BOJ.clsCtpartypeoccupant> clsCtpartypeoccupants = new List<HT_Stock.BOJ.clsCtpartypeoccupant>();
            HT_Stock.BOJ.clsCtpartypeoccupant clsCtpartypeoccupant = new HT_Stock.BOJ.clsCtpartypeoccupant();
            clsCtpartypeoccupant.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpartypeoccupant.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtpartypeoccupant.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtpartypeoccupant.clsObjetRetour.SL_MESSAGE = "";
            clsCtpartypeoccupants.Add(clsCtpartypeoccupant);
            return clsCtpartypeoccupants;
        }
    }
}
