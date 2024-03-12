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
	public partial class wsCtsinistrechequephoto
	{
        public List<HT_Stock.BOJ.clsCtsinistrechequephoto> TestTypeDonnee(HT_Stock.BOJ.clsCtsinistrechequephoto Objet)

        {


            List<HT_Stock.BOJ.clsCtsinistrechequephoto> clsCtsinistrechequephotos = new List<HT_Stock.BOJ.clsCtsinistrechequephoto>();
            HT_Stock.BOJ.clsCtsinistrechequephoto clsCtsinistrechequephoto = new HT_Stock.BOJ.clsCtsinistrechequephoto();
            clsCtsinistrechequephoto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtsinistrechequephoto.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtsinistrechequephoto.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtsinistrechequephoto.clsObjetRetour.SL_MESSAGE = "";
            clsCtsinistrechequephotos.Add(clsCtsinistrechequephoto);
            return clsCtsinistrechequephotos;


        }

    }
}