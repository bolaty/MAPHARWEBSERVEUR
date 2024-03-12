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
	public partial class wsPays
	{
        public List<HT_Stock.BOJ.clsPays> TestTypeDonnee(HT_Stock.BOJ.clsPays Objet)

        {


            List<HT_Stock.BOJ.clsPays> clsPayss = new List<HT_Stock.BOJ.clsPays>();
            HT_Stock.BOJ.clsPays clsPays = new HT_Stock.BOJ.clsPays();
            clsPays.clsObjetRetour = new Common.clsObjetRetour();
            clsPays.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPays.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPays.clsObjetRetour.SL_MESSAGE = "";
            clsPayss.Add(clsPays);
            return clsPayss;


        }

    }
}