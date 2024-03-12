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
	public partial class wsCtpartauxauto
	{

        public List<HT_Stock.BOJ.clsCtpartauxauto> TestChampObligatoireListe(HT_Stock.BOJ.clsCtpartauxauto Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtpartauxauto> clsCtpartauxautos = new List<HT_Stock.BOJ.clsCtpartauxauto>();
            HT_Stock.BOJ.clsCtpartauxauto clsCtpartauxauto = new HT_Stock.BOJ.clsCtpartauxauto();

            if (string.IsNullOrEmpty(Objet.DATEDEBUT))
            {
                clsCtpartauxauto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtpartauxauto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtpartauxauto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtpartauxauto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DATEDEBUT";
                clsCtpartauxautos.Add(clsCtpartauxauto);
                return clsCtpartauxautos;

            }
        if (string.IsNullOrEmpty(Objet.DATEFIN))
        {
            clsCtpartauxauto.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsCtpartauxauto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsCtpartauxauto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsCtpartauxauto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DATEFIN";
            clsCtpartauxautos.Add(clsCtpartauxauto);
            return clsCtpartauxautos;

        }

            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtpartauxauto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtpartauxauto.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtpartauxauto.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtpartauxautos.Add(clsCtpartauxauto);
            //    return clsCtpartauxautos;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtpartauxauto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtpartauxauto.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtpartauxauto.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtpartauxautos.Add(clsCtpartauxauto);
            //    return clsCtpartauxautos;

            //}


            else
            {
                clsCtpartauxauto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpartauxauto.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtpartauxauto.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtpartauxauto.clsObjetRetour.SL_MESSAGE = "";
                clsCtpartauxautos.Add(clsCtpartauxauto);
                return clsCtpartauxautos;

            }


        }

        public List<HT_Stock.BOJ.clsCtpartauxauto> TestChampObligatoireInsert(HT_Stock.BOJ.clsCtpartauxauto Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtpartauxauto> clsCtpartauxautos = new List<HT_Stock.BOJ.clsCtpartauxauto>();
            HT_Stock.BOJ.clsCtpartauxauto clsCtpartauxauto = new HT_Stock.BOJ.clsCtpartauxauto();

           

            if (string.IsNullOrEmpty(Objet.DATEFIN))
            {
                clsCtpartauxauto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtpartauxauto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtpartauxauto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtpartauxauto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DATEFIN";
                clsCtpartauxautos.Add(clsCtpartauxauto);
                return clsCtpartauxautos;

            }

            else
            {
                clsCtpartauxauto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpartauxauto.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtpartauxauto.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtpartauxauto.clsObjetRetour.SL_MESSAGE = "";
                clsCtpartauxautos.Add(clsCtpartauxauto);
                return clsCtpartauxautos;

            }


        }

        public List<HT_Stock.BOJ.clsCtpartauxauto> TestChampObligatoireUpdate(HT_Stock.BOJ.clsCtpartauxauto Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtpartauxauto> clsCtpartauxautos = new List<HT_Stock.BOJ.clsCtpartauxauto>();
            HT_Stock.BOJ.clsCtpartauxauto clsCtpartauxauto = new HT_Stock.BOJ.clsCtpartauxauto();

            if (string.IsNullOrEmpty(Objet.TX_CODETAUX))
            {
                clsCtpartauxauto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtpartauxauto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtpartauxauto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtpartauxauto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AC_CODECtpartauxauto";
                clsCtpartauxautos.Add(clsCtpartauxauto);
                return clsCtpartauxautos;

            }

            if (string.IsNullOrEmpty(Objet.TX_CODETAUX))
            {
                clsCtpartauxauto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtpartauxauto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtpartauxauto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtpartauxauto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AC_LIBELLE";
                clsCtpartauxautos.Add(clsCtpartauxauto);
                return clsCtpartauxautos;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtpartauxauto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtpartauxauto.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtpartauxauto.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtpartauxautos.Add(clsCtpartauxauto);
            //    return clsCtpartauxautos;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtpartauxauto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtpartauxauto.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtpartauxauto.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtpartauxautos.Add(clsCtpartauxauto);
            //    return clsCtpartauxautos;

            //}


            else
            {
                clsCtpartauxauto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpartauxauto.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtpartauxauto.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtpartauxauto.clsObjetRetour.SL_MESSAGE = "";
            clsCtpartauxautos.Add(clsCtpartauxauto);
            return clsCtpartauxautos;

            }


        }

        public List<HT_Stock.BOJ.clsCtpartauxauto> TestChampObligatoireDelete(HT_Stock.BOJ.clsCtpartauxauto Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtpartauxauto> clsCtpartauxautos = new List<HT_Stock.BOJ.clsCtpartauxauto>();
            HT_Stock.BOJ.clsCtpartauxauto clsCtpartauxauto = new HT_Stock.BOJ.clsCtpartauxauto();

            if (string.IsNullOrEmpty(Objet.TX_CODETAUX))
            {
                clsCtpartauxauto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtpartauxauto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtpartauxauto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtpartauxauto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AC_CODECtpartauxauto";
                clsCtpartauxautos.Add(clsCtpartauxauto);
                return clsCtpartauxautos;

            }
            else
            {
            clsCtpartauxauto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpartauxauto.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtpartauxauto.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtpartauxauto.clsObjetRetour.SL_MESSAGE = "";
            clsCtpartauxautos.Add(clsCtpartauxauto);
            return clsCtpartauxautos;

            }


        }


    }
}