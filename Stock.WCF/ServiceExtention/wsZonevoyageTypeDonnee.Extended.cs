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
	public partial class wsZonevoyage
	{
        public List<HT_Stock.BOJ.clsZonevoyage> TestTypeDonnee(HT_Stock.BOJ.clsZonevoyage Objet)

        {


            List<HT_Stock.BOJ.clsZonevoyage> clsZonevoyages = new List<HT_Stock.BOJ.clsZonevoyage>();
            HT_Stock.BOJ.clsZonevoyage clsZonevoyage = new HT_Stock.BOJ.clsZonevoyage();
            clsZonevoyage.clsObjetRetour = new Common.clsObjetRetour();
            clsZonevoyage.clsObjetRetour.SL_CODEMESSAGE = "";
            clsZonevoyage.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsZonevoyage.clsObjetRetour.SL_MESSAGE = "";
            clsZonevoyages.Add(clsZonevoyage);
            return clsZonevoyages;


        }

    }
}