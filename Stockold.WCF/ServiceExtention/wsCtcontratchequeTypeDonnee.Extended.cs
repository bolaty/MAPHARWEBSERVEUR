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
	public partial class wsCtcontratcheque
	{
        public List<HT_Stock.BOJ.clsCtcontratcheque> TestTypeDonnee(HT_Stock.BOJ.clsCtcontratcheque Objet)

        {


            List<HT_Stock.BOJ.clsCtcontratcheque> clsCtcontratcheques = new List<HT_Stock.BOJ.clsCtcontratcheque>();
            HT_Stock.BOJ.clsCtcontratcheque clsCtcontratcheque = new HT_Stock.BOJ.clsCtcontratcheque();
            clsCtcontratcheque.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontratcheque.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtcontratcheque.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtcontratcheque.clsObjetRetour.SL_MESSAGE = "";
            clsCtcontratcheques.Add(clsCtcontratcheque);
            return clsCtcontratcheques;


        }

    }
}