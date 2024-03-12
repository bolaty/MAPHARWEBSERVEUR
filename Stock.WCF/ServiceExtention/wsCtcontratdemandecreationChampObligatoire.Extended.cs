using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Stock.Common;
using Stock.BOJ;
using Stock.WSBLL;
using Stock.WSTOOLS;
using System.Data;

namespace Stock.WCF
{
	public partial class wsCtcontratdemandecreation
	{

        public DataSet TestChampObligatoireListe(HT_Stock.BOJ.clsCtcontratdemandecreation Objet)
        {
            DataSet DataSet = new DataSet();
            DataTable dt = new DataTable("TABLE");
            dt.Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtcontratdemandecreation> clsCtcontratdemandecreations = new List<HT_Stock.BOJ.clsCtcontratdemandecreation>();
            HT_Stock.BOJ.clsCtcontratdemandecreation clsCtcontratdemandecreation = new HT_Stock.BOJ.clsCtcontratdemandecreation();

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsCtcontratdemandecreation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);

                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = clsMessages.MS_CODEMESSAGE;
                dr["SL_RESULTAT"] = Common.clsDeclaration.ERROR_RESULTAT;
                dr["SL_MESSAGE"] = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);

                return DataSet;

            }
            if (string.IsNullOrEmpty(Objet.DATEDEBUT))
            {
                clsCtcontratdemandecreation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);

                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = clsMessages.MS_CODEMESSAGE;
                dr["SL_RESULTAT"] = Common.clsDeclaration.ERROR_RESULTAT;
                dr["SL_MESSAGE"] = clsMessages.MS_LIBELLEMESSAGE + ", DATEDEBUT";
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);

                return DataSet;

            }

            if (string.IsNullOrEmpty(Objet.DATEFIN))
            {
                clsCtcontratdemandecreation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);

                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = clsMessages.MS_CODEMESSAGE;
                dr["SL_RESULTAT"] = Common.clsDeclaration.ERROR_RESULTAT;
                dr["SL_MESSAGE"] = clsMessages.MS_LIBELLEMESSAGE + ", DATEFIN";
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);

                return DataSet;

            }
            //if (string.IsNullOrEmpty(Objet.RQ_CODERISQUE))
            //{
            //    clsCtcontratdemandecreation.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);

            //    DataRow dr = dt.NewRow();
            //    dr["SL_CODEMESSAGE"] = clsMessages.MS_CODEMESSAGE;
            //    dr["SL_RESULTAT"] = Common.clsDeclaration.ERROR_RESULTAT;
            //    dr["SL_MESSAGE"] = clsMessages.MS_LIBELLEMESSAGE + ", RQ_CODERISQUE";
            //    dt.Rows.Add(dr);
            //    DataSet.Tables.Add(dt);

            //    return DataSet;

            //}
            //if (string.IsNullOrEmpty(Objet.TYPEOPERATION))
            //{
            //    clsCtcontratdemandecreation.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);

            //    DataRow dr = dt.NewRow();
            //    dr["SL_CODEMESSAGE"] = clsMessages.MS_CODEMESSAGE;
            //    dr["SL_RESULTAT"] = Common.clsDeclaration.ERROR_RESULTAT;
            //    dr["SL_MESSAGE"] = clsMessages.MS_LIBELLEMESSAGE + ", TYPEOPERATION";
            //    dt.Rows.Add(dr);
            //    DataSet.Tables.Add(dt);

            //    return DataSet;

            //}


            else
            {
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = "";
                dr["SL_RESULTAT"] = "TRUE";
                dr["SL_MESSAGE"] = "";
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);
                return DataSet;

            }


        }

        public DataSet TestChampObligatoireInsert(HT_Stock.BOJ.clsCtcontratdemandecreation Objet)
        {



            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            DataSet DataSet = new DataSet();
            DataTable dt = new DataTable("TABLE");
            dt.Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));

            List<HT_Stock.BOJ.clsCtcontratdemandecreation> clsCtcontratdemandecreations = new List<HT_Stock.BOJ.clsCtcontratdemandecreation>();
            HT_Stock.BOJ.clsCtcontratdemandecreation clsCtcontratdemandecreation = new HT_Stock.BOJ.clsCtcontratdemandecreation();

           
            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsCtcontratdemandecreation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);

                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = clsMessages.MS_CODEMESSAGE;
                dr["SL_RESULTAT"] = Common.clsDeclaration.ERROR_RESULTAT;
                dr["SL_MESSAGE"] = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);

                return DataSet;

            }

            if (string.IsNullOrEmpty(Objet.RQ_CODERISQUE))
            {
                clsCtcontratdemandecreation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);

                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = clsMessages.MS_CODEMESSAGE;
                dr["SL_RESULTAT"] = Common.clsDeclaration.ERROR_RESULTAT;
                dr["SL_MESSAGE"] = clsMessages.MS_LIBELLEMESSAGE + ", RQ_CODERISQUE";
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);

                return DataSet;

            }
            if (string.IsNullOrEmpty(Objet.DE_DATESAISIE))
            {
                clsCtcontratdemandecreation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);

                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = clsMessages.MS_CODEMESSAGE;
                dr["SL_RESULTAT"] = Common.clsDeclaration.ERROR_RESULTAT;
                dr["SL_MESSAGE"] = clsMessages.MS_LIBELLEMESSAGE + ", DE_DATESAISIE";
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);

                return DataSet;

            }

            if (string.IsNullOrEmpty(Objet.DE_DATEVALIDATION))
            {
                clsCtcontratdemandecreation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);

                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = clsMessages.MS_CODEMESSAGE;
                dr["SL_RESULTAT"] = Common.clsDeclaration.ERROR_RESULTAT;
                dr["SL_MESSAGE"] = clsMessages.MS_LIBELLEMESSAGE + ", DE_DATEVALIDATION";
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);

                return DataSet;

            }
        if (string.IsNullOrEmpty(Objet.TI_IDTIERSASSUREUR))
        {
            clsCtcontratdemandecreation.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);

            DataRow dr = dt.NewRow();
            dr["SL_CODEMESSAGE"] = clsMessages.MS_CODEMESSAGE;
            dr["SL_RESULTAT"] = Common.clsDeclaration.ERROR_RESULTAT;
            dr["SL_MESSAGE"] = clsMessages.MS_LIBELLEMESSAGE + ", TI_IDTIERSASSUREUR";
            dt.Rows.Add(dr);
            DataSet.Tables.Add(dt);

            return DataSet;

        }
        if (string.IsNullOrEmpty(Objet.TI_IDTIERS))
        {
            clsCtcontratdemandecreation.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);

            DataRow dr = dt.NewRow();
            dr["SL_CODEMESSAGE"] = clsMessages.MS_CODEMESSAGE;
            dr["SL_RESULTAT"] = Common.clsDeclaration.ERROR_RESULTAT;
            dr["SL_MESSAGE"] = clsMessages.MS_LIBELLEMESSAGE + ", TI_IDTIERS";
            dt.Rows.Add(dr);
            DataSet.Tables.Add(dt);

            return DataSet;

        }

            //clsCtcontratdemandecreation.AG_CODEAGENCE = clsCtcontratdemandecreationDTO.AG_CODEAGENCE.ToString();
            //clsCtcontratdemandecreation.RQ_CODERISQUE = clsCtcontratdemandecreationDTO.RQ_CODERISQUE.ToString();
            //clsCtcontratdemandecreation.DE_DATESAISIE = DateTime.Parse(clsCtcontratdemandecreationDTO.DE_DATESAISIE.ToString());
            //clsCtcontratdemandecreation.DE_DATEVALIDATION = DateTime.Parse(clsCtcontratdemandecreationDTO.DE_DATEVALIDATION.ToString());
            //clsCtcontratdemandecreation.TI_IDTIERSASSUREUR = clsCtcontratdemandecreationDTO.TI_IDTIERSASSUREUR.ToString();
            //clsCtcontratdemandecreation.TI_IDTIERS = clsCtcontratdemandecreationDTO.TI_IDTIERS.ToString();
            //clsCtcontratdemandecreation.CA_CODECONTRAT = clsCtcontratdemandecreationDTO.CA_CODECONTRAT.ToString();



            else
            {
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = "";
                dr["SL_RESULTAT"] = "TRUE";
                dr["SL_MESSAGE"] = "";
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);
                return DataSet;

            }


        }

        public DataSet TestChampObligatoireUpdate(HT_Stock.BOJ.clsCtcontratdemandecreation Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            DataSet DataSet = new DataSet();
            DataTable dt = new DataTable("TABLE");
            dt.Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));

            List<HT_Stock.BOJ.clsCtcontratdemandecreation> clsCtcontratdemandecreations = new List<HT_Stock.BOJ.clsCtcontratdemandecreation>();
            HT_Stock.BOJ.clsCtcontratdemandecreation clsCtcontratdemandecreation = new HT_Stock.BOJ.clsCtcontratdemandecreation();
            if (string.IsNullOrEmpty(Objet.DE_CODEDEMANADE))
            {
                clsCtcontratdemandecreation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);

                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = clsMessages.MS_CODEMESSAGE;
                dr["SL_RESULTAT"] = Common.clsDeclaration.ERROR_RESULTAT;
                dr["SL_MESSAGE"] = clsMessages.MS_LIBELLEMESSAGE + ", DE_CODEDEMANADE";
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);

                return DataSet;

            }

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsCtcontratdemandecreation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);

                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = clsMessages.MS_CODEMESSAGE;
                dr["SL_RESULTAT"] = Common.clsDeclaration.ERROR_RESULTAT;
                dr["SL_MESSAGE"] = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);

                return DataSet;

            }

            if (string.IsNullOrEmpty(Objet.RQ_CODERISQUE) )
            {
                clsCtcontratdemandecreation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);

                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = clsMessages.MS_CODEMESSAGE;
                dr["SL_RESULTAT"] = Common.clsDeclaration.ERROR_RESULTAT;
                dr["SL_MESSAGE"] = clsMessages.MS_LIBELLEMESSAGE + ", RQ_CODERISQUE";
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);

                return DataSet;

            }
            if (string.IsNullOrEmpty(Objet.DE_DATESAISIE) )
            {
                clsCtcontratdemandecreation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);

                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = clsMessages.MS_CODEMESSAGE;
                dr["SL_RESULTAT"] = Common.clsDeclaration.ERROR_RESULTAT;
                dr["SL_MESSAGE"] = clsMessages.MS_LIBELLEMESSAGE + ", DE_DATESAISIE";
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);

                return DataSet;

            }

            if (string.IsNullOrEmpty(Objet.DE_DATEVALIDATION))
            {
                clsCtcontratdemandecreation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);

                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = clsMessages.MS_CODEMESSAGE;
                dr["SL_RESULTAT"] = Common.clsDeclaration.ERROR_RESULTAT;
                dr["SL_MESSAGE"] = clsMessages.MS_LIBELLEMESSAGE + ", DE_DATEVALIDATION";
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);

                return DataSet;

            }
            if (string.IsNullOrEmpty(Objet.TI_IDTIERSASSUREUR))
            {
                clsCtcontratdemandecreation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);

                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = clsMessages.MS_CODEMESSAGE;
                dr["SL_RESULTAT"] = Common.clsDeclaration.ERROR_RESULTAT;
                dr["SL_MESSAGE"] = clsMessages.MS_LIBELLEMESSAGE + ", TI_IDTIERSASSUREUR";
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);

                return DataSet;

            }
            if (string.IsNullOrEmpty(Objet.TI_IDTIERS))
            {
                clsCtcontratdemandecreation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);

                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = clsMessages.MS_CODEMESSAGE;
                dr["SL_RESULTAT"] = Common.clsDeclaration.ERROR_RESULTAT;
                dr["SL_MESSAGE"] = clsMessages.MS_LIBELLEMESSAGE + ", TI_IDTIERS";
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);

                return DataSet;

            }

            //clsCtcontratdemandecreation.AG_CODEAGENCE = clsCtcontratdemandecreationDTO.AG_CODEAGENCE.ToString();
            //clsCtcontratdemandecreation.RQ_CODERISQUE = clsCtcontratdemandecreationDTO.RQ_CODERISQUE.ToString();
            //clsCtcontratdemandecreation.DE_DATESAISIE = DateTime.Parse(clsCtcontratdemandecreationDTO.DE_DATESAISIE.ToString());
            //clsCtcontratdemandecreation.DE_DATEVALIDATION = DateTime.Parse(clsCtcontratdemandecreationDTO.DE_DATEVALIDATION.ToString());
            //clsCtcontratdemandecreation.TI_IDTIERSASSUREUR = clsCtcontratdemandecreationDTO.TI_IDTIERSASSUREUR.ToString();
            //clsCtcontratdemandecreation.TI_IDTIERS = clsCtcontratdemandecreationDTO.TI_IDTIERS.ToString();
            //clsCtcontratdemandecreation.CA_CODECONTRAT = clsCtcontratdemandecreationDTO.CA_CODECONTRAT.ToString();



            else
            {
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = "";
                dr["SL_RESULTAT"] = "TRUE";
                dr["SL_MESSAGE"] = "";
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);
                return DataSet;

            }


        }
        public DataSet TestChampObligatoireAnnulation(HT_Stock.BOJ.clsCtcontratdemandecreation Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            DataSet DataSet = new DataSet();
            DataTable dt = new DataTable("TABLE");
            dt.Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));

            List<HT_Stock.BOJ.clsCtcontratdemandecreation> clsCtcontratdemandecreations = new List<HT_Stock.BOJ.clsCtcontratdemandecreation>();
            HT_Stock.BOJ.clsCtcontratdemandecreation clsCtcontratdemandecreation = new HT_Stock.BOJ.clsCtcontratdemandecreation();
            if (string.IsNullOrEmpty(Objet.DE_CODEDEMANADE))
            {
                clsCtcontratdemandecreation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);

                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = clsMessages.MS_CODEMESSAGE;
                dr["SL_RESULTAT"] = Common.clsDeclaration.ERROR_RESULTAT;
                dr["SL_MESSAGE"] = clsMessages.MS_LIBELLEMESSAGE + ", DE_CODEDEMANADE";
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);

                return DataSet;

            }

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsCtcontratdemandecreation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);

                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = clsMessages.MS_CODEMESSAGE;
                dr["SL_RESULTAT"] = Common.clsDeclaration.ERROR_RESULTAT;
                dr["SL_MESSAGE"] = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);

                return DataSet;

            }

            if (string.IsNullOrEmpty(Objet.DE_DATEANNULATION) )
            {
                clsCtcontratdemandecreation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);

                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = clsMessages.MS_CODEMESSAGE;
                dr["SL_RESULTAT"] = Common.clsDeclaration.ERROR_RESULTAT;
                dr["SL_MESSAGE"] = clsMessages.MS_LIBELLEMESSAGE + ", DE_DATEANNULATION";
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);

                return DataSet;

            }
            

            //clsCtcontratdemandecreation.AG_CODEAGENCE = clsCtcontratdemandecreationDTO.AG_CODEAGENCE.ToString();
            //clsCtcontratdemandecreation.RQ_CODERISQUE = clsCtcontratdemandecreationDTO.RQ_CODERISQUE.ToString();
            //clsCtcontratdemandecreation.DE_DATESAISIE = DateTime.Parse(clsCtcontratdemandecreationDTO.DE_DATESAISIE.ToString());
            //clsCtcontratdemandecreation.DE_DATEVALIDATION = DateTime.Parse(clsCtcontratdemandecreationDTO.DE_DATEVALIDATION.ToString());
            //clsCtcontratdemandecreation.TI_IDTIERSASSUREUR = clsCtcontratdemandecreationDTO.TI_IDTIERSASSUREUR.ToString();
            //clsCtcontratdemandecreation.TI_IDTIERS = clsCtcontratdemandecreationDTO.TI_IDTIERS.ToString();
            //clsCtcontratdemandecreation.CA_CODECONTRAT = clsCtcontratdemandecreationDTO.CA_CODECONTRAT.ToString();



            else
            {
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = "";
                dr["SL_RESULTAT"] = "TRUE";
                dr["SL_MESSAGE"] = "";
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);
                return DataSet;

            }


        }
        public DataSet TestChampObligatoireDelete(HT_Stock.BOJ.clsCtcontratdemandecreation Objet)
        {
            DataSet DataSet = new DataSet();
            DataTable dt = new DataTable("TABLE");
            dt.Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtcontratdemandecreation> clsCtcontratdemandecreations = new List<HT_Stock.BOJ.clsCtcontratdemandecreation>();
            HT_Stock.BOJ.clsCtcontratdemandecreation clsCtcontratdemandecreation = new HT_Stock.BOJ.clsCtcontratdemandecreation();

            if (string.IsNullOrEmpty(Objet.DE_CODEDEMANADE))
            {
                clsCtcontratdemandecreation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);

                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = clsMessages.MS_CODEMESSAGE;
                dr["SL_RESULTAT"] = Common.clsDeclaration.ERROR_RESULTAT;
                dr["SL_MESSAGE"] = clsMessages.MS_LIBELLEMESSAGE + ", DE_CODEDEMANADE";
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);

                return DataSet;

            }

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsCtcontratdemandecreation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);

                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = clsMessages.MS_CODEMESSAGE;
                dr["SL_RESULTAT"] = Common.clsDeclaration.ERROR_RESULTAT;
                dr["SL_MESSAGE"] = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);

                return DataSet;

            }
            else
            {
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
}