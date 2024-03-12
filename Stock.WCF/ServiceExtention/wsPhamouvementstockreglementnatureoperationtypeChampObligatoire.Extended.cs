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
	public partial class wsPhamouvementstockreglementnatureoperationtype
	{

        public List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype> TestChampObligatoireListe(HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype> clsPhamouvementstockreglementnatureoperationtypes = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype>();
            HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype clsPhamouvementstockreglementnatureoperationtype = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype();

            //if (string.IsNullOrEmpty(Objet.RO_CODENATUREOPERATIONTYPE))
            //{
            //    clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", RO_CODENATUREOPERATIONTYPE";
            //    clsPhamouvementstockreglementnatureoperationtypes.Add(clsPhamouvementstockreglementnatureoperationtype);
            //    return clsPhamouvementstockreglementnatureoperationtypes;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhamouvementstockreglementnatureoperationtypes.Add(clsPhamouvementstockreglementnatureoperationtype);
            //    return clsPhamouvementstockreglementnatureoperationtypes;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhamouvementstockreglementnatureoperationtypes.Add(clsPhamouvementstockreglementnatureoperationtype);
            //    return clsPhamouvementstockreglementnatureoperationtypes;

            //}


            //else
            //{
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_MESSAGE = "";
                clsPhamouvementstockreglementnatureoperationtypes.Add(clsPhamouvementstockreglementnatureoperationtype);
                return clsPhamouvementstockreglementnatureoperationtypes;

            //}


        }

        public List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype> TestChampObligatoireInsert(HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype> clsPhamouvementstockreglementnatureoperationtypes = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype>();
            HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype clsPhamouvementstockreglementnatureoperationtype = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype();

           

            if (string.IsNullOrEmpty(Objet.RO_LIBELLE))
            {
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", RO_LIBELLE";
                clsPhamouvementstockreglementnatureoperationtypes.Add(clsPhamouvementstockreglementnatureoperationtype);
                return clsPhamouvementstockreglementnatureoperationtypes;

            }

            else
            {
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_MESSAGE = "";
                clsPhamouvementstockreglementnatureoperationtypes.Add(clsPhamouvementstockreglementnatureoperationtype);
                return clsPhamouvementstockreglementnatureoperationtypes;

            }


        }

        public List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype> TestChampObligatoireUpdate(HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype> clsPhamouvementstockreglementnatureoperationtypes = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype>();
            HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype clsPhamouvementstockreglementnatureoperationtype = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype();

            if (string.IsNullOrEmpty(Objet.RO_CODENATUREOPERATIONTYPE))
            {
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", RO_CODENATUREOPERATIONTYPE";
                clsPhamouvementstockreglementnatureoperationtypes.Add(clsPhamouvementstockreglementnatureoperationtype);
                return clsPhamouvementstockreglementnatureoperationtypes;

            }

            if (string.IsNullOrEmpty(Objet.RO_LIBELLE))
            {
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", RO_LIBELLE";
                clsPhamouvementstockreglementnatureoperationtypes.Add(clsPhamouvementstockreglementnatureoperationtype);
                return clsPhamouvementstockreglementnatureoperationtypes;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhamouvementstockreglementnatureoperationtypes.Add(clsPhamouvementstockreglementnatureoperationtype);
            //    return clsPhamouvementstockreglementnatureoperationtypes;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhamouvementstockreglementnatureoperationtypes.Add(clsPhamouvementstockreglementnatureoperationtype);
            //    return clsPhamouvementstockreglementnatureoperationtypes;

            //}


            else
            {
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour = new Common.clsObjetRetour();
            clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_MESSAGE = "";
            clsPhamouvementstockreglementnatureoperationtypes.Add(clsPhamouvementstockreglementnatureoperationtype);
            return clsPhamouvementstockreglementnatureoperationtypes;

            }


        }

        public List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype> TestChampObligatoireDelete(HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype> clsPhamouvementstockreglementnatureoperationtypes = new List<HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype>();
            HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype clsPhamouvementstockreglementnatureoperationtype = new HT_Stock.BOJ.clsPhamouvementstockreglementnatureoperationtype();

            if (string.IsNullOrEmpty(Objet.RO_CODENATUREOPERATIONTYPE))
            {
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", RO_CODENATUREOPERATIONTYPE";
                clsPhamouvementstockreglementnatureoperationtypes.Add(clsPhamouvementstockreglementnatureoperationtype);
                return clsPhamouvementstockreglementnatureoperationtypes;

            }
            else
            {
            clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour = new Common.clsObjetRetour();
            clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhamouvementstockreglementnatureoperationtype.clsObjetRetour.SL_MESSAGE = "";
            clsPhamouvementstockreglementnatureoperationtypes.Add(clsPhamouvementstockreglementnatureoperationtype);
            return clsPhamouvementstockreglementnatureoperationtypes;

            }


        }


    }
}