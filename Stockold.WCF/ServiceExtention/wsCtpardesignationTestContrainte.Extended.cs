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
	public partial class wsCtpardesignation
	{
        public List<HT_Stock.BOJ.clsCtpardesignation> TestContrainte(HT_Stock.BOJ.clsCtpardesignation Objet)

        {
            List<HT_Stock.BOJ.clsCtpardesignation> clsCtpardesignations = new List<HT_Stock.BOJ.clsCtpardesignation>();
            HT_Stock.BOJ.clsCtpardesignation clsCtpardesignation = new HT_Stock.BOJ.clsCtpardesignation();
            clsCtpardesignation.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpardesignation.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtpardesignation.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtpardesignation.clsObjetRetour.SL_MESSAGE = "";
            clsCtpardesignations.Add(clsCtpardesignation);
            return clsCtpardesignations;
        }



        public List<HT_Stock.BOJ.clsCtpardesignation> TestTestContrainteListe(HT_Stock.BOJ.clsCtpardesignation Objet)
        {
            List<HT_Stock.BOJ.clsCtpardesignation> clsCtpardesignations = new List<HT_Stock.BOJ.clsCtpardesignation>();
            HT_Stock.BOJ.clsCtpardesignation clsCtpardesignation = new HT_Stock.BOJ.clsCtpardesignation();
            clsCtpardesignation.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpardesignation.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtpardesignation.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtpardesignation.clsObjetRetour.SL_MESSAGE = "";
            clsCtpardesignations.Add(clsCtpardesignation);
            return clsCtpardesignations;
        }
    }
}
