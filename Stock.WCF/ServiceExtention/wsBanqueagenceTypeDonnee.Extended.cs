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
	public partial class wsBanqueagence
	{
        public List<HT_Stock.BOJ.clsBanqueagence> TestTypeDonnee(HT_Stock.BOJ.clsBanqueagence Objet)

        {


            List<HT_Stock.BOJ.clsBanqueagence> clsBanqueagences = new List<HT_Stock.BOJ.clsBanqueagence>();
            HT_Stock.BOJ.clsBanqueagence clsBanqueagence = new HT_Stock.BOJ.clsBanqueagence();
            clsBanqueagence.clsObjetRetour = new Common.clsObjetRetour();
            clsBanqueagence.clsObjetRetour.SL_CODEMESSAGE = "";
            clsBanqueagence.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsBanqueagence.clsObjetRetour.SL_MESSAGE = "";
            clsBanqueagences.Add(clsBanqueagence);
            return clsBanqueagences;


        }

    }
}