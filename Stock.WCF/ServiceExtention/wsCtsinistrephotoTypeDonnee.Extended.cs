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
	public partial class wsCtsinistrephoto
	{
        public List<HT_Stock.BOJ.clsCtsinistrephoto> TestTypeDonnee(HT_Stock.BOJ.clsCtsinistrephoto Objet)

        {


            List<HT_Stock.BOJ.clsCtsinistrephoto> clsCtsinistrephotos = new List<HT_Stock.BOJ.clsCtsinistrephoto>();
            HT_Stock.BOJ.clsCtsinistrephoto clsCtsinistrephoto = new HT_Stock.BOJ.clsCtsinistrephoto();
            clsCtsinistrephoto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtsinistrephoto.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtsinistrephoto.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtsinistrephoto.clsObjetRetour.SL_MESSAGE = "";
            clsCtsinistrephotos.Add(clsCtsinistrephoto);
            return clsCtsinistrephotos;


        }

    }
}