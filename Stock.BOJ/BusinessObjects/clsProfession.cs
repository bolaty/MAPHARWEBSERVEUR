using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.BOJ
{
	public class clsProfession
	{

        private string _PF_CODEPROFESSION = "";
		private string _PF_LIBELLE = "";



        public string PF_CODEPROFESSION
		{
			get { return _PF_CODEPROFESSION; }
			set { _PF_CODEPROFESSION = value; }
		}
		public string PF_LIBELLE
		{
			get { return _PF_LIBELLE; }
			set { _PF_LIBELLE = value; }
		}



        public clsProfession() {} 

		public clsProfession(string PF_CODEPROFESSION,string PF_LIBELLE)
		{
			this.PF_CODEPROFESSION = PF_CODEPROFESSION;
			this.PF_LIBELLE = PF_LIBELLE;
		}

		public clsProfession(clsProfession clsProfession)
		{
			PF_CODEPROFESSION = clsProfession.PF_CODEPROFESSION;
			PF_LIBELLE = clsProfession.PF_LIBELLE;
		}
        }
}