using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Stock.BOJ;
using Stock.WSBLL;
using Stock.WSTOOLS;
using Stock.Common;
namespace Stock.WCF
{
	public partial class wsCtpartypeoccupant
	{
        public List<HT_Stock.BOJ.clsCtpartypeoccupant> TestTypeDonnee(HT_Stock.BOJ.clsCtpartypeoccupant Objet)

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