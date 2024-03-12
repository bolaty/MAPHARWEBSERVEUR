using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsVehicule
	{
		#region VARIABLES LOCALES

		private string _AG_CODEAGENCE = "";
        private string _EN_CODEENTREPOT = "";
		private string _VH_CODEVEHICULE = "";
		private string _VH_MATRICULE = "";
		private string _TVH_CODETYPE = "";
        private string _TVH_LIBELE = "";

		#endregion

		#region ACCESSEURS

		public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set {  _AG_CODEAGENCE = value; }
		}

        public string EN_CODEENTREPOT
        {
            get { return _EN_CODEENTREPOT; }
            set { _EN_CODEENTREPOT = value; }
        }

		public string VH_CODEVEHICULE
		{
			get { return _VH_CODEVEHICULE; }
			set {  _VH_CODEVEHICULE = value; }
		}

		public string VH_MATRICULE
		{
			get { return _VH_MATRICULE; }
			set {  _VH_MATRICULE = value; }
		}

		public string TVH_CODETYPE
		{
			get { return _TVH_CODETYPE; }
			set {  _TVH_CODETYPE = value; }
		}

        public string TVH_LIBELE
        {
            get { return _TVH_LIBELE; }
            set { _TVH_LIBELE = value; }
        }


		#endregion

		#region INSTANCIATEURS

		public clsVehicule(){}
       
		public clsVehicule(clsVehicule clsVehicule)
		{
			this.AG_CODEAGENCE = clsVehicule.AG_CODEAGENCE;
            this.EN_CODEENTREPOT = clsVehicule.EN_CODEENTREPOT;
			this.VH_CODEVEHICULE = clsVehicule.VH_CODEVEHICULE;
			this.VH_MATRICULE = clsVehicule.VH_MATRICULE;
			this.TVH_CODETYPE = clsVehicule.TVH_CODETYPE;
            this.TVH_LIBELE = clsVehicule.TVH_LIBELE;


		}

		#endregion

	}
}
