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
	public partial class wsOrgProspects
	{

        public List<HT_Stock.BOJ.clsOrgProspects> TestChampObligatoireListe(HT_Stock.BOJ.clsOrgProspects Objet)
        {


            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();


            List<HT_Stock.BOJ.clsOrgProspects> clsOrgProspectss = new List<HT_Stock.BOJ.clsOrgProspects>();
            HT_Stock.BOJ.clsOrgProspects clsOrgProspects = new HT_Stock.BOJ.clsOrgProspects();

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

                clsOrgProspects.clsObjetRetour = new Common.clsObjetRetour();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "GNE0280" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOrgProspects.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOrgProspects.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOrgProspects.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsOrgProspectss.Add(clsOrgProspects);
                clsOrgProspects.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsOrgProspects.clsObjetRetour.SL_MESSAGE = "L'agence est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
                clsOrgProspectss.Add(clsOrgProspects);
                return clsOrgProspectss;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsOrgProspects.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsOrgProspects.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsOrgProspects.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsOrgProspectss.Add(clsOrgProspects);
            //    return clsOrgProspectss;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsOrgProspects.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsOrgProspects.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsOrgProspects.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsOrgProspectss.Add(clsOrgProspects);
            //    return clsOrgProspectss;

            //}


            else
            {
                clsOrgProspects.clsObjetRetour = new Common.clsObjetRetour();
                clsOrgProspects.clsObjetRetour.SL_CODEMESSAGE = "";
                clsOrgProspects.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsOrgProspects.clsObjetRetour.SL_MESSAGE = "";
                clsOrgProspectss.Add(clsOrgProspects);
                return clsOrgProspectss;

            }


        }


        public List<HT_Stock.BOJ.clsOrgProspects> TestChampObligatoirePhotoProspect(HT_Stock.BOJ.clsOrgProspects Objet)
        {


            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();


            List<HT_Stock.BOJ.clsOrgProspects> clsOrgProspectss = new List<HT_Stock.BOJ.clsOrgProspects>();
            HT_Stock.BOJ.clsOrgProspects clsOrgProspects = new HT_Stock.BOJ.clsOrgProspects();

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

                clsOrgProspects.clsObjetRetour = new Common.clsObjetRetour();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "GNE0280" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOrgProspects.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOrgProspects.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOrgProspects.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsOrgProspectss.Add(clsOrgProspects);
                clsOrgProspects.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsOrgProspects.clsObjetRetour.SL_MESSAGE = "L'agence est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
                clsOrgProspectss.Add(clsOrgProspects);
                return clsOrgProspectss;

            }
            if (string.IsNullOrEmpty(Objet.PR_IDTIERS))
            {
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

                clsOrgProspects.clsObjetRetour = new Common.clsObjetRetour();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "GNE0280" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOrgProspects.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOrgProspects.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOrgProspects.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PR_IDTIERS";
                clsOrgProspectss.Add(clsOrgProspects);
                clsOrgProspects.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsOrgProspects.clsObjetRetour.SL_MESSAGE = "Saisie est obligatoire !!! PR_IDTIERS";// clsMessages.MS_LIBELLEMESSAGE;
                clsOrgProspectss.Add(clsOrgProspects);
                return clsOrgProspectss;

            }

            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsOrgProspects.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsOrgProspects.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsOrgProspects.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsOrgProspectss.Add(clsOrgProspects);
            //    return clsOrgProspectss;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsOrgProspects.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsOrgProspects.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsOrgProspects.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsOrgProspectss.Add(clsOrgProspects);
            //    return clsOrgProspectss;

            //}


            else
            {
                clsOrgProspects.clsObjetRetour = new Common.clsObjetRetour();
                clsOrgProspects.clsObjetRetour.SL_CODEMESSAGE = "";
                clsOrgProspects.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsOrgProspects.clsObjetRetour.SL_MESSAGE = "";
                clsOrgProspectss.Add(clsOrgProspects);
                return clsOrgProspectss;

            }


        }


        public List<HT_Stock.BOJ.clsOrgProspects> TestChampObligatoireListeSolde(HT_Stock.BOJ.clsOrgProspects Objet)
        {


            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsOrgProspects> clsOrgProspectss = new List<HT_Stock.BOJ.clsOrgProspects>();
            HT_Stock.BOJ.clsOrgProspects clsOrgProspects = new HT_Stock.BOJ.clsOrgProspects();

            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsOrgProspects.clsObjetRetour = new Common.clsObjetRetour();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOrgProspects.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOrgProspects.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOrgProspects.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsOrgProspectss.Add(clsOrgProspects);
                return clsOrgProspectss;

            }
            if (string.IsNullOrEmpty(Objet.EN_CODEENTREPOT))
            {
                clsOrgProspects.clsObjetRetour = new Common.clsObjetRetour();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOrgProspects.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOrgProspects.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOrgProspects.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", EN_CODEENTREPOT";
                clsOrgProspectss.Add(clsOrgProspects);
                return clsOrgProspectss;

            }
            if (string.IsNullOrEmpty(Objet.PR_NUMTIERS))
            {
                clsOrgProspects.clsObjetRetour = new Common.clsObjetRetour();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOrgProspects.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOrgProspects.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOrgProspects.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PR_NUMTIERS";
                clsOrgProspectss.Add(clsOrgProspects);
                return clsOrgProspectss;

            }            
            if (string.IsNullOrEmpty(Objet.DATEDEBUT))
            {
                clsOrgProspects.clsObjetRetour = new Common.clsObjetRetour();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOrgProspects.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOrgProspects.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOrgProspects.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DATEDEBUT";
                clsOrgProspectss.Add(clsOrgProspects);
                return clsOrgProspectss;

            } 
            

            else
            {
                clsOrgProspects.clsObjetRetour = new Common.clsObjetRetour();
                clsOrgProspects.clsObjetRetour.SL_CODEMESSAGE = "";
                clsOrgProspects.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsOrgProspects.clsObjetRetour.SL_MESSAGE = "";
                clsOrgProspectss.Add(clsOrgProspects);
                return clsOrgProspectss;

            }


        }


    }
}