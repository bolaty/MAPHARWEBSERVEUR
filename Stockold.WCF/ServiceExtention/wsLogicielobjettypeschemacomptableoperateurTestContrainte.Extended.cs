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
	public partial class wsLogicielobjettypeschemacomptableoperateur
	{
        public List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur> TestContrainte(HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur Objet)

        {
            List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur> clsLogicielobjettypeschemacomptableoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur>();
            HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur clsLogicielobjettypeschemacomptableoperateur = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur();
            clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour = new Common.clsObjetRetour();
            clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_CODEMESSAGE = "";
            clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_MESSAGE = "";
            clsLogicielobjettypeschemacomptableoperateurs.Add(clsLogicielobjettypeschemacomptableoperateur);
            return clsLogicielobjettypeschemacomptableoperateurs;
        }



        public List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur> TestTestContrainteListe(HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur Objet)
        {
            List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur> clsLogicielobjettypeschemacomptableoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur>();
            HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur clsLogicielobjettypeschemacomptableoperateur = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur();
            clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour = new Common.clsObjetRetour();
            clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_CODEMESSAGE = "";
            clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_MESSAGE = "";
            clsLogicielobjettypeschemacomptableoperateurs.Add(clsLogicielobjettypeschemacomptableoperateur);
            return clsLogicielobjettypeschemacomptableoperateurs;
        }
    }
}
