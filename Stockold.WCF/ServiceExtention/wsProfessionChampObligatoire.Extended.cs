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
	public partial class wsProfession
	{

        public List<HT_Stock.BOJ.clsProfession> TestChampObligatoireListe(HT_Stock.BOJ.clsProfession Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsProfession> clsProfessions = new List<HT_Stock.BOJ.clsProfession>();
            HT_Stock.BOJ.clsProfession clsProfession = new HT_Stock.BOJ.clsProfession();

            //if (string.IsNullOrEmpty(Objet.PF_CODEPROFESSION))
            //{
            //    clsProfession.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsProfession.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsProfession.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsProfession.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PF_CODEPROFESSION";
            //    clsProfessions.Add(clsProfession);
            //    return clsProfessions;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsProfession.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsProfession.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsProfession.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsProfessions.Add(clsProfession);
            //    return clsProfessions;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsProfession.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsProfession.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsProfession.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsProfessions.Add(clsProfession);
            //    return clsProfessions;

            //}


            //else
            //{
                clsProfession.clsObjetRetour = new Common.clsObjetRetour();
                clsProfession.clsObjetRetour.SL_CODEMESSAGE = "";
                clsProfession.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsProfession.clsObjetRetour.SL_MESSAGE = "";
                clsProfessions.Add(clsProfession);
                return clsProfessions;

            //}


        }

        public List<HT_Stock.BOJ.clsProfession> TestChampObligatoireInsert(HT_Stock.BOJ.clsProfession Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsProfession> clsProfessions = new List<HT_Stock.BOJ.clsProfession>();
            HT_Stock.BOJ.clsProfession clsProfession = new HT_Stock.BOJ.clsProfession();

           

            if (string.IsNullOrEmpty(Objet.PF_LIBELLE))
            {
                clsProfession.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsProfession.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsProfession.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsProfession.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PF_LIBELLE";
                clsProfessions.Add(clsProfession);
                return clsProfessions;

            }

            else
            {
                clsProfession.clsObjetRetour = new Common.clsObjetRetour();
                clsProfession.clsObjetRetour.SL_CODEMESSAGE = "";
                clsProfession.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsProfession.clsObjetRetour.SL_MESSAGE = "";
                clsProfessions.Add(clsProfession);
                return clsProfessions;

            }


        }

        public List<HT_Stock.BOJ.clsProfession> TestChampObligatoireUpdate(HT_Stock.BOJ.clsProfession Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsProfession> clsProfessions = new List<HT_Stock.BOJ.clsProfession>();
            HT_Stock.BOJ.clsProfession clsProfession = new HT_Stock.BOJ.clsProfession();

            if (string.IsNullOrEmpty(Objet.PF_CODEPROFESSION))
            {
                clsProfession.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsProfession.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsProfession.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsProfession.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PF_CODEPROFESSION";
                clsProfessions.Add(clsProfession);
                return clsProfessions;

            }

            if (string.IsNullOrEmpty(Objet.PF_LIBELLE))
            {
                clsProfession.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsProfession.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsProfession.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsProfession.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PF_LIBELLE";
                clsProfessions.Add(clsProfession);
                return clsProfessions;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsProfession.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsProfession.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsProfession.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsProfessions.Add(clsProfession);
            //    return clsProfessions;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsProfession.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsProfession.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsProfession.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsProfessions.Add(clsProfession);
            //    return clsProfessions;

            //}


            else
            {
                clsProfession.clsObjetRetour = new Common.clsObjetRetour();
            clsProfession.clsObjetRetour.SL_CODEMESSAGE = "";
            clsProfession.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsProfession.clsObjetRetour.SL_MESSAGE = "";
            clsProfessions.Add(clsProfession);
            return clsProfessions;

            }


        }

        public List<HT_Stock.BOJ.clsProfession> TestChampObligatoireDelete(HT_Stock.BOJ.clsProfession Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsProfession> clsProfessions = new List<HT_Stock.BOJ.clsProfession>();
            HT_Stock.BOJ.clsProfession clsProfession = new HT_Stock.BOJ.clsProfession();

            if (string.IsNullOrEmpty(Objet.PF_CODEPROFESSION))
            {
                clsProfession.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsProfession.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsProfession.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsProfession.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PF_CODEPROFESSION";
                clsProfessions.Add(clsProfession);
                return clsProfessions;

            }
            else
            {
            clsProfession.clsObjetRetour = new Common.clsObjetRetour();
            clsProfession.clsObjetRetour.SL_CODEMESSAGE = "";
            clsProfession.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsProfession.clsObjetRetour.SL_MESSAGE = "";
            clsProfessions.Add(clsProfession);
            return clsProfessions;

            }


        }


    }
}