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
	public partial class wsStatutContrat
    {
        public List<HT_Stock.BOJ.clsCtparstatutcontrat> TestTypeDonnee(HT_Stock.BOJ.clsCtparstatutcontrat Objet)

        {


            List<HT_Stock.BOJ.clsCtparstatutcontrat> clsCtparstatutcontrats = new List<HT_Stock.BOJ.clsCtparstatutcontrat>();
            HT_Stock.BOJ.clsCtparstatutcontrat clsCtparstatutcontrat = new HT_Stock.BOJ.clsCtparstatutcontrat();
            clsCtparstatutcontrat.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparstatutcontrat.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparstatutcontrat.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparstatutcontrat.clsObjetRetour.SL_MESSAGE = "";
            clsCtparstatutcontrats.Add(clsCtparstatutcontrat);
            return clsCtparstatutcontrats;


        }

    }
}