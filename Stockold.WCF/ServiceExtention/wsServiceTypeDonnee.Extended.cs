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
	public partial class wsService
	{
        public List<HT_Stock.BOJ.clsService> TestTypeDonnee(HT_Stock.BOJ.clsService Objet)

        {


            List<HT_Stock.BOJ.clsService> clsServices = new List<HT_Stock.BOJ.clsService>();
            HT_Stock.BOJ.clsService clsService = new HT_Stock.BOJ.clsService();
            clsService.clsObjetRetour = new Common.clsObjetRetour();
            clsService.clsObjetRetour.SL_CODEMESSAGE = "";
            clsService.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsService.clsObjetRetour.SL_MESSAGE = "";
            clsServices.Add(clsService);
            return clsServices;


        }

    }
}