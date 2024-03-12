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
	public partial class wsSexe
	{

        public List<HT_Stock.BOJ.clsSexe> TestChampObligatoireListe(HT_Stock.BOJ.clsSexe Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsSexe> clsSexes = new List<HT_Stock.BOJ.clsSexe>();
            HT_Stock.BOJ.clsSexe clsSexe = new HT_Stock.BOJ.clsSexe();

            //if (string.IsNullOrEmpty(Objet.SX_CODESEXE))
            //{
            //    clsSexe.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsSexe.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsSexe.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsSexe.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SX_CODESEXE";
            //    clsSexes.Add(clsSexe);
            //    return clsSexes;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsSexe.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsSexe.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsSexe.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsSexes.Add(clsSexe);
            //    return clsSexes;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsSexe.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsSexe.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsSexe.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsSexes.Add(clsSexe);
            //    return clsSexes;

            //}


            //else
            //{
                clsSexe.clsObjetRetour = new Common.clsObjetRetour();
                clsSexe.clsObjetRetour.SL_CODEMESSAGE = "";
                clsSexe.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsSexe.clsObjetRetour.SL_MESSAGE = "";
                clsSexes.Add(clsSexe);
                return clsSexes;

            //}


        }

        public List<HT_Stock.BOJ.clsSexe> TestChampObligatoireInsert(HT_Stock.BOJ.clsSexe Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsSexe> clsSexes = new List<HT_Stock.BOJ.clsSexe>();
            HT_Stock.BOJ.clsSexe clsSexe = new HT_Stock.BOJ.clsSexe();

           

            if (string.IsNullOrEmpty(Objet.SX_LIBELLE))
            {
                clsSexe.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsSexe.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsSexe.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsSexe.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SX_LIBELLE";
                clsSexes.Add(clsSexe);
                return clsSexes;

            }

            else
            {
                clsSexe.clsObjetRetour = new Common.clsObjetRetour();
                clsSexe.clsObjetRetour.SL_CODEMESSAGE = "";
                clsSexe.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsSexe.clsObjetRetour.SL_MESSAGE = "";
                clsSexes.Add(clsSexe);
                return clsSexes;

            }


        }

        public List<HT_Stock.BOJ.clsSexe> TestChampObligatoireUpdate(HT_Stock.BOJ.clsSexe Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsSexe> clsSexes = new List<HT_Stock.BOJ.clsSexe>();
            HT_Stock.BOJ.clsSexe clsSexe = new HT_Stock.BOJ.clsSexe();

            if (string.IsNullOrEmpty(Objet.SX_CODESEXE))
            {
                clsSexe.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsSexe.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsSexe.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsSexe.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SX_CODESEXE";
                clsSexes.Add(clsSexe);
                return clsSexes;

            }

            if (string.IsNullOrEmpty(Objet.SX_LIBELLE))
            {
                clsSexe.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsSexe.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsSexe.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsSexe.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SX_LIBELLE";
                clsSexes.Add(clsSexe);
                return clsSexes;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsSexe.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsSexe.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsSexe.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsSexes.Add(clsSexe);
            //    return clsSexes;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsSexe.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsSexe.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsSexe.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsSexes.Add(clsSexe);
            //    return clsSexes;

            //}


            else
            {
                clsSexe.clsObjetRetour = new Common.clsObjetRetour();
            clsSexe.clsObjetRetour.SL_CODEMESSAGE = "";
            clsSexe.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsSexe.clsObjetRetour.SL_MESSAGE = "";
            clsSexes.Add(clsSexe);
            return clsSexes;

            }


        }

        public List<HT_Stock.BOJ.clsSexe> TestChampObligatoireDelete(HT_Stock.BOJ.clsSexe Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsSexe> clsSexes = new List<HT_Stock.BOJ.clsSexe>();
            HT_Stock.BOJ.clsSexe clsSexe = new HT_Stock.BOJ.clsSexe();

            if (string.IsNullOrEmpty(Objet.SX_CODESEXE))
            {
                clsSexe.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsSexe.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsSexe.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsSexe.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SX_CODESEXE";
                clsSexes.Add(clsSexe);
                return clsSexes;

            }
            else
            {
            clsSexe.clsObjetRetour = new Common.clsObjetRetour();
            clsSexe.clsObjetRetour.SL_CODEMESSAGE = "";
            clsSexe.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsSexe.clsObjetRetour.SL_MESSAGE = "";
            clsSexes.Add(clsSexe);
            return clsSexes;

            }


        }


    }
}