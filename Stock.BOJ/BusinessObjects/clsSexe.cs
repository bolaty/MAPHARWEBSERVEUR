using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.BOJ
{
	public class clsSexe
	{

        private string _SX_CODESEXE = "";
		private string _SX_LIBELLE = "";



        public string SX_CODESEXE
		{
			get { return _SX_CODESEXE; }
			set { _SX_CODESEXE = value; }
		}
		public string SX_LIBELLE
		{
			get { return _SX_LIBELLE; }
			set { _SX_LIBELLE = value; }
		}



        public clsSexe() {} 

		public clsSexe(string SX_CODESEXE,string SX_LIBELLE)
		{
			this.SX_CODESEXE = SX_CODESEXE;
			this.SX_LIBELLE = SX_LIBELLE;
		}

		public clsSexe(clsSexe clsSexe)
		{
			SX_CODESEXE = clsSexe.SX_CODESEXE;
			SX_LIBELLE = clsSexe.SX_LIBELLE;
		}
        }
}