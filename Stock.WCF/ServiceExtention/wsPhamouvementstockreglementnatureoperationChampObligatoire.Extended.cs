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
	public partial class wsPhamouvementstockreglementnatureoperation
	{

        public List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation> TestChampObligatoireListe(HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation> clsPhamouvementstockreglementnatureoperations = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation>();
            HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation clsPhamouvementstockreglementnatureoperation = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation();

            //if (string.IsNullOrEmpty(Objet.NO_CODENATUREOPERATION))
            //{
            //    clsPhamouvementstockreglementnatureoperation.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", NO_CODENATUREOPERATION";
            //    clsPhamouvementstockreglementnatureoperations.Add(clsPhamouvementstockreglementnatureoperation);
            //    return clsPhamouvementstockreglementnatureoperations;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhamouvementstockreglementnatureoperations.Add(clsPhamouvementstockreglementnatureoperation);
            //    return clsPhamouvementstockreglementnatureoperations;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhamouvementstockreglementnatureoperations.Add(clsPhamouvementstockreglementnatureoperation);
            //    return clsPhamouvementstockreglementnatureoperations;

            //}


            //else
            //{
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_MESSAGE = "";
                clsPhamouvementstockreglementnatureoperations.Add(clsPhamouvementstockreglementnatureoperation);
                return clsPhamouvementstockreglementnatureoperations;

            //}


        }
        public List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation> TestChampObligatoireListeEcranParametrage(HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation> clsPhamouvementstockreglementnatureoperations = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation>();
            HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation clsPhamouvementstockreglementnatureoperation = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation();

            if (string.IsNullOrEmpty(Objet.ET_TYPEETAT1))
            {
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ET_TYPEETAT1";
                clsPhamouvementstockreglementnatureoperations.Add(clsPhamouvementstockreglementnatureoperation);
                return clsPhamouvementstockreglementnatureoperations;

            }

            if (string.IsNullOrEmpty(Objet.NF_CODENATUREFAMILLEOPERATION) && Objet.ET_TYPEETAT1!="03")
            {
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", NF_CODENATUREFAMILLEOPERATION";
                clsPhamouvementstockreglementnatureoperations.Add(clsPhamouvementstockreglementnatureoperation);
                return clsPhamouvementstockreglementnatureoperations;

            }
            if (string.IsNullOrEmpty(Objet.FO_CODEFAMILLEOPERATION) && Objet.ET_TYPEETAT1 != "03")
            {
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", FO_CODEFAMILLEOPERATION";
                clsPhamouvementstockreglementnatureoperations.Add(clsPhamouvementstockreglementnatureoperation);
                return clsPhamouvementstockreglementnatureoperations;

            }
            


            else
            {
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_MESSAGE = "";
                clsPhamouvementstockreglementnatureoperations.Add(clsPhamouvementstockreglementnatureoperation);
                return clsPhamouvementstockreglementnatureoperations;

            }


        }
        public List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation> TestChampObligatoireInsert(HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation> clsPhamouvementstockreglementnatureoperations = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation>();
            HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation clsPhamouvementstockreglementnatureoperation = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation();

           

            if (string.IsNullOrEmpty(Objet.NO_LIBELLE))
            {
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", NO_LIBELLE";
                clsPhamouvementstockreglementnatureoperations.Add(clsPhamouvementstockreglementnatureoperation);
                return clsPhamouvementstockreglementnatureoperations;

            }

            else
            {
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_MESSAGE = "";
                clsPhamouvementstockreglementnatureoperations.Add(clsPhamouvementstockreglementnatureoperation);
                return clsPhamouvementstockreglementnatureoperations;

            }


        }

        public List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation> TestChampObligatoireUpdate(HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation> clsPhamouvementstockreglementnatureoperations = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation>();
            HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation clsPhamouvementstockreglementnatureoperation = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation();

            if (string.IsNullOrEmpty(Objet.NO_CODENATUREOPERATION))
            {
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", NO_CODENATUREOPERATION";
                clsPhamouvementstockreglementnatureoperations.Add(clsPhamouvementstockreglementnatureoperation);
                return clsPhamouvementstockreglementnatureoperations;

            }

            if (string.IsNullOrEmpty(Objet.NO_LIBELLE))
            {
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", NO_LIBELLE";
                clsPhamouvementstockreglementnatureoperations.Add(clsPhamouvementstockreglementnatureoperation);
                return clsPhamouvementstockreglementnatureoperations;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhamouvementstockreglementnatureoperations.Add(clsPhamouvementstockreglementnatureoperation);
            //    return clsPhamouvementstockreglementnatureoperations;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhamouvementstockreglementnatureoperations.Add(clsPhamouvementstockreglementnatureoperation);
            //    return clsPhamouvementstockreglementnatureoperations;

            //}


            else
            {
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour = new Common.clsObjetRetour();
            clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_MESSAGE = "";
            clsPhamouvementstockreglementnatureoperations.Add(clsPhamouvementstockreglementnatureoperation);
            return clsPhamouvementstockreglementnatureoperations;

            }


        }

        public List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation> TestChampObligatoireDelete(HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation> clsPhamouvementstockreglementnatureoperations = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation>();
            HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation clsPhamouvementstockreglementnatureoperation = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperation();

            if (string.IsNullOrEmpty(Objet.NO_CODENATUREOPERATION))
            {
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", NO_CODENATUREOPERATION";
                clsPhamouvementstockreglementnatureoperations.Add(clsPhamouvementstockreglementnatureoperation);
                return clsPhamouvementstockreglementnatureoperations;

            }
            else
            {
            clsPhamouvementstockreglementnatureoperation.clsObjetRetour = new Common.clsObjetRetour();
            clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhamouvementstockreglementnatureoperation.clsObjetRetour.SL_MESSAGE = "";
            clsPhamouvementstockreglementnatureoperations.Add(clsPhamouvementstockreglementnatureoperation);
            return clsPhamouvementstockreglementnatureoperations;

            }


        }


    }
}