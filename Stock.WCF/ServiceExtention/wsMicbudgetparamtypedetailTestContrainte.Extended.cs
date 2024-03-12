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
	public partial class wsMicbudgetparamtypedetail
	{
        public List<HT_Stock.BOJ.clsMicbudgetparamtypedetail> TestContrainte(HT_Stock.BOJ.clsMicbudgetparamtypedetail Objet)

        {
            List<HT_Stock.BOJ.clsMicbudgetparamtypedetail> clsMicbudgetparamtypedetails = new List<HT_Stock.BOJ.clsMicbudgetparamtypedetail>();
            HT_Stock.BOJ.clsMicbudgetparamtypedetail clsMicbudgetparamtypedetail = new HT_Stock.BOJ.clsMicbudgetparamtypedetail();
            clsMicbudgetparamtypedetail.clsObjetRetour = new Common.clsObjetRetour();
            clsMicbudgetparamtypedetail.clsObjetRetour.SL_CODEMESSAGE = "";
            clsMicbudgetparamtypedetail.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsMicbudgetparamtypedetail.clsObjetRetour.SL_MESSAGE = "";
            clsMicbudgetparamtypedetails.Add(clsMicbudgetparamtypedetail);
            return clsMicbudgetparamtypedetails;
        }

        public List<HT_Stock.BOJ.clsMicbudgetparamtypedetail> TestTestContrainteListe(HT_Stock.BOJ.clsMicbudgetparamtypedetail Objet)
        {
            List<HT_Stock.BOJ.clsMicbudgetparamtypedetail> clsMicbudgetparamtypes = new List<HT_Stock.BOJ.clsMicbudgetparamtypedetail>();
            HT_Stock.BOJ.clsMicbudgetparamtypedetail clsMicbudgetparamtypedetail = new HT_Stock.BOJ.clsMicbudgetparamtypedetail();
            clsMicbudgetparamtypedetail.clsObjetRetour = new Common.clsObjetRetour();
            clsMicbudgetparamtypedetail.clsObjetRetour.SL_CODEMESSAGE = "";
            clsMicbudgetparamtypedetail.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsMicbudgetparamtypedetail.clsObjetRetour.SL_MESSAGE = "";
            clsMicbudgetparamtypes.Add(clsMicbudgetparamtypedetail);
            return clsMicbudgetparamtypes;
        }
        public List<HT_Stock.BOJ.clsMicbudgetparamtypedetail> TestChampObligatoireUpdate(HT_Stock.BOJ.clsMicbudgetparamtypedetail Objet)
        {
            List<HT_Stock.BOJ.clsMicbudgetparamtypedetail> clsMicbudgetparamtypes = new List<HT_Stock.BOJ.clsMicbudgetparamtypedetail>();
            HT_Stock.BOJ.clsMicbudgetparamtypedetail clsMicbudgetparamtypedetail = new HT_Stock.BOJ.clsMicbudgetparamtypedetail();
            clsMicbudgetparamtypedetail.clsObjetRetour = new Common.clsObjetRetour();
            clsMicbudgetparamtypedetail.clsObjetRetour.SL_CODEMESSAGE = "";
            clsMicbudgetparamtypedetail.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsMicbudgetparamtypedetail.clsObjetRetour.SL_MESSAGE = "";
            clsMicbudgetparamtypes.Add(clsMicbudgetparamtypedetail);
            return clsMicbudgetparamtypes;
        }
        public List<HT_Stock.BOJ.clsMicbudgetparamtypedetail> TestChampObligatoireDelete(HT_Stock.BOJ.clsMicbudgetparamtypedetail Objet)
        {
            List<HT_Stock.BOJ.clsMicbudgetparamtypedetail> clsMicbudgetparamtypes = new List<HT_Stock.BOJ.clsMicbudgetparamtypedetail>();
            HT_Stock.BOJ.clsMicbudgetparamtypedetail clsMicbudgetparamtypedetail = new HT_Stock.BOJ.clsMicbudgetparamtypedetail();
            clsMicbudgetparamtypedetail.clsObjetRetour = new Common.clsObjetRetour();
            clsMicbudgetparamtypedetail.clsObjetRetour.SL_CODEMESSAGE = "";
            clsMicbudgetparamtypedetail.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsMicbudgetparamtypedetail.clsObjetRetour.SL_MESSAGE = "";
            clsMicbudgetparamtypes.Add(clsMicbudgetparamtypedetail);
            return clsMicbudgetparamtypes;
        }

        public List<HT_Stock.BOJ.clsMicbudgetparamtypedetail> TestChampObligatoireInsert(HT_Stock.BOJ.clsMicbudgetparamtypedetail Objet)
        {
            List<HT_Stock.BOJ.clsMicbudgetparamtypedetail> clsMicbudgetparamtypes = new List<HT_Stock.BOJ.clsMicbudgetparamtypedetail>();
            HT_Stock.BOJ.clsMicbudgetparamtypedetail clsMicbudgetparamtypedetail = new HT_Stock.BOJ.clsMicbudgetparamtypedetail();
            clsMicbudgetparamtypedetail.clsObjetRetour = new Common.clsObjetRetour();
            clsMicbudgetparamtypedetail.clsObjetRetour.SL_CODEMESSAGE = "";
            clsMicbudgetparamtypedetail.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsMicbudgetparamtypedetail.clsObjetRetour.SL_MESSAGE = "";
            clsMicbudgetparamtypes.Add(clsMicbudgetparamtypedetail);
            return clsMicbudgetparamtypes;
        }

       
    }
}
