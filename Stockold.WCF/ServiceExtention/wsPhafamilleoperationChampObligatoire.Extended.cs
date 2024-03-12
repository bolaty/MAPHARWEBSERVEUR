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
	public partial class wsPhafamilleoperation
    {


        
    

    public List<HT_Stock.BOJ.clsPhafamilleoperation> TestChampObligatoireListe(HT_Stock.BOJ.clsPhafamilleoperation Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhafamilleoperation> clsPhafamilleoperations = new List<HT_Stock.BOJ.clsPhafamilleoperation>();
            HT_Stock.BOJ.clsPhafamilleoperation clsPhafamilleoperation = new HT_Stock.BOJ.clsPhafamilleoperation();

            if (string.IsNullOrEmpty(Objet.NF_CODENATUREFAMILLEOPERATION))
            {
                clsPhafamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhafamilleoperation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhafamilleoperation.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhafamilleoperation.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", NF_CODENATUREFAMILLEOPERATION";
                clsPhafamilleoperations.Add(clsPhafamilleoperation);
                return clsPhafamilleoperations;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhafamilleoperation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhafamilleoperation.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhafamilleoperation.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhafamilleoperations.Add(clsPhafamilleoperation);
            //    return clsPhafamilleoperations;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhafamilleoperation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhafamilleoperation.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhafamilleoperation.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhafamilleoperations.Add(clsPhafamilleoperation);
            //    return clsPhafamilleoperations;

            //}


            //else
            //{
            clsPhafamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
                clsPhafamilleoperation.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhafamilleoperation.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhafamilleoperation.clsObjetRetour.SL_MESSAGE = "";
                clsPhafamilleoperations.Add(clsPhafamilleoperation);
                return clsPhafamilleoperations;

            //}


        }


        public List<HT_Stock.BOJ.clsPhafamilleoperation> TestChampObligatoireListeTreso(HT_Stock.BOJ.clsPhafamilleoperation Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhafamilleoperation> clsPhafamilleoperations = new List<HT_Stock.BOJ.clsPhafamilleoperation>();
            HT_Stock.BOJ.clsPhafamilleoperation clsPhafamilleoperation = new HT_Stock.BOJ.clsPhafamilleoperation();

            if (string.IsNullOrEmpty(Objet.NF_CODENATUREFAMILLEOPERATION))
            {
                clsPhafamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhafamilleoperation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhafamilleoperation.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhafamilleoperation.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", NF_CODENATUREFAMILLEOPERATION";
                clsPhafamilleoperations.Add(clsPhafamilleoperation);
                return clsPhafamilleoperations;

            }

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsPhafamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhafamilleoperation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhafamilleoperation.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhafamilleoperation.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsPhafamilleoperations.Add(clsPhafamilleoperation);
                return clsPhafamilleoperations;

            }

            if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUR))
            {
                clsPhafamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhafamilleoperation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhafamilleoperation.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhafamilleoperation.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_CODEOPERATEUR";
                clsPhafamilleoperations.Add(clsPhafamilleoperation);
                return clsPhafamilleoperations;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhafamilleoperation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhafamilleoperation.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhafamilleoperation.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhafamilleoperations.Add(clsPhafamilleoperation);
            //    return clsPhafamilleoperations;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhafamilleoperation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhafamilleoperation.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhafamilleoperation.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhafamilleoperations.Add(clsPhafamilleoperation);
            //    return clsPhafamilleoperations;

            //}


            //else
            //{
            clsPhafamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
            clsPhafamilleoperation.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhafamilleoperation.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhafamilleoperation.clsObjetRetour.SL_MESSAGE = "";
            clsPhafamilleoperations.Add(clsPhafamilleoperation);
            return clsPhafamilleoperations;

            //}


        }

        public List<HT_Stock.BOJ.clsPhafamilleoperation> TestChampObligatoireInsert(HT_Stock.BOJ.clsPhafamilleoperation Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhafamilleoperation> clsPhafamilleoperations = new List<HT_Stock.BOJ.clsPhafamilleoperation>();
            HT_Stock.BOJ.clsPhafamilleoperation clsPhafamilleoperation = new HT_Stock.BOJ.clsPhafamilleoperation();

           

            if (string.IsNullOrEmpty(Objet.FO_LIBELLEFAMILLEOPERATION))
            {
                clsPhafamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhafamilleoperation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhafamilleoperation.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhafamilleoperation.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", FO_LIBELLEFAMILLEOPERATION";
                clsPhafamilleoperations.Add(clsPhafamilleoperation);
                return clsPhafamilleoperations;

            }

            else
            {
                clsPhafamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
                clsPhafamilleoperation.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhafamilleoperation.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhafamilleoperation.clsObjetRetour.SL_MESSAGE = "";
                clsPhafamilleoperations.Add(clsPhafamilleoperation);
                return clsPhafamilleoperations;

            }


        }

        public List<HT_Stock.BOJ.clsPhafamilleoperation> TestChampObligatoireUpdate(HT_Stock.BOJ.clsPhafamilleoperation Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhafamilleoperation> clsPhafamilleoperations = new List<HT_Stock.BOJ.clsPhafamilleoperation>();
            HT_Stock.BOJ.clsPhafamilleoperation clsPhafamilleoperation = new HT_Stock.BOJ.clsPhafamilleoperation();

            if (string.IsNullOrEmpty(Objet.FO_CODEFAMILLEOPERATION))
            {
                clsPhafamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhafamilleoperation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhafamilleoperation.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhafamilleoperation.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", FO_CODEFAMILLEOPERATION";
                clsPhafamilleoperations.Add(clsPhafamilleoperation);
                return clsPhafamilleoperations;

            }

            if (string.IsNullOrEmpty(Objet.FO_LIBELLEFAMILLEOPERATION))
            {
                clsPhafamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhafamilleoperation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhafamilleoperation.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhafamilleoperation.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", FO_LIBELLEFAMILLEOPERATION";
                clsPhafamilleoperations.Add(clsPhafamilleoperation);
                return clsPhafamilleoperations;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhafamilleoperation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhafamilleoperation.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhafamilleoperation.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhafamilleoperations.Add(clsPhafamilleoperation);
            //    return clsPhafamilleoperations;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhafamilleoperation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhafamilleoperation.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhafamilleoperation.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhafamilleoperations.Add(clsPhafamilleoperation);
            //    return clsPhafamilleoperations;

            //}


            else
            {
                clsPhafamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
            clsPhafamilleoperation.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhafamilleoperation.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhafamilleoperation.clsObjetRetour.SL_MESSAGE = "";
            clsPhafamilleoperations.Add(clsPhafamilleoperation);
            return clsPhafamilleoperations;

            }


        }

        public List<HT_Stock.BOJ.clsPhafamilleoperation> TestChampObligatoireDelete(HT_Stock.BOJ.clsPhafamilleoperation Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhafamilleoperation> clsPhafamilleoperations = new List<HT_Stock.BOJ.clsPhafamilleoperation>();
            HT_Stock.BOJ.clsPhafamilleoperation clsPhafamilleoperation = new HT_Stock.BOJ.clsPhafamilleoperation();

            if (string.IsNullOrEmpty(Objet.FO_CODEFAMILLEOPERATION))
            {
                clsPhafamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhafamilleoperation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhafamilleoperation.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhafamilleoperation.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", FO_CODEFAMILLEOPERATION";
                clsPhafamilleoperations.Add(clsPhafamilleoperation);
                return clsPhafamilleoperations;

            }
            else
            {
            clsPhafamilleoperation.clsObjetRetour = new Common.clsObjetRetour();
            clsPhafamilleoperation.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhafamilleoperation.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhafamilleoperation.clsObjetRetour.SL_MESSAGE = "";
            clsPhafamilleoperations.Add(clsPhafamilleoperation);
            return clsPhafamilleoperations;

            }


        }


    }
}