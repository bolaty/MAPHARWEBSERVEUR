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
	public partial class wsCtcontratdemandecreation
	{
        public List<HT_Stock.BOJ.clsCtcontratdemandecreation> TestTypeDonnee(HT_Stock.BOJ.clsCtcontratdemandecreation Objet)

        {


            List<HT_Stock.BOJ.clsCtcontratdemandecreation> clsCtcontratdemandecreations = new List<HT_Stock.BOJ.clsCtcontratdemandecreation>();
            HT_Stock.BOJ.clsCtcontratdemandecreation clsCtcontratdemandecreation = new HT_Stock.BOJ.clsCtcontratdemandecreation();
            clsCtcontratdemandecreation.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontratdemandecreation.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtcontratdemandecreation.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtcontratdemandecreation.clsObjetRetour.SL_MESSAGE = "";
            clsCtcontratdemandecreations.Add(clsCtcontratdemandecreation);
            return clsCtcontratdemandecreations;


        }

    }
}