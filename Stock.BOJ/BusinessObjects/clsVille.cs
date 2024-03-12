using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.BOJ
{
	public class clsVille
	{

        private string _VL_CODEVILLE = "";
		private string _ZN_CODEZONE = "";
		private string _VL_LIBELLE = "";
		private string _VL_DESCRIPTION = "";
        private string _VL_REFERENCE = "";


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
		public string VL_LIBELLE
		{
			get { return _VL_LIBELLE; }
			set { _VL_LIBELLE = value; }
		}
		public string VL_DESCRIPTION
		{
			get { return _VL_DESCRIPTION; }
			set { _VL_DESCRIPTION = value; }
		}

        public string VL_REFERENCE
        {
	        get { return _VL_REFERENCE; }
	        set { _VL_REFERENCE = value; }
        }

        public clsVille() {} 

		public clsVille(string VL_CODEVILLE,string ZN_CODEZONE,string VL_LIBELLE,string VL_DESCRIPTION,string VL_REFERENCE)
		{
			this.VL_CODEVILLE = VL_CODEVILLE;
			this.ZN_CODEZONE = ZN_CODEZONE;
			this.VL_LIBELLE = VL_LIBELLE;
			this.VL_DESCRIPTION = VL_DESCRIPTION;
            this.VL_REFERENCE = VL_REFERENCE;
		}

		public clsVille(clsVille clsVille)
		{
			VL_CODEVILLE = clsVille.VL_CODEVILLE;
			ZN_CODEZONE = clsVille.ZN_CODEZONE;
			VL_LIBELLE = clsVille.VL_LIBELLE;
			VL_DESCRIPTION = clsVille.VL_DESCRIPTION;
            VL_REFERENCE = clsVille.VL_REFERENCE;
		}
        }
}