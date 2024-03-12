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
	public partial class wsPhatiers
	{
        public List<HT_Stock.BOJ.clsPhatiers> TestTypeDonnee(HT_Stock.BOJ.clsPhatiers Objet)

        {


            List<HT_Stock.BOJ.clsPhatiers> clsPhatierss = new List<HT_Stock.BOJ.clsPhatiers>();
            HT_Stock.BOJ.clsPhatiers clsPhatiers = new HT_Stock.BOJ.clsPhatiers();
            clsPhatiers.clsObjetRetour = new Common.clsObjetRetour();
            clsPhatiers.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhatiers.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhatiers.clsObjetRetour.SL_MESSAGE = "";
            clsPhatierss.Add(clsPhatiers);
            return clsPhatierss;


        }

    }
}