using Stock.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Stock.BOJ
{
	public class clsAgence : clsEntitieBase
    {

        private string _SO_CODESOCIETE = "";
		private string _AG_CODEAGENCE = "";
		private string _AG_AGENCECODE = "";
        private string _PY_CODEPAYS = "";
		private string _VL_CODEVILLE = "";
        private string _ZN_CODEZONE = "";
		private string _AG_RAISONSOCIAL = "";
		private string _AG_BOITEPOSTAL = "";
		private string _AG_ADRESSEGEOGRAPHIQUE = "";
        private string _AG_ADRESSEGEOGRAPHIQUE2 = "";
        private string _AG_ADRESSEGEOGRAPHIQUE3 = "";
		private string _AG_TELEPHONE = "";
		private string _AG_FAX = "";
		private string _AG_EMAIL = "";
		private string _AG_NUMEROAGREMENT = "";
		private string _AG_REFERENCE = "N";
		private DateTime _AG_DATECREATION = DateTime.Parse("01/01/1900");
		private string _AG_ACTIF = "O";
		private string _OP_CODEOPERATEUR = "";
        private string _AG_NUMCPTECONTIBUABLE = "";
        private string _RE_CODEREGIMEIMPOSITION = "";
        private string _AG_CENTREIMPOT = "";
        public string SO_CODESOCIETE
		{
			get { return _SO_CODESOCIETE; }
			set { _SO_CODESOCIETE = value; }
		}
		public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set { _AG_CODEAGENCE = value; }
		}
		public string AG_AGENCECODE
		{
			get { return _AG_AGENCECODE; }
			set { _AG_AGENCECODE = value; }
		}
        public string PY_CODEPAYS
        {
            get { return _PY_CODEPAYS; }
            set { _PY_CODEPAYS = value; }
        }
		public string VL_CODEVILLE
		{
			get { return _VL_CODEVILLE; }
			set { _VL_CODEVILLE = value; }
		}
        public string ZN_CODEZONE
		{
            get { return _ZN_CODEZONE; }
            set { _ZN_CODEZONE = value; }
		}
		public string AG_RAISONSOCIAL
		{
			get { return _AG_RAISONSOCIAL; }
			set { _AG_RAISONSOCIAL = value; }
		}
		public string AG_BOITEPOSTAL
		{
			get { return _AG_BOITEPOSTAL; }
			set { _AG_BOITEPOSTAL = value; }
		}
		public string AG_ADRESSEGEOGRAPHIQUE
		{
			get { return _AG_ADRESSEGEOGRAPHIQUE; }
			set { _AG_ADRESSEGEOGRAPHIQUE = value; }
		}

        public string AG_ADRESSEGEOGRAPHIQUE2
		{
            get { return _AG_ADRESSEGEOGRAPHIQUE2; }
            set { _AG_ADRESSEGEOGRAPHIQUE2 = value; }
		}

        public string AG_ADRESSEGEOGRAPHIQUE3
		{
            get { return _AG_ADRESSEGEOGRAPHIQUE3; }
            set { _AG_ADRESSEGEOGRAPHIQUE3 = value; }
		}
		public string AG_TELEPHONE
		{
			get { return _AG_TELEPHONE; }
			set { _AG_TELEPHONE = value; }
		}
		public string AG_FAX
		{
			get { return _AG_FAX; }
			set { _AG_FAX = value; }
		}
		public string AG_EMAIL
		{
			get { return _AG_EMAIL; }
			set { _AG_EMAIL = value; }
		}
		public string AG_NUMEROAGREMENT
		{
			get { return _AG_NUMEROAGREMENT; }
			set { _AG_NUMEROAGREMENT = value; }
		}
		public string AG_REFERENCE
		{
			get { return _AG_REFERENCE; }
			set { _AG_REFERENCE = value; }
		}
		public DateTime AG_DATECREATION
		{
			get { return _AG_DATECREATION; }
			set { _AG_DATECREATION = value; }
		}
		public string AG_ACTIF
		{
			get { return _AG_ACTIF; }
			set { _AG_ACTIF = value; }
		}
		public string OP_CODEOPERATEUR
		{
			get { return _OP_CODEOPERATEUR; }
			set { _OP_CODEOPERATEUR = value; }
		}

        public string AG_NUMCPTECONTIBUABLE
        {
            get { return _AG_NUMCPTECONTIBUABLE; }
	        set { _AG_NUMCPTECONTIBUABLE= value; }
        }

        public string RE_CODEREGIMEIMPOSITION
        {
            get { return _RE_CODEREGIMEIMPOSITION; }
	        set { _RE_CODEREGIMEIMPOSITION = value; }
        }
        public string AG_CENTREIMPOT
        {
            get { return _AG_CENTREIMPOT; }
	        set { _AG_CENTREIMPOT = value; }
        }

        public clsAgence() {}

        public clsAgence(string SO_CODESOCIETE, string AG_CODEAGENCE, string AG_AGENCECODE, string _PY_CODEPAYS, string VL_CODEVILLE, string ZN_CODEZONE, string AG_RAISONSOCIAL, string AG_BOITEPOSTAL, string AG_ADRESSEGEOGRAPHIQUE, string AG_ADRESSEGEOGRAPHIQUE2, string AG_ADRESSEGEOGRAPHIQUE3, string AG_TELEPHONE, string AG_FAX, string AG_EMAIL, string AG_NUMEROAGREMENT, string AG_REFERENCE, DateTime AG_DATECREATION, string AG_ACTIF, string OP_CODEOPERATEUR, string AG_NUMCPTECONTIBUABLE, string RE_CODEREGIMEIMPOSITION,string AG_CENTREIMPOT)
		{
			this.SO_CODESOCIETE = SO_CODESOCIETE;
			this.AG_CODEAGENCE = AG_CODEAGENCE;
			this.AG_AGENCECODE = AG_AGENCECODE;
            this._PY_CODEPAYS = _PY_CODEPAYS;
			this.VL_CODEVILLE = VL_CODEVILLE;
            this.ZN_CODEZONE = ZN_CODEZONE;
			this.AG_RAISONSOCIAL = AG_RAISONSOCIAL;
			this.AG_BOITEPOSTAL = AG_BOITEPOSTAL;
			this.AG_ADRESSEGEOGRAPHIQUE = AG_ADRESSEGEOGRAPHIQUE;
            this.AG_ADRESSEGEOGRAPHIQUE2 = AG_ADRESSEGEOGRAPHIQUE2;
            this.AG_ADRESSEGEOGRAPHIQUE3 = AG_ADRESSEGEOGRAPHIQUE3;
			this.AG_TELEPHONE = AG_TELEPHONE;
			this.AG_FAX = AG_FAX;
			this.AG_EMAIL = AG_EMAIL;
			this.AG_NUMEROAGREMENT = AG_NUMEROAGREMENT;
			this.AG_REFERENCE = AG_REFERENCE;
			this.AG_DATECREATION = AG_DATECREATION;
			this.AG_ACTIF = AG_ACTIF;
			this.OP_CODEOPERATEUR = OP_CODEOPERATEUR;
            this.AG_NUMCPTECONTIBUABLE = AG_NUMCPTECONTIBUABLE;
            this.RE_CODEREGIMEIMPOSITION = RE_CODEREGIMEIMPOSITION;
            this.AG_CENTREIMPOT = AG_CENTREIMPOT;


		}

		public clsAgence(clsAgence clsAgence)
		{
			SO_CODESOCIETE = clsAgence.SO_CODESOCIETE;
			AG_CODEAGENCE = clsAgence.AG_CODEAGENCE;
			AG_AGENCECODE = clsAgence.AG_AGENCECODE;
            _PY_CODEPAYS = clsAgence._PY_CODEPAYS;
			VL_CODEVILLE = clsAgence.VL_CODEVILLE;
            ZN_CODEZONE = clsAgence.ZN_CODEZONE;
			AG_RAISONSOCIAL = clsAgence.AG_RAISONSOCIAL;
			AG_BOITEPOSTAL = clsAgence.AG_BOITEPOSTAL;
			AG_ADRESSEGEOGRAPHIQUE = clsAgence.AG_ADRESSEGEOGRAPHIQUE;
            AG_ADRESSEGEOGRAPHIQUE2 = clsAgence.AG_ADRESSEGEOGRAPHIQUE2;
            AG_ADRESSEGEOGRAPHIQUE3 = clsAgence.AG_ADRESSEGEOGRAPHIQUE3;
			AG_TELEPHONE = clsAgence.AG_TELEPHONE;
			AG_FAX = clsAgence.AG_FAX;
			AG_EMAIL = clsAgence.AG_EMAIL;
			AG_NUMEROAGREMENT = clsAgence.AG_NUMEROAGREMENT;
			AG_REFERENCE = clsAgence.AG_REFERENCE;
			AG_DATECREATION = clsAgence.AG_DATECREATION;
			AG_ACTIF = clsAgence.AG_ACTIF;
			OP_CODEOPERATEUR = clsAgence.OP_CODEOPERATEUR;
            AG_NUMCPTECONTIBUABLE = clsAgence.AG_NUMCPTECONTIBUABLE;
            RE_CODEREGIMEIMPOSITION = clsAgence.RE_CODEREGIMEIMPOSITION;
            AG_CENTREIMPOT = clsAgence.AG_CENTREIMPOT;

		}
        }
}