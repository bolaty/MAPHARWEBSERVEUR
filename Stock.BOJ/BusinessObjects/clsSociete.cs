using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.BOJ
{
	public class clsSociete
	{

        private string _SO_CODESOCIETE = "";
        //private string _TY_CODETYPEINSTITUTION = "";
		private string _SO_RAISONSOCIAL = "";
		private string _SO_BOITEPOSTAL = "";
		private string _SO_TELEPHONE = "";
		private string _SO_DIRECTEUR = "";
		private string _SO_EMAIL = "";
		private string _SO_SITEWEB = "";
		private string _SO_ACTIF = "";
        private string _SO_SLOGAN = "";
        private DateTime _DATESYSTEMSERVEUR = DateTime.Parse("01/01/1900");


        public string SO_CODESOCIETE
        {
            get { return _SO_CODESOCIETE; }
            set { _SO_CODESOCIETE = value; }
        }

        //public string TY_CODETYPEINSTITUTION
        //{
        //    get { return _TY_CODETYPEINSTITUTION; }
        //    set { _TY_CODETYPEINSTITUTION = value; }
        //}

        public string SO_RAISONSOCIAL
		{
			get { return _SO_RAISONSOCIAL; }
			set { _SO_RAISONSOCIAL = value; }
		}
		public string SO_BOITEPOSTAL
		{
			get { return _SO_BOITEPOSTAL; }
			set { _SO_BOITEPOSTAL = value; }
		}
		public string SO_TELEPHONE
		{
			get { return _SO_TELEPHONE; }
			set { _SO_TELEPHONE = value; }
		}
		public string SO_DIRECTEUR
		{
			get { return _SO_DIRECTEUR; }
			set { _SO_DIRECTEUR = value; }
		}
		public string SO_EMAIL
		{
			get { return _SO_EMAIL; }
			set { _SO_EMAIL = value; }
		}
		public string SO_SITEWEB
		{
			get { return _SO_SITEWEB; }
			set { _SO_SITEWEB = value; }
		}
		public string SO_ACTIF
		{
			get { return _SO_ACTIF; }
			set { _SO_ACTIF = value; }
		}

        public string SO_SLOGAN
        {
            get { return _SO_SLOGAN; }
            set { _SO_SLOGAN = value; }
        }
        public DateTime DATESYSTEMSERVEUR
		{
            get { return _DATESYSTEMSERVEUR; }
            set { _DATESYSTEMSERVEUR = value; }
		}


        public clsSociete() {}

		public clsSociete(clsSociete clsSociete)
		{
			SO_CODESOCIETE = clsSociete.SO_CODESOCIETE;
			SO_RAISONSOCIAL = clsSociete.SO_RAISONSOCIAL;
            //TY_CODETYPEINSTITUTION = clsSociete.TY_CODETYPEINSTITUTION;
			SO_BOITEPOSTAL = clsSociete.SO_BOITEPOSTAL;
			SO_TELEPHONE = clsSociete.SO_TELEPHONE;
			SO_DIRECTEUR = clsSociete.SO_DIRECTEUR;
			SO_EMAIL = clsSociete.SO_EMAIL;
			SO_SITEWEB = clsSociete.SO_SITEWEB;
			SO_ACTIF = clsSociete.SO_ACTIF;
            SO_SLOGAN = clsSociete.SO_SLOGAN;
            DATESYSTEMSERVEUR = clsSociete.DATESYSTEMSERVEUR;
		}
        }
}