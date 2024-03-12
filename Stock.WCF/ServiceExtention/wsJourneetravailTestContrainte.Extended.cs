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
	public partial class wsJourneetravail
	{
        public List<HT_Stock.BOJ.clsJourneetravail> TestContrainte(HT_Stock.BOJ.clsJourneetravail Objet)

        {
            List<HT_Stock.BOJ.clsJourneetravail> clsJourneetravails = new List<HT_Stock.BOJ.clsJourneetravail>();
            HT_Stock.BOJ.clsJourneetravail clsJourneetravail = new HT_Stock.BOJ.clsJourneetravail();
            clsJourneetravail.clsObjetRetour = new Common.clsObjetRetour();
            clsJourneetravail.clsObjetRetour.SL_CODEMESSAGE = "";
            clsJourneetravail.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsJourneetravail.clsObjetRetour.SL_MESSAGE = "";
            clsJourneetravails.Add(clsJourneetravail);
            return clsJourneetravails;
        }



        public List<HT_Stock.BOJ.clsJourneetravail> TestTestContrainteListe(HT_Stock.BOJ.clsJourneetravail Objet)
        {
            List<HT_Stock.BOJ.clsJourneetravail> clsJourneetravails = new List<HT_Stock.BOJ.clsJourneetravail>();
            HT_Stock.BOJ.clsJourneetravail clsJourneetravail = new HT_Stock.BOJ.clsJourneetravail();
            clsJourneetravail.clsObjetRetour = new Common.clsObjetRetour();
            clsJourneetravail.clsObjetRetour.SL_CODEMESSAGE = "";
            clsJourneetravail.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsJourneetravail.clsObjetRetour.SL_MESSAGE = "";
            clsJourneetravails.Add(clsJourneetravail);
            return clsJourneetravails;
        }
    }
}
