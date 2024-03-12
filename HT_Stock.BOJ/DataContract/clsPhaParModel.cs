using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Stock.BOJ
{
	public class clsPhaparmodel
	{

        private string _MO_CODEMODEL = "";
		private string _MO_LIBELLE = "";



        public string MO_CODEMODEL
		{
			get { return _MO_CODEMODEL; }
			set { _MO_CODEMODEL = value; }
		}
		public string MO_LIBELLE
		{
			get { return _MO_LIBELLE; }
			set { _MO_LIBELLE = value; }
		}



        public clsPhaparmodel() {} 

		public clsPhaparmodel(string MO_CODEMODEL,string MO_LIBELLE)
		{
			this.MO_CODEMODEL = MO_CODEMODEL;
			this.MO_LIBELLE = MO_LIBELLE;
		}

		public clsPhaparmodel(clsPhaparmodel clsPhaparmodel)
		{
			MO_CODEMODEL = clsPhaparmodel.MO_CODEMODEL;
			MO_LIBELLE = clsPhaparmodel.MO_LIBELLE;
		}
        }
}