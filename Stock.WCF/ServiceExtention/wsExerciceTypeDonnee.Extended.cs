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
	public partial class wsExercice
	{
        public List<HT_Stock.BOJ.clsExercice> TestTypeDonnee(HT_Stock.BOJ.clsExercice Objet)

        {


            List<HT_Stock.BOJ.clsExercice> clsExercices = new List<HT_Stock.BOJ.clsExercice>();
            HT_Stock.BOJ.clsExercice clsExercice = new HT_Stock.BOJ.clsExercice();
            clsExercice.clsObjetRetour = new Common.clsObjetRetour();
            clsExercice.clsObjetRetour.SL_CODEMESSAGE = "";
            clsExercice.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsExercice.clsObjetRetour.SL_MESSAGE = "";
            clsExercices.Add(clsExercice);
            return clsExercices;


        }

    }
}