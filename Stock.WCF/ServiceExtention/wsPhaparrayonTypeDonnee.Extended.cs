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
	public partial class wsPhaparrayon
	{
        public List<HT_Stock.BOJ.clsPhaparrayon> TestTypeDonnee(HT_Stock.BOJ.clsPhaparrayon Objet)

        {


            List<HT_Stock.BOJ.clsPhaparrayon> clsPhaparrayons = new List<HT_Stock.BOJ.clsPhaparrayon>();
            HT_Stock.BOJ.clsPhaparrayon clsPhaparrayon = new HT_Stock.BOJ.clsPhaparrayon();
            clsPhaparrayon.clsObjetRetour = new Common.clsObjetRetour();
            clsPhaparrayon.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhaparrayon.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhaparrayon.clsObjetRetour.SL_MESSAGE = "";
            clsPhaparrayons.Add(clsPhaparrayon);
            return clsPhaparrayons;


        }

    }
}