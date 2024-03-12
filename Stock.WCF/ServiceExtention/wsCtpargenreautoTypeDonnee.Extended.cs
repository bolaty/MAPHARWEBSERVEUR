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
	public partial class wsCtpargenreauto
	{
        public List<HT_Stock.BOJ.clsCtpargenreauto> TestTypeDonnee(HT_Stock.BOJ.clsCtpargenreauto Objet)

        {


            List<HT_Stock.BOJ.clsCtpargenreauto> clsCtpargenreautos = new List<HT_Stock.BOJ.clsCtpargenreauto>();
            HT_Stock.BOJ.clsCtpargenreauto clsCtpargenreauto = new HT_Stock.BOJ.clsCtpargenreauto();
            clsCtpargenreauto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpargenreauto.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtpargenreauto.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtpargenreauto.clsObjetRetour.SL_MESSAGE = "";
            clsCtpargenreautos.Add(clsCtpargenreauto);
            return clsCtpargenreautos;


        }

    }
}