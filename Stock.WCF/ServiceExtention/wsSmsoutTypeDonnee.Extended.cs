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
	public partial class wsSmsout
	{
        public List<HT_Stock.BOJ.clsSmsout> TestTypeDonnee(HT_Stock.BOJ.clsSmsout Objet)

        {


            List<HT_Stock.BOJ.clsSmsout> clsSmsouts = new List<HT_Stock.BOJ.clsSmsout>();
            HT_Stock.BOJ.clsSmsout clsSmsout = new HT_Stock.BOJ.clsSmsout();
            clsSmsout.clsObjetRetour = new Common.clsObjetRetour();
            clsSmsout.clsObjetRetour.SL_CODEMESSAGE = "";
            clsSmsout.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsSmsout.clsObjetRetour.SL_MESSAGE = "";
            clsSmsouts.Add(clsSmsout);
            return clsSmsouts;


        }

    }
}