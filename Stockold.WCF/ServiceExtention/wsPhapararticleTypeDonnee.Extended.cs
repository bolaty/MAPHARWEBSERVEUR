using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Stock.BOJ;
using Stock.WSBLL;
using Stock.WSTOOLS;
using Stock.Common;
namespace Stock.WCF
{
	public partial class wsPhapararticle
	{
        public List<HT_Stock.BOJ.clsPhapararticle> TestTypeDonnee(HT_Stock.BOJ.clsPhapararticle Objet)

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