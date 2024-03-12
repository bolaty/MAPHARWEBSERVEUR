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
	public partial class wsCtcontrat
	{
        public List<HT_Stock.BOJ.clsCtcontrat> TestTypeDonnee(HT_Stock.BOJ.clsCtcontrat Objet)

        {


            List<HT_Stock.BOJ.clsCtcontrat> clsCtcontrats = new List<HT_Stock.BOJ.clsCtcontrat>();
            HT_Stock.BOJ.clsCtcontrat clsCtcontrat = new HT_Stock.BOJ.clsCtcontrat();
            clsCtcontrat.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontrat.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtcontrat.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtcontrat.clsObjetRetour.SL_MESSAGE = "";
            clsCtcontrats.Add(clsCtcontrat);
            return clsCtcontrats;


        }

    }
}