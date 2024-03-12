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
	public partial class wsCtsinistrephoto
	{

        public List<HT_Stock.BOJ.clsCtsinistrephoto> TestChampObligatoireListe(HT_Stock.BOJ.clsCtsinistrephoto Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtsinistrephoto> clsCtsinistrephotos = new List<HT_Stock.BOJ.clsCtsinistrephoto>();
            HT_Stock.BOJ.clsCtsinistrephoto clsCtsinistrephoto = new HT_Stock.BOJ.clsCtsinistrephoto();

            if (string.IsNullOrEmpty(Objet.SI_CODESINISTRE))
            {
                clsCtsinistrephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistrephoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistrephoto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistrephoto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SI_CODESINISTRE";
                clsCtsinistrephotos.Add(clsCtsinistrephoto);
                return clsCtsinistrephotos;

            }


           


            else
            {
                clsCtsinistrephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistrephoto.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtsinistrephoto.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtsinistrephoto.clsObjetRetour.SL_MESSAGE = "";
                clsCtsinistrephotos.Add(clsCtsinistrephoto);
                return clsCtsinistrephotos;

            }


        }

        public List<HT_Stock.BOJ.clsCtsinistrephoto> TestChampObligatoireInsert(HT_Stock.BOJ.clsCtsinistrephoto Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtsinistrephoto> clsCtsinistrephotos = new List<HT_Stock.BOJ.clsCtsinistrephoto>();
            HT_Stock.BOJ.clsCtsinistrephoto clsCtsinistrephoto = new HT_Stock.BOJ.clsCtsinistrephoto();

           

            if (string.IsNullOrEmpty(Objet.SI_LIBELLEPHOTO))
            {
                clsCtsinistrephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistrephoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistrephoto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistrephoto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SI_LIBELLEPHOTO";
                clsCtsinistrephotos.Add(clsCtsinistrephoto);
                return clsCtsinistrephotos;

            }

            else
            {
                clsCtsinistrephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistrephoto.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtsinistrephoto.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtsinistrephoto.clsObjetRetour.SL_MESSAGE = "";
                clsCtsinistrephotos.Add(clsCtsinistrephoto);
                return clsCtsinistrephotos;

            }


        }

        public List<HT_Stock.BOJ.clsCtsinistrephoto> TestChampObligatoireUpdate(HT_Stock.BOJ.clsCtsinistrephoto Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtsinistrephoto> clsCtsinistrephotos = new List<HT_Stock.BOJ.clsCtsinistrephoto>();
            HT_Stock.BOJ.clsCtsinistrephoto clsCtsinistrephoto = new HT_Stock.BOJ.clsCtsinistrephoto();

            if (string.IsNullOrEmpty(Objet.SI_CODESINISTRE))
            {
                clsCtsinistrephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistrephoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistrephoto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistrephoto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SI_CODESINISTRE";
                clsCtsinistrephotos.Add(clsCtsinistrephoto);
                return clsCtsinistrephotos;

            }

            if (string.IsNullOrEmpty(Objet.SI_LIBELLEPHOTO))
            {
                clsCtsinistrephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistrephoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistrephoto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistrephoto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SI_LIBELLEPHOTO";
                clsCtsinistrephotos.Add(clsCtsinistrephoto);
                return clsCtsinistrephotos;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtsinistrephoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtsinistrephoto.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtsinistrephoto.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtsinistrephotos.Add(clsCtsinistrephoto);
            //    return clsCtsinistrephotos;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtsinistrephoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtsinistrephoto.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtsinistrephoto.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtsinistrephotos.Add(clsCtsinistrephoto);
            //    return clsCtsinistrephotos;

            //}


            else
            {
                clsCtsinistrephoto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtsinistrephoto.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtsinistrephoto.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtsinistrephoto.clsObjetRetour.SL_MESSAGE = "";
            clsCtsinistrephotos.Add(clsCtsinistrephoto);
            return clsCtsinistrephotos;

            }


        }

        public List<HT_Stock.BOJ.clsCtsinistrephoto> TestChampObligatoireDelete(HT_Stock.BOJ.clsCtsinistrephoto Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtsinistrephoto> clsCtsinistrephotos = new List<HT_Stock.BOJ.clsCtsinistrephoto>();
            HT_Stock.BOJ.clsCtsinistrephoto clsCtsinistrephoto = new HT_Stock.BOJ.clsCtsinistrephoto();

            if (string.IsNullOrEmpty(Objet.SI_CODESINISTRE))
            {
                clsCtsinistrephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistrephoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistrephoto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistrephoto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SI_CODESINISTRE";
                clsCtsinistrephotos.Add(clsCtsinistrephoto);
                return clsCtsinistrephotos;

            }
            else
            {
            clsCtsinistrephoto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtsinistrephoto.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtsinistrephoto.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtsinistrephoto.clsObjetRetour.SL_MESSAGE = "";
            clsCtsinistrephotos.Add(clsCtsinistrephoto);
            return clsCtsinistrephotos;

            }


        }


    }
}