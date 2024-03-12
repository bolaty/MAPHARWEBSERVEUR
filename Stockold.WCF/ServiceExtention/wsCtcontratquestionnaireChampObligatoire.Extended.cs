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
	public partial class wsCtcontratquestionnaire
	{

        public List<HT_Stock.BOJ.clsCtcontratquestionnaire> TestChampObligatoireListe(HT_Stock.BOJ.clsCtcontratquestionnaire Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtcontratquestionnaire> clsCtcontratquestionnaires = new List<HT_Stock.BOJ.clsCtcontratquestionnaire>();
            HT_Stock.BOJ.clsCtcontratquestionnaire clsCtcontratquestionnaire = new HT_Stock.BOJ.clsCtcontratquestionnaire();


            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsCtcontratquestionnaire.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratquestionnaire.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratquestionnaire.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratquestionnaire.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsCtcontratquestionnaires.Add(clsCtcontratquestionnaire);
                return clsCtcontratquestionnaires;

            }

            if (string.IsNullOrEmpty(Objet.EN_CODEENTREPOT))
            {
                clsCtcontratquestionnaire.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratquestionnaire.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratquestionnaire.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratquestionnaire.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", EN_CODEENTREPOT";
                clsCtcontratquestionnaires.Add(clsCtcontratquestionnaire);
                return clsCtcontratquestionnaires;

            }

            if (string.IsNullOrEmpty(Objet.DC_CODEDOCUMENT))
            {
                clsCtcontratquestionnaire.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratquestionnaire.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratquestionnaire.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratquestionnaire.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DC_CODEDOCUMENT";
                clsCtcontratquestionnaires.Add(clsCtcontratquestionnaire);
                return clsCtcontratquestionnaires;

            }


            if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUR))
            {
                clsCtcontratquestionnaire.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratquestionnaire.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratquestionnaire.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratquestionnaire.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_CODEOPERATEUR";
                clsCtcontratquestionnaires.Add(clsCtcontratquestionnaire);
                return clsCtcontratquestionnaires;

            }

            if (string.IsNullOrEmpty(Objet.CA_CODECONTRAT))
            {
                clsCtcontratquestionnaire.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratquestionnaire.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratquestionnaire.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratquestionnaire.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CA_CODECONTRAT";
                clsCtcontratquestionnaires.Add(clsCtcontratquestionnaire);
                return clsCtcontratquestionnaires;

            }

            if (string.IsNullOrEmpty(Objet.TYPEOPERATION))
            {
                clsCtcontratquestionnaire.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratquestionnaire.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratquestionnaire.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratquestionnaire.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TYPEOPERATION";
                clsCtcontratquestionnaires.Add(clsCtcontratquestionnaire);
                return clsCtcontratquestionnaires;

            }

            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtcontratquestionnaire.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtcontratquestionnaire.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtcontratquestionnaire.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtcontratquestionnaires.Add(clsCtcontratquestionnaire);
            //    return clsCtcontratquestionnaires;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtcontratquestionnaire.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtcontratquestionnaire.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtcontratquestionnaire.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtcontratquestionnaires.Add(clsCtcontratquestionnaire);
            //    return clsCtcontratquestionnaires;

            //}


            else
            {
                clsCtcontratquestionnaire.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratquestionnaire.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtcontratquestionnaire.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtcontratquestionnaire.clsObjetRetour.SL_MESSAGE = "";
                clsCtcontratquestionnaires.Add(clsCtcontratquestionnaire);
                return clsCtcontratquestionnaires;

            }


        }

        public List<HT_Stock.BOJ.clsCtcontratquestionnaire> TestChampObligatoireInsert(HT_Stock.BOJ.clsCtcontratquestionnaire Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtcontratquestionnaire> clsCtcontratquestionnaires = new List<HT_Stock.BOJ.clsCtcontratquestionnaire>();
            HT_Stock.BOJ.clsCtcontratquestionnaire clsCtcontratquestionnaire = new HT_Stock.BOJ.clsCtcontratquestionnaire();

             if (string.IsNullOrEmpty(Objet.CA_CODECONTRAT))
            {
                clsCtcontratquestionnaire.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratquestionnaire.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratquestionnaire.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratquestionnaire.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CA_CODECONTRAT";
                clsCtcontratquestionnaires.Add(clsCtcontratquestionnaire);
                return clsCtcontratquestionnaires;

            }          

            if (string.IsNullOrEmpty(Objet.QE_CODEQUESTIONNAIRE))
            {
                clsCtcontratquestionnaire.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratquestionnaire.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratquestionnaire.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratquestionnaire.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", QE_CODEQUESTIONNAIRE";
                clsCtcontratquestionnaires.Add(clsCtcontratquestionnaire);
                return clsCtcontratquestionnaires;

            }

            if (string.IsNullOrEmpty(Objet.DC_CODEDOCUMENT))
            {
                clsCtcontratquestionnaire.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratquestionnaire.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratquestionnaire.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratquestionnaire.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DC_CODEDOCUMENT";
                clsCtcontratquestionnaires.Add(clsCtcontratquestionnaire);
                return clsCtcontratquestionnaires;

            }


            else
            {
                clsCtcontratquestionnaire.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratquestionnaire.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtcontratquestionnaire.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtcontratquestionnaire.clsObjetRetour.SL_MESSAGE = "";
                clsCtcontratquestionnaires.Add(clsCtcontratquestionnaire);
                return clsCtcontratquestionnaires;

            }


        }

        public List<HT_Stock.BOJ.clsCtcontratquestionnaire> TestChampObligatoireUpdate(HT_Stock.BOJ.clsCtcontratquestionnaire Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtcontratquestionnaire> clsCtcontratquestionnaires = new List<HT_Stock.BOJ.clsCtcontratquestionnaire>();
            HT_Stock.BOJ.clsCtcontratquestionnaire clsCtcontratquestionnaire = new HT_Stock.BOJ.clsCtcontratquestionnaire();

            if (string.IsNullOrEmpty(Objet.CA_CODECONTRAT))
            {
                clsCtcontratquestionnaire.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratquestionnaire.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratquestionnaire.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratquestionnaire.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CA_CODECONTRAT";
                clsCtcontratquestionnaires.Add(clsCtcontratquestionnaire);
                return clsCtcontratquestionnaires;

            }

            if (string.IsNullOrEmpty(Objet.QE_CODEQUESTIONNAIRE))
            {
                clsCtcontratquestionnaire.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratquestionnaire.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratquestionnaire.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratquestionnaire.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", QE_CODEQUESTIONNAIRE";
                clsCtcontratquestionnaires.Add(clsCtcontratquestionnaire);
                return clsCtcontratquestionnaires;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtcontratquestionnaire.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtcontratquestionnaire.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtcontratquestionnaire.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtcontratquestionnaires.Add(clsCtcontratquestionnaire);
            //    return clsCtcontratquestionnaires;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtcontratquestionnaire.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtcontratquestionnaire.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtcontratquestionnaire.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtcontratquestionnaires.Add(clsCtcontratquestionnaire);
            //    return clsCtcontratquestionnaires;

            //}


            else
            {
                clsCtcontratquestionnaire.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontratquestionnaire.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtcontratquestionnaire.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtcontratquestionnaire.clsObjetRetour.SL_MESSAGE = "";
            clsCtcontratquestionnaires.Add(clsCtcontratquestionnaire);
            return clsCtcontratquestionnaires;

            }


        }

        public List<HT_Stock.BOJ.clsCtcontratquestionnaire> TestChampObligatoireDelete(HT_Stock.BOJ.clsCtcontratquestionnaire Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtcontratquestionnaire> clsCtcontratquestionnaires = new List<HT_Stock.BOJ.clsCtcontratquestionnaire>();
            HT_Stock.BOJ.clsCtcontratquestionnaire clsCtcontratquestionnaire = new HT_Stock.BOJ.clsCtcontratquestionnaire();

            if (string.IsNullOrEmpty(Objet.CA_CODECONTRAT))
            {
                clsCtcontratquestionnaire.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratquestionnaire.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratquestionnaire.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratquestionnaire.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CA_CODECONTRAT";
                clsCtcontratquestionnaires.Add(clsCtcontratquestionnaire);
                return clsCtcontratquestionnaires;

            }
            else
            {
            clsCtcontratquestionnaire.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontratquestionnaire.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtcontratquestionnaire.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtcontratquestionnaire.clsObjetRetour.SL_MESSAGE = "";
            clsCtcontratquestionnaires.Add(clsCtcontratquestionnaire);
            return clsCtcontratquestionnaires;

            }


        }


    }
}