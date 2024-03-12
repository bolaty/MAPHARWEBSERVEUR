using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsPhainventaire
	{
		#region VARIABLES LOCALES

        private double _INV_CODEINVENTAIRE = 0;

		private string _AG_CODEAGENCE = "";
		private DateTime _INV_DATEINVENTAIRE = DateTime.Parse("01/01/1900");
        private string _OP_CODEOPERATEUR = "";
        private string _INVR_CODERAISONINVENTAIRE = "";
		private DateTime _INV_DATEINVENTAIRECLOTURE = DateTime.Parse("01/01/1900");
        private string _INV_CODEINVENTAIREACLOTURER = "";

		#endregion

		#region ACCESSEURS

		public double INV_CODEINVENTAIRE
		{
			get { return _INV_CODEINVENTAIRE; }
			set {  _INV_CODEINVENTAIRE = value; }
		}

		public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set {  _AG_CODEAGENCE = value; }
		}

		public DateTime INV_DATEINVENTAIRE
		{
			get { return _INV_DATEINVENTAIRE; }
			set {  _INV_DATEINVENTAIRE = value; }
		}

        public string OP_CODEOPERATEUR
		{
			get { return _OP_CODEOPERATEUR; }
			set {  _OP_CODEOPERATEUR = value; }
		}

        public string INVR_CODERAISONINVENTAIRE
        {
	        get { return _INVR_CODERAISONINVENTAIRE; }
	        set { _INVR_CODERAISONINVENTAIRE = value; }
        }


        public DateTime INV_DATEINVENTAIRECLOTURE
        {
	        get { return _INV_DATEINVENTAIRECLOTURE; }
	        set { _INV_DATEINVENTAIRECLOTURE = value; }
        }

        public string INV_CODEINVENTAIREACLOTURER
        {
	        get { return _INV_CODEINVENTAIREACLOTURER; }
	        set { _INV_CODEINVENTAIREACLOTURER = value; }
        }


		#endregion

		#region INSTANCIATEURS

		public clsPhainventaire(){}
       
		public clsPhainventaire(clsPhainventaire clsPhainventaire)
		{
			this.INV_CODEINVENTAIRE = clsPhainventaire.INV_CODEINVENTAIRE;
			this.AG_CODEAGENCE = clsPhainventaire.AG_CODEAGENCE;
			this.INV_DATEINVENTAIRE = clsPhainventaire.INV_DATEINVENTAIRE;
			this.OP_CODEOPERATEUR = clsPhainventaire.OP_CODEOPERATEUR;
            this.INVR_CODERAISONINVENTAIRE = clsPhainventaire.INVR_CODERAISONINVENTAIRE;
            this.INV_DATEINVENTAIRECLOTURE = clsPhainventaire.INV_DATEINVENTAIRECLOTURE;
            this.INV_CODEINVENTAIREACLOTURER = clsPhainventaire.INV_CODEINVENTAIREACLOTURER;

		}

		#endregion

	}
}
