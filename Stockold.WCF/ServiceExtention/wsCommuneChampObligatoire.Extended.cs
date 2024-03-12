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
	public partial class wsCommune
	{

        public List<HT_Stock.BOJ.clsCommune> TestChampObligatoireListe(HT_Stock.BOJ.clsCommune Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCommune> clsCommunes = new List<HT_Stock.BOJ.clsCommune>();
            HT_Stock.BOJ.clsCommune clsCommune = new HT_Stock.BOJ.clsCommune();

            if (string.IsNullOrEmpty(Objet.VL_CODEVILLE))
            {
                clsCommune.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCommune.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCommune.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCommune.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", VL_CODEVILLE";
                clsCommunes.Add(clsCommune);
                return clsCommunes;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCommune.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCommune.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCommune.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCommunes.Add(clsCommune);
            //    return clsCommunes;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCommune.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCommune.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCommune.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCommunes.Add(clsCommune);
            //    return clsCommunes;

            //}


            else
            {
                clsCommune.clsObjetRetour = new Common.clsObjetRetour();
                clsCommune.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCommune.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCommune.clsObjetRetour.SL_MESSAGE = "";
                clsCommunes.Add(clsCommune);
                return clsCommunes;

            }


        }

        public List<HT_Stock.BOJ.clsCommune> TestChampObligatoireListeSelonZone(HT_Stock.BOJ.clsCommune Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCommune> clsCommunes = new List<HT_Stock.BOJ.clsCommune>();
            HT_Stock.BOJ.clsCommune clsCommune = new HT_Stock.BOJ.clsCommune();

            if (string.IsNullOrEmpty(Objet.VL_CODEVILLE))
            {
                clsCommune.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCommune.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCommune.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCommune.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", VL_CODEVILLE";
                clsCommunes.Add(clsCommune);
                return clsCommunes;

            }
            if (string.IsNullOrEmpty(Objet.ZN_CODEZONE))
            {
                clsCommune.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCommune.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCommune.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCommune.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ZN_CODEZONE";
                clsCommunes.Add(clsCommune);
                return clsCommunes;

            }

            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCommune.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCommune.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCommune.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCommunes.Add(clsCommune);
            //    return clsCommunes;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCommune.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCommune.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCommune.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCommunes.Add(clsCommune);
            //    return clsCommunes;

            //}


            else
            {
                clsCommune.clsObjetRetour = new Common.clsObjetRetour();
                clsCommune.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCommune.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCommune.clsObjetRetour.SL_MESSAGE = "";
                clsCommunes.Add(clsCommune);
                return clsCommunes;

            }


        }
    }
}