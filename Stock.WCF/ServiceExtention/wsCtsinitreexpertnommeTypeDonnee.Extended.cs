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
	public partial class wsCtsinitreexpertnomme
	{
        public List<HT_Stock.BOJ.clsCtsinitreexpertnomme> TestTypeDonnee(HT_Stock.BOJ.clsCtsinitreexpertnomme Objet)

        {


            List<HT_Stock.BOJ.clsCtsinitreexpertnomme> clsCtsinitreexpertnommes = new List<HT_Stock.BOJ.clsCtsinitreexpertnomme>();
            HT_Stock.BOJ.clsCtsinitreexpertnomme clsCtsinitreexpertnomme = new HT_Stock.BOJ.clsCtsinitreexpertnomme();
            clsCtsinitreexpertnomme.clsObjetRetour = new Common.clsObjetRetour();
            clsCtsinitreexpertnomme.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtsinitreexpertnomme.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtsinitreexpertnomme.clsObjetRetour.SL_MESSAGE = "";
            clsCtsinitreexpertnommes.Add(clsCtsinitreexpertnomme);
            return clsCtsinitreexpertnommes;


        }

    }
}