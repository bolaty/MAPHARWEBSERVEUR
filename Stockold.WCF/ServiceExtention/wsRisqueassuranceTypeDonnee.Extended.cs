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
	public partial class wsRisqueassurance
	{
        public List<HT_Stock.BOJ.clsCtparrisqueassurance> TestTypeDonnee(HT_Stock.BOJ.clsCtparrisqueassurance Objet)

        {


            List<HT_Stock.BOJ.clsCtparrisqueassurance> clsCtparrisqueassurances = new List<HT_Stock.BOJ.clsCtparrisqueassurance>();
            HT_Stock.BOJ.clsCtparrisqueassurance clsCtparrisqueassurance = new HT_Stock.BOJ.clsCtparrisqueassurance();
            clsCtparrisqueassurance.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparrisqueassurance.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparrisqueassurance.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparrisqueassurance.clsObjetRetour.SL_MESSAGE = "";
            clsCtparrisqueassurances.Add(clsCtparrisqueassurance);
            return clsCtparrisqueassurances;


        }

    }
}