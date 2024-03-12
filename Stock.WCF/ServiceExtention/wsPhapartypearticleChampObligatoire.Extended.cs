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
	public partial class wsPhapartypearticle
	{

        public List<HT_Stock.BOJ.clsPhapartypearticle> TestChampObligatoireListe(HT_Stock.BOJ.clsPhapartypearticle Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhapartypearticle> clsPhapartypearticles = new List<HT_Stock.BOJ.clsPhapartypearticle>();
            HT_Stock.BOJ.clsPhapartypearticle clsPhapartypearticle = new HT_Stock.BOJ.clsPhapartypearticle();

            if (string.IsNullOrEmpty(Objet.NT_CODENATURETYPEARTICLE))
            {
                clsPhapartypearticle.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhapartypearticle.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhapartypearticle.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhapartypearticle.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", NT_CODENATURETYPEARTICLE";
                clsPhapartypearticles.Add(clsPhapartypearticle);
                return clsPhapartypearticles;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhapartypearticle.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhapartypearticle.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhapartypearticle.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhapartypearticles.Add(clsPhapartypearticle);
            //    return clsPhapartypearticles;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhapartypearticle.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhapartypearticle.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhapartypearticle.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhapartypearticles.Add(clsPhapartypearticle);
            //    return clsPhapartypearticles;

            //}


            //else
            //{
            clsPhapartypearticle.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapartypearticle.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhapartypearticle.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhapartypearticle.clsObjetRetour.SL_MESSAGE = "";
                clsPhapartypearticles.Add(clsPhapartypearticle);
                return clsPhapartypearticles;

            //}


        }

        public List<HT_Stock.BOJ.clsPhapartypearticle> TestChampObligatoireInsert(HT_Stock.BOJ.clsPhapartypearticle Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhapartypearticle> clsPhapartypearticles = new List<HT_Stock.BOJ.clsPhapartypearticle>();
            HT_Stock.BOJ.clsPhapartypearticle clsPhapartypearticle = new HT_Stock.BOJ.clsPhapartypearticle();

           

            if (string.IsNullOrEmpty(Objet.TA_LIBELLE))
            {
                clsPhapartypearticle.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhapartypearticle.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhapartypearticle.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhapartypearticle.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TA_LIBELLE";
                clsPhapartypearticles.Add(clsPhapartypearticle);
                return clsPhapartypearticles;

            }

            else
            {
                clsPhapartypearticle.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapartypearticle.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhapartypearticle.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhapartypearticle.clsObjetRetour.SL_MESSAGE = "";
                clsPhapartypearticles.Add(clsPhapartypearticle);
                return clsPhapartypearticles;

            }


        }

        public List<HT_Stock.BOJ.clsPhapartypearticle> TestChampObligatoireUpdate(HT_Stock.BOJ.clsPhapartypearticle Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhapartypearticle> clsPhapartypearticles = new List<HT_Stock.BOJ.clsPhapartypearticle>();
            HT_Stock.BOJ.clsPhapartypearticle clsPhapartypearticle = new HT_Stock.BOJ.clsPhapartypearticle();

            if (string.IsNullOrEmpty(Objet.TA_CODETYPEARTICLE))
            {
                clsPhapartypearticle.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhapartypearticle.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhapartypearticle.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhapartypearticle.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TA_CODETYPEARTICLE";
                clsPhapartypearticles.Add(clsPhapartypearticle);
                return clsPhapartypearticles;

            }

            if (string.IsNullOrEmpty(Objet.TA_LIBELLE))
            {
                clsPhapartypearticle.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhapartypearticle.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhapartypearticle.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhapartypearticle.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TA_LIBELLE";
                clsPhapartypearticles.Add(clsPhapartypearticle);
                return clsPhapartypearticles;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhapartypearticle.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhapartypearticle.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhapartypearticle.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhapartypearticles.Add(clsPhapartypearticle);
            //    return clsPhapartypearticles;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhapartypearticle.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhapartypearticle.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhapartypearticle.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhapartypearticles.Add(clsPhapartypearticle);
            //    return clsPhapartypearticles;

            //}


            else
            {
                clsPhapartypearticle.clsObjetRetour = new Common.clsObjetRetour();
            clsPhapartypearticle.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhapartypearticle.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhapartypearticle.clsObjetRetour.SL_MESSAGE = "";
            clsPhapartypearticles.Add(clsPhapartypearticle);
            return clsPhapartypearticles;

            }


        }

        public List<HT_Stock.BOJ.clsPhapartypearticle> TestChampObligatoireDelete(HT_Stock.BOJ.clsPhapartypearticle Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhapartypearticle> clsPhapartypearticles = new List<HT_Stock.BOJ.clsPhapartypearticle>();
            HT_Stock.BOJ.clsPhapartypearticle clsPhapartypearticle = new HT_Stock.BOJ.clsPhapartypearticle();

            if (string.IsNullOrEmpty(Objet.TA_CODETYPEARTICLE))
            {
                clsPhapartypearticle.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhapartypearticle.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhapartypearticle.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhapartypearticle.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TA_CODETYPEARTICLE";
                clsPhapartypearticles.Add(clsPhapartypearticle);
                return clsPhapartypearticles;

            }
            else
            {
            clsPhapartypearticle.clsObjetRetour = new Common.clsObjetRetour();
            clsPhapartypearticle.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhapartypearticle.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhapartypearticle.clsObjetRetour.SL_MESSAGE = "";
            clsPhapartypearticles.Add(clsPhapartypearticle);
            return clsPhapartypearticles;

            }


        }


    }
}