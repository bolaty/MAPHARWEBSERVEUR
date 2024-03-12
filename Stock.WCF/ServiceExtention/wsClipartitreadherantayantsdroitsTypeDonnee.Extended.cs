using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Stock.BOJ;
using Stock.WSBLL;
using Stock.WSTOOLS;
using Stock.Common;
namespace Stock.WCF
{
	public partial class wsClipartitreadherantayantsdroits
	{
        public List<HT_Stock.BOJ.clsClipartitreadherantayantsdroits> TestTypeDonnee(HT_Stock.BOJ.clsClipartitreadherantayantsdroits Objet)

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