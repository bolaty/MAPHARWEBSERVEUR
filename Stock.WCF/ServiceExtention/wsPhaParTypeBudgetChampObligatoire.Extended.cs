using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Stock.Common;
using Stock.BOJ;
using Stock.WSBLL;
using Stock.WSTOOLS;

namespace Stock.WCF
{
	public partial class wsPhaParTypeBudget
	{

        public List<HT_Stock.BOJ.clsMicbudgetparamtype> TestChampObligatoireListe(HT_Stock.BOJ.clsMicbudgetparamtype Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsMicbudgetparamtype> clsMicbudgetparamtypes = new List<HT_Stock.BOJ.clsMicbudgetparamtype>();
            HT_Stock.BOJ.clsMicbudgetparamtype clsMicbudgetparamtype = new HT_Stock.BOJ.clsMicbudgetparamtype();

            //if (string.IsNullOrEmpty(Objet.BT_CODETYPEBUDGET))
            //{
            //    clsMicbudgetparamtype.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsMicbudgetparamtype.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsMicbudgetparamtype.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsMicbudgetparamtype.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", BT_CODETYPEBUDGET";
            //    clsMicbudgetparamtypes.Add(clsMicbudgetparamtype);
            //    return clsMicbudgetparamtypes;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsMicbudgetparamtype.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsMicbudgetparamtype.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsMicbudgetparamtype.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsMicbudgetparamtypes.Add(clsMicbudgetparamtype);
            //    return clsMicbudgetparamtypes;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsMicbudgetparamtype.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsMicbudgetparamtype.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsMicbudgetparamtype.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsMicbudgetparamtypes.Add(clsMicbudgetparamtype);
            //    return clsMicbudgetparamtypes;

            //}


            //else
            //{
                clsMicbudgetparamtype.clsObjetRetour = new Common.clsObjetRetour();
                clsMicbudgetparamtype.clsObjetRetour.SL_CODEMESSAGE = "";
                clsMicbudgetparamtype.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsMicbudgetparamtype.clsObjetRetour.SL_MESSAGE = "";
                clsMicbudgetparamtypes.Add(clsMicbudgetparamtype);
                return clsMicbudgetparamtypes;

            //}


        }

        public List<HT_Stock.BOJ.clsMicbudgetparamtype> TestChampObligatoireInsert(HT_Stock.BOJ.clsMicbudgetparamtype Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsMicbudgetparamtype> clsMicbudgetparamtypes = new List<HT_Stock.BOJ.clsMicbudgetparamtype>();
            HT_Stock.BOJ.clsMicbudgetparamtype clsMicbudgetparamtype = new HT_Stock.BOJ.clsMicbudgetparamtype();

           

            if (string.IsNullOrEmpty(Objet.BT_LIBELLE))
            {
                clsMicbudgetparamtype.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMicbudgetparamtype.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMicbudgetparamtype.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMicbudgetparamtype.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", BT_LIBELLE";
                clsMicbudgetparamtypes.Add(clsMicbudgetparamtype);
                return clsMicbudgetparamtypes;

            }

            else
            {
                clsMicbudgetparamtype.clsObjetRetour = new Common.clsObjetRetour();
                clsMicbudgetparamtype.clsObjetRetour.SL_CODEMESSAGE = "";
                clsMicbudgetparamtype.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsMicbudgetparamtype.clsObjetRetour.SL_MESSAGE = "";
                clsMicbudgetparamtypes.Add(clsMicbudgetparamtype);
                return clsMicbudgetparamtypes;

            }


        }

        public List<HT_Stock.BOJ.clsMicbudgetparamtype> TestChampObligatoireUpdate(HT_Stock.BOJ.clsMicbudgetparamtype Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsMicbudgetparamtype> clsMicbudgetparamtypes = new List<HT_Stock.BOJ.clsMicbudgetparamtype>();
            HT_Stock.BOJ.clsMicbudgetparamtype clsMicbudgetparamtype = new HT_Stock.BOJ.clsMicbudgetparamtype();

            if (string.IsNullOrEmpty(Objet.BT_CODETYPEBUDGET))
            {
                clsMicbudgetparamtype.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMicbudgetparamtype.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMicbudgetparamtype.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMicbudgetparamtype.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", BT_CODETYPEBUDGET";
                clsMicbudgetparamtypes.Add(clsMicbudgetparamtype);
                return clsMicbudgetparamtypes;

            }

            if (string.IsNullOrEmpty(Objet.BT_LIBELLE))
            {
                clsMicbudgetparamtype.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMicbudgetparamtype.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMicbudgetparamtype.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMicbudgetparamtype.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", BT_LIBELLE";
                clsMicbudgetparamtypes.Add(clsMicbudgetparamtype);
                return clsMicbudgetparamtypes;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsMicbudgetparamtype.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsMicbudgetparamtype.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsMicbudgetparamtype.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsMicbudgetparamtypes.Add(clsMicbudgetparamtype);
            //    return clsMicbudgetparamtypes;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsMicbudgetparamtype.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsMicbudgetparamtype.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsMicbudgetparamtype.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsMicbudgetparamtypes.Add(clsMicbudgetparamtype);
            //    return clsMicbudgetparamtypes;

            //}


            else
            {
                clsMicbudgetparamtype.clsObjetRetour = new Common.clsObjetRetour();
            clsMicbudgetparamtype.clsObjetRetour.SL_CODEMESSAGE = "";
            clsMicbudgetparamtype.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsMicbudgetparamtype.clsObjetRetour.SL_MESSAGE = "";
            clsMicbudgetparamtypes.Add(clsMicbudgetparamtype);
            return clsMicbudgetparamtypes;

            }


        }

        public List<HT_Stock.BOJ.clsMicbudgetparamtype> TestChampObligatoireDelete(HT_Stock.BOJ.clsMicbudgetparamtype Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsMicbudgetparamtype> clsMicbudgetparamtypes = new List<HT_Stock.BOJ.clsMicbudgetparamtype>();
            HT_Stock.BOJ.clsMicbudgetparamtype clsMicbudgetparamtype = new HT_Stock.BOJ.clsMicbudgetparamtype();

            if (string.IsNullOrEmpty(Objet.BT_CODETYPEBUDGET))
            {
                clsMicbudgetparamtype.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMicbudgetparamtype.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMicbudgetparamtype.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMicbudgetparamtype.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", BT_CODETYPEBUDGET";
                clsMicbudgetparamtypes.Add(clsMicbudgetparamtype);
                return clsMicbudgetparamtypes;

            }
            else
            {
            clsMicbudgetparamtype.clsObjetRetour = new Common.clsObjetRetour();
            clsMicbudgetparamtype.clsObjetRetour.SL_CODEMESSAGE = "";
            clsMicbudgetparamtype.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsMicbudgetparamtype.clsObjetRetour.SL_MESSAGE = "";
            clsMicbudgetparamtypes.Add(clsMicbudgetparamtype);
            return clsMicbudgetparamtypes;

            }


        }


    }
}