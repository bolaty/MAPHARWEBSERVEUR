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
	public partial class wsMicbudgetparamtypedetail
	{
        public List<HT_Stock.BOJ.clsMicbudgetparamtypedetail> TestTypeDonnee(HT_Stock.BOJ.clsMicbudgetparamtypedetail Objet)

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

    }
}