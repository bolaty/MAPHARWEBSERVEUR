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
	public partial class wsCtparusageauto
	{
        public List<HT_Stock.BOJ.clsCtparusageauto> TestContrainte(HT_Stock.BOJ.clsCtparusageauto Objet)

        {
            List<HT_Stock.BOJ.clsCtparusageauto> clsCtparusageautos = new List<HT_Stock.BOJ.clsCtparusageauto>();
            HT_Stock.BOJ.clsCtparusageauto clsCtparusageauto = new HT_Stock.BOJ.clsCtparusageauto();
            clsCtparusageauto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparusageauto.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparusageauto.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparusageauto.clsObjetRetour.SL_MESSAGE = "";
            clsCtparusageautos.Add(clsCtparusageauto);
            return clsCtparusageautos;
        }



        public List<HT_Stock.BOJ.clsCtparusageauto> TestTestContrainteListe(HT_Stock.BOJ.clsCtparusageauto Objet)
        {
            List<HT_Stock.BOJ.clsCtparusageauto> clsCtparusageautos = new List<HT_Stock.BOJ.clsCtparusageauto>();
            HT_Stock.BOJ.clsCtparusageauto clsCtparusageauto = new HT_Stock.BOJ.clsCtparusageauto();
            clsCtparusageauto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparusageauto.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparusageauto.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparusageauto.clsObjetRetour.SL_MESSAGE = "";
            clsCtparusageautos.Add(clsCtparusageauto);
            return clsCtparusageautos;
        }
    }
}
