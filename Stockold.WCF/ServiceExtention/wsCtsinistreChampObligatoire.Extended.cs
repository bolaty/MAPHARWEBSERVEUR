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
	public partial class wsCtsinistre
	{

        public List<HT_Stock.BOJ.clsCtsinistre> TestChampObligatoireListe(HT_Stock.BOJ.clsCtsinistre Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtsinistre> clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();
            HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistre.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistre.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsCtsinistres.Add(clsCtsinistre);
                return clsCtsinistres;

            }



            if (string.IsNullOrEmpty(Objet.EN_CODEENTREPOT))
            {
                clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistre.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistre.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", EN_CODEENTREPOT";
                clsCtsinistres.Add(clsCtsinistre);
                return clsCtsinistres;

            }
            if (string.IsNullOrEmpty(Objet.CA_CODECONTRAT))
            {
                clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistre.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistre.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CA_CODECONTRAT";
                clsCtsinistres.Add(clsCtsinistre);
                return clsCtsinistres;

            }
        if (string.IsNullOrEmpty(Objet.DATEDEBUT))
        {
            clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsCtsinistre.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsCtsinistre.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DATEDEBUT";
            clsCtsinistres.Add(clsCtsinistre);
            return clsCtsinistres;

        }

        if (string.IsNullOrEmpty(Objet.DATEFIN))
        {
            clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsCtsinistre.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsCtsinistre.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DATEFIN";
            clsCtsinistres.Add(clsCtsinistre);
            return clsCtsinistres;

        }

        if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUR))
        {
            clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsCtsinistre.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsCtsinistre.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_CODEOPERATEUR";
            clsCtsinistres.Add(clsCtsinistre);
            return clsCtsinistres;

        }

        if (string.IsNullOrEmpty(Objet.TYPEOPERATION))
        {
            clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsCtsinistre.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsCtsinistre.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TYPEOPERATION";
            clsCtsinistres.Add(clsCtsinistre);
            return clsCtsinistres;

        }

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtsinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtsinistre.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtsinistres.Add(clsCtsinistre);
            //    return clsCtsinistres;

            //}


            //else
            //{
            clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtsinistre.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtsinistre.clsObjetRetour.SL_MESSAGE = "";
                clsCtsinistres.Add(clsCtsinistre);
                return clsCtsinistres;

            //}


        }

        public List<HT_Stock.BOJ.clsCtsinistre> TestChampObligatoireInsert(HT_Stock.BOJ.clsCtsinistre Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtsinistre> clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();
            HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();

           

            if (string.IsNullOrEmpty(Objet.SI_NUMSINISTRE))
            {
                clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistre.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistre.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SI_NUMSINISTRE";
                clsCtsinistres.Add(clsCtsinistre);
                return clsCtsinistres;

            }

            else
            {
                clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtsinistre.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtsinistre.clsObjetRetour.SL_MESSAGE = "";
                clsCtsinistres.Add(clsCtsinistre);
                return clsCtsinistres;

            }


        }

        public List<HT_Stock.BOJ.clsCtsinistre> TestChampObligatoireUpdate(HT_Stock.BOJ.clsCtsinistre Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtsinistre> clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();
            HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();

            if (string.IsNullOrEmpty(Objet.SI_CODESINISTRE))
            {
                clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistre.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistre.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SI_CODESINISTRE";
                clsCtsinistres.Add(clsCtsinistre);
                return clsCtsinistres;

            }

            if (string.IsNullOrEmpty(Objet.SI_NUMSINISTRE))
            {
                clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistre.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistre.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SI_NUMSINISTRE";
                clsCtsinistres.Add(clsCtsinistre);
                return clsCtsinistres;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtsinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtsinistre.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtsinistres.Add(clsCtsinistre);
            //    return clsCtsinistres;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtsinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtsinistre.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtsinistres.Add(clsCtsinistre);
            //    return clsCtsinistres;

            //}


            else
            {
                clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
            clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtsinistre.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtsinistre.clsObjetRetour.SL_MESSAGE = "";
            clsCtsinistres.Add(clsCtsinistre);
            return clsCtsinistres;

            }


        }


        public List<HT_Stock.BOJ.clsCtsinistre> TestChampObligatoireUpdateStatut(HT_Stock.BOJ.clsCtsinistre Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtsinistre> clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();
            HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();

            if (string.IsNullOrEmpty(Objet.SI_CODESINISTRE))
            {
                clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistre.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistre.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SI_CODESINISTRE";
                clsCtsinistres.Add(clsCtsinistre);
                return clsCtsinistres;

            }

            //if (string.IsNullOrEmpty(Objet.SI_NUMSINISTRE))
            //{
            //    clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtsinistre.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsCtsinistre.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SI_NUMSINISTRE";
            //    clsCtsinistres.Add(clsCtsinistre);
            //    return clsCtsinistres;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtsinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtsinistre.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtsinistres.Add(clsCtsinistre);
            //    return clsCtsinistres;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtsinistre.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtsinistre.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtsinistres.Add(clsCtsinistre);
            //    return clsCtsinistres;

            //}


            else
            {
                clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtsinistre.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtsinistre.clsObjetRetour.SL_MESSAGE = "";
                clsCtsinistres.Add(clsCtsinistre);
                return clsCtsinistres;

            }


        }

        public List<HT_Stock.BOJ.clsCtsinistre> TestChampObligatoireDelete(HT_Stock.BOJ.clsCtsinistre Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtsinistre> clsCtsinistres = new List<HT_Stock.BOJ.clsCtsinistre>();
            HT_Stock.BOJ.clsCtsinistre clsCtsinistre = new HT_Stock.BOJ.clsCtsinistre();

            if (string.IsNullOrEmpty(Objet.SI_CODESINISTRE))
            {
                clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistre.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistre.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SI_CODESINISTRE";
                clsCtsinistres.Add(clsCtsinistre);
                return clsCtsinistres;

            }
            else
            {
            clsCtsinistre.clsObjetRetour = new Common.clsObjetRetour();
            clsCtsinistre.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtsinistre.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtsinistre.clsObjetRetour.SL_MESSAGE = "";
            clsCtsinistres.Add(clsCtsinistre);
            return clsCtsinistres;

            }


        }


    }
}