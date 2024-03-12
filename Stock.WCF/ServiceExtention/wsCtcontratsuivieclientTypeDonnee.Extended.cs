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
	public partial class wsCtcontratsuivieclient
	{
        public List<HT_Stock.BOJ.clsCtcontratsuivieclient> TestTypeDonnee(HT_Stock.BOJ.clsCtcontratsuivieclient Objet)

        {


            List<HT_Stock.BOJ.clsCtcontratsuivieclient> clsCtcontratsuivieclients = new List<HT_Stock.BOJ.clsCtcontratsuivieclient>();
            HT_Stock.BOJ.clsCtcontratsuivieclient clsCtcontratsuivieclient = new HT_Stock.BOJ.clsCtcontratsuivieclient();
            clsCtcontratsuivieclient.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontratsuivieclient.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtcontratsuivieclient.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtcontratsuivieclient.clsObjetRetour.SL_MESSAGE = "";
            clsCtcontratsuivieclients.Add(clsCtcontratsuivieclient);
            return clsCtcontratsuivieclients;


        }

    }
}