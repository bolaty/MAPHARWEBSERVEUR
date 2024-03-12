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
	public partial class wsPhatiers
	{
        public List<HT_Stock.BOJ.clsPhatiers> TestContrainte(HT_Stock.BOJ.clsPhatiers Objet)

        {
            List<HT_Stock.BOJ.clsPhatiers> clsPhatierss = new List<HT_Stock.BOJ.clsPhatiers>();
            HT_Stock.BOJ.clsPhatiers clsPhatiers = new HT_Stock.BOJ.clsPhatiers();
            clsPhatiers.clsObjetRetour = new Common.clsObjetRetour();
            clsPhatiers.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhatiers.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhatiers.clsObjetRetour.SL_MESSAGE = "";
            clsPhatierss.Add(clsPhatiers);
            return clsPhatierss;
        }

        public List<HT_Stock.BOJ.clsPhatiers> TestChampObligatoireInsert(HT_Stock.BOJ.clsPhatiers Objet)

        {
            List<HT_Stock.BOJ.clsPhatiers> clsPhatierss = new List<HT_Stock.BOJ.clsPhatiers>();
            HT_Stock.BOJ.clsPhatiers clsPhatiers = new HT_Stock.BOJ.clsPhatiers();
            clsPhatiers.clsObjetRetour = new Common.clsObjetRetour();
            clsPhatiers.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhatiers.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhatiers.clsObjetRetour.SL_MESSAGE = "";
            clsPhatierss.Add(clsPhatiers);
            return clsPhatierss;
        }
        public List<HT_Stock.BOJ.clsPhatiers> TestChampObligatoireDelete(HT_Stock.BOJ.clsPhatiers Objet)

        {
            List<HT_Stock.BOJ.clsPhatiers> clsPhatierss = new List<HT_Stock.BOJ.clsPhatiers>();
            HT_Stock.BOJ.clsPhatiers clsPhatiers = new HT_Stock.BOJ.clsPhatiers();
            clsPhatiers.clsObjetRetour = new Common.clsObjetRetour();
            clsPhatiers.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhatiers.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhatiers.clsObjetRetour.SL_MESSAGE = "";
            clsPhatierss.Add(clsPhatiers);
            return clsPhatierss;
        }

        public List<HT_Stock.BOJ.clsPhatiers> TestChampObligatoireDepartTiers(HT_Stock.BOJ.clsPhatiers Objet)

        {
            List<HT_Stock.BOJ.clsPhatiers> clsPhatierss = new List<HT_Stock.BOJ.clsPhatiers>();
            HT_Stock.BOJ.clsPhatiers clsPhatiers = new HT_Stock.BOJ.clsPhatiers();
            clsPhatiers.clsObjetRetour = new Common.clsObjetRetour();

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

 

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsPhatiers.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhatiers.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhatiers.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhatiers.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsPhatierss.Add(clsPhatiers);
                return clsPhatierss;

            }
            if (string.IsNullOrEmpty(Objet.TI_IDTIERS))
            {
                clsPhatiers.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhatiers.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhatiers.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhatiers.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TI_IDTIERS";
                clsPhatierss.Add(clsPhatiers);
                return clsPhatierss;

            }
            if (string.IsNullOrEmpty(Objet.TI_DATEDEPART))
            {
                clsPhatiers.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhatiers.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhatiers.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhatiers.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TI_DATEDEPART";
                clsPhatierss.Add(clsPhatiers);
                return clsPhatierss;

            }
            if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUR))
            {
                clsPhatiers.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhatiers.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhatiers.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhatiers.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_CODEOPERATEUR";
                clsPhatierss.Add(clsPhatiers);
                return clsPhatierss;

            }



            else
            {
                clsPhatiers.clsObjetRetour = new Common.clsObjetRetour();
                clsPhatiers.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhatiers.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhatiers.clsObjetRetour.SL_MESSAGE = "";
                clsPhatierss.Add(clsPhatiers);
                return clsPhatierss;

            }

        }






        public List<HT_Stock.BOJ.clsPhatiers> TestTestContrainteListe(HT_Stock.BOJ.clsPhatiers Objet)
        {
            List<HT_Stock.BOJ.clsPhatiers> clsPhatierss = new List<HT_Stock.BOJ.clsPhatiers>();
            HT_Stock.BOJ.clsPhatiers clsPhatiers = new HT_Stock.BOJ.clsPhatiers();
            clsPhatiers.clsObjetRetour = new Common.clsObjetRetour();
            clsPhatiers.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhatiers.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhatiers.clsObjetRetour.SL_MESSAGE = "";
            clsPhatierss.Add(clsPhatiers);
            return clsPhatierss;
        }
        public DataSet TestTestContrainteListeNew(HT_Stock.BOJ.clsPhatiers Objet)
        {
            DataSet DataSet = new DataSet();
            DataTable dt = new DataTable("TABLE");
            dt.Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));

            List<HT_Stock.BOJ.clsPhatiers> clsPhatierss = new List<HT_Stock.BOJ.clsPhatiers>();
            HT_Stock.BOJ.clsPhatiers clsPhatiers = new HT_Stock.BOJ.clsPhatiers();
            clsPhatiers.clsObjetRetour = new Common.clsObjetRetour();
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
