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
	public partial class wsCtsinistresituationdossier
	{

        public List<HT_Stock.BOJ.clsCtsinistresituationdossier> TestChampObligatoireListe(HT_Stock.BOJ.clsCtsinistresituationdossier Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtsinistresituationdossier> clsCtsinistresituationdossiers = new List<HT_Stock.BOJ.clsCtsinistresituationdossier>();
            HT_Stock.BOJ.clsCtsinistresituationdossier clsCtsinistresituationdossier = new HT_Stock.BOJ.clsCtsinistresituationdossier();

            if (string.IsNullOrEmpty(Objet.SI_CODESINISTRE))
            {
                clsCtsinistresituationdossier.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistresituationdossier.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistresituationdossier.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistresituationdossier.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SI_CODESINISTRE";
                clsCtsinistresituationdossiers.Add(clsCtsinistresituationdossier);
                return clsCtsinistresituationdossiers;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtsinistresituationdossier.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtsinistresituationdossier.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtsinistresituationdossier.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtsinistresituationdossiers.Add(clsCtsinistresituationdossier);
            //    return clsCtsinistresituationdossiers;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtsinistresituationdossier.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtsinistresituationdossier.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtsinistresituationdossier.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtsinistresituationdossiers.Add(clsCtsinistresituationdossier);
            //    return clsCtsinistresituationdossiers;

            //}


            //else
            //{
            clsCtsinistresituationdossier.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistresituationdossier.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtsinistresituationdossier.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtsinistresituationdossier.clsObjetRetour.SL_MESSAGE = "";
                clsCtsinistresituationdossiers.Add(clsCtsinistresituationdossier);
                return clsCtsinistresituationdossiers;

            //}


        }

        public List<HT_Stock.BOJ.clsCtsinistresituationdossier> TestChampObligatoireInsert(HT_Stock.BOJ.clsCtsinistresituationdossier Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtsinistresituationdossier> clsCtsinistresituationdossiers = new List<HT_Stock.BOJ.clsCtsinistresituationdossier>();
            HT_Stock.BOJ.clsCtsinistresituationdossier clsCtsinistresituationdossier = new HT_Stock.BOJ.clsCtsinistresituationdossier();

           

            if (string.IsNullOrEmpty(Objet.SD_CODESITUATIONDOSSIER))
            {
                clsCtsinistresituationdossier.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistresituationdossier.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistresituationdossier.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistresituationdossier.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SD_CODESITUATIONDOSSIER";
                clsCtsinistresituationdossiers.Add(clsCtsinistresituationdossier);
                return clsCtsinistresituationdossiers;

            }

            else
            {
                clsCtsinistresituationdossier.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistresituationdossier.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtsinistresituationdossier.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtsinistresituationdossier.clsObjetRetour.SL_MESSAGE = "";
                clsCtsinistresituationdossiers.Add(clsCtsinistresituationdossier);
                return clsCtsinistresituationdossiers;

            }


        }

        public List<HT_Stock.BOJ.clsCtsinistresituationdossier> TestChampObligatoireUpdate(HT_Stock.BOJ.clsCtsinistresituationdossier Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtsinistresituationdossier> clsCtsinistresituationdossiers = new List<HT_Stock.BOJ.clsCtsinistresituationdossier>();
            HT_Stock.BOJ.clsCtsinistresituationdossier clsCtsinistresituationdossier = new HT_Stock.BOJ.clsCtsinistresituationdossier();

            if (string.IsNullOrEmpty(Objet.SI_CODESINISTRE))
            {
                clsCtsinistresituationdossier.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistresituationdossier.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistresituationdossier.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistresituationdossier.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SI_CODESINISTRE";
                clsCtsinistresituationdossiers.Add(clsCtsinistresituationdossier);
                return clsCtsinistresituationdossiers;

            }

            if (string.IsNullOrEmpty(Objet.SD_CODESITUATIONDOSSIER))
            {
                clsCtsinistresituationdossier.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistresituationdossier.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistresituationdossier.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistresituationdossier.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SD_CODESITUATIONDOSSIER";
                clsCtsinistresituationdossiers.Add(clsCtsinistresituationdossier);
                return clsCtsinistresituationdossiers;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtsinistresituationdossier.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtsinistresituationdossier.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtsinistresituationdossier.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtsinistresituationdossiers.Add(clsCtsinistresituationdossier);
            //    return clsCtsinistresituationdossiers;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtsinistresituationdossier.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtsinistresituationdossier.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtsinistresituationdossier.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtsinistresituationdossiers.Add(clsCtsinistresituationdossier);
            //    return clsCtsinistresituationdossiers;

            //}


            else
            {
                clsCtsinistresituationdossier.clsObjetRetour = new Common.clsObjetRetour();
            clsCtsinistresituationdossier.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtsinistresituationdossier.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtsinistresituationdossier.clsObjetRetour.SL_MESSAGE = "";
            clsCtsinistresituationdossiers.Add(clsCtsinistresituationdossier);
            return clsCtsinistresituationdossiers;

            }


        }

        public List<HT_Stock.BOJ.clsCtsinistresituationdossier> TestChampObligatoireDelete(HT_Stock.BOJ.clsCtsinistresituationdossier Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtsinistresituationdossier> clsCtsinistresituationdossiers = new List<HT_Stock.BOJ.clsCtsinistresituationdossier>();
            HT_Stock.BOJ.clsCtsinistresituationdossier clsCtsinistresituationdossier = new HT_Stock.BOJ.clsCtsinistresituationdossier();

            if (string.IsNullOrEmpty(Objet.SI_CODESINISTRE))
            {
                clsCtsinistresituationdossier.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistresituationdossier.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistresituationdossier.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistresituationdossier.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SI_CODESINISTRE";
                clsCtsinistresituationdossiers.Add(clsCtsinistresituationdossier);
                return clsCtsinistresituationdossiers;

            }
            else
            {
            clsCtsinistresituationdossier.clsObjetRetour = new Common.clsObjetRetour();
            clsCtsinistresituationdossier.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtsinistresituationdossier.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtsinistresituationdossier.clsObjetRetour.SL_MESSAGE = "";
            clsCtsinistresituationdossiers.Add(clsCtsinistresituationdossier);
            return clsCtsinistresituationdossiers;

            }


        }


    }
}