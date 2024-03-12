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
	public partial class wsLogicielobjettypeschemacomptableoperateur
	{

        public List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur> TestChampObligatoireListe(HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur> clsLogicielobjettypeschemacomptableoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur>();
            HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur clsLogicielobjettypeschemacomptableoperateur = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur();

            if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUR))
            {
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_CODEOPERATEUR";
                clsLogicielobjettypeschemacomptableoperateurs.Add(clsLogicielobjettypeschemacomptableoperateur);
                return clsLogicielobjettypeschemacomptableoperateurs;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsLogicielobjettypeschemacomptableoperateurs.Add(clsLogicielobjettypeschemacomptableoperateur);
            //    return clsLogicielobjettypeschemacomptableoperateurs;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsLogicielobjettypeschemacomptableoperateurs.Add(clsLogicielobjettypeschemacomptableoperateur);
            //    return clsLogicielobjettypeschemacomptableoperateurs;

            //}


            else
            {
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_CODEMESSAGE = "";
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_MESSAGE = "";
                clsLogicielobjettypeschemacomptableoperateurs.Add(clsLogicielobjettypeschemacomptableoperateur);
                return clsLogicielobjettypeschemacomptableoperateurs;

            }


        }

        public List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur> TestChampObligatoireInsert(HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur> clsLogicielobjettypeschemacomptableoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur>();
            HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur clsLogicielobjettypeschemacomptableoperateur = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur();

           

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsLogicielobjettypeschemacomptableoperateurs.Add(clsLogicielobjettypeschemacomptableoperateur);
                return clsLogicielobjettypeschemacomptableoperateurs;

            }

            if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUR))
            {
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_CODEOPERATEUR";
                clsLogicielobjettypeschemacomptableoperateurs.Add(clsLogicielobjettypeschemacomptableoperateur);
                return clsLogicielobjettypeschemacomptableoperateurs;

            }

            if (string.IsNullOrEmpty(Objet.COCHER))
            {
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", COCHER";
                clsLogicielobjettypeschemacomptableoperateurs.Add(clsLogicielobjettypeschemacomptableoperateur);
                return clsLogicielobjettypeschemacomptableoperateurs;

            }

        if (string.IsNullOrEmpty(Objet.NO_CODENATUREOPERATION))
        {
            clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", NO_CODENATUREOPERATION";
            clsLogicielobjettypeschemacomptableoperateurs.Add(clsLogicielobjettypeschemacomptableoperateur);
            return clsLogicielobjettypeschemacomptableoperateurs;

        }

        if (string.IsNullOrEmpty(Objet.FO_CODEFAMILLEOPERATION))
        {
            clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", FO_CODEFAMILLEOPERATION";
            clsLogicielobjettypeschemacomptableoperateurs.Add(clsLogicielobjettypeschemacomptableoperateur);
            return clsLogicielobjettypeschemacomptableoperateurs;

        }

        if (string.IsNullOrEmpty(Objet.NF_CODENATUREFAMILLEOPERATION))
        {
            clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", NF_CODENATUREFAMILLEOPERATION";
            clsLogicielobjettypeschemacomptableoperateurs.Add(clsLogicielobjettypeschemacomptableoperateur);
            return clsLogicielobjettypeschemacomptableoperateurs;

        }



            else
            {
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_CODEMESSAGE = "";
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_MESSAGE = "";
                clsLogicielobjettypeschemacomptableoperateurs.Add(clsLogicielobjettypeschemacomptableoperateur);
                return clsLogicielobjettypeschemacomptableoperateurs;

            }


        }

        public List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur> TestChampObligatoireUpdate(HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur> clsLogicielobjettypeschemacomptableoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur>();
            HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur clsLogicielobjettypeschemacomptableoperateur = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur();

            if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUR))
            {
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_CODEOPERATEUR";
                clsLogicielobjettypeschemacomptableoperateurs.Add(clsLogicielobjettypeschemacomptableoperateur);
                return clsLogicielobjettypeschemacomptableoperateurs;

            }

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsLogicielobjettypeschemacomptableoperateurs.Add(clsLogicielobjettypeschemacomptableoperateur);
                return clsLogicielobjettypeschemacomptableoperateurs;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsLogicielobjettypeschemacomptableoperateurs.Add(clsLogicielobjettypeschemacomptableoperateur);
            //    return clsLogicielobjettypeschemacomptableoperateurs;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsLogicielobjettypeschemacomptableoperateurs.Add(clsLogicielobjettypeschemacomptableoperateur);
            //    return clsLogicielobjettypeschemacomptableoperateurs;

            //}


            else
            {
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour = new Common.clsObjetRetour();
            clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_CODEMESSAGE = "";
            clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_MESSAGE = "";
            clsLogicielobjettypeschemacomptableoperateurs.Add(clsLogicielobjettypeschemacomptableoperateur);
            return clsLogicielobjettypeschemacomptableoperateurs;

            }


        }

        public List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur> TestChampObligatoireDelete(HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur> clsLogicielobjettypeschemacomptableoperateurs = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur>();
            HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur clsLogicielobjettypeschemacomptableoperateur = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableoperateur();

            if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUR))
            {
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_CODEOPERATEUR";
                clsLogicielobjettypeschemacomptableoperateurs.Add(clsLogicielobjettypeschemacomptableoperateur);
                return clsLogicielobjettypeschemacomptableoperateurs;

            }
            else
            {
            clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour = new Common.clsObjetRetour();
            clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_CODEMESSAGE = "";
            clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsLogicielobjettypeschemacomptableoperateur.clsObjetRetour.SL_MESSAGE = "";
            clsLogicielobjettypeschemacomptableoperateurs.Add(clsLogicielobjettypeschemacomptableoperateur);
            return clsLogicielobjettypeschemacomptableoperateurs;

            }


        }


    }
}