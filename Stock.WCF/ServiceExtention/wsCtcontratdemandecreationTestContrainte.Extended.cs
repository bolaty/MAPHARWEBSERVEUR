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
	public partial class wsCtcontratdemandecreation
	{
        public List<HT_Stock.BOJ.clsCtcontratdemandecreation> TestContrainte(HT_Stock.BOJ.clsCtcontratdemandecreation Objet)

        {
            List<HT_Stock.BOJ.clsCtcontratdemandecreation> clsCtcontratdemandecreations = new List<HT_Stock.BOJ.clsCtcontratdemandecreation>();
            HT_Stock.BOJ.clsCtcontratdemandecreation clsCtcontratdemandecreation = new HT_Stock.BOJ.clsCtcontratdemandecreation();
            clsCtcontratdemandecreation.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontratdemandecreation.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtcontratdemandecreation.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtcontratdemandecreation.clsObjetRetour.SL_MESSAGE = "";
            clsCtcontratdemandecreations.Add(clsCtcontratdemandecreation);
            return clsCtcontratdemandecreations;
        }



        public DataSet TestTestContrainteListe(HT_Stock.BOJ.clsCtcontratdemandecreation Objet)
        {
            DataSet DataSet = new DataSet();
            DataTable dt = new DataTable("TABLE");
            dt.Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));


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
