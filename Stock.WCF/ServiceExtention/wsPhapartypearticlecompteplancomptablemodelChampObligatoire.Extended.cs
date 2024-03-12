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
	public partial class wsPhapartypearticlecompteplancomptablemodel
	{

        public List<HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel> TestChampObligatoireListe(HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel> clsPhapartypearticlecompteplancomptablemodels = new List<HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel>();
            HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel clsPhapartypearticlecompteplancomptablemodel = new HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel();

            //if (string.IsNullOrEmpty(Objet.AC_CODEPhapartypearticlecompteplancomptablemodel))
            //{
            //    clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AC_CODEPhapartypearticlecompteplancomptablemodel";
            //    clsPhapartypearticlecompteplancomptablemodels.Add(clsPhapartypearticlecompteplancomptablemodel);
            //    return clsPhapartypearticlecompteplancomptablemodels;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhapartypearticlecompteplancomptablemodels.Add(clsPhapartypearticlecompteplancomptablemodel);
            //    return clsPhapartypearticlecompteplancomptablemodels;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhapartypearticlecompteplancomptablemodels.Add(clsPhapartypearticlecompteplancomptablemodel);
            //    return clsPhapartypearticlecompteplancomptablemodels;

            //}


            //else
            //{
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_MESSAGE = "";
                clsPhapartypearticlecompteplancomptablemodels.Add(clsPhapartypearticlecompteplancomptablemodel);
                return clsPhapartypearticlecompteplancomptablemodels;

            //}


        }

        public List<HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel> TestChampObligatoireInsert(HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel> clsPhapartypearticlecompteplancomptablemodels = new List<HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel>();
            HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel clsPhapartypearticlecompteplancomptablemodel = new HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel();

           

            if (string.IsNullOrEmpty(Objet.CP_CODEOPERATIONLIBELLECPTE))
            {
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CP_CODEOPERATIONLIBELLECPTE";
                clsPhapartypearticlecompteplancomptablemodels.Add(clsPhapartypearticlecompteplancomptablemodel);
                return clsPhapartypearticlecompteplancomptablemodels;

            }

            else
            {
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_MESSAGE = "";
                clsPhapartypearticlecompteplancomptablemodels.Add(clsPhapartypearticlecompteplancomptablemodel);
                return clsPhapartypearticlecompteplancomptablemodels;

            }


        }

        public List<HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel> TestChampObligatoireUpdate(HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel> clsPhapartypearticlecompteplancomptablemodels = new List<HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel>();
            HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel clsPhapartypearticlecompteplancomptablemodel = new HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel();

            if (string.IsNullOrEmpty(Objet.CP_CODEOPERATIONLIBELLECPTE))
            {
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CP_CODEOPERATIONLIBELLECPTE";
                clsPhapartypearticlecompteplancomptablemodels.Add(clsPhapartypearticlecompteplancomptablemodel);
                return clsPhapartypearticlecompteplancomptablemodels;

            }

            if (string.IsNullOrEmpty(Objet.CP_CODEOPERATIONLIBELLECPTE))
            {
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CP_CODEOPERATIONLIBELLECPTE";
                clsPhapartypearticlecompteplancomptablemodels.Add(clsPhapartypearticlecompteplancomptablemodel);
                return clsPhapartypearticlecompteplancomptablemodels;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhapartypearticlecompteplancomptablemodels.Add(clsPhapartypearticlecompteplancomptablemodel);
            //    return clsPhapartypearticlecompteplancomptablemodels;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhapartypearticlecompteplancomptablemodels.Add(clsPhapartypearticlecompteplancomptablemodel);
            //    return clsPhapartypearticlecompteplancomptablemodels;

            //}


            else
            {
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour = new Common.clsObjetRetour();
            clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_MESSAGE = "";
            clsPhapartypearticlecompteplancomptablemodels.Add(clsPhapartypearticlecompteplancomptablemodel);
            return clsPhapartypearticlecompteplancomptablemodels;

            }


        }

        public List<HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel> TestChampObligatoireDelete(HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel> clsPhapartypearticlecompteplancomptablemodels = new List<HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel>();
            HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel clsPhapartypearticlecompteplancomptablemodel = new HT_Stock.BOJ.clsPhapartypearticlecompteplancomptablemodel();

            if (string.IsNullOrEmpty(Objet.CP_CODEOPERATIONLIBELLECPTE))
            {
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CP_CODEOPERATIONLIBELLECPTE";
                clsPhapartypearticlecompteplancomptablemodels.Add(clsPhapartypearticlecompteplancomptablemodel);
                return clsPhapartypearticlecompteplancomptablemodels;

            }
            else
            {
            clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour = new Common.clsObjetRetour();
            clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhapartypearticlecompteplancomptablemodel.clsObjetRetour.SL_MESSAGE = "";
            clsPhapartypearticlecompteplancomptablemodels.Add(clsPhapartypearticlecompteplancomptablemodel);
            return clsPhapartypearticlecompteplancomptablemodels;

            }


        }


    }
}