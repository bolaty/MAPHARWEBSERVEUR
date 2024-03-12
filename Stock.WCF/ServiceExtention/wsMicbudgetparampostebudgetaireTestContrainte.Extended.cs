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
	public partial class wsMicbudgetparampostebudgetaire
	{
        public List<HT_Stock.BOJ.clsMicbudgetparampostebudgetaire> TestContrainte(HT_Stock.BOJ.clsMicbudgetparampostebudgetaire Objet)

        {
            List<HT_Stock.BOJ.clsMicbudgetparampostebudgetaire> clsMicbudgetparampostebudgetaires = new List<HT_Stock.BOJ.clsMicbudgetparampostebudgetaire>();
            HT_Stock.BOJ.clsMicbudgetparampostebudgetaire clsMicbudgetparampostebudgetaire = new HT_Stock.BOJ.clsMicbudgetparampostebudgetaire();
            clsMicbudgetparampostebudgetaire.clsObjetRetour = new Common.clsObjetRetour();
            clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_CODEMESSAGE = "";
            clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_MESSAGE = "";
            clsMicbudgetparampostebudgetaires.Add(clsMicbudgetparampostebudgetaire);
            return clsMicbudgetparampostebudgetaires;
        }



        public List<HT_Stock.BOJ.clsMicbudgetparampostebudgetaire> TestTestContrainteListe(HT_Stock.BOJ.clsMicbudgetparampostebudgetaire Objet)
        {
            List<HT_Stock.BOJ.clsMicbudgetparampostebudgetaire> clsMicbudgetparampostebudgetaires = new List<HT_Stock.BOJ.clsMicbudgetparampostebudgetaire>();
            HT_Stock.BOJ.clsMicbudgetparampostebudgetaire clsMicbudgetparampostebudgetaire = new HT_Stock.BOJ.clsMicbudgetparampostebudgetaire();
            clsMicbudgetparampostebudgetaire.clsObjetRetour = new Common.clsObjetRetour();
            clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_CODEMESSAGE = "";
            clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_MESSAGE = "";
            clsMicbudgetparampostebudgetaires.Add(clsMicbudgetparampostebudgetaire);
            return clsMicbudgetparampostebudgetaires;
        }
    }
}
