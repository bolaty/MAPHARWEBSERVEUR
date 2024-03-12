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
	public partial class wsModereglement
	{
        public List<HT_Stock.BOJ.clsModereglement> TestTypeDonnee(HT_Stock.BOJ.clsModereglement Objet)

        {


            List<HT_Stock.BOJ.clsModereglement> clsModereglements = new List<HT_Stock.BOJ.clsModereglement>();
            HT_Stock.BOJ.clsModereglement clsModereglement = new HT_Stock.BOJ.clsModereglement();
            clsModereglement.clsObjetRetour = new Common.clsObjetRetour();
            clsModereglement.clsObjetRetour.SL_CODEMESSAGE = "";
            clsModereglement.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsModereglement.clsObjetRetour.SL_MESSAGE = "";
            clsModereglements.Add(clsModereglement);
            return clsModereglements;


        }

    }
}