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
	public partial class wsSection
	{
        public List<HT_Stock.BOJ.clsPhaparsection> TestContrainte(HT_Stock.BOJ.clsPhaparsection Objet)

        {
            List<HT_Stock.BOJ.clsPhaparsection> clsPhaparsections = new List<HT_Stock.BOJ.clsPhaparsection>();
            HT_Stock.BOJ.clsPhaparsection clsPhaparsection = new HT_Stock.BOJ.clsPhaparsection();
            clsPhaparsection.clsObjetRetour = new Common.clsObjetRetour();
            clsPhaparsection.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhaparsection.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhaparsection.clsObjetRetour.SL_MESSAGE = "";
            clsPhaparsections.Add(clsPhaparsection);
            return clsPhaparsections;
        }



        public List<HT_Stock.BOJ.clsPhaparsection> TestTestContrainteListe(HT_Stock.BOJ.clsPhaparsection Objet)
        {
            List<HT_Stock.BOJ.clsPhaparsection> clsPhaparsections = new List<HT_Stock.BOJ.clsPhaparsection>();
            HT_Stock.BOJ.clsPhaparsection clsPhaparsection = new HT_Stock.BOJ.clsPhaparsection();
            clsPhaparsection.clsObjetRetour = new Common.clsObjetRetour();
            clsPhaparsection.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhaparsection.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhaparsection.clsObjetRetour.SL_MESSAGE = "";
            clsPhaparsections.Add(clsPhaparsection);
            return clsPhaparsections;
        }
    }
}
