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
	public partial class wsProfilwebdroitsaisieentrepot
	{
        public DataSet TestContrainte(HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot Objet)

        {

            DataSet DataSet = new DataSet();
            DataTable dt = new DataTable("TABLE");
            dt.Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));

            List<HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot> clsProfilwebdroitsaisieentrepots = new List<HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot>();
            HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot clsProfilwebdroitsaisieentrepot = new HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot();
            clsProfilwebdroitsaisieentrepot.clsObjetRetour = new Common.clsObjetRetour();
            DataRow dr = dt.NewRow();
            dr["SL_CODEMESSAGE"] = "";
            dr["SL_RESULTAT"] = "TRUE";
            dr["SL_MESSAGE"] = "";
            dt.Rows.Add(dr);
            DataSet.Tables.Add(dt);
            return DataSet;
        }



        public DataSet TestTestContrainteListe(HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot Objet)
        {
            DataSet DataSet = new DataSet();
            DataTable dt = new DataTable("TABLE");
            dt.Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));


            List<HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot> clsProfilwebdroitsaisieentrepots = new List<HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot>();
            HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot clsProfilwebdroitsaisieentrepot = new HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot();
            clsProfilwebdroitsaisieentrepot.clsObjetRetour = new Common.clsObjetRetour();
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
