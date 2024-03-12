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
	public partial class wsZoneauto
	{
        public List<HT_Stock.BOJ.clsZoneauto> TestTypeDonnee(HT_Stock.BOJ.clsZoneauto Objet)

        {


            List<HT_Stock.BOJ.clsZoneauto> clsZoneautos = new List<HT_Stock.BOJ.clsZoneauto>();
            HT_Stock.BOJ.clsZoneauto clsZoneauto = new HT_Stock.BOJ.clsZoneauto();
            clsZoneauto.clsObjetRetour = new Common.clsObjetRetour();
            clsZoneauto.clsObjetRetour.SL_CODEMESSAGE = "";
            clsZoneauto.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsZoneauto.clsObjetRetour.SL_MESSAGE = "";
            clsZoneautos.Add(clsZoneauto);
            return clsZoneautos;


        }

    }
}