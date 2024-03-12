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
	public partial class wsPhamouvementstockfiltragedestock
	{
        public List<HT_Stock.BOJ.clsPhamouvementstockfiltragedestock> TestContrainte(HT_Stock.BOJ.clsPhamouvementstockfiltragedestock Objet)

        {
            List<HT_Stock.BOJ.clsPhamouvementstockfiltragedestock> clsPhamouvementstockfiltragedestocks = new List<HT_Stock.BOJ.clsPhamouvementstockfiltragedestock>();
            HT_Stock.BOJ.clsPhamouvementstockfiltragedestock clsPhamouvementstockfiltragedestock = new HT_Stock.BOJ.clsPhamouvementstockfiltragedestock();
            clsPhamouvementstockfiltragedestock.clsObjetRetour = new Common.clsObjetRetour();
            clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_MESSAGE = "";
            clsPhamouvementstockfiltragedestocks.Add(clsPhamouvementstockfiltragedestock);
            return clsPhamouvementstockfiltragedestocks;
        }



        public List<HT_Stock.BOJ.clsPhamouvementstockfiltragedestock> TestTestContrainteListe(HT_Stock.BOJ.clsPhamouvementstockfiltragedestock Objet)
        {
            List<HT_Stock.BOJ.clsPhamouvementstockfiltragedestock> clsPhamouvementstockfiltragedestocks = new List<HT_Stock.BOJ.clsPhamouvementstockfiltragedestock>();
            HT_Stock.BOJ.clsPhamouvementstockfiltragedestock clsPhamouvementstockfiltragedestock = new HT_Stock.BOJ.clsPhamouvementstockfiltragedestock();
            clsPhamouvementstockfiltragedestock.clsObjetRetour = new Common.clsObjetRetour();
            clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhamouvementstockfiltragedestock.clsObjetRetour.SL_MESSAGE = "";
            clsPhamouvementstockfiltragedestocks.Add(clsPhamouvementstockfiltragedestock);
            return clsPhamouvementstockfiltragedestocks;
        }
    }
}
