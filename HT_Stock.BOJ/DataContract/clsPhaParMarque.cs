using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Stock.BOJ
{
	public class clsPhaparmarque
	{

        private string _MA_CODEMARQUE = "";
		private string _MA_LIBELLE = "";



        public string MA_CODEMARQUE
		{
			get { return _MA_CODEMARQUE; }
			set { _MA_CODEMARQUE = value; }
		}
		public string MA_LIBELLE
		{
			get { return _MA_LIBELLE; }
			set { _MA_LIBELLE = value; }
		}



        public clsPhaparmarque() {} 

		public clsPhaparmarque(string MA_CODEMARQUE,string MA_LIBELLE)
		{
			this.MA_CODEMARQUE = MA_CODEMARQUE;
			this.MA_LIBELLE = MA_LIBELLE;
		}

		public clsPhaparmarque(clsPhaparmarque clsPhaparmarque)
		{
			MA_CODEMARQUE = clsPhaparmarque.MA_CODEMARQUE;
			MA_LIBELLE = clsPhaparmarque.MA_LIBELLE;
		}
        }
}