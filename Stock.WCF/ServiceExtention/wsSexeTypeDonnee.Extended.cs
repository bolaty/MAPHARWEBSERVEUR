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
	public partial class wsSexe
	{
        public List<HT_Stock.BOJ.clsSexe> TestTypeDonnee(HT_Stock.BOJ.clsSexe Objet)

        {


            List<HT_Stock.BOJ.clsSexe> clsSexes = new List<HT_Stock.BOJ.clsSexe>();
            HT_Stock.BOJ.clsSexe clsSexe = new HT_Stock.BOJ.clsSexe();
            clsSexe.clsObjetRetour = new Common.clsObjetRetour();
            clsSexe.clsObjetRetour.SL_CODEMESSAGE = "";
            clsSexe.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsSexe.clsObjetRetour.SL_MESSAGE = "";
            clsSexes.Add(clsSexe);
            return clsSexes;


        }

    }
}