using System;
using System.Collections.Generic;
using Stock.Common;
using HT_Stock.BOJ;
using Stock.WSBLL;
using Stock.WSTOOLS;
using HT_HT_Stock.BOJ;

namespace Stock.WCF
{
    public class wsVerificationUsages
    {
        private clsDonnee _clsDonnee = new clsDonnee();

        public clsDonnee clsDonnee
        {
            get { return _clsDonnee; }
            set { _clsDonnee = value; }
        }

        public List<clsUtilisateursapis> verificationToken(Common.clsObjetEnvoi ObjetEnvoi, string Token )
        {
            clsUtilisateursapisWSBLL clsUtilisateursapisWSBLL = new clsUtilisateursapisWSBLL();
            List<clsUtilisateursapis> clsUtilisateursapiss = new List<clsUtilisateursapis>();
            List<clsUtilisateursapis> clsUtilisateursapisRetours = new List<clsUtilisateursapis>();
            clsUtilisateursapis clsUtilisateursapis = new clsUtilisateursapis();
            clsUtilisateursapis.clsObjetRetour = new Stock.Common.clsObjetRetour();
            clsUtilisateursapis.clsObjetEnvoi = new Common.clsObjetEnvoi();
            
            clsUtilisateursapis.TYPEOPERATION = ((int)TypeOperation.SELECT).ToString();
            clsUtilisateursapis.SL_LIBELLEECRAN = Stock.Common.clsDeclaration.LIBELLE_DEFAULT;
            clsUtilisateursapis.SL_LIBELLEMOUCHARD = Stock.Common.clsDeclaration.LIBELLE_DEFAULT;
            clsUtilisateursapis.UT_TOKEN = Token;
            clsUtilisateursapis.clsObjetEnvoi = ObjetEnvoi;
            clsUtilisateursapiss.Add(clsUtilisateursapis);
            clsUtilisateursapisRetours.Add(clsUtilisateursapis);

            if (Token == "")
            {
                clsUtilisateursapisRetours[0].clsObjetRetour.SL_RESULTAT = Stock.Common.clsDeclaration.ERROR_RESULTAT;
                clsUtilisateursapisRetours[0].clsObjetRetour.SL_MESSAGE = Stock.Common.clsDeclaration.TOKKEN_NULL;
            }
            else if (Token != "")
            {
                try
                {
                    List<Stock.BOJ.clsUtilisateursapis> clsUtilisateursapis1 = new List<Stock.BOJ.clsUtilisateursapis>();
                    List<Stock.BOJ.clsUtilisateursapis> clsUtilisateursapisRetours1 = new List<Stock.BOJ.clsUtilisateursapis>();
                    //=============
                    foreach (Stock.BOJ.clsUtilisateursapis clsUtilisateursapis12 in clsUtilisateursapisRetours1)
                    {
                      Stock.BOJ.clsUtilisateursapis clsUtilisateursapisStock = new Stock.BOJ.clsUtilisateursapis();

                        clsUtilisateursapisStock.UT_UTILISATEURSAPIS2 = clsUtilisateursapis12.UT_UTILISATEURSAPIS2;
                        clsUtilisateursapisStock.clsObjetRetour = new Stock.Common.clsObjetRetour();
                        clsUtilisateursapisStock.UT_IDUTILISATEUR = clsUtilisateursapis12.UT_IDUTILISATEUR;
                        clsUtilisateursapisStock.UT_LOGIN = clsUtilisateursapis12.UT_LOGIN;
                        clsUtilisateursapisStock.UT_MOTDEPASSE = clsUtilisateursapis12.UT_MOTDEPASSE;
                        clsUtilisateursapisStock.UT_TOKEN = clsUtilisateursapis12.UT_TOKEN;
                        clsUtilisateursapisStock.UT_STATUT = clsUtilisateursapis12.UT_STATUT;
                        clsUtilisateursapisStock.UT_DATESAISIE = (clsUtilisateursapis12.UT_DATESAISIE.ToString() == "") ? "" : DateTime.Parse(clsUtilisateursapis12.UT_DATESAISIE.ToString()).ToShortDateString().Replace("/", "-");
                        if (clsUtilisateursapisStock.UT_DATESAISIE == "01-01-1900") clsUtilisateursapis12.UT_DATESAISIE = "";
                        clsUtilisateursapisStock.clsObjetRetour.SL_CODEMESSAGE = clsUtilisateursapis12.clsObjetRetour.SL_CODEMESSAGE.ToString();
                        clsUtilisateursapisStock.clsObjetRetour.SL_RESULTAT = clsUtilisateursapis12.clsObjetRetour.SL_RESULTAT.ToString();
                        clsUtilisateursapisStock.clsObjetRetour.SL_MESSAGE = clsUtilisateursapis12.clsObjetRetour.SL_MESSAGE.ToString();
                        clsUtilisateursapisStock.UT_TOKEN = clsUtilisateursapis12.UT_TOKEN;
                        clsUtilisateursapis1.Add(clsUtilisateursapisStock);
                    }
                    //=============
                    clsUtilisateursapisRetours1 = clsUtilisateursapisWSBLL.pvgSelectListe(clsDonnee, clsUtilisateursapis1 );
                    //=============
                    foreach (Stock.BOJ.clsUtilisateursapis clsUtilisateursapis12 in clsUtilisateursapisRetours1)
                    {
                        clsUtilisateursapis clsUtilisateursapisRetour = new clsUtilisateursapis();

                        clsUtilisateursapisRetour.UT_UTILISATEURSAPIS2 = clsUtilisateursapis12.UT_UTILISATEURSAPIS2;
                        clsUtilisateursapisRetour.clsObjetRetour = new Stock.Common.clsObjetRetour();
                        clsUtilisateursapisRetour.UT_IDUTILISATEUR = clsUtilisateursapis12.UT_IDUTILISATEUR;
                        clsUtilisateursapisRetour.UT_LOGIN = clsUtilisateursapis12.UT_LOGIN;
                        clsUtilisateursapisRetour.UT_MOTDEPASSE = clsUtilisateursapis12.UT_MOTDEPASSE;
                        clsUtilisateursapisRetour.UT_TOKEN = clsUtilisateursapis12.UT_TOKEN;
                        clsUtilisateursapisRetour.UT_STATUT = clsUtilisateursapis12.UT_STATUT;
                        clsUtilisateursapisRetour.UT_DATESAISIE = (clsUtilisateursapis12.UT_DATESAISIE.ToString() == "") ? "" : DateTime.Parse(clsUtilisateursapis12.UT_DATESAISIE.ToString()).ToShortDateString().Replace("/", "-");
                        if (clsUtilisateursapisRetour.UT_DATESAISIE == "01-01-1900") clsUtilisateursapis12.UT_DATESAISIE = "";
                        clsUtilisateursapisRetour.clsObjetRetour.SL_CODEMESSAGE = clsUtilisateursapis12.clsObjetRetour.SL_CODEMESSAGE.ToString();
                        clsUtilisateursapisRetour.clsObjetRetour.SL_RESULTAT = clsUtilisateursapis12.clsObjetRetour.SL_RESULTAT.ToString();
                        clsUtilisateursapisRetour.clsObjetRetour.SL_MESSAGE = clsUtilisateursapis12.clsObjetRetour.SL_MESSAGE.ToString();
                        clsUtilisateursapisRetour.UT_TOKEN = clsUtilisateursapis12.UT_TOKEN;
                        clsUtilisateursapisRetours.Add(clsUtilisateursapisRetour);
                    }
 
                    if (clsUtilisateursapisRetours.Count > 0)
                        if (clsUtilisateursapisRetours[0].clsObjetRetour.SL_RESULTAT == Stock.Common.clsDeclaration.ERROR_RESULTAT)
                        {
                            clsUtilisateursapisRetours[0].clsObjetRetour.SL_MESSAGE = Stock.Common.clsDeclaration.WS_NON_AUTORISE_COMPTE_INNEXISTANT;
                        }
                        else
                        {
                            if (clsUtilisateursapisRetours[0].UT_STATUT == Stock.Common.clsDeclaration.STATUT_VALIDE)
                                clsUtilisateursapisRetours[0].clsObjetRetour.SL_MESSAGE = Stock.Common.clsDeclaration.WS_AUTORISE;
                            else
                            {
                                clsUtilisateursapisRetours[0].clsObjetRetour.SL_RESULTAT = Stock.Common.clsDeclaration.ERROR_RESULTAT;
                                clsUtilisateursapisRetours[0].clsObjetRetour.SL_MESSAGE = Stock.Common.clsDeclaration.WS_NON_AUTORISE_COMPTE_INNACTIF;
                            }

                        }
                }
                catch (Exception Ex)
                {
                    clsUtilisateursapis clsUtilisateursapis1 = new clsUtilisateursapis();
                    clsUtilisateursapis1.clsObjetRetour = new Stock.Common.clsObjetRetour();
                    clsUtilisateursapis1.clsObjetRetour.SL_RESULTAT = Stock.Common.clsDeclaration.ERROR_RESULTAT;
                    clsUtilisateursapis1.clsObjetRetour.SL_MESSAGE = Stock.Common.clsDeclaration.TOKKEN_NULL+" "+ Ex.Message;
                    clsUtilisateursapisRetours.Add(clsUtilisateursapis1);
                    //Execution du log
                    clsLog.EcrireDansFichierLog("Error wsVerificationUsages :" + Ex.Message);
                }

            }
            
            return clsUtilisateursapisRetours;

        }
    }
}