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
	public partial class wsCtpartauxauto
	{
        public List<HT_Stock.BOJ.clsCtpartauxauto> TestContrainte(HT_Stock.BOJ.clsCtpartauxauto Objet)

        {
            List<HT_Stock.BOJ.clsCtpartauxauto> clsCtpartauxautos = new List<HT_Stock.BOJ.clsCtpartauxauto>();
            HT_Stock.BOJ.clsCtpartauxauto clsCtpartauxauto = new HT_Stock.BOJ.clsCtpartauxauto();
            clsCtpartauxauto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpartauxauto.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtpartauxauto.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtpartauxauto.clsObjetRetour.SL_MESSAGE = "";
            clsCtpartauxautos.Add(clsCtpartauxauto);
            return clsCtpartauxautos;
        }



        public List<HT_Stock.BOJ.clsCtpartauxauto> TestTestContrainteListe(HT_Stock.BOJ.clsCtpartauxauto Objet)
        {
            List<HT_Stock.BOJ.clsCtpartauxauto> clsCtpartauxautos = new List<HT_Stock.BOJ.clsCtpartauxauto>();
            HT_Stock.BOJ.clsCtpartauxauto clsCtpartauxauto = new HT_Stock.BOJ.clsCtpartauxauto();
            clsCtpartauxauto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpartauxauto.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtpartauxauto.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtpartauxauto.clsObjetRetour.SL_MESSAGE = "";
            clsCtpartauxautos.Add(clsCtpartauxauto);
            return clsCtpartauxautos;
        }
    }
}
