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
	public partial class wsTypeoperateur
	{
        public List<HT_Stock.BOJ.clsTypeoperateur> TestContrainte(HT_Stock.BOJ.clsTypeoperateur Objet)

        {
            List<HT_Stock.BOJ.clsTypeoperateur> clsTypeoperateurs = new List<HT_Stock.BOJ.clsTypeoperateur>();
            HT_Stock.BOJ.clsTypeoperateur clsTypeoperateur = new HT_Stock.BOJ.clsTypeoperateur();
            clsTypeoperateur.clsObjetRetour = new Common.clsObjetRetour();
            clsTypeoperateur.clsObjetRetour.SL_CODEMESSAGE = "";
            clsTypeoperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsTypeoperateur.clsObjetRetour.SL_MESSAGE = "";
            clsTypeoperateurs.Add(clsTypeoperateur);
            return clsTypeoperateurs;
        }



        public List<HT_Stock.BOJ.clsTypeoperateur> TestTestContrainteListe(HT_Stock.BOJ.clsTypeoperateur Objet)
        {
            List<HT_Stock.BOJ.clsTypeoperateur> clsTypeoperateurs = new List<HT_Stock.BOJ.clsTypeoperateur>();
            HT_Stock.BOJ.clsTypeoperateur clsTypeoperateur = new HT_Stock.BOJ.clsTypeoperateur();
            clsTypeoperateur.clsObjetRetour = new Common.clsObjetRetour();
            clsTypeoperateur.clsObjetRetour.SL_CODEMESSAGE = "";
            clsTypeoperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsTypeoperateur.clsObjetRetour.SL_MESSAGE = "";
            clsTypeoperateurs.Add(clsTypeoperateur);
            return clsTypeoperateurs;
        }
    }
}
