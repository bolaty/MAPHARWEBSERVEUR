using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsPhafamilleoperation
	{
		#region VARIABLES LOCALES

		private string _FO_CODEFAMILLEOPERATION = "";
		private string _FO_LIBELLEFAMILLEOPERATION = "";
        private string _NF_CODENATUREFAMILLEOPERATION = "";
		private int _FO_NUMEROORDRE = 0;
		private string _FO_STATUT = "";

		#endregion

		#region ACCESSEURS

		public string FO_CODEFAMILLEOPERATION
		{
			get { return _FO_CODEFAMILLEOPERATION; }
			set {  _FO_CODEFAMILLEOPERATION = value; }
		}

		public string FO_LIBELLEFAMILLEOPERATION
		{
			get { return _FO_LIBELLEFAMILLEOPERATION; }
			set {  _FO_LIBELLEFAMILLEOPERATION = value; }
		}

        public string NF_CODENATUREFAMILLEOPERATION
        {
	        get { return _NF_CODENATUREFAMILLEOPERATION; }
	        set { _NF_CODENATUREFAMILLEOPERATION = value; }
        }

		public int FO_NUMEROORDRE
		{
			get { return _FO_NUMEROORDRE; }
			set {  _FO_NUMEROORDRE = value; }
		}

		public string FO_STATUT
		{
			get { return _FO_STATUT; }
			set {  _FO_STATUT = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsPhafamilleoperation(){}
		
		public clsPhafamilleoperation(clsPhafamilleoperation clsPhafamilleoperation)
		{
			this.FO_CODEFAMILLEOPERATION = clsPhafamilleoperation.FO_CODEFAMILLEOPERATION;
			this.FO_LIBELLEFAMILLEOPERATION = clsPhafamilleoperation.FO_LIBELLEFAMILLEOPERATION;
            this.NF_CODENATUREFAMILLEOPERATION = clsPhafamilleoperation.NF_CODENATUREFAMILLEOPERATION;
			this.FO_NUMEROORDRE = clsPhafamilleoperation.FO_NUMEROORDRE;
			this.FO_STATUT = clsPhafamilleoperation.FO_STATUT;
		}

		#endregion

	}
}
