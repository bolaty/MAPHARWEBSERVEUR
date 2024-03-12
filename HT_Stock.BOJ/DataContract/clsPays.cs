using Stock.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Stock.BOJ
{
	public class clsPays : clsEntitieBase
    {

        private string _PY_CODEPAYS = "";
		private string _PY_CODEPOSTALE = "";
		private string _DE_CODEDEVISE = "";
		private string _ZT_CODEZONE = "";
		private string _PY_LIBELLE = "";
		private string _PY_LIBELLENATIONALITE = "";
		private string _PY_REFERENCE = "";



        public string PY_CODEPAYS
		{
			get { return _PY_CODEPAYS; }
			set { _PY_CODEPAYS = value; }
		}
		public string PY_CODEPOSTALE
		{
			get { return _PY_CODEPOSTALE; }
			set { _PY_CODEPOSTALE = value; }
		}
		public string DE_CODEDEVISE
		{
			get { return _DE_CODEDEVISE; }
			set { _DE_CODEDEVISE = value; }
		}
		public string ZT_CODEZONE
		{
			get { return _ZT_CODEZONE; }
			set { _ZT_CODEZONE = value; }
		}
		public string PY_LIBELLE
		{
			get { return _PY_LIBELLE; }
			set { _PY_LIBELLE = value; }
		}
		public string PY_LIBELLENATIONALITE
		{
			get { return _PY_LIBELLENATIONALITE; }
			set { _PY_LIBELLENATIONALITE = value; }
		}
		public string PY_REFERENCE
		{
			get { return _PY_REFERENCE; }
			set { _PY_REFERENCE = value; }
		}



        public clsPays() {} 

		public clsPays(string PY_CODEPAYS,string PY_CODEPOSTALE,string DE_CODEDEVISE,string ZT_CODEZONE,string PY_LIBELLE,string PY_LIBELLENATIONALITE,string PY_REFERENCE)
		{
			this.PY_CODEPAYS = PY_CODEPAYS;
			this.PY_CODEPOSTALE = PY_CODEPOSTALE;
			this.DE_CODEDEVISE = DE_CODEDEVISE;
			this.ZT_CODEZONE = ZT_CODEZONE;
			this.PY_LIBELLE = PY_LIBELLE;
			this.PY_LIBELLENATIONALITE = PY_LIBELLENATIONALITE;
			this.PY_REFERENCE = PY_REFERENCE;
		}

		public clsPays(clsPays clsPays)
		{
			PY_CODEPAYS = clsPays.PY_CODEPAYS;
			PY_CODEPOSTALE = clsPays.PY_CODEPOSTALE;
			DE_CODEDEVISE = clsPays.DE_CODEDEVISE;
			ZT_CODEZONE = clsPays.ZT_CODEZONE;
			PY_LIBELLE = clsPays.PY_LIBELLE;
			PY_LIBELLENATIONALITE = clsPays.PY_LIBELLENATIONALITE;
			PY_REFERENCE = clsPays.PY_REFERENCE;
		}
        }
}