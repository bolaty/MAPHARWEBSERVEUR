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
	public partial class wsOperateur
	{
        public List<HT_Stock.BOJ.clsOperateur> TestContrainte(HT_Stock.BOJ.clsOperateur Objet)

        {
            List<HT_Stock.BOJ.clsOperateur> clsOperateurs = new List<HT_Stock.BOJ.clsOperateur>();
            HT_Stock.BOJ.clsOperateur clsOperateur = new HT_Stock.BOJ.clsOperateur();
            clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
            clsOperateur.clsObjetRetour.SL_CODEMESSAGE = "";
            clsOperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsOperateur.clsObjetRetour.SL_MESSAGE = "";
            clsOperateurs.Add(clsOperateur);
            return clsOperateurs;
        }



        public List<HT_Stock.BOJ.clsOperateur> TestTestContrainteListe(HT_Stock.BOJ.clsOperateur Objet)
        {
            List<HT_Stock.BOJ.clsOperateur> clsOperateurs = new List<HT_Stock.BOJ.clsOperateur>();
            HT_Stock.BOJ.clsOperateur clsOperateur = new HT_Stock.BOJ.clsOperateur();
            clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
            clsOperateur.clsObjetRetour.SL_CODEMESSAGE = "";
            clsOperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsOperateur.clsObjetRetour.SL_MESSAGE = "";
            clsOperateurs.Add(clsOperateur);
            return clsOperateurs;
        }
    }
}
