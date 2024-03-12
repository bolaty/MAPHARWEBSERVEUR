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
	public partial class wsProfil
	{

        public List<HT_Stock.BOJ.clsProfil> TestChampObligatoireListe(HT_Stock.BOJ.clsProfil Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsProfil> clsProfils = new List<HT_Stock.BOJ.clsProfil>();
            HT_Stock.BOJ.clsProfil clsProfil = new HT_Stock.BOJ.clsProfil();

            //if (string.IsNullOrEmpty(Objet.PO_CODEPROFIL))
            //{
            //    clsProfil.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsProfil.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsProfil.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsProfil.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PO_CODEPROFIL";
            //    clsProfils.Add(clsProfil);
            //    return clsProfils;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsProfil.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsProfil.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsProfil.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsProfils.Add(clsProfil);
            //    return clsProfils;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsProfil.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsProfil.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsProfil.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsProfils.Add(clsProfil);
            //    return clsProfils;

            //}


            //else
            //{
                clsProfil.clsObjetRetour = new Common.clsObjetRetour();
                clsProfil.clsObjetRetour.SL_CODEMESSAGE = "";
                clsProfil.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsProfil.clsObjetRetour.SL_MESSAGE = "";
                clsProfils.Add(clsProfil);
                return clsProfils;

            //}


        }

        public List<HT_Stock.BOJ.clsProfil> TestChampObligatoireInsert(HT_Stock.BOJ.clsProfil Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsProfil> clsProfils = new List<HT_Stock.BOJ.clsProfil>();
            HT_Stock.BOJ.clsProfil clsProfil = new HT_Stock.BOJ.clsProfil();

           

            if (string.IsNullOrEmpty(Objet.PO_LIBELLE))
            {
                clsProfil.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsProfil.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsProfil.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsProfil.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PO_LIBELLE";
                clsProfils.Add(clsProfil);
                return clsProfils;

            }

            else
            {
                clsProfil.clsObjetRetour = new Common.clsObjetRetour();
                clsProfil.clsObjetRetour.SL_CODEMESSAGE = "";
                clsProfil.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsProfil.clsObjetRetour.SL_MESSAGE = "";
                clsProfils.Add(clsProfil);
                return clsProfils;

            }


        }

        public List<HT_Stock.BOJ.clsProfil> TestChampObligatoireUpdate(HT_Stock.BOJ.clsProfil Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsProfil> clsProfils = new List<HT_Stock.BOJ.clsProfil>();
            HT_Stock.BOJ.clsProfil clsProfil = new HT_Stock.BOJ.clsProfil();

            if (string.IsNullOrEmpty(Objet.PO_CODEPROFIL))
            {
                clsProfil.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsProfil.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsProfil.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsProfil.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PO_CODEPROFIL";
                clsProfils.Add(clsProfil);
                return clsProfils;

            }

            if (string.IsNullOrEmpty(Objet.PO_LIBELLE))
            {
                clsProfil.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsProfil.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsProfil.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsProfil.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PO_LIBELLE";
                clsProfils.Add(clsProfil);
                return clsProfils;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsProfil.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsProfil.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsProfil.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsProfils.Add(clsProfil);
            //    return clsProfils;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsProfil.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsProfil.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsProfil.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsProfils.Add(clsProfil);
            //    return clsProfils;

            //}


            else
            {
                clsProfil.clsObjetRetour = new Common.clsObjetRetour();
            clsProfil.clsObjetRetour.SL_CODEMESSAGE = "";
            clsProfil.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsProfil.clsObjetRetour.SL_MESSAGE = "";
            clsProfils.Add(clsProfil);
            return clsProfils;

            }


        }

        public List<HT_Stock.BOJ.clsProfil> TestChampObligatoireDelete(HT_Stock.BOJ.clsProfil Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsProfil> clsProfils = new List<HT_Stock.BOJ.clsProfil>();
            HT_Stock.BOJ.clsProfil clsProfil = new HT_Stock.BOJ.clsProfil();

            if (string.IsNullOrEmpty(Objet.PO_CODEPROFIL))
            {
                clsProfil.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsProfil.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsProfil.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsProfil.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PO_CODEPROFIL";
                clsProfils.Add(clsProfil);
                return clsProfils;

            }
            else
            {
            clsProfil.clsObjetRetour = new Common.clsObjetRetour();
            clsProfil.clsObjetRetour.SL_CODEMESSAGE = "";
            clsProfil.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsProfil.clsObjetRetour.SL_MESSAGE = "";
            clsProfils.Add(clsProfil);
            return clsProfils;

            }


        }


    }
}