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
	public partial class wsNumeroDebut
	{
        public List<HT_Stock.BOJ.clsPlancomptable> TestTypeDonnee(HT_Stock.BOJ.clsPlancomptable Objet)

        {


            List<HT_Stock.BOJ.clsPlancomptable> clsPlancomptables = new List<HT_Stock.BOJ.clsPlancomptable>();
            HT_Stock.BOJ.clsPlancomptable clsPlancomptable = new HT_Stock.BOJ.clsPlancomptable();
            clsPlancomptable.clsObjetRetour = new Common.clsObjetRetour();
            clsPlancomptable.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPlancomptable.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPlancomptable.clsObjetRetour.SL_MESSAGE = "";
            clsPlancomptables.Add(clsPlancomptable);
            return clsPlancomptables;


        }

    }
}