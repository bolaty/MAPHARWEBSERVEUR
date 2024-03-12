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
	public partial class wsModereglement
	{
        public List<HT_Stock.BOJ.clsModereglement> TestContrainte(HT_Stock.BOJ.clsModereglement Objet)

        {
            List<HT_Stock.BOJ.clsModereglement> clsModereglements = new List<HT_Stock.BOJ.clsModereglement>();
            HT_Stock.BOJ.clsModereglement clsModereglement = new HT_Stock.BOJ.clsModereglement();
            clsModereglement.clsObjetRetour = new Common.clsObjetRetour();
            clsModereglement.clsObjetRetour.SL_CODEMESSAGE = "";
            clsModereglement.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsModereglement.clsObjetRetour.SL_MESSAGE = "";
            clsModereglements.Add(clsModereglement);
            return clsModereglements;
        }



        public List<HT_Stock.BOJ.clsModereglement> TestTestContrainteListe(HT_Stock.BOJ.clsModereglement Objet)
        {
            List<HT_Stock.BOJ.clsModereglement> clsModereglements = new List<HT_Stock.BOJ.clsModereglement>();
            HT_Stock.BOJ.clsModereglement clsModereglement = new HT_Stock.BOJ.clsModereglement();
            clsModereglement.clsObjetRetour = new Common.clsObjetRetour();
            clsModereglement.clsObjetRetour.SL_CODEMESSAGE = "";
            clsModereglement.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsModereglement.clsObjetRetour.SL_MESSAGE = "";
            clsModereglements.Add(clsModereglement);
            return clsModereglements;
        }
    }
}
