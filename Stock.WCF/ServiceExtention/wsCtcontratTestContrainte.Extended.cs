using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stock.Common;
using System.Runtime.Serialization;
using Stock.BOJ;
using Stock.WSBLL;
using Stock.WSTOOLS;
using System.Data;

namespace Stock.WCF
{
	public partial class wsCtcontrat
	{
        public List<HT_Stock.BOJ.clsCtcontrat> TestContrainte(HT_Stock.BOJ.clsCtcontrat Objet)

        {
            List<HT_Stock.BOJ.clsCtcontrat> clsCtcontrats = new List<HT_Stock.BOJ.clsCtcontrat>();
            HT_Stock.BOJ.clsCtcontrat clsCtcontrat = new HT_Stock.BOJ.clsCtcontrat();
            clsCtcontrat.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontrat.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtcontrat.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtcontrat.clsObjetRetour.SL_MESSAGE = "";
            clsCtcontrats.Add(clsCtcontrat);
            return clsCtcontrats;
        }



        public List<HT_Stock.BOJ.clsCtcontrat> TestTestContrainteListe(HT_Stock.BOJ.clsCtcontrat Objet)
        {
            List<HT_Stock.BOJ.clsCtcontrat> clsCtcontrats = new List<HT_Stock.BOJ.clsCtcontrat>();
            HT_Stock.BOJ.clsCtcontrat clsCtcontrat = new HT_Stock.BOJ.clsCtcontrat();
            clsCtcontrat.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontrat.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtcontrat.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtcontrat.clsObjetRetour.SL_MESSAGE = "";
            clsCtcontrats.Add(clsCtcontrat);
            return clsCtcontrats;
        }

        public DataSet TestTestContrainteListeDataSet(HT_Stock.BOJ.clsCtcontrat Objet)
        {

            DataSet DataSet = new DataSet();
            DataTable dt = new DataTable("TABLE");
            dt.Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));

            List<HT_Stock.BOJ.clsCtcontrat> clsCtcontrats = new List<HT_Stock.BOJ.clsCtcontrat>();
            HT_Stock.BOJ.clsCtcontrat clsCtcontrat = new HT_Stock.BOJ.clsCtcontrat();
            clsCtcontrat.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontrat.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtcontrat.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtcontrat.clsObjetRetour.SL_MESSAGE = "";
            DataRow dr = dt.NewRow();
            dr["SL_CODEMESSAGE"] = "";
            dr["SL_RESULTAT"] = "TRUE";
            dr["SL_MESSAGE"] = "";
            dt.Rows.Add(dr);
            DataSet.Tables.Add(dt);
            return DataSet;
        }

    }
}
