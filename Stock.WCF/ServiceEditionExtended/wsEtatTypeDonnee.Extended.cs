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
	public partial class wsEtat
	{
        public List<HT_Stock.BOJ.clsEtat> TestTypeDonnee(HT_Stock.BOJ.clsEtat Objet)

        {


            List<HT_Stock.BOJ.clsEtat> clsEtats = new List<HT_Stock.BOJ.clsEtat>();
            HT_Stock.BOJ.clsEtat clsEtat = new HT_Stock.BOJ.clsEtat();
            clsEtat.clsObjetRetour = new Common.clsObjetRetour();
            clsEtat.clsObjetRetour.SL_CODEMESSAGE = "";
            clsEtat.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsEtat.clsObjetRetour.SL_MESSAGE = "";
            clsEtats.Add(clsEtat);
            return clsEtats;


        }

    }
}