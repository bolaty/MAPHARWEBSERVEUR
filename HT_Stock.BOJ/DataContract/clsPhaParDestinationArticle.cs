using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Stock.BOJ
{
	public class clsPhapardestinationarticle
	{

        private string _DA_CODEDESTINATION = "";
		private string _DA_LIBELLE = "";



        public string DA_CODEDESTINATION
		{
			get { return _DA_CODEDESTINATION; }
			set { _DA_CODEDESTINATION = value; }
		}
		public string DA_LIBELLE
		{
			get { return _DA_LIBELLE; }
			set { _DA_LIBELLE = value; }
		}



        public clsPhapardestinationarticle() {} 

		public clsPhapardestinationarticle(string DA_CODEDESTINATION,string DA_LIBELLE)
		{
			this.DA_CODEDESTINATION = DA_CODEDESTINATION;
			this.DA_LIBELLE = DA_LIBELLE;
		}

		public clsPhapardestinationarticle(clsPhapardestinationarticle clsPhapardestinationarticle)
		{
			DA_CODEDESTINATION = clsPhapardestinationarticle.DA_CODEDESTINATION;
			DA_LIBELLE = clsPhapardestinationarticle.DA_LIBELLE;
		}

     }
}