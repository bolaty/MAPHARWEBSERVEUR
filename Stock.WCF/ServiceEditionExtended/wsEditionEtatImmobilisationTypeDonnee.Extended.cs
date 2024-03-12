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
	public partial class wsEditionEtatImmobilisation
	{
        public List<HT_Stock.BOJ.clsEditionEtatImmobilisation> TestTypeDonnee(HT_Stock.BOJ.clsEditionEtatImmobilisation Objet)

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