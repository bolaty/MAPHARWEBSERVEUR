using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Stock.BOJ
{
	public class clsPhaparfabricant
	{

        private string _FA_CODEFABRICANT = "";
		private string _FA_LIBELLE = "";



        public string FA_CODEFABRICANT
		{
			get { return _FA_CODEFABRICANT; }
			set { _FA_CODEFABRICANT = value; }
		}
		public string FA_LIBELLE
		{
			get { return _FA_LIBELLE; }
			set { _FA_LIBELLE = value; }
		}



        public clsPhaparfabricant() {} 

		public clsPhaparfabricant(string FA_CODEFABRICANT,string FA_LIBELLE)
		{
			this.FA_CODEFABRICANT = FA_CODEFABRICANT;
			this.FA_LIBELLE = FA_LIBELLE;
		}

		public clsPhaparfabricant(clsPhaparfabricant clsPhaparfabricant)
		{
			FA_CODEFABRICANT = clsPhaparfabricant.FA_CODEFABRICANT;
			FA_LIBELLE = clsPhaparfabricant.FA_LIBELLE;
		}
        }
}