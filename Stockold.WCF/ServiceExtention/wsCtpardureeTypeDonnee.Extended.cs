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
	public partial class wsCtparduree
	{
        public List<HT_Stock.BOJ.clsCtparduree> TestTypeDonnee(HT_Stock.BOJ.clsCtparduree Objet)

        {


            List<HT_Stock.BOJ.clsCtparduree> clsCtpardurees = new List<HT_Stock.BOJ.clsCtparduree>();
            HT_Stock.BOJ.clsCtparduree clsCtparduree = new HT_Stock.BOJ.clsCtparduree();
            clsCtparduree.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparduree.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparduree.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparduree.clsObjetRetour.SL_MESSAGE = "";
            clsCtpardurees.Add(clsCtparduree);
            return clsCtpardurees;


        }

    }
}