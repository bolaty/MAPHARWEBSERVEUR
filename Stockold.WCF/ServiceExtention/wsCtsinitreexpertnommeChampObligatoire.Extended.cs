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
	public partial class wsCtsinitreexpertnomme
	{

        public List<HT_Stock.BOJ.clsCtsinitreexpertnomme> TestChampObligatoireListe(HT_Stock.BOJ.clsCtsinitreexpertnomme Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtsinitreexpertnomme> clsCtsinitreexpertnommes = new List<HT_Stock.BOJ.clsCtsinitreexpertnomme>();
            HT_Stock.BOJ.clsCtsinitreexpertnomme clsCtsinitreexpertnomme = new HT_Stock.BOJ.clsCtsinitreexpertnomme();

            //if (string.IsNullOrEmpty(Objet.EP_CODEEXPERTNOMME))
            //{
            //    clsCtsinitreexpertnomme.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsCtsinitreexpertnomme.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtsinitreexpertnomme.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsCtsinitreexpertnomme.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", EP_CODEEXPERTNOMME";
            //    clsCtsinitreexpertnommes.Add(clsCtsinitreexpertnomme);
            //    return clsCtsinitreexpertnommes;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtsinitreexpertnomme.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtsinitreexpertnomme.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtsinitreexpertnomme.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtsinitreexpertnommes.Add(clsCtsinitreexpertnomme);
            //    return clsCtsinitreexpertnommes;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtsinitreexpertnomme.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtsinitreexpertnomme.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtsinitreexpertnomme.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtsinitreexpertnommes.Add(clsCtsinitreexpertnomme);
            //    return clsCtsinitreexpertnommes;

            //}


            //else
            //{
                clsCtsinitreexpertnomme.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinitreexpertnomme.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtsinitreexpertnomme.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtsinitreexpertnomme.clsObjetRetour.SL_MESSAGE = "";
                clsCtsinitreexpertnommes.Add(clsCtsinitreexpertnomme);
                return clsCtsinitreexpertnommes;

            //}


        }

        public List<HT_Stock.BOJ.clsCtsinitreexpertnomme> TestChampObligatoireInsert(HT_Stock.BOJ.clsCtsinitreexpertnomme Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtsinitreexpertnomme> clsCtsinitreexpertnommes = new List<HT_Stock.BOJ.clsCtsinitreexpertnomme>();
            HT_Stock.BOJ.clsCtsinitreexpertnomme clsCtsinitreexpertnomme = new HT_Stock.BOJ.clsCtsinitreexpertnomme();

           

            if (string.IsNullOrEmpty(Objet.EP_DENOMMINATIONEXPERTNOMME))
            {
                clsCtsinitreexpertnomme.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinitreexpertnomme.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinitreexpertnomme.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinitreexpertnomme.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", EP_DENOMMINATIONEXPERTNOMME";
                clsCtsinitreexpertnommes.Add(clsCtsinitreexpertnomme);
                return clsCtsinitreexpertnommes;

            }

            else
            {
                clsCtsinitreexpertnomme.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinitreexpertnomme.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtsinitreexpertnomme.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtsinitreexpertnomme.clsObjetRetour.SL_MESSAGE = "";
                clsCtsinitreexpertnommes.Add(clsCtsinitreexpertnomme);
                return clsCtsinitreexpertnommes;

            }


        }

        public List<HT_Stock.BOJ.clsCtsinitreexpertnomme> TestChampObligatoireUpdate(HT_Stock.BOJ.clsCtsinitreexpertnomme Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtsinitreexpertnomme> clsCtsinitreexpertnommes = new List<HT_Stock.BOJ.clsCtsinitreexpertnomme>();
            HT_Stock.BOJ.clsCtsinitreexpertnomme clsCtsinitreexpertnomme = new HT_Stock.BOJ.clsCtsinitreexpertnomme();

            if (string.IsNullOrEmpty(Objet.EP_CODEEXPERTNOMME))
            {
                clsCtsinitreexpertnomme.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinitreexpertnomme.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinitreexpertnomme.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinitreexpertnomme.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", EP_CODEEXPERTNOMME";
                clsCtsinitreexpertnommes.Add(clsCtsinitreexpertnomme);
                return clsCtsinitreexpertnommes;

            }

            if (string.IsNullOrEmpty(Objet.EP_DENOMMINATIONEXPERTNOMME))
            {
                clsCtsinitreexpertnomme.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinitreexpertnomme.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinitreexpertnomme.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinitreexpertnomme.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", EP_DENOMMINATIONEXPERTNOMME";
                clsCtsinitreexpertnommes.Add(clsCtsinitreexpertnomme);
                return clsCtsinitreexpertnommes;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtsinitreexpertnomme.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtsinitreexpertnomme.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtsinitreexpertnomme.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtsinitreexpertnommes.Add(clsCtsinitreexpertnomme);
            //    return clsCtsinitreexpertnommes;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtsinitreexpertnomme.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtsinitreexpertnomme.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtsinitreexpertnomme.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtsinitreexpertnommes.Add(clsCtsinitreexpertnomme);
            //    return clsCtsinitreexpertnommes;

            //}


            else
            {
                clsCtsinitreexpertnomme.clsObjetRetour = new Common.clsObjetRetour();
            clsCtsinitreexpertnomme.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtsinitreexpertnomme.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtsinitreexpertnomme.clsObjetRetour.SL_MESSAGE = "";
            clsCtsinitreexpertnommes.Add(clsCtsinitreexpertnomme);
            return clsCtsinitreexpertnommes;

            }


        }

        public List<HT_Stock.BOJ.clsCtsinitreexpertnomme> TestChampObligatoireDelete(HT_Stock.BOJ.clsCtsinitreexpertnomme Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtsinitreexpertnomme> clsCtsinitreexpertnommes = new List<HT_Stock.BOJ.clsCtsinitreexpertnomme>();
            HT_Stock.BOJ.clsCtsinitreexpertnomme clsCtsinitreexpertnomme = new HT_Stock.BOJ.clsCtsinitreexpertnomme();

            if (string.IsNullOrEmpty(Objet.EP_CODEEXPERTNOMME))
            {
                clsCtsinitreexpertnomme.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinitreexpertnomme.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinitreexpertnomme.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinitreexpertnomme.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", EP_CODEEXPERTNOMME";
                clsCtsinitreexpertnommes.Add(clsCtsinitreexpertnomme);
                return clsCtsinitreexpertnommes;

            }
            else
            {
            clsCtsinitreexpertnomme.clsObjetRetour = new Common.clsObjetRetour();
            clsCtsinitreexpertnomme.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtsinitreexpertnomme.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtsinitreexpertnomme.clsObjetRetour.SL_MESSAGE = "";
            clsCtsinitreexpertnommes.Add(clsCtsinitreexpertnomme);
            return clsCtsinitreexpertnommes;

            }


        }


    }
}