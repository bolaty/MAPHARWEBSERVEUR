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
	public partial class wsCtcontratsuivieclient
	{

        public List<HT_Stock.BOJ.clsCtcontratsuivieclient> TestChampObligatoireListe(HT_Stock.BOJ.clsCtcontratsuivieclient Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtcontratsuivieclient> clsCtcontratsuivieclients = new List<HT_Stock.BOJ.clsCtcontratsuivieclient>();
            HT_Stock.BOJ.clsCtcontratsuivieclient clsCtcontratsuivieclient = new HT_Stock.BOJ.clsCtcontratsuivieclient();
            //clsObjetEnvoi.OE_PARAM = new string[] { Objet[0].AG_CODEAGENCE, Objet[0].CA_CODECONTRAT, Objet[0].SU_DESCRIPTIONEVENEMENT, Objet[0].DATEDEBUT, Objet[0].DATEFIN, Objet[0].OP_CODEOPERATEUR, Objet[0].TYPEOPERATION };
            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsCtcontratsuivieclient.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratsuivieclient.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratsuivieclient.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratsuivieclient.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsCtcontratsuivieclients.Add(clsCtcontratsuivieclient);
                return clsCtcontratsuivieclients;

            }

            if (string.IsNullOrEmpty(Objet.CA_CODECONTRAT))
            {
                clsCtcontratsuivieclient.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratsuivieclient.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratsuivieclient.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratsuivieclient.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CA_CODECONTRAT";
                clsCtcontratsuivieclients.Add(clsCtcontratsuivieclient);
                return clsCtcontratsuivieclients;

            }

            if (string.IsNullOrEmpty(Objet.DATEDEBUT))
            {
                clsCtcontratsuivieclient.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratsuivieclient.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratsuivieclient.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratsuivieclient.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DATEDEBUT";
                clsCtcontratsuivieclients.Add(clsCtcontratsuivieclient);
                return clsCtcontratsuivieclients;

            }
            if (string.IsNullOrEmpty(Objet.DATEFIN))
            {
                clsCtcontratsuivieclient.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratsuivieclient.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratsuivieclient.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratsuivieclient.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DATEFIN";
                clsCtcontratsuivieclients.Add(clsCtcontratsuivieclient);
                return clsCtcontratsuivieclients;

            }
            if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUR))
            {
                clsCtcontratsuivieclient.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratsuivieclient.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratsuivieclient.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratsuivieclient.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_CODEOPERATEUR";
                clsCtcontratsuivieclients.Add(clsCtcontratsuivieclient);
                return clsCtcontratsuivieclients;

            }

            //if (string.IsNullOrEmpty(Objet.SU_DESCRIPTIONEVENEMENT))
            //{
            //    clsCtcontratsuivieclient.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsCtcontratsuivieclient.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtcontratsuivieclient.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsCtcontratsuivieclient.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SU_DESCRIPTIONEVENEMENT";
            //    clsCtcontratsuivieclients.Add(clsCtcontratsuivieclient);
            //    return clsCtcontratsuivieclients;

            //}



            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtcontratsuivieclient.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtcontratsuivieclient.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtcontratsuivieclient.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtcontratsuivieclients.Add(clsCtcontratsuivieclient);
            //    return clsCtcontratsuivieclients;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtcontratsuivieclient.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtcontratsuivieclient.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtcontratsuivieclient.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtcontratsuivieclients.Add(clsCtcontratsuivieclient);
            //    return clsCtcontratsuivieclients;

            //}


            //else
            //{
            clsCtcontratsuivieclient.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratsuivieclient.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtcontratsuivieclient.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtcontratsuivieclient.clsObjetRetour.SL_MESSAGE = "";
                clsCtcontratsuivieclients.Add(clsCtcontratsuivieclient);
                return clsCtcontratsuivieclients;

            //}


        }

        public List<HT_Stock.BOJ.clsCtcontratsuivieclient> TestChampObligatoireInsert(HT_Stock.BOJ.clsCtcontratsuivieclient Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtcontratsuivieclient> clsCtcontratsuivieclients = new List<HT_Stock.BOJ.clsCtcontratsuivieclient>();
            HT_Stock.BOJ.clsCtcontratsuivieclient clsCtcontratsuivieclient = new HT_Stock.BOJ.clsCtcontratsuivieclient();

           

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsCtcontratsuivieclient.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratsuivieclient.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratsuivieclient.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratsuivieclient.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsCtcontratsuivieclients.Add(clsCtcontratsuivieclient);
                return clsCtcontratsuivieclients;

            }

            else
            {
                clsCtcontratsuivieclient.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratsuivieclient.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtcontratsuivieclient.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtcontratsuivieclient.clsObjetRetour.SL_MESSAGE = "";
                clsCtcontratsuivieclients.Add(clsCtcontratsuivieclient);
                return clsCtcontratsuivieclients;

            }


        }

        public List<HT_Stock.BOJ.clsCtcontratsuivieclient> TestChampObligatoireUpdate(HT_Stock.BOJ.clsCtcontratsuivieclient Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtcontratsuivieclient> clsCtcontratsuivieclients = new List<HT_Stock.BOJ.clsCtcontratsuivieclient>();
            HT_Stock.BOJ.clsCtcontratsuivieclient clsCtcontratsuivieclient = new HT_Stock.BOJ.clsCtcontratsuivieclient();

            if (string.IsNullOrEmpty(Objet.SU_INDEXSUIVIE))
            {
                clsCtcontratsuivieclient.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratsuivieclient.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratsuivieclient.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratsuivieclient.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SU_INDEXSUIVIE";
                clsCtcontratsuivieclients.Add(clsCtcontratsuivieclient);
                return clsCtcontratsuivieclients;

            }

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsCtcontratsuivieclient.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratsuivieclient.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratsuivieclient.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratsuivieclient.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsCtcontratsuivieclients.Add(clsCtcontratsuivieclient);
                return clsCtcontratsuivieclients;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtcontratsuivieclient.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtcontratsuivieclient.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtcontratsuivieclient.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtcontratsuivieclients.Add(clsCtcontratsuivieclient);
            //    return clsCtcontratsuivieclients;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtcontratsuivieclient.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtcontratsuivieclient.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtcontratsuivieclient.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtcontratsuivieclients.Add(clsCtcontratsuivieclient);
            //    return clsCtcontratsuivieclients;

            //}


            else
            {
                clsCtcontratsuivieclient.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontratsuivieclient.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtcontratsuivieclient.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtcontratsuivieclient.clsObjetRetour.SL_MESSAGE = "";
            clsCtcontratsuivieclients.Add(clsCtcontratsuivieclient);
            return clsCtcontratsuivieclients;

            }


        }

        public List<HT_Stock.BOJ.clsCtcontratsuivieclient> TestChampObligatoireDelete(HT_Stock.BOJ.clsCtcontratsuivieclient Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtcontratsuivieclient> clsCtcontratsuivieclients = new List<HT_Stock.BOJ.clsCtcontratsuivieclient>();
            HT_Stock.BOJ.clsCtcontratsuivieclient clsCtcontratsuivieclient = new HT_Stock.BOJ.clsCtcontratsuivieclient();

            if (string.IsNullOrEmpty(Objet.SU_INDEXSUIVIE))
            {
                clsCtcontratsuivieclient.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratsuivieclient.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratsuivieclient.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratsuivieclient.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SU_INDEXSUIVIE";
                clsCtcontratsuivieclients.Add(clsCtcontratsuivieclient);
                return clsCtcontratsuivieclients;

            }
            else
            {
            clsCtcontratsuivieclient.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontratsuivieclient.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtcontratsuivieclient.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtcontratsuivieclient.clsObjetRetour.SL_MESSAGE = "";
            clsCtcontratsuivieclients.Add(clsCtcontratsuivieclient);
            return clsCtcontratsuivieclients;

            }


        }


    }
}