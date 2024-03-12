using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stock.Common;
using System.Runtime.Serialization;
using Stock.BOJ;
using Stock.WSBLL;
using Stock.WSTOOLS;

namespace Stock.WCF
{
	public partial class wsMobileSouscription
	{
        public List<HT_Stock.BOJ.clsMobileSouscription> TestContrainte(HT_Stock.BOJ.clsMobileSouscription Objet)

        {
            List<HT_Stock.BOJ.clsMobileSouscription> clsMobileSouscriptions = new List<HT_Stock.BOJ.clsMobileSouscription>();
            HT_Stock.BOJ.clsMobileSouscription clsMobileSouscription = new HT_Stock.BOJ.clsMobileSouscription();
            clsMobileSouscription.clsObjetRetour = new Common.clsObjetRetour();
            clsMobileSouscription.clsObjetRetour.SL_CODEMESSAGE = "";
            clsMobileSouscription.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsMobileSouscription.clsObjetRetour.SL_MESSAGE = "";
            clsMobileSouscriptions.Add(clsMobileSouscription);
            return clsMobileSouscriptions;
        }

        public List<HT_Stock.BOJ.clsMobileSouscription> TestChampObligatoireInsert(HT_Stock.BOJ.clsMobileSouscription Objet)

        {


            // Objet[0].LG_CODELANGUE, Objet[0].AG_CODEAGENCE, Objet[0].TI_IDTIERS, Objet[0].SO_CODESOUSCRIPTION, Objet[0].PY_CODEPAYS, Objet[0].TI_TELEPHONE, Objet[0].DATEJOURNEE, Objet[0].TI_EMAIL, Objet[0].SO_LIEURESIDENCE, Objet[0].TYPEOPERATION





            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsMobileSouscription> clsMobileSouscriptions = new List<HT_Stock.BOJ.clsMobileSouscription>();
            HT_Stock.BOJ.clsMobileSouscription clsMobileSouscription = new HT_Stock.BOJ.clsMobileSouscription();

            if (string.IsNullOrEmpty(Objet.TYPEOPERATION))
            {
                clsMobileSouscription.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMobileSouscription.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMobileSouscription.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMobileSouscription.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TYPEOPERATION";
                clsMobileSouscriptions.Add(clsMobileSouscription);
                return clsMobileSouscriptions;

            }

            if (string.IsNullOrEmpty(Objet.LG_CODELANGUE))
            {
                clsMobileSouscription.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMobileSouscription.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMobileSouscription.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMobileSouscription.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", LG_CODELANGUE";
                clsMobileSouscriptions.Add(clsMobileSouscription);
                return clsMobileSouscriptions;

            }
            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsMobileSouscription.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMobileSouscription.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMobileSouscription.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMobileSouscription.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsMobileSouscriptions.Add(clsMobileSouscription);
                return clsMobileSouscriptions;

            }
            if (string.IsNullOrEmpty(Objet.TI_IDTIERS))
            {
                clsMobileSouscription.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMobileSouscription.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMobileSouscription.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMobileSouscription.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TI_IDTIERS";
                clsMobileSouscriptions.Add(clsMobileSouscription);
                return clsMobileSouscriptions;

            }

            if (string.IsNullOrEmpty(Objet.DATEJOURNEE))
            {
                clsMobileSouscription.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMobileSouscription.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMobileSouscription.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMobileSouscription.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DATEJOURNEE";
                clsMobileSouscriptions.Add(clsMobileSouscription);
                return clsMobileSouscriptions;

            }


          
            if (string.IsNullOrEmpty(Objet.PY_CODEPAYS) && Objet.TYPEOPERATION == "01")
            {
                clsMobileSouscription.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMobileSouscription.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMobileSouscription.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMobileSouscription.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PY_CODEPAYS";
                clsMobileSouscriptions.Add(clsMobileSouscription);
                return clsMobileSouscriptions;

            }


            if (string.IsNullOrEmpty(Objet.TI_TELEPHONE) && Objet.TYPEOPERATION == "01")
            {
                clsMobileSouscription.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMobileSouscription.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMobileSouscription.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMobileSouscription.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TI_TELEPHONE";
                clsMobileSouscriptions.Add(clsMobileSouscription);
                return clsMobileSouscriptions;

            }
               
            if (string.IsNullOrEmpty(Objet.TI_EMAIL) && Objet.TYPEOPERATION == "01")
            {
                clsMobileSouscription.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMobileSouscription.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMobileSouscription.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMobileSouscription.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TI_EMAIL";
                clsMobileSouscriptions.Add(clsMobileSouscription);
                return clsMobileSouscriptions;

            }
            if (string.IsNullOrEmpty(Objet.SO_LIEURESIDENCE) && Objet.TYPEOPERATION == "01")
            {
                clsMobileSouscription.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMobileSouscription.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMobileSouscription.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMobileSouscription.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SO_LIEURESIDENCE";
                clsMobileSouscriptions.Add(clsMobileSouscription);
                return clsMobileSouscriptions;

            }
            if (string.IsNullOrEmpty(Objet.SO_CODESOUSCRIPTION) && Objet.TYPEOPERATION == "02")
            {
                clsMobileSouscription.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMobileSouscription.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMobileSouscription.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMobileSouscription.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SO_CODESOUSCRIPTION";
                clsMobileSouscriptions.Add(clsMobileSouscription);
                return clsMobileSouscriptions;

            }            

            
        


            //Objet[0].DATEJOURNEE, Objet[0].TI_EMAIL, Objet[0].SO_LIEURESIDENCE, Objet[0].TYPEOPERATION

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
        public List<HT_Stock.BOJ.clsMobileSouscription> TestChampObligatoireDelete(HT_Stock.BOJ.clsMobileSouscription Objet)

        {
            List<HT_Stock.BOJ.clsMobileSouscription> clsMobileSouscriptions = new List<HT_Stock.BOJ.clsMobileSouscription>();
            HT_Stock.BOJ.clsMobileSouscription clsMobileSouscription = new HT_Stock.BOJ.clsMobileSouscription();
            clsMobileSouscription.clsObjetRetour = new Common.clsObjetRetour();
            clsMobileSouscription.clsObjetRetour.SL_CODEMESSAGE = "";
            clsMobileSouscription.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsMobileSouscription.clsObjetRetour.SL_MESSAGE = "";
            clsMobileSouscriptions.Add(clsMobileSouscription);
            return clsMobileSouscriptions;
        }
        public List<HT_Stock.BOJ.clsMobileSouscription> TestTestContrainteListe(HT_Stock.BOJ.clsMobileSouscription Objet)
        {
            List<HT_Stock.BOJ.clsMobileSouscription> clsMobileSouscriptions = new List<HT_Stock.BOJ.clsMobileSouscription>();
            HT_Stock.BOJ.clsMobileSouscription clsMobileSouscription = new HT_Stock.BOJ.clsMobileSouscription();
            clsMobileSouscription.clsObjetRetour = new Common.clsObjetRetour();
            clsMobileSouscription.clsObjetRetour.SL_CODEMESSAGE = "";
            clsMobileSouscription.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsMobileSouscription.clsObjetRetour.SL_MESSAGE = "";
            clsMobileSouscriptions.Add(clsMobileSouscription);
            return clsMobileSouscriptions;
        }
    }
}
