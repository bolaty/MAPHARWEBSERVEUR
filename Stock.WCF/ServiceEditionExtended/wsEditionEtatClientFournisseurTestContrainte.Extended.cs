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
	public partial class wsEditionEtatClientFournisseur
	{
        public List<HT_Stock.BOJ.clsEditionEtatClientFournisseur> TestContrainte(HT_Stock.BOJ.clsEditionEtatClientFournisseur Objet)

        {
            List<HT_Stock.BOJ.clsEditionEtatClientFournisseur> clsEditionEtatClientFournisseurs = new List<HT_Stock.BOJ.clsEditionEtatClientFournisseur>();
            HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur = new HT_Stock.BOJ.clsEditionEtatClientFournisseur();
            clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE = "";
            clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE = "";
            clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
            return clsEditionEtatClientFournisseurs;
        }



        public List<HT_Stock.BOJ.clsEditionEtatClientFournisseur> TestTestContrainteListe(HT_Stock.BOJ.clsEditionEtatClientFournisseur Objet)
        {
            List<HT_Stock.BOJ.clsEditionEtatClientFournisseur> clsEditionEtatClientFournisseurs = new List<HT_Stock.BOJ.clsEditionEtatClientFournisseur>();
            HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur = new HT_Stock.BOJ.clsEditionEtatClientFournisseur();
            clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE = "";
            clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE = "";
            clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
            return clsEditionEtatClientFournisseurs;
        }
    }
}