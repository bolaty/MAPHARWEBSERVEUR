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
	public partial class wsLogicielobjettypeoperationprofilweb
	{

        public DataSet TestChampObligatoireListe(HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb Objet)
        {

            DataSet DataSet = new DataSet();
            DataTable dt = new DataTable("TABLE");
            dt.Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb> clsLogicielobjettypeoperationprofilwebs = new List<HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb>();
            HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb clsLogicielobjettypeoperationprofilweb = new HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb();

            if (string.IsNullOrEmpty(Objet.PO_CODEPROFILWEB))
            {
                clsLogicielobjettypeoperationprofilweb.clsObjetRetour = new Common.clsObjetRetour();
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



            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsLogicielobjettypeoperationprofilweb.clsObjetRetour = new Common.clsObjetRetour();
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

            if (string.IsNullOrEmpty(Objet.NF_CODENATUREFAMILLEOPERATION))
            {
                clsLogicielobjettypeoperationprofilweb.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = clsMessages.MS_CODEMESSAGE;
                dr["SL_RESULTAT"] = Common.clsDeclaration.ERROR_RESULTAT;
                dr["SL_MESSAGE"] = clsMessages.MS_LIBELLEMESSAGE + ", NF_CODENATUREFAMILLEOPERATION";
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);

                return DataSet;

            }

            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsLogicielobjettypeoperationprofilweb.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsLogicielobjettypeoperationprofilweb.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsLogicielobjettypeoperationprofilweb.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsLogicielobjettypeoperationprofilwebs.Add(clsLogicielobjettypeoperationprofilweb);
            //    return clsLogicielobjettypeoperationprofilwebs;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsLogicielobjettypeoperationprofilweb.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsLogicielobjettypeoperationprofilweb.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsLogicielobjettypeoperationprofilweb.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsLogicielobjettypeoperationprofilwebs.Add(clsLogicielobjettypeoperationprofilweb);
            //    return clsLogicielobjettypeoperationprofilwebs;

            //}


            else
            {
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

        public DataSet TestChampObligatoireInsert(HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb Objet)
        {

            DataSet DataSet = new DataSet();
            DataTable dt = new DataTable("TABLE");
            dt.Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb> clsLogicielobjettypeoperationprofilwebs = new List<HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb>();
            HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb clsLogicielobjettypeoperationprofilweb = new HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb();

           

            if (string.IsNullOrEmpty(Objet.PO_CODEPROFILWEB))
            {
                clsLogicielobjettypeoperationprofilweb.clsObjetRetour = new Common.clsObjetRetour();
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
            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsLogicielobjettypeoperationprofilweb.clsObjetRetour = new Common.clsObjetRetour();
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
            if (string.IsNullOrEmpty(Objet.FO_CODEFAMILLEOPERATION))
            {
                clsLogicielobjettypeoperationprofilweb.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = clsMessages.MS_CODEMESSAGE;
                dr["SL_RESULTAT"] = Common.clsDeclaration.ERROR_RESULTAT;
                dr["SL_MESSAGE"] = clsMessages.MS_LIBELLEMESSAGE + ", FO_CODEFAMILLEOPERATION";
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);

                return DataSet;

            }
            if (string.IsNullOrEmpty(Objet.NF_CODENATUREFAMILLEOPERATION))
            {
                clsLogicielobjettypeoperationprofilweb.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = clsMessages.MS_CODEMESSAGE;
                dr["SL_RESULTAT"] = Common.clsDeclaration.ERROR_RESULTAT;
                dr["SL_MESSAGE"] = clsMessages.MS_LIBELLEMESSAGE + ", NF_CODENATUREFAMILLEOPERATION";
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);

                return DataSet;

            }
            else
            {
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

     /*   public List<HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb> TestChampObligatoireUpdate(HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb> clsLogicielobjettypeoperationprofilwebs = new List<HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb>();
            HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb clsLogicielobjettypeoperationprofilweb = new HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb();

            //if (string.IsNullOrEmpty(Objet.AC_CODELogicielobjettypeoperationprofilweb))
            //{
            //    clsLogicielobjettypeoperationprofilweb.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsLogicielobjettypeoperationprofilweb.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsLogicielobjettypeoperationprofilweb.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsLogicielobjettypeoperationprofilweb.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AC_CODELogicielobjettypeoperationprofilweb";
            //    clsLogicielobjettypeoperationprofilwebs.Add(clsLogicielobjettypeoperationprofilweb);
            //    return clsLogicielobjettypeoperationprofilwebs;

            //}

            if (string.IsNullOrEmpty(Objet.PO_CODEPROFILWEB))
            {
                clsLogicielobjettypeoperationprofilweb.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsLogicielobjettypeoperationprofilweb.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsLogicielobjettypeoperationprofilweb.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsLogicielobjettypeoperationprofilweb.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PO_CODEPROFILWEB";
                clsLogicielobjettypeoperationprofilwebs.Add(clsLogicielobjettypeoperationprofilweb);
                return clsLogicielobjettypeoperationprofilwebs;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsLogicielobjettypeoperationprofilweb.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsLogicielobjettypeoperationprofilweb.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsLogicielobjettypeoperationprofilweb.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsLogicielobjettypeoperationprofilwebs.Add(clsLogicielobjettypeoperationprofilweb);
            //    return clsLogicielobjettypeoperationprofilwebs;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsLogicielobjettypeoperationprofilweb.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsLogicielobjettypeoperationprofilweb.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsLogicielobjettypeoperationprofilweb.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsLogicielobjettypeoperationprofilwebs.Add(clsLogicielobjettypeoperationprofilweb);
            //    return clsLogicielobjettypeoperationprofilwebs;

            //}


            else
            {
                clsLogicielobjettypeoperationprofilweb.clsObjetRetour = new Common.clsObjetRetour();
            clsLogicielobjettypeoperationprofilweb.clsObjetRetour.SL_CODEMESSAGE = "";
            clsLogicielobjettypeoperationprofilweb.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsLogicielobjettypeoperationprofilweb.clsObjetRetour.SL_MESSAGE = "";
            clsLogicielobjettypeoperationprofilwebs.Add(clsLogicielobjettypeoperationprofilweb);
            return clsLogicielobjettypeoperationprofilwebs;

            }


        }*/

      /*  public List<HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb> TestChampObligatoireDelete(HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb> clsLogicielobjettypeoperationprofilwebs = new List<HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb>();
            HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb clsLogicielobjettypeoperationprofilweb = new HT_Stock.BOJ.clsLogicielobjettypeoperationprofilweb();

            if (string.IsNullOrEmpty(Objet.AC_CODELogicielobjettypeoperationprofilweb))
            {
                clsLogicielobjettypeoperationprofilweb.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsLogicielobjettypeoperationprofilweb.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsLogicielobjettypeoperationprofilweb.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsLogicielobjettypeoperationprofilweb.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AC_CODELogicielobjettypeoperationprofilweb";
                clsLogicielobjettypeoperationprofilwebs.Add(clsLogicielobjettypeoperationprofilweb);
                return clsLogicielobjettypeoperationprofilwebs;

            }
            else
            {
            clsLogicielobjettypeoperationprofilweb.clsObjetRetour = new Common.clsObjetRetour();
            clsLogicielobjettypeoperationprofilweb.clsObjetRetour.SL_CODEMESSAGE = "";
            clsLogicielobjettypeoperationprofilweb.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsLogicielobjettypeoperationprofilweb.clsObjetRetour.SL_MESSAGE = "";
            clsLogicielobjettypeoperationprofilwebs.Add(clsLogicielobjettypeoperationprofilweb);
            return clsLogicielobjettypeoperationprofilwebs;

            }


        }*/


    }
}