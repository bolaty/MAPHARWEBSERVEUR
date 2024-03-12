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
	public partial class wsPlancomptablenaturecomptemodereglement
	{
        public List<HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement> TestTypeDonnee(HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement Objet)

        {


            List<HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement> clsPlancomptablenaturecomptemodereglements = new List<HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement>();
            HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement clsPlancomptablenaturecomptemodereglement = new HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement();
            clsPlancomptablenaturecomptemodereglement.clsObjetRetour = new Common.clsObjetRetour();
            clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_MESSAGE = "";
            clsPlancomptablenaturecomptemodereglements.Add(clsPlancomptablenaturecomptemodereglement);
            return clsPlancomptablenaturecomptemodereglements;


        }

    }
}