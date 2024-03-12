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
	public partial class wsCliconsultation
	{
        public List<HT_Stock.BOJ.clsCliconsultation> TestContrainte(HT_Stock.BOJ.clsCliconsultation Objet)

        {
            List<HT_Stock.BOJ.clsCliconsultation> clsCliconsultations = new List<HT_Stock.BOJ.clsCliconsultation>();
            HT_Stock.BOJ.clsCliconsultation clsCliconsultation = new HT_Stock.BOJ.clsCliconsultation();
            clsCliconsultation.clsObjetRetour = new Common.clsObjetRetour();
            clsCliconsultation.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCliconsultation.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCliconsultation.clsObjetRetour.SL_MESSAGE = "";
            clsCliconsultations.Add(clsCliconsultation);
            return clsCliconsultations;
        }



        public List<HT_Stock.BOJ.clsCliconsultation> TestTestContrainteListe(HT_Stock.BOJ.clsCliconsultation Objet)
        {
            List<HT_Stock.BOJ.clsCliconsultation> clsCliconsultations = new List<HT_Stock.BOJ.clsCliconsultation>();
            HT_Stock.BOJ.clsCliconsultation clsCliconsultation = new HT_Stock.BOJ.clsCliconsultation();
            clsCliconsultation.clsObjetRetour = new Common.clsObjetRetour();
            clsCliconsultation.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCliconsultation.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCliconsultation.clsObjetRetour.SL_MESSAGE = "";
            clsCliconsultations.Add(clsCliconsultation);
            return clsCliconsultations;
        }
    }
}
