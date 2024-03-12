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
	public partial class wsActivite
	{

        public List<HT_Stock.BOJ.clsActivite> TestChampObligatoireListe(HT_Stock.BOJ.clsActivite Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsActivite> clsActivites = new List<HT_Stock.BOJ.clsActivite>();
            HT_Stock.BOJ.clsActivite clsActivite = new HT_Stock.BOJ.clsActivite();

            //if (string.IsNullOrEmpty(Objet.AC_CODEACTIVITE))
            //{
            //    clsActivite.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsActivite.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsActivite.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsActivite.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AC_CODEACTIVITE";
            //    clsActivites.Add(clsActivite);
            //    return clsActivites;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsActivite.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsActivite.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsActivite.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsActivites.Add(clsActivite);
            //    return clsActivites;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsActivite.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsActivite.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsActivite.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsActivites.Add(clsActivite);
            //    return clsActivites;

            //}


            //else
            //{
                clsActivite.clsObjetRetour = new Common.clsObjetRetour();
                clsActivite.clsObjetRetour.SL_CODEMESSAGE = "";
                clsActivite.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsActivite.clsObjetRetour.SL_MESSAGE = "";
                clsActivites.Add(clsActivite);
                return clsActivites;

            //}


        }

        public List<HT_Stock.BOJ.clsActivite> TestChampObligatoireInsert(HT_Stock.BOJ.clsActivite Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsActivite> clsActivites = new List<HT_Stock.BOJ.clsActivite>();
            HT_Stock.BOJ.clsActivite clsActivite = new HT_Stock.BOJ.clsActivite();

           

            if (string.IsNullOrEmpty(Objet.AC_LIBELLE))
            {
                clsActivite.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsActivite.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsActivite.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsActivite.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AC_LIBELLE";
                clsActivites.Add(clsActivite);
                return clsActivites;

            }

            else
            {
                clsActivite.clsObjetRetour = new Common.clsObjetRetour();
                clsActivite.clsObjetRetour.SL_CODEMESSAGE = "";
                clsActivite.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsActivite.clsObjetRetour.SL_MESSAGE = "";
                clsActivites.Add(clsActivite);
                return clsActivites;

            }


        }

        public List<HT_Stock.BOJ.clsActivite> TestChampObligatoireUpdate(HT_Stock.BOJ.clsActivite Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsActivite> clsActivites = new List<HT_Stock.BOJ.clsActivite>();
            HT_Stock.BOJ.clsActivite clsActivite = new HT_Stock.BOJ.clsActivite();

            if (string.IsNullOrEmpty(Objet.AC_CODEACTIVITE))
            {
                clsActivite.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsActivite.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsActivite.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsActivite.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AC_CODEACTIVITE";
                clsActivites.Add(clsActivite);
                return clsActivites;

            }

            if (string.IsNullOrEmpty(Objet.AC_LIBELLE))
            {
                clsActivite.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsActivite.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsActivite.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsActivite.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AC_LIBELLE";
                clsActivites.Add(clsActivite);
                return clsActivites;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsActivite.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsActivite.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsActivite.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsActivites.Add(clsActivite);
            //    return clsActivites;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsActivite.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsActivite.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsActivite.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsActivites.Add(clsActivite);
            //    return clsActivites;

            //}


            else
            {
                clsActivite.clsObjetRetour = new Common.clsObjetRetour();
            clsActivite.clsObjetRetour.SL_CODEMESSAGE = "";
            clsActivite.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsActivite.clsObjetRetour.SL_MESSAGE = "";
            clsActivites.Add(clsActivite);
            return clsActivites;

            }


        }

        public List<HT_Stock.BOJ.clsActivite> TestChampObligatoireDelete(HT_Stock.BOJ.clsActivite Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsActivite> clsActivites = new List<HT_Stock.BOJ.clsActivite>();
            HT_Stock.BOJ.clsActivite clsActivite = new HT_Stock.BOJ.clsActivite();

            if (string.IsNullOrEmpty(Objet.AC_CODEACTIVITE))
            {
                clsActivite.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsActivite.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsActivite.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsActivite.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AC_CODEACTIVITE";
                clsActivites.Add(clsActivite);
                return clsActivites;

            }
            else
            {
            clsActivite.clsObjetRetour = new Common.clsObjetRetour();
            clsActivite.clsObjetRetour.SL_CODEMESSAGE = "";
            clsActivite.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsActivite.clsObjetRetour.SL_MESSAGE = "";
            clsActivites.Add(clsActivite);
            return clsActivites;

            }


        }


    }
}