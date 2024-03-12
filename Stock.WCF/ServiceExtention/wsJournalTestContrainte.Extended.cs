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
	public partial class wsJournal
	{
        public List<HT_Stock.BOJ.clsJournal> TestContrainte(HT_Stock.BOJ.clsJournal Objet)

        {
            List<HT_Stock.BOJ.clsJournal> clsJournals = new List<HT_Stock.BOJ.clsJournal>();
            HT_Stock.BOJ.clsJournal clsJournal = new HT_Stock.BOJ.clsJournal();
            clsJournal.clsObjetRetour = new Common.clsObjetRetour();
            clsJournal.clsObjetRetour.SL_CODEMESSAGE = "";
            clsJournal.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsJournal.clsObjetRetour.SL_MESSAGE = "";
            clsJournals.Add(clsJournal);
            return clsJournals;
        }



        public List<HT_Stock.BOJ.clsJournal> TestTestContrainteListe(HT_Stock.BOJ.clsJournal Objet)
        {
            List<HT_Stock.BOJ.clsJournal> clsJournals = new List<HT_Stock.BOJ.clsJournal>();
            HT_Stock.BOJ.clsJournal clsJournal = new HT_Stock.BOJ.clsJournal();
            clsJournal.clsObjetRetour = new Common.clsObjetRetour();
            clsJournal.clsObjetRetour.SL_CODEMESSAGE = "";
            clsJournal.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsJournal.clsObjetRetour.SL_MESSAGE = "";
            clsJournals.Add(clsJournal);
            return clsJournals;
        }
    }
}
