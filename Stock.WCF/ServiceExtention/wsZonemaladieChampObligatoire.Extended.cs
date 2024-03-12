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
	public partial class wsZonemaladie
	{

        public List<HT_Stock.BOJ.clsZonemaladie> TestChampObligatoireListe(HT_Stock.BOJ.clsZonemaladie Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsZonemaladie> clsZonemaladies = new List<HT_Stock.BOJ.clsZonemaladie>();
            HT_Stock.BOJ.clsZonemaladie clsZonemaladie = new HT_Stock.BOJ.clsZonemaladie();

            //if (string.IsNullOrEmpty(Objet.ZM_CODEZONEMALADIE))
            //{
            //    clsZonemaladie.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsZonemaladie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsZonemaladie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsZonemaladie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ZM_CODEZONEMALADIE";
            //    clsZonemaladies.Add(clsZonemaladie);
            //    return clsZonemaladies;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsZonemaladie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsZonemaladie.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsZonemaladie.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsZonemaladies.Add(clsZonemaladie);
            //    return clsZonemaladies;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsZonemaladie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsZonemaladie.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsZonemaladie.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsZonemaladies.Add(clsZonemaladie);
            //    return clsZonemaladies;

            //}


            //else
            //{
                clsZonemaladie.clsObjetRetour = new Common.clsObjetRetour();
                clsZonemaladie.clsObjetRetour.SL_CODEMESSAGE = "";
                clsZonemaladie.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsZonemaladie.clsObjetRetour.SL_MESSAGE = "";
                clsZonemaladies.Add(clsZonemaladie);
                return clsZonemaladies;

            //}


        }

        public List<HT_Stock.BOJ.clsZonemaladie> TestChampObligatoireInsert(HT_Stock.BOJ.clsZonemaladie Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsZonemaladie> clsZonemaladies = new List<HT_Stock.BOJ.clsZonemaladie>();
            HT_Stock.BOJ.clsZonemaladie clsZonemaladie = new HT_Stock.BOJ.clsZonemaladie();

           

            if (string.IsNullOrEmpty(Objet.ZM_NOMZONEMALADIE))
            {
                clsZonemaladie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsZonemaladie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsZonemaladie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsZonemaladie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ZM_NOMZONEMALADIE";
                clsZonemaladies.Add(clsZonemaladie);
                return clsZonemaladies;

            }

            else
            {
                clsZonemaladie.clsObjetRetour = new Common.clsObjetRetour();
                clsZonemaladie.clsObjetRetour.SL_CODEMESSAGE = "";
                clsZonemaladie.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsZonemaladie.clsObjetRetour.SL_MESSAGE = "";
                clsZonemaladies.Add(clsZonemaladie);
                return clsZonemaladies;

            }


        }

        public List<HT_Stock.BOJ.clsZonemaladie> TestChampObligatoireUpdate(HT_Stock.BOJ.clsZonemaladie Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsZonemaladie> clsZonemaladies = new List<HT_Stock.BOJ.clsZonemaladie>();
            HT_Stock.BOJ.clsZonemaladie clsZonemaladie = new HT_Stock.BOJ.clsZonemaladie();

            if (string.IsNullOrEmpty(Objet.ZM_CODEZONEMALADIE))
            {
                clsZonemaladie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsZonemaladie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsZonemaladie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsZonemaladie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ZM_CODEZONEMALADIE";
                clsZonemaladies.Add(clsZonemaladie);
                return clsZonemaladies;

            }

            if (string.IsNullOrEmpty(Objet.ZM_NOMZONEMALADIE))
            {
                clsZonemaladie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsZonemaladie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsZonemaladie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsZonemaladie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ZM_NOMZONEMALADIE";
                clsZonemaladies.Add(clsZonemaladie);
                return clsZonemaladies;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsZonemaladie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsZonemaladie.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsZonemaladie.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsZonemaladies.Add(clsZonemaladie);
            //    return clsZonemaladies;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsZonemaladie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsZonemaladie.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsZonemaladie.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsZonemaladies.Add(clsZonemaladie);
            //    return clsZonemaladies;

            //}


            else
            {
                clsZonemaladie.clsObjetRetour = new Common.clsObjetRetour();
            clsZonemaladie.clsObjetRetour.SL_CODEMESSAGE = "";
            clsZonemaladie.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsZonemaladie.clsObjetRetour.SL_MESSAGE = "";
            clsZonemaladies.Add(clsZonemaladie);
            return clsZonemaladies;

            }


        }

        public List<HT_Stock.BOJ.clsZonemaladie> TestChampObligatoireDelete(HT_Stock.BOJ.clsZonemaladie Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsZonemaladie> clsZonemaladies = new List<HT_Stock.BOJ.clsZonemaladie>();
            HT_Stock.BOJ.clsZonemaladie clsZonemaladie = new HT_Stock.BOJ.clsZonemaladie();

            if (string.IsNullOrEmpty(Objet.ZM_CODEZONEMALADIE))
            {
                clsZonemaladie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsZonemaladie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsZonemaladie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsZonemaladie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ZM_CODEZONEMALADIE";
                clsZonemaladies.Add(clsZonemaladie);
                return clsZonemaladies;

            }
            else
            {
            clsZonemaladie.clsObjetRetour = new Common.clsObjetRetour();
            clsZonemaladie.clsObjetRetour.SL_CODEMESSAGE = "";
            clsZonemaladie.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsZonemaladie.clsObjetRetour.SL_MESSAGE = "";
            clsZonemaladies.Add(clsZonemaladie);
            return clsZonemaladies;

            }


        }


    }
}