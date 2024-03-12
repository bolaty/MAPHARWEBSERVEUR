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
	public partial class wsSection
	{

        public List<HT_Stock.BOJ.clsPhaparsection> TestChampObligatoireListe(HT_Stock.BOJ.clsPhaparsection Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhaparsection> clsPhaparsections = new List<HT_Stock.BOJ.clsPhaparsection>();
            HT_Stock.BOJ.clsPhaparsection clsPhaparsection = new HT_Stock.BOJ.clsPhaparsection();

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsPhaparsection.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhaparsection.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhaparsection.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhaparsection.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsPhaparsections.Add(clsPhaparsection);
                return clsPhaparsections;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhaparsection.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhaparsection.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhaparsection.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhaparsections.Add(clsPhaparsection);
            //    return clsPhaparsections;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhaparsection.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhaparsection.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhaparsection.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhaparsections.Add(clsPhaparsection);
            //    return clsPhaparsections;

            //}


            else
            {
                clsPhaparsection.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparsection.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhaparsection.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhaparsection.clsObjetRetour.SL_MESSAGE = "";
                clsPhaparsections.Add(clsPhaparsection);
                return clsPhaparsections;

            }


        }

        public List<HT_Stock.BOJ.clsPhaparsection> TestChampObligatoireInsert(HT_Stock.BOJ.clsPhaparsection Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhaparsection> clsPhaparsections = new List<HT_Stock.BOJ.clsPhaparsection>();
            HT_Stock.BOJ.clsPhaparsection clsPhaparsection = new HT_Stock.BOJ.clsPhaparsection();

           

            if (string.IsNullOrEmpty(Objet.SC_DENOMINATION))
            {
                clsPhaparsection.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhaparsection.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhaparsection.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhaparsection.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SC_DENOMINATION";
                clsPhaparsections.Add(clsPhaparsection);
                return clsPhaparsections;

            }

            else
            {
                clsPhaparsection.clsObjetRetour = new Common.clsObjetRetour();
                clsPhaparsection.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhaparsection.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhaparsection.clsObjetRetour.SL_MESSAGE = "";
                clsPhaparsections.Add(clsPhaparsection);
                return clsPhaparsections;

            }


        }

        public List<HT_Stock.BOJ.clsPhaparsection> TestChampObligatoireUpdate(HT_Stock.BOJ.clsPhaparsection Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhaparsection> clsPhaparsections = new List<HT_Stock.BOJ.clsPhaparsection>();
            HT_Stock.BOJ.clsPhaparsection clsPhaparsection = new HT_Stock.BOJ.clsPhaparsection();

            if (string.IsNullOrEmpty(Objet.SC_CODESECTION))
            {
                clsPhaparsection.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhaparsection.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhaparsection.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhaparsection.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SC_CODESECTION";
                clsPhaparsections.Add(clsPhaparsection);
                return clsPhaparsections;

            }

            if (string.IsNullOrEmpty(Objet.SC_DENOMINATION))
            {
                clsPhaparsection.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhaparsection.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhaparsection.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhaparsection.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SC_DENOMINATION";
                clsPhaparsections.Add(clsPhaparsection);
                return clsPhaparsections;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhaparsection.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhaparsection.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhaparsection.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhaparsections.Add(clsPhaparsection);
            //    return clsPhaparsections;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhaparsection.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhaparsection.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhaparsection.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhaparsections.Add(clsPhaparsection);
            //    return clsPhaparsections;

            //}


            else
            {
                clsPhaparsection.clsObjetRetour = new Common.clsObjetRetour();
            clsPhaparsection.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhaparsection.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhaparsection.clsObjetRetour.SL_MESSAGE = "";
            clsPhaparsections.Add(clsPhaparsection);
            return clsPhaparsections;

            }


        }

        public List<HT_Stock.BOJ.clsPhaparsection> TestChampObligatoireDelete(HT_Stock.BOJ.clsPhaparsection Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhaparsection> clsPhaparsections = new List<HT_Stock.BOJ.clsPhaparsection>();
            HT_Stock.BOJ.clsPhaparsection clsPhaparsection = new HT_Stock.BOJ.clsPhaparsection();

            if (string.IsNullOrEmpty(Objet.SC_CODESECTION))
            {
                clsPhaparsection.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhaparsection.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhaparsection.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhaparsection.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SC_CODESECTION";
                clsPhaparsections.Add(clsPhaparsection);
                return clsPhaparsections;

            }
            else
            {
            clsPhaparsection.clsObjetRetour = new Common.clsObjetRetour();
            clsPhaparsection.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhaparsection.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhaparsection.clsObjetRetour.SL_MESSAGE = "";
            clsPhaparsections.Add(clsPhaparsection);
            return clsPhaparsections;

            }


        }


    }
}