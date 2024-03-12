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
	public partial class wsCtsinistrechequephoto
	{

        public List<HT_Stock.BOJ.clsCtsinistrechequephoto> TestChampObligatoireListe(HT_Stock.BOJ.clsCtsinistrechequephoto Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtsinistrechequephoto> clsCtsinistrechequephotos = new List<HT_Stock.BOJ.clsCtsinistrechequephoto>();
            HT_Stock.BOJ.clsCtsinistrechequephoto clsCtsinistrechequephoto = new HT_Stock.BOJ.clsCtsinistrechequephoto();

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsCtsinistrechequephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistrechequephoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistrechequephoto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistrechequephoto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsCtsinistrechequephotos.Add(clsCtsinistrechequephoto);
                return clsCtsinistrechequephotos;

            }
            if (string.IsNullOrEmpty(Objet.CH_DATESAISIECHEQUE))
            {
                clsCtsinistrechequephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistrechequephoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistrechequephoto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistrechequephoto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CH_DATESAISIECHEQUE";
                clsCtsinistrechequephotos.Add(clsCtsinistrechequephoto);
                return clsCtsinistrechequephotos;

            }

        if (string.IsNullOrEmpty(Objet.CH_IDEXCHEQUE))
        {
            clsCtsinistrechequephoto.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsCtsinistrechequephoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsCtsinistrechequephoto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsCtsinistrechequephoto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CH_IDEXCHEQUE";
            clsCtsinistrechequephotos.Add(clsCtsinistrechequephoto);
            return clsCtsinistrechequephotos;

        }
        if (string.IsNullOrEmpty(Objet.SI_CODESINISTRE))
        {
            clsCtsinistrechequephoto.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsCtsinistrechequephoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsCtsinistrechequephoto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsCtsinistrechequephoto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", SI_CODESINISTRE";
            clsCtsinistrechequephotos.Add(clsCtsinistrechequephoto);
            return clsCtsinistrechequephotos;

        }
        if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUR))
        {
            clsCtsinistrechequephoto.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsCtsinistrechequephoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsCtsinistrechequephoto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsCtsinistrechequephoto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_CODEOPERATEUR";
            clsCtsinistrechequephotos.Add(clsCtsinistrechequephoto);
            return clsCtsinistrechequephotos;

        }

            //Objet[0].AG_CODEAGENCE, Objet[0].CH_DATESAISIECHEQUE, Objet[0].CH_IDEXCHEQUE

            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtsinistrechequephoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtsinistrechequephoto.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtsinistrechequephoto.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtsinistrechequephotos.Add(clsCtsinistrechequephoto);
            //    return clsCtsinistrechequephotos;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtsinistrechequephoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtsinistrechequephoto.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtsinistrechequephoto.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtsinistrechequephotos.Add(clsCtsinistrechequephoto);
            //    return clsCtsinistrechequephotos;

            //}


            else
            {
                clsCtsinistrechequephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistrechequephoto.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtsinistrechequephoto.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtsinistrechequephoto.clsObjetRetour.SL_MESSAGE = "";
                clsCtsinistrechequephotos.Add(clsCtsinistrechequephoto);
                return clsCtsinistrechequephotos;

            }


        }

        public List<HT_Stock.BOJ.clsCtsinistrechequephoto> TestChampObligatoireInsert(HT_Stock.BOJ.clsCtsinistrechequephoto Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtsinistrechequephoto> clsCtsinistrechequephotos = new List<HT_Stock.BOJ.clsCtsinistrechequephoto>();
            HT_Stock.BOJ.clsCtsinistrechequephoto clsCtsinistrechequephoto = new HT_Stock.BOJ.clsCtsinistrechequephoto();

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsCtsinistrechequephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistrechequephoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistrechequephoto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistrechequephoto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsCtsinistrechequephotos.Add(clsCtsinistrechequephoto);
                return clsCtsinistrechequephotos;

            }

            if (string.IsNullOrEmpty(Objet.CH_DATESAISIECHEQUE))
            {
                clsCtsinistrechequephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistrechequephoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistrechequephoto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistrechequephoto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CH_DATESAISIECHEQUE";
                clsCtsinistrechequephotos.Add(clsCtsinistrechequephoto);
                return clsCtsinistrechequephotos;

            }

            if (string.IsNullOrEmpty(Objet.CH_IDEXCHEQUE))
            {
                clsCtsinistrechequephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistrechequephoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistrechequephoto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistrechequephoto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CH_IDEXCHEQUE";
                clsCtsinistrechequephotos.Add(clsCtsinistrechequephoto);
                return clsCtsinistrechequephotos;

            }

            if (string.IsNullOrEmpty(Objet.CH_LIBELLEPHOTOCHEQUE))
            {
                clsCtsinistrechequephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistrechequephoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistrechequephoto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistrechequephoto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CH_LIBELLEPHOTOCHEQUE";
                clsCtsinistrechequephotos.Add(clsCtsinistrechequephoto);
                return clsCtsinistrechequephotos;

            }

            if (string.IsNullOrEmpty(Objet.CH_CHEMINPHOTOCHEQUE))
            {
                clsCtsinistrechequephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistrechequephoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistrechequephoto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistrechequephoto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CH_CHEMINPHOTOCHEQUE";
                clsCtsinistrechequephotos.Add(clsCtsinistrechequephoto);
                return clsCtsinistrechequephotos;

            }

            else
            {
                clsCtsinistrechequephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtsinistrechequephoto.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtsinistrechequephoto.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtsinistrechequephoto.clsObjetRetour.SL_MESSAGE = "";
                clsCtsinistrechequephotos.Add(clsCtsinistrechequephoto);
                return clsCtsinistrechequephotos;

            }


        }

        public List<HT_Stock.BOJ.clsCtsinistrechequephoto> TestChampObligatoireUpdate(HT_Stock.BOJ.clsCtsinistrechequephoto Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtsinistrechequephoto> clsCtsinistrechequephotos = new List<HT_Stock.BOJ.clsCtsinistrechequephoto>();
            HT_Stock.BOJ.clsCtsinistrechequephoto clsCtsinistrechequephoto = new HT_Stock.BOJ.clsCtsinistrechequephoto();

            if (string.IsNullOrEmpty(Objet.CH_NUMSEQUENCEPHOTO))
            {
                clsCtsinistrechequephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistrechequephoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistrechequephoto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistrechequephoto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CH_NUMSEQUENCEPHOTO";
                clsCtsinistrechequephotos.Add(clsCtsinistrechequephoto);
                return clsCtsinistrechequephotos;

            }

            if (string.IsNullOrEmpty(Objet.CH_LIBELLEPHOTOCHEQUE))
            {
                clsCtsinistrechequephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistrechequephoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistrechequephoto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistrechequephoto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CH_LIBELLEPHOTOCHEQUEO";
                clsCtsinistrechequephotos.Add(clsCtsinistrechequephoto);
                return clsCtsinistrechequephotos;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtsinistrechequephoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtsinistrechequephoto.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtsinistrechequephoto.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtsinistrechequephotos.Add(clsCtsinistrechequephoto);
            //    return clsCtsinistrechequephotos;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtsinistrechequephoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtsinistrechequephoto.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtsinistrechequephoto.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtsinistrechequephotos.Add(clsCtsinistrechequephoto);
            //    return clsCtsinistrechequephotos;

            //}


            else
            {
                clsCtsinistrechequephoto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtsinistrechequephoto.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtsinistrechequephoto.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtsinistrechequephoto.clsObjetRetour.SL_MESSAGE = "";
            clsCtsinistrechequephotos.Add(clsCtsinistrechequephoto);
            return clsCtsinistrechequephotos;

            }


        }

        public List<HT_Stock.BOJ.clsCtsinistrechequephoto> TestChampObligatoireDelete(HT_Stock.BOJ.clsCtsinistrechequephoto Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtsinistrechequephoto> clsCtsinistrechequephotos = new List<HT_Stock.BOJ.clsCtsinistrechequephoto>();
            HT_Stock.BOJ.clsCtsinistrechequephoto clsCtsinistrechequephoto = new HT_Stock.BOJ.clsCtsinistrechequephoto();

            if (string.IsNullOrEmpty(Objet.CH_NUMSEQUENCEPHOTO))
            {
                clsCtsinistrechequephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtsinistrechequephoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtsinistrechequephoto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtsinistrechequephoto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CH_NUMSEQUENCEPHOTO";
                clsCtsinistrechequephotos.Add(clsCtsinistrechequephoto);
                return clsCtsinistrechequephotos;

            }
            else
            {
            clsCtsinistrechequephoto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtsinistrechequephoto.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtsinistrechequephoto.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtsinistrechequephoto.clsObjetRetour.SL_MESSAGE = "";
            clsCtsinistrechequephotos.Add(clsCtsinistrechequephoto);
            return clsCtsinistrechequephotos;

            }


        }


    }
}