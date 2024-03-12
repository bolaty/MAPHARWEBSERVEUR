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
	public partial class wsLogiciel
	{
        public List<HT_Stock.BOJ.clsLogiciel> TestTypeDonnee(HT_Stock.BOJ.clsLogiciel Objet)

        {


            List<HT_Stock.BOJ.clsLogiciel> clsLogiciels = new List<HT_Stock.BOJ.clsLogiciel>();
            HT_Stock.BOJ.clsLogiciel clsLogiciel = new HT_Stock.BOJ.clsLogiciel();
            clsLogiciel.clsObjetRetour = new Common.clsObjetRetour();
            clsLogiciel.clsObjetRetour.SL_CODEMESSAGE = "";
            clsLogiciel.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsLogiciel.clsObjetRetour.SL_MESSAGE = "";
            clsLogiciels.Add(clsLogiciel);
            return clsLogiciels;


        }

    }
}