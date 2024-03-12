using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stock.Common;
using System.Runtime.Serialization;
using Stock.BOJ;
using Stock.WSBLL;
using Stock.WSTOOLS;

namespace Stock.WCF
{
	public partial class wsPhapartypearticlecompteplancomptablemodel
	{
        public List<HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel> TestContrainte(HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel Objet)

        {
            List<HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel> clsPhapartypearticlecompteplancomptablemodels = new List<HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel>();
            HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel clsPhapartypearticlecompteplancomptablemodel = new HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel();
            clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour = new Common.clsObjetRetour();
            clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_MESSAGE = "";
            clsPhapartypearticlecompteplancomptablemodels.Add(clsPhapartypearticlecompteplancomptablemodel);
            return clsPhapartypearticlecompteplancomptablemodels;
        }



        public List<HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel> TestTestContrainteListe(HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel Objet)
        {
            List<HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel> clsPhapartypearticlecompteplancomptablemodels = new List<HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel>();
            HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel clsPhapartypearticlecompteplancomptablemodel = new HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel();
            clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour = new Common.clsObjetRetour();
            clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_MESSAGE = "";
            clsPhapartypearticlecompteplancomptablemodels.Add(clsPhapartypearticlecompteplancomptablemodel);
            return clsPhapartypearticlecompteplancomptablemodels;
        }
    }
}
