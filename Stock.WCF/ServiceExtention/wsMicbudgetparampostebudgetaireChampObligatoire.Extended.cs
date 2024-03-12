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
	public partial class wsMicbudgetparampostebudgetaire
	{

        public List<HT_Stock.BOJ.clsMicbudgetparampostebudgetaire> TestChampObligatoireListe(HT_Stock.BOJ.clsMicbudgetparampostebudgetaire Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsMicbudgetparampostebudgetaire> clsMicbudgetparampostebudgetaires = new List<HT_Stock.BOJ.clsMicbudgetparampostebudgetaire>();
            HT_Stock.BOJ.clsMicbudgetparampostebudgetaire clsMicbudgetparampostebudgetaire = new HT_Stock.BOJ.clsMicbudgetparampostebudgetaire();

            //if (string.IsNullOrEmpty(Objet.BG_CODEPOSTEBUDGETAIRE))
            //{
            //    clsMicbudgetparampostebudgetaire.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", BG_CODEPOSTEBUDGETAIRE";
            //    clsMicbudgetparampostebudgetaires.Add(clsMicbudgetparampostebudgetaire);
            //    return clsMicbudgetparampostebudgetaires;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsMicbudgetparampostebudgetaires.Add(clsMicbudgetparampostebudgetaire);
            //    return clsMicbudgetparampostebudgetaires;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsMicbudgetparampostebudgetaires.Add(clsMicbudgetparampostebudgetaire);
            //    return clsMicbudgetparampostebudgetaires;

            //}


            //else
            //{
                clsMicbudgetparampostebudgetaire.clsObjetRetour = new Common.clsObjetRetour();
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_CODEMESSAGE = "";
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_MESSAGE = "";
                clsMicbudgetparampostebudgetaires.Add(clsMicbudgetparampostebudgetaire);
                return clsMicbudgetparampostebudgetaires;

            //}


        }

        public List<HT_Stock.BOJ.clsMicbudgetparampostebudgetaire> TestChampObligatoireInsert(HT_Stock.BOJ.clsMicbudgetparampostebudgetaire Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsMicbudgetparampostebudgetaire> clsMicbudgetparampostebudgetaires = new List<HT_Stock.BOJ.clsMicbudgetparampostebudgetaire>();
            HT_Stock.BOJ.clsMicbudgetparampostebudgetaire clsMicbudgetparampostebudgetaire = new HT_Stock.BOJ.clsMicbudgetparampostebudgetaire();

           

            if (string.IsNullOrEmpty(Objet.BG_LIBELLE))
            {
                clsMicbudgetparampostebudgetaire.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", BG_LIBELLE";
                clsMicbudgetparampostebudgetaires.Add(clsMicbudgetparampostebudgetaire);
                return clsMicbudgetparampostebudgetaires;

            }
           else if (string.IsNullOrEmpty(Objet.BT_CODETYPEBUDGET))
            {
                clsMicbudgetparampostebudgetaire.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", BT_CODETYPEBUDGET";
                clsMicbudgetparampostebudgetaires.Add(clsMicbudgetparampostebudgetaire);
                return clsMicbudgetparampostebudgetaires;

            }
            else if (string.IsNullOrEmpty(Objet.BD_CODETYPEBUDGETDETAIL))
            {
                clsMicbudgetparampostebudgetaire.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", BD_CODETYPEBUDGETDETAIL";
                clsMicbudgetparampostebudgetaires.Add(clsMicbudgetparampostebudgetaire);
                return clsMicbudgetparampostebudgetaires;

            }
            else if (string.IsNullOrEmpty(Objet.BN_CODENATUREPOSTEBUDGETAIRE))
            {
                clsMicbudgetparampostebudgetaire.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", BN_CODENATUREPOSTEBUDGETAIRE";
                clsMicbudgetparampostebudgetaires.Add(clsMicbudgetparampostebudgetaire);
                return clsMicbudgetparampostebudgetaires;

            }
            else if (string.IsNullOrEmpty(Objet.SR_CODESERVICE))
            {
                clsMicbudgetparampostebudgetaire.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SR_CODESERVICE";
                clsMicbudgetparampostebudgetaires.Add(clsMicbudgetparampostebudgetaire);
                return clsMicbudgetparampostebudgetaires;

            }
            else
            {
                clsMicbudgetparampostebudgetaire.clsObjetRetour = new Common.clsObjetRetour();
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_CODEMESSAGE = "";
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_MESSAGE = "";
                clsMicbudgetparampostebudgetaires.Add(clsMicbudgetparampostebudgetaire);
                return clsMicbudgetparampostebudgetaires;

            }


        }

        public List<HT_Stock.BOJ.clsMicbudgetparampostebudgetaire> TestChampObligatoireUpdate(HT_Stock.BOJ.clsMicbudgetparampostebudgetaire Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsMicbudgetparampostebudgetaire> clsMicbudgetparampostebudgetaires = new List<HT_Stock.BOJ.clsMicbudgetparampostebudgetaire>();
            HT_Stock.BOJ.clsMicbudgetparampostebudgetaire clsMicbudgetparampostebudgetaire = new HT_Stock.BOJ.clsMicbudgetparampostebudgetaire();

            if (string.IsNullOrEmpty(Objet.BG_CODEPOSTEBUDGETAIRE))
            {
                clsMicbudgetparampostebudgetaire.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", BG_CODEPOSTEBUDGETAIRE";
                clsMicbudgetparampostebudgetaires.Add(clsMicbudgetparampostebudgetaire);
                return clsMicbudgetparampostebudgetaires;

            }
            if (string.IsNullOrEmpty(Objet.BG_LIBELLE))
            {
                clsMicbudgetparampostebudgetaire.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", BG_LIBELLE";
                clsMicbudgetparampostebudgetaires.Add(clsMicbudgetparampostebudgetaire);
                return clsMicbudgetparampostebudgetaires;

            }
            else if (string.IsNullOrEmpty(Objet.BT_CODETYPEBUDGET))
            {
                clsMicbudgetparampostebudgetaire.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", BT_CODETYPEBUDGET";
                clsMicbudgetparampostebudgetaires.Add(clsMicbudgetparampostebudgetaire);
                return clsMicbudgetparampostebudgetaires;

            }
            else if (string.IsNullOrEmpty(Objet.BD_CODETYPEBUDGETDETAIL))
            {
                clsMicbudgetparampostebudgetaire.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", BD_CODETYPEBUDGETDETAIL";
                clsMicbudgetparampostebudgetaires.Add(clsMicbudgetparampostebudgetaire);
                return clsMicbudgetparampostebudgetaires;

            }
            else if (string.IsNullOrEmpty(Objet.BN_CODENATUREPOSTEBUDGETAIRE))
            {
                clsMicbudgetparampostebudgetaire.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", BN_CODENATUREPOSTEBUDGETAIRE";
                clsMicbudgetparampostebudgetaires.Add(clsMicbudgetparampostebudgetaire);
                return clsMicbudgetparampostebudgetaires;

            }
            else if (string.IsNullOrEmpty(Objet.SR_CODESERVICE))
            {
                clsMicbudgetparampostebudgetaire.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SR_CODESERVICE";
                clsMicbudgetparampostebudgetaires.Add(clsMicbudgetparampostebudgetaire);
                return clsMicbudgetparampostebudgetaires;

            }
            if (string.IsNullOrEmpty(Objet.BG_LIBELLE))
            {
                clsMicbudgetparampostebudgetaire.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", BG_LIBELLE";
                clsMicbudgetparampostebudgetaires.Add(clsMicbudgetparampostebudgetaire);
                return clsMicbudgetparampostebudgetaires;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsMicbudgetparampostebudgetaires.Add(clsMicbudgetparampostebudgetaire);
            //    return clsMicbudgetparampostebudgetaires;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsMicbudgetparampostebudgetaires.Add(clsMicbudgetparampostebudgetaire);
            //    return clsMicbudgetparampostebudgetaires;

            //}


            else
            {
                clsMicbudgetparampostebudgetaire.clsObjetRetour = new Common.clsObjetRetour();
            clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_CODEMESSAGE = "";
            clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_MESSAGE = "";
            clsMicbudgetparampostebudgetaires.Add(clsMicbudgetparampostebudgetaire);
            return clsMicbudgetparampostebudgetaires;

            }


        }

        public List<HT_Stock.BOJ.clsMicbudgetparampostebudgetaire> TestChampObligatoireDelete(HT_Stock.BOJ.clsMicbudgetparampostebudgetaire Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsMicbudgetparampostebudgetaire> clsMicbudgetparampostebudgetaires = new List<HT_Stock.BOJ.clsMicbudgetparampostebudgetaire>();
            HT_Stock.BOJ.clsMicbudgetparampostebudgetaire clsMicbudgetparampostebudgetaire = new HT_Stock.BOJ.clsMicbudgetparampostebudgetaire();

            if (string.IsNullOrEmpty(Objet.BG_CODEPOSTEBUDGETAIRE))
            {
                clsMicbudgetparampostebudgetaire.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", BG_CODEPOSTEBUDGETAIRE";
                clsMicbudgetparampostebudgetaires.Add(clsMicbudgetparampostebudgetaire);
                return clsMicbudgetparampostebudgetaires;

            }
            else
            {
            clsMicbudgetparampostebudgetaire.clsObjetRetour = new Common.clsObjetRetour();
            clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_CODEMESSAGE = "";
            clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsMicbudgetparampostebudgetaire.clsObjetRetour.SL_MESSAGE = "";
            clsMicbudgetparampostebudgetaires.Add(clsMicbudgetparampostebudgetaire);
            return clsMicbudgetparampostebudgetaires;

            }


        }


    }
}