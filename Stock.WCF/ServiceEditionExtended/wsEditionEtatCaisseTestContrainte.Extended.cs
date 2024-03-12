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
	public partial class wsEditionEtatCaisse
	{
        public List<HT_Stock.BOJ.clsEditionEtatCaisse> TestContrainte(HT_Stock.BOJ.clsEditionEtatCaisse Objet)

        {
            List<HT_Stock.BOJ.clsEditionEtatCaisse> clsEditionEtatCaisses = new List<HT_Stock.BOJ.clsEditionEtatCaisse>();
            HT_Stock.BOJ.clsEditionEtatCaisse clsEditionEtatCaisse = new HT_Stock.BOJ.clsEditionEtatCaisse();
            clsEditionEtatCaisse.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatCaisse.clsObjetRetour.SL_CODEMESSAGE = "";
            clsEditionEtatCaisse.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsEditionEtatCaisse.clsObjetRetour.SL_MESSAGE = "";
            clsEditionEtatCaisses.Add(clsEditionEtatCaisse);
            return clsEditionEtatCaisses;
        }



        public List<HT_Stock.BOJ.clsEditionEtatCaisse> TestTestContrainteListe(HT_Stock.BOJ.clsEditionEtatCaisse Objet)
        {
            List<HT_Stock.BOJ.clsEditionEtatCaisse> clsEditionEtatCaisses = new List<HT_Stock.BOJ.clsEditionEtatCaisse>();
            HT_Stock.BOJ.clsEditionEtatCaisse clsEditionEtatCaisse = new HT_Stock.BOJ.clsEditionEtatCaisse();
            clsEditionEtatCaisse.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatCaisse.clsObjetRetour.SL_CODEMESSAGE = "";
            clsEditionEtatCaisse.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsEditionEtatCaisse.clsObjetRetour.SL_MESSAGE = "";
            clsEditionEtatCaisses.Add(clsEditionEtatCaisse);
            return clsEditionEtatCaisses;
        }
    }
}
