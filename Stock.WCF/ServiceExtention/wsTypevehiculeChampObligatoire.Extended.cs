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
	public partial class wsTypevehicule
	{

        public List<HT_Stock.BOJ.clsTypevehicule> TestChampObligatoireListe(HT_Stock.BOJ.clsTypevehicule Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsTypevehicule> clsTypevehicules = new List<HT_Stock.BOJ.clsTypevehicule>();
            HT_Stock.BOJ.clsTypevehicule clsTypevehicule = new HT_Stock.BOJ.clsTypevehicule();

            //if (string.IsNullOrEmpty(Objet.TVH_CODETYPE))
            //{
            //    clsTypevehicule.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsTypevehicule.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsTypevehicule.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsTypevehicule.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TVH_CODETYPE";
            //    clsTypevehicules.Add(clsTypevehicule);
            //    return clsTypevehicules;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsTypevehicule.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsTypevehicule.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsTypevehicule.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsTypevehicules.Add(clsTypevehicule);
            //    return clsTypevehicules;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsTypevehicule.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsTypevehicule.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsTypevehicule.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsTypevehicules.Add(clsTypevehicule);
            //    return clsTypevehicules;

            //}


            //else
            //{
                clsTypevehicule.clsObjetRetour = new Common.clsObjetRetour();
                clsTypevehicule.clsObjetRetour.SL_CODEMESSAGE = "";
                clsTypevehicule.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsTypevehicule.clsObjetRetour.SL_MESSAGE = "";
                clsTypevehicules.Add(clsTypevehicule);
                return clsTypevehicules;

            //}


        }

        public List<HT_Stock.BOJ.clsTypevehicule> TestChampObligatoireInsert(HT_Stock.BOJ.clsTypevehicule Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsTypevehicule> clsTypevehicules = new List<HT_Stock.BOJ.clsTypevehicule>();
            HT_Stock.BOJ.clsTypevehicule clsTypevehicule = new HT_Stock.BOJ.clsTypevehicule();

           

            if (string.IsNullOrEmpty(Objet.TVH_LIBELE))
            {
                clsTypevehicule.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsTypevehicule.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsTypevehicule.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsTypevehicule.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TVH_LIBELE";
                clsTypevehicules.Add(clsTypevehicule);
                return clsTypevehicules;

            }

            else
            {
                clsTypevehicule.clsObjetRetour = new Common.clsObjetRetour();
                clsTypevehicule.clsObjetRetour.SL_CODEMESSAGE = "";
                clsTypevehicule.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsTypevehicule.clsObjetRetour.SL_MESSAGE = "";
                clsTypevehicules.Add(clsTypevehicule);
                return clsTypevehicules;

            }


        }

        public List<HT_Stock.BOJ.clsTypevehicule> TestChampObligatoireUpdate(HT_Stock.BOJ.clsTypevehicule Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsTypevehicule> clsTypevehicules = new List<HT_Stock.BOJ.clsTypevehicule>();
            HT_Stock.BOJ.clsTypevehicule clsTypevehicule = new HT_Stock.BOJ.clsTypevehicule();

            if (string.IsNullOrEmpty(Objet.TVH_CODETYPE))
            {
                clsTypevehicule.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsTypevehicule.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsTypevehicule.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsTypevehicule.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TVH_CODETYPE";
                clsTypevehicules.Add(clsTypevehicule);
                return clsTypevehicules;

            }

            if (string.IsNullOrEmpty(Objet.TVH_LIBELE))
            {
                clsTypevehicule.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsTypevehicule.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsTypevehicule.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsTypevehicule.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TVH_LIBELE";
                clsTypevehicules.Add(clsTypevehicule);
                return clsTypevehicules;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsTypevehicule.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsTypevehicule.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsTypevehicule.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsTypevehicules.Add(clsTypevehicule);
            //    return clsTypevehicules;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsTypevehicule.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsTypevehicule.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsTypevehicule.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsTypevehicules.Add(clsTypevehicule);
            //    return clsTypevehicules;

            //}


            else
            {
                clsTypevehicule.clsObjetRetour = new Common.clsObjetRetour();
            clsTypevehicule.clsObjetRetour.SL_CODEMESSAGE = "";
            clsTypevehicule.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsTypevehicule.clsObjetRetour.SL_MESSAGE = "";
            clsTypevehicules.Add(clsTypevehicule);
            return clsTypevehicules;

            }


        }

        public List<HT_Stock.BOJ.clsTypevehicule> TestChampObligatoireDelete(HT_Stock.BOJ.clsTypevehicule Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsTypevehicule> clsTypevehicules = new List<HT_Stock.BOJ.clsTypevehicule>();
            HT_Stock.BOJ.clsTypevehicule clsTypevehicule = new HT_Stock.BOJ.clsTypevehicule();

            if (string.IsNullOrEmpty(Objet.TVH_CODETYPE))
            {
                clsTypevehicule.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsTypevehicule.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsTypevehicule.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsTypevehicule.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TVH_CODETYPE";
                clsTypevehicules.Add(clsTypevehicule);
                return clsTypevehicules;

            }
            else
            {
            clsTypevehicule.clsObjetRetour = new Common.clsObjetRetour();
            clsTypevehicule.clsObjetRetour.SL_CODEMESSAGE = "";
            clsTypevehicule.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsTypevehicule.clsObjetRetour.SL_MESSAGE = "";
            clsTypevehicules.Add(clsTypevehicule);
            return clsTypevehicules;

            }


        }


    }
}