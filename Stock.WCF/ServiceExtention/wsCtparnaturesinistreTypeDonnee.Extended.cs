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
	public partial class wsCtparnaturesinistre
	{
        public List<HT_Stock.BOJ.clsCtparnaturesinistre> TestTypeDonnee(HT_Stock.BOJ.clsCtparnaturesinistre Objet)

        {


            List<HT_Stock.BOJ.clsCtparnaturesinistre> clsCtparnaturesinistres = new List<HT_Stock.BOJ.clsCtparnaturesinistre>();
            HT_Stock.BOJ.clsCtparnaturesinistre clsCtparnaturesinistre = new HT_Stock.BOJ.clsCtparnaturesinistre();
            clsCtparnaturesinistre.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparnaturesinistre.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparnaturesinistre.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparnaturesinistre.clsObjetRetour.SL_MESSAGE = "";
            clsCtparnaturesinistres.Add(clsCtparnaturesinistre);
            return clsCtparnaturesinistres;


        }

    }
}