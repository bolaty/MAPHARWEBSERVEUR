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
	public partial class wsProfilwebdroitagence
	{

        public DataSet TestChampObligatoireListe(HT_Stock.BOJ.clsProfilwebdroitagence Objet)
        {
            DataSet DataSet = new DataSet();
            DataTable dt = new DataTable("TABLE");
            dt.Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsProfilwebdroitagence> clsProfilwebdroitagences = new List<HT_Stock.BOJ.clsProfilwebdroitagence>();
            HT_Stock.BOJ.clsProfilwebdroitagence clsProfilwebdroitagence = new HT_Stock.BOJ.clsProfilwebdroitagence();

          /*  if (string.IsNullOrEmpty(Objet.PO_CODEPROFILWEB))
            {
                clsProfilwebdroitagence.clsObjetRetour = new Common.clsObjetRetour();
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

            }*/


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsProfilwebdroitagence.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsProfilwebdroitagence.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsProfilwebdroitagence.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsProfilwebdroitagences.Add(clsProfilwebdroitagence);
            //    return clsProfilwebdroitagences;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsProfilwebdroitagence.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsProfilwebdroitagence.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsProfilwebdroitagence.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsProfilwebdroitagences.Add(clsProfilwebdroitagence);
            //    return clsProfilwebdroitagences;

            //}


          //  else
          //  {
                clsProfilwebdroitagence.clsObjetRetour = new Common.clsObjetRetour();
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = "";
                dr["SL_RESULTAT"] = "TRUE";
                dr["SL_MESSAGE"] = "";
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);


                return DataSet;

           // }


        }

        public DataSet TestChampObligatoireInsert(HT_Stock.BOJ.clsProfilwebdroitagence Objet)
        {

            DataSet DataSet = new DataSet();
            DataTable dt = new DataTable("TABLE");
            dt.Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsProfilwebdroitagence> clsProfilwebdroitagences = new List<HT_Stock.BOJ.clsProfilwebdroitagence>();
            HT_Stock.BOJ.clsProfilwebdroitagence clsProfilwebdroitagence = new HT_Stock.BOJ.clsProfilwebdroitagence();

           

            if (string.IsNullOrEmpty(Objet.PO_CODEPROFILWEB))
            {
                clsProfilwebdroitagence.clsObjetRetour = new Common.clsObjetRetour();
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
                clsProfilwebdroitagence.clsObjetRetour = new Common.clsObjetRetour();
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

     /*   public List<HT_Stock.BOJ.clsProfilwebdroitagence> TestChampObligatoireUpdate(HT_Stock.BOJ.clsProfilwebdroitagence Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsProfilwebdroitagence> clsProfilwebdroitagences = new List<HT_Stock.BOJ.clsProfilwebdroitagence>();
            HT_Stock.BOJ.clsProfilwebdroitagence clsProfilwebdroitagence = new HT_Stock.BOJ.clsProfilwebdroitagence();

            //if (string.IsNullOrEmpty(Objet.AC_CODEProfilwebdroitagence))
            //{
            //    clsProfilwebdroitagence.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsProfilwebdroitagence.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsProfilwebdroitagence.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsProfilwebdroitagence.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AC_CODEProfilwebdroitagence";
            //    clsProfilwebdroitagences.Add(clsProfilwebdroitagence);
            //    return clsProfilwebdroitagences;

            //}

            if (string.IsNullOrEmpty(Objet.PO_CODEPROFILWEB))
            {
                clsProfilwebdroitagence.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsProfilwebdroitagence.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsProfilwebdroitagence.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsProfilwebdroitagence.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PO_CODEPROFILWEB";
                clsProfilwebdroitagences.Add(clsProfilwebdroitagence);
                return clsProfilwebdroitagences;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsProfilwebdroitagence.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsProfilwebdroitagence.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsProfilwebdroitagence.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsProfilwebdroitagences.Add(clsProfilwebdroitagence);
            //    return clsProfilwebdroitagences;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsProfilwebdroitagence.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsProfilwebdroitagence.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsProfilwebdroitagence.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsProfilwebdroitagences.Add(clsProfilwebdroitagence);
            //    return clsProfilwebdroitagences;

            //}


            else
            {
                clsProfilwebdroitagence.clsObjetRetour = new Common.clsObjetRetour();
            clsProfilwebdroitagence.clsObjetRetour.SL_CODEMESSAGE = "";
            clsProfilwebdroitagence.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsProfilwebdroitagence.clsObjetRetour.SL_MESSAGE = "";
            clsProfilwebdroitagences.Add(clsProfilwebdroitagence);
            return clsProfilwebdroitagences;

            }


        }*/

      /*  public List<HT_Stock.BOJ.clsProfilwebdroitagence> TestChampObligatoireDelete(HT_Stock.BOJ.clsProfilwebdroitagence Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsProfilwebdroitagence> clsProfilwebdroitagences = new List<HT_Stock.BOJ.clsProfilwebdroitagence>();
            HT_Stock.BOJ.clsProfilwebdroitagence clsProfilwebdroitagence = new HT_Stock.BOJ.clsProfilwebdroitagence();

            if (string.IsNullOrEmpty(Objet.AC_CODEProfilwebdroitagence))
            {
                clsProfilwebdroitagence.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsProfilwebdroitagence.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsProfilwebdroitagence.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsProfilwebdroitagence.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AC_CODEProfilwebdroitagence";
                clsProfilwebdroitagences.Add(clsProfilwebdroitagence);
                return clsProfilwebdroitagences;

            }
            else
            {
            clsProfilwebdroitagence.clsObjetRetour = new Common.clsObjetRetour();
            clsProfilwebdroitagence.clsObjetRetour.SL_CODEMESSAGE = "";
            clsProfilwebdroitagence.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsProfilwebdroitagence.clsObjetRetour.SL_MESSAGE = "";
            clsProfilwebdroitagences.Add(clsProfilwebdroitagence);
            return clsProfilwebdroitagences;

            }


        }*/


    }
}