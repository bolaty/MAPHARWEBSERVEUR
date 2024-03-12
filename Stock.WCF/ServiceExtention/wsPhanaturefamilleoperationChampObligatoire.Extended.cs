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
	public partial class wsPhanaturefamilleoperation
	{

        public List<HT_Stock.BOJ.clsPhanaturefamilleoperation> TestChampObligatoireListe(HT_Stock.BOJ.clsPhanaturefamilleoperation Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhanaturefamilleoperation> clsPhanaturefamilleoperations = new List<HT_Stock.BOJ.clsPhanaturefamilleoperation>();
            HT_Stock.BOJ.clsPhanaturefamilleoperation clsPhanaturefamilleoperation = new HT_Stock.BOJ.clsPhanaturefamilleoperation();

            //if (string.IsNullOrEmpty(Objet.NF_CODENATUREFAMILLEOPERATION))
            //{
            //    clsPhanaturefamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsPhanaturefamilleoperation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhanaturefamilleoperation.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsPhanaturefamilleoperation.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", NF_CODENATUREFAMILLEOPERATION";
            //    clsPhanaturefamilleoperations.Add(clsPhanaturefamilleoperation);
            //    return clsPhanaturefamilleoperations;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhanaturefamilleoperation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhanaturefamilleoperation.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhanaturefamilleoperation.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhanaturefamilleoperations.Add(clsPhanaturefamilleoperation);
            //    return clsPhanaturefamilleoperations;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhanaturefamilleoperation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhanaturefamilleoperation.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhanaturefamilleoperation.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhanaturefamilleoperations.Add(clsPhanaturefamilleoperation);
            //    return clsPhanaturefamilleoperations;

            //}


            //else
            //{
                clsPhanaturefamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
                clsPhanaturefamilleoperation.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhanaturefamilleoperation.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhanaturefamilleoperation.clsObjetRetour.SL_MESSAGE = "";
                clsPhanaturefamilleoperations.Add(clsPhanaturefamilleoperation);
                return clsPhanaturefamilleoperations;

            //}


        }

        public List<HT_Stock.BOJ.clsPhanaturefamilleoperation> TestChampObligatoireInsert(HT_Stock.BOJ.clsPhanaturefamilleoperation Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhanaturefamilleoperation> clsPhanaturefamilleoperations = new List<HT_Stock.BOJ.clsPhanaturefamilleoperation>();
            HT_Stock.BOJ.clsPhanaturefamilleoperation clsPhanaturefamilleoperation = new HT_Stock.BOJ.clsPhanaturefamilleoperation();

           

            if (string.IsNullOrEmpty(Objet.NF_LIBELLENATUREFAMILLEOPERATION1))
            {
                clsPhanaturefamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhanaturefamilleoperation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhanaturefamilleoperation.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhanaturefamilleoperation.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", NF_LIBELLENATUREFAMILLEOPERATION1";
                clsPhanaturefamilleoperations.Add(clsPhanaturefamilleoperation);
                return clsPhanaturefamilleoperations;

            }

            else
            {
                clsPhanaturefamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
                clsPhanaturefamilleoperation.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhanaturefamilleoperation.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhanaturefamilleoperation.clsObjetRetour.SL_MESSAGE = "";
                clsPhanaturefamilleoperations.Add(clsPhanaturefamilleoperation);
                return clsPhanaturefamilleoperations;

            }


        }

        public List<HT_Stock.BOJ.clsPhanaturefamilleoperation> TestChampObligatoireUpdate(HT_Stock.BOJ.clsPhanaturefamilleoperation Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhanaturefamilleoperation> clsPhanaturefamilleoperations = new List<HT_Stock.BOJ.clsPhanaturefamilleoperation>();
            HT_Stock.BOJ.clsPhanaturefamilleoperation clsPhanaturefamilleoperation = new HT_Stock.BOJ.clsPhanaturefamilleoperation();

            if (string.IsNullOrEmpty(Objet.NF_CODENATUREFAMILLEOPERATION))
            {
                clsPhanaturefamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhanaturefamilleoperation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhanaturefamilleoperation.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhanaturefamilleoperation.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", NF_CODENATUREFAMILLEOPERATION";
                clsPhanaturefamilleoperations.Add(clsPhanaturefamilleoperation);
                return clsPhanaturefamilleoperations;

            }

            if (string.IsNullOrEmpty(Objet.NF_LIBELLENATUREFAMILLEOPERATION1))
            {
                clsPhanaturefamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhanaturefamilleoperation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhanaturefamilleoperation.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhanaturefamilleoperation.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", NF_LIBELLENATUREFAMILLEOPERATION1";
                clsPhanaturefamilleoperations.Add(clsPhanaturefamilleoperation);
                return clsPhanaturefamilleoperations;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhanaturefamilleoperation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhanaturefamilleoperation.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhanaturefamilleoperation.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhanaturefamilleoperations.Add(clsPhanaturefamilleoperation);
            //    return clsPhanaturefamilleoperations;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhanaturefamilleoperation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhanaturefamilleoperation.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhanaturefamilleoperation.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhanaturefamilleoperations.Add(clsPhanaturefamilleoperation);
            //    return clsPhanaturefamilleoperations;

            //}


            else
            {
                clsPhanaturefamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
            clsPhanaturefamilleoperation.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhanaturefamilleoperation.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhanaturefamilleoperation.clsObjetRetour.SL_MESSAGE = "";
            clsPhanaturefamilleoperations.Add(clsPhanaturefamilleoperation);
            return clsPhanaturefamilleoperations;

            }


        }

        public List<HT_Stock.BOJ.clsPhanaturefamilleoperation> TestChampObligatoireDelete(HT_Stock.BOJ.clsPhanaturefamilleoperation Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhanaturefamilleoperation> clsPhanaturefamilleoperations = new List<HT_Stock.BOJ.clsPhanaturefamilleoperation>();
            HT_Stock.BOJ.clsPhanaturefamilleoperation clsPhanaturefamilleoperation = new HT_Stock.BOJ.clsPhanaturefamilleoperation();

            if (string.IsNullOrEmpty(Objet.NF_CODENATUREFAMILLEOPERATION))
            {
                clsPhanaturefamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhanaturefamilleoperation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhanaturefamilleoperation.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhanaturefamilleoperation.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", NF_CODENATUREFAMILLEOPERATION";
                clsPhanaturefamilleoperations.Add(clsPhanaturefamilleoperation);
                return clsPhanaturefamilleoperations;

            }
            else
            {
            clsPhanaturefamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
            clsPhanaturefamilleoperation.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhanaturefamilleoperation.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhanaturefamilleoperation.clsObjetRetour.SL_MESSAGE = "";
            clsPhanaturefamilleoperations.Add(clsPhanaturefamilleoperation);
            return clsPhanaturefamilleoperations;

            }


        }


    }
}