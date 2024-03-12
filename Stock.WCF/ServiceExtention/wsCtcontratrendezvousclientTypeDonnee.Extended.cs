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
	public partial class wsCtcontratrendezvousclient
	{
        public List<HT_Stock.BOJ.clsCtcontratrendezvousclient> TestTypeDonnee(HT_Stock.BOJ.clsCtcontratrendezvousclient Objet)

        {


            List<HT_Stock.BOJ.clsCtcontratrendezvousclient> clsCtcontratrendezvousclients = new List<HT_Stock.BOJ.clsCtcontratrendezvousclient>();
            HT_Stock.BOJ.clsCtcontratrendezvousclient clsCtcontratrendezvousclient = new HT_Stock.BOJ.clsCtcontratrendezvousclient();
            clsCtcontratrendezvousclient.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontratrendezvousclient.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtcontratrendezvousclient.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtcontratrendezvousclient.clsObjetRetour.SL_MESSAGE = "";
            clsCtcontratrendezvousclients.Add(clsCtcontratrendezvousclient);
            return clsCtcontratrendezvousclients;


        }

    }
}