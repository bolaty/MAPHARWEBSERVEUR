using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Stock.BOJ
{
    public class clsReedition
    {
        #region VARIABLES LOCALES


        private string _MC_DATEPIECE = "";
        private string _NUMEROBORDEREAU = "";
        private string _AG_RAISONSOCIAL = "";
        private string _MC_LIBELLEOPERATION = "";
        private string _OP_NOMPRENOM = "";
        private double _MC_MONTANTDEBIT = 0;
        private double _MC_MONTANTCREDIT = 0;
        private String _SOLDE = "0";
        private double _MC_MONTANTOPERATION = 0;
        private String _MC_MONTANTOPERATIONFT = "0";

        private string _CO_INTITULECOMPTERECU = "";
        private string _NUMEROCOMPTE = "";
        private string _PI_LIBELLEPIECE = "";

        private string _MC_NOMTIERS = "";
        private string _SL_CODEMESSAGE = "";
        private string _SL_MESSAGE = "";
        private string _SL_RESULTAT = "";

        private string _SL_RESULTATAPI = "";
        private string _SL_MESSAGEAPI = "";

        private string _CO_CODECOMPTE = "";
        private string _OB_NOMOBJET = "";
        private string _OP_CODEOPERATEUR = "";
        private string _PV_CODEPOINTVENTE = "";
        private string _SL_MESSAGECLIENT = "";
        private string _SL_LIBELLE1 = "";
        private string _SL_LIBELLE2 = "";

        #endregion

        #region ACCESSEURS



        public string MC_DATEPIECE
        {
            get { return _MC_DATEPIECE; }
            set { _MC_DATEPIECE = value; }
        }

        public string NUMEROBORDEREAU
        {
            get { return _NUMEROBORDEREAU; }
            set { _NUMEROBORDEREAU = value; }
        }



        public string CO_INTITULECOMPTERECU
        {
            get { return _CO_INTITULECOMPTERECU; }
            set { _CO_INTITULECOMPTERECU = value; }
        }

        public string NUMEROCOMPTE
        {
            get { return _NUMEROCOMPTE; }
            set { _NUMEROCOMPTE = value; }
        }

        public string PI_LIBELLEPIECE
        {
            get { return _PI_LIBELLEPIECE; }
            set { _PI_LIBELLEPIECE = value; }
        }

        public string AG_RAISONSOCIAL
        {
            get { return _AG_RAISONSOCIAL; }
            set { _AG_RAISONSOCIAL = value; }
        }
        public string OP_NOMPRENOM
        {
            get { return _OP_NOMPRENOM; }
            set { _OP_NOMPRENOM = value; }
        }
        public string MC_LIBELLEOPERATION
        {
            get { return _MC_LIBELLEOPERATION; }
            set { _MC_LIBELLEOPERATION = value; }
        }
        public double MC_MONTANTDEBIT
        {
            get { return _MC_MONTANTDEBIT; }
            set { _MC_MONTANTDEBIT = value; }
        }
        public double MC_MONTANTCREDIT
        {
            get { return _MC_MONTANTCREDIT; }
            set { _MC_MONTANTCREDIT = value; }
        }
        public String SOLDE
        {
            get { return _SOLDE; }
            set { _SOLDE = value; }
        }
        public double MC_MONTANTOPERATION
        {
            get { return _MC_MONTANTOPERATION; }
            set { _MC_MONTANTOPERATION = value; }
        }

        public string MC_MONTANTOPERATIONFT
        {
            get { return _MC_MONTANTOPERATIONFT; }
            set { _MC_MONTANTOPERATIONFT = value; }
        }



        public string MC_NOMTIERS
        {
            get { return _MC_NOMTIERS; }
            set { _MC_NOMTIERS = value; }
        }


        public string SL_CODEMESSAGE
        {
            get { return _SL_CODEMESSAGE; }
            set { _SL_CODEMESSAGE = value; }
        }

        public string SL_MESSAGE
        {
            get { return _SL_MESSAGE; }
            set { _SL_MESSAGE = value; }
        }


        public string SL_RESULTAT
        {
            get { return _SL_RESULTAT; }
            set { _SL_RESULTAT = value; }
        }

        public string SL_RESULTATAPI
        {
            get { return _SL_RESULTATAPI; }
            set { _SL_RESULTATAPI = value; }
        }

        public string SL_MESSAGEAPI
        {
            get { return _SL_MESSAGEAPI; }
            set { _SL_MESSAGEAPI = value; }
        }


        public string PV_CODEPOINTVENTE
        {
            get { return _PV_CODEPOINTVENTE; }
            set { _PV_CODEPOINTVENTE = value; }
        }

        public string CO_CODECOMPTE
        {
            get { return _CO_CODECOMPTE; }
            set { _CO_CODECOMPTE = value; }
        }

        public string OB_NOMOBJET
        {
            get { return _OB_NOMOBJET; }
            set { _OB_NOMOBJET = value; }
        }

        public string OP_CODEOPERATEUR
        {
            get { return _OP_CODEOPERATEUR; }
            set { _OP_CODEOPERATEUR = value; }
        }
        public string SL_MESSAGECLIENT
        {
            get { return _SL_MESSAGECLIENT; }
            set { _SL_MESSAGECLIENT = value; }
        }
        public string SL_LIBELLE1
        {
            get { return _SL_LIBELLE1; }
            set { _SL_LIBELLE1 = value; }
        }
        public string SL_LIBELLE2
        {
            get { return _SL_LIBELLE2; }
            set { _SL_LIBELLE2 = value; }
        }

        #endregion

        #region INSTANCIATEURS

        public clsReedition() { }

        public clsReedition(clsReedition clsReedition)
        {

            this.MC_DATEPIECE = clsReedition.MC_DATEPIECE;
            this.NUMEROBORDEREAU = clsReedition.NUMEROBORDEREAU;
            this.AG_RAISONSOCIAL = clsReedition.AG_RAISONSOCIAL;
            this.MC_LIBELLEOPERATION = clsReedition.MC_LIBELLEOPERATION;
            this.OP_NOMPRENOM = clsReedition.OP_NOMPRENOM;
            this.MC_MONTANTDEBIT = clsReedition.MC_MONTANTDEBIT;
            this.MC_MONTANTCREDIT = clsReedition.MC_MONTANTCREDIT;
            this.SOLDE = clsReedition.SOLDE;
            this.MC_MONTANTOPERATION = clsReedition.MC_MONTANTOPERATION;
            this._MC_MONTANTOPERATIONFT = clsReedition._MC_MONTANTOPERATIONFT;

            this.CO_INTITULECOMPTERECU = clsReedition.CO_INTITULECOMPTERECU;
            this.NUMEROCOMPTE = clsReedition.NUMEROCOMPTE;
            this.PI_LIBELLEPIECE = clsReedition.PI_LIBELLEPIECE;

            this.MC_NOMTIERS = clsReedition.MC_NOMTIERS;
            this.SL_CODEMESSAGE = clsReedition.SL_CODEMESSAGE;
            this.SL_MESSAGE = clsReedition.SL_MESSAGE;
            this.SL_RESULTAT = clsReedition.SL_RESULTAT;

            this.SL_RESULTATAPI = clsReedition.SL_RESULTATAPI;
            this.SL_MESSAGEAPI = clsReedition.SL_MESSAGEAPI;
            this.PV_CODEPOINTVENTE = clsReedition.PV_CODEPOINTVENTE;
            this.CO_CODECOMPTE = clsReedition.CO_CODECOMPTE;
            this.OB_NOMOBJET = clsReedition.OB_NOMOBJET;
            this.OP_CODEOPERATEUR = clsReedition.OP_CODEOPERATEUR;
            this.SL_MESSAGECLIENT = clsReedition.SL_MESSAGECLIENT;
            this.SL_LIBELLE2 = clsReedition.SL_LIBELLE2;
            this.SL_LIBELLE1 = clsReedition.SL_LIBELLE1;

        }

        #endregion

    }
}