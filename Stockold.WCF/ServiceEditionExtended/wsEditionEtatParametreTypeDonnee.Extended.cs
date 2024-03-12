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
	public partial class wsEditionEtatParametre
	{
        public List<HT_Stock.BOJ.clsEditionEtatParametre> TestTypeDonnee(HT_Stock.BOJ.clsEditionEtatParametre Objet)

        {


            List<HT_Stock.BOJ.clsEditionEtatParametre> clsEditionEtatParametres = new List<HT_Stock.BOJ.clsEditionEtatParametre>();
            HT_Stock.BOJ.clsEditionEtatParametre clsEditionEtatParametre = new HT_Stock.BOJ.clsEditionEtatParametre();
            clsEditionEtatParametre.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatParametre.clsObjetRetour.SL_CODEMESSAGE = "";
            clsEditionEtatParametre.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsEditionEtatParametre.clsObjetRetour.SL_MESSAGE = "";
            clsEditionEtatParametres.Add(clsEditionEtatParametre);
            return clsEditionEtatParametres;


        }

    }
}