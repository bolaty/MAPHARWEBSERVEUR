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
	public partial class wsBanque
	{
        public List<HT_Stock.BOJ.clsBanque> TestTypeDonnee(HT_Stock.BOJ.clsBanque Objet)

        {


            List<HT_Stock.BOJ.clsBanque> clsBanques = new List<HT_Stock.BOJ.clsBanque>();
            HT_Stock.BOJ.clsBanque clsBanque = new HT_Stock.BOJ.clsBanque();
            clsBanque.clsObjetRetour = new Common.clsObjetRetour();
            clsBanque.clsObjetRetour.SL_CODEMESSAGE = "";
            clsBanque.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsBanque.clsObjetRetour.SL_MESSAGE = "";
            clsBanques.Add(clsBanque);
            return clsBanques;


        }

    }
}