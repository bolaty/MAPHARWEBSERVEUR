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
	public partial class wsPhaparnaturetypearticle
	{

        public List<HT_Stock.BOJ.clsPhaparnaturetypearticle> TestChampObligatoireListe(HT_Stock.BOJ.clsPhaparnaturetypearticle Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhaparnaturetypearticle> clsPhaparnaturetypearticles = new List<HT_Stock.BOJ.clsPhaparnaturetypearticle>();
            HT_Stock.BOJ.clsPhaparnaturetypearticle clsPhaparnaturetypearticle = new HT_Stock.BOJ.clsPhaparnaturetypearticle();

            if (string.IsNullOrEmpty(Objet.PP_CODEMODEGESTION))
            {
                clsPhaparnaturetypearticle.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhaparnaturetypearticle.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhaparnaturetypearticle.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhaparnaturetypearticle.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PP_CODEMODEGESTION";
                clsPhaparnaturetypearticles.Add(clsPhaparnaturetypearticle);
                return clsPhaparnaturetypearticles;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhaparnaturetypearticle.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhaparnaturetypearticle.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhaparnaturetypearticle.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhaparnaturetypearticles.Add(clsPhaparnaturetypearticle);
            //    return clsPhaparnaturetypearticles;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhaparnaturetypearticle.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhaparnaturetypearticle.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhaparnaturetypearticle.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhaparnaturetypearticles.Add(clsPhaparnaturetypearticle);
            //    return clsPhaparnaturetypearticles;

            //}


            //else
            //{
            clsPhaparnaturetypearticle.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparnaturetypearticle.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhaparnaturetypearticle.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhaparnaturetypearticle.clsObjetRetour.SL_MESSAGE = "";
                clsPhaparnaturetypearticles.Add(clsPhaparnaturetypearticle);
                return clsPhaparnaturetypearticles;

            //}


        }

        public List<HT_Stock.BOJ.clsPhaparnaturetypearticle> TestChampObligatoireInsert(HT_Stock.BOJ.clsPhaparnaturetypearticle Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhaparnaturetypearticle> clsPhaparnaturetypearticles = new List<HT_Stock.BOJ.clsPhaparnaturetypearticle>();
            HT_Stock.BOJ.clsPhaparnaturetypearticle clsPhaparnaturetypearticle = new HT_Stock.BOJ.clsPhaparnaturetypearticle();

           

            if (string.IsNullOrEmpty(Objet.NT_LIBELLE))
            {
                clsPhaparnaturetypearticle.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhaparnaturetypearticle.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhaparnaturetypearticle.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhaparnaturetypearticle.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", NT_LIBELLE";
                clsPhaparnaturetypearticles.Add(clsPhaparnaturetypearticle);
                return clsPhaparnaturetypearticles;

            }

            else
            {
                clsPhaparnaturetypearticle.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparnaturetypearticle.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhaparnaturetypearticle.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhaparnaturetypearticle.clsObjetRetour.SL_MESSAGE = "";
                clsPhaparnaturetypearticles.Add(clsPhaparnaturetypearticle);
                return clsPhaparnaturetypearticles;

            }


        }

        public List<HT_Stock.BOJ.clsPhaparnaturetypearticle> TestChampObligatoireUpdate(HT_Stock.BOJ.clsPhaparnaturetypearticle Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhaparnaturetypearticle> clsPhaparnaturetypearticles = new List<HT_Stock.BOJ.clsPhaparnaturetypearticle>();
            HT_Stock.BOJ.clsPhaparnaturetypearticle clsPhaparnaturetypearticle = new HT_Stock.BOJ.clsPhaparnaturetypearticle();

            if (string.IsNullOrEmpty(Objet.NT_CODENATURETYPEARTICLE))
            {
                clsPhaparnaturetypearticle.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhaparnaturetypearticle.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhaparnaturetypearticle.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhaparnaturetypearticle.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", NT_CODENATURETYPEARTICLE";
                clsPhaparnaturetypearticles.Add(clsPhaparnaturetypearticle);
                return clsPhaparnaturetypearticles;

            }

            if (string.IsNullOrEmpty(Objet.NT_LIBELLE))
            {
                clsPhaparnaturetypearticle.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhaparnaturetypearticle.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhaparnaturetypearticle.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhaparnaturetypearticle.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", NT_LIBELLE";
                clsPhaparnaturetypearticles.Add(clsPhaparnaturetypearticle);
                return clsPhaparnaturetypearticles;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhaparnaturetypearticle.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhaparnaturetypearticle.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhaparnaturetypearticle.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhaparnaturetypearticles.Add(clsPhaparnaturetypearticle);
            //    return clsPhaparnaturetypearticles;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhaparnaturetypearticle.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhaparnaturetypearticle.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhaparnaturetypearticle.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhaparnaturetypearticles.Add(clsPhaparnaturetypearticle);
            //    return clsPhaparnaturetypearticles;

            //}


            else
            {
                clsPhaparnaturetypearticle.clsObjetRetour = new Common.clsObjetRetour();
            clsPhaparnaturetypearticle.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhaparnaturetypearticle.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhaparnaturetypearticle.clsObjetRetour.SL_MESSAGE = "";
            clsPhaparnaturetypearticles.Add(clsPhaparnaturetypearticle);
            return clsPhaparnaturetypearticles;

            }


        }

        public List<HT_Stock.BOJ.clsPhaparnaturetypearticle> TestChampObligatoireDelete(HT_Stock.BOJ.clsPhaparnaturetypearticle Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhaparnaturetypearticle> clsPhaparnaturetypearticles = new List<HT_Stock.BOJ.clsPhaparnaturetypearticle>();
            HT_Stock.BOJ.clsPhaparnaturetypearticle clsPhaparnaturetypearticle = new HT_Stock.BOJ.clsPhaparnaturetypearticle();

            if (string.IsNullOrEmpty(Objet.NT_CODENATURETYPEARTICLE))
            {
                clsPhaparnaturetypearticle.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhaparnaturetypearticle.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhaparnaturetypearticle.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhaparnaturetypearticle.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", NT_CODENATURETYPEARTICLE";
                clsPhaparnaturetypearticles.Add(clsPhaparnaturetypearticle);
                return clsPhaparnaturetypearticles;

            }
            else
            {
            clsPhaparnaturetypearticle.clsObjetRetour = new Common.clsObjetRetour();
            clsPhaparnaturetypearticle.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhaparnaturetypearticle.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhaparnaturetypearticle.clsObjetRetour.SL_MESSAGE = "";
            clsPhaparnaturetypearticles.Add(clsPhaparnaturetypearticle);
            return clsPhaparnaturetypearticles;

            }


        }


    }
}