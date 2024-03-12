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
	public partial class wsCtparcapitauxrisqueassuranceliaison
	{
        public List<HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison> TestContrainte(HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison Objet)

        {
            List<HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison> clsCtparcapitauxrisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison>();
            HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison clsCtparcapitauxrisqueassuranceliaison = new HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison();
            clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = "";
            clsCtparcapitauxrisqueassuranceliaisons.Add(clsCtparcapitauxrisqueassuranceliaison);
            return clsCtparcapitauxrisqueassuranceliaisons;
        }



        public List<HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison> TestTestContrainteListe(HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison Objet)
        {
            List<HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison> clsCtparcapitauxrisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison>();
            HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison clsCtparcapitauxrisqueassuranceliaison = new HT_Stock.BOJ.clsCtparcapitauxrisqueassuranceliaison();
            clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparcapitauxrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = "";
            clsCtparcapitauxrisqueassuranceliaisons.Add(clsCtparcapitauxrisqueassuranceliaison);
            return clsCtparcapitauxrisqueassuranceliaisons;
        }
    }
}
