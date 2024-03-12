using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.BOJ
{
	public class clsPhacommercialphoto
	{

        private string _AG_CODEAGENCE = "";
		private string _CO_IDCOMMERCIAL = "";
        private Byte[] _PH_PHOTO = null;



        public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set { _AG_CODEAGENCE = value; }
		}
		public string CO_IDCOMMERCIAL
		{
			get { return _CO_IDCOMMERCIAL; }
			set { _CO_IDCOMMERCIAL = value; }
		}
        public Byte[] PH_PHOTO
		{
			get { return _PH_PHOTO; }
			set { _PH_PHOTO = value; }
		}



        public clsPhacommercialphoto() {}

        public clsPhacommercialphoto(string AG_CODEAGENCE, string CO_IDCOMMERCIAL, Byte[] PH_PHOTO)
		{
			this.AG_CODEAGENCE = AG_CODEAGENCE;
			this.CO_IDCOMMERCIAL = CO_IDCOMMERCIAL;
			this.PH_PHOTO = PH_PHOTO;
		}

		public clsPhacommercialphoto(clsPhacommercialphoto clsPhacommercialphoto)
		{
			AG_CODEAGENCE = clsPhacommercialphoto.AG_CODEAGENCE;
			CO_IDCOMMERCIAL = clsPhacommercialphoto.CO_IDCOMMERCIAL;
			PH_PHOTO = clsPhacommercialphoto.PH_PHOTO;
		}
        }
}