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
	public partial class wsCtcontratquestionnaire
	{
        public List<HT_Stock.BOJ.clsCtcontratquestionnaire> TestContrainte(HT_Stock.BOJ.clsCtcontratquestionnaire Objet)

        {
            List<HT_Stock.BOJ.clsCtcontratquestionnaire> clsCtcontratquestionnaires = new List<HT_Stock.BOJ.clsCtcontratquestionnaire>();
            HT_Stock.BOJ.clsCtcontratquestionnaire clsCtcontratquestionnaire = new HT_Stock.BOJ.clsCtcontratquestionnaire();
            clsCtcontratquestionnaire.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontratquestionnaire.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtcontratquestionnaire.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtcontratquestionnaire.clsObjetRetour.SL_MESSAGE = "";
            clsCtcontratquestionnaires.Add(clsCtcontratquestionnaire);
            return clsCtcontratquestionnaires;
        }



        public List<HT_Stock.BOJ.clsCtcontratquestionnaire> TestTestContrainteListe(HT_Stock.BOJ.clsCtcontratquestionnaire Objet)
        {
            List<HT_Stock.BOJ.clsCtcontratquestionnaire> clsCtcontratquestionnaires = new List<HT_Stock.BOJ.clsCtcontratquestionnaire>();
            HT_Stock.BOJ.clsCtcontratquestionnaire clsCtcontratquestionnaire = new HT_Stock.BOJ.clsCtcontratquestionnaire();
            clsCtcontratquestionnaire.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontratquestionnaire.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtcontratquestionnaire.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtcontratquestionnaire.clsObjetRetour.SL_MESSAGE = "";
            clsCtcontratquestionnaires.Add(clsCtcontratquestionnaire);
            return clsCtcontratquestionnaires;
        }
    }
}
