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
	public partial class wsProfession
	{
        public List<HT_Stock.BOJ.clsProfession> TestContrainte(HT_Stock.BOJ.clsProfession Objet)

        {
            List<HT_Stock.BOJ.clsProfession> clsProfessions = new List<HT_Stock.BOJ.clsProfession>();
            HT_Stock.BOJ.clsProfession clsProfession = new HT_Stock.BOJ.clsProfession();
            clsProfession.clsObjetRetour = new Common.clsObjetRetour();
            clsProfession.clsObjetRetour.SL_CODEMESSAGE = "";
            clsProfession.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsProfession.clsObjetRetour.SL_MESSAGE = "";
            clsProfessions.Add(clsProfession);
            return clsProfessions;
        }



        public List<HT_Stock.BOJ.clsProfession> TestTestContrainteListe(HT_Stock.BOJ.clsProfession Objet)
        {
            List<HT_Stock.BOJ.clsProfession> clsProfessions = new List<HT_Stock.BOJ.clsProfession>();
            HT_Stock.BOJ.clsProfession clsProfession = new HT_Stock.BOJ.clsProfession();
            clsProfession.clsObjetRetour = new Common.clsObjetRetour();
            clsProfession.clsObjetRetour.SL_CODEMESSAGE = "";
            clsProfession.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsProfession.clsObjetRetour.SL_MESSAGE = "";
            clsProfessions.Add(clsProfession);
            return clsProfessions;
        }
    }
}