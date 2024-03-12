using Stock.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Stock.BOJ
{
	public class clsCommune: clsEntitieBase
	{

        private string _CO_CODECOMMUNE = "";
		private string _VL_CODEVILLE = "";
		private string _CO_LIBELLE = "";
		private string _CO_DESCRIPTION = "";
        private string _CO_REFERENCE= "N";
        private string _ZN_CODEZONE = "";

        public string CO_CODECOMMUNE
		{
			get { return _CO_CODECOMMUNE; }
			set { _CO_CODECOMMUNE = value; }
		}
		public string VL_CODEVILLE
		{
			get { return _VL_CODEVILLE; }
			set { _VL_CODEVILLE = value; }
		}
		public string CO_LIBELLE
		{
			get { return _CO_LIBELLE; }
			set { _CO_LIBELLE = value; }
		}
		public string CO_DESCRIPTION
		{
			get { return _CO_DESCRIPTION; }
			set { _CO_DESCRIPTION = value; }
		}
        public string CO_REFERENCE
		{
            get { return _CO_REFERENCE; }
            set { _CO_REFERENCE = value; }
		}
        public string ZN_CODEZONE
        {
            get { return _ZN_CODEZONE; }
            set { _ZN_CODEZONE = value; }
		}

        public clsCommune() {}

       

		public clsCommune(clsCommune clsCommune)
		{
			CO_CODECOMMUNE = clsCommune.CO_CODECOMMUNE;
			VL_CODEVILLE = clsCommune.VL_CODEVILLE;
			CO_LIBELLE = clsCommune.CO_LIBELLE;
			CO_DESCRIPTION = clsCommune.CO_DESCRIPTION;
            CO_REFERENCE = clsCommune.CO_REFERENCE;
            ZN_CODEZONE = clsCommune.ZN_CODEZONE;
		}
        }
}