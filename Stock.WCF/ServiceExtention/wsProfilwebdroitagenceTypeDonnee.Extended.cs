using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Stock.BOJ;
using Stock.WSBLL;
using Stock.WSTOOLS;
using Stock.Common;
using System.Data;

namespace Stock.WCF
{
	public partial class wsProfilwebdroitagence
	{
        public DataSet TestTypeDonnee(HT_Stock.BOJ.clsProfilwebdroitagence Objet)

        {
            DataSet DataSet = new DataSet();
            DataTable dt = new DataTable("TABLE");
            dt.Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));

            List<HT_Stock.BOJ.clsProfilwebdroitagence> clsProfilwebdroitagences = new List<HT_Stock.BOJ.clsProfilwebdroitagence>();
            HT_Stock.BOJ.clsProfilwebdroitagence clsProfilwebdroitagence = new HT_Stock.BOJ.clsProfilwebdroitagence();
            clsProfilwebdroitagence.clsObjetRetour = new Common.clsObjetRetour();
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