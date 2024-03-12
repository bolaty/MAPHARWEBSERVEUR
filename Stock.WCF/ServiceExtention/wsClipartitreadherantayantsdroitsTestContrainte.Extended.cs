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
	public partial class wsClipartitreadherantayantsdroits
	{
        public List<HT_Stock.BOJ.clsClipartitreadherantayantsdroits> TestContrainte(HT_Stock.BOJ.clsClipartitreadherantayantsdroits Objet)

        {
            List<HT_Stock.BOJ.clsClipartitreadherantayantsdroits> clsClipartitreadherantayantsdroitss = new List<HT_Stock.BOJ.clsClipartitreadherantayantsdroits>();
            HT_Stock.BOJ.clsClipartitreadherantayantsdroits clsClipartitreadherantayantsdroits = new HT_Stock.BOJ.clsClipartitreadherantayantsdroits();
            clsClipartitreadherantayantsdroits.clsObjetRetour = new Common.clsObjetRetour();
            clsClipartitreadherantayantsdroits.clsObjetRetour.SL_CODEMESSAGE = "";
            clsClipartitreadherantayantsdroits.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsClipartitreadherantayantsdroits.clsObjetRetour.SL_MESSAGE = "";
            clsClipartitreadherantayantsdroitss.Add(clsClipartitreadherantayantsdroits);
            return clsClipartitreadherantayantsdroitss;
        }



        public List<HT_Stock.BOJ.clsClipartitreadherantayantsdroits> TestTestContrainteListe(HT_Stock.BOJ.clsClipartitreadherantayantsdroits Objet)
        {
            List<HT_Stock.BOJ.clsClipartitreadherantayantsdroits> clsClipartitreadherantayantsdroitss = new List<HT_Stock.BOJ.clsClipartitreadherantayantsdroits>();
            HT_Stock.BOJ.clsClipartitreadherantayantsdroits clsClipartitreadherantayantsdroits = new HT_Stock.BOJ.clsClipartitreadherantayantsdroits();
            clsClipartitreadherantayantsdroits.clsObjetRetour = new Common.clsObjetRetour();
            clsClipartitreadherantayantsdroits.clsObjetRetour.SL_CODEMESSAGE = "";
            clsClipartitreadherantayantsdroits.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsClipartitreadherantayantsdroits.clsObjetRetour.SL_MESSAGE = "";
            clsClipartitreadherantayantsdroitss.Add(clsClipartitreadherantayantsdroits);
            return clsClipartitreadherantayantsdroitss;
        }
    }
}
