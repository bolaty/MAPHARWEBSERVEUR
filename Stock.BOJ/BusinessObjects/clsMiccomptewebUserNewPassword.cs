using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.BOJ
{
	public class clsMiccomptewebUserNewPassword
	{

        #region VARIABLES LOCALES

        private string _AG_CODEAGENCE = "";
        private string _AG_RAISONSOCIAL = "";
        private string _AG_TELEPHONE = "";
        private string _AG_BOITEPOSTAL = "";
        private string _SL_LOGIN = "";
        private string _SL_MOTPASSE = "";
        private string _OP_CODEOPERATEUR = "";
        private string _OP_NOMPRENOM = "";
        private string _OP_TELEPHONE = "";
        private string _OP_EMAIL = "";
        private string _CL_IDCLIENT = "";
        private string _SL_CODEMESSAGE = "";
        private string _SL_MESSAGE = "";
        private string _SL_RESULTAT = "";
        #endregion

        #region ACCESSEURS




        public string AG_CODEAGENCE
        {
            get { return _AG_CODEAGENCE; }
            set { _AG_CODEAGENCE = value; }
        }
        public string AG_RAISONSOCIAL
        {
            get { return _AG_RAISONSOCIAL; }
            set { _AG_RAISONSOCIAL = value; }
        }
        public string AG_TELEPHONE
        {
            get { return _AG_TELEPHONE; }
            set { _AG_TELEPHONE = value; }
        }
        public string AG_BOITEPOSTAL
        {
            get { return _AG_BOITEPOSTAL; }
            set { _AG_BOITEPOSTAL = value; }
        }
        public string SL_LOGIN
        {
            get { return _SL_LOGIN; }
            set { _SL_LOGIN = value; }
        }

        public string SL_MOTPASSE
        {
            get { return _SL_MOTPASSE; }
            set { _SL_MOTPASSE = value; }
        }


        public string CL_IDCLIENT
        {
            get { return _CL_IDCLIENT; }
            set { _CL_IDCLIENT = value; }
        }

        public string OP_CODEOPERATEUR
        {
            get { return _OP_CODEOPERATEUR; }
            set { _OP_CODEOPERATEUR = value; }
        }
     
        public string OP_NOMPRENOM
        {
            get { return _OP_NOMPRENOM; }
            set { _OP_NOMPRENOM = value; }
        }

        public string OP_TELEPHONE
        {
            get { return _OP_TELEPHONE; }
            set { _OP_TELEPHONE = value; }
        }
        public string OP_EMAIL
        {
            get { return _OP_EMAIL; }
            set { _OP_EMAIL = value; }
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



        #endregion

        #region INSTANCIATEURS

        public clsMiccomptewebUserNewPassword() { }

        public clsMiccomptewebUserNewPassword(clsMiccomptewebUserNewPassword clsMiccomptewebUserNewPassword)
        {

            this.AG_CODEAGENCE = clsMiccomptewebUserNewPassword.AG_CODEAGENCE;
            this.AG_RAISONSOCIAL = clsMiccomptewebUserNewPassword.AG_RAISONSOCIAL;
            this.AG_TELEPHONE = clsMiccomptewebUserNewPassword.AG_TELEPHONE;
            this.AG_BOITEPOSTAL = clsMiccomptewebUserNewPassword.AG_BOITEPOSTAL;
            this.SL_LOGIN = clsMiccomptewebUserNewPassword.SL_LOGIN;
            this.SL_MOTPASSE = clsMiccomptewebUserNewPassword.SL_MOTPASSE;
            this.OP_CODEOPERATEUR = clsMiccomptewebUserNewPassword.OP_CODEOPERATEUR;
            this.CL_IDCLIENT = clsMiccomptewebUserNewPassword.CL_IDCLIENT;
            this.OP_NOMPRENOM = clsMiccomptewebUserNewPassword.OP_NOMPRENOM;
            this.OP_TELEPHONE = clsMiccomptewebUserNewPassword.OP_TELEPHONE;
            this.OP_EMAIL = clsMiccomptewebUserNewPassword.OP_EMAIL;
            this.SL_CODEMESSAGE = clsMiccomptewebUserNewPassword.SL_CODEMESSAGE;
            this.SL_MESSAGE = clsMiccomptewebUserNewPassword.SL_MESSAGE;
            this.SL_RESULTAT = clsMiccomptewebUserNewPassword.SL_RESULTAT;

        }

        #endregion
    }
}