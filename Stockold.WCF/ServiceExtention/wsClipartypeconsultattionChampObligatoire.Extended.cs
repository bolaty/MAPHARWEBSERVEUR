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
	public partial class wsClipartypeconsultattion
	{

        public List<HT_Stock.BOJ.clsClipartypeconsultattion> TestChampObligatoireListe(HT_Stock.BOJ.clsClipartypeconsultattion Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsClipartypeconsultattion> clsClipartypeconsultattions = new List<HT_Stock.BOJ.clsClipartypeconsultattion>();
            HT_Stock.BOJ.clsClipartypeconsultattion clsClipartypeconsultattion = new HT_Stock.BOJ.clsClipartypeconsultattion();

            //if (string.IsNullOrEmpty(Objet.TY_CODETYPECONSULTATION))
            //{
            //    clsClipartypeconsultattion.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsClipartypeconsultattion.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsClipartypeconsultattion.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsClipartypeconsultattion.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TY_CODETYPECONSULTATION";
            //    clsClipartypeconsultattions.Add(clsClipartypeconsultattion);
            //    return clsClipartypeconsultattions;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsClipartypeconsultattion.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsClipartypeconsultattion.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsClipartypeconsultattion.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsClipartypeconsultattions.Add(clsClipartypeconsultattion);
            //    return clsClipartypeconsultattions;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsClipartypeconsultattion.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsClipartypeconsultattion.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsClipartypeconsultattion.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsClipartypeconsultattions.Add(clsClipartypeconsultattion);
            //    return clsClipartypeconsultattions;

            //}


            //else
            //{
                clsClipartypeconsultattion.clsObjetRetour = new Common.clsObjetRetour();
                clsClipartypeconsultattion.clsObjetRetour.SL_CODEMESSAGE = "";
                clsClipartypeconsultattion.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsClipartypeconsultattion.clsObjetRetour.SL_MESSAGE = "";
                clsClipartypeconsultattions.Add(clsClipartypeconsultattion);
                return clsClipartypeconsultattions;

            //}


        }

        public List<HT_Stock.BOJ.clsClipartypeconsultattion> TestChampObligatoireInsert(HT_Stock.BOJ.clsClipartypeconsultattion Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsClipartypeconsultattion> clsClipartypeconsultattions = new List<HT_Stock.BOJ.clsClipartypeconsultattion>();
            HT_Stock.BOJ.clsClipartypeconsultattion clsClipartypeconsultattion = new HT_Stock.BOJ.clsClipartypeconsultattion();

           

            if (string.IsNullOrEmpty(Objet.TY_LIBELLETYPECONSULTATION))
            {
                clsClipartypeconsultattion.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsClipartypeconsultattion.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsClipartypeconsultattion.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsClipartypeconsultattion.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TY_LIBELLETYPECONSULTATION";
                clsClipartypeconsultattions.Add(clsClipartypeconsultattion);
                return clsClipartypeconsultattions;

            }

            else
            {
                clsClipartypeconsultattion.clsObjetRetour = new Common.clsObjetRetour();
                clsClipartypeconsultattion.clsObjetRetour.SL_CODEMESSAGE = "";
                clsClipartypeconsultattion.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsClipartypeconsultattion.clsObjetRetour.SL_MESSAGE = "";
                clsClipartypeconsultattions.Add(clsClipartypeconsultattion);
                return clsClipartypeconsultattions;

            }


        }

        public List<HT_Stock.BOJ.clsClipartypeconsultattion> TestChampObligatoireUpdate(HT_Stock.BOJ.clsClipartypeconsultattion Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsClipartypeconsultattion> clsClipartypeconsultattions = new List<HT_Stock.BOJ.clsClipartypeconsultattion>();
            HT_Stock.BOJ.clsClipartypeconsultattion clsClipartypeconsultattion = new HT_Stock.BOJ.clsClipartypeconsultattion();

            if (string.IsNullOrEmpty(Objet.TY_CODETYPECONSULTATION))
            {
                clsClipartypeconsultattion.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsClipartypeconsultattion.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsClipartypeconsultattion.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsClipartypeconsultattion.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TY_CODETYPECONSULTATION";
                clsClipartypeconsultattions.Add(clsClipartypeconsultattion);
                return clsClipartypeconsultattions;

            }

            if (string.IsNullOrEmpty(Objet.TY_LIBELLETYPECONSULTATION))
            {
                clsClipartypeconsultattion.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsClipartypeconsultattion.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsClipartypeconsultattion.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsClipartypeconsultattion.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TY_LIBELLETYPECONSULTATION";
                clsClipartypeconsultattions.Add(clsClipartypeconsultattion);
                return clsClipartypeconsultattions;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsClipartypeconsultattion.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsClipartypeconsultattion.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsClipartypeconsultattion.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsClipartypeconsultattions.Add(clsClipartypeconsultattion);
            //    return clsClipartypeconsultattions;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsClipartypeconsultattion.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsClipartypeconsultattion.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsClipartypeconsultattion.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsClipartypeconsultattions.Add(clsClipartypeconsultattion);
            //    return clsClipartypeconsultattions;

            //}


            else
            {
                clsClipartypeconsultattion.clsObjetRetour = new Common.clsObjetRetour();
            clsClipartypeconsultattion.clsObjetRetour.SL_CODEMESSAGE = "";
            clsClipartypeconsultattion.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsClipartypeconsultattion.clsObjetRetour.SL_MESSAGE = "";
            clsClipartypeconsultattions.Add(clsClipartypeconsultattion);
            return clsClipartypeconsultattions;

            }


        }

        public List<HT_Stock.BOJ.clsClipartypeconsultattion> TestChampObligatoireDelete(HT_Stock.BOJ.clsClipartypeconsultattion Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsClipartypeconsultattion> clsClipartypeconsultattions = new List<HT_Stock.BOJ.clsClipartypeconsultattion>();
            HT_Stock.BOJ.clsClipartypeconsultattion clsClipartypeconsultattion = new HT_Stock.BOJ.clsClipartypeconsultattion();

            if (string.IsNullOrEmpty(Objet.TY_CODETYPECONSULTATION))
            {
                clsClipartypeconsultattion.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsClipartypeconsultattion.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsClipartypeconsultattion.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsClipartypeconsultattion.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TY_CODETYPECONSULTATION";
                clsClipartypeconsultattions.Add(clsClipartypeconsultattion);
                return clsClipartypeconsultattions;

            }
            else
            {
            clsClipartypeconsultattion.clsObjetRetour = new Common.clsObjetRetour();
            clsClipartypeconsultattion.clsObjetRetour.SL_CODEMESSAGE = "";
            clsClipartypeconsultattion.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsClipartypeconsultattion.clsObjetRetour.SL_MESSAGE = "";
            clsClipartypeconsultattions.Add(clsClipartypeconsultattion);
            return clsClipartypeconsultattions;

            }


        }


    }
}