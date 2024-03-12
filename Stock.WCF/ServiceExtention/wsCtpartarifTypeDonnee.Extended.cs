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
	public partial class wsCtpartarif
	{
        public List<HT_Stock.BOJ.clsCtpartarif> TestTypeDonnee(HT_Stock.BOJ.clsCtpartarif Objet)

        {


            List<HT_Stock.BOJ.clsCtpartarif> clsCtpartarifs = new List<HT_Stock.BOJ.clsCtpartarif>();
            HT_Stock.BOJ.clsCtpartarif clsCtpartarif = new HT_Stock.BOJ.clsCtpartarif();
            clsCtpartarif.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpartarif.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtpartarif.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtpartarif.clsObjetRetour.SL_MESSAGE = "";
            clsCtpartarifs.Add(clsCtpartarif);
            return clsCtpartarifs;


        }

    }
}