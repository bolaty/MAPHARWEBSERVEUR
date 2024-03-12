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
	public partial class wsEditionEtatImmobilisation
	{
        public List<HT_Stock.BOJ.clsEditionEtatImmobilisation> TestContrainte(HT_Stock.BOJ.clsEditionEtatImmobilisation Objet)

        {
            List<HT_Stock.BOJ.clsEditionEtatImmobilisation> clsEditionEtatImmobilisations = new List<HT_Stock.BOJ.clsEditionEtatImmobilisation>();
            HT_Stock.BOJ.clsEditionEtatImmobilisation clsEditionEtatImmobilisation = new HT_Stock.BOJ.clsEditionEtatImmobilisation();
            clsEditionEtatImmobilisation.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatImmobilisation.clsObjetRetour.SL_CODEMESSAGE = "";
            clsEditionEtatImmobilisation.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsEditionEtatImmobilisation.clsObjetRetour.SL_MESSAGE = "";
            clsEditionEtatImmobilisations.Add(clsEditionEtatImmobilisation);
            return clsEditionEtatImmobilisations;
        }



        public List<HT_Stock.BOJ.clsEditionEtatImmobilisation> TestTestContrainteListe(HT_Stock.BOJ.clsEditionEtatImmobilisation Objet)
        {
            List<HT_Stock.BOJ.clsEditionEtatImmobilisation> clsEditionEtatImmobilisations = new List<HT_Stock.BOJ.clsEditionEtatImmobilisation>();
            HT_Stock.BOJ.clsEditionEtatImmobilisation clsEditionEtatImmobilisation = new HT_Stock.BOJ.clsEditionEtatImmobilisation();
            clsEditionEtatImmobilisation.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatImmobilisation.clsObjetRetour.SL_CODEMESSAGE = "";
            clsEditionEtatImmobilisation.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsEditionEtatImmobilisation.clsObjetRetour.SL_MESSAGE = "";
            clsEditionEtatImmobilisations.Add(clsEditionEtatImmobilisation);
            return clsEditionEtatImmobilisations;
        }
    }
}
