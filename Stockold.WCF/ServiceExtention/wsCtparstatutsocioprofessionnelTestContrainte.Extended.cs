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
	public partial class wsCtparstatutsocioprofessionnel
	{
        public List<HT_Stock.BOJ.clsCtparstatutsocioprofessionnel> TestContrainte(HT_Stock.BOJ.clsCtparstatutsocioprofessionnel Objet)

        {
            List<HT_Stock.BOJ.clsCtparstatutsocioprofessionnel> clsCtparstatutsocioprofessionnels = new List<HT_Stock.BOJ.clsCtparstatutsocioprofessionnel>();
            HT_Stock.BOJ.clsCtparstatutsocioprofessionnel clsCtparstatutsocioprofessionnel = new HT_Stock.BOJ.clsCtparstatutsocioprofessionnel();
            clsCtparstatutsocioprofessionnel.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_MESSAGE = "";
            clsCtparstatutsocioprofessionnels.Add(clsCtparstatutsocioprofessionnel);
            return clsCtparstatutsocioprofessionnels;
        }



        public List<HT_Stock.BOJ.clsCtparstatutsocioprofessionnel> TestTestContrainteListe(HT_Stock.BOJ.clsCtparstatutsocioprofessionnel Objet)
        {
            List<HT_Stock.BOJ.clsCtparstatutsocioprofessionnel> clsCtparstatutsocioprofessionnels = new List<HT_Stock.BOJ.clsCtparstatutsocioprofessionnel>();
            HT_Stock.BOJ.clsCtparstatutsocioprofessionnel clsCtparstatutsocioprofessionnel = new HT_Stock.BOJ.clsCtparstatutsocioprofessionnel();
            clsCtparstatutsocioprofessionnel.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_MESSAGE = "";
            clsCtparstatutsocioprofessionnels.Add(clsCtparstatutsocioprofessionnel);
            return clsCtparstatutsocioprofessionnels;
        }
    }
}
