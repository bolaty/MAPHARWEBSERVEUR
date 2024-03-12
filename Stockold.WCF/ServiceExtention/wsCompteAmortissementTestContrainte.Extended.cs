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
	public partial class wsCompteAmortissement
	{
        public List<HT_Stock.BOJ.clsBienimmobilisefamille> TestContrainte(HT_Stock.BOJ.clsBienimmobilisefamille Objet)

        {
            List<HT_Stock.BOJ.clsBienimmobilisefamille> clsBienimmobilisefamilles = new List<HT_Stock.BOJ.clsBienimmobilisefamille>();
            HT_Stock.BOJ.clsBienimmobilisefamille clsBienimmobilisefamille = new HT_Stock.BOJ.clsBienimmobilisefamille();
            clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
            clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = "";
            clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = "";
            clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
            return clsBienimmobilisefamilles;
        }



        public List<HT_Stock.BOJ.clsBienimmobilisefamille> TestTestContrainteListe(HT_Stock.BOJ.clsBienimmobilisefamille Objet)
        {
            List<HT_Stock.BOJ.clsBienimmobilisefamille> clsBienimmobilisefamilles = new List<HT_Stock.BOJ.clsBienimmobilisefamille>();
            HT_Stock.BOJ.clsBienimmobilisefamille clsBienimmobilisefamille = new HT_Stock.BOJ.clsBienimmobilisefamille();
            clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
            clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = "";
            clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = "";
            clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
            return clsBienimmobilisefamilles;
        }
    }
}
