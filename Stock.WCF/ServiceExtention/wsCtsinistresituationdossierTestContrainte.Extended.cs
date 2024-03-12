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
	public partial class wsCtsinistresituationdossier
	{
        public List<HT_Stock.BOJ.clsCtsinistresituationdossier> TestContrainte(HT_Stock.BOJ.clsCtsinistresituationdossier Objet)

        {
            List<HT_Stock.BOJ.clsCtsinistresituationdossier> clsCtsinistresituationdossiers = new List<HT_Stock.BOJ.clsCtsinistresituationdossier>();
            HT_Stock.BOJ.clsCtsinistresituationdossier clsCtsinistresituationdossier = new HT_Stock.BOJ.clsCtsinistresituationdossier();
            clsCtsinistresituationdossier.clsObjetRetour = new Common.clsObjetRetour();
            clsCtsinistresituationdossier.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtsinistresituationdossier.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtsinistresituationdossier.clsObjetRetour.SL_MESSAGE = "";
            clsCtsinistresituationdossiers.Add(clsCtsinistresituationdossier);
            return clsCtsinistresituationdossiers;
        }



        public List<HT_Stock.BOJ.clsCtsinistresituationdossier> TestTestContrainteListe(HT_Stock.BOJ.clsCtsinistresituationdossier Objet)
        {
            List<HT_Stock.BOJ.clsCtsinistresituationdossier> clsCtsinistresituationdossiers = new List<HT_Stock.BOJ.clsCtsinistresituationdossier>();
            HT_Stock.BOJ.clsCtsinistresituationdossier clsCtsinistresituationdossier = new HT_Stock.BOJ.clsCtsinistresituationdossier();
            clsCtsinistresituationdossier.clsObjetRetour = new Common.clsObjetRetour();
            clsCtsinistresituationdossier.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtsinistresituationdossier.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtsinistresituationdossier.clsObjetRetour.SL_MESSAGE = "";
            clsCtsinistresituationdossiers.Add(clsCtsinistresituationdossier);
            return clsCtsinistresituationdossiers;
        }
    }
}
