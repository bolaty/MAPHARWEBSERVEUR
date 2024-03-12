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
	public partial class wsOrgProspectsPhoto
	{

        public List<HT_Stock.BOJ.clsOrgProspectsPhoto> TestChampObligatoireListe(HT_Stock.BOJ.clsOrgProspectsPhoto Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsOrgProspectsPhoto> clsOrgProspectsPhotos = new List<HT_Stock.BOJ.clsOrgProspectsPhoto>();
            HT_Stock.BOJ.clsOrgProspectsPhoto clsOrgProspectsPhoto = new HT_Stock.BOJ.clsOrgProspectsPhoto();

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsOrgProspectsPhoto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOrgProspectsPhoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOrgProspectsPhoto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOrgProspectsPhoto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsOrgProspectsPhotos.Add(clsOrgProspectsPhoto);
                return clsOrgProspectsPhotos;

            }

            if (string.IsNullOrEmpty(Objet.PR_IDTIERS))
            {
                clsOrgProspectsPhoto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOrgProspectsPhoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOrgProspectsPhoto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOrgProspectsPhoto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PR_IDTIERS";
                clsOrgProspectsPhotos.Add(clsOrgProspectsPhoto);
                return clsOrgProspectsPhotos;

            }

            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsOrgProspectsPhoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsOrgProspectsPhoto.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsOrgProspectsPhoto.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsOrgProspectsPhotos.Add(clsOrgProspectsPhoto);
            //    return clsOrgProspectsPhotos;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsOrgProspectsPhoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsOrgProspectsPhoto.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsOrgProspectsPhoto.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsOrgProspectsPhotos.Add(clsOrgProspectsPhoto);
            //    return clsOrgProspectsPhotos;

            //}


            else
            {
                clsOrgProspectsPhoto.clsObjetRetour = new Common.clsObjetRetour();
                clsOrgProspectsPhoto.clsObjetRetour.SL_CODEMESSAGE = "";
                clsOrgProspectsPhoto.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsOrgProspectsPhoto.clsObjetRetour.SL_MESSAGE = "";
                clsOrgProspectsPhotos.Add(clsOrgProspectsPhoto);
                return clsOrgProspectsPhotos;

            }


        }

        public List<HT_Stock.BOJ.clsOrgProspectsPhoto> TestChampObligatoireInsert(HT_Stock.BOJ.clsOrgProspectsPhoto Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsOrgProspectsPhoto> clsOrgProspectsPhotos = new List<HT_Stock.BOJ.clsOrgProspectsPhoto>();
            HT_Stock.BOJ.clsOrgProspectsPhoto clsOrgProspectsPhoto = new HT_Stock.BOJ.clsOrgProspectsPhoto();

           

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsOrgProspectsPhoto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOrgProspectsPhoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOrgProspectsPhoto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOrgProspectsPhoto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsOrgProspectsPhotos.Add(clsOrgProspectsPhoto);
                return clsOrgProspectsPhotos;

            }

            else
            {
                clsOrgProspectsPhoto.clsObjetRetour = new Common.clsObjetRetour();
                clsOrgProspectsPhoto.clsObjetRetour.SL_CODEMESSAGE = "";
                clsOrgProspectsPhoto.clsObjetRetour.SL_RESULTAT = "TRUE";
                clsOrgProspectsPhoto.clsObjetRetour.SL_MESSAGE = "";
                clsOrgProspectsPhotos.Add(clsOrgProspectsPhoto);
                return clsOrgProspectsPhotos;

            }


        }

        public List<HT_Stock.BOJ.clsOrgProspectsPhoto> TestChampObligatoireUpdate(HT_Stock.BOJ.clsOrgProspectsPhoto Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsOrgProspectsPhoto> clsOrgProspectsPhotos = new List<HT_Stock.BOJ.clsOrgProspectsPhoto>();
            HT_Stock.BOJ.clsOrgProspectsPhoto clsOrgProspectsPhoto = new HT_Stock.BOJ.clsOrgProspectsPhoto();

            if (string.IsNullOrEmpty(Objet.PR_IDTIERS))
            {
                clsOrgProspectsPhoto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOrgProspectsPhoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOrgProspectsPhoto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOrgProspectsPhoto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PR_IDTIERS";
                clsOrgProspectsPhotos.Add(clsOrgProspectsPhoto);
                return clsOrgProspectsPhotos;

            }

            if (string.IsNullOrEmpty(Objet.AG_CODEAGENCE))
            {
                clsOrgProspectsPhoto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOrgProspectsPhoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOrgProspectsPhoto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOrgProspectsPhoto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", AG_CODEAGENCE";
                clsOrgProspectsPhotos.Add(clsOrgProspectsPhoto);
                return clsOrgProspectsPhotos;

            }


            //if (string.IsNullOrEmpty(Objet.OP_CODEOPERATEUREDITION))
            //{
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0280";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsOrgProspectsPhoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsOrgProspectsPhoto.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsOrgProspectsPhoto.clsObjetRetour.SL_MESSAGE = "L'opérateur édition est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsOrgProspectsPhotos.Add(clsOrgProspectsPhoto);
            //    return clsOrgProspectsPhotos;

            //}

            //if (string.IsNullOrEmpty(Objet.t))
            //{

            //    //----EXEPTION
            //    clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
            //    Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();
            //    clsMessages.MS_CODEMESSAGE = "GNE0001";
            //    //clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsMessages);
            //    clsOrgProspectsPhoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
            //    clsOrgProspectsPhoto.clsObjetRetour.SL_RESULTAT = "FALSE";
            //    clsOrgProspectsPhoto.clsObjetRetour.SL_MESSAGE = "Le type opération est obligatoire !!!";// clsMessages.MS_LIBELLEMESSAGE;
            //    clsOrgProspectsPhotos.Add(clsOrgProspectsPhoto);
            //    return clsOrgProspectsPhotos;

            //}


            else
            {
                clsOrgProspectsPhoto.clsObjetRetour = new Common.clsObjetRetour();
            clsOrgProspectsPhoto.clsObjetRetour.SL_CODEMESSAGE = "";
            clsOrgProspectsPhoto.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsOrgProspectsPhoto.clsObjetRetour.SL_MESSAGE = "";
            clsOrgProspectsPhotos.Add(clsOrgProspectsPhoto);
            return clsOrgProspectsPhotos;

            }


        }

        public List<HT_Stock.BOJ.clsOrgProspectsPhoto> TestChampObligatoireDelete(HT_Stock.BOJ.clsOrgProspectsPhoto Objet)
        {

            HT_Stock.BOJ.clsObjetRetour clsObjetRetour = new HT_Stock.BOJ.clsObjetRetour();
            Stock.BOJ.clsObjetEnvoi clsObjetEnvoi = new Stock.BOJ.clsObjetEnvoi();
            Stock.BOJ.clsMessages clsMessages = new Stock.BOJ.clsMessages();

            List<HT_Stock.BOJ.clsOrgProspectsPhoto> clsOrgProspectsPhotos = new List<HT_Stock.BOJ.clsOrgProspectsPhoto>();
            HT_Stock.BOJ.clsOrgProspectsPhoto clsOrgProspectsPhoto = new HT_Stock.BOJ.clsOrgProspectsPhoto();

            if (string.IsNullOrEmpty(Objet.PR_IDTIERS))
            {
                clsOrgProspectsPhoto.clsObjetRetour = new Common.clsObjetRetour();
                clsMessagesWSBLL clsMessagesWSBLL = new clsMessagesWSBLL();
                clsMessages.MS_CODEMESSAGE = Common.clsDeclaration.CODE_TYPE_OP_REQUIS;
                clsObjetEnvoi.OE_PARAM = new string[] { "ST0001" };
                clsMessages = clsMessagesWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi);
                clsOrgProspectsPhoto.clsObjetRetour.SL_CODEMESSAGE = clsMessages.MS_CODEMESSAGE;
                clsOrgProspectsPhoto.clsObjetRetour.SL_RESULTAT = Common.clsDeclaration.ERROR_RESULTAT;
                clsOrgProspectsPhoto.clsObjetRetour.SL_MESSAGE = clsMessages.MS_LIBELLEMESSAGE + ", PR_IDTIERS";
                clsOrgProspectsPhotos.Add(clsOrgProspectsPhoto);
                return clsOrgProspectsPhotos;

            }
            else
            {
            clsOrgProspectsPhoto.clsObjetRetour = new Common.clsObjetRetour();
            clsOrgProspectsPhoto.clsObjetRetour.SL_CODEMESSAGE = "";
            clsOrgProspectsPhoto.clsObjetRetour.SL_RESULTAT = "TRUE";
            clsOrgProspectsPhoto.clsObjetRetour.SL_MESSAGE = "";
            clsOrgProspectsPhotos.Add(clsOrgProspectsPhoto);
            return clsOrgProspectsPhotos;

            }


        }


    }
}