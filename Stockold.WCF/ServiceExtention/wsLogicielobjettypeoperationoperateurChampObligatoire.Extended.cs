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
	public partial class wsLogicielobjettypeoperationoperateur
	{

        public List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur> TestChampObligatoireListe(HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur> clsLogicielobjettypeoperationoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur>();
            HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur clsLogicielobjettypeoperationoperateur = new HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur();
            //Objet[0].AG_CODEAGENCE, Objet[0].NF_CODENATUREFAMILLEOPERATION,Objet[0].OP_CODEOPERATEUR}
            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsLogicielobjettypeoperationoperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsLogicielobjettypeoperationoperateurs.Add(clsLogicielobjettypeoperationoperateur);
                return clsLogicielobjettypeoperationoperateurs;

            }

        if (string.IsNullOrEmpty(Objet.NF_CODENATUREFAMILLEOPERATION))
            {
                clsLogicielobjettypeoperationoperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", NF_CODENATUREFAMILLEOPERATION";
                clsLogicielobjettypeoperationoperateurs.Add(clsLogicielobjettypeoperationoperateur);
                return clsLogicielobjettypeoperationoperateurs;

            }

        if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUR))
            {
                clsLogicielobjettypeoperationoperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_CODEOPERATEUR";
                clsLogicielobjettypeoperationoperateurs.Add(clsLogicielobjettypeoperationoperateur);
                return clsLogicielobjettypeoperationoperateurs;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsLogicielobjettypeoperationoperateurs.Add(clsLogicielobjettypeoperationoperateur);
            //    return clsLogicielobjettypeoperationoperateurs;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsLogicielobjettypeoperationoperateurs.Add(clsLogicielobjettypeoperationoperateur);
            //    return clsLogicielobjettypeoperationoperateurs;

            //}


            //else
            //{
            clsLogicielobjettypeoperationoperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_CODEMESSAGE = "";
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_MESSAGE = "";
                clsLogicielobjettypeoperationoperateurs.Add(clsLogicielobjettypeoperationoperateur);
                return clsLogicielobjettypeoperationoperateurs;

            //}


        }

        public List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur> TestChampObligatoireInsert(HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur> clsLogicielobjettypeoperationoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur>();
            HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur clsLogicielobjettypeoperationoperateur = new HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur();

           

            if (string.IsNullOrEmpty(Objet.NF_CODENATUREFAMILLEOPERATION))
            {
                clsLogicielobjettypeoperationoperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", NF_CODENATUREFAMILLEOPERATION";
                clsLogicielobjettypeoperationoperateurs.Add(clsLogicielobjettypeoperationoperateur);
                return clsLogicielobjettypeoperationoperateurs;

            }

            else
            {
                clsLogicielobjettypeoperationoperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_CODEMESSAGE = "";
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_MESSAGE = "";
                clsLogicielobjettypeoperationoperateurs.Add(clsLogicielobjettypeoperationoperateur);
                return clsLogicielobjettypeoperationoperateurs;

            }


        }

        public List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur> TestChampObligatoireUpdate(HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur> clsLogicielobjettypeoperationoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur>();
            HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur clsLogicielobjettypeoperationoperateur = new HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur();

            if (string.IsNullOrEmpty(Objet.FO_CODEFAMILLEOPERATION))
            {
                clsLogicielobjettypeoperationoperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", FO_CODEFAMILLEOPERATION";
                clsLogicielobjettypeoperationoperateurs.Add(clsLogicielobjettypeoperationoperateur);
                return clsLogicielobjettypeoperationoperateurs;

            }

            if (string.IsNullOrEmpty(Objet.NF_CODENATUREFAMILLEOPERATION))
            {
                clsLogicielobjettypeoperationoperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", NF_CODENATUREFAMILLEOPERATION";
                clsLogicielobjettypeoperationoperateurs.Add(clsLogicielobjettypeoperationoperateur);
                return clsLogicielobjettypeoperationoperateurs;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsLogicielobjettypeoperationoperateurs.Add(clsLogicielobjettypeoperationoperateur);
            //    return clsLogicielobjettypeoperationoperateurs;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsLogicielobjettypeoperationoperateurs.Add(clsLogicielobjettypeoperationoperateur);
            //    return clsLogicielobjettypeoperationoperateurs;

            //}


            else
            {
                clsLogicielobjettypeoperationoperateur.clsObjetRetour = new Common.clsObjetRetour();
            clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_CODEMESSAGE = "";
            clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_MESSAGE = "";
            clsLogicielobjettypeoperationoperateurs.Add(clsLogicielobjettypeoperationoperateur);
            return clsLogicielobjettypeoperationoperateurs;

            }


        }

        public List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur> TestChampObligatoireDelete(HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur> clsLogicielobjettypeoperationoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur>();
            HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur clsLogicielobjettypeoperationoperateur = new HT_Stock.BOJ.clsLogicielobjettypeoperationoperateur();

            if (string.IsNullOrEmpty(Objet.FO_CODEFAMILLEOPERATION))
            {
                clsLogicielobjettypeoperationoperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", FO_CODEFAMILLEOPERATION";
                clsLogicielobjettypeoperationoperateurs.Add(clsLogicielobjettypeoperationoperateur);
                return clsLogicielobjettypeoperationoperateurs;

            }
            else
            {
            clsLogicielobjettypeoperationoperateur.clsObjetRetour = new Common.clsObjetRetour();
            clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_CODEMESSAGE = "";
            clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsLogicielobjettypeoperationoperateur.clsObjetRetour.SL_MESSAGE = "";
            clsLogicielobjettypeoperationoperateurs.Add(clsLogicielobjettypeoperationoperateur);
            return clsLogicielobjettypeoperationoperateurs;

            }


        }


    }
}