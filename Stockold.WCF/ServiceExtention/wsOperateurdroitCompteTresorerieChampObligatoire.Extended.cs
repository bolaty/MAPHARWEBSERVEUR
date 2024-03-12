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
	public partial class wsOperateurdroitCompteTresorerie
	{

        public List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie> TestChampObligatoireListe(HT_Stock.BOJ.clsOperateurdroitCompteTresorerie Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie> clsOperateurdroitCompteTresoreries = new List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie>();
            HT_Stock.BOJ.clsOperateurdroitCompteTresorerie clsOperateurdroitCompteTresorerie = new HT_Stock.BOJ.clsOperateurdroitCompteTresorerie();

            if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUR))
            {
                clsOperateurdroitCompteTresorerie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_CODEOPERATEUR";
                clsOperateurdroitCompteTresoreries.Add(clsOperateurdroitCompteTresorerie);
                return clsOperateurdroitCompteTresoreries;

            }
            if (string.IsNullOrEmpty(Objet.NO_CODENATUREOPERATION))
            {
                clsOperateurdroitCompteTresorerie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", NO_CODENATUREOPERATION";
                clsOperateurdroitCompteTresoreries.Add(clsOperateurdroitCompteTresorerie);
                return clsOperateurdroitCompteTresoreries;

            }
            if (string.IsNullOrEmpty(Objet.OB_CODEOBJET))
            {
                clsOperateurdroitCompteTresorerie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OB_CODEOBJET";
                clsOperateurdroitCompteTresoreries.Add(clsOperateurdroitCompteTresorerie);
                return clsOperateurdroitCompteTresoreries;

            }



            //Objet[0].AG_CODEAGENCE, Objet[0].OP_CODEOPERATEUR, Objet[0].NO_CODENATUREOPERATION, Objet[0].OB_CODEOBJET
            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsOperateurdroitCompteTresoreries.Add(clsOperateurdroitCompteTresorerie);
            //    return clsOperateurdroitCompteTresoreries;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsOperateurdroitCompteTresoreries.Add(clsOperateurdroitCompteTresorerie);
            //    return clsOperateurdroitCompteTresoreries;

            //}


            else
            {
                clsOperateurdroitCompteTresorerie.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_CODEMESSAGE = "";
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_MESSAGE = "";
                clsOperateurdroitCompteTresoreries.Add(clsOperateurdroitCompteTresorerie);
                return clsOperateurdroitCompteTresoreries;

            }


        }

        public List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie> TestChampObligatoireInsert(HT_Stock.BOJ.clsOperateurdroitCompteTresorerie Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie> clsOperateurdroitCompteTresoreries = new List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie>();
            HT_Stock.BOJ.clsOperateurdroitCompteTresorerie clsOperateurdroitCompteTresorerie = new HT_Stock.BOJ.clsOperateurdroitCompteTresorerie();






            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsOperateurdroitCompteTresorerie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsOperateurdroitCompteTresoreries.Add(clsOperateurdroitCompteTresorerie);
                return clsOperateurdroitCompteTresoreries;

            }

            if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUR))
            {
                clsOperateurdroitCompteTresorerie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_CODEOPERATEUR";
                clsOperateurdroitCompteTresoreries.Add(clsOperateurdroitCompteTresorerie);
                return clsOperateurdroitCompteTresoreries;

            }

            if (string.IsNullOrEmpty(Objet.COCHER))
            {
                clsOperateurdroitCompteTresorerie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", COCHER";
                clsOperateurdroitCompteTresoreries.Add(clsOperateurdroitCompteTresorerie);
                return clsOperateurdroitCompteTresoreries;

            }

        if (string.IsNullOrEmpty(Objet.NO_CODENATUREOPERATION))
        {
            clsOperateurdroitCompteTresorerie.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", NO_CODENATUREOPERATION";
            clsOperateurdroitCompteTresoreries.Add(clsOperateurdroitCompteTresorerie);
            return clsOperateurdroitCompteTresoreries;

        }

        if (string.IsNullOrEmpty(Objet.OB_CODEOBJET))
        {
            clsOperateurdroitCompteTresorerie.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OB_CODEOBJET";
            clsOperateurdroitCompteTresoreries.Add(clsOperateurdroitCompteTresorerie);
            return clsOperateurdroitCompteTresoreries;

        }

        if (string.IsNullOrEmpty(Objet.PL_CODENUMCOMPTE))
        {
            clsOperateurdroitCompteTresorerie.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PL_CODENUMCOMPTE";
            clsOperateurdroitCompteTresoreries.Add(clsOperateurdroitCompteTresorerie);
            return clsOperateurdroitCompteTresoreries;

        }



            else
            {
                clsOperateurdroitCompteTresorerie.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_CODEMESSAGE = "";
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_MESSAGE = "";
                clsOperateurdroitCompteTresoreries.Add(clsOperateurdroitCompteTresorerie);
                return clsOperateurdroitCompteTresoreries;

            }


        }

        public List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie> TestChampObligatoireUpdate(HT_Stock.BOJ.clsOperateurdroitCompteTresorerie Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie> clsOperateurdroitCompteTresoreries = new List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie>();
            HT_Stock.BOJ.clsOperateurdroitCompteTresorerie clsOperateurdroitCompteTresorerie = new HT_Stock.BOJ.clsOperateurdroitCompteTresorerie();

            if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUR))
            {
                clsOperateurdroitCompteTresorerie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_CODEOPERATEUR";
                clsOperateurdroitCompteTresoreries.Add(clsOperateurdroitCompteTresorerie);
                return clsOperateurdroitCompteTresoreries;

            }

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsOperateurdroitCompteTresorerie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsOperateurdroitCompteTresoreries.Add(clsOperateurdroitCompteTresorerie);
                return clsOperateurdroitCompteTresoreries;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsOperateurdroitCompteTresoreries.Add(clsOperateurdroitCompteTresorerie);
            //    return clsOperateurdroitCompteTresoreries;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsOperateurdroitCompteTresoreries.Add(clsOperateurdroitCompteTresorerie);
            //    return clsOperateurdroitCompteTresoreries;

            //}


            else
            {
                clsOperateurdroitCompteTresorerie.clsObjetRetour = new Common.clsObjetRetour();
            clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_CODEMESSAGE = "";
            clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_MESSAGE = "";
            clsOperateurdroitCompteTresoreries.Add(clsOperateurdroitCompteTresorerie);
            return clsOperateurdroitCompteTresoreries;

            }


        }

        public List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie> TestChampObligatoireDelete(HT_Stock.BOJ.clsOperateurdroitCompteTresorerie Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie> clsOperateurdroitCompteTresoreries = new List<HT_Stock.BOJ.clsOperateurdroitCompteTresorerie>();
            HT_Stock.BOJ.clsOperateurdroitCompteTresorerie clsOperateurdroitCompteTresorerie = new HT_Stock.BOJ.clsOperateurdroitCompteTresorerie();

            if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUR))
            {
                clsOperateurdroitCompteTresorerie.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_CODEOPERATEUR";
                clsOperateurdroitCompteTresoreries.Add(clsOperateurdroitCompteTresorerie);
                return clsOperateurdroitCompteTresoreries;

            }
            else
            {
            clsOperateurdroitCompteTresorerie.clsObjetRetour = new Common.clsObjetRetour();
            clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_CODEMESSAGE = "";
            clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsOperateurdroitCompteTresorerie.clsObjetRetour.SL_MESSAGE = "";
            clsOperateurdroitCompteTresoreries.Add(clsOperateurdroitCompteTresorerie);
            return clsOperateurdroitCompteTresoreries;

            }


        }


    }
}