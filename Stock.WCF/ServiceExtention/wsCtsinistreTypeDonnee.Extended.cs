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
	public partial class wsCtsinistre
	{
        public List<HT_Stock.BOJ.clsCtsinistre> TestTypeDonnee(HT_Stock.BOJ.clsCtsinistre Objet)

        {


            List<HT_Stock.BOJ.clsCtsinistre> clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();
            HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();
            clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
            clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtsinistre.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtsinistre.clsObjetRetour.SL_MESSAGE = "";
            clsCtsinistres.Add(clsCtsinistre);
            return clsCtsinistres;


        }

    }
}