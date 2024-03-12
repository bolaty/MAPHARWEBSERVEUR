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
	public partial class wsCtsinistresuivie
	{
        public List<HT_Stock.BOJ.clsCtsinistresuivie> TestTypeDonnee(HT_Stock.BOJ.clsCtsinistresuivie Objet)

        {


            List<HT_Stock.BOJ.clsCtsinistresuivie> clsCtsinistresuivies = new List<HT_Stock.BOJ.clsCtsinistresuivie>();
            HT_Stock.BOJ.clsCtsinistresuivie clsCtsinistresuivie = new HT_Stock.BOJ.clsCtsinistresuivie();
            clsCtsinistresuivie.clsObjetRetour = new Common.clsObjetRetour();
            clsCtsinistresuivie.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtsinistresuivie.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtsinistresuivie.clsObjetRetour.SL_MESSAGE = "";
            clsCtsinistresuivies.Add(clsCtsinistresuivie);
            return clsCtsinistresuivies;


        }

    }
}