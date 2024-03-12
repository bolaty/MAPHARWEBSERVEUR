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
	public partial class wsPhaparcasutilisationtiers
	{
        public List<HT_Stock.BOJ.clsPhaparcasutilisationtiers> TestTypeDonnee(HT_Stock.BOJ.clsPhaparcasutilisationtiers Objet)

        {


            List<HT_Stock.BOJ.clsPhaparcasutilisationtiers> clsPhaparcasutilisationtierss = new List<HT_Stock.BOJ.clsPhaparcasutilisationtiers>();
            HT_Stock.BOJ.clsPhaparcasutilisationtiers clsPhaparcasutilisationtiers = new HT_Stock.BOJ.clsPhaparcasutilisationtiers();
            clsPhaparcasutilisationtiers.clsObjetRetour = new Common.clsObjetRetour();
            clsPhaparcasutilisationtiers.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhaparcasutilisationtiers.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhaparcasutilisationtiers.clsObjetRetour.SL_MESSAGE = "";
            clsPhaparcasutilisationtierss.Add(clsPhaparcasutilisationtiers);
            return clsPhaparcasutilisationtierss;


        }

    }
}