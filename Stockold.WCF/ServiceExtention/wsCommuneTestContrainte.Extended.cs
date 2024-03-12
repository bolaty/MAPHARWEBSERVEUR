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
	public partial class wsCommune
	{
        public List<HT_Stock.BOJ.clsCommune> TestContrainte(HT_Stock.BOJ.clsCommune Objet)

        {
            List<HT_Stock.BOJ.clsCommune> clsCommunes = new List<HT_Stock.BOJ.clsCommune>();
            HT_Stock.BOJ.clsCommune clsCommune = new HT_Stock.BOJ.clsCommune();
            clsCommune.clsObjetRetour = new Common.clsObjetRetour();
            clsCommune.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCommune.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCommune.clsObjetRetour.SL_MESSAGE = "";
            clsCommunes.Add(clsCommune);
            return clsCommunes;
        }



        public List<HT_Stock.BOJ.clsCommune> TestTestContrainteListe(HT_Stock.BOJ.clsCommune Objet)
        {
            List<HT_Stock.BOJ.clsCommune> clsCommunes = new List<HT_Stock.BOJ.clsCommune>();
            HT_Stock.BOJ.clsCommune clsCommune = new HT_Stock.BOJ.clsCommune();
            clsCommune.clsObjetRetour = new Common.clsObjetRetour();
            clsCommune.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCommune.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCommune.clsObjetRetour.SL_MESSAGE = "";
            clsCommunes.Add(clsCommune);
            return clsCommunes;
        }
    }
}
