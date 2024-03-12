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
	public partial class wsPlancomptable
	{
        public List<HT_Stock.BOJ.clsPlancomptable> TestContrainte(HT_Stock.BOJ.clsPlancomptable Objet)

        {
            List<HT_Stock.BOJ.clsPlancomptable> clsPlancomptables = new List<HT_Stock.BOJ.clsPlancomptable>();
            HT_Stock.BOJ.clsPlancomptable clsPlancomptable = new HT_Stock.BOJ.clsPlancomptable();
            clsPlancomptable.clsObjetRetour = new Common.clsObjetRetour();
            clsPlancomptable.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPlancomptable.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPlancomptable.clsObjetRetour.SL_MESSAGE = "";
            clsPlancomptables.Add(clsPlancomptable);
            return clsPlancomptables;
        }



        public List<HT_Stock.BOJ.clsPlancomptable> TestTestContrainteListe(HT_Stock.BOJ.clsPlancomptable Objet)
        {
            List<HT_Stock.BOJ.clsPlancomptable> clsPlancomptables = new List<HT_Stock.BOJ.clsPlancomptable>();
            HT_Stock.BOJ.clsPlancomptable clsPlancomptable = new HT_Stock.BOJ.clsPlancomptable();
            clsPlancomptable.clsObjetRetour = new Common.clsObjetRetour();
            clsPlancomptable.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPlancomptable.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPlancomptable.clsObjetRetour.SL_MESSAGE = "";
            clsPlancomptables.Add(clsPlancomptable);
            return clsPlancomptables;
        }
    }
}
