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
	public partial class wsMobileSouscription
	{

        public List<HT_Stock.BOJ.clsMobileSouscription> TestChampObligatoireListe(HT_Stock.BOJ.clsMobileSouscription Objet)
        {


            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();


            List<HT_Stock.BOJ.clsMobileSouscription> clsMobileSouscriptions = new List<HT_Stock.BOJ.clsMobileSouscription>();
            HT_Stock.BOJ.clsMobileSouscription clsMobileSouscription = new HT_Stock.BOJ.clsMobileSouscription();

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

                clsMobileSouscription.clsObjetRetour = new Common.clsObjetRetour();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "GNE0280" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMobileSouscription.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMobileSouscription.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMobileSouscription.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsMobileSouscriptions.Add(clsMobileSouscription);
                clsMobileSouscription.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsMobileSouscription.clsObjetRetour.SL_MESSAGE = "L'agence est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
                clsMobileSouscriptions.Add(clsMobileSouscription);
                return clsMobileSouscriptions;

            }
        if (string.IsNullOrEmpty(Objet.TI_IDTIERS))
        {
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            clsMobileSouscription.clsObjetRetour = new Common.clsObjetRetour();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "GNE0280" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsMobileSouscription.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsMobileSouscription.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsMobileSouscription.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TI_IDTIERS";
            clsMobileSouscriptions.Add(clsMobileSouscription);
            clsMobileSouscription.clsObjetRetour.SL_RESULTAT = "FALSE";
            clsMobileSouscription.clsObjetRetour.SL_MESSAGE = "L'id du tiers  est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            clsMobileSouscriptions.Add(clsMobileSouscription);
            return clsMobileSouscriptions;

        }
        if (string.IsNullOrEmpty(Objet.LO_CODELOGICIEL))
        {
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            clsMobileSouscription.clsObjetRetour = new Common.clsObjetRetour();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "GNE0280" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsMobileSouscription.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsMobileSouscription.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsMobileSouscription.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", LO_CODELOGICIEL";
            clsMobileSouscriptions.Add(clsMobileSouscription);
            clsMobileSouscription.clsObjetRetour.SL_RESULTAT = "FALSE";
            clsMobileSouscription.clsObjetRetour.SL_MESSAGE = "Le logiciel  est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            clsMobileSouscriptions.Add(clsMobileSouscription);
            return clsMobileSouscriptions;

        }
        if (string.IsNullOrEmpty(Objet.DATEJOURNEE))
        {
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            clsMobileSouscription.clsObjetRetour = new Common.clsObjetRetour();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "GNE0280" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsMobileSouscription.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsMobileSouscription.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsMobileSouscription.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DATEJOURNEE";
            clsMobileSouscriptions.Add(clsMobileSouscription);
            clsMobileSouscription.clsObjetRetour.SL_RESULTAT = "FALSE";
            clsMobileSouscription.clsObjetRetour.SL_MESSAGE = "La date  est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            clsMobileSouscriptions.Add(clsMobileSouscription);
            return clsMobileSouscriptions;

        }
        if (string.IsNullOrEmpty(Objet.TYPEOPERATION))
        {
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            clsMobileSouscription.clsObjetRetour = new Common.clsObjetRetour();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "GNE0280" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsMobileSouscription.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsMobileSouscription.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsMobileSouscription.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TYPEOPERATION";
            clsMobileSouscriptions.Add(clsMobileSouscription);
            clsMobileSouscription.clsObjetRetour.SL_RESULTAT = "FALSE";
            clsMobileSouscription.clsObjetRetour.SL_MESSAGE = "Le type opération  est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            clsMobileSouscriptions.Add(clsMobileSouscription);
            return clsMobileSouscriptions;

        }

            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsMobileSouscription.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsMobileSouscription.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsMobileSouscription.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsMobileSouscriptions.Add(clsMobileSouscription);
            //    return clsMobileSouscriptions;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsMobileSouscription.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsMobileSouscription.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsMobileSouscription.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsMobileSouscriptions.Add(clsMobileSouscription);
            //    return clsMobileSouscriptions;

            //}


            else
            {
                clsMobileSouscription.clsObjetRetour = new Common.clsObjetRetour();
                clsMobileSouscription.clsObjetRetour.SL_CODEMESSAGE = "";
                clsMobileSouscription.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsMobileSouscription.clsObjetRetour.SL_MESSAGE = "";
                clsMobileSouscriptions.Add(clsMobileSouscription);
                return clsMobileSouscriptions;

            }


        }


        public List<HT_Stock.BOJ.clsMobileSouscription> TestChampObligatoireListeSolde(HT_Stock.BOJ.clsMobileSouscription Objet)
        {


            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsMobileSouscription> clsMobileSouscriptions = new List<HT_Stock.BOJ.clsMobileSouscription>();
            HT_Stock.BOJ.clsMobileSouscription clsMobileSouscription = new HT_Stock.BOJ.clsMobileSouscription();

            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsMobileSouscription.clsObjetRetour = new Common.clsObjetRetour();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMobileSouscription.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMobileSouscription.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMobileSouscription.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsMobileSouscriptions.Add(clsMobileSouscription);
                return clsMobileSouscriptions;

            }
            if (string.IsNullOrEmpty(Objet.EN_CODEENTREPOT))
            {
                clsMobileSouscription.clsObjetRetour = new Common.clsObjetRetour();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMobileSouscription.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMobileSouscription.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMobileSouscription.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", EN_CODEENTREPOT";
                clsMobileSouscriptions.Add(clsMobileSouscription);
                return clsMobileSouscriptions;

            }
            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsMobileSouscription.clsObjetRetour = new Common.clsObjetRetour();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMobileSouscription.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMobileSouscription.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMobileSouscription.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TI_NUMTIERS";
                clsMobileSouscriptions.Add(clsMobileSouscription);
                return clsMobileSouscriptions;

            }            
            if (string.IsNullOrEmpty(Objet.DATEDEBUT))
            {
                clsMobileSouscription.clsObjetRetour = new Common.clsObjetRetour();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMobileSouscription.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMobileSouscription.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMobileSouscription.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DATEDEBUT";
                clsMobileSouscriptions.Add(clsMobileSouscription);
                return clsMobileSouscriptions;

            } 
            

            else
            {
                clsMobileSouscription.clsObjetRetour = new Common.clsObjetRetour();
                clsMobileSouscription.clsObjetRetour.SL_CODEMESSAGE = "";
                clsMobileSouscription.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsMobileSouscription.clsObjetRetour.SL_MESSAGE = "";
                clsMobileSouscriptions.Add(clsMobileSouscription);
                return clsMobileSouscriptions;

            }


        }


    }
}