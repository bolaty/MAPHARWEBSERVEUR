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
	public partial class wsCtparduree
	{

        public List<HT_Stock.BOJ.clsCtparduree> TestChampObligatoireListe(HT_Stock.BOJ.clsCtparduree Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparduree> clsCtpardurees = new List<HT_Stock.BOJ.clsCtparduree>();
            HT_Stock.BOJ.clsCtparduree clsCtparduree = new HT_Stock.BOJ.clsCtparduree();

            //if (string.IsNullOrEmpty(Objet.DU_CODEDUREE))
            //{
            //    clsCtparduree.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsCtparduree.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparduree.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsCtparduree.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DU_CODEDUREE";
            //    clsCtpardurees.Add(clsCtparduree);
            //    return clsCtpardurees;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparduree.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparduree.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparduree.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtpardurees.Add(clsCtparduree);
            //    return clsCtpardurees;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparduree.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparduree.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparduree.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtpardurees.Add(clsCtparduree);
            //    return clsCtpardurees;

            //}


            //else
            //{
                clsCtparduree.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparduree.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtparduree.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtparduree.clsObjetRetour.SL_MESSAGE = "";
                clsCtpardurees.Add(clsCtparduree);
                return clsCtpardurees;

            //}


        }

        public List<HT_Stock.BOJ.clsCtparduree> TestChampObligatoireInsert(HT_Stock.BOJ.clsCtparduree Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparduree> clsCtpardurees = new List<HT_Stock.BOJ.clsCtparduree>();
            HT_Stock.BOJ.clsCtparduree clsCtparduree = new HT_Stock.BOJ.clsCtparduree();

           

            if (string.IsNullOrEmpty(Objet.DU_LIBELLEDUREE))
            {
                clsCtparduree.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparduree.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparduree.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparduree.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DU_LIBELLEDUREE";
                clsCtpardurees.Add(clsCtparduree);
                return clsCtpardurees;

            }

            else
            {
                clsCtparduree.clsObjetRetour = new Common.clsObjetRetour();
                clsCtparduree.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtparduree.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtparduree.clsObjetRetour.SL_MESSAGE = "";
                clsCtpardurees.Add(clsCtparduree);
                return clsCtpardurees;

            }


        }

        public List<HT_Stock.BOJ.clsCtparduree> TestChampObligatoireUpdate(HT_Stock.BOJ.clsCtparduree Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparduree> clsCtpardurees = new List<HT_Stock.BOJ.clsCtparduree>();
            HT_Stock.BOJ.clsCtparduree clsCtparduree = new HT_Stock.BOJ.clsCtparduree();

            if (string.IsNullOrEmpty(Objet.DU_CODEDUREE))
            {
                clsCtparduree.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparduree.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparduree.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparduree.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DU_CODEDUREE";
                clsCtpardurees.Add(clsCtparduree);
                return clsCtpardurees;

            }

            if (string.IsNullOrEmpty(Objet.DU_LIBELLEDUREE))
            {
                clsCtparduree.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparduree.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparduree.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparduree.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DU_LIBELLEDUREE";
                clsCtpardurees.Add(clsCtparduree);
                return clsCtpardurees;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparduree.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparduree.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparduree.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtpardurees.Add(clsCtparduree);
            //    return clsCtpardurees;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtparduree.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtparduree.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtparduree.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtpardurees.Add(clsCtparduree);
            //    return clsCtpardurees;

            //}


            else
            {
                clsCtparduree.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparduree.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparduree.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparduree.clsObjetRetour.SL_MESSAGE = "";
            clsCtpardurees.Add(clsCtparduree);
            return clsCtpardurees;

            }


        }

        public List<HT_Stock.BOJ.clsCtparduree> TestChampObligatoireDelete(HT_Stock.BOJ.clsCtparduree Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtparduree> clsCtpardurees = new List<HT_Stock.BOJ.clsCtparduree>();
            HT_Stock.BOJ.clsCtparduree clsCtparduree = new HT_Stock.BOJ.clsCtparduree();

            if (string.IsNullOrEmpty(Objet.DU_CODEDUREE))
            {
                clsCtparduree.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtparduree.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtparduree.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtparduree.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DU_CODEDUREE";
                clsCtpardurees.Add(clsCtparduree);
                return clsCtpardurees;

            }
            else
            {
            clsCtparduree.clsObjetRetour = new Common.clsObjetRetour();
            clsCtparduree.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtparduree.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtparduree.clsObjetRetour.SL_MESSAGE = "";
            clsCtpardurees.Add(clsCtparduree);
            return clsCtpardurees;

            }


        }


    }
}