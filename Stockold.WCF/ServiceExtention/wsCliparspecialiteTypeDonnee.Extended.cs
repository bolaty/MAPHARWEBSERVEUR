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
	public partial class wsCliparspecialite
	{
        public List<HT_Stock.BOJ.clsCliparspecialite> TestTypeDonnee(HT_Stock.BOJ.clsCliparspecialite Objet)

        {


            List<HT_Stock.BOJ.clsCliparspecialite> clsCliparspecialites = new List<HT_Stock.BOJ.clsCliparspecialite>();
            HT_Stock.BOJ.clsCliparspecialite clsCliparspecialite = new HT_Stock.BOJ.clsCliparspecialite();
            clsCliparspecialite.clsObjetRetour = new Common.clsObjetRetour();
            clsCliparspecialite.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCliparspecialite.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCliparspecialite.clsObjetRetour.SL_MESSAGE = "";
            clsCliparspecialites.Add(clsCliparspecialite);
            return clsCliparspecialites;


        }

    }
}