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
	public partial class wsEtat
	{

        public List<HT_Stock.BOJ.clsEtat> TestChampObligatoireListe(HT_Stock.BOJ.clsEtat Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsEtat> clsEtats = new List<HT_Stock.BOJ.clsEtat>();
            HT_Stock.BOJ.clsEtat clsEtat = new HT_Stock.BOJ.clsEtat();

           // Objet[0].ET_NOMGROUPE, Objet[0].OP_CODEOPERATEUR, Objet[0].ET_AFFICHER, Objet[0].OD_APERCU

            if (string.IsNullOrEmpty(Objet.ET_NOMGROUPE))
            {
                clsEtat.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsEtat.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsEtat.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsEtat.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ET_NOMGROUPE";
                clsEtats.Add(clsEtat);
                return clsEtats;

            }

        if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUR))
        {
            clsEtat.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsEtat.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsEtat.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsEtat.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_CODEOPERATEUR";
            clsEtats.Add(clsEtat);
            return clsEtats;

        }
           
        if (string.IsNullOrEmpty(Objet.ET_AFFICHER))
        {
            clsEtat.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsEtat.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsEtat.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsEtat.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ET_AFFICHER";
            clsEtats.Add(clsEtat);
            return clsEtats;

        }
        if (string.IsNullOrEmpty(Objet.OD_APERCU))
        {
            clsEtat.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsEtat.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsEtat.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsEtat.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OD_APERCU";
            clsEtats.Add(clsEtat);
            return clsEtats;

        }            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsEtat.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsEtat.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsEtat.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsEtats.Add(clsEtat);
            //    return clsEtats;

            //}


            //else
            //{
            clsEtat.clsObjetRetour = new Common.clsObjetRetour();
                clsEtat.clsObjetRetour.SL_CODEMESSAGE = "";
                clsEtat.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsEtat.clsObjetRetour.SL_MESSAGE = "";
                clsEtats.Add(clsEtat);
                return clsEtats;

            //}


        }

        public List<HT_Stock.BOJ.clsEtat> TestChampObligatoireInsert(HT_Stock.BOJ.clsEtat Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsEtat> clsEtats = new List<HT_Stock.BOJ.clsEtat>();
            HT_Stock.BOJ.clsEtat clsEtat = new HT_Stock.BOJ.clsEtat();

           

            if (string.IsNullOrEmpty(Objet.ET_LIBELLEETAT))
            {
                clsEtat.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsEtat.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsEtat.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsEtat.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ET_LIBELLEETAT";
                clsEtats.Add(clsEtat);
                return clsEtats;

            }

            else
            {
                clsEtat.clsObjetRetour = new Common.clsObjetRetour();
                clsEtat.clsObjetRetour.SL_CODEMESSAGE = "";
                clsEtat.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsEtat.clsObjetRetour.SL_MESSAGE = "";
                clsEtats.Add(clsEtat);
                return clsEtats;

            }


        }

        public List<HT_Stock.BOJ.clsEtat> TestChampObligatoireUpdate(HT_Stock.BOJ.clsEtat Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsEtat> clsEtats = new List<HT_Stock.BOJ.clsEtat>();
            HT_Stock.BOJ.clsEtat clsEtat = new HT_Stock.BOJ.clsEtat();

            if (string.IsNullOrEmpty(Objet.ET_INDEX))
            {
                clsEtat.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsEtat.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsEtat.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsEtat.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ET_INDEX";
                clsEtats.Add(clsEtat);
                return clsEtats;

            }

            if (string.IsNullOrEmpty(Objet.ET_LIBELLEETAT))
            {
                clsEtat.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsEtat.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsEtat.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsEtat.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ET_LIBELLEETAT";
                clsEtats.Add(clsEtat);
                return clsEtats;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsEtat.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsEtat.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsEtat.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsEtats.Add(clsEtat);
            //    return clsEtats;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsEtat.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsEtat.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsEtat.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsEtats.Add(clsEtat);
            //    return clsEtats;

            //}


            else
            {
                clsEtat.clsObjetRetour = new Common.clsObjetRetour();
            clsEtat.clsObjetRetour.SL_CODEMESSAGE = "";
            clsEtat.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsEtat.clsObjetRetour.SL_MESSAGE = "";
            clsEtats.Add(clsEtat);
            return clsEtats;

            }


        }

        public List<HT_Stock.BOJ.clsEtat> TestChampObligatoireDelete(HT_Stock.BOJ.clsEtat Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsEtat> clsEtats = new List<HT_Stock.BOJ.clsEtat>();
            HT_Stock.BOJ.clsEtat clsEtat = new HT_Stock.BOJ.clsEtat();

            if (string.IsNullOrEmpty(Objet.ET_INDEX))
            {
                clsEtat.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsEtat.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsEtat.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsEtat.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ET_INDEX";
                clsEtats.Add(clsEtat);
                return clsEtats;

            }
            else
            {
            clsEtat.clsObjetRetour = new Common.clsObjetRetour();
            clsEtat.clsObjetRetour.SL_CODEMESSAGE = "";
            clsEtat.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsEtat.clsObjetRetour.SL_MESSAGE = "";
            clsEtats.Add(clsEtat);
            return clsEtats;

            }


        }


    }
}