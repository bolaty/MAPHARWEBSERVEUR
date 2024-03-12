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
	public partial class wsLogicielobjetweb
	{
        public List<HT_Stock.BOJ.clsLogicielobjetweb> TestTypeDonnee(HT_Stock.BOJ.clsLogicielobjetweb Objet)

        {


            List<HT_Stock.BOJ.clsLogicielobjetweb> clsLogicielobjetwebs = new List<HT_Stock.BOJ.clsLogicielobjetweb>();
            HT_Stock.BOJ.clsLogicielobjetweb clsLogicielobjetweb = new HT_Stock.BOJ.clsLogicielobjetweb();
            clsLogicielobjetweb.clsObjetRetour = new Common.clsObjetRetour();
            clsLogicielobjetweb.clsObjetRetour.SL_CODEMESSAGE = "";
            clsLogicielobjetweb.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsLogicielobjetweb.clsObjetRetour.SL_MESSAGE = "";
            clsLogicielobjetwebs.Add(clsLogicielobjetweb);
            return clsLogicielobjetwebs;


        }

    }
}