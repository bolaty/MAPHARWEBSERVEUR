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
	public partial class wsRisque
	{

        public List<HT_Stock.BOJ.clsCtparrisqueassurance> TestChampObligatoireListe(HT_Stock.BOJ.clsCtparrisqueassurance Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparrisqueassurance> clsCtparrisqueassurances = new List<HT_Stock.BOJ.clsCtparrisqueassurance>();
            HT_Stock.BOJ.clsCtparrisqueassurance clsCtparrisqueassurance = new HT_Stock.BOJ.clsCtparrisqueassurance();

            //if (string.IsNullOrEmpty(Objet.RQ_CODERISQUE))
            //{
            //    clsCtparrisqueassurance.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsCtparrisqueassurance.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparrisqueassurance.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsCtparrisqueassurance.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", RQ_CODERISQUE";
            //    clsCtparrisqueassurances.Add(clsCtparrisqueassurance);
            //    return clsCtparrisqueassurances;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparrisqueassurance.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparrisqueassurance.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparrisqueassurance.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparrisqueassurances.Add(clsCtparrisqueassurance);
            //    return clsCtparrisqueassurances;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparrisqueassurance.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparrisqueassurance.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparrisqueassurance.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparrisqueassurances.Add(clsCtparrisqueassurance);
            //    return clsCtparrisqueassurances;

            //}


            //else
            //{
                clsCtparrisqueassurance.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparrisqueassurance.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtparrisqueassurance.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtparrisqueassurance.clsObjetRetour.SL_MESSAGE = "";
                clsCtparrisqueassurances.Add(clsCtparrisqueassurance);
                return clsCtparrisqueassurances;

            //}


        }

        public List<HT_Stock.BOJ.clsCtparrisqueassurance> TestChampObligatoireInsert(HT_Stock.BOJ.clsCtparrisqueassurance Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparrisqueassurance> clsCtparrisqueassurances = new List<HT_Stock.BOJ.clsCtparrisqueassurance>();
            HT_Stock.BOJ.clsCtparrisqueassurance clsCtparrisqueassurance = new HT_Stock.BOJ.clsCtparrisqueassurance();

           

            if (string.IsNullOrEmpty(Objet.RQ_LIBELLERISQUE))
            {
                clsCtparrisqueassurance.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparrisqueassurance.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparrisqueassurance.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparrisqueassurance.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", RQ_LIBELLERISQUE";
                clsCtparrisqueassurances.Add(clsCtparrisqueassurance);
                return clsCtparrisqueassurances;

            }

            else
            {
                clsCtparrisqueassurance.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparrisqueassurance.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtparrisqueassurance.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtparrisqueassurance.clsObjetRetour.SL_MESSAGE = "";
                clsCtparrisqueassurances.Add(clsCtparrisqueassurance);
                return clsCtparrisqueassurances;

            }


        }

        public List<HT_Stock.BOJ.clsCtparrisqueassurance> TestChampObligatoireUpdate(HT_Stock.BOJ.clsCtparrisqueassurance Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparrisqueassurance> clsCtparrisqueassurances = new List<HT_Stock.BOJ.clsCtparrisqueassurance>();
            HT_Stock.BOJ.clsCtparrisqueassurance clsCtparrisqueassurance = new HT_Stock.BOJ.clsCtparrisqueassurance();

            if (string.IsNullOrEmpty(Objet.RQ_CODERISQUE))
            {
                clsCtparrisqueassurance.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparrisqueassurance.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparrisqueassurance.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparrisqueassurance.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", RQ_CODERISQUE";
                clsCtparrisqueassurances.Add(clsCtparrisqueassurance);
                return clsCtparrisqueassurances;

            }

            if (string.IsNullOrEmpty(Objet.RQ_LIBELLERISQUE))
            {
                clsCtparrisqueassurance.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparrisqueassurance.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparrisqueassurance.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparrisqueassurance.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", RQ_LIBELLERISQUE";
                clsCtparrisqueassurances.Add(clsCtparrisqueassurance);
                return clsCtparrisqueassurances;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparrisqueassurance.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparrisqueassurance.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparrisqueassurance.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparrisqueassurances.Add(clsCtparrisqueassurance);
            //    return clsCtparrisqueassurances;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparrisqueassurance.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparrisqueassurance.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparrisqueassurance.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtparrisqueassurances.Add(clsCtparrisqueassurance);
            //    return clsCtparrisqueassurances;

            //}


            else
            {
                clsCtparrisqueassurance.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparrisqueassurance.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparrisqueassurance.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparrisqueassurance.clsObjetRetour.SL_MESSAGE = "";
            clsCtparrisqueassurances.Add(clsCtparrisqueassurance);
            return clsCtparrisqueassurances;

            }


        }

        public List<HT_Stock.BOJ.clsCtparrisqueassurance> TestChampObligatoireDelete(HT_Stock.BOJ.clsCtparrisqueassurance Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparrisqueassurance> clsCtparrisqueassurances = new List<HT_Stock.BOJ.clsCtparrisqueassurance>();
            HT_Stock.BOJ.clsCtparrisqueassurance clsCtparrisqueassurance = new HT_Stock.BOJ.clsCtparrisqueassurance();

            if (string.IsNullOrEmpty(Objet.RQ_CODERISQUE))
            {
                clsCtparrisqueassurance.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparrisqueassurance.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparrisqueassurance.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparrisqueassurance.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", RQ_CODERISQUE";
                clsCtparrisqueassurances.Add(clsCtparrisqueassurance);
                return clsCtparrisqueassurances;

            }
            else
            {
            clsCtparrisqueassurance.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparrisqueassurance.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparrisqueassurance.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparrisqueassurance.clsObjetRetour.SL_MESSAGE = "";
            clsCtparrisqueassurances.Add(clsCtparrisqueassurance);
            return clsCtparrisqueassurances;

            }


        }


    }
}