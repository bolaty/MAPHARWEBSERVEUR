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
	public partial class wsPhatiers
	{
        public List<HT_Stock.BOJ.clsPhatiers> TestContrainte(HT_Stock.BOJ.clsPhatiers Objet)

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

        public List<HT_Stock.BOJ.clsPhatiers> TestChampObligatoireInsert(HT_Stock.BOJ.clsPhatiers Objet)

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
        public List<HT_Stock.BOJ.clsPhatiers> TestChampObligatoireDelete(HT_Stock.BOJ.clsPhatiers Objet)

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
        public List<HT_Stock.BOJ.clsPhatiers> TestTestContrainteListe(HT_Stock.BOJ.clsPhatiers Objet)
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
