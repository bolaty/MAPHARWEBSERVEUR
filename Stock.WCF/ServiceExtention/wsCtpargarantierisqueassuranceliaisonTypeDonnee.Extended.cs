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
	public partial class wsCtpargarantierisqueassuranceliaison
	{
        public List<HT_Stock.BOJ.clsCtpargarantierisqueassuranceliaison> TestTypeDonnee(HT_Stock.BOJ.clsCtpargarantierisqueassuranceliaison Objet)

        {


            List<HT_Stock.BOJ.clsCtpargarantierisqueassuranceliaison> clsCtpargarantierisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtpargarantierisqueassuranceliaison>();
            HT_Stock.BOJ.clsCtpargarantierisqueassuranceliaison clsCtpargarantierisqueassuranceliaison = new HT_Stock.BOJ.clsCtpargarantierisqueassuranceliaison();
            clsCtpargarantierisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpargarantierisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtpargarantierisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtpargarantierisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = "";
            clsCtpargarantierisqueassuranceliaisons.Add(clsCtpargarantierisqueassuranceliaison);
            return clsCtpargarantierisqueassuranceliaisons;


        }

    }
}