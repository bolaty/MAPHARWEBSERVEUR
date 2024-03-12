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
	public partial class wsPhatiers
	{

        public List<HT_Stock.BOJ.clsPhatiers> TestChampObligatoireListe(HT_Stock.BOJ.clsPhatiers Objet)
        {


            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();


            List<HT_Stock.BOJ.clsPhatiers> clsPhatierss = new List<HT_Stock.BOJ.clsPhatiers>();
            HT_Stock.BOJ.clsPhatiers clsPhatiers = new HT_Stock.BOJ.clsPhatiers();

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

                clsPhatiers.clsObjetRetour = new Common.clsObjetRetour();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "GNE0280" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhatiers.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhatiers.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhatiers.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsPhatierss.Add(clsPhatiers);
                clsPhatiers.clsObjetRetour.SL_RESULTAT = "FALSE";
                clsPhatiers.clsObjetRetour.SL_MESSAGE = "L'agence est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
                clsPhatierss.Add(clsPhatiers);
                return clsPhatierss;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhatiers.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhatiers.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhatiers.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhatierss.Add(clsPhatiers);
            //    return clsPhatierss;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhatiers.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhatiers.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhatiers.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhatierss.Add(clsPhatiers);
            //    return clsPhatierss;

            //}


            else
            {
                clsPhatiers.clsObjetRetour = new Common.clsObjetRetour();
                clsPhatiers.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhatiers.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhatiers.clsObjetRetour.SL_MESSAGE = "";
                clsPhatierss.Add(clsPhatiers);
                return clsPhatierss;

            }


        }


        public List<HT_Stock.BOJ.clsPhatiers> TestChampObligatoireListeSolde(HT_Stock.BOJ.clsPhatiers Objet)
        {


            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhatiers> clsPhatierss = new List<HT_Stock.BOJ.clsPhatiers>();
            HT_Stock.BOJ.clsPhatiers clsPhatiers = new HT_Stock.BOJ.clsPhatiers();

            clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsPhatiers.clsObjetRetour = new Common.clsObjetRetour();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhatiers.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhatiers.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhatiers.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsPhatierss.Add(clsPhatiers);
                return clsPhatierss;

            }
            if (string.IsNullOrEmpty(Objet.EN_CODEENTREPOT))
            {
                clsPhatiers.clsObjetRetour = new Common.clsObjetRetour();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhatiers.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhatiers.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhatiers.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", EN_CODEENTREPOT";
                clsPhatierss.Add(clsPhatiers);
                return clsPhatierss;

            }
            if (string.IsNullOrEmpty(Objet.TI_NUMTIERS))
            {
                clsPhatiers.clsObjetRetour = new Common.clsObjetRetour();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhatiers.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhatiers.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhatiers.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", TI_NUMTIERS";
                clsPhatierss.Add(clsPhatiers);
                return clsPhatierss;

            }            
            if (string.IsNullOrEmpty(Objet.DATEDEBUT))
            {
                clsPhatiers.clsObjetRetour = new Common.clsObjetRetour();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhatiers.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhatiers.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhatiers.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", DATEDEBUT";
                clsPhatierss.Add(clsPhatiers);
                return clsPhatierss;

            } 
            

            else
            {
                clsPhatiers.clsObjetRetour = new Common.clsObjetRetour();
                clsPhatiers.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhatiers.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhatiers.clsObjetRetour.SL_MESSAGE = "";
                clsPhatierss.Add(clsPhatiers);
                return clsPhatierss;

            }


        }


    }
}