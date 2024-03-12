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
	public partial class wsCtparquestionnairedocumentrisqueassuranceliaison
	{
        public List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison> TestTypeDonnee(HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison Objet)

        {


            List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison> clsCtparquestionnairedocumentrisqueassuranceliaisons = new List<HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison>();
            HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison clsCtparquestionnairedocumentrisqueassuranceliaison = new HT_Stock.BOJ.clsCtparquestionnairedocumentrisqueassuranceliaison();
            clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparquestionnairedocumentrisqueassuranceliaison.clsObjetRetour.SL_MESSAGE = "";
            clsCtparquestionnairedocumentrisqueassuranceliaisons.Add(clsCtparquestionnairedocumentrisqueassuranceliaison);
            return clsCtparquestionnairedocumentrisqueassuranceliaisons;


        }

    }
}