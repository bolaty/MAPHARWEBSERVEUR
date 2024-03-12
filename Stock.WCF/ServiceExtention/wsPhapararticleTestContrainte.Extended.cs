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
	public partial class wsPhapararticle
	{
        public List<HT_Stock.BOJ.clsPhapararticle> TestContrainte(HT_Stock.BOJ.clsPhapararticle Objet)

        {
            List<HT_Stock.BOJ.clsPhapararticle> clsPhapararticles = new List<HT_Stock.BOJ.clsPhapararticle>();
            HT_Stock.BOJ.clsPhapararticle clsPhapararticle = new HT_Stock.BOJ.clsPhapararticle();
            clsPhapararticle.clsObjetRetour = new Common.clsObjetRetour();
            clsPhapararticle.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhapararticle.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhapararticle.clsObjetRetour.SL_MESSAGE = "";
            clsPhapararticles.Add(clsPhapararticle);
            return clsPhapararticles;
        }



        public List<HT_Stock.BOJ.clsPhapararticle> TestTestContrainteListe(HT_Stock.BOJ.clsPhapararticle Objet)
        {
            List<HT_Stock.BOJ.clsPhapararticle> clsPhapararticles = new List<HT_Stock.BOJ.clsPhapararticle>();
            HT_Stock.BOJ.clsPhapararticle clsPhapararticle = new HT_Stock.BOJ.clsPhapararticle();
            clsPhapararticle.clsObjetRetour = new Common.clsObjetRetour();
            clsPhapararticle.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhapararticle.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhapararticle.clsObjetRetour.SL_MESSAGE = "";
            clsPhapararticles.Add(clsPhapararticle);
            return clsPhapararticles;
        }
    }
}
