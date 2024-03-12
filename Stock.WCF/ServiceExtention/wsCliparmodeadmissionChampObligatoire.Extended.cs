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
	public partial class wsCliparmodeadmission
	{

        public List<HT_Stock.BOJ.clsCliparmodeadmission> TestChampObligatoireListe(HT_Stock.BOJ.clsCliparmodeadmission Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCliparmodeadmission> clsCliparmodeadmissions = new List<HT_Stock.BOJ.clsCliparmodeadmission>();
            HT_Stock.BOJ.clsCliparmodeadmission clsCliparmodeadmission = new HT_Stock.BOJ.clsCliparmodeadmission();

            //if (string.IsNullOrEmpty(Objet.MD_CODEMODEADMISSION))
            //{
            //    clsCliparmodeadmission.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsCliparmodeadmission.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCliparmodeadmission.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsCliparmodeadmission.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MD_CODEMODEADMISSION";
            //    clsCliparmodeadmissions.Add(clsCliparmodeadmission);
            //    return clsCliparmodeadmissions;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCliparmodeadmission.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCliparmodeadmission.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCliparmodeadmission.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCliparmodeadmissions.Add(clsCliparmodeadmission);
            //    return clsCliparmodeadmissions;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCliparmodeadmission.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCliparmodeadmission.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCliparmodeadmission.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCliparmodeadmissions.Add(clsCliparmodeadmission);
            //    return clsCliparmodeadmissions;

            //}


            //else
            //{
                clsCliparmodeadmission.clsObjetRetour = new Common.clsObjetRetour();
                clsCliparmodeadmission.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCliparmodeadmission.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCliparmodeadmission.clsObjetRetour.SL_MESSAGE = "";
                clsCliparmodeadmissions.Add(clsCliparmodeadmission);
                return clsCliparmodeadmissions;

            //}


        }

        public List<HT_Stock.BOJ.clsCliparmodeadmission> TestChampObligatoireInsert(HT_Stock.BOJ.clsCliparmodeadmission Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCliparmodeadmission> clsCliparmodeadmissions = new List<HT_Stock.BOJ.clsCliparmodeadmission>();
            HT_Stock.BOJ.clsCliparmodeadmission clsCliparmodeadmission = new HT_Stock.BOJ.clsCliparmodeadmission();

           

            if (string.IsNullOrEmpty(Objet.MD_LIBELLEMODEADMISSION))
            {
                clsCliparmodeadmission.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCliparmodeadmission.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCliparmodeadmission.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCliparmodeadmission.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MD_LIBELLEMODEADMISSION";
                clsCliparmodeadmissions.Add(clsCliparmodeadmission);
                return clsCliparmodeadmissions;

            }

            else
            {
                clsCliparmodeadmission.clsObjetRetour = new Common.clsObjetRetour();
                clsCliparmodeadmission.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCliparmodeadmission.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCliparmodeadmission.clsObjetRetour.SL_MESSAGE = "";
                clsCliparmodeadmissions.Add(clsCliparmodeadmission);
                return clsCliparmodeadmissions;

            }


        }

        public List<HT_Stock.BOJ.clsCliparmodeadmission> TestChampObligatoireUpdate(HT_Stock.BOJ.clsCliparmodeadmission Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCliparmodeadmission> clsCliparmodeadmissions = new List<HT_Stock.BOJ.clsCliparmodeadmission>();
            HT_Stock.BOJ.clsCliparmodeadmission clsCliparmodeadmission = new HT_Stock.BOJ.clsCliparmodeadmission();

            if (string.IsNullOrEmpty(Objet.MD_CODEMODEADMISSION))
            {
                clsCliparmodeadmission.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCliparmodeadmission.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCliparmodeadmission.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCliparmodeadmission.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MD_CODEMODEADMISSION";
                clsCliparmodeadmissions.Add(clsCliparmodeadmission);
                return clsCliparmodeadmissions;

            }

            if (string.IsNullOrEmpty(Objet.MD_LIBELLEMODEADMISSION))
            {
                clsCliparmodeadmission.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCliparmodeadmission.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCliparmodeadmission.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCliparmodeadmission.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MD_LIBELLEMODEADMISSION";
                clsCliparmodeadmissions.Add(clsCliparmodeadmission);
                return clsCliparmodeadmissions;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCliparmodeadmission.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCliparmodeadmission.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCliparmodeadmission.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCliparmodeadmissions.Add(clsCliparmodeadmission);
            //    return clsCliparmodeadmissions;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCliparmodeadmission.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCliparmodeadmission.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCliparmodeadmission.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCliparmodeadmissions.Add(clsCliparmodeadmission);
            //    return clsCliparmodeadmissions;

            //}


            else
            {
                clsCliparmodeadmission.clsObjetRetour = new Common.clsObjetRetour();
            clsCliparmodeadmission.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCliparmodeadmission.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCliparmodeadmission.clsObjetRetour.SL_MESSAGE = "";
            clsCliparmodeadmissions.Add(clsCliparmodeadmission);
            return clsCliparmodeadmissions;

            }


        }

        public List<HT_Stock.BOJ.clsCliparmodeadmission> TestChampObligatoireDelete(HT_Stock.BOJ.clsCliparmodeadmission Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCliparmodeadmission> clsCliparmodeadmissions = new List<HT_Stock.BOJ.clsCliparmodeadmission>();
            HT_Stock.BOJ.clsCliparmodeadmission clsCliparmodeadmission = new HT_Stock.BOJ.clsCliparmodeadmission();

            if (string.IsNullOrEmpty(Objet.MD_CODEMODEADMISSION))
            {
                clsCliparmodeadmission.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCliparmodeadmission.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCliparmodeadmission.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCliparmodeadmission.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MD_CODEMODEADMISSION";
                clsCliparmodeadmissions.Add(clsCliparmodeadmission);
                return clsCliparmodeadmissions;

            }
            else
            {
            clsCliparmodeadmission.clsObjetRetour = new Common.clsObjetRetour();
            clsCliparmodeadmission.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCliparmodeadmission.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCliparmodeadmission.clsObjetRetour.SL_MESSAGE = "";
            clsCliparmodeadmissions.Add(clsCliparmodeadmission);
            return clsCliparmodeadmissions;

            }


        }


    }
}