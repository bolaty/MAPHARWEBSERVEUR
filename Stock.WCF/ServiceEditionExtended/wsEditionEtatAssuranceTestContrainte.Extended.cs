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
	public partial class wsEditionEtatAssurance
	{
        public List<HT_Stock.BOJ.clsEditionEtatAssurance> TestContrainte(HT_Stock.BOJ.clsEditionEtatAssurance Objet)

        {
            List<HT_Stock.BOJ.clsEditionEtatAssurance> clsEditionEtatAssurances = new List<HT_Stock.BOJ.clsEditionEtatAssurance>();
            HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance = new HT_Stock.BOJ.clsEditionEtatAssurance();
            clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = "";
            clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = "";
            clsEditionEtatAssurances.Add(clsEditionEtatAssurance);
            return clsEditionEtatAssurances;
        }



        public List<HT_Stock.BOJ.clsEditionEtatAssurance> TestTestContrainteListe(HT_Stock.BOJ.clsEditionEtatAssurance Objet)
        {
            List<HT_Stock.BOJ.clsEditionEtatAssurance> clsEditionEtatAssurances = new List<HT_Stock.BOJ.clsEditionEtatAssurance>();
            HT_Stock.BOJ.clsEditionEtatAssurance clsEditionEtatAssurance = new HT_Stock.BOJ.clsEditionEtatAssurance();
            clsEditionEtatAssurance.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatAssurance.clsObjetRetour.SL_CODEMESSAGE = "";
            clsEditionEtatAssurance.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsEditionEtatAssurance.clsObjetRetour.SL_MESSAGE = "";
            clsEditionEtatAssurances.Add(clsEditionEtatAssurance);
            return clsEditionEtatAssurances;
        }
    }
}
