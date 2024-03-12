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
	public partial class wsCtcontratchequephoto
	{
        public List<HT_Stock.BOJ.clsCtcontratchequephoto> TestContrainte(HT_Stock.BOJ.clsCtcontratchequephoto Objet)

        {
            List<HT_Stock.BOJ.clsCtcontratchequephoto> clsCtcontratchequephotos = new List<HT_Stock.BOJ.clsCtcontratchequephoto>();
            HT_Stock.BOJ.clsCtcontratchequephoto clsCtcontratchequephoto = new HT_Stock.BOJ.clsCtcontratchequephoto();
            clsCtcontratchequephoto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontratchequephoto.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtcontratchequephoto.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtcontratchequephoto.clsObjetRetour.SL_MESSAGE = "";
            clsCtcontratchequephotos.Add(clsCtcontratchequephoto);
            return clsCtcontratchequephotos;
        }



        public List<HT_Stock.BOJ.clsCtcontratchequephoto> TestTestContrainteListe(HT_Stock.BOJ.clsCtcontratchequephoto Objet)
        {
            List<HT_Stock.BOJ.clsCtcontratchequephoto> clsCtcontratchequephotos = new List<HT_Stock.BOJ.clsCtcontratchequephoto>();
            HT_Stock.BOJ.clsCtcontratchequephoto clsCtcontratchequephoto = new HT_Stock.BOJ.clsCtcontratchequephoto();
            clsCtcontratchequephoto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontratchequephoto.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtcontratchequephoto.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtcontratchequephoto.clsObjetRetour.SL_MESSAGE = "";
            clsCtcontratchequephotos.Add(clsCtcontratchequephoto);
            return clsCtcontratchequephotos;
        }
    }
}
