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
	public partial class wsClipartypejourfacturation
	{
        public List<HT_Stock.BOJ.clsClipartypejourfacturation> TestTypeDonnee(HT_Stock.BOJ.clsClipartypejourfacturation Objet)

        {


            List<HT_Stock.BOJ.clsClipartypejourfacturation> clsClipartypejourfacturations = new List<HT_Stock.BOJ.clsClipartypejourfacturation>();
            HT_Stock.BOJ.clsClipartypejourfacturation clsClipartypejourfacturation = new HT_Stock.BOJ.clsClipartypejourfacturation();
            clsClipartypejourfacturation.clsObjetRetour = new Common.clsObjetRetour();
            clsClipartypejourfacturation.clsObjetRetour.SL_CODEMESSAGE = "";
            clsClipartypejourfacturation.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsClipartypejourfacturation.clsObjetRetour.SL_MESSAGE = "";
            clsClipartypejourfacturations.Add(clsClipartypejourfacturation);
            return clsClipartypejourfacturations;


        }

    }
}