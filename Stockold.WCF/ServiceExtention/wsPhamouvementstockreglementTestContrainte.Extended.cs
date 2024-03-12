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
	public partial class wsPhamouvementstockreglement
	{
        public List<HT_Stock.BOJ.clsPhamouvementstockreglement> TestContrainte(HT_Stock.BOJ.clsPhamouvementstockreglement Objet)

        {
            List<HT_Stock.BOJ.clsPhamouvementstockreglement> clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
            HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
            clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
            clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "";
            clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            return clsPhamouvementstockreglements;
        }



        public List<HT_Stock.BOJ.clsPhamouvementstockreglement> TestTestContrainteListe(HT_Stock.BOJ.clsPhamouvementstockreglement Objet)
        {
            List<HT_Stock.BOJ.clsPhamouvementstockreglement> clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
            HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
            clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
            clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "";
            clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            return clsPhamouvementstockreglements;
        }
    }
}
