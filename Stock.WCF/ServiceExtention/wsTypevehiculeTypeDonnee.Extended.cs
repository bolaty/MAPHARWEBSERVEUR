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
	public partial class wsTypevehicule
	{
        public List<HT_Stock.BOJ.clsTypevehicule> TestTypeDonnee(HT_Stock.BOJ.clsTypevehicule Objet)

        {


            List<HT_Stock.BOJ.clsTypevehicule> clsTypevehicules = new List<HT_Stock.BOJ.clsTypevehicule>();
            HT_Stock.BOJ.clsTypevehicule clsTypevehicule = new HT_Stock.BOJ.clsTypevehicule();
            clsTypevehicule.clsObjetRetour = new Common.clsObjetRetour();
            clsTypevehicule.clsObjetRetour.SL_CODEMESSAGE = "";
            clsTypevehicule.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsTypevehicule.clsObjetRetour.SL_MESSAGE = "";
            clsTypevehicules.Add(clsTypevehicule);
            return clsTypevehicules;


        }

    }
}