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
	public partial class wsRegimeimposition
	{
        public List<HT_Stock.BOJ.clsRegimeimposition> TestTypeDonnee(HT_Stock.BOJ.clsRegimeimposition Objet)

        {


            List<HT_Stock.BOJ.clsRegimeimposition> clsRegimeimpositions = new List<HT_Stock.BOJ.clsRegimeimposition>();
            HT_Stock.BOJ.clsRegimeimposition clsRegimeimposition = new HT_Stock.BOJ.clsRegimeimposition();
            clsRegimeimposition.clsObjetRetour = new Common.clsObjetRetour();
            clsRegimeimposition.clsObjetRetour.SL_CODEMESSAGE = "";
            clsRegimeimposition.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsRegimeimposition.clsObjetRetour.SL_MESSAGE = "";
            clsRegimeimpositions.Add(clsRegimeimposition);
            return clsRegimeimpositions;


        }

    }
}