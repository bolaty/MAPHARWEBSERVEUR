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
	public partial class wsEdition
	{
        public List<HT_Stock.BOJ.clsEdition> TestContrainte(HT_Stock.BOJ.clsEdition Objet)

        {
            List<HT_Stock.BOJ.clsEdition> clsEditions = new List<HT_Stock.BOJ.clsEdition>();
            HT_Stock.BOJ.clsEdition clsEdition = new HT_Stock.BOJ.clsEdition();
            clsEdition.clsObjetRetour = new Common.clsObjetRetour();
            clsEdition.clsObjetRetour.SL_CODEMESSAGE = "";
            clsEdition.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsEdition.clsObjetRetour.SL_MESSAGE = "";
            clsEditions.Add(clsEdition);
            return clsEditions;
        }



        public List<HT_Stock.BOJ.clsEdition> TestTestContrainteListe(HT_Stock.BOJ.clsEdition Objet)
        {
            List<HT_Stock.BOJ.clsEdition> clsEditions = new List<HT_Stock.BOJ.clsEdition>();
            HT_Stock.BOJ.clsEdition clsEdition = new HT_Stock.BOJ.clsEdition();
            clsEdition.clsObjetRetour = new Common.clsObjetRetour();
            clsEdition.clsObjetRetour.SL_CODEMESSAGE = "";
            clsEdition.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsEdition.clsObjetRetour.SL_MESSAGE = "";
            clsEditions.Add(clsEdition);
            return clsEditions;
        }
    }
}
