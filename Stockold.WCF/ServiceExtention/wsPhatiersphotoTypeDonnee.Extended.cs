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
	public partial class wsPhatiersphoto
	{
        public List<HT_Stock.BOJ.clsPhatiersphoto> TestTypeDonnee(HT_Stock.BOJ.clsPhatiersphoto Objet)

        {


            List<HT_Stock.BOJ.clsPhatiersphoto> clsPhatiersphotos = new List<HT_Stock.BOJ.clsPhatiersphoto>();
            HT_Stock.BOJ.clsPhatiersphoto clsPhatiersphoto = new HT_Stock.BOJ.clsPhatiersphoto();
            clsPhatiersphoto.clsObjetRetour = new Common.clsObjetRetour();
            clsPhatiersphoto.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhatiersphoto.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhatiersphoto.clsObjetRetour.SL_MESSAGE = "";
            clsPhatiersphotos.Add(clsPhatiersphoto);
            return clsPhatiersphotos;


        }

    }
}