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
	public partial class wsCtpartypecontratsante
	{

        public List<HT_Stock.BOJ.clsCtpartypecontratsante> TestChampObligatoireListe(HT_Stock.BOJ.clsCtpartypecontratsante Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtpartypecontratsante> clsCtpartypecontratsantes = new List<HT_Stock.BOJ.clsCtpartypecontratsante>();
            HT_Stock.BOJ.clsCtpartypecontratsante clsCtpartypecontratsante = new HT_Stock.BOJ.clsCtpartypecontratsante();

            //if (string.IsNullOrEmpty(Objet.TA_CODETYPECONTRATSANTE))
            //{
            //    clsCtpartypecontratsante.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsCtpartypecontratsante.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtpartypecontratsante.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsCtpartypecontratsante.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TA_CODETYPECONTRATSANTE";
            //    clsCtpartypecontratsantes.Add(clsCtpartypecontratsante);
            //    return clsCtpartypecontratsantes;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtpartypecontratsante.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtpartypecontratsante.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtpartypecontratsante.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtpartypecontratsantes.Add(clsCtpartypecontratsante);
            //    return clsCtpartypecontratsantes;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtpartypecontratsante.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtpartypecontratsante.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtpartypecontratsante.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtpartypecontratsantes.Add(clsCtpartypecontratsante);
            //    return clsCtpartypecontratsantes;

            //}


            //else
            //{
                clsCtpartypecontratsante.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpartypecontratsante.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtpartypecontratsante.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtpartypecontratsante.clsObjetRetour.SL_MESSAGE = "";
                clsCtpartypecontratsantes.Add(clsCtpartypecontratsante);
                return clsCtpartypecontratsantes;

            //}


        }

        public List<HT_Stock.BOJ.clsCtpartypecontratsante> TestChampObligatoireInsert(HT_Stock.BOJ.clsCtpartypecontratsante Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtpartypecontratsante> clsCtpartypecontratsantes = new List<HT_Stock.BOJ.clsCtpartypecontratsante>();
            HT_Stock.BOJ.clsCtpartypecontratsante clsCtpartypecontratsante = new HT_Stock.BOJ.clsCtpartypecontratsante();

           

            if (string.IsNullOrEmpty(Objet.TA_LIBELLETYPECONTRATSANTE))
            {
                clsCtpartypecontratsante.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtpartypecontratsante.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtpartypecontratsante.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtpartypecontratsante.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TA_LIBELLETYPECONTRATSANTE";
                clsCtpartypecontratsantes.Add(clsCtpartypecontratsante);
                return clsCtpartypecontratsantes;

            }

            else
            {
                clsCtpartypecontratsante.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpartypecontratsante.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtpartypecontratsante.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtpartypecontratsante.clsObjetRetour.SL_MESSAGE = "";
                clsCtpartypecontratsantes.Add(clsCtpartypecontratsante);
                return clsCtpartypecontratsantes;

            }


        }

        public List<HT_Stock.BOJ.clsCtpartypecontratsante> TestChampObligatoireUpdate(HT_Stock.BOJ.clsCtpartypecontratsante Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtpartypecontratsante> clsCtpartypecontratsantes = new List<HT_Stock.BOJ.clsCtpartypecontratsante>();
            HT_Stock.BOJ.clsCtpartypecontratsante clsCtpartypecontratsante = new HT_Stock.BOJ.clsCtpartypecontratsante();

            if (string.IsNullOrEmpty(Objet.TA_CODETYPECONTRATSANTE))
            {
                clsCtpartypecontratsante.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtpartypecontratsante.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtpartypecontratsante.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtpartypecontratsante.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TA_CODETYPECONTRATSANTE";
                clsCtpartypecontratsantes.Add(clsCtpartypecontratsante);
                return clsCtpartypecontratsantes;

            }

            if (string.IsNullOrEmpty(Objet.TA_LIBELLETYPECONTRATSANTE))
            {
                clsCtpartypecontratsante.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtpartypecontratsante.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtpartypecontratsante.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtpartypecontratsante.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TA_LIBELLETYPECONTRATSANTE";
                clsCtpartypecontratsantes.Add(clsCtpartypecontratsante);
                return clsCtpartypecontratsantes;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtpartypecontratsante.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtpartypecontratsante.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtpartypecontratsante.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtpartypecontratsantes.Add(clsCtpartypecontratsante);
            //    return clsCtpartypecontratsantes;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtpartypecontratsante.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtpartypecontratsante.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtpartypecontratsante.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtpartypecontratsantes.Add(clsCtpartypecontratsante);
            //    return clsCtpartypecontratsantes;

            //}


            else
            {
                clsCtpartypecontratsante.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpartypecontratsante.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtpartypecontratsante.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtpartypecontratsante.clsObjetRetour.SL_MESSAGE = "";
            clsCtpartypecontratsantes.Add(clsCtpartypecontratsante);
            return clsCtpartypecontratsantes;

            }


        }

        public List<HT_Stock.BOJ.clsCtpartypecontratsante> TestChampObligatoireDelete(HT_Stock.BOJ.clsCtpartypecontratsante Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtpartypecontratsante> clsCtpartypecontratsantes = new List<HT_Stock.BOJ.clsCtpartypecontratsante>();
            HT_Stock.BOJ.clsCtpartypecontratsante clsCtpartypecontratsante = new HT_Stock.BOJ.clsCtpartypecontratsante();

            if (string.IsNullOrEmpty(Objet.TA_CODETYPECONTRATSANTE))
            {
                clsCtpartypecontratsante.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtpartypecontratsante.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtpartypecontratsante.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtpartypecontratsante.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TA_CODETYPECONTRATSANTE";
                clsCtpartypecontratsantes.Add(clsCtpartypecontratsante);
                return clsCtpartypecontratsantes;

            }
            else
            {
            clsCtpartypecontratsante.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpartypecontratsante.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtpartypecontratsante.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtpartypecontratsante.clsObjetRetour.SL_MESSAGE = "";
            clsCtpartypecontratsantes.Add(clsCtpartypecontratsante);
            return clsCtpartypecontratsantes;

            }


        }


    }
}