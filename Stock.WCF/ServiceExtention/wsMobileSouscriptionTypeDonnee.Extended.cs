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
	public partial class wsMobileSouscription
	{
        public List<HT_Stock.BOJ.clsMobileSouscription> TestTypeDonnee(HT_Stock.BOJ.clsMobileSouscription Objet)

        {


            List<HT_Stock.BOJ.clsMobileSouscription> clsMobileSouscriptions = new List<HT_Stock.BOJ.clsMobileSouscription>();
            HT_Stock.BOJ.clsMobileSouscription clsMobileSouscription = new HT_Stock.BOJ.clsMobileSouscription();
            clsMobileSouscription.clsObjetRetour = new Common.clsObjetRetour();
            clsMobileSouscription.clsObjetRetour.SL_CODEMESSAGE = "";
            clsMobileSouscription.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsMobileSouscription.clsObjetRetour.SL_MESSAGE = "";
            clsMobileSouscriptions.Add(clsMobileSouscription);
            return clsMobileSouscriptions;


        }

    }
}