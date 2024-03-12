using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.BOJ
{
	public class clsPhaparoperation
	{

        private string _OT_CODEOPERATION = "";
		private string _OT_LIBELLE = "";
		private string _OT_SENS = "";



        public string OT_CODEOPERATION
		{
			get { return _OT_CODEOPERATION; }
			set { _OT_CODEOPERATION = value; }
		}
		public string OT_LIBELLE
		{
			get { return _OT_LIBELLE; }
			set { _OT_LIBELLE = value; }
		}
		public string OT_SENS
		{
			get { return _OT_SENS; }
			set { _OT_SENS = value; }
		}



        public clsPhaparoperation() {} 

		public clsPhaparoperation(string OT_CODEOPERATION,string OT_LIBELLE,string OT_SENS)
		{
			this.OT_CODEOPERATION = OT_CODEOPERATION;
			this.OT_LIBELLE = OT_LIBELLE;
			this.OT_SENS = OT_SENS;
		}

		public clsPhaparoperation(clsPhaparoperation clsPhaparoperation)
		{
			OT_CODEOPERATION = clsPhaparoperation.OT_CODEOPERATION;
			OT_LIBELLE = clsPhaparoperation.OT_LIBELLE;
			OT_SENS = clsPhaparoperation.OT_SENS;
		}
        }
}