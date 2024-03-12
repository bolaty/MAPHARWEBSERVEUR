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
	public partial class wsPhamouvementstockfiltragedestockexpiration
	{

        public List<HT_Stock.BOJ.clsPhamouvementstockfiltragedestockexpiration> TestChampObligatoireListe(HT_Stock.BOJ.clsPhamouvementstockfiltragedestockexpiration Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhamouvementstockfiltragedestockexpiration> clsPhamouvementstockfiltragedestockexpirations = new List<HT_Stock.BOJ.clsPhamouvementstockfiltragedestockexpiration>();
            HT_Stock.BOJ.clsPhamouvementstockfiltragedestockexpiration clsPhamouvementstockfiltragedestockexpiration = new HT_Stock.BOJ.clsPhamouvementstockfiltragedestockexpiration();

            //if (string.IsNullOrEmpty(Objet.ME_IDFILTRAGEDESTOCKEXPIRATION))
            //{
            //    clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour = new Common.clsObjetRetour();
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
            //    clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
            //    clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
            //    clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
            //    clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ME_IDFILTRAGEDESTOCKEXPIRATION";
            //    clsPhamouvementstockfiltragedestockexpirations.Add(clsPhamouvementstockfiltragedestockexpiration);
            //    return clsPhamouvementstockfiltragedestockexpirations;

            //}


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhamouvementstockfiltragedestockexpirations.Add(clsPhamouvementstockfiltragedestockexpiration);
            //    return clsPhamouvementstockfiltragedestockexpirations;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhamouvementstockfiltragedestockexpirations.Add(clsPhamouvementstockfiltragedestockexpiration);
            //    return clsPhamouvementstockfiltragedestockexpirations;

            //}


            //else
            //{
                clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour.SL_MESSAGE = "";
                clsPhamouvementstockfiltragedestockexpirations.Add(clsPhamouvementstockfiltragedestockexpiration);
                return clsPhamouvementstockfiltragedestockexpirations;

            //}


        }

        public List<HT_Stock.BOJ.clsPhamouvementstockfiltragedestockexpiration> TestChampObligatoireInsert(HT_Stock.BOJ.clsPhamouvementstockfiltragedestockexpiration Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhamouvementstockfiltragedestockexpiration> clsPhamouvementstockfiltragedestockexpirations = new List<HT_Stock.BOJ.clsPhamouvementstockfiltragedestockexpiration>();
            HT_Stock.BOJ.clsPhamouvementstockfiltragedestockexpiration clsPhamouvementstockfiltragedestockexpiration = new HT_Stock.BOJ.clsPhamouvementstockfiltragedestockexpiration();

           

            if (string.IsNullOrEmpty(Objet.ME_DATEEXPIRATIONFILTRAGEDESTOCKEXPIRATION))
            {
                clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ME_DATEEXPIRATIONFILTRAGEDESTOCKEXPIRATION";
                clsPhamouvementstockfiltragedestockexpirations.Add(clsPhamouvementstockfiltragedestockexpiration);
                return clsPhamouvementstockfiltragedestockexpirations;

            }

            else
            {
                clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour = new Common.clsObjetRetour();
                clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour.SL_CODEMESSAGE = "";
                clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour.SL_MESSAGE = "";
                clsPhamouvementstockfiltragedestockexpirations.Add(clsPhamouvementstockfiltragedestockexpiration);
                return clsPhamouvementstockfiltragedestockexpirations;

            }


        }

        public List<HT_Stock.BOJ.clsPhamouvementstockfiltragedestockexpiration> TestChampObligatoireUpdate(HT_Stock.BOJ.clsPhamouvementstockfiltragedestockexpiration Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhamouvementstockfiltragedestockexpiration> clsPhamouvementstockfiltragedestockexpirations = new List<HT_Stock.BOJ.clsPhamouvementstockfiltragedestockexpiration>();
            HT_Stock.BOJ.clsPhamouvementstockfiltragedestockexpiration clsPhamouvementstockfiltragedestockexpiration = new HT_Stock.BOJ.clsPhamouvementstockfiltragedestockexpiration();

            if (string.IsNullOrEmpty(Objet.ME_IDFILTRAGEDESTOCKEXPIRATION))
            {
                clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ME_IDFILTRAGEDESTOCKEXPIRATION";
                clsPhamouvementstockfiltragedestockexpirations.Add(clsPhamouvementstockfiltragedestockexpiration);
                return clsPhamouvementstockfiltragedestockexpirations;

            }

            if (string.IsNullOrEmpty(Objet.ME_DATEEXPIRATIONFILTRAGEDESTOCKEXPIRATION))
            {
                clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ME_DATEEXPIRATIONFILTRAGEDESTOCKEXPIRATION";
                clsPhamouvementstockfiltragedestockexpirations.Add(clsPhamouvementstockfiltragedestockexpiration);
                return clsPhamouvementstockfiltragedestockexpirations;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhamouvementstockfiltragedestockexpirations.Add(clsPhamouvementstockfiltragedestockexpiration);
            //    return clsPhamouvementstockfiltragedestockexpirations;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsPhamouvementstockfiltragedestockexpirations.Add(clsPhamouvementstockfiltragedestockexpiration);
            //    return clsPhamouvementstockfiltragedestockexpirations;

            //}


            else
            {
                clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour = new Common.clsObjetRetour();
            clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour.SL_MESSAGE = "";
            clsPhamouvementstockfiltragedestockexpirations.Add(clsPhamouvementstockfiltragedestockexpiration);
            return clsPhamouvementstockfiltragedestockexpirations;

            }


        }

        public List<HT_Stock.BOJ.clsPhamouvementstockfiltragedestockexpiration> TestChampObligatoireDelete(HT_Stock.BOJ.clsPhamouvementstockfiltragedestockexpiration Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsPhamouvementstockfiltragedestockexpiration> clsPhamouvementstockfiltragedestockexpirations = new List<HT_Stock.BOJ.clsPhamouvementstockfiltragedestockexpiration>();
            HT_Stock.BOJ.clsPhamouvementstockfiltragedestockexpiration clsPhamouvementstockfiltragedestockexpiration = new HT_Stock.BOJ.clsPhamouvementstockfiltragedestockexpiration();

            if (string.IsNullOrEmpty(Objet.ME_IDFILTRAGEDESTOCKEXPIRATION))
            {
                clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", ME_IDFILTRAGEDESTOCKEXPIRATION";
                clsPhamouvementstockfiltragedestockexpirations.Add(clsPhamouvementstockfiltragedestockexpiration);
                return clsPhamouvementstockfiltragedestockexpirations;

            }
            else
            {
            clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour = new Common.clsObjetRetour();
            clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour.SL_CODEMESSAGE = "";
            clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsPhamouvementstockfiltragedestockexpiration.clsObjetRetour.SL_MESSAGE = "";
            clsPhamouvementstockfiltragedestockexpirations.Add(clsPhamouvementstockfiltragedestockexpiration);
            return clsPhamouvementstockfiltragedestockexpirations;

            }


        }


    }
}