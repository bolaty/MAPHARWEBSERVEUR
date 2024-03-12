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
	public partial class wsClipartitreadherantayantsdroits
	{

        public List<HT_Stock.BOJ.clsClipartitreadherantayantsdroits> TestChampObligatoireListe(HT_Stock.BOJ.clsClipartitreadherantayantsdroits Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsClipartitreadherantayantsdroits> clsClipartitreadherantayantsdroitss = new List<HT_Stock.BOJ.clsClipartitreadherantayantsdroits>();
            HT_Stock.BOJ.clsClipartitreadherantayantsdroits clsClipartitreadherantayantsdroits = new HT_Stock.BOJ.clsClipartitreadherantayantsdroits();

            //if (string.IsNullOrEmpty(Objet.TA_CODETITREAYANTDROIT))
            //{
            //    clsClipartitreadherantayantsdroits.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsClipartitreadherantayantsdroits.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsClipartitreadherantayantsdroits.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsClipartitreadherantayantsdroits.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TA_CODETITREAYANTDROIT";
            //    clsClipartitreadherantayantsdroitss.Add(clsClipartitreadherantayantsdroits);
            //    return clsClipartitreadherantayantsdroitss;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsClipartitreadherantayantsdroits.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsClipartitreadherantayantsdroits.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsClipartitreadherantayantsdroits.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsClipartitreadherantayantsdroitss.Add(clsClipartitreadherantayantsdroits);
            //    return clsClipartitreadherantayantsdroitss;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsClipartitreadherantayantsdroits.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsClipartitreadherantayantsdroits.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsClipartitreadherantayantsdroits.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsClipartitreadherantayantsdroitss.Add(clsClipartitreadherantayantsdroits);
            //    return clsClipartitreadherantayantsdroitss;

            //}


            //else
            //{
                clsClipartitreadherantayantsdroits.clsObjetRetour = new Common.clsObjetRetour();
                clsClipartitreadherantayantsdroits.clsObjetRetour.SL_CODEMESSAGE = "";
                clsClipartitreadherantayantsdroits.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsClipartitreadherantayantsdroits.clsObjetRetour.SL_MESSAGE = "";
                clsClipartitreadherantayantsdroitss.Add(clsClipartitreadherantayantsdroits);
                return clsClipartitreadherantayantsdroitss;

            //}


        }

        public List<HT_Stock.BOJ.clsClipartitreadherantayantsdroits> TestChampObligatoireInsert(HT_Stock.BOJ.clsClipartitreadherantayantsdroits Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsClipartitreadherantayantsdroits> clsClipartitreadherantayantsdroitss = new List<HT_Stock.BOJ.clsClipartitreadherantayantsdroits>();
            HT_Stock.BOJ.clsClipartitreadherantayantsdroits clsClipartitreadherantayantsdroits = new HT_Stock.BOJ.clsClipartitreadherantayantsdroits();

           

            if (string.IsNullOrEmpty(Objet.TA_LIBELLETITREAYANTDROIT))
            {
                clsClipartitreadherantayantsdroits.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsClipartitreadherantayantsdroits.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsClipartitreadherantayantsdroits.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsClipartitreadherantayantsdroits.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TA_LIBELLETITREAYANTDROIT";
                clsClipartitreadherantayantsdroitss.Add(clsClipartitreadherantayantsdroits);
                return clsClipartitreadherantayantsdroitss;

            }

            else
            {
                clsClipartitreadherantayantsdroits.clsObjetRetour = new Common.clsObjetRetour();
                clsClipartitreadherantayantsdroits.clsObjetRetour.SL_CODEMESSAGE = "";
                clsClipartitreadherantayantsdroits.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsClipartitreadherantayantsdroits.clsObjetRetour.SL_MESSAGE = "";
                clsClipartitreadherantayantsdroitss.Add(clsClipartitreadherantayantsdroits);
                return clsClipartitreadherantayantsdroitss;

            }


        }

        public List<HT_Stock.BOJ.clsClipartitreadherantayantsdroits> TestChampObligatoireUpdate(HT_Stock.BOJ.clsClipartitreadherantayantsdroits Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsClipartitreadherantayantsdroits> clsClipartitreadherantayantsdroitss = new List<HT_Stock.BOJ.clsClipartitreadherantayantsdroits>();
            HT_Stock.BOJ.clsClipartitreadherantayantsdroits clsClipartitreadherantayantsdroits = new HT_Stock.BOJ.clsClipartitreadherantayantsdroits();

            if (string.IsNullOrEmpty(Objet.TA_CODETITREAYANTDROIT))
            {
                clsClipartitreadherantayantsdroits.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsClipartitreadherantayantsdroits.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsClipartitreadherantayantsdroits.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsClipartitreadherantayantsdroits.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TA_CODETITREAYANTDROIT";
                clsClipartitreadherantayantsdroitss.Add(clsClipartitreadherantayantsdroits);
                return clsClipartitreadherantayantsdroitss;

            }

            if (string.IsNullOrEmpty(Objet.TA_LIBELLETITREAYANTDROIT))
            {
                clsClipartitreadherantayantsdroits.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsClipartitreadherantayantsdroits.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsClipartitreadherantayantsdroits.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsClipartitreadherantayantsdroits.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TA_LIBELLETITREAYANTDROIT";
                clsClipartitreadherantayantsdroitss.Add(clsClipartitreadherantayantsdroits);
                return clsClipartitreadherantayantsdroitss;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsClipartitreadherantayantsdroits.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsClipartitreadherantayantsdroits.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsClipartitreadherantayantsdroits.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsClipartitreadherantayantsdroitss.Add(clsClipartitreadherantayantsdroits);
            //    return clsClipartitreadherantayantsdroitss;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsClipartitreadherantayantsdroits.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsClipartitreadherantayantsdroits.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsClipartitreadherantayantsdroits.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsClipartitreadherantayantsdroitss.Add(clsClipartitreadherantayantsdroits);
            //    return clsClipartitreadherantayantsdroitss;

            //}


            else
            {
                clsClipartitreadherantayantsdroits.clsObjetRetour = new Common.clsObjetRetour();
            clsClipartitreadherantayantsdroits.clsObjetRetour.SL_CODEMESSAGE = "";
            clsClipartitreadherantayantsdroits.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsClipartitreadherantayantsdroits.clsObjetRetour.SL_MESSAGE = "";
            clsClipartitreadherantayantsdroitss.Add(clsClipartitreadherantayantsdroits);
            return clsClipartitreadherantayantsdroitss;

            }


        }

        public List<HT_Stock.BOJ.clsClipartitreadherantayantsdroits> TestChampObligatoireDelete(HT_Stock.BOJ.clsClipartitreadherantayantsdroits Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsClipartitreadherantayantsdroits> clsClipartitreadherantayantsdroitss = new List<HT_Stock.BOJ.clsClipartitreadherantayantsdroits>();
            HT_Stock.BOJ.clsClipartitreadherantayantsdroits clsClipartitreadherantayantsdroits = new HT_Stock.BOJ.clsClipartitreadherantayantsdroits();

            if (string.IsNullOrEmpty(Objet.TA_CODETITREAYANTDROIT))
            {
                clsClipartitreadherantayantsdroits.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsClipartitreadherantayantsdroits.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsClipartitreadherantayantsdroits.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsClipartitreadherantayantsdroits.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TA_CODETITREAYANTDROIT";
                clsClipartitreadherantayantsdroitss.Add(clsClipartitreadherantayantsdroits);
                return clsClipartitreadherantayantsdroitss;

            }
            else
            {
            clsClipartitreadherantayantsdroits.clsObjetRetour = new Common.clsObjetRetour();
            clsClipartitreadherantayantsdroits.clsObjetRetour.SL_CODEMESSAGE = "";
            clsClipartitreadherantayantsdroits.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsClipartitreadherantayantsdroits.clsObjetRetour.SL_MESSAGE = "";
            clsClipartitreadherantayantsdroitss.Add(clsClipartitreadherantayantsdroits);
            return clsClipartitreadherantayantsdroitss;

            }


        }


    }
}