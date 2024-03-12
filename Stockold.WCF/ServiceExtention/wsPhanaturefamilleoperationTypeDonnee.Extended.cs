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
	public partial class wsPhanaturefamilleoperation
	{
        public List<HT_Stock.BOJ.clsPhanaturefamilleoperation> TestTypeDonnee(HT_Stock.BOJ.clsPhanaturefamilleoperation Objet)

        {


            List<HT_Stock.BOJ.clsPhanaturefamilleoperation> clsPhanaturefamilleoperations = new List<HT_Stock.BOJ.clsPhanaturefamilleoperation>();
            HT_Stock.BOJ.clsPhanaturefamilleoperation clsPhanaturefamilleoperation = new HT_Stock.BOJ.clsPhanaturefamilleoperation();
            clsPhanaturefamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
            clsPhanaturefamilleoperation.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhanaturefamilleoperation.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhanaturefamilleoperation.clsObjetRetour.SL_MESSAGE = "";
            clsPhanaturefamilleoperations.Add(clsPhanaturefamilleoperation);
            return clsPhanaturefamilleoperations;


        }

    }
}