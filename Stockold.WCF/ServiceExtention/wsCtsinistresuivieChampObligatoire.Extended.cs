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
	public partial class wsCtsinistresuivie
	{

        public List<HT_Stock.BOJ.clsCtsinistresuivie> TestChampObligatoireListe(HT_Stock.BOJ.clsCtsinistresuivie Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtsinistresuivie> clsCtsinistresuivies = new List<HT_Stock.BOJ.clsCtsinistresuivie>();
            HT_Stock.BOJ.clsCtsinistresuivie clsCtsinistresuivie = new HT_Stock.BOJ.clsCtsinistresuivie();

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsCtsinistresuivie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistresuivie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistresuivie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistresuivie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsCtsinistresuivies.Add(clsCtsinistresuivie);
                return clsCtsinistresuivies;

            }

            if (string.IsNullOrEmpty(Objet.SI_CODESINISTRE))
            {
                clsCtsinistresuivie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistresuivie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistresuivie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistresuivie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SI_CODESINISTRE";
                clsCtsinistresuivies.Add(clsCtsinistresuivie);
                return clsCtsinistresuivies;

            }
            if (string.IsNullOrEmpty(Objet.DATEDEBUT))
            {
                clsCtsinistresuivie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistresuivie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistresuivie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistresuivie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DATEDEBUT";
                clsCtsinistresuivies.Add(clsCtsinistresuivie);
                return clsCtsinistresuivies;

            }
            if (string.IsNullOrEmpty(Objet.DATEFIN))
            {
                clsCtsinistresuivie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistresuivie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistresuivie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistresuivie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DATEFIN";
                clsCtsinistresuivies.Add(clsCtsinistresuivie);
                return clsCtsinistresuivies;

            }



            else
            {
                clsCtsinistresuivie.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistresuivie.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtsinistresuivie.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtsinistresuivie.clsObjetRetour.SL_MESSAGE = "";
                clsCtsinistresuivies.Add(clsCtsinistresuivie);
                return clsCtsinistresuivies;

            }


        }

        public List<HT_Stock.BOJ.clsCtsinistresuivie> TestChampObligatoireInsert(HT_Stock.BOJ.clsCtsinistresuivie Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtsinistresuivie> clsCtsinistresuivies = new List<HT_Stock.BOJ.clsCtsinistresuivie>();
            HT_Stock.BOJ.clsCtsinistresuivie clsCtsinistresuivie = new HT_Stock.BOJ.clsCtsinistresuivie();
           if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsCtsinistresuivie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistresuivie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistresuivie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistresuivie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsCtsinistresuivies.Add(clsCtsinistresuivie);
                return clsCtsinistresuivies;

            }
           if (string.IsNullOrEmpty(Objet.EN_CODEENTREPOT))
            {
                clsCtsinistresuivie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistresuivie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistresuivie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistresuivie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", EN_CODEENTREPOT";
                clsCtsinistresuivies.Add(clsCtsinistresuivie);
                return clsCtsinistresuivies;

            }
            if (string.IsNullOrEmpty(Objet.SI_CODESINISTRE))
            {
                clsCtsinistresuivie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistresuivie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistresuivie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistresuivie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SI_CODESINISTRE";
                clsCtsinistresuivies.Add(clsCtsinistresuivie);
                return clsCtsinistresuivies;

            }



           if (string.IsNullOrEmpty(Objet.SD_DATESAISIE))
            {
                clsCtsinistresuivie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistresuivie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistresuivie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistresuivie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SD_DATESAISIE";
                clsCtsinistresuivies.Add(clsCtsinistresuivie);
                return clsCtsinistresuivies;

            }
           if (string.IsNullOrEmpty(Objet.SD_DATESUIVIE))
            {
                clsCtsinistresuivie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistresuivie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistresuivie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistresuivie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SD_DATESUIVIE";
                clsCtsinistresuivies.Add(clsCtsinistresuivie);
                return clsCtsinistresuivies;

            }



            if (string.IsNullOrEmpty(Objet.SD_DESCRIPTIONEVENEMENT))
            {
                clsCtsinistresuivie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistresuivie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistresuivie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistresuivie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SD_DESCRIPTIONEVENEMENT";
                clsCtsinistresuivies.Add(clsCtsinistresuivie);
                return clsCtsinistresuivies;

            }

            else
            {
                clsCtsinistresuivie.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistresuivie.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtsinistresuivie.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtsinistresuivie.clsObjetRetour.SL_MESSAGE = "";
                clsCtsinistresuivies.Add(clsCtsinistresuivie);
                return clsCtsinistresuivies;

            }


        }

        public List<HT_Stock.BOJ.clsCtsinistresuivie> TestChampObligatoireUpdate(HT_Stock.BOJ.clsCtsinistresuivie Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtsinistresuivie> clsCtsinistresuivies = new List<HT_Stock.BOJ.clsCtsinistresuivie>();
            HT_Stock.BOJ.clsCtsinistresuivie clsCtsinistresuivie = new HT_Stock.BOJ.clsCtsinistresuivie();

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsCtsinistresuivie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistresuivie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistresuivie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistresuivie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsCtsinistresuivies.Add(clsCtsinistresuivie);
                return clsCtsinistresuivies;

            }
            if (string.IsNullOrEmpty(Objet.EN_CODEENTREPOT))
            {
                clsCtsinistresuivie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistresuivie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistresuivie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistresuivie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", EN_CODEENTREPOT";
                clsCtsinistresuivies.Add(clsCtsinistresuivie);
                return clsCtsinistresuivies;

            }



            if (string.IsNullOrEmpty(Objet.SD_DATESAISIE))
            {
                clsCtsinistresuivie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistresuivie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistresuivie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistresuivie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SD_DATESAISIE";
                clsCtsinistresuivies.Add(clsCtsinistresuivie);
                return clsCtsinistresuivies;

            }

            if (string.IsNullOrEmpty(Objet.SI_CODESINISTRE))
            {
                clsCtsinistresuivie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistresuivie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistresuivie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistresuivie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SI_CODESINISTRE";
                clsCtsinistresuivies.Add(clsCtsinistresuivie);
                return clsCtsinistresuivies;

            }

            if (string.IsNullOrEmpty(Objet.SD_DESCRIPTIONEVENEMENT))
            {
                clsCtsinistresuivie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistresuivie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistresuivie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistresuivie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SD_DESCRIPTIONEVENEMENT";
                clsCtsinistresuivies.Add(clsCtsinistresuivie);
                return clsCtsinistresuivies;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtsinistresuivie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtsinistresuivie.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtsinistresuivie.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtsinistresuivies.Add(clsCtsinistresuivie);
            //    return clsCtsinistresuivies;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtsinistresuivie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtsinistresuivie.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtsinistresuivie.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtsinistresuivies.Add(clsCtsinistresuivie);
            //    return clsCtsinistresuivies;

            //}


            else
            {
                clsCtsinistresuivie.clsObjetRetour = new Common.clsObjetRetour();
            clsCtsinistresuivie.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtsinistresuivie.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtsinistresuivie.clsObjetRetour.SL_MESSAGE = "";
            clsCtsinistresuivies.Add(clsCtsinistresuivie);
            return clsCtsinistresuivies;

            }


        }

        public List<HT_Stock.BOJ.clsCtsinistresuivie> TestChampObligatoireDelete(HT_Stock.BOJ.clsCtsinistresuivie Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtsinistresuivie> clsCtsinistresuivies = new List<HT_Stock.BOJ.clsCtsinistresuivie>();
            HT_Stock.BOJ.clsCtsinistresuivie clsCtsinistresuivie = new HT_Stock.BOJ.clsCtsinistresuivie();


            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsCtsinistresuivie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistresuivie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistresuivie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistresuivie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsCtsinistresuivies.Add(clsCtsinistresuivie);
                return clsCtsinistresuivies;

            }
            if (string.IsNullOrEmpty(Objet.SD_INDEXSUIVIE))
            {
                clsCtsinistresuivie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistresuivie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistresuivie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistresuivie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SD_INDEXSUIVIE";
                clsCtsinistresuivies.Add(clsCtsinistresuivie);
                return clsCtsinistresuivies;

            }
            if (string.IsNullOrEmpty(Objet.SD_DATESAISIE))
            {
                clsCtsinistresuivie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistresuivie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistresuivie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistresuivie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SD_DATESAISIE";
                clsCtsinistresuivies.Add(clsCtsinistresuivie);
                return clsCtsinistresuivies;

            }



            if (string.IsNullOrEmpty(Objet.SI_CODESINISTRE))
            {
                clsCtsinistresuivie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistresuivie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistresuivie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistresuivie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SI_CODESINISTRE";
                clsCtsinistresuivies.Add(clsCtsinistresuivie);
                return clsCtsinistresuivies;

            }
            else
            {
            clsCtsinistresuivie.clsObjetRetour = new Common.clsObjetRetour();
            clsCtsinistresuivie.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtsinistresuivie.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtsinistresuivie.clsObjetRetour.SL_MESSAGE = "";
            clsCtsinistresuivies.Add(clsCtsinistresuivie);
            return clsCtsinistresuivies;

            }


        }


    }
}