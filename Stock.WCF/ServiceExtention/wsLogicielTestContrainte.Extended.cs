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
	public partial class wsLogiciel
	{
        public List<HT_Stock.BOJ.clsLogiciel> TestContrainte(HT_Stock.BOJ.clsLogiciel Objet)

        {
            List<HT_Stock.BOJ.clsLogiciel> clsLogiciels = new List<HT_Stock.BOJ.clsLogiciel>();
            HT_Stock.BOJ.clsLogiciel clsLogiciel = new HT_Stock.BOJ.clsLogiciel();
            clsLogiciel.clsObjetRetour = new Common.clsObjetRetour();
            clsLogiciel.clsObjetRetour.SL_CODEMESSAGE = "";
            clsLogiciel.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsLogiciel.clsObjetRetour.SL_MESSAGE = "";
            clsLogiciels.Add(clsLogiciel);
            return clsLogiciels;
        }



        public List<HT_Stock.BOJ.clsLogiciel> TestTestContrainteListe(HT_Stock.BOJ.clsLogiciel Objet)
        {
            List<HT_Stock.BOJ.clsLogiciel> clsLogiciels = new List<HT_Stock.BOJ.clsLogiciel>();
            HT_Stock.BOJ.clsLogiciel clsLogiciel = new HT_Stock.BOJ.clsLogiciel();
            clsLogiciel.clsObjetRetour = new Common.clsObjetRetour();
            clsLogiciel.clsObjetRetour.SL_CODEMESSAGE = "";
            clsLogiciel.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsLogiciel.clsObjetRetour.SL_MESSAGE = "";
            clsLogiciels.Add(clsLogiciel);
            return clsLogiciels;
        }
    }
}
