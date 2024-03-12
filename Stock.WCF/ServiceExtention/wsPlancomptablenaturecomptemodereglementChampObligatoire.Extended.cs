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
	public partial class wsPlancomptablenaturecomptemodereglement
	{

        public List<HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement> TestChampObligatoireListe(HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement> clsPlancomptablenaturecomptemodereglements = new List<HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement>();
            HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement clsPlancomptablenaturecomptemodereglement = new HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement();

            if (string.IsNullOrEmpty(Objet.MR_CODEMODEREGLEMENT))
            {
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MR_CODEMODEREGLEMENT";
                clsPlancomptablenaturecomptemodereglements.Add(clsPlancomptablenaturecomptemodereglement);
                return clsPlancomptablenaturecomptemodereglements;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPlancomptablenaturecomptemodereglements.Add(clsPlancomptablenaturecomptemodereglement);
            //    return clsPlancomptablenaturecomptemodereglements;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPlancomptablenaturecomptemodereglements.Add(clsPlancomptablenaturecomptemodereglement);
            //    return clsPlancomptablenaturecomptemodereglements;

            //}


            else
            {
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour = new Common.clsObjetRetour();
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_MESSAGE = "";
                clsPlancomptablenaturecomptemodereglements.Add(clsPlancomptablenaturecomptemodereglement);
                return clsPlancomptablenaturecomptemodereglements;

            }


        }

        public List<HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement> TestChampObligatoireInsert(HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement> clsPlancomptablenaturecomptemodereglements = new List<HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement>();
            HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement clsPlancomptablenaturecomptemodereglement = new HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement();

           

            if (string.IsNullOrEmpty(Objet.NC_LIBELLENATURECOMPTE))
            {
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", NC_LIBELLENATURECOMPTE";
                clsPlancomptablenaturecomptemodereglements.Add(clsPlancomptablenaturecomptemodereglement);
                return clsPlancomptablenaturecomptemodereglements;

            }

            else
            {
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour = new Common.clsObjetRetour();
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_MESSAGE = "";
                clsPlancomptablenaturecomptemodereglements.Add(clsPlancomptablenaturecomptemodereglement);
                return clsPlancomptablenaturecomptemodereglements;

            }


        }

        public List<HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement> TestChampObligatoireUpdate(HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement> clsPlancomptablenaturecomptemodereglements = new List<HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement>();
            HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement clsPlancomptablenaturecomptemodereglement = new HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement();

            if (string.IsNullOrEmpty(Objet.NC_CODENATURECOMPTE))
            {
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", NC_CODENATURECOMPTE";
                clsPlancomptablenaturecomptemodereglements.Add(clsPlancomptablenaturecomptemodereglement);
                return clsPlancomptablenaturecomptemodereglements;

            }

            if (string.IsNullOrEmpty(Objet.NC_LIBELLENATURECOMPTE))
            {
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", NC_LIBELLENATURECOMPTE";
                clsPlancomptablenaturecomptemodereglements.Add(clsPlancomptablenaturecomptemodereglement);
                return clsPlancomptablenaturecomptemodereglements;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPlancomptablenaturecomptemodereglements.Add(clsPlancomptablenaturecomptemodereglement);
            //    return clsPlancomptablenaturecomptemodereglements;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPlancomptablenaturecomptemodereglements.Add(clsPlancomptablenaturecomptemodereglement);
            //    return clsPlancomptablenaturecomptemodereglements;

            //}


            else
            {
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour = new Common.clsObjetRetour();
            clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_MESSAGE = "";
            clsPlancomptablenaturecomptemodereglements.Add(clsPlancomptablenaturecomptemodereglement);
            return clsPlancomptablenaturecomptemodereglements;

            }


        }

        public List<HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement> TestChampObligatoireDelete(HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement> clsPlancomptablenaturecomptemodereglements = new List<HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement>();
            HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement clsPlancomptablenaturecomptemodereglement = new HT_Stock.BOJ.clsPlancomptablenaturecomptemodereglement();

            if (string.IsNullOrEmpty(Objet.NC_CODENATURECOMPTE))
            {
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", NC_CODENATURECOMPTE";
                clsPlancomptablenaturecomptemodereglements.Add(clsPlancomptablenaturecomptemodereglement);
                return clsPlancomptablenaturecomptemodereglements;

            }
            else
            {
            clsPlancomptablenaturecomptemodereglement.clsObjetRetour = new Common.clsObjetRetour();
            clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPlancomptablenaturecomptemodereglement.clsObjetRetour.SL_MESSAGE = "";
            clsPlancomptablenaturecomptemodereglements.Add(clsPlancomptablenaturecomptemodereglement);
            return clsPlancomptablenaturecomptemodereglements;

            }


        }


    }
}