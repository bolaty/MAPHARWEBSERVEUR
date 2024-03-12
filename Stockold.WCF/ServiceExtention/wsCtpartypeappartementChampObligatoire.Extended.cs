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
	public partial class wsCtpartypeappartement
	{

        public List<HT_Stock.BOJ.clsCtpartypeappartement> TestChampObligatoireListe(HT_Stock.BOJ.clsCtpartypeappartement Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtpartypeappartement> clsCtpartypeappartements = new List<HT_Stock.BOJ.clsCtpartypeappartement>();
            HT_Stock.BOJ.clsCtpartypeappartement clsCtpartypeappartement = new HT_Stock.BOJ.clsCtpartypeappartement();

            //if (string.IsNullOrEmpty(Objet.AP_CODETYPEAPPARTEMENT))
            //{
            //    clsCtpartypeappartement.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsCtpartypeappartement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtpartypeappartement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsCtpartypeappartement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AP_CODETYPEAPPARTEMENT";
            //    clsCtpartypeappartements.Add(clsCtpartypeappartement);
            //    return clsCtpartypeappartements;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtpartypeappartement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtpartypeappartement.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtpartypeappartement.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtpartypeappartements.Add(clsCtpartypeappartement);
            //    return clsCtpartypeappartements;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtpartypeappartement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtpartypeappartement.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtpartypeappartement.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtpartypeappartements.Add(clsCtpartypeappartement);
            //    return clsCtpartypeappartements;

            //}


            //else
            //{
                clsCtpartypeappartement.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpartypeappartement.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtpartypeappartement.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtpartypeappartement.clsObjetRetour.SL_MESSAGE = "";
                clsCtpartypeappartements.Add(clsCtpartypeappartement);
                return clsCtpartypeappartements;

            //}


        }

        public List<HT_Stock.BOJ.clsCtpartypeappartement> TestChampObligatoireInsert(HT_Stock.BOJ.clsCtpartypeappartement Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtpartypeappartement> clsCtpartypeappartements = new List<HT_Stock.BOJ.clsCtpartypeappartement>();
            HT_Stock.BOJ.clsCtpartypeappartement clsCtpartypeappartement = new HT_Stock.BOJ.clsCtpartypeappartement();

           

            if (string.IsNullOrEmpty(Objet.AP_LIBLLETYPEAPPARTEMENT))
            {
                clsCtpartypeappartement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtpartypeappartement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtpartypeappartement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtpartypeappartement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AP_LIBLLETYPEAPPARTEMENT";
                clsCtpartypeappartements.Add(clsCtpartypeappartement);
                return clsCtpartypeappartements;

            }

            else
            {
                clsCtpartypeappartement.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpartypeappartement.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtpartypeappartement.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtpartypeappartement.clsObjetRetour.SL_MESSAGE = "";
                clsCtpartypeappartements.Add(clsCtpartypeappartement);
                return clsCtpartypeappartements;

            }


        }

        public List<HT_Stock.BOJ.clsCtpartypeappartement> TestChampObligatoireUpdate(HT_Stock.BOJ.clsCtpartypeappartement Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtpartypeappartement> clsCtpartypeappartements = new List<HT_Stock.BOJ.clsCtpartypeappartement>();
            HT_Stock.BOJ.clsCtpartypeappartement clsCtpartypeappartement = new HT_Stock.BOJ.clsCtpartypeappartement();

            if (string.IsNullOrEmpty(Objet.AP_CODETYPEAPPARTEMENT))
            {
                clsCtpartypeappartement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtpartypeappartement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtpartypeappartement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtpartypeappartement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AP_CODETYPEAPPARTEMENT";
                clsCtpartypeappartements.Add(clsCtpartypeappartement);
                return clsCtpartypeappartements;

            }

            if (string.IsNullOrEmpty(Objet.AP_LIBLLETYPEAPPARTEMENT))
            {
                clsCtpartypeappartement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtpartypeappartement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtpartypeappartement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtpartypeappartement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AP_LIBLLETYPEAPPARTEMENT";
                clsCtpartypeappartements.Add(clsCtpartypeappartement);
                return clsCtpartypeappartements;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtpartypeappartement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtpartypeappartement.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtpartypeappartement.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtpartypeappartements.Add(clsCtpartypeappartement);
            //    return clsCtpartypeappartements;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtpartypeappartement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtpartypeappartement.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtpartypeappartement.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtpartypeappartements.Add(clsCtpartypeappartement);
            //    return clsCtpartypeappartements;

            //}


            else
            {
                clsCtpartypeappartement.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpartypeappartement.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtpartypeappartement.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtpartypeappartement.clsObjetRetour.SL_MESSAGE = "";
            clsCtpartypeappartements.Add(clsCtpartypeappartement);
            return clsCtpartypeappartements;

            }


        }

        public List<HT_Stock.BOJ.clsCtpartypeappartement> TestChampObligatoireDelete(HT_Stock.BOJ.clsCtpartypeappartement Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtpartypeappartement> clsCtpartypeappartements = new List<HT_Stock.BOJ.clsCtpartypeappartement>();
            HT_Stock.BOJ.clsCtpartypeappartement clsCtpartypeappartement = new HT_Stock.BOJ.clsCtpartypeappartement();

            if (string.IsNullOrEmpty(Objet.AP_CODETYPEAPPARTEMENT))
            {
                clsCtpartypeappartement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtpartypeappartement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtpartypeappartement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtpartypeappartement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AP_CODETYPEAPPARTEMENT";
                clsCtpartypeappartements.Add(clsCtpartypeappartement);
                return clsCtpartypeappartements;

            }
            else
            {
            clsCtpartypeappartement.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpartypeappartement.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtpartypeappartement.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtpartypeappartement.clsObjetRetour.SL_MESSAGE = "";
            clsCtpartypeappartements.Add(clsCtpartypeappartement);
            return clsCtpartypeappartements;

            }


        }


    }
}