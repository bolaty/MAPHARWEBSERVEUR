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
	public partial class wsCtcontratchequephoto
	{

        public List<HT_Stock.BOJ.clsCtcontratchequephoto> TestChampObligatoireListe(HT_Stock.BOJ.clsCtcontratchequephoto Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtcontratchequephoto> clsCtcontratchequephotos = new List<HT_Stock.BOJ.clsCtcontratchequephoto>();
            HT_Stock.BOJ.clsCtcontratchequephoto clsCtcontratchequephoto = new HT_Stock.BOJ.clsCtcontratchequephoto();

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsCtcontratchequephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratchequephoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratchequephoto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratchequephoto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsCtcontratchequephotos.Add(clsCtcontratchequephoto);
                return clsCtcontratchequephotos;

            }
            if (string.IsNullOrEmpty(Objet.CH_DATESAISIECHEQUE))
            {
                clsCtcontratchequephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratchequephoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratchequephoto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratchequephoto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CH_DATESAISIECHEQUE";
                clsCtcontratchequephotos.Add(clsCtcontratchequephoto);
                return clsCtcontratchequephotos;

            }

        if (string.IsNullOrEmpty(Objet.CH_IDEXCHEQUE))
        {
            clsCtcontratchequephoto.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsCtcontratchequephoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsCtcontratchequephoto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsCtcontratchequephoto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CH_IDEXCHEQUE";
            clsCtcontratchequephotos.Add(clsCtcontratchequephoto);
            return clsCtcontratchequephotos;

        }
        if (string.IsNullOrEmpty(Objet.CA_CODECONTRAT))
        {
            clsCtcontratchequephoto.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsCtcontratchequephoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsCtcontratchequephoto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsCtcontratchequephoto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CA_CODECONTRAT";
            clsCtcontratchequephotos.Add(clsCtcontratchequephoto);
            return clsCtcontratchequephotos;

        }
        if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUR))
        {
            clsCtcontratchequephoto.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsCtcontratchequephoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsCtcontratchequephoto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsCtcontratchequephoto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_CODEOPERATEUR";
            clsCtcontratchequephotos.Add(clsCtcontratchequephoto);
            return clsCtcontratchequephotos;

        }

            //Objet[0].AG_CODEAGENCE, Objet[0].CH_DATESAISIECHEQUE, Objet[0].CH_IDEXCHEQUE

            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtcontratchequephoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtcontratchequephoto.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtcontratchequephoto.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtcontratchequephotos.Add(clsCtcontratchequephoto);
            //    return clsCtcontratchequephotos;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtcontratchequephoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtcontratchequephoto.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtcontratchequephoto.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtcontratchequephotos.Add(clsCtcontratchequephoto);
            //    return clsCtcontratchequephotos;

            //}


            else
            {
                clsCtcontratchequephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratchequephoto.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtcontratchequephoto.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtcontratchequephoto.clsObjetRetour.SL_MESSAGE = "";
                clsCtcontratchequephotos.Add(clsCtcontratchequephoto);
                return clsCtcontratchequephotos;

            }


        }

        public List<HT_Stock.BOJ.clsCtcontratchequephoto> TestChampObligatoireInsert(HT_Stock.BOJ.clsCtcontratchequephoto Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtcontratchequephoto> clsCtcontratchequephotos = new List<HT_Stock.BOJ.clsCtcontratchequephoto>();
            HT_Stock.BOJ.clsCtcontratchequephoto clsCtcontratchequephoto = new HT_Stock.BOJ.clsCtcontratchequephoto();

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsCtcontratchequephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratchequephoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratchequephoto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratchequephoto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsCtcontratchequephotos.Add(clsCtcontratchequephoto);
                return clsCtcontratchequephotos;

            }

            if (string.IsNullOrEmpty(Objet.CH_DATESAISIECHEQUE))
            {
                clsCtcontratchequephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratchequephoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratchequephoto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratchequephoto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CH_DATESAISIECHEQUE";
                clsCtcontratchequephotos.Add(clsCtcontratchequephoto);
                return clsCtcontratchequephotos;

            }

            if (string.IsNullOrEmpty(Objet.CH_IDEXCHEQUE))
            {
                clsCtcontratchequephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratchequephoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratchequephoto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratchequephoto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CH_IDEXCHEQUE";
                clsCtcontratchequephotos.Add(clsCtcontratchequephoto);
                return clsCtcontratchequephotos;

            }

            if (string.IsNullOrEmpty(Objet.CH_LIBELLEPHOTOCHEQUE))
            {
                clsCtcontratchequephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratchequephoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratchequephoto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratchequephoto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CH_LIBELLEPHOTOCHEQUE";
                clsCtcontratchequephotos.Add(clsCtcontratchequephoto);
                return clsCtcontratchequephotos;

            }

            if (string.IsNullOrEmpty(Objet.CH_CHEMINPHOTOCHEQUE))
            {
                clsCtcontratchequephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratchequephoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratchequephoto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratchequephoto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CH_CHEMINPHOTOCHEQUE";
                clsCtcontratchequephotos.Add(clsCtcontratchequephoto);
                return clsCtcontratchequephotos;

            }

            else
            {
                clsCtcontratchequephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsCtcontratchequephoto.clsObjetRetour.SL_CODEMESSAGE = "";
                clsCtcontratchequephoto.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsCtcontratchequephoto.clsObjetRetour.SL_MESSAGE = "";
                clsCtcontratchequephotos.Add(clsCtcontratchequephoto);
                return clsCtcontratchequephotos;

            }


        }

        public List<HT_Stock.BOJ.clsCtcontratchequephoto> TestChampObligatoireUpdate(HT_Stock.BOJ.clsCtcontratchequephoto Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtcontratchequephoto> clsCtcontratchequephotos = new List<HT_Stock.BOJ.clsCtcontratchequephoto>();
            HT_Stock.BOJ.clsCtcontratchequephoto clsCtcontratchequephoto = new HT_Stock.BOJ.clsCtcontratchequephoto();

            if (string.IsNullOrEmpty(Objet.CH_NUMSEQUENCEPHOTO))
            {
                clsCtcontratchequephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratchequephoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratchequephoto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratchequephoto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CH_NUMSEQUENCEPHOTO";
                clsCtcontratchequephotos.Add(clsCtcontratchequephoto);
                return clsCtcontratchequephotos;

            }

            if (string.IsNullOrEmpty(Objet.CH_LIBELLEPHOTOCHEQUE))
            {
                clsCtcontratchequephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratchequephoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratchequephoto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratchequephoto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CH_LIBELLEPHOTOCHEQUEO";
                clsCtcontratchequephotos.Add(clsCtcontratchequephoto);
                return clsCtcontratchequephotos;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtcontratchequephoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtcontratchequephoto.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtcontratchequephoto.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtcontratchequephotos.Add(clsCtcontratchequephoto);
            //    return clsCtcontratchequephotos;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsCtcontratchequephoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsCtcontratchequephoto.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsCtcontratchequephoto.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsCtcontratchequephotos.Add(clsCtcontratchequephoto);
            //    return clsCtcontratchequephotos;

            //}


            else
            {
                clsCtcontratchequephoto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontratchequephoto.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtcontratchequephoto.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtcontratchequephoto.clsObjetRetour.SL_MESSAGE = "";
            clsCtcontratchequephotos.Add(clsCtcontratchequephoto);
            return clsCtcontratchequephotos;

            }


        }

        public List<HT_Stock.BOJ.clsCtcontratchequephoto> TestChampObligatoireDelete(HT_Stock.BOJ.clsCtcontratchequephoto Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsCtcontratchequephoto> clsCtcontratchequephotos = new List<HT_Stock.BOJ.clsCtcontratchequephoto>();
            HT_Stock.BOJ.clsCtcontratchequephoto clsCtcontratchequephoto = new HT_Stock.BOJ.clsCtcontratchequephoto();

            if (string.IsNullOrEmpty(Objet.CH_NUMSEQUENCEPHOTO))
            {
                clsCtcontratchequephoto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsCtcontratchequephoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsCtcontratchequephoto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsCtcontratchequephoto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CH_NUMSEQUENCEPHOTO";
                clsCtcontratchequephotos.Add(clsCtcontratchequephoto);
                return clsCtcontratchequephotos;

            }
            else
            {
            clsCtcontratchequephoto.clsObjetRetour = new Common.clsObjetRetour();
            clsCtcontratchequephoto.clsObjetRetour.SL_CODEMESSAGE = "";
            clsCtcontratchequephoto.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsCtcontratchequephoto.clsObjetRetour.SL_MESSAGE = "";
            clsCtcontratchequephotos.Add(clsCtcontratchequephoto);
            return clsCtcontratchequephotos;

            }


        }


    }
}