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
	public partial class wsProfilwebdroitsaisieentrepot
	{

        public DataSet TestChampObligatoireListe(HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot Objet)
        {
            DataSet DataSet = new DataSet();
            DataTable dt = new DataTable("TABLE");
            dt.Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot> clsProfilwebdroitsaisieentrepots = new List<HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot>();
            HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot clsProfilwebdroitsaisieentrepot = new HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot();

         /*   if (string.IsNullOrEmpty(Objet.PO_CODEPROFILWEB))
            {
                clsProfilwebdroitsaisieentrepot.clsObjetRetour = new Common.clsObjetRetour();
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
            //    clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsProfilwebdroitsaisieentrepots.Add(clsProfilwebdroitsaisieentrepot);
            //    return clsProfilwebdroitsaisieentrepots;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsProfilwebdroitsaisieentrepots.Add(clsProfilwebdroitsaisieentrepot);
            //    return clsProfilwebdroitsaisieentrepots;

            //}


          //  else
          //  {
                clsProfilwebdroitsaisieentrepot.clsObjetRetour = new Common.clsObjetRetour();
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = "";
                dr["SL_RESULTAT"] = "TRUE";
                dr["SL_MESSAGE"] = "";
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);
                return DataSet;

          //  }


        }

        public DataSet TestChampObligatoireInsert(HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot Objet)
        {

            DataSet DataSet = new DataSet();
            DataTable dt = new DataTable("TABLE");
            dt.Columns.Add(new DataColumn("SL_CODEMESSAGE", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_RESULTAT", typeof(string)));
            dt.Columns.Add(new DataColumn("SL_MESSAGE", typeof(string)));


            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot> clsProfilwebdroitsaisieentrepots = new List<HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot>();
            HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot clsProfilwebdroitsaisieentrepot = new HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot();

           

            if (string.IsNullOrEmpty(Objet.PO_CODEPROFILWEB))
            {
                clsProfilwebdroitsaisieentrepot.clsObjetRetour = new Common.clsObjetRetour();
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
            if (string.IsNullOrEmpty(Objet.EN_CODEENTREPOT))
            {
                clsProfilwebdroitsaisieentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = clsMessages.MS_CODEMESSAGE;
                dr["SL_RESULTAT"] = Common.clsDeclaration.ERROR_RESULTAT;
                dr["SL_MESSAGE"] = clsMessages.MS_LIBELLEMESSAGE + ", EN_CODEENTREPOT";
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);

                return DataSet;

            }
            if (string.IsNullOrEmpty(Objet.COCHER))
            {
                clsProfilwebdroitsaisieentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                DataRow dr = dt.NewRow();
                dr["SL_CODEMESSAGE"] = clsMessages.MS_CODEMESSAGE;
                dr["SL_RESULTAT"] = Common.clsDeclaration.ERROR_RESULTAT;
                dr["SL_MESSAGE"] = clsMessages.MS_LIBELLEMESSAGE + ", COCHER";
                dt.Rows.Add(dr);
                DataSet.Tables.Add(dt);

                return DataSet;

            }
            else
            {
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

     /*   public List<HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot> TestChampObligatoireUpdate(HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot> clsProfilwebdroitsaisieentrepots = new List<HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot>();
            HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot clsProfilwebdroitsaisieentrepot = new HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot();

            //if (string.IsNullOrEmpty(Objet.AC_CODEProfilwebdroitsaisieentrepot))
            //{
            //    clsProfilwebdroitsaisieentrepot.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AC_CODEProfilwebdroitsaisieentrepot";
            //    clsProfilwebdroitsaisieentrepots.Add(clsProfilwebdroitsaisieentrepot);
            //    return clsProfilwebdroitsaisieentrepots;

            //}

            if (string.IsNullOrEmpty(Objet.PO_CODEPROFILWEB))
            {
                clsProfilwebdroitsaisieentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PO_CODEPROFILWEB";
                clsProfilwebdroitsaisieentrepots.Add(clsProfilwebdroitsaisieentrepot);
                return clsProfilwebdroitsaisieentrepots;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsProfilwebdroitsaisieentrepots.Add(clsProfilwebdroitsaisieentrepot);
            //    return clsProfilwebdroitsaisieentrepots;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsProfilwebdroitsaisieentrepots.Add(clsProfilwebdroitsaisieentrepot);
            //    return clsProfilwebdroitsaisieentrepots;

            //}


            else
            {
                clsProfilwebdroitsaisieentrepot.clsObjetRetour = new Common.clsObjetRetour();
            clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_CODEMESSAGE = "";
            clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_MESSAGE = "";
            clsProfilwebdroitsaisieentrepots.Add(clsProfilwebdroitsaisieentrepot);
            return clsProfilwebdroitsaisieentrepots;

            }


        }*/

      /*  public List<HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot> TestChampObligatoireDelete(HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot> clsProfilwebdroitsaisieentrepots = new List<HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot>();
            HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot clsProfilwebdroitsaisieentrepot = new HT_Stock.BOJ.clsProfilwebdroitsaisieentrepot();

            if (string.IsNullOrEmpty(Objet.AC_CODEProfilwebdroitsaisieentrepot))
            {
                clsProfilwebdroitsaisieentrepot.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AC_CODEProfilwebdroitsaisieentrepot";
                clsProfilwebdroitsaisieentrepots.Add(clsProfilwebdroitsaisieentrepot);
                return clsProfilwebdroitsaisieentrepots;

            }
            else
            {
            clsProfilwebdroitsaisieentrepot.clsObjetRetour = new Common.clsObjetRetour();
            clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_CODEMESSAGE = "";
            clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsProfilwebdroitsaisieentrepot.clsObjetRetour.SL_MESSAGE = "";
            clsProfilwebdroitsaisieentrepots.Add(clsProfilwebdroitsaisieentrepot);
            return clsProfilwebdroitsaisieentrepots;

            }


        }*/


    }
}