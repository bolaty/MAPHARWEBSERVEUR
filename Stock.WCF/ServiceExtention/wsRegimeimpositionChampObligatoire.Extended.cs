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
	public partial class wsRegimeimposition
	{

        public List<HT_Stock.BOJ.clsRegimeimposition> TestChampObligatoireListe(HT_Stock.BOJ.clsRegimeimposition Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsRegimeimposition> clsRegimeimpositions = new List<HT_Stock.BOJ.clsRegimeimposition>();
            HT_Stock.BOJ.clsRegimeimposition clsRegimeimposition = new HT_Stock.BOJ.clsRegimeimposition();

            //if (string.IsNullOrEmpty(Objet.RE_CODEREGIMEIMPOSITION))
            //{
            //    clsRegimeimposition.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsRegimeimposition.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsRegimeimposition.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsRegimeimposition.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", RE_CODEREGIMEIMPOSITION";
            //    clsRegimeimpositions.Add(clsRegimeimposition);
            //    return clsRegimeimpositions;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsRegimeimposition.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsRegimeimposition.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsRegimeimposition.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsRegimeimpositions.Add(clsRegimeimposition);
            //    return clsRegimeimpositions;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsRegimeimposition.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsRegimeimposition.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsRegimeimposition.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsRegimeimpositions.Add(clsRegimeimposition);
            //    return clsRegimeimpositions;

            //}


            //else
            //{
                clsRegimeimposition.clsObjetRetour = new Common.clsObjetRetour();
                clsRegimeimposition.clsObjetRetour.SL_CODEMESSAGE = "";
                clsRegimeimposition.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsRegimeimposition.clsObjetRetour.SL_MESSAGE = "";
                clsRegimeimpositions.Add(clsRegimeimposition);
                return clsRegimeimpositions;

            //}


        }

        public List<HT_Stock.BOJ.clsRegimeimposition> TestChampObligatoireInsert(HT_Stock.BOJ.clsRegimeimposition Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsRegimeimposition> clsRegimeimpositions = new List<HT_Stock.BOJ.clsRegimeimposition>();
            HT_Stock.BOJ.clsRegimeimposition clsRegimeimposition = new HT_Stock.BOJ.clsRegimeimposition();

           

            if (string.IsNullOrEmpty(Objet.RE_LIBELLEREGIMEIMPOSITION))
            {
                clsRegimeimposition.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsRegimeimposition.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsRegimeimposition.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsRegimeimposition.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", RE_LIBELLEREGIMEIMPOSITION";
                clsRegimeimpositions.Add(clsRegimeimposition);
                return clsRegimeimpositions;

            }

            else
            {
                clsRegimeimposition.clsObjetRetour = new Common.clsObjetRetour();
                clsRegimeimposition.clsObjetRetour.SL_CODEMESSAGE = "";
                clsRegimeimposition.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsRegimeimposition.clsObjetRetour.SL_MESSAGE = "";
                clsRegimeimpositions.Add(clsRegimeimposition);
                return clsRegimeimpositions;

            }


        }

        public List<HT_Stock.BOJ.clsRegimeimposition> TestChampObligatoireUpdate(HT_Stock.BOJ.clsRegimeimposition Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsRegimeimposition> clsRegimeimpositions = new List<HT_Stock.BOJ.clsRegimeimposition>();
            HT_Stock.BOJ.clsRegimeimposition clsRegimeimposition = new HT_Stock.BOJ.clsRegimeimposition();

            if (string.IsNullOrEmpty(Objet.RE_CODEREGIMEIMPOSITION))
            {
                clsRegimeimposition.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsRegimeimposition.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsRegimeimposition.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsRegimeimposition.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", RE_CODEREGIMEIMPOSITION";
                clsRegimeimpositions.Add(clsRegimeimposition);
                return clsRegimeimpositions;

            }

            if (string.IsNullOrEmpty(Objet.RE_LIBELLEREGIMEIMPOSITION))
            {
                clsRegimeimposition.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsRegimeimposition.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsRegimeimposition.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsRegimeimposition.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", RE_LIBELLEREGIMEIMPOSITION";
                clsRegimeimpositions.Add(clsRegimeimposition);
                return clsRegimeimpositions;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsRegimeimposition.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsRegimeimposition.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsRegimeimposition.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsRegimeimpositions.Add(clsRegimeimposition);
            //    return clsRegimeimpositions;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsRegimeimposition.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsRegimeimposition.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsRegimeimposition.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsRegimeimpositions.Add(clsRegimeimposition);
            //    return clsRegimeimpositions;

            //}


            else
            {
                clsRegimeimposition.clsObjetRetour = new Common.clsObjetRetour();
            clsRegimeimposition.clsObjetRetour.SL_CODEMESSAGE = "";
            clsRegimeimposition.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsRegimeimposition.clsObjetRetour.SL_MESSAGE = "";
            clsRegimeimpositions.Add(clsRegimeimposition);
            return clsRegimeimpositions;

            }


        }

        public List<HT_Stock.BOJ.clsRegimeimposition> TestChampObligatoireDelete(HT_Stock.BOJ.clsRegimeimposition Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsRegimeimposition> clsRegimeimpositions = new List<HT_Stock.BOJ.clsRegimeimposition>();
            HT_Stock.BOJ.clsRegimeimposition clsRegimeimposition = new HT_Stock.BOJ.clsRegimeimposition();

            if (string.IsNullOrEmpty(Objet.RE_CODEREGIMEIMPOSITION))
            {
                clsRegimeimposition.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsRegimeimposition.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsRegimeimposition.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsRegimeimposition.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", RE_CODEREGIMEIMPOSITION";
                clsRegimeimpositions.Add(clsRegimeimposition);
                return clsRegimeimpositions;

            }
            else
            {
            clsRegimeimposition.clsObjetRetour = new Common.clsObjetRetour();
            clsRegimeimposition.clsObjetRetour.SL_CODEMESSAGE = "";
            clsRegimeimposition.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsRegimeimposition.clsObjetRetour.SL_MESSAGE = "";
            clsRegimeimpositions.Add(clsRegimeimposition);
            return clsRegimeimpositions;

            }


        }


    }
}