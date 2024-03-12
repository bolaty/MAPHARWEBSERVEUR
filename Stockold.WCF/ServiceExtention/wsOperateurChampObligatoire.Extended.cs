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
	public partial class wsOperateur
	{

        public List<HT_Stock.BOJ.clsOperateur> TestChampObligatoireListe(HT_Stock.BOJ.clsOperateur Objet)
        {
           // Objet.OP_MOTPASSE = "123";
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsOperateur> clsOperateurs = new List<HT_Stock.BOJ.clsOperateur>();
            HT_Stock.BOJ.clsOperateur clsOperateur = new HT_Stock.BOJ.clsOperateur();
            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsOperateurs.Add(clsOperateur);
                return clsOperateurs;

            }
            if (string.IsNullOrEmpty(Objet.OP_LOGIN))
            {
                clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_LOGIN";
                clsOperateurs.Add(clsOperateur);
                return clsOperateurs;

            }

            if (string.IsNullOrEmpty(Objet.OP_MOTPASSE))
            {
                clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_MOTPASSE";
                clsOperateurs.Add(clsOperateur);
                return clsOperateurs;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsOperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsOperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsOperateur.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsOperateurs.Add(clsOperateur);
            //    return clsOperateurs;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsOperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsOperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsOperateur.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsOperateurs.Add(clsOperateur);
            //    return clsOperateurs;

            //}


            else
            {
                clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateur.clsObjetRetour.SL_CODEMESSAGE = "";
                clsOperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsOperateur.clsObjetRetour.SL_MESSAGE = "";
                clsOperateurs.Add(clsOperateur);
                return clsOperateurs;

            }


        }


        public List<HT_Stock.BOJ.clsOperateur> TestChampObligatoireListe2(HT_Stock.BOJ.clsOperateur Objet)
        {
            // Objet.OP_MOTPASSE = "123";
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsOperateur> clsOperateurs = new List<HT_Stock.BOJ.clsOperateur>();
            HT_Stock.BOJ.clsOperateur clsOperateur = new HT_Stock.BOJ.clsOperateur();
            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsOperateurs.Add(clsOperateur);
                return clsOperateurs;

            }
            if (string.IsNullOrEmpty(Objet.EN_CODEENTREPOT))
            {
                clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", EN_CODEENTREPOT";
                clsOperateurs.Add(clsOperateur);
                return clsOperateurs;

            }

            //if (string.IsNullOrEmpty(Objet.OP_LOGIN))
            //{
            //    clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsOperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsOperateur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsOperateur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_LOGIN";
            //    clsOperateurs.Add(clsOperateur);
            //    return clsOperateurs;

            //}

            //if (string.IsNullOrEmpty(Objet.OP_MOTPASSE))
            //{
            //    clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsOperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsOperateur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsOperateur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_MOTPASSE";
            //    clsOperateurs.Add(clsOperateur);
            //    return clsOperateurs;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsOperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsOperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsOperateur.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsOperateurs.Add(clsOperateur);
            //    return clsOperateurs;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsOperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsOperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsOperateur.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsOperateurs.Add(clsOperateur);
            //    return clsOperateurs;

            //}


            else
            {
                clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateur.clsObjetRetour.SL_CODEMESSAGE = "";
                clsOperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsOperateur.clsObjetRetour.SL_MESSAGE = "";
                clsOperateurs.Add(clsOperateur);
                return clsOperateurs;

            }


        }
        public List<HT_Stock.BOJ.clsOperateur> TestChampObligatoireCombo(HT_Stock.BOJ.clsOperateur Objet)
        {
            // Objet.OP_MOTPASSE = "123";
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsOperateur> clsOperateurs = new List<HT_Stock.BOJ.clsOperateur>();
            HT_Stock.BOJ.clsOperateur clsOperateur = new HT_Stock.BOJ.clsOperateur();
            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsOperateurs.Add(clsOperateur);
                return clsOperateurs;

            }
           

            


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsOperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsOperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsOperateur.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsOperateurs.Add(clsOperateur);
            //    return clsOperateurs;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsOperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsOperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsOperateur.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsOperateurs.Add(clsOperateur);
            //    return clsOperateurs;

            //}


            else
            {
                clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateur.clsObjetRetour.SL_CODEMESSAGE = "";
                clsOperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsOperateur.clsObjetRetour.SL_MESSAGE = "";
                clsOperateurs.Add(clsOperateur);
                return clsOperateurs;

            }


        }
        public List<HT_Stock.BOJ.clsOperateur> TestChampObligatoireListeEntrepot(HT_Stock.BOJ.clsOperateur Objet)
        {
            // Objet.OP_MOTPASSE = "123";
            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsOperateur> clsOperateurs = new List<HT_Stock.BOJ.clsOperateur>();
            HT_Stock.BOJ.clsOperateur clsOperateur = new HT_Stock.BOJ.clsOperateur();
            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsOperateurs.Add(clsOperateur);
                return clsOperateurs;

            }
           
        if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUR))
        {
            clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsOperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsOperateur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsOperateur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_CODEOPERATEUR";
            clsOperateurs.Add(clsOperateur);
            return clsOperateurs;

        }
            


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsOperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsOperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsOperateur.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsOperateurs.Add(clsOperateur);
            //    return clsOperateurs;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsOperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsOperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsOperateur.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsOperateurs.Add(clsOperateur);
            //    return clsOperateurs;

            //}


            else
            {
                clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateur.clsObjetRetour.SL_CODEMESSAGE = "";
                clsOperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsOperateur.clsObjetRetour.SL_MESSAGE = "";
                clsOperateurs.Add(clsOperateur);
                return clsOperateurs;

            }


        }

        public List<HT_Stock.BOJ.clsOperateur> TestChampObligatoireInsert(HT_Stock.BOJ.clsOperateur Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsOperateur> clsOperateurs = new List<HT_Stock.BOJ.clsOperateur>();
            HT_Stock.BOJ.clsOperateur clsOperateur = new HT_Stock.BOJ.clsOperateur();



            if (string.IsNullOrEmpty(Objet.OP_NOMPRENOM))
            {
                clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_NOMPRENOM";
                clsOperateurs.Add(clsOperateur);
                return clsOperateurs;

            }

            else
            {
                clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateur.clsObjetRetour.SL_CODEMESSAGE = "";
                clsOperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsOperateur.clsObjetRetour.SL_MESSAGE = "";
                clsOperateurs.Add(clsOperateur);
                return clsOperateurs;

            }


        }

        public List<HT_Stock.BOJ.clsOperateur> TestChampObligatoireChangerMotDePasse(HT_Stock.BOJ.clsOperateur Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsOperateur> clsOperateurs = new List<HT_Stock.BOJ.clsOperateur>();
            HT_Stock.BOJ.clsOperateur clsOperateur = new HT_Stock.BOJ.clsOperateur();

         

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsOperateurs.Add(clsOperateur);
                return clsOperateurs;

            }
            if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUR))
            {
                clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_CODEOPERATEUR";
                clsOperateurs.Add(clsOperateur);
                return clsOperateurs;

            }
            if (string.IsNullOrEmpty(Objet.OP_MOTPASSE))
            {
                clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_MOTPASSE";
                clsOperateurs.Add(clsOperateur);
                return clsOperateurs;

            }



            else
            {
                clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateur.clsObjetRetour.SL_CODEMESSAGE = "";
                clsOperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsOperateur.clsObjetRetour.SL_MESSAGE = "";
                clsOperateurs.Add(clsOperateur);
                return clsOperateurs;

            }


        }


        public List<HT_Stock.BOJ.clsOperateur> TestChampObligatoireUpdate(HT_Stock.BOJ.clsOperateur Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsOperateur> clsOperateurs = new List<HT_Stock.BOJ.clsOperateur>();
            HT_Stock.BOJ.clsOperateur clsOperateur = new HT_Stock.BOJ.clsOperateur();

            if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUR))
            {
                clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_CODEOPERATEUR";
                clsOperateurs.Add(clsOperateur);
                return clsOperateurs;

            }

            if (string.IsNullOrEmpty(Objet.OP_NOMPRENOM))
            {
                clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_NOMPRENOM";
                clsOperateurs.Add(clsOperateur);
                return clsOperateurs;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsOperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsOperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsOperateur.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsOperateurs.Add(clsOperateur);
            //    return clsOperateurs;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsOperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsOperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsOperateur.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsOperateurs.Add(clsOperateur);
            //    return clsOperateurs;

            //}


            else
            {
                clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateur.clsObjetRetour.SL_CODEMESSAGE = "";
                clsOperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsOperateur.clsObjetRetour.SL_MESSAGE = "";
                clsOperateurs.Add(clsOperateur);
                return clsOperateurs;

            }


        }

        public List<HT_Stock.BOJ.clsOperateur> TestChampObligatoireDelete(HT_Stock.BOJ.clsOperateur Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsOperateur> clsOperateurs = new List<HT_Stock.BOJ.clsOperateur>();
            HT_Stock.BOJ.clsOperateur clsOperateur = new HT_Stock.BOJ.clsOperateur();
            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsOperateurs.Add(clsOperateur);
                return clsOperateurs;

            }
            if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUR))
            {
                clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_CODEOPERATEUR";
                clsOperateurs.Add(clsOperateur);
                return clsOperateurs;

            }
            else
            {
                clsOperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateur.clsObjetRetour.SL_CODEMESSAGE = "";
                clsOperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsOperateur.clsObjetRetour.SL_MESSAGE = "";
                clsOperateurs.Add(clsOperateur);
                return clsOperateurs;

            }


        }


    }
}