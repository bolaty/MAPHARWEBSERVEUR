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
	public partial class wsOperateurdroit
	{

        public List<HT_Stock.BOJ.clsOperateurdroit> TestChampObligatoireListe(HT_Stock.BOJ.clsOperateurdroit Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsOperateurdroit> clsOperateurdroits = new List<HT_Stock.BOJ.clsOperateurdroit>();
            HT_Stock.BOJ.clsOperateurdroit clsOperateurdroit = new HT_Stock.BOJ.clsOperateurdroit();

            //Objet[0].AG_CODEAGENCE,Objet[0].OP_CODEOPERATEUR,Objet[0].OB_CODEOBJET ,Objet[0].LO_CODELOGICIEL  ,Objet[0].OB_RATTACHEA

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsOperateurdroit.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateurdroit.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateurdroit.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateurdroit.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsOperateurdroits.Add(clsOperateurdroit);
                return clsOperateurdroits;

            }
            if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUR))
            {
                clsOperateurdroit.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateurdroit.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateurdroit.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateurdroit.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_CODEOPERATEUR";
                clsOperateurdroits.Add(clsOperateurdroit);
                return clsOperateurdroits;

            }
            if (string.IsNullOrEmpty(Objet.OB_CODEOBJET))
            {
                clsOperateurdroit.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateurdroit.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateurdroit.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateurdroit.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OB_CODEOBJET";
                clsOperateurdroits.Add(clsOperateurdroit);
                return clsOperateurdroits;

            }
            if (string.IsNullOrEmpty(Objet.LO_CODELOGICIEL))
            {
                clsOperateurdroit.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateurdroit.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateurdroit.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateurdroit.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", LO_CODELOGICIEL";
                clsOperateurdroits.Add(clsOperateurdroit);
                return clsOperateurdroits;

            }            

            if (string.IsNullOrEmpty(Objet.OB_RATTACHEA) &&  Objet.OB_CODEOBJET != "5")
            {
                clsOperateurdroit.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateurdroit.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateurdroit.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateurdroit.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OB_RATTACHEA";
                clsOperateurdroits.Add(clsOperateurdroit);
                return clsOperateurdroits;

            }



            else
            {
                clsOperateurdroit.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroit.clsObjetRetour.SL_CODEMESSAGE = "";
                clsOperateurdroit.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsOperateurdroit.clsObjetRetour.SL_MESSAGE = "";
                clsOperateurdroits.Add(clsOperateurdroit);
                return clsOperateurdroits;

            }


        }


        public List<HT_Stock.BOJ.clsOperateurdroit> TestChampObligatoireListeOperateurDroit(HT_Stock.BOJ.clsOperateurdroit Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsOperateurdroit> clsOperateurdroits = new List<HT_Stock.BOJ.clsOperateurdroit>();
            HT_Stock.BOJ.clsOperateurdroit clsOperateurdroit = new HT_Stock.BOJ.clsOperateurdroit();

            //Objet[0].AG_CODEAGENCE,Objet[0].OP_CODEOPERATEUR,Objet[0].OB_CODEOBJET ,Objet[0].LO_CODELOGICIEL  ,Objet[0].OB_RATTACHEA

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsOperateurdroit.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateurdroit.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateurdroit.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateurdroit.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsOperateurdroits.Add(clsOperateurdroit);
                return clsOperateurdroits;

            }
            if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUR))
            {
                clsOperateurdroit.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateurdroit.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateurdroit.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateurdroit.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_CODEOPERATEUR";
                clsOperateurdroits.Add(clsOperateurdroit);
                return clsOperateurdroits;

            }
            //if (string.IsNullOrEmpty(Objet.OB_CODEOBJET))
            //{
            //    clsOperateurdroit.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsOperateurdroit.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsOperateurdroit.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsOperateurdroit.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OB_CODEOBJET";
            //    clsOperateurdroits.Add(clsOperateurdroit);
            //    return clsOperateurdroits;

            //}
            if (string.IsNullOrEmpty(Objet.LO_CODELOGICIEL))
            {
                clsOperateurdroit.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateurdroit.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateurdroit.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateurdroit.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", LO_CODELOGICIEL";
                clsOperateurdroits.Add(clsOperateurdroit);
                return clsOperateurdroits;

            }

            //if (string.IsNullOrEmpty(Objet.OB_RATTACHEA) && Objet.OB_CODEOBJET != "5")
            //{
            //    clsOperateurdroit.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsOperateurdroit.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsOperateurdroit.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsOperateurdroit.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OB_RATTACHEA";
            //    clsOperateurdroits.Add(clsOperateurdroit);
            //    return clsOperateurdroits;

            //}



            else
            {
                clsOperateurdroit.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroit.clsObjetRetour.SL_CODEMESSAGE = "";
                clsOperateurdroit.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsOperateurdroit.clsObjetRetour.SL_MESSAGE = "";
                clsOperateurdroits.Add(clsOperateurdroit);
                return clsOperateurdroits;

            }


        }



        public List<HT_Stock.BOJ.clsOperateurdroit> TestChampObligatoireInsert(HT_Stock.BOJ.clsOperateurdroit Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsOperateurdroit> clsOperateurdroits = new List<HT_Stock.BOJ.clsOperateurdroit>();
            HT_Stock.BOJ.clsOperateurdroit clsOperateurdroit = new HT_Stock.BOJ.clsOperateurdroit();

           

            if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUR))
            {
                clsOperateurdroit.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateurdroit.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateurdroit.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateurdroit.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_CODEOPERATEUR";
                clsOperateurdroits.Add(clsOperateurdroit);
                return clsOperateurdroits;

            }

            else
            {
                clsOperateurdroit.clsObjetRetour = new Common.clsObjetRetour();
                clsOperateurdroit.clsObjetRetour.SL_CODEMESSAGE = "";
                clsOperateurdroit.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsOperateurdroit.clsObjetRetour.SL_MESSAGE = "";
                clsOperateurdroits.Add(clsOperateurdroit);
                return clsOperateurdroits;

            }


        }

        public List<HT_Stock.BOJ.clsOperateurdroit> TestChampObligatoireUpdate(HT_Stock.BOJ.clsOperateurdroit Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsOperateurdroit> clsOperateurdroits = new List<HT_Stock.BOJ.clsOperateurdroit>();
            HT_Stock.BOJ.clsOperateurdroit clsOperateurdroit = new HT_Stock.BOJ.clsOperateurdroit();

            if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUR))
            {
                clsOperateurdroit.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateurdroit.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateurdroit.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateurdroit.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_CODEOPERATEUR";
                clsOperateurdroits.Add(clsOperateurdroit);
                return clsOperateurdroits;

            }

            if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUR))
            {
                clsOperateurdroit.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateurdroit.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateurdroit.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateurdroit.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_CODEOPERATEUR";
                clsOperateurdroits.Add(clsOperateurdroit);
                return clsOperateurdroits;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsOperateurdroit.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsOperateurdroit.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsOperateurdroit.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsOperateurdroits.Add(clsOperateurdroit);
            //    return clsOperateurdroits;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsOperateurdroit.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsOperateurdroit.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsOperateurdroit.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsOperateurdroits.Add(clsOperateurdroit);
            //    return clsOperateurdroits;

            //}


            else
            {
                clsOperateurdroit.clsObjetRetour = new Common.clsObjetRetour();
            clsOperateurdroit.clsObjetRetour.SL_CODEMESSAGE = "";
            clsOperateurdroit.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsOperateurdroit.clsObjetRetour.SL_MESSAGE = "";
            clsOperateurdroits.Add(clsOperateurdroit);
            return clsOperateurdroits;

            }


        }

        public List<HT_Stock.BOJ.clsOperateurdroit> TestChampObligatoireDelete(HT_Stock.BOJ.clsOperateurdroit Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsOperateurdroit> clsOperateurdroits = new List<HT_Stock.BOJ.clsOperateurdroit>();
            HT_Stock.BOJ.clsOperateurdroit clsOperateurdroit = new HT_Stock.BOJ.clsOperateurdroit();

            if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUR))
            {
                clsOperateurdroit.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOperateurdroit.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOperateurdroit.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOperateurdroit.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_CODEOPERATEUR";
                clsOperateurdroits.Add(clsOperateurdroit);
                return clsOperateurdroits;

            }
            else
            {
            clsOperateurdroit.clsObjetRetour = new Common.clsObjetRetour();
            clsOperateurdroit.clsObjetRetour.SL_CODEMESSAGE = "";
            clsOperateurdroit.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsOperateurdroit.clsObjetRetour.SL_MESSAGE = "";
            clsOperateurdroits.Add(clsOperateurdroit);
            return clsOperateurdroits;

            }


        }


    }
}