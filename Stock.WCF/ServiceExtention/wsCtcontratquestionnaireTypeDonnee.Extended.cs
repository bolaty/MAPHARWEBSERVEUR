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
	public partial class wsCtcontratquestionnaire
	{
        public List<HT_Stock.BOJ.clsCtcontratquestionnaire> TestTypeDonnee(HT_Stock.BOJ.clsCtcontratquestionnaire Objet)

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