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
	public partial class wsPhaparcasutilisationtiers
	{
        public List<HT_Stock.BOJ.clsPhaparcasutilisationtiers> TestContrainte(HT_Stock.BOJ.clsPhaparcasutilisationtiers Objet)

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



        public List<HT_Stock.BOJ.clsPhaparcasutilisationtiers> TestTestContrainteListe(HT_Stock.BOJ.clsPhaparcasutilisationtiers Objet)
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
