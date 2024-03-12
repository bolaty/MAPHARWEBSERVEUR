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
	public partial class wsCtparbranchecategorietarif
	{

        public List<HT_Stock.BOJ.clsCtparbranchecategorietarif> TestChampObligatoireListe(HT_Stock.BOJ.clsCtparbranchecategorietarif Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparbranchecategorietarif> clsCtparbranchecategorietarifs = new List<HT_Stock.BOJ.clsCtparbranchecategorietarif>();
            HT_Stock.BOJ.clsCtparbranchecategorietarif clsCtparbranchecategorietarif = new HT_Stock.BOJ.clsCtparbranchecategorietarif();

            if (string.IsNullOrEmpty(Objet.CB_IDBRANCHE))
            {
                clsCtparbranchecategorietarif.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparbranchecategorietarif.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparbranchecategorietarif.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparbranchecategorietarif.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CB_IDBRANCHE";
                clsCtparbranchecategorietarifs.Add(clsCtparbranchecategorietarif);
                return clsCtparbranchecategorietarifs;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparbranchecategorietarif.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparbranchecategorietarif.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparbranchecategorietarif.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparbranchecategorietarifs.Add(clsCtparbranchecategorietarif);
            //    return clsCtparbranchecategorietarifs;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparbranchecategorietarif.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparbranchecategorietarif.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparbranchecategorietarif.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparbranchecategorietarifs.Add(clsCtparbranchecategorietarif);
            //    return clsCtparbranchecategorietarifs;

            //}


            else
            {
                clsCtparbranchecategorietarif.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparbranchecategorietarif.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtparbranchecategorietarif.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtparbranchecategorietarif.clsObjetRetour.SL_MESSAGE = "";
                clsCtparbranchecategorietarifs.Add(clsCtparbranchecategorietarif);
                return clsCtparbranchecategorietarifs;

            }


        }

        public List<HT_Stock.BOJ.clsCtparbranchecategorietarif> TestChampObligatoireInsert(HT_Stock.BOJ.clsCtparbranchecategorietarif Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparbranchecategorietarif> clsCtparbranchecategorietarifs = new List<HT_Stock.BOJ.clsCtparbranchecategorietarif>();
            HT_Stock.BOJ.clsCtparbranchecategorietarif clsCtparbranchecategorietarif = new HT_Stock.BOJ.clsCtparbranchecategorietarif();

           

            if (string.IsNullOrEmpty(Objet.AU_LIBELLECATEGORIE))
            {
                clsCtparbranchecategorietarif.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparbranchecategorietarif.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparbranchecategorietarif.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparbranchecategorietarif.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AU_LIBELLECATEGORIE";
                clsCtparbranchecategorietarifs.Add(clsCtparbranchecategorietarif);
                return clsCtparbranchecategorietarifs;

            }

            else
            {
                clsCtparbranchecategorietarif.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparbranchecategorietarif.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtparbranchecategorietarif.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtparbranchecategorietarif.clsObjetRetour.SL_MESSAGE = "";
                clsCtparbranchecategorietarifs.Add(clsCtparbranchecategorietarif);
                return clsCtparbranchecategorietarifs;

            }


        }

        public List<HT_Stock.BOJ.clsCtparbranchecategorietarif> TestChampObligatoireUpdate(HT_Stock.BOJ.clsCtparbranchecategorietarif Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparbranchecategorietarif> clsCtparbranchecategorietarifs = new List<HT_Stock.BOJ.clsCtparbranchecategorietarif>();
            HT_Stock.BOJ.clsCtparbranchecategorietarif clsCtparbranchecategorietarif = new HT_Stock.BOJ.clsCtparbranchecategorietarif();

            if (string.IsNullOrEmpty(Objet.AU_CODECATEGORIE))
            {
                clsCtparbranchecategorietarif.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparbranchecategorietarif.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparbranchecategorietarif.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparbranchecategorietarif.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AU_CODECATEGORIE";
                clsCtparbranchecategorietarifs.Add(clsCtparbranchecategorietarif);
                return clsCtparbranchecategorietarifs;

            }

            if (string.IsNullOrEmpty(Objet.AU_LIBELLECATEGORIE))
            {
                clsCtparbranchecategorietarif.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparbranchecategorietarif.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparbranchecategorietarif.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparbranchecategorietarif.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AU_LIBELLECATEGORIE";
                clsCtparbranchecategorietarifs.Add(clsCtparbranchecategorietarif);
                return clsCtparbranchecategorietarifs;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparbranchecategorietarif.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparbranchecategorietarif.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparbranchecategorietarif.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparbranchecategorietarifs.Add(clsCtparbranchecategorietarif);
            //    return clsCtparbranchecategorietarifs;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparbranchecategorietarif.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparbranchecategorietarif.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparbranchecategorietarif.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparbranchecategorietarifs.Add(clsCtparbranchecategorietarif);
            //    return clsCtparbranchecategorietarifs;

            //}


            else
            {
                clsCtparbranchecategorietarif.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparbranchecategorietarif.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparbranchecategorietarif.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparbranchecategorietarif.clsObjetRetour.SL_MESSAGE = "";
            clsCtparbranchecategorietarifs.Add(clsCtparbranchecategorietarif);
            return clsCtparbranchecategorietarifs;

            }


        }

        public List<HT_Stock.BOJ.clsCtparbranchecategorietarif> TestChampObligatoireDelete(HT_Stock.BOJ.clsCtparbranchecategorietarif Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparbranchecategorietarif> clsCtparbranchecategorietarifs = new List<HT_Stock.BOJ.clsCtparbranchecategorietarif>();
            HT_Stock.BOJ.clsCtparbranchecategorietarif clsCtparbranchecategorietarif = new HT_Stock.BOJ.clsCtparbranchecategorietarif();

            if (string.IsNullOrEmpty(Objet.AU_CODECATEGORIE))
            {
                clsCtparbranchecategorietarif.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparbranchecategorietarif.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparbranchecategorietarif.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparbranchecategorietarif.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AU_CODECATEGORIE";
                clsCtparbranchecategorietarifs.Add(clsCtparbranchecategorietarif);
                return clsCtparbranchecategorietarifs;

            }
            else
            {
            clsCtparbranchecategorietarif.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparbranchecategorietarif.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparbranchecategorietarif.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparbranchecategorietarif.clsObjetRetour.SL_MESSAGE = "";
            clsCtparbranchecategorietarifs.Add(clsCtparbranchecategorietarif);
            return clsCtparbranchecategorietarifs;

            }


        }


    }
}