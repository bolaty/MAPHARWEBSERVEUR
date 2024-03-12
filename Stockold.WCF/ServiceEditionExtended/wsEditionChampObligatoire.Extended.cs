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
	public partial class wsEdition
	{

        public List<HT_Stock.BOJ.clsEdition> TestChampObligatoireListe(HT_Stock.BOJ.clsEdition Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsEdition> clsEditions = new List<HT_Stock.BOJ.clsEdition>();
            HT_Stock.BOJ.clsEdition clsEdition = new HT_Stock.BOJ.clsEdition();

            //Objet[0].EX_EXERCICE,Objet[0].SO_CODESOCIETE,Objet[0].ZN_CODEZONE, Objet[0].AG_CODEAGENCE, Objet[0].OP_CODEOPERATEUR

            if (string.IsNullOrEmpty(Objet.EX_EXERCICE))
            {
                clsEdition.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsEdition.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsEdition.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsEdition.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", EX_EXERCICE";
                clsEditions.Add(clsEdition);
                return clsEditions;

            }

            if (string.IsNullOrEmpty(Objet.SO_CODESOCIETE))
        {
            clsEdition.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsEdition.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsEdition.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsEdition.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SO_CODESOCIETE";
            clsEditions.Add(clsEdition);
            return clsEditions;

        }

            //if (string.IsNullOrEmpty(Objet.ZN_CODEZONE))
            //{
            //    clsEdition.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsEdition.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsEdition.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsEdition.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ZN_CODEZONE";
            //    clsEditions.Add(clsEdition);
            //    return clsEditions;

            //}
            if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUR))
            {
                clsEdition.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsEdition.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsEdition.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsEdition.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_CODEOPERATEUR";
                clsEditions.Add(clsEdition);
                return clsEditions;

            }            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsEdition.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsEdition.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsEdition.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsEditions.Add(clsEdition);
            //    return clsEditions;

            //}


            //else
            //{
            clsEdition.clsObjetRetour = new Common.clsObjetRetour();
                clsEdition.clsObjetRetour.SL_CODEMESSAGE = "";
                clsEdition.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsEdition.clsObjetRetour.SL_MESSAGE = "";
                clsEditions.Add(clsEdition);
                return clsEditions;

            //}


        }
        public List<HT_Stock.BOJ.clsEdition> TestChampObligatoireListePeriodicite(HT_Stock.BOJ.clsEdition Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsEdition> clsEditions = new List<HT_Stock.BOJ.clsEdition>();
            HT_Stock.BOJ.clsEdition clsEdition = new HT_Stock.BOJ.clsEdition();

            //Objet[0].EX_EXERCICE,Objet[0].SO_CODESOCIETE,Objet[0].ZN_CODEZONE, Objet[0].AG_CODEAGENCE, Objet[0].OP_CODEOPERATEUR

            if (string.IsNullOrEmpty(Objet.PE_CODEPERIODICITE))
            {
                clsEdition.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsEdition.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsEdition.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsEdition.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PE_CODEPERIODICITE";
                clsEditions.Add(clsEdition);
                return clsEditions;

            }


            //else
            //{
            clsEdition.clsObjetRetour = new Common.clsObjetRetour();
                clsEdition.clsObjetRetour.SL_CODEMESSAGE = "";
                clsEdition.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsEdition.clsObjetRetour.SL_MESSAGE = "";
                clsEditions.Add(clsEdition);
                return clsEditions;

            //}


        }

        public List<HT_Stock.BOJ.clsEdition> TestChampObligatoireListePeriodiciteDateFin(HT_Stock.BOJ.clsEdition Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsEdition> clsEditions = new List<HT_Stock.BOJ.clsEdition>();
            HT_Stock.BOJ.clsEdition clsEdition = new HT_Stock.BOJ.clsEdition();

            //Objet[0].EX_EXERCICE,Objet[0].SO_CODESOCIETE,Objet[0].ZN_CODEZONE, Objet[0].AG_CODEAGENCE, Objet[0].OP_CODEOPERATEUR

            if (string.IsNullOrEmpty(Objet.EX_EXERCICE))
            {
                clsEdition.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsEdition.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsEdition.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsEdition.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", EX_EXERCICE";
                clsEditions.Add(clsEdition);
                return clsEditions;

            }
            if (string.IsNullOrEmpty(Objet.PE_CODEPERIODICITE))
            {
                clsEdition.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsEdition.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsEdition.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsEdition.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PE_CODEPERIODICITE";
                clsEditions.Add(clsEdition);
                return clsEditions;

            }

            if (string.IsNullOrEmpty(Objet.MO_CODEMOIS))
            {
                clsEdition.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsEdition.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsEdition.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsEdition.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MO_CODEMOIS";
                clsEditions.Add(clsEdition);
                return clsEditions;

            }

            if (string.IsNullOrEmpty(Objet.JT_DATEJOURNEETRAVAIL))
            {
                clsEdition.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsEdition.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsEdition.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsEdition.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", JT_DATEJOURNEETRAVAIL";
                clsEditions.Add(clsEdition);
                return clsEditions;

            }




            else
            {
                clsEdition.clsObjetRetour = new Common.clsObjetRetour();
                clsEdition.clsObjetRetour.SL_CODEMESSAGE = "";
                clsEdition.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsEdition.clsObjetRetour.SL_MESSAGE = "";
                clsEditions.Add(clsEdition);
                return clsEditions;

            }


        }

        public List<HT_Stock.BOJ.clsEdition> TestChampObligatoireInsert(HT_Stock.BOJ.clsEdition Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsEdition> clsEditions = new List<HT_Stock.BOJ.clsEdition>();
            HT_Stock.BOJ.clsEdition clsEdition = new HT_Stock.BOJ.clsEdition();



            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsEdition.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsEdition.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsEdition.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsEdition.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsEditions.Add(clsEdition);
                return clsEditions;

            }

            else
            {
                clsEdition.clsObjetRetour = new Common.clsObjetRetour();
                clsEdition.clsObjetRetour.SL_CODEMESSAGE = "";
                clsEdition.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsEdition.clsObjetRetour.SL_MESSAGE = "";
                clsEditions.Add(clsEdition);
                return clsEditions;

            }


        }

        public List<HT_Stock.BOJ.clsEdition> TestChampObligatoireUpdate(HT_Stock.BOJ.clsEdition Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsEdition> clsEditions = new List<HT_Stock.BOJ.clsEdition>();
            HT_Stock.BOJ.clsEdition clsEdition = new HT_Stock.BOJ.clsEdition();

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsEdition.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsEdition.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsEdition.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsEdition.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsEditions.Add(clsEdition);
                return clsEditions;

            }

            //if (string.IsNullOrEmpty(Objet.ET_LIBELLEEdition))
            //{
            //    clsEdition.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsEdition.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsEdition.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsEdition.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ET_LIBELLEEdition";
            //    clsEditions.Add(clsEdition);
            //    return clsEditions;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsEdition.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsEdition.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsEdition.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsEditions.Add(clsEdition);
            //    return clsEditions;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsEdition.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsEdition.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsEdition.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsEditions.Add(clsEdition);
            //    return clsEditions;

            //}


            else
            {
                clsEdition.clsObjetRetour = new Common.clsObjetRetour();
            clsEdition.clsObjetRetour.SL_CODEMESSAGE = "";
            clsEdition.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsEdition.clsObjetRetour.SL_MESSAGE = "";
            clsEditions.Add(clsEdition);
            return clsEditions;

            }


        }

        public List<HT_Stock.BOJ.clsEdition> TestChampObligatoireDelete(HT_Stock.BOJ.clsEdition Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsEdition> clsEditions = new List<HT_Stock.BOJ.clsEdition>();
            HT_Stock.BOJ.clsEdition clsEdition = new HT_Stock.BOJ.clsEdition();

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsEdition.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsEdition.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsEdition.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsEdition.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ET_INDEX";
                clsEditions.Add(clsEdition);
                return clsEditions;

            }
            else
            {
            clsEdition.clsObjetRetour = new Common.clsObjetRetour();
            clsEdition.clsObjetRetour.SL_CODEMESSAGE = "";
            clsEdition.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsEdition.clsObjetRetour.SL_MESSAGE = "";
            clsEditions.Add(clsEdition);
            return clsEditions;

            }


        }


    }
}