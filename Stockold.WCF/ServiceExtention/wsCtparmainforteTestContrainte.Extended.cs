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
	public partial class wsCtparmainforte
	{
        public List<HT_Stock.BOJ.clsCtparmainforte> TestContrainte(HT_Stock.BOJ.clsCtparmainforte Objet)

        {
            List<HT_Stock.BOJ.clsCtparmainforte> clsCtparmainfortes = new List<HT_Stock.BOJ.clsCtparmainforte>();
            HT_Stock.BOJ.clsCtparmainforte clsCtparmainforte = new HT_Stock.BOJ.clsCtparmainforte();
            clsCtparmainforte.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparmainforte.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparmainforte.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparmainforte.clsObjetRetour.SL_MESSAGE = "";
            clsCtparmainfortes.Add(clsCtparmainforte);
            return clsCtparmainfortes;
        }



        public List<HT_Stock.BOJ.clsCtparmainforte> TestTestContrainteListe(HT_Stock.BOJ.clsCtparmainforte Objet)
        {
            List<HT_Stock.BOJ.clsCtparmainforte> clsCtparmainfortes = new List<HT_Stock.BOJ.clsCtparmainforte>();
            HT_Stock.BOJ.clsCtparmainforte clsCtparmainforte = new HT_Stock.BOJ.clsCtparmainforte();
            clsCtparmainforte.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparmainforte.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparmainforte.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparmainforte.clsObjetRetour.SL_MESSAGE = "";
            clsCtparmainfortes.Add(clsCtparmainforte);
            return clsCtparmainfortes;
        }
    }
}