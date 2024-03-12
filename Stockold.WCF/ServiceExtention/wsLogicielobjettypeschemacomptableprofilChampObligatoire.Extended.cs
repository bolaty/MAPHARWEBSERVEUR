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
	public partial class wsLogicielobjettypeschemacomptableprofil
	{

        public List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil> TestChampObligatoireListe(HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil> clsLogicielobjettypeschemacomptableprofils = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil>();
            HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil clsLogicielobjettypeschemacomptableprofil = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil();

            if (string.IsNullOrEmpty(Objet.PO_CODEPROFIL))
            {
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PO_CODEPROFIL";
                clsLogicielobjettypeschemacomptableprofils.Add(clsLogicielobjettypeschemacomptableprofil);
                return clsLogicielobjettypeschemacomptableprofils;

            }
            if (string.IsNullOrEmpty(Objet.FO_CODEFAMILLEOPERATION))
            {
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", FO_CODEFAMILLEOPERATION";
                clsLogicielobjettypeschemacomptableprofils.Add(clsLogicielobjettypeschemacomptableprofil);
                return clsLogicielobjettypeschemacomptableprofils;

            }

        if (string.IsNullOrEmpty(Objet.NF_CODENATUREFAMILLEOPERATION))
        {
            clsLogicielobjettypeschemacomptableprofil.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", NF_CODENATUREFAMILLEOPERATION";
            clsLogicielobjettypeschemacomptableprofils.Add(clsLogicielobjettypeschemacomptableprofil);
            return clsLogicielobjettypeschemacomptableprofils;

        }

        if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
        {
            clsLogicielobjettypeschemacomptableprofil.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
            clsLogicielobjettypeschemacomptableprofils.Add(clsLogicielobjettypeschemacomptableprofil);
            return clsLogicielobjettypeschemacomptableprofils;

        }
            //if (string.IsNullOrEmpty(Objet.PO_CODEPROFILEDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsLogicielobjettypeschemacomptableprofils.Add(clsLogicielobjettypeschemacomptableprofil);
            //    return clsLogicielobjettypeschemacomptableprofils;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsLogicielobjettypeschemacomptableprofils.Add(clsLogicielobjettypeschemacomptableprofil);
            //    return clsLogicielobjettypeschemacomptableprofils;

            //}


            else
            {
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_CODEMESSAGE = "";
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_MESSAGE = "";
                clsLogicielobjettypeschemacomptableprofils.Add(clsLogicielobjettypeschemacomptableprofil);
                return clsLogicielobjettypeschemacomptableprofils;

            }


        }

        public List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil> TestChampObligatoireInsert(HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil> clsLogicielobjettypeschemacomptableprofils = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil>();
            HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil clsLogicielobjettypeschemacomptableprofil = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil();

           

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsLogicielobjettypeschemacomptableprofils.Add(clsLogicielobjettypeschemacomptableprofil);
                return clsLogicielobjettypeschemacomptableprofils;

            }

            if (string.IsNullOrEmpty(Objet.PO_CODEPROFIL))
            {
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PO_CODEPROFIL";
                clsLogicielobjettypeschemacomptableprofils.Add(clsLogicielobjettypeschemacomptableprofil);
                return clsLogicielobjettypeschemacomptableprofils;

            }

            if (string.IsNullOrEmpty(Objet.COCHER))
            {
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", COCHER";
                clsLogicielobjettypeschemacomptableprofils.Add(clsLogicielobjettypeschemacomptableprofil);
                return clsLogicielobjettypeschemacomptableprofils;

            }

        if (string.IsNullOrEmpty(Objet.NO_CODENATUREOPERATION))
        {
            clsLogicielobjettypeschemacomptableprofil.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", NO_CODENATUREOPERATION";
            clsLogicielobjettypeschemacomptableprofils.Add(clsLogicielobjettypeschemacomptableprofil);
            return clsLogicielobjettypeschemacomptableprofils;

        }

        if (string.IsNullOrEmpty(Objet.FO_CODEFAMILLEOPERATION))
        {
            clsLogicielobjettypeschemacomptableprofil.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", FO_CODEFAMILLEOPERATION";
            clsLogicielobjettypeschemacomptableprofils.Add(clsLogicielobjettypeschemacomptableprofil);
            return clsLogicielobjettypeschemacomptableprofils;

        }

        if (string.IsNullOrEmpty(Objet.NF_CODENATUREFAMILLEOPERATION))
        {
            clsLogicielobjettypeschemacomptableprofil.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", NF_CODENATUREFAMILLEOPERATION";
            clsLogicielobjettypeschemacomptableprofils.Add(clsLogicielobjettypeschemacomptableprofil);
            return clsLogicielobjettypeschemacomptableprofils;

        }



            else
            {
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour = new Common.clsObjetRetour();
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_CODEMESSAGE = "";
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_MESSAGE = "";
                clsLogicielobjettypeschemacomptableprofils.Add(clsLogicielobjettypeschemacomptableprofil);
                return clsLogicielobjettypeschemacomptableprofils;

            }


        }

        public List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil> TestChampObligatoireUpdate(HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil> clsLogicielobjettypeschemacomptableprofils = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil>();
            HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil clsLogicielobjettypeschemacomptableprofil = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil();

            if (string.IsNullOrEmpty(Objet.PO_CODEPROFIL))
            {
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PO_CODEPROFIL";
                clsLogicielobjettypeschemacomptableprofils.Add(clsLogicielobjettypeschemacomptableprofil);
                return clsLogicielobjettypeschemacomptableprofils;

            }

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsLogicielobjettypeschemacomptableprofils.Add(clsLogicielobjettypeschemacomptableprofil);
                return clsLogicielobjettypeschemacomptableprofils;

            }


            //if (string.IsNullOrEmpty(Objet.PO_CODEPROFILEDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsLogicielobjettypeschemacomptableprofils.Add(clsLogicielobjettypeschemacomptableprofil);
            //    return clsLogicielobjettypeschemacomptableprofils;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsLogicielobjettypeschemacomptableprofils.Add(clsLogicielobjettypeschemacomptableprofil);
            //    return clsLogicielobjettypeschemacomptableprofils;

            //}


            else
            {
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour = new Common.clsObjetRetour();
            clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_CODEMESSAGE = "";
            clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_MESSAGE = "";
            clsLogicielobjettypeschemacomptableprofils.Add(clsLogicielobjettypeschemacomptableprofil);
            return clsLogicielobjettypeschemacomptableprofils;

            }


        }

        public List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil> TestChampObligatoireDelete(HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil> clsLogicielobjettypeschemacomptableprofils = new List<HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil>();
            HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil clsLogicielobjettypeschemacomptableprofil = new HT_Stock.BOJ.clsLogicielobjettypeschemacomptableprofil();

            if (string.IsNullOrEmpty(Objet.PO_CODEPROFIL))
            {
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PO_CODEPROFIL";
                clsLogicielobjettypeschemacomptableprofils.Add(clsLogicielobjettypeschemacomptableprofil);
                return clsLogicielobjettypeschemacomptableprofils;

            }
            else
            {
            clsLogicielobjettypeschemacomptableprofil.clsObjetRetour = new Common.clsObjetRetour();
            clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_CODEMESSAGE = "";
            clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsLogicielobjettypeschemacomptableprofil.clsObjetRetour.SL_MESSAGE = "";
            clsLogicielobjettypeschemacomptableprofils.Add(clsLogicielobjettypeschemacomptableprofil);
            return clsLogicielobjettypeschemacomptableprofils;

            }


        }


    }
}