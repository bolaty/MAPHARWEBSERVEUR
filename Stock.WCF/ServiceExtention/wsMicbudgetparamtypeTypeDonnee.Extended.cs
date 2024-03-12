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
	public partial class wsMicbudgetparamtype
	{
        public List<HT_Stock.BOJ.clsMicbudgetparamtype> TestTypeDonnee(HT_Stock.BOJ.clsMicbudgetparamtype Objet)

        {


            List<HT_Stock.BOJ.clsMicbudgetparamtype> clsMicbudgetparamtypes = new List<HT_Stock.BOJ.clsMicbudgetparamtype>();
            HT_Stock.BOJ.clsMicbudgetparamtype clsMicbudgetparamtype = new HT_Stock.BOJ.clsMicbudgetparamtype();
            clsMicbudgetparamtype.clsObjetRetour = new Common.clsObjetRetour();
            clsMicbudgetparamtype.clsObjetRetour.SL_CODEMESSAGE = "";
            clsMicbudgetparamtype.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsMicbudgetparamtype.clsObjetRetour.SL_MESSAGE = "";
            clsMicbudgetparamtypes.Add(clsMicbudgetparamtype);
            return clsMicbudgetparamtypes;


        }

    }
}