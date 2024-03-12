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
	public partial class wsBienimmobilisefamille
	{

        public List<HT_Stock.BOJ.clsBienimmobilisefamille> TestChampObligatoireListe(HT_Stock.BOJ.clsBienimmobilisefamille Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsBienimmobilisefamille> clsBienimmobilisefamilles = new List<HT_Stock.BOJ.clsBienimmobilisefamille>();
            HT_Stock.BOJ.clsBienimmobilisefamille clsBienimmobilisefamille = new HT_Stock.BOJ.clsBienimmobilisefamille();

            if (string.IsNullOrEmpty(Objet.NT_CODENATUREBIEN))
            {
                clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", NT_CODENATUREBIEN";
                clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
                return clsBienimmobilisefamilles;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
            //    return clsBienimmobilisefamilles;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
            //    return clsBienimmobilisefamilles;

            //}


            else
            {
                clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
                clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = "";
                clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = "";
                clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
                return clsBienimmobilisefamilles;

            }


        }

        public List<HT_Stock.BOJ.clsBienimmobilisefamille> TestChampObligatoireInsert1(HT_Stock.BOJ.clsBienimmobilisefamille Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsBienimmobilisefamille> clsBienimmobilisefamilles = new List<HT_Stock.BOJ.clsBienimmobilisefamille>();
            HT_Stock.BOJ.clsBienimmobilisefamille clsBienimmobilisefamille = new HT_Stock.BOJ.clsBienimmobilisefamille();



            if (string.IsNullOrEmpty(Objet.PL_CODENUMCOMPTE))
            {
                clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PL_CODENUMCOMPTE";
                clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
                return clsBienimmobilisefamilles;

            }
            else if (string.IsNullOrEmpty(Objet.NT_CODENATUREBIEN))
            {
                clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", NT_CODENATUREBIEN";
                clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
                return clsBienimmobilisefamilles;

            }
            //else if (string.IsNullOrEmpty(Objet.PS_CODESOUSPRODUITCOMPTEAMORTISSEMENT))
            //{
            //    clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PS_CODESOUSPRODUITCOMPTEAMORTISSEMENT";
            //    clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
            //    return clsBienimmobilisefamilles;

            //}
            else if (string.IsNullOrEmpty(Objet.PS_LIBELLE))
            {
                clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PS_LIBELLE";
                clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
                return clsBienimmobilisefamilles;

            }
            else if (string.IsNullOrEmpty(Objet.PS_DUREEMINIMUM))
            {
                clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PS_DUREEMINIMUM";
                clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
                return clsBienimmobilisefamilles;

            }
            else if (string.IsNullOrEmpty(Objet.PS_DUREEMAXIMUM))
            {
                clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PS_DUREEMAXIMUM";
                clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
                return clsBienimmobilisefamilles;


            }
            else if (string.IsNullOrEmpty(Objet.PS_AMORTISSEMENTDIRECT))
            {
                clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PS_AMORTISSEMENTDIRECT";
                clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
                return clsBienimmobilisefamilles;

            }
            else if (string.IsNullOrEmpty(Objet.PS_AMORTISSEMENTBIEN))
            {
                clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PS_AMORTISSEMENTBIEN";
                clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
                return clsBienimmobilisefamilles;

            }
            else if (string.IsNullOrEmpty(Objet.PS_AMORTISSEMENTVALEURRESIDUELLEZERO))
            {
                clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PS_AMORTISSEMENTVALEURRESIDUELLEZERO";
                clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
                return clsBienimmobilisefamilles;

            }
            else if (string.IsNullOrEmpty(Objet.PS_ACTIF))
            {
                clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PS_ACTIF";
                clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
                return clsBienimmobilisefamilles;

            }
            else if (string.IsNullOrEmpty(Objet.PS_NUMEROORDRE))
            {
                clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PS_NUMEROORDRE";
                clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
                return clsBienimmobilisefamilles;


            }
            else if (string.IsNullOrEmpty(Objet.PS_DATESAISIE))
            {
                clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PS_DATESAISIE";
                clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
                return clsBienimmobilisefamilles;

            }
            else
            {
                clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
                clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = "";
                clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = "";
                clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
                return clsBienimmobilisefamilles;

            }


        }

        public List<HT_Stock.BOJ.clsBienimmobilisefamille> TestChampObligatoireUpdate1(HT_Stock.BOJ.clsBienimmobilisefamille Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsBienimmobilisefamille> clsBienimmobilisefamilles = new List<HT_Stock.BOJ.clsBienimmobilisefamille>();
            HT_Stock.BOJ.clsBienimmobilisefamille clsBienimmobilisefamille = new HT_Stock.BOJ.clsBienimmobilisefamille();

            if (string.IsNullOrEmpty(Objet.PS_CODESOUSPRODUIT))
            {
                clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PS_CODESOUSPRODUIT";
                clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
                return clsBienimmobilisefamilles;

            }
            if (string.IsNullOrEmpty(Objet.PL_CODENUMCOMPTE))
            {
                clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PL_CODENUMCOMPTE";
                clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
                return clsBienimmobilisefamilles;

            }
            else if (string.IsNullOrEmpty(Objet.NT_CODENATUREBIEN))
            {
                clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", NT_CODENATUREBIEN";
                clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
                return clsBienimmobilisefamilles;

            }
            //else if (string.IsNullOrEmpty(Objet.PS_CODESOUSPRODUITCOMPTEAMORTISSEMENT))
            //{
            //    clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PS_CODESOUSPRODUITCOMPTEAMORTISSEMENT";
            //    clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
            //    return clsBienimmobilisefamilles;

            //}
            else if (string.IsNullOrEmpty(Objet.PS_LIBELLE))
            {
                clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PS_LIBELLE";
                clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
                return clsBienimmobilisefamilles;

            }
            else if (string.IsNullOrEmpty(Objet.PS_DUREEMINIMUM))
            {
                clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PS_DUREEMINIMUM";
                clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
                return clsBienimmobilisefamilles;

            }
            else if (string.IsNullOrEmpty(Objet.PS_DUREEMAXIMUM))
            {
                clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PS_DUREEMAXIMUM";
                clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
                return clsBienimmobilisefamilles;


            }
            else if (string.IsNullOrEmpty(Objet.PS_AMORTISSEMENTDIRECT))
            {
                clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PS_AMORTISSEMENTDIRECT";
                clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
                return clsBienimmobilisefamilles;

            }
            else if (string.IsNullOrEmpty(Objet.PS_AMORTISSEMENTBIEN))
            {
                clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PS_AMORTISSEMENTBIEN";
                clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
                return clsBienimmobilisefamilles;

            }
            else if (string.IsNullOrEmpty(Objet.PS_AMORTISSEMENTVALEURRESIDUELLEZERO))
            {
                clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PS_AMORTISSEMENTVALEURRESIDUELLEZERO";
                clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
                return clsBienimmobilisefamilles;

            }
            else if (string.IsNullOrEmpty(Objet.PS_ACTIF))
            {
                clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PS_ACTIF";
                clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
                return clsBienimmobilisefamilles;

            }
            else if (string.IsNullOrEmpty(Objet.PS_NUMEROORDRE))
            {
                clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PS_NUMEROORDRE";
                clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
                return clsBienimmobilisefamilles;


            }
            else if (string.IsNullOrEmpty(Objet.PS_DATESAISIE))
            {
                clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PS_DATESAISIE";
                clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
                return clsBienimmobilisefamilles;

            }

            else
            {
                clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
                clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = "";
                clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = "";
                clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
                return clsBienimmobilisefamilles;

            }


        }

        public List<HT_Stock.BOJ.clsBienimmobilisefamille> TestChampObligatoireDelete1(HT_Stock.BOJ.clsBienimmobilisefamille Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsBienimmobilisefamille> clsBienimmobilisefamilles = new List<HT_Stock.BOJ.clsBienimmobilisefamille>();
            HT_Stock.BOJ.clsBienimmobilisefamille clsBienimmobilisefamille = new HT_Stock.BOJ.clsBienimmobilisefamille();

            if (string.IsNullOrEmpty(Objet.PS_CODESOUSPRODUIT))
            {
                clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PS_CODESOUSPRODUIT";
                clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
                return clsBienimmobilisefamilles;

            }
            else
            {
                clsBienimmobilisefamille.clsObjetRetour = new Common.clsObjetRetour();
                clsBienimmobilisefamille.clsObjetRetour.SL_CODEMESSAGE = "";
                clsBienimmobilisefamille.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsBienimmobilisefamille.clsObjetRetour.SL_MESSAGE = "";
                clsBienimmobilisefamilles.Add(clsBienimmobilisefamille);
                return clsBienimmobilisefamilles;

            }


        }
    }
}