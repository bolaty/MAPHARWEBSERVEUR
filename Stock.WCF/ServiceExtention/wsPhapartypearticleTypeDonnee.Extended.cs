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
	public partial class wsPhapartypearticle
	{
        public List<HT_Stock.BOJ.clsPhapartypearticle> TestTypeDonnee(HT_Stock.BOJ.clsPhapartypearticle Objet)

        {


            List<HT_Stock.BOJ.clsPhapartypearticle> clsPhapartypearticles = new List<HT_Stock.BOJ.clsPhapartypearticle>();
            HT_Stock.BOJ.clsPhapartypearticle clsPhapartypearticle = new HT_Stock.BOJ.clsPhapartypearticle();
            clsPhapartypearticle.clsObjetRetour = new Common.clsObjetRetour();
            clsPhapartypearticle.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhapartypearticle.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhapartypearticle.clsObjetRetour.SL_MESSAGE = "";
            clsPhapartypearticles.Add(clsPhapartypearticle);
            return clsPhapartypearticles;


        }

    }
}