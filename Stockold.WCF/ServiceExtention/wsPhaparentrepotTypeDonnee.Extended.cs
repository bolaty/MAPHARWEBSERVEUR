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
	public partial class wsPhaparentrepot
	{
        public List<HT_Stock.BOJ.clsPhaparentrepot> TestTypeDonnee(HT_Stock.BOJ.clsPhaparentrepot Objet)

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