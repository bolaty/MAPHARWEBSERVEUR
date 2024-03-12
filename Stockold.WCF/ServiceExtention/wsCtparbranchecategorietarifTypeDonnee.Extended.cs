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
	public partial class wsCtparbranchecategorietarif
	{
        public List<HT_Stock.BOJ.clsCtparbranchecategorietarif> TestTypeDonnee(HT_Stock.BOJ.clsCtparbranchecategorietarif Objet)

        {


            List<HT_Stock.BOJ.clsCtparbranchecategorietarif> clsCtparbranchecategorietarifs = new List<HT_Stock.BOJ.clsCtparbranchecategorietarif>();
            HT_Stock.BOJ.clsCtparbranchecategorietarif clsCtparbranchecategorietarif = new HT_Stock.BOJ.clsCtparbranchecategorietarif();
            clsCtparbranchecategorietarif.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparbranchecategorietarif.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparbranchecategorietarif.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparbranchecategorietarif.clsObjetRetour.SL_MESSAGE = "";
            clsCtparbranchecategorietarifs.Add(clsCtparbranchecategorietarif);
            return clsCtparbranchecategorietarifs;


        }

    }
}