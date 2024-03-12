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
	public partial class wsTypeoperateur
	{

        public List<HT_Stock.BOJ.clsTypeoperateur> TestChampObligatoireListe(HT_Stock.BOJ.clsTypeoperateur Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsTypeoperateur> clsTypeoperateurs = new List<HT_Stock.BOJ.clsTypeoperateur>();
            HT_Stock.BOJ.clsTypeoperateur clsTypeoperateur = new HT_Stock.BOJ.clsTypeoperateur();

            //if (string.IsNullOrEmpty(Objet.TO_CODETYPEOERATEUR))
            //{
            //    clsTypeoperateur.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsTypeoperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsTypeoperateur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsTypeoperateur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TO_CODETYPEOERATEUR";
            //    clsTypeoperateurs.Add(clsTypeoperateur);
            //    return clsTypeoperateurs;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsTypeoperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsTypeoperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsTypeoperateur.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsTypeoperateurs.Add(clsTypeoperateur);
            //    return clsTypeoperateurs;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsTypeoperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsTypeoperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsTypeoperateur.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsTypeoperateurs.Add(clsTypeoperateur);
            //    return clsTypeoperateurs;

            //}


            //else
            //{
                clsTypeoperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsTypeoperateur.clsObjetRetour.SL_CODEMESSAGE = "";
                clsTypeoperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsTypeoperateur.clsObjetRetour.SL_MESSAGE = "";
                clsTypeoperateurs.Add(clsTypeoperateur);
                return clsTypeoperateurs;

            //}


        }

        public List<HT_Stock.BOJ.clsTypeoperateur> TestChampObligatoireInsert(HT_Stock.BOJ.clsTypeoperateur Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsTypeoperateur> clsTypeoperateurs = new List<HT_Stock.BOJ.clsTypeoperateur>();
            HT_Stock.BOJ.clsTypeoperateur clsTypeoperateur = new HT_Stock.BOJ.clsTypeoperateur();

           

            if (string.IsNullOrEmpty(Objet.TO_LIBELLE))
            {
                clsTypeoperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsTypeoperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsTypeoperateur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsTypeoperateur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TO_LIBELLE";
                clsTypeoperateurs.Add(clsTypeoperateur);
                return clsTypeoperateurs;

            }

            else
            {
                clsTypeoperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsTypeoperateur.clsObjetRetour.SL_CODEMESSAGE = "";
                clsTypeoperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsTypeoperateur.clsObjetRetour.SL_MESSAGE = "";
                clsTypeoperateurs.Add(clsTypeoperateur);
                return clsTypeoperateurs;

            }


        }

        public List<HT_Stock.BOJ.clsTypeoperateur> TestChampObligatoireUpdate(HT_Stock.BOJ.clsTypeoperateur Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsTypeoperateur> clsTypeoperateurs = new List<HT_Stock.BOJ.clsTypeoperateur>();
            HT_Stock.BOJ.clsTypeoperateur clsTypeoperateur = new HT_Stock.BOJ.clsTypeoperateur();

            if (string.IsNullOrEmpty(Objet.TO_CODETYPEOERATEUR))
            {
                clsTypeoperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsTypeoperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsTypeoperateur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsTypeoperateur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TO_CODETYPEOERATEUR";
                clsTypeoperateurs.Add(clsTypeoperateur);
                return clsTypeoperateurs;

            }

            if (string.IsNullOrEmpty(Objet.TO_LIBELLE))
            {
                clsTypeoperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsTypeoperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsTypeoperateur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsTypeoperateur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TO_LIBELLE";
                clsTypeoperateurs.Add(clsTypeoperateur);
                return clsTypeoperateurs;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsTypeoperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsTypeoperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsTypeoperateur.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsTypeoperateurs.Add(clsTypeoperateur);
            //    return clsTypeoperateurs;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsTypeoperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsTypeoperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsTypeoperateur.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsTypeoperateurs.Add(clsTypeoperateur);
            //    return clsTypeoperateurs;

            //}


            else
            {
                clsTypeoperateur.clsObjetRetour = new Common.clsObjetRetour();
            clsTypeoperateur.clsObjetRetour.SL_CODEMESSAGE = "";
            clsTypeoperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsTypeoperateur.clsObjetRetour.SL_MESSAGE = "";
            clsTypeoperateurs.Add(clsTypeoperateur);
            return clsTypeoperateurs;

            }


        }

        public List<HT_Stock.BOJ.clsTypeoperateur> TestChampObligatoireDelete(HT_Stock.BOJ.clsTypeoperateur Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsTypeoperateur> clsTypeoperateurs = new List<HT_Stock.BOJ.clsTypeoperateur>();
            HT_Stock.BOJ.clsTypeoperateur clsTypeoperateur = new HT_Stock.BOJ.clsTypeoperateur();

            if (string.IsNullOrEmpty(Objet.TO_CODETYPEOERATEUR))
            {
                clsTypeoperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsTypeoperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsTypeoperateur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsTypeoperateur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TO_CODETYPEOERATEUR";
                clsTypeoperateurs.Add(clsTypeoperateur);
                return clsTypeoperateurs;

            }
            else
            {
            clsTypeoperateur.clsObjetRetour = new Common.clsObjetRetour();
            clsTypeoperateur.clsObjetRetour.SL_CODEMESSAGE = "";
            clsTypeoperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsTypeoperateur.clsObjetRetour.SL_MESSAGE = "";
            clsTypeoperateurs.Add(clsTypeoperateur);
            return clsTypeoperateurs;

            }


        }


    }
}