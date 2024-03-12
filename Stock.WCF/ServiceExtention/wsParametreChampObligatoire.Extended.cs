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
	public partial class wsParametre
	{

        public List<HT_Stock.BOJ.clsParametre> TestChampObligatoireListe(HT_Stock.BOJ.clsParametre Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsParametre> clsParametres = new List<HT_Stock.BOJ.clsParametre>();
            HT_Stock.BOJ.clsParametre clsParametre = new HT_Stock.BOJ.clsParametre();

            //if (string.IsNullOrEmpty(Objet.PP_CODEPARAMETRE))
            //{
            //    clsParametre.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsParametre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsParametre.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsParametre.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PP_CODEPARAMETRE";
            //    clsParametres.Add(clsParametre);
            //    return clsParametres;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsParametre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsParametre.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsParametre.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsParametres.Add(clsParametre);
            //    return clsParametres;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsParametre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsParametre.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsParametre.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsParametres.Add(clsParametre);
            //    return clsParametres;

            //}


            //else
            //{
                clsParametre.clsObjetRetour = new Common.clsObjetRetour();
                clsParametre.clsObjetRetour.SL_CODEMESSAGE = "";
                clsParametre.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsParametre.clsObjetRetour.SL_MESSAGE = "";
                clsParametres.Add(clsParametre);
                return clsParametres;

            //}


        }

        public List<HT_Stock.BOJ.clsParametre> TestChampObligatoireInsert(HT_Stock.BOJ.clsParametre Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsParametre> clsParametres = new List<HT_Stock.BOJ.clsParametre>();
            HT_Stock.BOJ.clsParametre clsParametre = new HT_Stock.BOJ.clsParametre();

           
            if (string.IsNullOrEmpty(Objet.SO_CODESOCIETE))
            {
                clsParametre.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsParametre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsParametre.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsParametre.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SO_CODESOCIETE";
                clsParametres.Add(clsParametre);
                return clsParametres;

            }

            if (string.IsNullOrEmpty(Objet.PP_LIBELLE))
            {
                clsParametre.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsParametre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsParametre.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsParametre.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PP_LIBELLE";
                clsParametres.Add(clsParametre);
                return clsParametres;

            }

            else
            {
                clsParametre.clsObjetRetour = new Common.clsObjetRetour();
                clsParametre.clsObjetRetour.SL_CODEMESSAGE = "";
                clsParametre.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsParametre.clsObjetRetour.SL_MESSAGE = "";
                clsParametres.Add(clsParametre);
                return clsParametres;

            }


        }

        public List<HT_Stock.BOJ.clsParametre> TestChampObligatoireUpdate(HT_Stock.BOJ.clsParametre Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsParametre> clsParametres = new List<HT_Stock.BOJ.clsParametre>();
            HT_Stock.BOJ.clsParametre clsParametre = new HT_Stock.BOJ.clsParametre();
            if (string.IsNullOrEmpty(Objet.SO_CODESOCIETE))
            {
                clsParametre.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsParametre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsParametre.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsParametre.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SO_CODESOCIETE";
                clsParametres.Add(clsParametre);
                return clsParametres;

            }
            if (string.IsNullOrEmpty(Objet.PP_CODEPARAMETRE))
            {
                clsParametre.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsParametre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsParametre.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsParametre.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PP_CODEPARAMETRE";
                clsParametres.Add(clsParametre);
                return clsParametres;

            }

            if (string.IsNullOrEmpty(Objet.PP_LIBELLE))
            {
                clsParametre.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsParametre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsParametre.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsParametre.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PP_LIBELLE";
                clsParametres.Add(clsParametre);
                return clsParametres;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsParametre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsParametre.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsParametre.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsParametres.Add(clsParametre);
            //    return clsParametres;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsParametre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsParametre.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsParametre.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsParametres.Add(clsParametre);
            //    return clsParametres;

            //}


            else
            {
                clsParametre.clsObjetRetour = new Common.clsObjetRetour();
            clsParametre.clsObjetRetour.SL_CODEMESSAGE = "";
            clsParametre.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsParametre.clsObjetRetour.SL_MESSAGE = "";
            clsParametres.Add(clsParametre);
            return clsParametres;

            }


        }

        public List<HT_Stock.BOJ.clsParametre> TestChampObligatoireDelete(HT_Stock.BOJ.clsParametre Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsParametre> clsParametres = new List<HT_Stock.BOJ.clsParametre>();
            HT_Stock.BOJ.clsParametre clsParametre = new HT_Stock.BOJ.clsParametre();

            if (string.IsNullOrEmpty(Objet.PP_CODEPARAMETRE))
            {
                clsParametre.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsParametre.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsParametre.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsParametre.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PP_CODEPARAMETRE";
                clsParametres.Add(clsParametre);
                return clsParametres;

            }
            else
            {
            clsParametre.clsObjetRetour = new Common.clsObjetRetour();
            clsParametre.clsObjetRetour.SL_CODEMESSAGE = "";
            clsParametre.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsParametre.clsObjetRetour.SL_MESSAGE = "";
            clsParametres.Add(clsParametre);
            return clsParametres;

            }


        }


    }
}