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
	public partial class wsPhamouvementstockfiltragedestockexpiration
	{
        public List<HT_Stock.BOJ.clsPhamouvementstockfiltragedestockexpiration> TestTypeDonnee(HT_Stock.BOJ.clsPhamouvementstockfiltragedestockexpiration Objet)

        {


            List<HT_Stock.BOJ.clsPhamouvementstockfiltragedestockexpiration> clsPhamouvementstockfiltragedestockexpirations = new List<HT_Stock.BOJ.clsPhamouvementstockfiltragedestockexpiration>();
            HT_Stock.BOJ.clsPhamouvementstockfiltragedestockexpiration clsPhamouvementstockfiltragedestockexpiration = new HT_Stock.BOJ.clsPhamouvementstockfiltragedestockexpiration();
            clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour = new Common.clsObjetRetour();
            clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour.SL_MESSAGE = "";
            clsPhamouvementstockfiltragedestockexpirations.Add(clsPhamouvementstockfiltragedestockexpiration);
            return clsPhamouvementstockfiltragedestockexpirations;


        }

    }
}