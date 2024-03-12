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
	public partial class wsPhamouvementstockreglement
	{

        public List<HT_Stock.BOJ.clsPhamouvementstockreglement> TestChampObligatoireListe(HT_Stock.BOJ.clsPhamouvementstockreglement Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhamouvementstockreglement> clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
            HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();

            //if (string.IsNullOrEmpty(Objet.MV_NUMPIECE))
            //{
            //    clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MV_NUMPIECE";
            //    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            //    return clsPhamouvementstockreglements;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            //    return clsPhamouvementstockreglements;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            //    return clsPhamouvementstockreglements;

            //}


            //else
            //{
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            //}


        }
            public List<HT_Stock.BOJ.clsPhamouvementstockreglement> TestChampObligatoireListeReglementCommission(HT_Stock.BOJ.clsPhamouvementstockreglement Objet)
            {

                HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
                Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
                Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

                List<HT_Stock.BOJ.clsPhamouvementstockreglement> clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
                HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
            //Objet[0].AG_CODEAGENCE, Objet[0].EN_CODEENTREPOT , Objet[0].TI_NUMTIERS, Objet[0].DATEDEBUT, Objet[0].DATEFIN, Objet[0].MV_DATESAISIE
            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            if (string.IsNullOrEmpty(Objet.EN_CODEENTREPOT))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", EN_CODEENTREPOT";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            if (string.IsNullOrEmpty(Objet.TI_NUMTIERS))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TI_NUMTIERS";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            if (string.IsNullOrEmpty(Objet.DATEDEBUT))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DATEDEBUT";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }

            if (string.IsNullOrEmpty(Objet.DATEFIN))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DATEFIN";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }


            if (string.IsNullOrEmpty(Objet.MV_DATESAISIE))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MV_DATESAISIE";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }



            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            //    return clsPhamouvementstockreglements;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            //    return clsPhamouvementstockreglements;

            //}


            //else
            //{
            clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "TRUE";
                    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "";
                    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                    return clsPhamouvementstockreglements;

                //}


            }



        public List<HT_Stock.BOJ.clsPhamouvementstockreglement> TestChampObligatoireListeSoldeCompteEcranOD(HT_Stock.BOJ.clsPhamouvementstockreglement Objet)
        {
            //Objet[0].AG_CODEAGENCE, Objet[0].PL_NUMCOMPTEGENERAL, Objet[0].TI_NUMTIERS, Objet[0].NC_CODENATURECOMPTE, Objet[0].MV_DATESAISIE

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhamouvementstockreglement> clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
            HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();
        //Objet[0].AG_CODEAGENCE, Objet[0].EN_CODEENTREPOT , Objet[0].TI_NUMTIERS, Objet[0].DATEDEBUT, Objet[0].DATEFIN, Objet[0].MV_DATESAISIE
        if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
        {
            clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
            clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            return clsPhamouvementstockreglements;

        }
        if (string.IsNullOrEmpty(Objet.PL_NUMCOMPTEGENERAL))
        {
            clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PL_NUMCOMPTEGENERAL";
            clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            return clsPhamouvementstockreglements;

        }
        if (string.IsNullOrEmpty(Objet.TI_NUMTIERS))
        {
            clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TI_NUMTIERS";
            clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            return clsPhamouvementstockreglements;

        }
        if (string.IsNullOrEmpty(Objet.NC_CODENATURECOMPTE))
        {
            clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", NC_CODENATURECOMPTE";
            clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            return clsPhamouvementstockreglements;

        }

        if (string.IsNullOrEmpty(Objet.MV_DATESAISIE))
        {
            clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MV_DATESAISIE";
            clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            return clsPhamouvementstockreglements;

        }






            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            //    return clsPhamouvementstockreglements;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            //    return clsPhamouvementstockreglements;

            //}


            else
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }


        }


        public List<HT_Stock.BOJ.clsPhamouvementstockreglement> TestChampObligatoireInsert(HT_Stock.BOJ.clsPhamouvementstockreglement Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhamouvementstockreglement> clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
            HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();

           

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            if (string.IsNullOrEmpty(Objet.EN_CODEENTREPOT))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", EN_CODEENTREPOT";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            if (string.IsNullOrEmpty(Objet.MS_NUMPIECE))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MS_NUMPIECE";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            if (string.IsNullOrEmpty(Objet.MV_NOMTIERS))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MV_NOMTIERS";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            if (string.IsNullOrEmpty(Objet.MR_CODEMODEREGLEMENT))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MR_CODEMODEREGLEMENT";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }

            if (string.IsNullOrEmpty(Objet.CH_DATEDEBUTCOUVERTURE))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CH_DATEDEBUTCOUVERTURE";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }

            if (string.IsNullOrEmpty(Objet.CH_DATEFINCOUVERTURE))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", CH_DATEFINCOUVERTURE";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }

            //if (Objet.MR_CODEMODEREGLEMENT=="01")
            //{
            //    clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "Le compte caisse de l'opérateur doit être configuré !!!";
            //    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            //    return clsPhamouvementstockreglements;

            //}


            if (string.IsNullOrEmpty(Objet.TI_NUMTIERS))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TI_NUMTIERS";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            if (string.IsNullOrEmpty(Objet.PL_NUMCOMPTE))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PL_NUMCOMPTE";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            if (string.IsNullOrEmpty(Objet.PL_NUMCOMPTEBANQUE))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PL_NUMCOMPTEBANQUE";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            if (Objet.MONTANTVERSEMENT==0)
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MONTANTVERSEMENT";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            if (Objet.MONTANTFACTURETTC==0)
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "La facture a été soldé . Veuillez consulter le relevé du client " + " !!!";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            //if (string.IsNullOrEmpty(Objet.MV_REFERENCEPIECE))
            //{
            //    clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MV_REFERENCEPIECE";
            //    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            //    return clsPhamouvementstockreglements;

            //}






            else
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }


        }
        public List<HT_Stock.BOJ.clsPhamouvementstockreglement> TestChampObligatoireExtourne(HT_Stock.BOJ.clsPhamouvementstockreglement Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhamouvementstockreglement> clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
            HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();

            //@AG_CODEAGENCE1, @MV_DATESAISIE, @MV_DATEPIECE, @MV_NUMPIECE,@MV_NUMPIECE1,@OP_CODEOPERATEUR,0,@CODECRYPTAGE1

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            if (string.IsNullOrEmpty(Objet.MV_DATESAISIE))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MV_DATESAISIE";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            if (string.IsNullOrEmpty(Objet.MV_DATEPIECE))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MV_DATEPIECE";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUR))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", OP_CODEOPERATEUR";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            

            else
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }


        }

        public List<HT_Stock.BOJ.clsPhamouvementstockreglement> TestChampObligatoireRecu(HT_Stock.BOJ.clsPhamouvementstockreglement Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhamouvementstockreglement> clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
            HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();

            //@AG_CODEAGENCE1, @MV_DATESAISIE, @MV_DATEPIECE, @MV_NUMPIECE,@MV_NUMPIECE1,@OP_CODEOPERATEUR,0,@CODECRYPTAGE1
           // Objet[0].AG_CODEAGENCE,Objet[0].MV_NUMPIECE,Objet[0].MV_NUMBORDEREAU
            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            if (string.IsNullOrEmpty(Objet.MV_NUMPIECE))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MV_NUMPIECE";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            if (string.IsNullOrEmpty(Objet.MV_NUMBORDEREAU))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MV_NUMBORDEREAU";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            
            

            else
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }


        }




        public List<HT_Stock.BOJ.clsPhamouvementstockreglement> TestChampObligatoireUpdate(HT_Stock.BOJ.clsPhamouvementstockreglement Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhamouvementstockreglement> clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
            HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();

            if (string.IsNullOrEmpty(Objet.MV_NUMPIECE))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MV_NUMPIECE";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }

            if (string.IsNullOrEmpty(Objet.MV_LIBELLEOPERATION))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MV_LIBELLEOPERATION";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            //    return clsPhamouvementstockreglements;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            //    return clsPhamouvementstockreglements;

            //}


            else
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
            clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "";
            clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            return clsPhamouvementstockreglements;

            }


        }

        public List<HT_Stock.BOJ.clsPhamouvementstockreglement> TestChampObligatoireDelete(HT_Stock.BOJ.clsPhamouvementstockreglement Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhamouvementstockreglement> clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
            HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();

            if (string.IsNullOrEmpty(Objet.MV_NUMPIECE))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MV_NUMPIECE";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            else
            {
            clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
            clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "";
            clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            return clsPhamouvementstockreglements;

            }


        }



        public List<HT_Stock.BOJ.clsPhamouvementstockreglement> TestChampObligatoireReglementCommissionCommerciale(HT_Stock.BOJ.clsPhamouvementstockreglement Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhamouvementstockreglement> clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
            HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();



            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            if (string.IsNullOrEmpty(Objet.EN_CODEENTREPOT))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", EN_CODEENTREPOT";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            if (string.IsNullOrEmpty(Objet.MV_DATESAISIE))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MV_DATESAISIE";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            if (string.IsNullOrEmpty(Objet.MV_NOMTIERS))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MV_NOMTIERS";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            if (string.IsNullOrEmpty(Objet.MR_CODEMODEREGLEMENT))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MR_CODEMODEREGLEMENT";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            if (string.IsNullOrEmpty(Objet.TI_NUMTIERS))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TI_NUMTIERS";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            if (string.IsNullOrEmpty(Objet.TI_IDTIERS))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TI_IDTIERS";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }



            if (string.IsNullOrEmpty(Objet.PL_NUMCOMPTE))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PL_NUMCOMPTE";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            if (string.IsNullOrEmpty(Objet.PL_NUMCOMPTEBANQUE))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PL_NUMCOMPTEBANQUE";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            if (Objet.MV_MONTANTCREDIT==0)
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MV_MONTANTCREDIT";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
           
            //if (string.IsNullOrEmpty(Objet.MV_REFERENCEPIECE))
            //{
            //    clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MV_REFERENCEPIECE";
            //    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            //    return clsPhamouvementstockreglements;

            //}
            if (string.IsNullOrEmpty(Objet.MC_LIBELLEOPERATION))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MC_LIBELLEOPERATION";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            if (string.IsNullOrEmpty(Objet.MS_NUMPIECE))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MS_NUMPIECE";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }




            else
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }


        }


        public List<HT_Stock.BOJ.clsPhamouvementstockreglement> TestChampObligatoireReglementOD(HT_Stock.BOJ.clsPhamouvementstockreglement Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhamouvementstockreglement> clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
            HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();



            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            if (string.IsNullOrEmpty(Objet.EN_CODEENTREPOT))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", EN_CODEENTREPOT";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            if (string.IsNullOrEmpty(Objet.MV_DATESAISIE))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MV_DATESAISIE";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            if (string.IsNullOrEmpty(Objet.MV_NOMTIERS))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MV_NOMTIERS";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            //if (string.IsNullOrEmpty(Objet.MR_CODEMODEREGLEMENT))
            //{
            //    clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MR_CODEMODEREGLEMENT";
            //    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            //    return clsPhamouvementstockreglements;

            //}
            if (string.IsNullOrEmpty(Objet.TI_NUMTIERS))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TI_NUMTIERS";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            if (string.IsNullOrEmpty(Objet.TI_IDTIERS))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TI_IDTIERS";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }



            if (string.IsNullOrEmpty(Objet.PL_NUMCOMPTE))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PL_NUMCOMPTE";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            if (string.IsNullOrEmpty(Objet.PL_NUMCOMPTEBANQUE))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PL_NUMCOMPTEBANQUE";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            if ((Objet.MV_MONTANTCREDIT+Objet.MV_MONTANTDEBIT)== 0)
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MV_MONTANTCREDIT";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }

            //if (string.IsNullOrEmpty(Objet.MV_REFERENCEPIECE))
            //{
            //    clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MV_REFERENCEPIECE";
            //    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            //    return clsPhamouvementstockreglements;

            //}
            if (string.IsNullOrEmpty(Objet.MV_LIBELLEOPERATION))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MV_LIBELLEOPERATION";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            if (string.IsNullOrEmpty(Objet.MS_NUMPIECE))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MS_NUMPIECE";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }




            else
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }


        }

            public List<HT_Stock.BOJ.clsPhamouvementstockreglement> TestChampObligatoireReglementTresorerieTiers(HT_Stock.BOJ.clsPhamouvementstockreglement Objet)
            {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhamouvementstockreglement> clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
            HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();



            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            if (string.IsNullOrEmpty(Objet.EN_CODEENTREPOT))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", EN_CODEENTREPOT";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            if (string.IsNullOrEmpty(Objet.MV_DATESAISIE))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MV_DATESAISIE";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            if (string.IsNullOrEmpty(Objet.MV_NOMTIERS))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MV_NOMTIERS";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            if (string.IsNullOrEmpty(Objet.NO_CODENATUREOPERATION))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", NO_CODENATUREOPERATION";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            if (string.IsNullOrEmpty(Objet.TI_NUMTIERS))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TI_NUMTIERS";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            //if (string.IsNullOrEmpty(Objet.TI_IDTIERS))
            //{
            //    clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TI_IDTIERS";
            //    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            //    return clsPhamouvementstockreglements;

            //}



            if (string.IsNullOrEmpty(Objet.PL_NUMCOMPTE))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PL_NUMCOMPTE";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            if (string.IsNullOrEmpty(Objet.PL_NUMCOMPTEBANQUE))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PL_NUMCOMPTEBANQUE";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            if ((Objet.MV_MONTANTCREDIT+ Objet.MV_MONTANTDEBIT) == 0)
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MV_MONTANTCREDIT";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }

            if (string.IsNullOrEmpty(Objet.MV_REFERENCEPIECE))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MV_REFERENCEPIECE";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            if (string.IsNullOrEmpty(Objet.MV_LIBELLEOPERATION))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MV_LIBELLEOPERATION";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            if (string.IsNullOrEmpty(Objet.MS_NUMPIECE))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MS_NUMPIECE";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }




            else
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }


            }
            public List<HT_Stock.BOJ.clsPhamouvementstockreglement> TestChampObligatoireReglementTresorerieCaisse(HT_Stock.BOJ.clsPhamouvementstockreglement Objet)
            {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhamouvementstockreglement> clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsPhamouvementstockreglement>();
            HT_Stock.BOJ.clsPhamouvementstockreglement clsPhamouvementstockreglement = new HT_Stock.BOJ.clsPhamouvementstockreglement();



            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            if (string.IsNullOrEmpty(Objet.EN_CODEENTREPOT))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", EN_CODEENTREPOT";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            if (string.IsNullOrEmpty(Objet.MV_DATESAISIE))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MV_DATESAISIE";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            if (string.IsNullOrEmpty(Objet.MV_NOMTIERS))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MV_NOMTIERS";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            if (string.IsNullOrEmpty(Objet.NO_CODENATUREOPERATION))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", NO_CODENATUREOPERATION";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            //if (string.IsNullOrEmpty(Objet.TI_NUMTIERS))
            //{
            //    clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TI_NUMTIERS";
            //    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            //    return clsPhamouvementstockreglements;

            //}
            //if (string.IsNullOrEmpty(Objet.TI_IDTIERS))
            //{
            //    clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TI_IDTIERS";
            //    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            //    return clsPhamouvementstockreglements;

            //}



            if (string.IsNullOrEmpty(Objet.PL_NUMCOMPTE))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PL_NUMCOMPTE";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            if (string.IsNullOrEmpty(Objet.PL_NUMCOMPTEBANQUE))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PL_NUMCOMPTEBANQUE";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            if (Objet.MV_MONTANTCREDIT==0)
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MV_MONTANTCREDIT";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }

            if (string.IsNullOrEmpty(Objet.MV_REFERENCEPIECE))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MV_REFERENCEPIECE";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            if (string.IsNullOrEmpty(Objet.MV_LIBELLEOPERATION))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MV_LIBELLEOPERATION";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            //if (string.IsNullOrEmpty(Objet.MS_NUMPIECE))
            //{
            //    clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MS_NUMPIECE";
            //    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            //    return clsPhamouvementstockreglements;

            //}




            else
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }


            }


        public List<HT_Stock.BOJ.clsMiccomptewebResultat> TestChampObligatoireInsertMobile(HT_Stock.BOJ.clsPhamouvementstockreglement Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsMiccomptewebResultat> clsPhamouvementstockreglements = new List<HT_Stock.BOJ.clsMiccomptewebResultat>();
            HT_Stock.BOJ.clsMiccomptewebResultat clsPhamouvementstockreglement = new HT_Stock.BOJ.clsMiccomptewebResultat();



            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
           

            if (string.IsNullOrEmpty(Objet.TYPEOPERATION))
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TYPEOPERATION";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }

            if (string.IsNullOrEmpty(Objet.EN_CODEENTREPOT) && Objet.TYPEOPERATION == "0")
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", EN_CODEENTREPOT";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }

            if (string.IsNullOrEmpty(Objet.MS_NUMPIECE) && Objet.TYPEOPERATION=="0")
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MS_NUMPIECE";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            if (string.IsNullOrEmpty(Objet.MV_NOMTIERS) && Objet.TYPEOPERATION == "0")
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MV_NOMTIERS";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            if (string.IsNullOrEmpty(Objet.MR_CODEMODEREGLEMENT) && Objet.TYPEOPERATION == "0")
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MR_CODEMODEREGLEMENT";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }

            //if (Objet.MR_CODEMODEREGLEMENT=="01")
            //{
            //    clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "Le compte caisse de l'opérateur doit être configuré !!!";
            //    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            //    return clsPhamouvementstockreglements;

            //}


            if (string.IsNullOrEmpty(Objet.TI_NUMTIERS) && Objet.TYPEOPERATION == "0")
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TI_NUMTIERS";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            if (string.IsNullOrEmpty(Objet.PL_NUMCOMPTE) && Objet.TYPEOPERATION == "0")
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PL_NUMCOMPTE";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            if (string.IsNullOrEmpty(Objet.PL_NUMCOMPTEBANQUE) && Objet.TYPEOPERATION == "0")
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PL_NUMCOMPTEBANQUE";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            if (Objet.MONTANTVERSEMENT == 0 && Objet.TYPEOPERATION == "0")
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MONTANTVERSEMENT";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            if (Objet.MONTANTFACTURETTC==0 && Objet.TYPEOPERATION == "0")
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MONTANTFACTURETTC";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }
            //if (string.IsNullOrEmpty(Objet.MV_REFERENCEPIECE))
            //{
            //    clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", MV_REFERENCEPIECE";
            //    clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
            //    return clsPhamouvementstockreglements;

            //}






            else
            {
                clsPhamouvementstockreglement.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglement.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhamouvementstockreglement.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhamouvementstockreglement.clsObjetRetour.SL_MESSAGE = "";
                clsPhamouvementstockreglements.Add(clsPhamouvementstockreglement);
                return clsPhamouvementstockreglements;

            }


        }



    }
}