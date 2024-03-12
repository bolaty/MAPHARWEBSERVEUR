using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace TontineMobile.BOJ
{
	public class clsUserNewPassword
	{
		#region VARIABLES LOCALES

        private string _AG_CODEAGENCE = "";
        private string _AG_RAISONSOCIAL = "";
        private string _AG_TELEPHONE = "";
        private string _AG_BOITEPOSTAL = "";
        private string _SL_LOGIN = "";
        private string _SL_MOTPASSE = "";
        private string _CL_CODECLIENT = "";
        private string _CL_NOMCLIENT = "";
        private string _CL_IDCLIENT = "";
        private string _CL_PRENOMCLIENT = "";
        private string _CL_TELEPHONE = "";
        private string _CL_EMAIL = "";
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



        public string CL_CODECLIENT
        {
            get { return _CL_CODECLIENT; }
            set { _CL_CODECLIENT = value; }
        }

        public string CL_IDCLIENT
        {
            get { return _CL_IDCLIENT; }
            set { _CL_IDCLIENT = value; }
        }

        public string CL_NOMCLIENT
        {
            get { return _CL_NOMCLIENT; }
            set { _CL_NOMCLIENT = value; }
        }
        public string CL_PRENOMCLIENT
        {
            get { return _CL_PRENOMCLIENT; }
            set { _CL_PRENOMCLIENT = value; }
        }
        public string CL_TELEPHONE
        {
            get { return _CL_TELEPHONE; }
            set { _CL_TELEPHONE = value; }
        }
        public string CL_EMAIL
        {
            get { return _CL_EMAIL; }
            set { _CL_EMAIL = value; }
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

		public clsUserNewPassword(){}
       
		public clsUserNewPassword(clsUserNewPassword clsUserNewPassword)
		{

            this.AG_CODEAGENCE = clsUserNewPassword.AG_CODEAGENCE;
            this.AG_RAISONSOCIAL = clsUserNewPassword.AG_RAISONSOCIAL;
            this.AG_TELEPHONE = clsUserNewPassword.AG_TELEPHONE;
            this.AG_BOITEPOSTAL = clsUserNewPassword.AG_BOITEPOSTAL;
            this.SL_LOGIN = clsUserNewPassword.SL_LOGIN;
            this.SL_MOTPASSE = clsUserNewPassword.SL_MOTPASSE;
            this.CL_CODECLIENT = clsUserNewPassword.CL_CODECLIENT;
            this.CL_IDCLIENT = clsUserNewPassword.CL_IDCLIENT;
            this.CL_NOMCLIENT = clsUserNewPassword.CL_NOMCLIENT;
            this.CL_PRENOMCLIENT = clsUserNewPassword.CL_PRENOMCLIENT;
            this.CL_TELEPHONE = clsUserNewPassword.CL_TELEPHONE;
            this.CL_EMAIL = clsUserNewPassword.CL_EMAIL;
            this.SL_MESSAGE = clsUserNewPassword.SL_MESSAGE;
            this.SL_RESULTAT = clsUserNewPassword.SL_RESULTAT;

		}

		#endregion

	}
}
