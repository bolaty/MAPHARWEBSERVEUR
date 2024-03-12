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
	public partial class wsPhaparnaturetiers
	{
        public List<HT_Stock.BOJ.clsPhaparnaturetiers> TestContrainte(HT_Stock.BOJ.clsPhaparnaturetiers Objet)

        {
            List<HT_Stock.BOJ.clsPhaparnaturetiers> clsPhaparnaturetierss = new List<HT_Stock.BOJ.clsPhaparnaturetiers>();
            HT_Stock.BOJ.clsPhaparnaturetiers clsPhaparnaturetiers = new HT_Stock.BOJ.clsPhaparnaturetiers();
            clsPhaparnaturetiers.clsObjetRetour = new Common.clsObjetRetour();
            clsPhaparnaturetiers.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhaparnaturetiers.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhaparnaturetiers.clsObjetRetour.SL_MESSAGE = "";
            clsPhaparnaturetierss.Add(clsPhaparnaturetiers);
            return clsPhaparnaturetierss;
        }



        public List<HT_Stock.BOJ.clsPhaparnaturetiers> TestTestContrainteListe(HT_Stock.BOJ.clsPhaparnaturetiers Objet)
        {
            List<HT_Stock.BOJ.clsPhaparnaturetiers> clsPhaparnaturetierss = new List<HT_Stock.BOJ.clsPhaparnaturetiers>();
            HT_Stock.BOJ.clsPhaparnaturetiers clsPhaparnaturetiers = new HT_Stock.BOJ.clsPhaparnaturetiers();
            clsPhaparnaturetiers.clsObjetRetour = new Common.clsObjetRetour();
            clsPhaparnaturetiers.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhaparnaturetiers.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhaparnaturetiers.clsObjetRetour.SL_MESSAGE = "";
            clsPhaparnaturetierss.Add(clsPhaparnaturetiers);
            return clsPhaparnaturetierss;
        }
    }
}
