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
	public partial class wsCtpartypecontratauto
	{
        public List<HT_Stock.BOJ.clsCtpartypecontratauto> TestContrainte(HT_Stock.BOJ.clsCtpartypecontratauto Objet)

        {
            List<HT_Stock.BOJ.clsCtpartypecontratauto> clsCtpartypecontratautos = new List<HT_Stock.BOJ.clsCtpartypecontratauto>();
            HT_Stock.BOJ.clsCtpartypecontratauto clsCtpartypecontratauto = new HT_Stock.BOJ.clsCtpartypecontratauto();
            clsCtpartypecontratauto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpartypecontratauto.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtpartypecontratauto.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtpartypecontratauto.clsObjetRetour.SL_MESSAGE = "";
            clsCtpartypecontratautos.Add(clsCtpartypecontratauto);
            return clsCtpartypecontratautos;
        }



        public List<HT_Stock.BOJ.clsCtpartypecontratauto> TestTestContrainteListe(HT_Stock.BOJ.clsCtpartypecontratauto Objet)
        {
            List<HT_Stock.BOJ.clsCtpartypecontratauto> clsCtpartypecontratautos = new List<HT_Stock.BOJ.clsCtpartypecontratauto>();
            HT_Stock.BOJ.clsCtpartypecontratauto clsCtpartypecontratauto = new HT_Stock.BOJ.clsCtpartypecontratauto();
            clsCtpartypecontratauto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpartypecontratauto.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtpartypecontratauto.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtpartypecontratauto.clsObjetRetour.SL_MESSAGE = "";
            clsCtpartypecontratautos.Add(clsCtpartypecontratauto);
            return clsCtpartypecontratautos;
        }
    }
}
