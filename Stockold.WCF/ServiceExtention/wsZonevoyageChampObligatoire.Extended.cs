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
	public partial class wsZonevoyage
	{

        public List<HT_Stock.BOJ.clsZonevoyage> TestChampObligatoireListe(HT_Stock.BOJ.clsZonevoyage Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsZonevoyage> clsZonevoyages = new List<HT_Stock.BOJ.clsZonevoyage>();
            HT_Stock.BOJ.clsZonevoyage clsZonevoyage = new HT_Stock.BOJ.clsZonevoyage();

            //if (string.IsNullOrEmpty(Objet.ZM_CODEZONEVOYAGE))
            //{
            //    clsZonevoyage.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsZonevoyage.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsZonevoyage.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsZonevoyage.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ZM_CODEZONEVOYAGE";
            //    clsZonevoyages.Add(clsZonevoyage);
            //    return clsZonevoyages;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsZonevoyage.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsZonevoyage.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsZonevoyage.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsZonevoyages.Add(clsZonevoyage);
            //    return clsZonevoyages;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsZonevoyage.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsZonevoyage.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsZonevoyage.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsZonevoyages.Add(clsZonevoyage);
            //    return clsZonevoyages;

            //}


            //else
            //{
                clsZonevoyage.clsObjetRetour = new Common.clsObjetRetour();
                clsZonevoyage.clsObjetRetour.SL_CODEMESSAGE = "";
                clsZonevoyage.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsZonevoyage.clsObjetRetour.SL_MESSAGE = "";
                clsZonevoyages.Add(clsZonevoyage);
                return clsZonevoyages;

            //}


        }

        public List<HT_Stock.BOJ.clsZonevoyage> TestChampObligatoireInsert(HT_Stock.BOJ.clsZonevoyage Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsZonevoyage> clsZonevoyages = new List<HT_Stock.BOJ.clsZonevoyage>();
            HT_Stock.BOJ.clsZonevoyage clsZonevoyage = new HT_Stock.BOJ.clsZonevoyage();

           

            if (string.IsNullOrEmpty(Objet.ZM_NOMZONEVOYAGE))
            {
                clsZonevoyage.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsZonevoyage.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsZonevoyage.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsZonevoyage.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ZM_NOMZONEVOYAGE";
                clsZonevoyages.Add(clsZonevoyage);
                return clsZonevoyages;

            }

            else
            {
                clsZonevoyage.clsObjetRetour = new Common.clsObjetRetour();
                clsZonevoyage.clsObjetRetour.SL_CODEMESSAGE = "";
                clsZonevoyage.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsZonevoyage.clsObjetRetour.SL_MESSAGE = "";
                clsZonevoyages.Add(clsZonevoyage);
                return clsZonevoyages;

            }


        }

        public List<HT_Stock.BOJ.clsZonevoyage> TestChampObligatoireUpdate(HT_Stock.BOJ.clsZonevoyage Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsZonevoyage> clsZonevoyages = new List<HT_Stock.BOJ.clsZonevoyage>();
            HT_Stock.BOJ.clsZonevoyage clsZonevoyage = new HT_Stock.BOJ.clsZonevoyage();

            if (string.IsNullOrEmpty(Objet.ZM_CODEZONEVOYAGE))
            {
                clsZonevoyage.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsZonevoyage.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsZonevoyage.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsZonevoyage.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ZM_CODEZONEVOYAGE";
                clsZonevoyages.Add(clsZonevoyage);
                return clsZonevoyages;

            }

            if (string.IsNullOrEmpty(Objet.ZM_NOMZONEVOYAGE))
            {
                clsZonevoyage.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsZonevoyage.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsZonevoyage.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsZonevoyage.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ZM_NOMZONEVOYAGE";
                clsZonevoyages.Add(clsZonevoyage);
                return clsZonevoyages;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsZonevoyage.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsZonevoyage.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsZonevoyage.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsZonevoyages.Add(clsZonevoyage);
            //    return clsZonevoyages;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsZonevoyage.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsZonevoyage.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsZonevoyage.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsZonevoyages.Add(clsZonevoyage);
            //    return clsZonevoyages;

            //}


            else
            {
                clsZonevoyage.clsObjetRetour = new Common.clsObjetRetour();
            clsZonevoyage.clsObjetRetour.SL_CODEMESSAGE = "";
            clsZonevoyage.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsZonevoyage.clsObjetRetour.SL_MESSAGE = "";
            clsZonevoyages.Add(clsZonevoyage);
            return clsZonevoyages;

            }


        }

        public List<HT_Stock.BOJ.clsZonevoyage> TestChampObligatoireDelete(HT_Stock.BOJ.clsZonevoyage Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsZonevoyage> clsZonevoyages = new List<HT_Stock.BOJ.clsZonevoyage>();
            HT_Stock.BOJ.clsZonevoyage clsZonevoyage = new HT_Stock.BOJ.clsZonevoyage();

            if (string.IsNullOrEmpty(Objet.ZM_CODEZONEVOYAGE))
            {
                clsZonevoyage.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsZonevoyage.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsZonevoyage.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsZonevoyage.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ZM_CODEZONEVOYAGE";
                clsZonevoyages.Add(clsZonevoyage);
                return clsZonevoyages;

            }
            else
            {
            clsZonevoyage.clsObjetRetour = new Common.clsObjetRetour();
            clsZonevoyage.clsObjetRetour.SL_CODEMESSAGE = "";
            clsZonevoyage.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsZonevoyage.clsObjetRetour.SL_MESSAGE = "";
            clsZonevoyages.Add(clsZonevoyage);
            return clsZonevoyages;

            }


        }


    }
}