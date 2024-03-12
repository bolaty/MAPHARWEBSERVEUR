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
	public partial class wsCtparautocategorie
	{
        public List<HT_Stock.BOJ.clsCtparautocategorie> TestTypeDonnee(HT_Stock.BOJ.clsCtparautocategorie Objet)

        {


            List<HT_Stock.BOJ.clsCtparautocategorie> clsCtparautocategories = new List<HT_Stock.BOJ.clsCtparautocategorie>();
            HT_Stock.BOJ.clsCtparautocategorie clsCtparautocategorie = new HT_Stock.BOJ.clsCtparautocategorie();
            clsCtparautocategorie.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparautocategorie.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparautocategorie.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparautocategorie.clsObjetRetour.SL_MESSAGE = "";
            clsCtparautocategories.Add(clsCtparautocategorie);
            return clsCtparautocategories;


        }

    }
}