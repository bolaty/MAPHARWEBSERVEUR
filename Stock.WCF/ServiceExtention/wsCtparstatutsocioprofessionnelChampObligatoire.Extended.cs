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
	public partial class wsCtparstatutsocioprofessionnel
	{

        public List<HT_Stock.BOJ.clsCtparstatutsocioprofessionnel> TestChampObligatoireListe(HT_Stock.BOJ.clsCtparstatutsocioprofessionnel Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparstatutsocioprofessionnel> clsCtparstatutsocioprofessionnels = new List<HT_Stock.BOJ.clsCtparstatutsocioprofessionnel>();
            HT_Stock.BOJ.clsCtparstatutsocioprofessionnel clsCtparstatutsocioprofessionnel = new HT_Stock.BOJ.clsCtparstatutsocioprofessionnel();

            //if (string.IsNullOrEmpty(Objet.ST_CODESTATUTSOCIOPROF))
            //{
            //    clsCtparstatutsocioprofessionnel.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ST_CODESTATUTSOCIOPROF";
            //    clsCtparstatutsocioprofessionnels.Add(clsCtparstatutsocioprofessionnel);
            //    return clsCtparstatutsocioprofessionnels;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparstatutsocioprofessionnels.Add(clsCtparstatutsocioprofessionnel);
            //    return clsCtparstatutsocioprofessionnels;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparstatutsocioprofessionnels.Add(clsCtparstatutsocioprofessionnel);
            //    return clsCtparstatutsocioprofessionnels;

            //}


            //else
            //{
                clsCtparstatutsocioprofessionnel.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_MESSAGE = "";
                clsCtparstatutsocioprofessionnels.Add(clsCtparstatutsocioprofessionnel);
                return clsCtparstatutsocioprofessionnels;

            //}


        }

        public List<HT_Stock.BOJ.clsCtparstatutsocioprofessionnel> TestChampObligatoireInsert(HT_Stock.BOJ.clsCtparstatutsocioprofessionnel Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparstatutsocioprofessionnel> clsCtparstatutsocioprofessionnels = new List<HT_Stock.BOJ.clsCtparstatutsocioprofessionnel>();
            HT_Stock.BOJ.clsCtparstatutsocioprofessionnel clsCtparstatutsocioprofessionnel = new HT_Stock.BOJ.clsCtparstatutsocioprofessionnel();

           

            if (string.IsNullOrEmpty(Objet.ST_LIBELLESTATUTSOCIOPROF1))
            {
                clsCtparstatutsocioprofessionnel.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ST_LIBELLESTATUTSOCIOPROF1";
                clsCtparstatutsocioprofessionnels.Add(clsCtparstatutsocioprofessionnel);
                return clsCtparstatutsocioprofessionnels;

            }

            else
            {
                clsCtparstatutsocioprofessionnel.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_MESSAGE = "";
                clsCtparstatutsocioprofessionnels.Add(clsCtparstatutsocioprofessionnel);
                return clsCtparstatutsocioprofessionnels;

            }


        }

        public List<HT_Stock.BOJ.clsCtparstatutsocioprofessionnel> TestChampObligatoireUpdate(HT_Stock.BOJ.clsCtparstatutsocioprofessionnel Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparstatutsocioprofessionnel> clsCtparstatutsocioprofessionnels = new List<HT_Stock.BOJ.clsCtparstatutsocioprofessionnel>();
            HT_Stock.BOJ.clsCtparstatutsocioprofessionnel clsCtparstatutsocioprofessionnel = new HT_Stock.BOJ.clsCtparstatutsocioprofessionnel();

            if (string.IsNullOrEmpty(Objet.ST_CODESTATUTSOCIOPROF))
            {
                clsCtparstatutsocioprofessionnel.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ST_CODESTATUTSOCIOPROF";
                clsCtparstatutsocioprofessionnels.Add(clsCtparstatutsocioprofessionnel);
                return clsCtparstatutsocioprofessionnels;

            }

            if (string.IsNullOrEmpty(Objet.ST_LIBELLESTATUTSOCIOPROF1))
            {
                clsCtparstatutsocioprofessionnel.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ST_LIBELLESTATUTSOCIOPROF1";
                clsCtparstatutsocioprofessionnels.Add(clsCtparstatutsocioprofessionnel);
                return clsCtparstatutsocioprofessionnels;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparstatutsocioprofessionnels.Add(clsCtparstatutsocioprofessionnel);
            //    return clsCtparstatutsocioprofessionnels;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparstatutsocioprofessionnels.Add(clsCtparstatutsocioprofessionnel);
            //    return clsCtparstatutsocioprofessionnels;

            //}


            else
            {
                clsCtparstatutsocioprofessionnel.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_MESSAGE = "";
            clsCtparstatutsocioprofessionnels.Add(clsCtparstatutsocioprofessionnel);
            return clsCtparstatutsocioprofessionnels;

            }


        }

        public List<HT_Stock.BOJ.clsCtparstatutsocioprofessionnel> TestChampObligatoireDelete(HT_Stock.BOJ.clsCtparstatutsocioprofessionnel Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparstatutsocioprofessionnel> clsCtparstatutsocioprofessionnels = new List<HT_Stock.BOJ.clsCtparstatutsocioprofessionnel>();
            HT_Stock.BOJ.clsCtparstatutsocioprofessionnel clsCtparstatutsocioprofessionnel = new HT_Stock.BOJ.clsCtparstatutsocioprofessionnel();

            if (string.IsNullOrEmpty(Objet.ST_CODESTATUTSOCIOPROF))
            {
                clsCtparstatutsocioprofessionnel.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ST_CODESTATUTSOCIOPROF";
                clsCtparstatutsocioprofessionnels.Add(clsCtparstatutsocioprofessionnel);
                return clsCtparstatutsocioprofessionnels;

            }
            else
            {
            clsCtparstatutsocioprofessionnel.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparstatutsocioprofessionnel.clsObjetRetour.SL_MESSAGE = "";
            clsCtparstatutsocioprofessionnels.Add(clsCtparstatutsocioprofessionnel);
            return clsCtparstatutsocioprofessionnels;

            }


        }


    }
}