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
	public partial class wsLogiciel
	{

        public List<HT_Stock.BOJ.clsLogiciel> TestChampObligatoireListe(HT_Stock.BOJ.clsLogiciel Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsLogiciel> clsLogiciels = new List<HT_Stock.BOJ.clsLogiciel>();
            HT_Stock.BOJ.clsLogiciel clsLogiciel = new HT_Stock.BOJ.clsLogiciel();

            //if (string.IsNullOrEmpty(Objet.LO_CODELOGICIEL))
            //{
            //    clsLogiciel.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsLogiciel.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsLogiciel.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsLogiciel.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", LO_CODELOGICIEL";
            //    clsLogiciels.Add(clsLogiciel);
            //    return clsLogiciels;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsLogiciel.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsLogiciel.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsLogiciel.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsLogiciels.Add(clsLogiciel);
            //    return clsLogiciels;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsLogiciel.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsLogiciel.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsLogiciel.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsLogiciels.Add(clsLogiciel);
            //    return clsLogiciels;

            //}


            //else
            //{
                clsLogiciel.clsObjetRetour = new Common.clsObjetRetour();
                clsLogiciel.clsObjetRetour.SL_CODEMESSAGE = "";
                clsLogiciel.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsLogiciel.clsObjetRetour.SL_MESSAGE = "";
                clsLogiciels.Add(clsLogiciel);
                return clsLogiciels;

            //}


        }

        public List<HT_Stock.BOJ.clsLogiciel> TestChampObligatoireInsert(HT_Stock.BOJ.clsLogiciel Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsLogiciel> clsLogiciels = new List<HT_Stock.BOJ.clsLogiciel>();
            HT_Stock.BOJ.clsLogiciel clsLogiciel = new HT_Stock.BOJ.clsLogiciel();

           

            if (string.IsNullOrEmpty(Objet.LO_LIBELLE))
            {
                clsLogiciel.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsLogiciel.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsLogiciel.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsLogiciel.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", LO_LIBELLE";
                clsLogiciels.Add(clsLogiciel);
                return clsLogiciels;

            }

            else
            {
                clsLogiciel.clsObjetRetour = new Common.clsObjetRetour();
                clsLogiciel.clsObjetRetour.SL_CODEMESSAGE = "";
                clsLogiciel.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsLogiciel.clsObjetRetour.SL_MESSAGE = "";
                clsLogiciels.Add(clsLogiciel);
                return clsLogiciels;

            }


        }

        public List<HT_Stock.BOJ.clsLogiciel> TestChampObligatoireUpdate(HT_Stock.BOJ.clsLogiciel Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsLogiciel> clsLogiciels = new List<HT_Stock.BOJ.clsLogiciel>();
            HT_Stock.BOJ.clsLogiciel clsLogiciel = new HT_Stock.BOJ.clsLogiciel();

            if (string.IsNullOrEmpty(Objet.LO_CODELOGICIEL))
            {
                clsLogiciel.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsLogiciel.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsLogiciel.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsLogiciel.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", LO_CODELOGICIEL";
                clsLogiciels.Add(clsLogiciel);
                return clsLogiciels;

            }

            if (string.IsNullOrEmpty(Objet.LO_LIBELLE))
            {
                clsLogiciel.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsLogiciel.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsLogiciel.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsLogiciel.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", LO_LIBELLE";
                clsLogiciels.Add(clsLogiciel);
                return clsLogiciels;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsLogiciel.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsLogiciel.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsLogiciel.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsLogiciels.Add(clsLogiciel);
            //    return clsLogiciels;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsLogiciel.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsLogiciel.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsLogiciel.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsLogiciels.Add(clsLogiciel);
            //    return clsLogiciels;

            //}


            else
            {
                clsLogiciel.clsObjetRetour = new Common.clsObjetRetour();
            clsLogiciel.clsObjetRetour.SL_CODEMESSAGE = "";
            clsLogiciel.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsLogiciel.clsObjetRetour.SL_MESSAGE = "";
            clsLogiciels.Add(clsLogiciel);
            return clsLogiciels;

            }


        }

        public List<HT_Stock.BOJ.clsLogiciel> TestChampObligatoireDelete(HT_Stock.BOJ.clsLogiciel Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsLogiciel> clsLogiciels = new List<HT_Stock.BOJ.clsLogiciel>();
            HT_Stock.BOJ.clsLogiciel clsLogiciel = new HT_Stock.BOJ.clsLogiciel();

            if (string.IsNullOrEmpty(Objet.LO_CODELOGICIEL))
            {
                clsLogiciel.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsLogiciel.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsLogiciel.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsLogiciel.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", LO_CODELOGICIEL";
                clsLogiciels.Add(clsLogiciel);
                return clsLogiciels;

            }
            else
            {
            clsLogiciel.clsObjetRetour = new Common.clsObjetRetour();
            clsLogiciel.clsObjetRetour.SL_CODEMESSAGE = "";
            clsLogiciel.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsLogiciel.clsObjetRetour.SL_MESSAGE = "";
            clsLogiciels.Add(clsLogiciel);
            return clsLogiciels;

            }


        }


    }
}