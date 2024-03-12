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
	public partial class wsPhaparentrepot
	{
        public List<HT_Stock.BOJ.clsPhaparentrepot> TestContrainte(HT_Stock.BOJ.clsPhaparentrepot Objet)

        {
            List<HT_Stock.BOJ.clsPhaparentrepot> clsPhaparentrepots = new List<HT_Stock.BOJ.clsPhaparentrepot>();
            HT_Stock.BOJ.clsPhaparentrepot clsPhaparentrepot = new HT_Stock.BOJ.clsPhaparentrepot();
            clsPhaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
            clsPhaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhaparentrepot.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhaparentrepot.clsObjetRetour.SL_MESSAGE = "";
            clsPhaparentrepots.Add(clsPhaparentrepot);
            return clsPhaparentrepots;
        }



        public List<HT_Stock.BOJ.clsPhaparentrepot> TestTestContrainteListe(HT_Stock.BOJ.clsPhaparentrepot Objet)
        {
            List<HT_Stock.BOJ.clsPhaparentrepot> clsPhaparentrepots = new List<HT_Stock.BOJ.clsPhaparentrepot>();
            HT_Stock.BOJ.clsPhaparentrepot clsPhaparentrepot = new HT_Stock.BOJ.clsPhaparentrepot();
            clsPhaparentrepot.clsObjetRetour = new Common.clsObjetRetour();
            clsPhaparentrepot.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhaparentrepot.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhaparentrepot.clsObjetRetour.SL_MESSAGE = "";
            clsPhaparentrepots.Add(clsPhaparentrepot);
            return clsPhaparentrepots;
        }
    }
}
