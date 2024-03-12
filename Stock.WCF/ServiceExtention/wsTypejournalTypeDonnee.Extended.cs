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
	public partial class wsTypejournal
	{
        public List<HT_Stock.BOJ.clsTypejournal> TestTypeDonnee(HT_Stock.BOJ.clsTypejournal Objet)

        {


            List<HT_Stock.BOJ.clsTypejournal> clsTypejournals = new List<HT_Stock.BOJ.clsTypejournal>();
            HT_Stock.BOJ.clsTypejournal clsTypejournal = new HT_Stock.BOJ.clsTypejournal();
            clsTypejournal.clsObjetRetour = new Common.clsObjetRetour();
            clsTypejournal.clsObjetRetour.SL_CODEMESSAGE = "";
            clsTypejournal.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsTypejournal.clsObjetRetour.SL_MESSAGE = "";
            clsTypejournals.Add(clsTypejournal);
            return clsTypejournals;


        }

    }
}