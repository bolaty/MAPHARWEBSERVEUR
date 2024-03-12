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
	public partial class wsCtpartypeoccupant
	{

        public List<HT_Stock.BOJ.clsCtpartypeoccupant> TestChampObligatoireListe(HT_Stock.BOJ.clsCtpartypeoccupant Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtpartypeoccupant> clsCtpartypeoccupants = new List<HT_Stock.BOJ.clsCtpartypeoccupant>();
            HT_Stock.BOJ.clsCtpartypeoccupant clsCtpartypeoccupant = new HT_Stock.BOJ.clsCtpartypeoccupant();

            //if (string.IsNullOrEmpty(Objet.OC_CODETYPEOCCUPANT))
            //{
            //    clsCtpartypeoccupant.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsCtpartypeoccupant.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtpartypeoccupant.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsCtpartypeoccupant.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OC_CODETYPEOCCUPANT";
            //    clsCtpartypeoccupants.Add(clsCtpartypeoccupant);
            //    return clsCtpartypeoccupants;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtpartypeoccupant.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtpartypeoccupant.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtpartypeoccupant.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtpartypeoccupants.Add(clsCtpartypeoccupant);
            //    return clsCtpartypeoccupants;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtpartypeoccupant.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtpartypeoccupant.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtpartypeoccupant.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtpartypeoccupants.Add(clsCtpartypeoccupant);
            //    return clsCtpartypeoccupants;

            //}


            //else
            //{
                clsCtpartypeoccupant.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpartypeoccupant.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtpartypeoccupant.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtpartypeoccupant.clsObjetRetour.SL_MESSAGE = "";
                clsCtpartypeoccupants.Add(clsCtpartypeoccupant);
                return clsCtpartypeoccupants;

            //}


        }

        public List<HT_Stock.BOJ.clsCtpartypeoccupant> TestChampObligatoireInsert(HT_Stock.BOJ.clsCtpartypeoccupant Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtpartypeoccupant> clsCtpartypeoccupants = new List<HT_Stock.BOJ.clsCtpartypeoccupant>();
            HT_Stock.BOJ.clsCtpartypeoccupant clsCtpartypeoccupant = new HT_Stock.BOJ.clsCtpartypeoccupant();

           

            if (string.IsNullOrEmpty(Objet.OC_LIBLLETYPEOCCUPANT))
            {
                clsCtpartypeoccupant.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtpartypeoccupant.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtpartypeoccupant.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtpartypeoccupant.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OC_LIBLLETYPEOCCUPANT";
                clsCtpartypeoccupants.Add(clsCtpartypeoccupant);
                return clsCtpartypeoccupants;

            }

            else
            {
                clsCtpartypeoccupant.clsObjetRetour = new Common.clsObjetRetour();
                clsCtpartypeoccupant.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtpartypeoccupant.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtpartypeoccupant.clsObjetRetour.SL_MESSAGE = "";
                clsCtpartypeoccupants.Add(clsCtpartypeoccupant);
                return clsCtpartypeoccupants;

            }


        }

        public List<HT_Stock.BOJ.clsCtpartypeoccupant> TestChampObligatoireUpdate(HT_Stock.BOJ.clsCtpartypeoccupant Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtpartypeoccupant> clsCtpartypeoccupants = new List<HT_Stock.BOJ.clsCtpartypeoccupant>();
            HT_Stock.BOJ.clsCtpartypeoccupant clsCtpartypeoccupant = new HT_Stock.BOJ.clsCtpartypeoccupant();

            if (string.IsNullOrEmpty(Objet.OC_CODETYPEOCCUPANT))
            {
                clsCtpartypeoccupant.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtpartypeoccupant.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtpartypeoccupant.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtpartypeoccupant.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OC_CODETYPEOCCUPANT";
                clsCtpartypeoccupants.Add(clsCtpartypeoccupant);
                return clsCtpartypeoccupants;

            }

            if (string.IsNullOrEmpty(Objet.OC_LIBLLETYPEOCCUPANT))
            {
                clsCtpartypeoccupant.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtpartypeoccupant.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtpartypeoccupant.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtpartypeoccupant.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OC_LIBLLETYPEOCCUPANT";
                clsCtpartypeoccupants.Add(clsCtpartypeoccupant);
                return clsCtpartypeoccupants;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtpartypeoccupant.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtpartypeoccupant.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtpartypeoccupant.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtpartypeoccupants.Add(clsCtpartypeoccupant);
            //    return clsCtpartypeoccupants;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtpartypeoccupant.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtpartypeoccupant.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtpartypeoccupant.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtpartypeoccupants.Add(clsCtpartypeoccupant);
            //    return clsCtpartypeoccupants;

            //}


            else
            {
                clsCtpartypeoccupant.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpartypeoccupant.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtpartypeoccupant.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtpartypeoccupant.clsObjetRetour.SL_MESSAGE = "";
            clsCtpartypeoccupants.Add(clsCtpartypeoccupant);
            return clsCtpartypeoccupants;

            }


        }

        public List<HT_Stock.BOJ.clsCtpartypeoccupant> TestChampObligatoireDelete(HT_Stock.BOJ.clsCtpartypeoccupant Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtpartypeoccupant> clsCtpartypeoccupants = new List<HT_Stock.BOJ.clsCtpartypeoccupant>();
            HT_Stock.BOJ.clsCtpartypeoccupant clsCtpartypeoccupant = new HT_Stock.BOJ.clsCtpartypeoccupant();

            if (string.IsNullOrEmpty(Objet.OC_CODETYPEOCCUPANT))
            {
                clsCtpartypeoccupant.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtpartypeoccupant.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtpartypeoccupant.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtpartypeoccupant.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OC_CODETYPEOCCUPANT";
                clsCtpartypeoccupants.Add(clsCtpartypeoccupant);
                return clsCtpartypeoccupants;

            }
            else
            {
            clsCtpartypeoccupant.clsObjetRetour = new Common.clsObjetRetour();
            clsCtpartypeoccupant.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtpartypeoccupant.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtpartypeoccupant.clsObjetRetour.SL_MESSAGE = "";
            clsCtpartypeoccupants.Add(clsCtpartypeoccupant);
            return clsCtpartypeoccupants;

            }


        }


    }
}