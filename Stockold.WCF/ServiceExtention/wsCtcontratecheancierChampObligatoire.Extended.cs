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
	public partial class wsCtcontratecheancier
	{

        public List<HT_Stock.BOJ.clsCtcontratecheancier> TestChampObligatoireListe(HT_Stock.BOJ.clsCtcontratecheancier Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtcontratecheancier> clsCtcontratecheanciers = new List<HT_Stock.BOJ.clsCtcontratecheancier>();
            HT_Stock.BOJ.clsCtcontratecheancier clsCtcontratecheancier = new HT_Stock.BOJ.clsCtcontratecheancier();

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsCtcontratecheancier.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratecheancier.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratecheancier.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratecheancier.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsCtcontratecheanciers.Add(clsCtcontratecheancier);
                return clsCtcontratecheanciers;

            }

            if (string.IsNullOrEmpty(Objet.CA_CODECONTRAT))
            {
                clsCtcontratecheancier.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratecheancier.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratecheancier.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratecheancier.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CA_CODECONTRAT";
                clsCtcontratecheanciers.Add(clsCtcontratecheancier);
                return clsCtcontratecheanciers;

            }

            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtcontratecheancier.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtcontratecheancier.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtcontratecheancier.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtcontratecheanciers.Add(clsCtcontratecheancier);
            //    return clsCtcontratecheanciers;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtcontratecheancier.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtcontratecheancier.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtcontratecheancier.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtcontratecheanciers.Add(clsCtcontratecheancier);
            //    return clsCtcontratecheanciers;

            //}


            else
            {
                clsCtcontratecheancier.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratecheancier.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtcontratecheancier.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtcontratecheancier.clsObjetRetour.SL_MESSAGE = "";
                clsCtcontratecheanciers.Add(clsCtcontratecheancier);
                return clsCtcontratecheanciers;

            }


        }

        public List<HT_Stock.BOJ.clsCtcontratecheancier> TestChampObligatoireInsert(HT_Stock.BOJ.clsCtcontratecheancier Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtcontratecheancier> clsCtcontratecheanciers = new List<HT_Stock.BOJ.clsCtcontratecheancier>();
            HT_Stock.BOJ.clsCtcontratecheancier clsCtcontratecheancier = new HT_Stock.BOJ.clsCtcontratecheancier();

           

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsCtcontratecheancier.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratecheancier.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratecheancier.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratecheancier.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsCtcontratecheanciers.Add(clsCtcontratecheancier);
                return clsCtcontratecheanciers;

            }

            else
            {
                clsCtcontratecheancier.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratecheancier.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtcontratecheancier.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtcontratecheancier.clsObjetRetour.SL_MESSAGE = "";
                clsCtcontratecheanciers.Add(clsCtcontratecheancier);
                return clsCtcontratecheanciers;

            }


        }

        public List<HT_Stock.BOJ.clsCtcontratecheancier> TestChampObligatoireUpdate(HT_Stock.BOJ.clsCtcontratecheancier Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtcontratecheancier> clsCtcontratecheanciers = new List<HT_Stock.BOJ.clsCtcontratecheancier>();
            HT_Stock.BOJ.clsCtcontratecheancier clsCtcontratecheancier = new HT_Stock.BOJ.clsCtcontratecheancier();

            if (string.IsNullOrEmpty(Objet.CA_CODECONTRAT))
            {
                clsCtcontratecheancier.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratecheancier.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratecheancier.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratecheancier.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CA_CODECONTRAT";
                clsCtcontratecheanciers.Add(clsCtcontratecheancier);
                return clsCtcontratecheanciers;

            }

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsCtcontratecheancier.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratecheancier.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratecheancier.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratecheancier.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsCtcontratecheanciers.Add(clsCtcontratecheancier);
                return clsCtcontratecheanciers;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtcontratecheancier.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtcontratecheancier.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtcontratecheancier.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtcontratecheanciers.Add(clsCtcontratecheancier);
            //    return clsCtcontratecheanciers;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtcontratecheancier.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtcontratecheancier.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtcontratecheancier.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtcontratecheanciers.Add(clsCtcontratecheancier);
            //    return clsCtcontratecheanciers;

            //}


            else
            {
                clsCtcontratecheancier.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontratecheancier.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtcontratecheancier.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtcontratecheancier.clsObjetRetour.SL_MESSAGE = "";
            clsCtcontratecheanciers.Add(clsCtcontratecheancier);
            return clsCtcontratecheanciers;

            }


        }

        public List<HT_Stock.BOJ.clsCtcontratecheancier> TestChampObligatoireDelete(HT_Stock.BOJ.clsCtcontratecheancier Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtcontratecheancier> clsCtcontratecheanciers = new List<HT_Stock.BOJ.clsCtcontratecheancier>();
            HT_Stock.BOJ.clsCtcontratecheancier clsCtcontratecheancier = new HT_Stock.BOJ.clsCtcontratecheancier();

            if (string.IsNullOrEmpty(Objet.CA_CODECONTRAT))
            {
                clsCtcontratecheancier.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratecheancier.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratecheancier.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratecheancier.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CA_CODECONTRAT";
                clsCtcontratecheanciers.Add(clsCtcontratecheancier);
                return clsCtcontratecheanciers;

            }
            else
            {
            clsCtcontratecheancier.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontratecheancier.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtcontratecheancier.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtcontratecheancier.clsObjetRetour.SL_MESSAGE = "";
            clsCtcontratecheanciers.Add(clsCtcontratecheancier);
            return clsCtcontratecheanciers;

            }


        }


    }
}