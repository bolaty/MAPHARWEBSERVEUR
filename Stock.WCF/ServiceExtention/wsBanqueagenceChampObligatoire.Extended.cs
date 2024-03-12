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
	public partial class wsBanqueagence
	{

        public List<HT_Stock.BOJ.clsBanqueagence> TestChampObligatoireListe(HT_Stock.BOJ.clsBanqueagence Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsBanqueagence> clsBanqueagences = new List<HT_Stock.BOJ.clsBanqueagence>();
            HT_Stock.BOJ.clsBanqueagence clsBanqueagence = new HT_Stock.BOJ.clsBanqueagence();

            if (string.IsNullOrEmpty(Objet.BQ_CODEBANQUE))
            {
                clsBanqueagence.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsBanqueagence.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsBanqueagence.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsBanqueagence.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", BQ_CODEBANQUE";
                clsBanqueagences.Add(clsBanqueagence);
                return clsBanqueagences;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsBanqueagence.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsBanqueagence.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsBanqueagence.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsBanqueagences.Add(clsBanqueagence);
            //    return clsBanqueagences;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsBanqueagence.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsBanqueagence.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsBanqueagence.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsBanqueagences.Add(clsBanqueagence);
            //    return clsBanqueagences;

            //}


            else
            {
                clsBanqueagence.clsObjetRetour = new Common.clsObjetRetour();
                clsBanqueagence.clsObjetRetour.SL_CODEMESSAGE = "";
                clsBanqueagence.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsBanqueagence.clsObjetRetour.SL_MESSAGE = "";
                clsBanqueagences.Add(clsBanqueagence);
                return clsBanqueagences;

            }


        }

        public List<HT_Stock.BOJ.clsBanqueagence> TestChampObligatoireInsert(HT_Stock.BOJ.clsBanqueagence Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsBanqueagence> clsBanqueagences = new List<HT_Stock.BOJ.clsBanqueagence>();
            HT_Stock.BOJ.clsBanqueagence clsBanqueagence = new HT_Stock.BOJ.clsBanqueagence();

           

            if (string.IsNullOrEmpty(Objet.AB_LIBELLE))
            {
                clsBanqueagence.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsBanqueagence.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsBanqueagence.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsBanqueagence.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AB_LIBELLE";
                clsBanqueagences.Add(clsBanqueagence);
                return clsBanqueagences;

            }

            else
            {
                clsBanqueagence.clsObjetRetour = new Common.clsObjetRetour();
                clsBanqueagence.clsObjetRetour.SL_CODEMESSAGE = "";
                clsBanqueagence.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsBanqueagence.clsObjetRetour.SL_MESSAGE = "";
                clsBanqueagences.Add(clsBanqueagence);
                return clsBanqueagences;

            }


        }

        public List<HT_Stock.BOJ.clsBanqueagence> TestChampObligatoireUpdate(HT_Stock.BOJ.clsBanqueagence Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsBanqueagence> clsBanqueagences = new List<HT_Stock.BOJ.clsBanqueagence>();
            HT_Stock.BOJ.clsBanqueagence clsBanqueagence = new HT_Stock.BOJ.clsBanqueagence();

            if (string.IsNullOrEmpty(Objet.AB_CODEAGENCEBANCAIRE))
            {
                clsBanqueagence.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsBanqueagence.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsBanqueagence.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsBanqueagence.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AB_CODEAGENCEBANCAIRE";
                clsBanqueagences.Add(clsBanqueagence);
                return clsBanqueagences;

            }

            if (string.IsNullOrEmpty(Objet.AB_LIBELLE))
            {
                clsBanqueagence.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsBanqueagence.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsBanqueagence.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsBanqueagence.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AB_LIBELLE";
                clsBanqueagences.Add(clsBanqueagence);
                return clsBanqueagences;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsBanqueagence.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsBanqueagence.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsBanqueagence.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsBanqueagences.Add(clsBanqueagence);
            //    return clsBanqueagences;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsBanqueagence.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsBanqueagence.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsBanqueagence.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsBanqueagences.Add(clsBanqueagence);
            //    return clsBanqueagences;

            //}


            else
            {
                clsBanqueagence.clsObjetRetour = new Common.clsObjetRetour();
            clsBanqueagence.clsObjetRetour.SL_CODEMESSAGE = "";
            clsBanqueagence.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsBanqueagence.clsObjetRetour.SL_MESSAGE = "";
            clsBanqueagences.Add(clsBanqueagence);
            return clsBanqueagences;

            }


        }

        public List<HT_Stock.BOJ.clsBanqueagence> TestChampObligatoireDelete(HT_Stock.BOJ.clsBanqueagence Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsBanqueagence> clsBanqueagences = new List<HT_Stock.BOJ.clsBanqueagence>();
            HT_Stock.BOJ.clsBanqueagence clsBanqueagence = new HT_Stock.BOJ.clsBanqueagence();

            if (string.IsNullOrEmpty(Objet.AB_CODEAGENCEBANCAIRE))
            {
                clsBanqueagence.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsBanqueagence.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsBanqueagence.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsBanqueagence.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AB_CODEAGENCEBANCAIRE";
                clsBanqueagences.Add(clsBanqueagence);
                return clsBanqueagences;

            }

            if (string.IsNullOrEmpty(Objet.BQ_CODEBANQUE))
            {
                clsBanqueagence.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsBanqueagence.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsBanqueagence.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsBanqueagence.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", BQ_CODEBANQUE";
                clsBanqueagences.Add(clsBanqueagence);
                return clsBanqueagences;

            }
            else
            {
            clsBanqueagence.clsObjetRetour = new Common.clsObjetRetour();
            clsBanqueagence.clsObjetRetour.SL_CODEMESSAGE = "";
            clsBanqueagence.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsBanqueagence.clsObjetRetour.SL_MESSAGE = "";
            clsBanqueagences.Add(clsBanqueagence);
            return clsBanqueagences;

            }


        }


    }
}