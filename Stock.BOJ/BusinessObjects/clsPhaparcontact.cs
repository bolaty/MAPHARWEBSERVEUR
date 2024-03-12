using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsPhaparcontact
	{
		#region VARIABLES LOCALES

		private string _CT_CODECONTACT = "";
		private string _CT_NOM = "";
		private string _CT_PRENOM = "";
		private string _SR_CODESERVICE = "";
		private string _CT_FONCTION = "";
		private string _TC_CODETYPECONTACT = "";
		private string _CT_TELEPHONE = "";
		private string _CT_PORTABLE = "";
		private string _CT_FAX = "";
		private string _CT_EMAIL = "";
		private string _TP_CODETYPEPERSONNE = "";
        private string _AB_CODEAGENCEBANCAIRE = "";

		#endregion

		#region ACCESSEURS

		public string CT_CODECONTACT
		{
			get { return _CT_CODECONTACT; }
			set {  _CT_CODECONTACT = value; }
		}

		public string CT_NOM
		{
			get { return _CT_NOM; }
			set {  _CT_NOM = value; }
		}

		public string CT_PRENOM
		{
			get { return _CT_PRENOM; }
			set {  _CT_PRENOM = value; }
		}

		public string SR_CODESERVICE
		{
			get { return _SR_CODESERVICE; }
			set {  _SR_CODESERVICE = value; }
		}

		public string CT_FONCTION
		{
			get { return _CT_FONCTION; }
			set {  _CT_FONCTION = value; }
		}

		public string TC_CODETYPECONTACT
		{
			get { return _TC_CODETYPECONTACT; }
			set {  _TC_CODETYPECONTACT = value; }
		}

		public string CT_TELEPHONE
		{
			get { return _CT_TELEPHONE; }
			set {  _CT_TELEPHONE = value; }
		}

		public string CT_PORTABLE
		{
			get { return _CT_PORTABLE; }
			set {  _CT_PORTABLE = value; }
		}

		public string CT_FAX
		{
			get { return _CT_FAX; }
			set {  _CT_FAX = value; }
		}

		public string CT_EMAIL
		{
			get { return _CT_EMAIL; }
			set {  _CT_EMAIL = value; }
		}

		public string TP_CODETYPEPERSONNE
		{
			get { return _TP_CODETYPEPERSONNE; }
			set {  _TP_CODETYPEPERSONNE = value; }
		}


        public string AB_CODEAGENCEBANCAIRE
        {
            get { return _AB_CODEAGENCEBANCAIRE; }
            set { _AB_CODEAGENCEBANCAIRE = value; }
        }


		#endregion

		#region INSTANCIATEURS

		public clsPhaparcontact(){}
		
		public clsPhaparcontact(clsPhaparcontact clsPhaparcontact)
		{
			this.CT_CODECONTACT = clsPhaparcontact.CT_CODECONTACT;
			this.CT_NOM = clsPhaparcontact.CT_NOM;
			this.CT_PRENOM = clsPhaparcontact.CT_PRENOM;
			this.SR_CODESERVICE = clsPhaparcontact.SR_CODESERVICE;
			this.CT_FONCTION = clsPhaparcontact.CT_FONCTION;
			this.TC_CODETYPECONTACT = clsPhaparcontact.TC_CODETYPECONTACT;
			this.CT_TELEPHONE = clsPhaparcontact.CT_TELEPHONE;
			this.CT_PORTABLE = clsPhaparcontact.CT_PORTABLE;
			this.CT_FAX = clsPhaparcontact.CT_FAX;
			this.CT_EMAIL = clsPhaparcontact.CT_EMAIL;
			this.TP_CODETYPEPERSONNE = clsPhaparcontact.TP_CODETYPEPERSONNE;
            this.AB_CODEAGENCEBANCAIRE = clsPhaparcontact.AB_CODEAGENCEBANCAIRE;
		}

		#endregion

	}
}
