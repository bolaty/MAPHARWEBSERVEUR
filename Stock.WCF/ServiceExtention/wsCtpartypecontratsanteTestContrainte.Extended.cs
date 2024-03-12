using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stock.Common;
using System.Runtime.Serialization;
using Stock.BOJ;
using Stock.WSBLL;
using Stock.WSTOOLS;

namespace Stock.WCF
{
	public partial class wsCtpartypecontratsante
	{
        public List<HT_Stock.BOJ.clsCtpartypecontratsante> TestContrainte(HT_Stock.BOJ.clsCtpartypecontratsante Objet)

        {
            List<HT_Stock.BOJ.clsCtpartypecontratsante> clsCtpartypecontratsantes = new List<HT_Stock.BOJ.clsCtpartypecontratsante>();
            HT_Stock.BOJ.clsCtpartypecontratsante clsCtpartypecontratsante = new HT_Stock.BOJ.clsCtpartypecontratsante();
            clsCtpartypecontratsante.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpartypecontratsante.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtpartypecontratsante.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtpartypecontratsante.clsObjetRetour.SL_MESSAGE = "";
            clsCtpartypecontratsantes.Add(clsCtpartypecontratsante);
            return clsCtpartypecontratsantes;
        }



        public List<HT_Stock.BOJ.clsCtpartypecontratsante> TestTestContrainteListe(HT_Stock.BOJ.clsCtpartypecontratsante Objet)
        {
            List<HT_Stock.BOJ.clsCtpartypecontratsante> clsCtpartypecontratsantes = new List<HT_Stock.BOJ.clsCtpartypecontratsante>();
            HT_Stock.BOJ.clsCtpartypecontratsante clsCtpartypecontratsante = new HT_Stock.BOJ.clsCtpartypecontratsante();
            clsCtpartypecontratsante.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpartypecontratsante.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtpartypecontratsante.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtpartypecontratsante.clsObjetRetour.SL_MESSAGE = "";
            clsCtpartypecontratsantes.Add(clsCtpartypecontratsante);
            return clsCtpartypecontratsantes;
        }
    }
}
