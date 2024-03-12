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
	public partial class wsPhaparnaturetypearticle
	{
        public List<HT_Stock.BOJ.clsPhaparnaturetypearticle> TestContrainte(HT_Stock.BOJ.clsPhaparnaturetypearticle Objet)

        {
            List<HT_Stock.BOJ.clsPhaparnaturetypearticle> clsPhaparnaturetypearticles = new List<HT_Stock.BOJ.clsPhaparnaturetypearticle>();
            HT_Stock.BOJ.clsPhaparnaturetypearticle clsPhaparnaturetypearticle = new HT_Stock.BOJ.clsPhaparnaturetypearticle();
            clsPhaparnaturetypearticle.clsObjetRetour = new Common.clsObjetRetour();
            clsPhaparnaturetypearticle.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhaparnaturetypearticle.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhaparnaturetypearticle.clsObjetRetour.SL_MESSAGE = "";
            clsPhaparnaturetypearticles.Add(clsPhaparnaturetypearticle);
            return clsPhaparnaturetypearticles;
        }



        public List<HT_Stock.BOJ.clsPhaparnaturetypearticle> TestTestContrainteListe(HT_Stock.BOJ.clsPhaparnaturetypearticle Objet)
        {
            List<HT_Stock.BOJ.clsPhaparnaturetypearticle> clsPhaparnaturetypearticles = new List<HT_Stock.BOJ.clsPhaparnaturetypearticle>();
            HT_Stock.BOJ.clsPhaparnaturetypearticle clsPhaparnaturetypearticle = new HT_Stock.BOJ.clsPhaparnaturetypearticle();
            clsPhaparnaturetypearticle.clsObjetRetour = new Common.clsObjetRetour();
            clsPhaparnaturetypearticle.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhaparnaturetypearticle.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhaparnaturetypearticle.clsObjetRetour.SL_MESSAGE = "";
            clsPhaparnaturetypearticles.Add(clsPhaparnaturetypearticle);
            return clsPhaparnaturetypearticles;
        }
    }
}
