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
	public partial class wsProfilwebdroit
	{

        public DataSet TestChampObligatoireListe(HT_Stock.BOJ.clsProfilwebdroit Objet)
        {


            DataSet DataSet = new DataSet();
            DataTable dt = new DataTable("TABLE");
            dt.Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsProfilwebdroit> clsProfilwebdroits = new List<HT_Stock.BOJ.clsProfilwebdroit>();
            HT_Stock.BOJ.clsProfilwebdroit clsProfilwebdroit = new HT_Stock.BOJ.clsProfilwebdroit();

          /*  if (string.IsNullOrEmpty(Objet.PO_CODEPROFILWEB))
            {
                clsProfilwebdroit.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = clsMessages.MS_CODEMESSAGE;
                dr["SL_RESULTAT"] = Common.clsDeclaration.ERROR_RESULTAT;
                dr["SL_MESSAGE"] = clsMessages.MS_LIBELLEMESSAGE + ", PO_CODEPROFILWEB";
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);

                return DataSet;

            }

            if (string.IsNullOrEmpty(Objet.OT_CODETYPEOBJET))
            {
                clsProfilwebdroit.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = clsMessages.MS_CODEMESSAGE;
                dr["SL_RESULTAT"] = Common.clsDeclaration.ERROR_RESULTAT;
                dr["SL_MESSAGE"] = clsMessages.MS_LIBELLEMESSAGE + ", OT_CODETYPEOBJET";
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);

                return DataSet;

            }

            if (string.IsNullOrEmpty(Objet.OB_CODEOBJET))
            {
                clsProfilwebdroit.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = clsMessages.MS_CODEMESSAGE;
                dr["SL_RESULTAT"] = Common.clsDeclaration.ERROR_RESULTAT;
                dr["SL_MESSAGE"] = clsMessages.MS_LIBELLEMESSAGE + ", OB_CODEOBJET";
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);

                return DataSet;

            }


            if (string.IsNullOrEmpty(Objet.LO_CODELOGICIEL))
            {
                clsProfilwebdroit.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = clsMessages.MS_CODEMESSAGE;
                dr["SL_RESULTAT"] = Common.clsDeclaration.ERROR_RESULTAT;
                dr["SL_MESSAGE"] = clsMessages.MS_LIBELLEMESSAGE + ", OB_CODEOBJET";
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);

                return DataSet;

            }

            else
            {*/
                clsProfilwebdroit.clsObjetRetour = new Common.clsObjetRetour();
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = "";
                dr["SL_RESULTAT"] = "TRUE";
                dr["SL_MESSAGE"] = "";
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);


                return DataSet;

           // }


        }

        public DataSet TestChampObligatoireInsert(HT_Stock.BOJ.clsProfilwebdroit Objet)
        {
            DataSet DataSet = new DataSet();
            DataTable dt = new DataTable("TABLE");
            dt.Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));




            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsProfilwebdroit> clsProfilwebdroits = new List<HT_Stock.BOJ.clsProfilwebdroit>();
            HT_Stock.BOJ.clsProfilwebdroit clsProfilwebdroit = new HT_Stock.BOJ.clsProfilwebdroit();

           

            if (string.IsNullOrEmpty(Objet.OB_CODEOBJET))
            {
                clsProfilwebdroit.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);

                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = clsMessages.MS_CODEMESSAGE;
                dr["SL_RESULTAT"] = Common.clsDeclaration.ERROR_RESULTAT;
                dr["SL_MESSAGE"] = clsMessages.MS_LIBELLEMESSAGE + ", OB_CODEOBJET";
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);

                return DataSet;
                
            }

            if (string.IsNullOrEmpty(Objet.PO_CODEPROFILWEB))
            {
                clsProfilwebdroit.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);

                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = clsMessages.MS_CODEMESSAGE;
                dr["SL_RESULTAT"] = Common.clsDeclaration.ERROR_RESULTAT;
                dr["SL_MESSAGE"] = clsMessages.MS_LIBELLEMESSAGE + ", PO_CODEPROFILWEB";
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);

                return DataSet;
               

            }
            if (string.IsNullOrEmpty(Objet.PD_AUTORISER))
            {
                clsProfilwebdroit.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = clsMessages.MS_CODEMESSAGE;
                dr["SL_RESULTAT"] = Common.clsDeclaration.ERROR_RESULTAT;
                dr["SL_MESSAGE"] = clsMessages.MS_LIBELLEMESSAGE + ", PO_CODEPROFILWEB";
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);

                return DataSet;


               

            }
            if (string.IsNullOrEmpty(Objet.PD_AJOUTER))
            {
                clsProfilwebdroit.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);

                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = clsMessages.MS_CODEMESSAGE;
                dr["SL_RESULTAT"] = Common.clsDeclaration.ERROR_RESULTAT;
                dr["SL_MESSAGE"] = clsMessages.MS_LIBELLEMESSAGE + ", PO_CODEPROFILWEB";
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);

                return DataSet;

                

            }
            if (string.IsNullOrEmpty(Objet.PD_MODIFIER))
            {
                clsProfilwebdroit.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);

                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = clsMessages.MS_CODEMESSAGE;
                dr["SL_RESULTAT"] = Common.clsDeclaration.ERROR_RESULTAT;
                dr["SL_MESSAGE"] = clsMessages.MS_LIBELLEMESSAGE + ", PD_MODIFIER";
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);

                return DataSet;
                
            }
            if (string.IsNullOrEmpty(Objet.PD_SUPPRIMER))
            {
                clsProfilwebdroit.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);

                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = clsMessages.MS_CODEMESSAGE;
                dr["SL_RESULTAT"] = Common.clsDeclaration.ERROR_RESULTAT;
                dr["SL_MESSAGE"] = clsMessages.MS_LIBELLEMESSAGE + ", PD_SUPPRIMER";
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);

                return DataSet;

              

            }
            if (string.IsNullOrEmpty(Objet.PD_APERCU))
            {
                clsProfilwebdroit.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);

                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = clsMessages.MS_CODEMESSAGE;
                dr["SL_RESULTAT"] = Common.clsDeclaration.ERROR_RESULTAT;
                dr["SL_MESSAGE"] = clsMessages.MS_LIBELLEMESSAGE + ", PD_APERCU";
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);

                return DataSet;

             

            }
            if (string.IsNullOrEmpty(Objet.PD_IMPRIMER))
            {
                clsProfilwebdroit.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = clsMessages.MS_CODEMESSAGE;
                dr["SL_RESULTAT"] = Common.clsDeclaration.ERROR_RESULTAT;
                dr["SL_MESSAGE"] = clsMessages.MS_LIBELLEMESSAGE + ", PD_IMPRIMER";
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);

                return DataSet;
               

            }
            if (string.IsNullOrEmpty(Objet.PD_IMPRIMERTOUT))
            {
                clsProfilwebdroit.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = clsMessages.MS_CODEMESSAGE;
                dr["SL_RESULTAT"] = Common.clsDeclaration.ERROR_RESULTAT;
                dr["SL_MESSAGE"] = clsMessages.MS_LIBELLEMESSAGE + ", PD_IMPRIMERTOUT";
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);

                return DataSet;

            }
            if (string.IsNullOrEmpty(Objet.PD_NUMEROORDRE))
            {
                clsProfilwebdroit.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = clsMessages.MS_CODEMESSAGE;
                dr["SL_RESULTAT"] = Common.clsDeclaration.ERROR_RESULTAT;
                dr["SL_MESSAGE"] = clsMessages.MS_LIBELLEMESSAGE + ", PD_NUMEROORDRE";
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);

                return DataSet;


            }
            if (string.IsNullOrEmpty(Objet.LO_CODELOGICIEL))
            {
                clsProfilwebdroit.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = clsMessages.MS_CODEMESSAGE;
                dr["SL_RESULTAT"] = Common.clsDeclaration.ERROR_RESULTAT;
                dr["SL_MESSAGE"] = clsMessages.MS_LIBELLEMESSAGE + ", LO_CODELOGICIEL";
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);

                return DataSet;

            }
            if (string.IsNullOrEmpty(Objet.OB_RATTACHEA))
            {
                clsProfilwebdroit.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = clsMessages.MS_CODEMESSAGE;
                dr["SL_RESULTAT"] = Common.clsDeclaration.ERROR_RESULTAT;
                dr["SL_MESSAGE"] = clsMessages.MS_LIBELLEMESSAGE + ", OB_RATTACHEA";
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);

                return DataSet;

            }
            else
            {
                clsProfilwebdroit.clsObjetRetour = new Common.clsObjetRetour();
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = "";
                dr["SL_RESULTAT"] = "TRUE";
                dr["SL_MESSAGE"] = "";
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);
                

                return DataSet;


               /* clsProfilwebdroit.clsObjetRetour = new Common.clsObjetRetour();
                clsProfilwebdroit.clsObjetRetour.SL_CODEMESSAGE = "";
                clsProfilwebdroit.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsProfilwebdroit.clsObjetRetour.SL_MESSAGE = "";
                clsProfilwebdroits.Add(clsProfilwebdroit);
                return clsProfilwebdroits;*/

            }


        }

      /*  public List<HT_Stock.BOJ.clsProfilwebdroit> TestChampObligatoireUpdate(HT_Stock.BOJ.clsProfilwebdroit Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsProfilwebdroit> clsProfilwebdroits = new List<HT_Stock.BOJ.clsProfilwebdroit>();
            HT_Stock.BOJ.clsProfilwebdroit clsProfilwebdroit = new HT_Stock.BOJ.clsProfilwebdroit();

            if (string.IsNullOrEmpty(Objet.PO_CODEPROFILWEB))
            {
                clsProfilwebdroit.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsProfilwebdroit.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsProfilwebdroit.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsProfilwebdroit.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PO_CODEPROFILWEB";
                clsProfilwebdroits.Add(clsProfilwebdroit);
                return clsProfilwebdroits;

            }

            if (string.IsNullOrEmpty(Objet.OB_CODEOBJET))
            {
                clsProfilwebdroit.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsProfilwebdroit.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsProfilwebdroit.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsProfilwebdroit.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OB_CODEOBJET";
                clsProfilwebdroits.Add(clsProfilwebdroit);
                return clsProfilwebdroits;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsProfilwebdroit.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsProfilwebdroit.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsProfilwebdroit.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsProfilwebdroits.Add(clsProfilwebdroit);
            //    return clsProfilwebdroits;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsProfilwebdroit.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsProfilwebdroit.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsProfilwebdroit.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsProfilwebdroits.Add(clsProfilwebdroit);
            //    return clsProfilwebdroits;

            //}


            else
            {
                clsProfilwebdroit.clsObjetRetour = new Common.clsObjetRetour();
            clsProfilwebdroit.clsObjetRetour.SL_CODEMESSAGE = "";
            clsProfilwebdroit.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsProfilwebdroit.clsObjetRetour.SL_MESSAGE = "";
            clsProfilwebdroits.Add(clsProfilwebdroit);
            return clsProfilwebdroits;

            }


        }

        public List<HT_Stock.BOJ.clsProfilwebdroit> TestChampObligatoireDelete(HT_Stock.BOJ.clsProfilwebdroit Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsProfilwebdroit> clsProfilwebdroits = new List<HT_Stock.BOJ.clsProfilwebdroit>();
            HT_Stock.BOJ.clsProfilwebdroit clsProfilwebdroit = new HT_Stock.BOJ.clsProfilwebdroit();

            if (string.IsNullOrEmpty(Objet.PO_CODEPROFILWEB))
            {
                clsProfilwebdroit.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsProfilwebdroit.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsProfilwebdroit.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsProfilwebdroit.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PO_CODEPROFILWEB";
                clsProfilwebdroits.Add(clsProfilwebdroit);
                return clsProfilwebdroits;

            }
            else
            {
            clsProfilwebdroit.clsObjetRetour = new Common.clsObjetRetour();
            clsProfilwebdroit.clsObjetRetour.SL_CODEMESSAGE = "";
            clsProfilwebdroit.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsProfilwebdroit.clsObjetRetour.SL_MESSAGE = "";
            clsProfilwebdroits.Add(clsProfilwebdroit);
            return clsProfilwebdroits;

            }


        }*/


    }
}