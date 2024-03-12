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
	public partial class wsPhapartypetiers
	{
        public List<HT_Stock.BOJ.clsPhapartypetiers> TestContrainte(HT_Stock.BOJ.clsPhapartypetiers Objet)

        {
            List<HT_Stock.BOJ.clsPhapartypetiers> clsPhapartypetierss = new List<HT_Stock.BOJ.clsPhapartypetiers>();
            HT_Stock.BOJ.clsPhapartypetiers clsPhapartypetiers = new HT_Stock.BOJ.clsPhapartypetiers();
            clsPhapartypetiers.clsObjetRetour = new Common.clsObjetRetour();
            clsPhapartypetiers.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhapartypetiers.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhapartypetiers.clsObjetRetour.SL_MESSAGE = "";
            clsPhapartypetierss.Add(clsPhapartypetiers);
            return clsPhapartypetierss;
        }



        public List<HT_Stock.BOJ.clsPhapartypetiers> TestTestContrainteListe(HT_Stock.BOJ.clsPhapartypetiers Objet)
        {
            List<HT_Stock.BOJ.clsPhapartypetiers> clsPhapartypetierss = new List<HT_Stock.BOJ.clsPhapartypetiers>();
            HT_Stock.BOJ.clsPhapartypetiers clsPhapartypetiers = new HT_Stock.BOJ.clsPhapartypetiers();
            clsPhapartypetiers.clsObjetRetour = new Common.clsObjetRetour();
            clsPhapartypetiers.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhapartypetiers.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhapartypetiers.clsObjetRetour.SL_MESSAGE = "";
            clsPhapartypetierss.Add(clsPhapartypetiers);
            return clsPhapartypetierss;
        }
    }
}
