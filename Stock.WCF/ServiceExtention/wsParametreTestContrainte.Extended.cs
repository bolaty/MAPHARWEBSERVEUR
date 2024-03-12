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
	public partial class wsParametre
	{
        public List<HT_Stock.BOJ.clsParametre> TestContrainte(HT_Stock.BOJ.clsParametre Objet)

        {
            List<HT_Stock.BOJ.clsParametre> clsParametres = new List<HT_Stock.BOJ.clsParametre>();
            HT_Stock.BOJ.clsParametre clsParametre = new HT_Stock.BOJ.clsParametre();
            clsParametre.clsObjetRetour = new Common.clsObjetRetour();
            clsParametre.clsObjetRetour.SL_CODEMESSAGE = "";
            clsParametre.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsParametre.clsObjetRetour.SL_MESSAGE = "";
            clsParametres.Add(clsParametre);
            return clsParametres;
        }



        public List<HT_Stock.BOJ.clsParametre> TestTestContrainteListe(HT_Stock.BOJ.clsParametre Objet)
        {
            List<HT_Stock.BOJ.clsParametre> clsParametres = new List<HT_Stock.BOJ.clsParametre>();
            HT_Stock.BOJ.clsParametre clsParametre = new HT_Stock.BOJ.clsParametre();
            clsParametre.clsObjetRetour = new Common.clsObjetRetour();
            clsParametre.clsObjetRetour.SL_CODEMESSAGE = "";
            clsParametre.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsParametre.clsObjetRetour.SL_MESSAGE = "";
            clsParametres.Add(clsParametre);
            return clsParametres;
        }
    }
}
