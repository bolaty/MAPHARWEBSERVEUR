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
	public partial class wsModereglement
	{

        public List<HT_Stock.BOJ.clsModereglement> TestChampObligatoireListe(HT_Stock.BOJ.clsModereglement Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsModereglement> clsModereglements = new List<HT_Stock.BOJ.clsModereglement>();
            HT_Stock.BOJ.clsModereglement clsModereglement = new HT_Stock.BOJ.clsModereglement();

            //if (string.IsNullOrEmpty(Objet.MR_CODEMODEREGLEMENT))
            //{
            //    clsModereglement.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsModereglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsModereglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsModereglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MR_CODEMODEREGLEMENT";
            //    clsModereglements.Add(clsModereglement);
            //    return clsModereglements;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsModereglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsModereglement.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsModereglement.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsModereglements.Add(clsModereglement);
            //    return clsModereglements;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsModereglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsModereglement.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsModereglement.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsModereglements.Add(clsModereglement);
            //    return clsModereglements;

            //}


            //else
            //{
                clsModereglement.clsObjetRetour = new Common.clsObjetRetour();
                clsModereglement.clsObjetRetour.SL_CODEMESSAGE = "";
                clsModereglement.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsModereglement.clsObjetRetour.SL_MESSAGE = "";
                clsModereglements.Add(clsModereglement);
                return clsModereglements;

            //}


        }

        public List<HT_Stock.BOJ.clsModereglement> TestChampObligatoireInsert(HT_Stock.BOJ.clsModereglement Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsModereglement> clsModereglements = new List<HT_Stock.BOJ.clsModereglement>();
            HT_Stock.BOJ.clsModereglement clsModereglement = new HT_Stock.BOJ.clsModereglement();

           

            if (string.IsNullOrEmpty(Objet.MR_LIBELLE))
            {
                clsModereglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsModereglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsModereglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsModereglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MR_LIBELLE";
                clsModereglements.Add(clsModereglement);
                return clsModereglements;

            }

            else
            {
                clsModereglement.clsObjetRetour = new Common.clsObjetRetour();
                clsModereglement.clsObjetRetour.SL_CODEMESSAGE = "";
                clsModereglement.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsModereglement.clsObjetRetour.SL_MESSAGE = "";
                clsModereglements.Add(clsModereglement);
                return clsModereglements;

            }


        }

        public List<HT_Stock.BOJ.clsModereglement> TestChampObligatoireUpdate(HT_Stock.BOJ.clsModereglement Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsModereglement> clsModereglements = new List<HT_Stock.BOJ.clsModereglement>();
            HT_Stock.BOJ.clsModereglement clsModereglement = new HT_Stock.BOJ.clsModereglement();

            if (string.IsNullOrEmpty(Objet.MR_CODEMODEREGLEMENT))
            {
                clsModereglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsModereglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsModereglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsModereglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MR_CODEMODEREGLEMENT";
                clsModereglements.Add(clsModereglement);
                return clsModereglements;

            }

            if (string.IsNullOrEmpty(Objet.MR_LIBELLE))
            {
                clsModereglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsModereglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsModereglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsModereglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MR_LIBELLE";
                clsModereglements.Add(clsModereglement);
                return clsModereglements;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsModereglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsModereglement.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsModereglement.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsModereglements.Add(clsModereglement);
            //    return clsModereglements;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsModereglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsModereglement.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsModereglement.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsModereglements.Add(clsModereglement);
            //    return clsModereglements;

            //}


            else
            {
                clsModereglement.clsObjetRetour = new Common.clsObjetRetour();
            clsModereglement.clsObjetRetour.SL_CODEMESSAGE = "";
            clsModereglement.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsModereglement.clsObjetRetour.SL_MESSAGE = "";
            clsModereglements.Add(clsModereglement);
            return clsModereglements;

            }


        }

        public List<HT_Stock.BOJ.clsModereglement> TestChampObligatoireDelete(HT_Stock.BOJ.clsModereglement Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsModereglement> clsModereglements = new List<HT_Stock.BOJ.clsModereglement>();
            HT_Stock.BOJ.clsModereglement clsModereglement = new HT_Stock.BOJ.clsModereglement();

            if (string.IsNullOrEmpty(Objet.MR_CODEMODEREGLEMENT))
            {
                clsModereglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsModereglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsModereglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsModereglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MR_CODEMODEREGLEMENT";
                clsModereglements.Add(clsModereglement);
                return clsModereglements;

            }
            else
            {
            clsModereglement.clsObjetRetour = new Common.clsObjetRetour();
            clsModereglement.clsObjetRetour.SL_CODEMESSAGE = "";
            clsModereglement.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsModereglement.clsObjetRetour.SL_MESSAGE = "";
            clsModereglements.Add(clsModereglement);
            return clsModereglements;

            }


        }


    }
}