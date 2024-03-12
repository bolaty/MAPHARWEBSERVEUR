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
	public partial class wsZoneauto
	{

        public List<HT_Stock.BOJ.clsZoneauto> TestChampObligatoireListe(HT_Stock.BOJ.clsZoneauto Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsZoneauto> clsZoneautos = new List<HT_Stock.BOJ.clsZoneauto>();
            HT_Stock.BOJ.clsZoneauto clsZoneauto = new HT_Stock.BOJ.clsZoneauto();

            //if (string.IsNullOrEmpty(Objet.ZA_CODEZONEAUTO))
            //{
            //    clsZoneauto.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsZoneauto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsZoneauto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsZoneauto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ZA_CODEZONEAUTO";
            //    clsZoneautos.Add(clsZoneauto);
            //    return clsZoneautos;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsZoneauto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsZoneauto.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsZoneauto.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsZoneautos.Add(clsZoneauto);
            //    return clsZoneautos;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsZoneauto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsZoneauto.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsZoneauto.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsZoneautos.Add(clsZoneauto);
            //    return clsZoneautos;

            //}


            //else
            //{
                clsZoneauto.clsObjetRetour = new Common.clsObjetRetour();
                clsZoneauto.clsObjetRetour.SL_CODEMESSAGE = "";
                clsZoneauto.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsZoneauto.clsObjetRetour.SL_MESSAGE = "";
                clsZoneautos.Add(clsZoneauto);
                return clsZoneautos;

            //}


        }

        public List<HT_Stock.BOJ.clsZoneauto> TestChampObligatoireInsert(HT_Stock.BOJ.clsZoneauto Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsZoneauto> clsZoneautos = new List<HT_Stock.BOJ.clsZoneauto>();
            HT_Stock.BOJ.clsZoneauto clsZoneauto = new HT_Stock.BOJ.clsZoneauto();

           

            if (string.IsNullOrEmpty(Objet.ZA_NOMZONEAUTO))
            {
                clsZoneauto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsZoneauto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsZoneauto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsZoneauto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ZA_NOMZONEAUTO";
                clsZoneautos.Add(clsZoneauto);
                return clsZoneautos;

            }

            else
            {
                clsZoneauto.clsObjetRetour = new Common.clsObjetRetour();
                clsZoneauto.clsObjetRetour.SL_CODEMESSAGE = "";
                clsZoneauto.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsZoneauto.clsObjetRetour.SL_MESSAGE = "";
                clsZoneautos.Add(clsZoneauto);
                return clsZoneautos;

            }


        }

        public List<HT_Stock.BOJ.clsZoneauto> TestChampObligatoireUpdate(HT_Stock.BOJ.clsZoneauto Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsZoneauto> clsZoneautos = new List<HT_Stock.BOJ.clsZoneauto>();
            HT_Stock.BOJ.clsZoneauto clsZoneauto = new HT_Stock.BOJ.clsZoneauto();

            if (string.IsNullOrEmpty(Objet.ZA_CODEZONEAUTO))
            {
                clsZoneauto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsZoneauto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsZoneauto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsZoneauto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ZA_CODEZONEAUTO";
                clsZoneautos.Add(clsZoneauto);
                return clsZoneautos;

            }

            if (string.IsNullOrEmpty(Objet.ZA_NOMZONEAUTO))
            {
                clsZoneauto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsZoneauto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsZoneauto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsZoneauto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ZA_NOMZONEAUTO";
                clsZoneautos.Add(clsZoneauto);
                return clsZoneautos;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsZoneauto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsZoneauto.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsZoneauto.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsZoneautos.Add(clsZoneauto);
            //    return clsZoneautos;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsZoneauto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsZoneauto.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsZoneauto.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsZoneautos.Add(clsZoneauto);
            //    return clsZoneautos;

            //}


            else
            {
                clsZoneauto.clsObjetRetour = new Common.clsObjetRetour();
            clsZoneauto.clsObjetRetour.SL_CODEMESSAGE = "";
            clsZoneauto.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsZoneauto.clsObjetRetour.SL_MESSAGE = "";
            clsZoneautos.Add(clsZoneauto);
            return clsZoneautos;

            }


        }

        public List<HT_Stock.BOJ.clsZoneauto> TestChampObligatoireDelete(HT_Stock.BOJ.clsZoneauto Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsZoneauto> clsZoneautos = new List<HT_Stock.BOJ.clsZoneauto>();
            HT_Stock.BOJ.clsZoneauto clsZoneauto = new HT_Stock.BOJ.clsZoneauto();

            if (string.IsNullOrEmpty(Objet.ZA_CODEZONEAUTO))
            {
                clsZoneauto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsZoneauto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsZoneauto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsZoneauto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ZA_CODEZONEAUTO";
                clsZoneautos.Add(clsZoneauto);
                return clsZoneautos;

            }
            else
            {
            clsZoneauto.clsObjetRetour = new Common.clsObjetRetour();
            clsZoneauto.clsObjetRetour.SL_CODEMESSAGE = "";
            clsZoneauto.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsZoneauto.clsObjetRetour.SL_MESSAGE = "";
            clsZoneautos.Add(clsZoneauto);
            return clsZoneautos;

            }


        }


    }
}