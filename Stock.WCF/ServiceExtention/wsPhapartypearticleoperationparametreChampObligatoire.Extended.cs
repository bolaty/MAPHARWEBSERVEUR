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
	public partial class wsPhapartypearticleoperationparametre
	{

        public List<HT_Stock.BOJ.clsPhapartypearticleoperationparametre> TestChampObligatoireListe(HT_Stock.BOJ.clsPhapartypearticleoperationparametre Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhapartypearticleoperationparametre> clsPhapartypearticleoperationparametres = new List<HT_Stock.BOJ.clsPhapartypearticleoperationparametre>();
            HT_Stock.BOJ.clsPhapartypearticleoperationparametre clsPhapartypearticleoperationparametre = new HT_Stock.BOJ.clsPhapartypearticleoperationparametre();

            if (string.IsNullOrEmpty(Objet.TO_CODEOPERATION))
            {
                clsPhapartypearticleoperationparametre.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhapartypearticleoperationparametre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhapartypearticleoperationparametre.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhapartypearticleoperationparametre.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TO_CODEOPERATION";
                clsPhapartypearticleoperationparametres.Add(clsPhapartypearticleoperationparametre);
                return clsPhapartypearticleoperationparametres;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhapartypearticleoperationparametre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhapartypearticleoperationparametre.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhapartypearticleoperationparametre.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhapartypearticleoperationparametres.Add(clsPhapartypearticleoperationparametre);
            //    return clsPhapartypearticleoperationparametres;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhapartypearticleoperationparametre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhapartypearticleoperationparametre.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhapartypearticleoperationparametre.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhapartypearticleoperationparametres.Add(clsPhapartypearticleoperationparametre);
            //    return clsPhapartypearticleoperationparametres;

            //}


            else
            {
                clsPhapartypearticleoperationparametre.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapartypearticleoperationparametre.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhapartypearticleoperationparametre.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhapartypearticleoperationparametre.clsObjetRetour.SL_MESSAGE = "";
                clsPhapartypearticleoperationparametres.Add(clsPhapartypearticleoperationparametre);
                return clsPhapartypearticleoperationparametres;

            }


        }

        public List<HT_Stock.BOJ.clsPhapartypearticleoperationparametre> TestChampObligatoireInsert(HT_Stock.BOJ.clsPhapartypearticleoperationparametre Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhapartypearticleoperationparametre> clsPhapartypearticleoperationparametres = new List<HT_Stock.BOJ.clsPhapartypearticleoperationparametre>();
            HT_Stock.BOJ.clsPhapartypearticleoperationparametre clsPhapartypearticleoperationparametre = new HT_Stock.BOJ.clsPhapartypearticleoperationparametre();

           

            if (string.IsNullOrEmpty(Objet.TO_CODEOPERATION))
            {
                clsPhapartypearticleoperationparametre.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhapartypearticleoperationparametre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhapartypearticleoperationparametre.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhapartypearticleoperationparametre.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TO_CODEOPERATION";
                clsPhapartypearticleoperationparametres.Add(clsPhapartypearticleoperationparametre);
                return clsPhapartypearticleoperationparametres;

            }

            else
            {
                clsPhapartypearticleoperationparametre.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapartypearticleoperationparametre.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhapartypearticleoperationparametre.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhapartypearticleoperationparametre.clsObjetRetour.SL_MESSAGE = "";
                clsPhapartypearticleoperationparametres.Add(clsPhapartypearticleoperationparametre);
                return clsPhapartypearticleoperationparametres;

            }


        }

        public List<HT_Stock.BOJ.clsPhapartypearticleoperationparametre> TestChampObligatoireUpdate(HT_Stock.BOJ.clsPhapartypearticleoperationparametre Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhapartypearticleoperationparametre> clsPhapartypearticleoperationparametres = new List<HT_Stock.BOJ.clsPhapartypearticleoperationparametre>();
            HT_Stock.BOJ.clsPhapartypearticleoperationparametre clsPhapartypearticleoperationparametre = new HT_Stock.BOJ.clsPhapartypearticleoperationparametre();

            if (string.IsNullOrEmpty(Objet.TO_CODEOPERATIONPARAMETRE))
            {
                clsPhapartypearticleoperationparametre.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhapartypearticleoperationparametre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhapartypearticleoperationparametre.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhapartypearticleoperationparametre.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TO_CODEOPERATIONPARAMETRE";
                clsPhapartypearticleoperationparametres.Add(clsPhapartypearticleoperationparametre);
                return clsPhapartypearticleoperationparametres;

            }

            if (string.IsNullOrEmpty(Objet.TO_CODEOPERATION))
            {
                clsPhapartypearticleoperationparametre.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhapartypearticleoperationparametre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhapartypearticleoperationparametre.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhapartypearticleoperationparametre.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TO_CODEOPERATION";
                clsPhapartypearticleoperationparametres.Add(clsPhapartypearticleoperationparametre);
                return clsPhapartypearticleoperationparametres;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhapartypearticleoperationparametre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhapartypearticleoperationparametre.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhapartypearticleoperationparametre.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhapartypearticleoperationparametres.Add(clsPhapartypearticleoperationparametre);
            //    return clsPhapartypearticleoperationparametres;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhapartypearticleoperationparametre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhapartypearticleoperationparametre.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhapartypearticleoperationparametre.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhapartypearticleoperationparametres.Add(clsPhapartypearticleoperationparametre);
            //    return clsPhapartypearticleoperationparametres;

            //}


            else
            {
                clsPhapartypearticleoperationparametre.clsObjetRetour = new Common.clsObjetRetour();
            clsPhapartypearticleoperationparametre.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhapartypearticleoperationparametre.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhapartypearticleoperationparametre.clsObjetRetour.SL_MESSAGE = "";
            clsPhapartypearticleoperationparametres.Add(clsPhapartypearticleoperationparametre);
            return clsPhapartypearticleoperationparametres;

            }


        }



        public List<HT_Stock.BOJ.clsPhapartypearticleoperationparametre> TestTestContrainteListe(HT_Stock.BOJ.clsPhapartypearticleoperationparametre Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhapartypearticleoperationparametre> clsPhapartypearticleoperationparametres = new List<HT_Stock.BOJ.clsPhapartypearticleoperationparametre>();
            HT_Stock.BOJ.clsPhapartypearticleoperationparametre clsPhapartypearticleoperationparametre = new HT_Stock.BOJ.clsPhapartypearticleoperationparametre();

            //if (string.IsNullOrEmpty(Objet.TO_CODEOPERATIONPARAMETRE))
            //{
            //    clsPhapartypearticleoperationparametre.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsPhapartypearticleoperationparametre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhapartypearticleoperationparametre.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsPhapartypearticleoperationparametre.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TO_CODEOPERATIONPARAMETRE";
            //    clsPhapartypearticleoperationparametres.Add(clsPhapartypearticleoperationparametre);
            //    return clsPhapartypearticleoperationparametres;

            //}
            //else
            //{
                clsPhapartypearticleoperationparametre.clsObjetRetour = new Common.clsObjetRetour();
                clsPhapartypearticleoperationparametre.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhapartypearticleoperationparametre.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhapartypearticleoperationparametre.clsObjetRetour.SL_MESSAGE = "";
                clsPhapartypearticleoperationparametres.Add(clsPhapartypearticleoperationparametre);
                return clsPhapartypearticleoperationparametres;

            //}


        }

        public List<HT_Stock.BOJ.clsPhapartypearticleoperationparametre> TestChampObligatoireDelete(HT_Stock.BOJ.clsPhapartypearticleoperationparametre Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhapartypearticleoperationparametre> clsPhapartypearticleoperationparametres = new List<HT_Stock.BOJ.clsPhapartypearticleoperationparametre>();
            HT_Stock.BOJ.clsPhapartypearticleoperationparametre clsPhapartypearticleoperationparametre = new HT_Stock.BOJ.clsPhapartypearticleoperationparametre();

            if (string.IsNullOrEmpty(Objet.TO_CODEOPERATIONPARAMETRE))
            {
                clsPhapartypearticleoperationparametre.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhapartypearticleoperationparametre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhapartypearticleoperationparametre.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhapartypearticleoperationparametre.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TO_CODEOPERATIONPARAMETRE";
                clsPhapartypearticleoperationparametres.Add(clsPhapartypearticleoperationparametre);
                return clsPhapartypearticleoperationparametres;

            }
            else
            {
            clsPhapartypearticleoperationparametre.clsObjetRetour = new Common.clsObjetRetour();
            clsPhapartypearticleoperationparametre.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhapartypearticleoperationparametre.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhapartypearticleoperationparametre.clsObjetRetour.SL_MESSAGE = "";
            clsPhapartypearticleoperationparametres.Add(clsPhapartypearticleoperationparametre);
            return clsPhapartypearticleoperationparametres;

            }


        }


    }
}