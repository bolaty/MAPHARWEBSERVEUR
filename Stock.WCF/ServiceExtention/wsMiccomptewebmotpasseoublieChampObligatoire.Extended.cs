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
	public partial class wsMiccomptewebmotpasseoublie
	{

        public List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie> TestChampObligatoireListe(HT_Stock.BOJ.clsMiccomptewebmotpasseoublie Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie> clsMiccomptewebmotpasseoublies = new List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie>();
            HT_Stock.BOJ.clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new HT_Stock.BOJ.clsMiccomptewebmotpasseoublie();

            //if (string.IsNullOrEmpty(Objet.RP_NUMSEQUENCE))
            //{
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", RP_NUMSEQUENCE";
            //    clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
            //    return clsMiccomptewebmotpasseoublies;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
            //    return clsMiccomptewebmotpasseoublies;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
            //    return clsMiccomptewebmotpasseoublies;

            //}


            //else
            //{
                clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = "";
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = "";
                clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublies;

            //}


        }

        public List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie> TestChampObligatoireInsert(HT_Stock.BOJ.clsMiccomptewebmotpasseoublie Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie> clsMiccomptewebmotpasseoublies = new List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie>();
            HT_Stock.BOJ.clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new HT_Stock.BOJ.clsMiccomptewebmotpasseoublie();

            if (string.IsNullOrEmpty(Objet.TYPEOPERATION))
            {
                clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TYPEOPERATION";
                clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublies;

            }           
            if (string.IsNullOrEmpty(Objet.RP_DATE))
            {
                clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", RP_DATE";
                clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublies;

            } 



            //if (string.IsNullOrEmpty(Objet.RP_CODEVALIDATION))
            //{
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", RP_CODEVALIDATION";
            //    clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
            //    return clsMiccomptewebmotpasseoublies;

            //}

            else
            {
                clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = "";
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = "";
                clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublies;

            }


        }

        public List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie> TestChampObligatoireUpdate(HT_Stock.BOJ.clsMiccomptewebmotpasseoublie Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie> clsMiccomptewebmotpasseoublies = new List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie>();
            HT_Stock.BOJ.clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new HT_Stock.BOJ.clsMiccomptewebmotpasseoublie();

            if (string.IsNullOrEmpty(Objet.RP_NUMSEQUENCE))
            {
                clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", RP_NUMSEQUENCE";
                clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublies;

            }

            if (string.IsNullOrEmpty(Objet.RP_CODEVALIDATION))
            {
                clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", RP_CODEVALIDATION";
                clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublies;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
            //    return clsMiccomptewebmotpasseoublies;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
            //    return clsMiccomptewebmotpasseoublies;

            //}


            else
            {
                clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
            clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = "";
            clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = "";
            clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
            return clsMiccomptewebmotpasseoublies;

            }


        }

        public List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie> TestChampObligatoireDelete(HT_Stock.BOJ.clsMiccomptewebmotpasseoublie Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie> clsMiccomptewebmotpasseoublies = new List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie>();
            HT_Stock.BOJ.clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new HT_Stock.BOJ.clsMiccomptewebmotpasseoublie();

            if (string.IsNullOrEmpty(Objet.RP_NUMSEQUENCE))
            {
                clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", RP_NUMSEQUENCE";
                clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublies;

            }
            else
            {
            clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
            clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = "";
            clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = "";
            clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
            return clsMiccomptewebmotpasseoublies;

            }


        }


        public List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie> TestChampObligatoireMotDePasseOublier(HT_Stock.BOJ.clsMiccomptewebmotpasseoublie Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie> clsMiccomptewebmotpasseoublies = new List<HT_Stock.BOJ.clsMiccomptewebmotpasseoublie>();
            HT_Stock.BOJ.clsMiccomptewebmotpasseoublie clsMiccomptewebmotpasseoublie = new HT_Stock.BOJ.clsMiccomptewebmotpasseoublie();


            if (string.IsNullOrEmpty(Objet.LG_CODELANGUE))
            {
                clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", LG_CODELANGUE";
                clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublies;

            }
            //if (string.IsNullOrEmpty(Objet.OS_MACADRESSE))
            //{
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OS_MACADRESSE";
            //    clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
            //    return clsMiccomptewebmotpasseoublies;

            //}
            if (string.IsNullOrEmpty(Objet.SL_VERSIONAPK))
            {
                clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SL_VERSIONAPK";
                clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublies;

            }
            if (string.IsNullOrEmpty(Objet.CL_CONTACT))
            {
                clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CL_CONTACT";
                clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublies;

            }
            if (Objet.CL_CONTACT.Replace(" ", "")!= Objet.CL_CONTACT)
            {
                clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE ="Le contact doit être correct !!!";
                clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublies;

            }

            if (Objet.CL_CONTACT.Replace("-", "") != Objet.CL_CONTACT)
            {
                clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE ="Le contact doit être correct !!!";
                clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublies;

            }
            if (Objet.CL_CONTACT.Replace("/", "") != Objet.CL_CONTACT)
            {
                clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE ="Le contact doit être correct !!!";
                clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublies;

            }



            if (string.IsNullOrEmpty(Objet.TYPEOPERATION))
            {
                clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TYPEOPERATION";
                clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublies;

            }
            if (Objet.TYPEOPERATION != "03" && Objet.TYPEOPERATION != "04")
            {
                clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TYPEOPERATION";
                clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublies;

            }

            //if (string.IsNullOrEmpty(Objet.CL_CODECLIENT) && Objet.TYPEOPERATION == "04")
            //{
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CL_CODECLIENT";
            //    clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
            //    return clsMiccomptewebmotpasseoublies;

            //}


            if (string.IsNullOrEmpty(Objet.RP_DATE))
            {
                clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", RP_DATE";
                clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublies;

            }



            //if (string.IsNullOrEmpty(Objet.RP_CODEVALIDATION))
            //{
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", RP_CODEVALIDATION";
            //    clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
            //    return clsMiccomptewebmotpasseoublies;

            //}

            else
            {
                clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = "";
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = "";
                clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublies;

            }


        }

            public List<HT_Stock.BOJ.clsMiccomptewebUserNewPassword> TestChampObligatoireUpdateMotDePasse(HT_Stock.BOJ.clsMiccomptewebmotpasseoublie Objet)
            {

                HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
                Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
                Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

                List<HT_Stock.BOJ.clsMiccomptewebUserNewPassword> clsMiccomptewebmotpasseoublies = new List<HT_Stock.BOJ.clsMiccomptewebUserNewPassword>();
                HT_Stock.BOJ.clsMiccomptewebUserNewPassword clsMiccomptewebmotpasseoublie = new HT_Stock.BOJ.clsMiccomptewebUserNewPassword();


                if (string.IsNullOrEmpty(Objet.LG_CODELANGUE))
                {
                    clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", LG_CODELANGUE";
                    clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
                    return clsMiccomptewebmotpasseoublies;

                }

                if (string.IsNullOrEmpty(Objet.TYPEOPERATION))
                {
                    clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TYPEOPERATION";
                    clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
                    return clsMiccomptewebmotpasseoublies;

                }


            if (string.IsNullOrEmpty(Objet.SL_MOTPASSEOLD))
            {
                clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SL_MOTPASSEOLD";
                clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublies;

            }
            if (string.IsNullOrEmpty(Objet.SL_LOGINOLD))
            {
                clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SL_LOGINOLD";
                clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublies;

            }
            if (string.IsNullOrEmpty(Objet.SL_MOTPASSENEW))
            {
                clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SL_MOTPASSENEW";
                clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublies;

            }
            if (string.IsNullOrEmpty(Objet.SL_LOGINNEW))
            {
                clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SL_LOGINNEW";
                clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublies;

            }



            if (string.IsNullOrEmpty(Objet.SL_VERSIONAPK))
                {
                    clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SL_VERSIONAPK";
                    clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
                    return clsMiccomptewebmotpasseoublies;

                }
                //if (string.IsNullOrEmpty(Objet.CL_CONTACT))
                //{
                //    clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CL_CONTACT";
                //    clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
                //    return clsMiccomptewebmotpasseoublies;

                //}
                //if (Objet.CL_CONTACT.Replace(" ", "")!= Objet.CL_CONTACT)
                //{
                //    clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE ="Le contact doit être correct !!!";
                //    clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
                //    return clsMiccomptewebmotpasseoublies;

                //}

                //if (Objet.CL_CONTACT.Replace("-", "") != Objet.CL_CONTACT)
                //{
                //    clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE ="Le contact doit être correct !!!";
                //    clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
                //    return clsMiccomptewebmotpasseoublies;

                //}
                //if (Objet.CL_CONTACT.Replace("/", "") != Objet.CL_CONTACT)
                //{
                //    clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE ="Le contact doit être correct !!!";
                //    clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
                //    return clsMiccomptewebmotpasseoublies;

                //}




                //if (Objet.TYPEOPERATION != "03" && Objet.TYPEOPERATION != "04")
                //{
                //    clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TYPEOPERATION";
                //    clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
                //    return clsMiccomptewebmotpasseoublies;

                //}

                //if (string.IsNullOrEmpty(Objet.CL_CODECLIENT) && Objet.TYPEOPERATION == "04")
                //{
                //    clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CL_CODECLIENT";
                //    clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
                //    return clsMiccomptewebmotpasseoublies;

                //}


                //if (string.IsNullOrEmpty(Objet.RP_DATE))
                //{
                //    clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", RP_DATE";
                //    clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
                //    return clsMiccomptewebmotpasseoublies;

                //}



                //if (string.IsNullOrEmpty(Objet.RP_CODEVALIDATION))
                //{
                //    clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", RP_CODEVALIDATION";
                //    clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
                //    return clsMiccomptewebmotpasseoublies;

                //}

                else
                {
                    clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = "";
                    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = "";
                    clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
                    return clsMiccomptewebmotpasseoublies;

                }


            }



        public List<HT_Stock.BOJ.clsMiccomptewebUserNewPassword> TestChampObligatoireUserNewPassword(HT_Stock.BOJ.clsMiccomptewebmotpasseoublie Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsMiccomptewebUserNewPassword> clsMiccomptewebmotpasseoublies = new List<HT_Stock.BOJ.clsMiccomptewebUserNewPassword>();
            HT_Stock.BOJ.clsMiccomptewebUserNewPassword clsMiccomptewebmotpasseoublie = new HT_Stock.BOJ.clsMiccomptewebUserNewPassword();


            if (string.IsNullOrEmpty(Objet.LG_CODELANGUE))
            {
                clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", LG_CODELANGUE";
                clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublies;

            }
            //if (string.IsNullOrEmpty(Objet.OS_MACADRESSE))
            //{
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OS_MACADRESSE";
            //    clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
            //    return clsMiccomptewebmotpasseoublies;

            //}
            if (string.IsNullOrEmpty(Objet.SL_VERSIONAPK))
            {
                clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SL_VERSIONAPK";
                clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublies;

            }
            if (string.IsNullOrEmpty(Objet.SL_MOTDEPASSE))
            {
                clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SL_MOTDEPASSE";
                clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublies;

            }
        if (string.IsNullOrEmpty(Objet.RP_CODEVALIDATION))
        {
            clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", RP_CODEVALIDATION";
            clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
            return clsMiccomptewebmotpasseoublies;

        }
        if (string.IsNullOrEmpty(Objet.RP_DATE))
        {
            clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", RP_DATE";
            clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
            return clsMiccomptewebmotpasseoublies;

        }
        if (string.IsNullOrEmpty(Objet.RP_HEURE))
        {
            clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", RP_HEURE";
            clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
            return clsMiccomptewebmotpasseoublies;

        }
        if (string.IsNullOrEmpty(Objet.TYPEOPERATION))
        {
            clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TYPEOPERATION";
            clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
            return clsMiccomptewebmotpasseoublies;

        }

            //if (Objet.CL_CONTACT.Replace(" ", "")!= Objet.CL_CONTACT)
            //{
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE ="Le contact doit être correct !!!";
            //    clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
            //    return clsMiccomptewebmotpasseoublies;

            //}

            //if (Objet.CL_CONTACT.Replace("-", "") != Objet.CL_CONTACT)
            //{
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE ="Le contact doit être correct !!!";
            //    clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
            //    return clsMiccomptewebmotpasseoublies;

            //}
            //if (Objet.CL_CONTACT.Replace("/", "") != Objet.CL_CONTACT)
            //{
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE ="Le contact doit être correct !!!";
            //    clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
            //    return clsMiccomptewebmotpasseoublies;

            //}



            //if (string.IsNullOrEmpty(Objet.TYPEOPERATION))
            //{
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TYPEOPERATION";
            //    clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
            //    return clsMiccomptewebmotpasseoublies;

            //}
            if (Objet.TYPEOPERATION != "01" && Objet.TYPEOPERATION != "02")
            {
                clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TYPEOPERATION";
                clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublies;

            }

            //if (string.IsNullOrEmpty(Objet.CL_CODECLIENT) && Objet.TYPEOPERATION == "04")
            //{
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CL_CODECLIENT";
            //    clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
            //    return clsMiccomptewebmotpasseoublies;

            //}


            if (string.IsNullOrEmpty(Objet.RP_DATE))
            {
                clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", RP_DATE";
                clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublies;

            }



            //if (string.IsNullOrEmpty(Objet.RP_CODEVALIDATION))
            //{
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", RP_CODEVALIDATION";
            //    clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
            //    return clsMiccomptewebmotpasseoublies;

            //}

            else
            {
                clsMiccomptewebmotpasseoublie.clsObjetRetour = new Common.clsObjetRetour();
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_CODEMESSAGE = "";
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsMiccomptewebmotpasseoublie.clsObjetRetour.SL_MESSAGE = "";
                clsMiccomptewebmotpasseoublies.Add(clsMiccomptewebmotpasseoublie);
                return clsMiccomptewebmotpasseoublies;

            }


        }
    }
}