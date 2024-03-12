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
	public partial class wsPhapararticle
	{

        public List<HT_Stock.BOJ.clsPhapararticle> TestChampObligatoireListe(HT_Stock.BOJ.clsPhapararticle Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhapararticle> clsPhapararticles = new List<HT_Stock.BOJ.clsPhapararticle>();
            HT_Stock.BOJ.clsPhapararticle clsPhapararticle = new HT_Stock.BOJ.clsPhapararticle();

            if (string.IsNullOrEmpty(Objet.TA_CODETYPEARTICLE))
            {
                clsPhapararticle.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhapararticle.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhapararticle.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhapararticle.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TA_CODETYPEARTICLE";
                clsPhapararticles.Add(clsPhapararticle);
                return clsPhapararticles;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhapararticle.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhapararticle.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhapararticle.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhapararticles.Add(clsPhapararticle);
            //    return clsPhapararticles;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhapararticle.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhapararticle.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhapararticle.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhapararticles.Add(clsPhapararticle);
            //    return clsPhapararticles;

            //}


            //else
            //{
            clsPhapararticle.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapararticle.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhapararticle.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhapararticle.clsObjetRetour.SL_MESSAGE = "";
                clsPhapararticles.Add(clsPhapararticle);
                return clsPhapararticles;

            //}


        }

        public List<HT_Stock.BOJ.clsPhapararticle> TestChampObligatoireInsert(HT_Stock.BOJ.clsPhapararticle Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhapararticle> clsPhapararticles = new List<HT_Stock.BOJ.clsPhapararticle>();
            HT_Stock.BOJ.clsPhapararticle clsPhapararticle = new HT_Stock.BOJ.clsPhapararticle();

           

            if (string.IsNullOrEmpty(Objet.AR_NOMCOMMERCIALE))
            {
                clsPhapararticle.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhapararticle.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhapararticle.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhapararticle.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AR_NOMCOMMERCIALE";
                clsPhapararticles.Add(clsPhapararticle);
                return clsPhapararticles;

            }

            else
            {
                clsPhapararticle.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapararticle.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhapararticle.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhapararticle.clsObjetRetour.SL_MESSAGE = "";
                clsPhapararticles.Add(clsPhapararticle);
                return clsPhapararticles;

            }


        }

        public List<HT_Stock.BOJ.clsPhapararticle> TestChampObligatoireUpdate(HT_Stock.BOJ.clsPhapararticle Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhapararticle> clsPhapararticles = new List<HT_Stock.BOJ.clsPhapararticle>();
            HT_Stock.BOJ.clsPhapararticle clsPhapararticle = new HT_Stock.BOJ.clsPhapararticle();

            if (string.IsNullOrEmpty(Objet.AR_CODEARTICLE))
            {
                clsPhapararticle.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhapararticle.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhapararticle.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhapararticle.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AR_CODEARTICLE";
                clsPhapararticles.Add(clsPhapararticle);
                return clsPhapararticles;

            }

            if (string.IsNullOrEmpty(Objet.AR_NOMCOMMERCIALE))
            {
                clsPhapararticle.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhapararticle.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhapararticle.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhapararticle.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AR_NOMCOMMERCIALE";
                clsPhapararticles.Add(clsPhapararticle);
                return clsPhapararticles;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhapararticle.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhapararticle.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhapararticle.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhapararticles.Add(clsPhapararticle);
            //    return clsPhapararticles;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhapararticle.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhapararticle.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhapararticle.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhapararticles.Add(clsPhapararticle);
            //    return clsPhapararticles;

            //}


            else
            {
                clsPhapararticle.clsObjetRetour = new Common.clsObjetRetour();
            clsPhapararticle.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhapararticle.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhapararticle.clsObjetRetour.SL_MESSAGE = "";
            clsPhapararticles.Add(clsPhapararticle);
            return clsPhapararticles;

            }


        }

        public List<HT_Stock.BOJ.clsPhapararticle> TestChampObligatoireDelete(HT_Stock.BOJ.clsPhapararticle Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhapararticle> clsPhapararticles = new List<HT_Stock.BOJ.clsPhapararticle>();
            HT_Stock.BOJ.clsPhapararticle clsPhapararticle = new HT_Stock.BOJ.clsPhapararticle();

            if (string.IsNullOrEmpty(Objet.AR_CODEARTICLE))
            {
                clsPhapararticle.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhapararticle.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhapararticle.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhapararticle.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AR_CODEARTICLE";
                clsPhapararticles.Add(clsPhapararticle);
                return clsPhapararticles;

            }
            else
            {
            clsPhapararticle.clsObjetRetour = new Common.clsObjetRetour();
            clsPhapararticle.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhapararticle.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhapararticle.clsObjetRetour.SL_MESSAGE = "";
            clsPhapararticles.Add(clsPhapararticle);
            return clsPhapararticles;

            }


        }


    }
}