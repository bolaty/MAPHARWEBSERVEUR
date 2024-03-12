using Stock.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Stock.BOJ
{
	public class clsGrandLivre : clsEntitieBase
    {

        private string _GL_CODEGRANDLIVRE = "";
		private string _GL_GRANDLIVRELIBELLE = "";



        public string GL_CODEGRANDLIVRE
		{
			get { return _GL_CODEGRANDLIVRE; }
			set { _GL_CODEGRANDLIVRE = value; }
		}
		public string GL_GRANDLIVRELIBELLE
		{
			get { return _GL_GRANDLIVRELIBELLE; }
			set { _GL_GRANDLIVRELIBELLE = value; }
		}
      


        public clsGrandLivre() {}

        public clsGrandLivre(clsGrandLivre clsGrandLivre)
        {
            GL_CODEGRANDLIVRE = clsGrandLivre.GL_CODEGRANDLIVRE;
            GL_GRANDLIVRELIBELLE = clsGrandLivre.GL_GRANDLIVRELIBELLE;
        }


    }
}