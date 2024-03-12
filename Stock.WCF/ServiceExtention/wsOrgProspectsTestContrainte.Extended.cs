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
	public partial class wsOrgProspects
	{
        public List<HT_Stock.BOJ.clsOrgProspects> TestContrainte(HT_Stock.BOJ.clsOrgProspects Objet)

        {
            List<HT_Stock.BOJ.clsOrgProspects> clsOrgProspectss = new List<HT_Stock.BOJ.clsOrgProspects>();
            HT_Stock.BOJ.clsOrgProspects clsOrgProspects = new HT_Stock.BOJ.clsOrgProspects();
            clsOrgProspects.clsObjetRetour = new Common.clsObjetRetour();
            clsOrgProspects.clsObjetRetour.SL_CODEMESSAGE = "";
            clsOrgProspects.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsOrgProspects.clsObjetRetour.SL_MESSAGE = "";
            clsOrgProspectss.Add(clsOrgProspects);
            return clsOrgProspectss;
        }

        public List<HT_Stock.BOJ.clsOrgProspects> TestChampObligatoireInsert(HT_Stock.BOJ.clsOrgProspects Objet)

        {
            List<HT_Stock.BOJ.clsOrgProspects> clsOrgProspectss = new List<HT_Stock.BOJ.clsOrgProspects>();
            HT_Stock.BOJ.clsOrgProspects clsOrgProspects = new HT_Stock.BOJ.clsOrgProspects();
            clsOrgProspects.clsObjetRetour = new Common.clsObjetRetour();
            clsOrgProspects.clsObjetRetour.SL_CODEMESSAGE = "";
            clsOrgProspects.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsOrgProspects.clsObjetRetour.SL_MESSAGE = "";
            clsOrgProspectss.Add(clsOrgProspects);
            return clsOrgProspectss;
        }
        public List<HT_Stock.BOJ.clsOrgProspects> TestChampObligatoireDelete(HT_Stock.BOJ.clsOrgProspects Objet)

        {
            List<HT_Stock.BOJ.clsOrgProspects> clsOrgProspectss = new List<HT_Stock.BOJ.clsOrgProspects>();
            HT_Stock.BOJ.clsOrgProspects clsOrgProspects = new HT_Stock.BOJ.clsOrgProspects();
            clsOrgProspects.clsObjetRetour = new Common.clsObjetRetour();
            clsOrgProspects.clsObjetRetour.SL_CODEMESSAGE = "";
            clsOrgProspects.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsOrgProspects.clsObjetRetour.SL_MESSAGE = "";
            clsOrgProspectss.Add(clsOrgProspects);
            return clsOrgProspectss;
        }
        public List<HT_Stock.BOJ.clsOrgProspects> TestTestContrainteListe(HT_Stock.BOJ.clsOrgProspects Objet)
        {
            List<HT_Stock.BOJ.clsOrgProspects> clsOrgProspectss = new List<HT_Stock.BOJ.clsOrgProspects>();
            HT_Stock.BOJ.clsOrgProspects clsOrgProspects = new HT_Stock.BOJ.clsOrgProspects();
            clsOrgProspects.clsObjetRetour = new Common.clsObjetRetour();
            clsOrgProspects.clsObjetRetour.SL_CODEMESSAGE = "";
            clsOrgProspects.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsOrgProspects.clsObjetRetour.SL_MESSAGE = "";
            clsOrgProspectss.Add(clsOrgProspects);
            return clsOrgProspectss;
        }
    }
}
