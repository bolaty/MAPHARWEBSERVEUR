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
	public partial class wsCtparquestionnaireliaisondocument
	{
        public List<HT_Stock.BOJ.clsCtparquestionnaireliaisondocument> TestContrainte(HT_Stock.BOJ.clsCtparquestionnaireliaisondocument Objet)

        {
            List<HT_Stock.BOJ.clsCtparquestionnaireliaisondocument> clsCtparquestionnaireliaisondocuments = new List<HT_Stock.BOJ.clsCtparquestionnaireliaisondocument>();
            HT_Stock.BOJ.clsCtparquestionnaireliaisondocument clsCtparquestionnaireliaisondocument = new HT_Stock.BOJ.clsCtparquestionnaireliaisondocument();
            clsCtparquestionnaireliaisondocument.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_MESSAGE = "";
            clsCtparquestionnaireliaisondocuments.Add(clsCtparquestionnaireliaisondocument);
            return clsCtparquestionnaireliaisondocuments;
        }



        public List<HT_Stock.BOJ.clsCtparquestionnaireliaisondocument> TestTestContrainteListe(HT_Stock.BOJ.clsCtparquestionnaireliaisondocument Objet)
        {
            List<HT_Stock.BOJ.clsCtparquestionnaireliaisondocument> clsCtparquestionnaireliaisondocuments = new List<HT_Stock.BOJ.clsCtparquestionnaireliaisondocument>();
            HT_Stock.BOJ.clsCtparquestionnaireliaisondocument clsCtparquestionnaireliaisondocument = new HT_Stock.BOJ.clsCtparquestionnaireliaisondocument();
            clsCtparquestionnaireliaisondocument.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_MESSAGE = "";
            clsCtparquestionnaireliaisondocuments.Add(clsCtparquestionnaireliaisondocument);
            return clsCtparquestionnaireliaisondocuments;
        }
    }
}
