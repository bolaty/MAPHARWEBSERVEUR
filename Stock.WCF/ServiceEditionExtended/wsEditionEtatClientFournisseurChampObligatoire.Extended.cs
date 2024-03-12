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
	public partial class wsEditionEtatClientFournisseur
	{

        public List<HT_Stock.BOJ.clsEditionEtatClientFournisseur> TestChampObligatoireListe(HT_Stock.BOJ.clsEditionEtatClientFournisseur Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsEditionEtatClientFournisseur> clsEditionEtatClientFournisseurs = new List<HT_Stock.BOJ.clsEditionEtatClientFournisseur>();
            HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur = new HT_Stock.BOJ.clsEditionEtatClientFournisseur();

            //Objet[0].TP_CODETYPECLIENT, Objet[0].ET_TYPEETAT


            if (string.IsNullOrEmpty(Objet.TP_CODETYPECLIENT))
        {
            clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TP_CODETYPECLIENT";
            clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
            return clsEditionEtatClientFournisseurs;

        }

        if (string.IsNullOrEmpty(Objet.ET_TYPEETAT))
        {
            clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ET_TYPEETAT";
            clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
            return clsEditionEtatClientFournisseurs;

        }
            else
            {
                clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE = "";
            clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE = "";
            clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
            return clsEditionEtatClientFournisseurs;

            }


        }

        public List<HT_Stock.BOJ.clsEditionEtatClientFournisseur> TestChampObligatoireListeEntrepot(HT_Stock.BOJ.clsEditionEtatClientFournisseur Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsEditionEtatClientFournisseur> clsEditionEtatClientFournisseurs = new List<HT_Stock.BOJ.clsEditionEtatClientFournisseur>();
            HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur = new HT_Stock.BOJ.clsEditionEtatClientFournisseur();

           

            if (string.IsNullOrEmpty(Objet.ET_TYPEETAT))
            {
                clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ET_TYPEETAT";
                clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
                return clsEditionEtatClientFournisseurs;

            }

            else
            {
                clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
                clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE = "";
                clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE = "";
                clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
                return clsEditionEtatClientFournisseurs;

            }


        }



        public List<HT_Stock.BOJ.clsEditionEtatClientFournisseur> TestChampObligatoireListeVpehicule(HT_Stock.BOJ.clsEditionEtatClientFournisseur Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsEditionEtatClientFournisseur> clsEditionEtatClientFournisseurs = new List<HT_Stock.BOJ.clsEditionEtatClientFournisseur>();
            HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur = new HT_Stock.BOJ.clsEditionEtatClientFournisseur();

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
                return clsEditionEtatClientFournisseurs;

            }

            if (string.IsNullOrEmpty(Objet.EN_CODEENTREPOT))
            {
                clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", EN_CODEENTREPOT";
                clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
                return clsEditionEtatClientFournisseurs;

            }



            if (string.IsNullOrEmpty(Objet.ET_TYPEETAT))
            {
                clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ET_TYPEETAT";
                clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
                return clsEditionEtatClientFournisseurs;

            }

            else
            {
                clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
                clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE = "";
                clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE = "";
                clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
                return clsEditionEtatClientFournisseurs;

            }


        }

        public List<HT_Stock.BOJ.clsEditionEtatClientFournisseur> TestChampObligatoireListeChauffeur(HT_Stock.BOJ.clsEditionEtatClientFournisseur Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsEditionEtatClientFournisseur> clsEditionEtatClientFournisseurs = new List<HT_Stock.BOJ.clsEditionEtatClientFournisseur>();
            HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur = new HT_Stock.BOJ.clsEditionEtatClientFournisseur();

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
                return clsEditionEtatClientFournisseurs;

            }

            if (string.IsNullOrEmpty(Objet.EN_CODEENTREPOT))
            {
                clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", EN_CODEENTREPOT";
                clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
                return clsEditionEtatClientFournisseurs;

            }

            if (string.IsNullOrEmpty(Objet.DATEFIN))
            {
                clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DATEFIN";
                clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
                return clsEditionEtatClientFournisseurs;

            }

            if (string.IsNullOrEmpty(Objet.ET_TYPEETAT))
            {
                clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ET_TYPEETAT";
                clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
                return clsEditionEtatClientFournisseurs;

            }

            else
            {
                clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
                clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE = "";
                clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE = "";
                clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
                return clsEditionEtatClientFournisseurs;

            }


        }

        public List<HT_Stock.BOJ.clsEditionEtatClientFournisseur> TestChampObligatoireListeCommerciaux(HT_Stock.BOJ.clsEditionEtatClientFournisseur Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsEditionEtatClientFournisseur> clsEditionEtatClientFournisseurs = new List<HT_Stock.BOJ.clsEditionEtatClientFournisseur>();
            HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur = new HT_Stock.BOJ.clsEditionEtatClientFournisseur();

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
                return clsEditionEtatClientFournisseurs;

            }

            if (string.IsNullOrEmpty(Objet.EN_CODEENTREPOT))
            {
                clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", EN_CODEENTREPOT";
                clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
                return clsEditionEtatClientFournisseurs;

            }

            if (string.IsNullOrEmpty(Objet.DATEFIN))
            {
                clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DATEFIN";
                clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
                return clsEditionEtatClientFournisseurs;

            }

            if (string.IsNullOrEmpty(Objet.ET_TYPEETAT))
            {
                clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ET_TYPEETAT";
                clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
                return clsEditionEtatClientFournisseurs;

            }

            else
            {
                clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
                clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE = "";
                clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE = "";
                clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
                return clsEditionEtatClientFournisseurs;

            }


        }
        public List<HT_Stock.BOJ.clsEditionEtatClientFournisseur> TestChampObligatoireUpdate(HT_Stock.BOJ.clsEditionEtatClientFournisseur Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsEditionEtatClientFournisseur> clsEditionEtatClientFournisseurs = new List<HT_Stock.BOJ.clsEditionEtatClientFournisseur>();
            HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur = new HT_Stock.BOJ.clsEditionEtatClientFournisseur();

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
                return clsEditionEtatClientFournisseurs;

            }

            




            else
            {
                clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE = "";
            clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE = "";
            clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
            return clsEditionEtatClientFournisseurs;

            }


        }

        public List<HT_Stock.BOJ.clsEditionEtatClientFournisseur> TestChampObligatoireDelete(HT_Stock.BOJ.clsEditionEtatClientFournisseur Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsEditionEtatClientFournisseur> clsEditionEtatClientFournisseurs = new List<HT_Stock.BOJ.clsEditionEtatClientFournisseur>();
            HT_Stock.BOJ.clsEditionEtatClientFournisseur clsEditionEtatClientFournisseur = new HT_Stock.BOJ.clsEditionEtatClientFournisseur();

            //if (string.IsNullOrEmpty(Objet.ET_INDEX))
            //{
            //    clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ET_INDEX";
            //    clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
            //    return clsEditionEtatClientFournisseurs;

            //}
            //else
            //{
            clsEditionEtatClientFournisseur.clsObjetRetour = new Common.clsObjetRetour();
            clsEditionEtatClientFournisseur.clsObjetRetour.SL_CODEMESSAGE = "";
            clsEditionEtatClientFournisseur.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsEditionEtatClientFournisseur.clsObjetRetour.SL_MESSAGE = "";
            clsEditionEtatClientFournisseurs.Add(clsEditionEtatClientFournisseur);
            return clsEditionEtatClientFournisseurs;

            //}


        }


    }
}