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
	public partial class wsCliconsultation
	{

        public List<HT_Stock.BOJ.clsCliconsultation> TestChampObligatoireListe(HT_Stock.BOJ.clsCliconsultation Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCliconsultation> clsCliconsultations = new List<HT_Stock.BOJ.clsCliconsultation>();
            HT_Stock.BOJ.clsCliconsultation clsCliconsultation = new HT_Stock.BOJ.clsCliconsultation();

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsCliconsultation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCliconsultation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCliconsultation.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCliconsultation.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsCliconsultations.Add(clsCliconsultation);
                return clsCliconsultations;

            }

            if (string.IsNullOrEmpty(Objet.DATEDEBUT))
            {
                clsCliconsultation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCliconsultation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCliconsultation.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCliconsultation.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DATEDEBUT";
                clsCliconsultations.Add(clsCliconsultation);
                return clsCliconsultations;

            }

            if (string.IsNullOrEmpty(Objet.DATEFIN))
            {
                clsCliconsultation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCliconsultation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCliconsultation.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCliconsultation.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DATEFIN";
                clsCliconsultations.Add(clsCliconsultation);
                return clsCliconsultations;

            }

            if (string.IsNullOrEmpty(Objet.DATEFIN))
            {
                clsCliconsultation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCliconsultation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCliconsultation.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCliconsultation.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DATEFIN";
                clsCliconsultations.Add(clsCliconsultation);
                return clsCliconsultations;

            }
            if (string.IsNullOrEmpty(Objet.TYPEOPERATION))
            {
                clsCliconsultation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCliconsultation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCliconsultation.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCliconsultation.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TYPEOPERATION";
                clsCliconsultations.Add(clsCliconsultation);
                return clsCliconsultations;

            }



            else
            {
                clsCliconsultation.clsObjetRetour = new Common.clsObjetRetour();
                clsCliconsultation.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCliconsultation.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCliconsultation.clsObjetRetour.SL_MESSAGE = "";
                clsCliconsultations.Add(clsCliconsultation);
                return clsCliconsultations;

            }


        }

        public List<HT_Stock.BOJ.clsCliconsultation> TestChampObligatoireInsert(HT_Stock.BOJ.clsCliconsultation Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCliconsultation> clsCliconsultations = new List<HT_Stock.BOJ.clsCliconsultation>();
            HT_Stock.BOJ.clsCliconsultation clsCliconsultation = new HT_Stock.BOJ.clsCliconsultation();

           

            if (string.IsNullOrEmpty(Objet.CO_NUMERODOSSIER))
            {
                clsCliconsultation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCliconsultation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCliconsultation.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCliconsultation.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CO_NUMERODOSSIER";
                clsCliconsultations.Add(clsCliconsultation);
                return clsCliconsultations;

            }

            else
            {
                clsCliconsultation.clsObjetRetour = new Common.clsObjetRetour();
                clsCliconsultation.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCliconsultation.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCliconsultation.clsObjetRetour.SL_MESSAGE = "";
                clsCliconsultations.Add(clsCliconsultation);
                return clsCliconsultations;

            }


        }

        public List<HT_Stock.BOJ.clsCliconsultation> TestChampObligatoireUpdate(HT_Stock.BOJ.clsCliconsultation Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCliconsultation> clsCliconsultations = new List<HT_Stock.BOJ.clsCliconsultation>();
            HT_Stock.BOJ.clsCliconsultation clsCliconsultation = new HT_Stock.BOJ.clsCliconsultation();

            if (string.IsNullOrEmpty(Objet.CO_CODECONSULTATION))
            {
                clsCliconsultation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCliconsultation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCliconsultation.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCliconsultation.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CO_CODECONSULTATION";
                clsCliconsultations.Add(clsCliconsultation);
                return clsCliconsultations;

            }

            if (string.IsNullOrEmpty(Objet.CO_NUMERODOSSIER))
            {
                clsCliconsultation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCliconsultation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCliconsultation.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCliconsultation.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CO_NUMERODOSSIER";
                clsCliconsultations.Add(clsCliconsultation);
                return clsCliconsultations;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCliconsultation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCliconsultation.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCliconsultation.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCliconsultations.Add(clsCliconsultation);
            //    return clsCliconsultations;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCliconsultation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCliconsultation.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCliconsultation.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCliconsultations.Add(clsCliconsultation);
            //    return clsCliconsultations;

            //}


            else
            {
                clsCliconsultation.clsObjetRetour = new Common.clsObjetRetour();
            clsCliconsultation.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCliconsultation.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCliconsultation.clsObjetRetour.SL_MESSAGE = "";
            clsCliconsultations.Add(clsCliconsultation);
            return clsCliconsultations;

            }


        }

        public List<HT_Stock.BOJ.clsCliconsultation> TestChampObligatoireDelete(HT_Stock.BOJ.clsCliconsultation Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCliconsultation> clsCliconsultations = new List<HT_Stock.BOJ.clsCliconsultation>();
            HT_Stock.BOJ.clsCliconsultation clsCliconsultation = new HT_Stock.BOJ.clsCliconsultation();

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsCliconsultation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCliconsultation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCliconsultation.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCliconsultation.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsCliconsultations.Add(clsCliconsultation);
                return clsCliconsultations;

            }

            if (string.IsNullOrEmpty(Objet.CO_CODECONSULTATION))
            {
                clsCliconsultation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCliconsultation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCliconsultation.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCliconsultation.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CO_CODECONSULTATION";
                clsCliconsultations.Add(clsCliconsultation);
                return clsCliconsultations;

            }
            else
            {
            clsCliconsultation.clsObjetRetour = new Common.clsObjetRetour();
            clsCliconsultation.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCliconsultation.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCliconsultation.clsObjetRetour.SL_MESSAGE = "";
            clsCliconsultations.Add(clsCliconsultation);
            return clsCliconsultations;

            }


        }


    }
}