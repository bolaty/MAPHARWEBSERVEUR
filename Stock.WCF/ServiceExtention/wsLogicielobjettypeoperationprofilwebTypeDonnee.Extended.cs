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
	public partial class wsLogicielobjettypeoperationprofilweb
	{
        public DataSet TestTypeDonnee(HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb Objet)

        {
            DataSet DataSet = new DataSet();
            DataTable dt = new DataTable("TABLE");
            dt.Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));

            List<HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb> clsLogicielobjettypeoperationprofilwebs = new List<HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb>();
            HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb clsLogicielobjettypeoperationprofilweb = new HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb();
            clsLogicielobjettypeoperationprofilweb.clsObjetRetour = new Common.clsObjetRetour();
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