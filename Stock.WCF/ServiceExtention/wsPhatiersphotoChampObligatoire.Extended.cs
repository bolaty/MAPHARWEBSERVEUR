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
	public partial class wsPhatiersphoto
	{

        public List<HT_Stock.BOJ.clsPhatiersphoto> TestChampObligatoireListe(HT_Stock.BOJ.clsPhatiersphoto Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhatiersphoto> clsPhatiersphotos = new List<HT_Stock.BOJ.clsPhatiersphoto>();
            HT_Stock.BOJ.clsPhatiersphoto clsPhatiersphoto = new HT_Stock.BOJ.clsPhatiersphoto();

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsPhatiersphoto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhatiersphoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhatiersphoto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhatiersphoto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsPhatiersphotos.Add(clsPhatiersphoto);
                return clsPhatiersphotos;

            }

            if (string.IsNullOrEmpty(Objet.TI_IDTIERS))
            {
                clsPhatiersphoto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhatiersphoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhatiersphoto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhatiersphoto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TI_IDTIERS";
                clsPhatiersphotos.Add(clsPhatiersphoto);
                return clsPhatiersphotos;

            }

            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhatiersphoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhatiersphoto.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhatiersphoto.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhatiersphotos.Add(clsPhatiersphoto);
            //    return clsPhatiersphotos;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhatiersphoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhatiersphoto.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhatiersphoto.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhatiersphotos.Add(clsPhatiersphoto);
            //    return clsPhatiersphotos;

            //}


            else
            {
                clsPhatiersphoto.clsObjetRetour = new Common.clsObjetRetour();
                clsPhatiersphoto.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhatiersphoto.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhatiersphoto.clsObjetRetour.SL_MESSAGE = "";
                clsPhatiersphotos.Add(clsPhatiersphoto);
                return clsPhatiersphotos;

            }


        }

        public List<HT_Stock.BOJ.clsPhatiersphoto> TestChampObligatoireInsert(HT_Stock.BOJ.clsPhatiersphoto Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhatiersphoto> clsPhatiersphotos = new List<HT_Stock.BOJ.clsPhatiersphoto>();
            HT_Stock.BOJ.clsPhatiersphoto clsPhatiersphoto = new HT_Stock.BOJ.clsPhatiersphoto();

           

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsPhatiersphoto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhatiersphoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhatiersphoto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhatiersphoto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsPhatiersphotos.Add(clsPhatiersphoto);
                return clsPhatiersphotos;

            }

            else
            {
                clsPhatiersphoto.clsObjetRetour = new Common.clsObjetRetour();
                clsPhatiersphoto.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhatiersphoto.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhatiersphoto.clsObjetRetour.SL_MESSAGE = "";
                clsPhatiersphotos.Add(clsPhatiersphoto);
                return clsPhatiersphotos;

            }


        }

        public List<HT_Stock.BOJ.clsPhatiersphoto> TestChampObligatoireUpdate(HT_Stock.BOJ.clsPhatiersphoto Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhatiersphoto> clsPhatiersphotos = new List<HT_Stock.BOJ.clsPhatiersphoto>();
            HT_Stock.BOJ.clsPhatiersphoto clsPhatiersphoto = new HT_Stock.BOJ.clsPhatiersphoto();

            if (string.IsNullOrEmpty(Objet.TI_IDTIERS))
            {
                clsPhatiersphoto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhatiersphoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhatiersphoto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhatiersphoto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TI_IDTIERS";
                clsPhatiersphotos.Add(clsPhatiersphoto);
                return clsPhatiersphotos;

            }

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsPhatiersphoto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhatiersphoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhatiersphoto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhatiersphoto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsPhatiersphotos.Add(clsPhatiersphoto);
                return clsPhatiersphotos;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhatiersphoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhatiersphoto.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhatiersphoto.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhatiersphotos.Add(clsPhatiersphoto);
            //    return clsPhatiersphotos;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhatiersphoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhatiersphoto.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhatiersphoto.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhatiersphotos.Add(clsPhatiersphoto);
            //    return clsPhatiersphotos;

            //}


            else
            {
                clsPhatiersphoto.clsObjetRetour = new Common.clsObjetRetour();
            clsPhatiersphoto.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhatiersphoto.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhatiersphoto.clsObjetRetour.SL_MESSAGE = "";
            clsPhatiersphotos.Add(clsPhatiersphoto);
            return clsPhatiersphotos;

            }


        }

        public List<HT_Stock.BOJ.clsPhatiersphoto> TestChampObligatoireDelete(HT_Stock.BOJ.clsPhatiersphoto Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhatiersphoto> clsPhatiersphotos = new List<HT_Stock.BOJ.clsPhatiersphoto>();
            HT_Stock.BOJ.clsPhatiersphoto clsPhatiersphoto = new HT_Stock.BOJ.clsPhatiersphoto();

            if (string.IsNullOrEmpty(Objet.TI_IDTIERS))
            {
                clsPhatiersphoto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhatiersphoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhatiersphoto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhatiersphoto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TI_IDTIERS";
                clsPhatiersphotos.Add(clsPhatiersphoto);
                return clsPhatiersphotos;

            }
            else
            {
            clsPhatiersphoto.clsObjetRetour = new Common.clsObjetRetour();
            clsPhatiersphoto.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhatiersphoto.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhatiersphoto.clsObjetRetour.SL_MESSAGE = "";
            clsPhatiersphotos.Add(clsPhatiersphoto);
            return clsPhatiersphotos;

            }


        }


    }
}