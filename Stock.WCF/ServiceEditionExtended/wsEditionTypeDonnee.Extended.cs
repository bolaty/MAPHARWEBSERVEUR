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
	public partial class wsEdition
	{
        public List<HT_Stock.BOJ.clsEdition> TestTypeDonnee(HT_Stock.BOJ.clsEdition Objet)

        {


            List<HT_Stock.BOJ.clsEdition> clsEditions = new List<HT_Stock.BOJ.clsEdition>();
            HT_Stock.BOJ.clsEdition clsEdition = new HT_Stock.BOJ.clsEdition();
            clsEdition.clsObjetRetour = new Common.clsObjetRetour();
            clsEdition.clsObjetRetour.SL_CODEMESSAGE = "";
            clsEdition.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsEdition.clsObjetRetour.SL_MESSAGE = "";
            clsEditions.Add(clsEdition);
            return clsEditions;


        }

    }
}