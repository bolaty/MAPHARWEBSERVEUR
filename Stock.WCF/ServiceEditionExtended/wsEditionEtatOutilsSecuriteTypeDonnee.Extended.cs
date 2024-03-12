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
	public partial class wsEditionEtatOutilsSecurite
	{
        public List<HT_Stock.BOJ.clsEditionEtatOutilsSecurite> TestTypeDonnee(HT_Stock.BOJ.clsEditionEtatOutilsSecurite Objet)

        {


            List<HT_Stock.BOJ.clsEditionEtatOutilsSecurite> clsEditionEtatOutilsSecurites = new List<HT_Stock.BOJ.clsEditionEtatOutilsSecurite>();
            HT_Stock.BOJ.clsEditionEtatOutilsSecurite clsEditionEtatOutilsSecurite = new HT_Stock.BOJ.clsEditionEtatOutilsSecurite();
            clsEditionEtatOutilsSecurite.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatOutilsSecurite.clsObjetRetour.SL_CODEMESSAGE = "";
            clsEditionEtatOutilsSecurite.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsEditionEtatOutilsSecurite.clsObjetRetour.SL_MESSAGE = "";
            clsEditionEtatOutilsSecurites.Add(clsEditionEtatOutilsSecurite);
            return clsEditionEtatOutilsSecurites;


        }

    }
}