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
	public partial class wsCtparreduction
	{
        public List<HT_Stock.BOJ.clsCtparreduction> TestTypeDonnee(HT_Stock.BOJ.clsCtparreduction Objet)

        {


            List<HT_Stock.BOJ.clsCtparreduction> clsCtparreductions = new List<HT_Stock.BOJ.clsCtparreduction>();
            HT_Stock.BOJ.clsCtparreduction clsCtparreduction = new HT_Stock.BOJ.clsCtparreduction();
            clsCtparreduction.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparreduction.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparreduction.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparreduction.clsObjetRetour.SL_MESSAGE = "";
            clsCtparreductions.Add(clsCtparreduction);
            return clsCtparreductions;


        }

    }
}