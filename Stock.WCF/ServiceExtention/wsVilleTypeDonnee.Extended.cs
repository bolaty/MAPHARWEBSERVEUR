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
	public partial class wsVille
	{
        public List<HT_Stock.BOJ.clsVille> TestTypeDonnee(HT_Stock.BOJ.clsVille Objet)

        {


            List<HT_Stock.BOJ.clsVille> clsVilles = new List<HT_Stock.BOJ.clsVille>();
            HT_Stock.BOJ.clsVille clsVille = new HT_Stock.BOJ.clsVille();
            clsVille.clsObjetRetour = new Common.clsObjetRetour();
            clsVille.clsObjetRetour.SL_CODEMESSAGE = "";
            clsVille.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsVille.clsObjetRetour.SL_MESSAGE = "";
            clsVilles.Add(clsVille);
            return clsVilles;


        }

    }
}