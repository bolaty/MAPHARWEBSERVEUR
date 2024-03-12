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
	public partial class wsPhaparrayon
	{

        public List<HT_Stock.BOJ.clsPhaparrayon> TestChampObligatoireListe(HT_Stock.BOJ.clsPhaparrayon Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhaparrayon> clsPhaparrayons = new List<HT_Stock.BOJ.clsPhaparrayon>();
            HT_Stock.BOJ.clsPhaparrayon clsPhaparrayon = new HT_Stock.BOJ.clsPhaparrayon();

            //if (string.IsNullOrEmpty(Objet.RY_CODERAYON))
            //{
            //    clsPhaparrayon.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsPhaparrayon.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhaparrayon.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsPhaparrayon.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", RY_CODERAYON";
            //    clsPhaparrayons.Add(clsPhaparrayon);
            //    return clsPhaparrayons;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhaparrayon.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhaparrayon.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhaparrayon.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhaparrayons.Add(clsPhaparrayon);
            //    return clsPhaparrayons;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhaparrayon.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhaparrayon.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhaparrayon.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhaparrayons.Add(clsPhaparrayon);
            //    return clsPhaparrayons;

            //}


            //else
            //{
                clsPhaparrayon.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparrayon.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhaparrayon.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhaparrayon.clsObjetRetour.SL_MESSAGE = "";
                clsPhaparrayons.Add(clsPhaparrayon);
                return clsPhaparrayons;

            //}


        }

        public List<HT_Stock.BOJ.clsPhaparrayon> TestChampObligatoireInsert(HT_Stock.BOJ.clsPhaparrayon Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhaparrayon> clsPhaparrayons = new List<HT_Stock.BOJ.clsPhaparrayon>();
            HT_Stock.BOJ.clsPhaparrayon clsPhaparrayon = new HT_Stock.BOJ.clsPhaparrayon();

           

            if (string.IsNullOrEmpty(Objet.RY_LIBELLE))
            {
                clsPhaparrayon.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhaparrayon.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhaparrayon.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhaparrayon.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", RY_LIBELLE";
                clsPhaparrayons.Add(clsPhaparrayon);
                return clsPhaparrayons;

            }

            else
            {
                clsPhaparrayon.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparrayon.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhaparrayon.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhaparrayon.clsObjetRetour.SL_MESSAGE = "";
                clsPhaparrayons.Add(clsPhaparrayon);
                return clsPhaparrayons;

            }


        }

        public List<HT_Stock.BOJ.clsPhaparrayon> TestChampObligatoireUpdate(HT_Stock.BOJ.clsPhaparrayon Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhaparrayon> clsPhaparrayons = new List<HT_Stock.BOJ.clsPhaparrayon>();
            HT_Stock.BOJ.clsPhaparrayon clsPhaparrayon = new HT_Stock.BOJ.clsPhaparrayon();

            if (string.IsNullOrEmpty(Objet.RY_CODERAYON))
            {
                clsPhaparrayon.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhaparrayon.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhaparrayon.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhaparrayon.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", RY_CODERAYON";
                clsPhaparrayons.Add(clsPhaparrayon);
                return clsPhaparrayons;

            }

            if (string.IsNullOrEmpty(Objet.RY_LIBELLE))
            {
                clsPhaparrayon.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhaparrayon.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhaparrayon.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhaparrayon.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", RY_LIBELLE";
                clsPhaparrayons.Add(clsPhaparrayon);
                return clsPhaparrayons;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhaparrayon.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhaparrayon.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhaparrayon.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhaparrayons.Add(clsPhaparrayon);
            //    return clsPhaparrayons;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhaparrayon.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhaparrayon.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhaparrayon.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhaparrayons.Add(clsPhaparrayon);
            //    return clsPhaparrayons;

            //}


            else
            {
                clsPhaparrayon.clsObjetRetour = new Common.clsObjetRetour();
            clsPhaparrayon.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhaparrayon.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhaparrayon.clsObjetRetour.SL_MESSAGE = "";
            clsPhaparrayons.Add(clsPhaparrayon);
            return clsPhaparrayons;

            }


        }

        public List<HT_Stock.BOJ.clsPhaparrayon> TestChampObligatoireDelete(HT_Stock.BOJ.clsPhaparrayon Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhaparrayon> clsPhaparrayons = new List<HT_Stock.BOJ.clsPhaparrayon>();
            HT_Stock.BOJ.clsPhaparrayon clsPhaparrayon = new HT_Stock.BOJ.clsPhaparrayon();

            if (string.IsNullOrEmpty(Objet.RY_CODERAYON))
            {
                clsPhaparrayon.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhaparrayon.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhaparrayon.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhaparrayon.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", RY_CODERAYON";
                clsPhaparrayons.Add(clsPhaparrayon);
                return clsPhaparrayons;

            }
            else
            {
            clsPhaparrayon.clsObjetRetour = new Common.clsObjetRetour();
            clsPhaparrayon.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhaparrayon.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhaparrayon.clsObjetRetour.SL_MESSAGE = "";
            clsPhaparrayons.Add(clsPhaparrayon);
            return clsPhaparrayons;

            }


        }


    }
}