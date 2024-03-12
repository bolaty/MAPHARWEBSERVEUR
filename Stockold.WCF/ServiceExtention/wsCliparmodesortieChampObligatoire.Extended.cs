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
	public partial class wsCliparmodesortie
	{

        public List<HT_Stock.BOJ.clsCliparmodesortie> TestChampObligatoireListe(HT_Stock.BOJ.clsCliparmodesortie Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCliparmodesortie> clsCliparmodesorties = new List<HT_Stock.BOJ.clsCliparmodesortie>();
            HT_Stock.BOJ.clsCliparmodesortie clsCliparmodesortie = new HT_Stock.BOJ.clsCliparmodesortie();

            //if (string.IsNullOrEmpty(Objet.MS_CODEMODESORTIE))
            //{
            //    clsCliparmodesortie.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsCliparmodesortie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCliparmodesortie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsCliparmodesortie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MS_CODEMODESORTIE";
            //    clsCliparmodesorties.Add(clsCliparmodesortie);
            //    return clsCliparmodesorties;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCliparmodesortie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCliparmodesortie.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCliparmodesortie.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCliparmodesorties.Add(clsCliparmodesortie);
            //    return clsCliparmodesorties;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCliparmodesortie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCliparmodesortie.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCliparmodesortie.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCliparmodesorties.Add(clsCliparmodesortie);
            //    return clsCliparmodesorties;

            //}


            //else
            //{
                clsCliparmodesortie.clsObjetRetour = new Common.clsObjetRetour();
                clsCliparmodesortie.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCliparmodesortie.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCliparmodesortie.clsObjetRetour.SL_MESSAGE = "";
                clsCliparmodesorties.Add(clsCliparmodesortie);
                return clsCliparmodesorties;

            //}


        }

        public List<HT_Stock.BOJ.clsCliparmodesortie> TestChampObligatoireInsert(HT_Stock.BOJ.clsCliparmodesortie Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCliparmodesortie> clsCliparmodesorties = new List<HT_Stock.BOJ.clsCliparmodesortie>();
            HT_Stock.BOJ.clsCliparmodesortie clsCliparmodesortie = new HT_Stock.BOJ.clsCliparmodesortie();

           

            if (string.IsNullOrEmpty(Objet.MS_LIBELLEMODESORTIE))
            {
                clsCliparmodesortie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCliparmodesortie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCliparmodesortie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCliparmodesortie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MS_LIBELLEMODESORTIE";
                clsCliparmodesorties.Add(clsCliparmodesortie);
                return clsCliparmodesorties;

            }

            else
            {
                clsCliparmodesortie.clsObjetRetour = new Common.clsObjetRetour();
                clsCliparmodesortie.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCliparmodesortie.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCliparmodesortie.clsObjetRetour.SL_MESSAGE = "";
                clsCliparmodesorties.Add(clsCliparmodesortie);
                return clsCliparmodesorties;

            }


        }

        public List<HT_Stock.BOJ.clsCliparmodesortie> TestChampObligatoireUpdate(HT_Stock.BOJ.clsCliparmodesortie Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCliparmodesortie> clsCliparmodesorties = new List<HT_Stock.BOJ.clsCliparmodesortie>();
            HT_Stock.BOJ.clsCliparmodesortie clsCliparmodesortie = new HT_Stock.BOJ.clsCliparmodesortie();

            if (string.IsNullOrEmpty(Objet.MS_CODEMODESORTIE))
            {
                clsCliparmodesortie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCliparmodesortie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCliparmodesortie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCliparmodesortie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MS_CODEMODESORTIE";
                clsCliparmodesorties.Add(clsCliparmodesortie);
                return clsCliparmodesorties;

            }

            if (string.IsNullOrEmpty(Objet.MS_LIBELLEMODESORTIE))
            {
                clsCliparmodesortie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCliparmodesortie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCliparmodesortie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCliparmodesortie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MS_LIBELLEMODESORTIE";
                clsCliparmodesorties.Add(clsCliparmodesortie);
                return clsCliparmodesorties;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCliparmodesortie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCliparmodesortie.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCliparmodesortie.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCliparmodesorties.Add(clsCliparmodesortie);
            //    return clsCliparmodesorties;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCliparmodesortie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCliparmodesortie.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCliparmodesortie.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCliparmodesorties.Add(clsCliparmodesortie);
            //    return clsCliparmodesorties;

            //}


            else
            {
                clsCliparmodesortie.clsObjetRetour = new Common.clsObjetRetour();
            clsCliparmodesortie.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCliparmodesortie.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCliparmodesortie.clsObjetRetour.SL_MESSAGE = "";
            clsCliparmodesorties.Add(clsCliparmodesortie);
            return clsCliparmodesorties;

            }


        }

        public List<HT_Stock.BOJ.clsCliparmodesortie> TestChampObligatoireDelete(HT_Stock.BOJ.clsCliparmodesortie Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCliparmodesortie> clsCliparmodesorties = new List<HT_Stock.BOJ.clsCliparmodesortie>();
            HT_Stock.BOJ.clsCliparmodesortie clsCliparmodesortie = new HT_Stock.BOJ.clsCliparmodesortie();

            if (string.IsNullOrEmpty(Objet.MS_CODEMODESORTIE))
            {
                clsCliparmodesortie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCliparmodesortie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCliparmodesortie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCliparmodesortie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MS_CODEMODESORTIE";
                clsCliparmodesorties.Add(clsCliparmodesortie);
                return clsCliparmodesorties;

            }
            else
            {
            clsCliparmodesortie.clsObjetRetour = new Common.clsObjetRetour();
            clsCliparmodesortie.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCliparmodesortie.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCliparmodesortie.clsObjetRetour.SL_MESSAGE = "";
            clsCliparmodesorties.Add(clsCliparmodesortie);
            return clsCliparmodesorties;

            }


        }


    }
}