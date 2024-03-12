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
	public partial class wsCliparspecialite
	{

        public List<HT_Stock.BOJ.clsCliparspecialite> TestChampObligatoireListe(HT_Stock.BOJ.clsCliparspecialite Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCliparspecialite> clsCliparspecialites = new List<HT_Stock.BOJ.clsCliparspecialite>();
            HT_Stock.BOJ.clsCliparspecialite clsCliparspecialite = new HT_Stock.BOJ.clsCliparspecialite();

            //if (string.IsNullOrEmpty(Objet.SP_CODESPECIALITE))
            //{
            //    clsCliparspecialite.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsCliparspecialite.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCliparspecialite.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsCliparspecialite.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SP_CODESPECIALITE";
            //    clsCliparspecialites.Add(clsCliparspecialite);
            //    return clsCliparspecialites;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCliparspecialite.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCliparspecialite.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCliparspecialite.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCliparspecialites.Add(clsCliparspecialite);
            //    return clsCliparspecialites;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCliparspecialite.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCliparspecialite.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCliparspecialite.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCliparspecialites.Add(clsCliparspecialite);
            //    return clsCliparspecialites;

            //}


            //else
            //{
                clsCliparspecialite.clsObjetRetour = new Common.clsObjetRetour();
                clsCliparspecialite.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCliparspecialite.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCliparspecialite.clsObjetRetour.SL_MESSAGE = "";
                clsCliparspecialites.Add(clsCliparspecialite);
                return clsCliparspecialites;

            //}


        }

        public List<HT_Stock.BOJ.clsCliparspecialite> TestChampObligatoireInsert(HT_Stock.BOJ.clsCliparspecialite Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCliparspecialite> clsCliparspecialites = new List<HT_Stock.BOJ.clsCliparspecialite>();
            HT_Stock.BOJ.clsCliparspecialite clsCliparspecialite = new HT_Stock.BOJ.clsCliparspecialite();

           

            if (string.IsNullOrEmpty(Objet.SP_LIBELLESPECIALITE))
            {
                clsCliparspecialite.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCliparspecialite.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCliparspecialite.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCliparspecialite.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SP_LIBELLESPECIALITE";
                clsCliparspecialites.Add(clsCliparspecialite);
                return clsCliparspecialites;

            }

            else
            {
                clsCliparspecialite.clsObjetRetour = new Common.clsObjetRetour();
                clsCliparspecialite.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCliparspecialite.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCliparspecialite.clsObjetRetour.SL_MESSAGE = "";
                clsCliparspecialites.Add(clsCliparspecialite);
                return clsCliparspecialites;

            }


        }

        public List<HT_Stock.BOJ.clsCliparspecialite> TestChampObligatoireUpdate(HT_Stock.BOJ.clsCliparspecialite Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCliparspecialite> clsCliparspecialites = new List<HT_Stock.BOJ.clsCliparspecialite>();
            HT_Stock.BOJ.clsCliparspecialite clsCliparspecialite = new HT_Stock.BOJ.clsCliparspecialite();

            if (string.IsNullOrEmpty(Objet.SP_CODESPECIALITE))
            {
                clsCliparspecialite.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCliparspecialite.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCliparspecialite.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCliparspecialite.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SP_CODESPECIALITE";
                clsCliparspecialites.Add(clsCliparspecialite);
                return clsCliparspecialites;

            }

            if (string.IsNullOrEmpty(Objet.SP_LIBELLESPECIALITE))
            {
                clsCliparspecialite.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCliparspecialite.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCliparspecialite.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCliparspecialite.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SP_LIBELLESPECIALITE";
                clsCliparspecialites.Add(clsCliparspecialite);
                return clsCliparspecialites;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCliparspecialite.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCliparspecialite.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCliparspecialite.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCliparspecialites.Add(clsCliparspecialite);
            //    return clsCliparspecialites;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCliparspecialite.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCliparspecialite.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCliparspecialite.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCliparspecialites.Add(clsCliparspecialite);
            //    return clsCliparspecialites;

            //}


            else
            {
                clsCliparspecialite.clsObjetRetour = new Common.clsObjetRetour();
            clsCliparspecialite.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCliparspecialite.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCliparspecialite.clsObjetRetour.SL_MESSAGE = "";
            clsCliparspecialites.Add(clsCliparspecialite);
            return clsCliparspecialites;

            }


        }

        public List<HT_Stock.BOJ.clsCliparspecialite> TestChampObligatoireDelete(HT_Stock.BOJ.clsCliparspecialite Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCliparspecialite> clsCliparspecialites = new List<HT_Stock.BOJ.clsCliparspecialite>();
            HT_Stock.BOJ.clsCliparspecialite clsCliparspecialite = new HT_Stock.BOJ.clsCliparspecialite();

            if (string.IsNullOrEmpty(Objet.SP_CODESPECIALITE))
            {
                clsCliparspecialite.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCliparspecialite.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCliparspecialite.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCliparspecialite.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SP_CODESPECIALITE";
                clsCliparspecialites.Add(clsCliparspecialite);
                return clsCliparspecialites;

            }
            else
            {
            clsCliparspecialite.clsObjetRetour = new Common.clsObjetRetour();
            clsCliparspecialite.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCliparspecialite.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCliparspecialite.clsObjetRetour.SL_MESSAGE = "";
            clsCliparspecialites.Add(clsCliparspecialite);
            return clsCliparspecialites;

            }


        }


    }
}