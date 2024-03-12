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
	public partial class wsService
	{

        public List<HT_Stock.BOJ.clsService> TestChampObligatoireListe(HT_Stock.BOJ.clsService Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsService> clsServices = new List<HT_Stock.BOJ.clsService>();
            HT_Stock.BOJ.clsService clsService = new HT_Stock.BOJ.clsService();

            //if (string.IsNullOrEmpty(Objet.SR_CODESERVICE))
            //{
            //    clsService.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsService.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsService.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsService.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SR_CODESERVICE";
            //    clsServices.Add(clsService);
            //    return clsServices;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsService.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsService.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsService.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsServices.Add(clsService);
            //    return clsServices;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsService.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsService.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsService.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsServices.Add(clsService);
            //    return clsServices;

            //}


            //else
            //{
                clsService.clsObjetRetour = new Common.clsObjetRetour();
                clsService.clsObjetRetour.SL_CODEMESSAGE = "";
                clsService.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsService.clsObjetRetour.SL_MESSAGE = "";
                clsServices.Add(clsService);
                return clsServices;

            //}


        }

        public List<HT_Stock.BOJ.clsService> TestChampObligatoireInsert(HT_Stock.BOJ.clsService Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsService> clsServices = new List<HT_Stock.BOJ.clsService>();
            HT_Stock.BOJ.clsService clsService = new HT_Stock.BOJ.clsService();

           

            if (string.IsNullOrEmpty(Objet.SR_LIBELLE))
            {
                clsService.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsService.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsService.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsService.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SR_LIBELLE";
                clsServices.Add(clsService);
                return clsServices;

            }

            else
            {
                clsService.clsObjetRetour = new Common.clsObjetRetour();
                clsService.clsObjetRetour.SL_CODEMESSAGE = "";
                clsService.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsService.clsObjetRetour.SL_MESSAGE = "";
                clsServices.Add(clsService);
                return clsServices;

            }


        }

        public List<HT_Stock.BOJ.clsService> TestChampObligatoireUpdate(HT_Stock.BOJ.clsService Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsService> clsServices = new List<HT_Stock.BOJ.clsService>();
            HT_Stock.BOJ.clsService clsService = new HT_Stock.BOJ.clsService();

            if (string.IsNullOrEmpty(Objet.SR_CODESERVICE))
            {
                clsService.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsService.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsService.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsService.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SR_CODESERVICE";
                clsServices.Add(clsService);
                return clsServices;

            }

            if (string.IsNullOrEmpty(Objet.SR_LIBELLE))
            {
                clsService.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsService.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsService.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsService.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SR_LIBELLE";
                clsServices.Add(clsService);
                return clsServices;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsService.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsService.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsService.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsServices.Add(clsService);
            //    return clsServices;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsService.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsService.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsService.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsServices.Add(clsService);
            //    return clsServices;

            //}


            else
            {
                clsService.clsObjetRetour = new Common.clsObjetRetour();
            clsService.clsObjetRetour.SL_CODEMESSAGE = "";
            clsService.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsService.clsObjetRetour.SL_MESSAGE = "";
            clsServices.Add(clsService);
            return clsServices;

            }


        }

        public List<HT_Stock.BOJ.clsService> TestChampObligatoireDelete(HT_Stock.BOJ.clsService Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsService> clsServices = new List<HT_Stock.BOJ.clsService>();
            HT_Stock.BOJ.clsService clsService = new HT_Stock.BOJ.clsService();

            if (string.IsNullOrEmpty(Objet.SR_CODESERVICE))
            {
                clsService.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsService.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsService.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsService.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SR_CODESERVICE";
                clsServices.Add(clsService);
                return clsServices;

            }
            else
            {
            clsService.clsObjetRetour = new Common.clsObjetRetour();
            clsService.clsObjetRetour.SL_CODEMESSAGE = "";
            clsService.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsService.clsObjetRetour.SL_MESSAGE = "";
            clsServices.Add(clsService);
            return clsServices;

            }


        }


    }
}