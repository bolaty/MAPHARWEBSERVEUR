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
	public partial class wsPhapartypetierscompterattacheadditionnel
	{
        public List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel> TestContrainte(HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel Objet)

        {
            List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel> clsPhapartypetierscompterattacheadditionnels = new List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel>();
            HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel clsPhapartypetierscompterattacheadditionnel = new HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel();
            clsPhapartypetierscompterattacheadditionnel.clsObjetRetour = new Common.clsObjetRetour();
            clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_MESSAGE = "";
            clsPhapartypetierscompterattacheadditionnels.Add(clsPhapartypetierscompterattacheadditionnel);
            return clsPhapartypetierscompterattacheadditionnels;
        }



        public List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel> TestTestContrainteListe(HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel Objet)
        {
            List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel> clsPhapartypetierscompterattacheadditionnels = new List<HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel>();
            HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel clsPhapartypetierscompterattacheadditionnel = new HT_Stock.BOJ.clsPhapartypetierscompterattacheadditionnel();
            clsPhapartypetierscompterattacheadditionnel.clsObjetRetour = new Common.clsObjetRetour();
            clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhapartypetierscompterattacheadditionnel.clsObjetRetour.SL_MESSAGE = "";
            clsPhapartypetierscompterattacheadditionnels.Add(clsPhapartypetierscompterattacheadditionnel);
            return clsPhapartypetierscompterattacheadditionnels;
        }
    }
}
