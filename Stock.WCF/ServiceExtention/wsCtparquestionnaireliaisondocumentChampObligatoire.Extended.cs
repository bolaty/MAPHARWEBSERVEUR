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
	public partial class wsCtparquestionnaireliaisondocument
	{

        public List<HT_Stock.BOJ.clsCtparquestionnaireliaisondocument> TestChampObligatoireListe(HT_Stock.BOJ.clsCtparquestionnaireliaisondocument Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparquestionnaireliaisondocument> clsCtparquestionnaireliaisondocuments = new List<HT_Stock.BOJ.clsCtparquestionnaireliaisondocument>();
            HT_Stock.BOJ.clsCtparquestionnaireliaisondocument clsCtparquestionnaireliaisondocument = new HT_Stock.BOJ.clsCtparquestionnaireliaisondocument();

            if (string.IsNullOrEmpty(Objet.DC_CODEDOCUMENT))
            {
                clsCtparquestionnaireliaisondocument.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DC_CODEDOCUMENT";
                clsCtparquestionnaireliaisondocuments.Add(clsCtparquestionnaireliaisondocument);
                return clsCtparquestionnaireliaisondocuments;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparquestionnaireliaisondocuments.Add(clsCtparquestionnaireliaisondocument);
            //    return clsCtparquestionnaireliaisondocuments;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparquestionnaireliaisondocuments.Add(clsCtparquestionnaireliaisondocument);
            //    return clsCtparquestionnaireliaisondocuments;

            //}


            else
            {
                clsCtparquestionnaireliaisondocument.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_MESSAGE = "";
                clsCtparquestionnaireliaisondocuments.Add(clsCtparquestionnaireliaisondocument);
                return clsCtparquestionnaireliaisondocuments;

            }


        }

        public List<HT_Stock.BOJ.clsCtparquestionnaireliaisondocument> TestChampObligatoireInsert(HT_Stock.BOJ.clsCtparquestionnaireliaisondocument Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparquestionnaireliaisondocument> clsCtparquestionnaireliaisondocuments = new List<HT_Stock.BOJ.clsCtparquestionnaireliaisondocument>();
            HT_Stock.BOJ.clsCtparquestionnaireliaisondocument clsCtparquestionnaireliaisondocument = new HT_Stock.BOJ.clsCtparquestionnaireliaisondocument();

           

            if (string.IsNullOrEmpty(Objet.DC_CODEDOCUMENT))
            {
                clsCtparquestionnaireliaisondocument.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DC_CODEDOCUMENT";
                clsCtparquestionnaireliaisondocuments.Add(clsCtparquestionnaireliaisondocument);
                return clsCtparquestionnaireliaisondocuments;

            }

            else
            {
                clsCtparquestionnaireliaisondocument.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_MESSAGE = "";
                clsCtparquestionnaireliaisondocuments.Add(clsCtparquestionnaireliaisondocument);
                return clsCtparquestionnaireliaisondocuments;

            }


        }

        public List<HT_Stock.BOJ.clsCtparquestionnaireliaisondocument> TestChampObligatoireUpdate(HT_Stock.BOJ.clsCtparquestionnaireliaisondocument Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparquestionnaireliaisondocument> clsCtparquestionnaireliaisondocuments = new List<HT_Stock.BOJ.clsCtparquestionnaireliaisondocument>();
            HT_Stock.BOJ.clsCtparquestionnaireliaisondocument clsCtparquestionnaireliaisondocument = new HT_Stock.BOJ.clsCtparquestionnaireliaisondocument();

            if (string.IsNullOrEmpty(Objet.QE_CODEQUESTIONNAIRE))
            {
                clsCtparquestionnaireliaisondocument.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", QE_CODEQUESTIONNAIRE";
                clsCtparquestionnaireliaisondocuments.Add(clsCtparquestionnaireliaisondocument);
                return clsCtparquestionnaireliaisondocuments;

            }

            if (string.IsNullOrEmpty(Objet.DC_CODEDOCUMENT))
            {
                clsCtparquestionnaireliaisondocument.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DC_CODEDOCUMENT";
                clsCtparquestionnaireliaisondocuments.Add(clsCtparquestionnaireliaisondocument);
                return clsCtparquestionnaireliaisondocuments;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparquestionnaireliaisondocuments.Add(clsCtparquestionnaireliaisondocument);
            //    return clsCtparquestionnaireliaisondocuments;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparquestionnaireliaisondocuments.Add(clsCtparquestionnaireliaisondocument);
            //    return clsCtparquestionnaireliaisondocuments;

            //}


            else
            {
                clsCtparquestionnaireliaisondocument.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_MESSAGE = "";
            clsCtparquestionnaireliaisondocuments.Add(clsCtparquestionnaireliaisondocument);
            return clsCtparquestionnaireliaisondocuments;

            }


        }

        public List<HT_Stock.BOJ.clsCtparquestionnaireliaisondocument> TestChampObligatoireDelete(HT_Stock.BOJ.clsCtparquestionnaireliaisondocument Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparquestionnaireliaisondocument> clsCtparquestionnaireliaisondocuments = new List<HT_Stock.BOJ.clsCtparquestionnaireliaisondocument>();
            HT_Stock.BOJ.clsCtparquestionnaireliaisondocument clsCtparquestionnaireliaisondocument = new HT_Stock.BOJ.clsCtparquestionnaireliaisondocument();

            if (string.IsNullOrEmpty(Objet.QE_CODEQUESTIONNAIRE))
            {
                clsCtparquestionnaireliaisondocument.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", QE_CODEQUESTIONNAIRE";
                clsCtparquestionnaireliaisondocuments.Add(clsCtparquestionnaireliaisondocument);
                return clsCtparquestionnaireliaisondocuments;

            }
            else
            {
            clsCtparquestionnaireliaisondocument.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparquestionnaireliaisondocument.clsObjetRetour.SL_MESSAGE = "";
            clsCtparquestionnaireliaisondocuments.Add(clsCtparquestionnaireliaisondocument);
            return clsCtparquestionnaireliaisondocuments;

            }


        }


    }
}