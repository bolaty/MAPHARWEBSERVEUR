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
	public partial class wsClipartypeconsultattion
	{
        public List<HT_Stock.BOJ.clsClipartypeconsultattion> TestContrainte(HT_Stock.BOJ.clsClipartypeconsultattion Objet)

        {
            List<HT_Stock.BOJ.clsClipartypeconsultattion> clsClipartypeconsultattions = new List<HT_Stock.BOJ.clsClipartypeconsultattion>();
            HT_Stock.BOJ.clsClipartypeconsultattion clsClipartypeconsultattion = new HT_Stock.BOJ.clsClipartypeconsultattion();
            clsClipartypeconsultattion.clsObjetRetour = new Common.clsObjetRetour();
            clsClipartypeconsultattion.clsObjetRetour.SL_CODEMESSAGE = "";
            clsClipartypeconsultattion.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsClipartypeconsultattion.clsObjetRetour.SL_MESSAGE = "";
            clsClipartypeconsultattions.Add(clsClipartypeconsultattion);
            return clsClipartypeconsultattions;
        }



        public List<HT_Stock.BOJ.clsClipartypeconsultattion> TestTestContrainteListe(HT_Stock.BOJ.clsClipartypeconsultattion Objet)
        {
            List<HT_Stock.BOJ.clsClipartypeconsultattion> clsClipartypeconsultattions = new List<HT_Stock.BOJ.clsClipartypeconsultattion>();
            HT_Stock.BOJ.clsClipartypeconsultattion clsClipartypeconsultattion = new HT_Stock.BOJ.clsClipartypeconsultattion();
            clsClipartypeconsultattion.clsObjetRetour = new Common.clsObjetRetour();
            clsClipartypeconsultattion.clsObjetRetour.SL_CODEMESSAGE = "";
            clsClipartypeconsultattion.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsClipartypeconsultattion.clsObjetRetour.SL_MESSAGE = "";
            clsClipartypeconsultattions.Add(clsClipartypeconsultattion);
            return clsClipartypeconsultattions;
        }
    }
}
