using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.BOJ
{
	public class clsPhapararticlephoto
	{

        private string _AR_CODEARTICLE = "";
        private byte[] _PH_PHOTO = null;



        public string AR_CODEARTICLE
		{
			get { return _AR_CODEARTICLE; }
			set { _AR_CODEARTICLE = value; }
		}
		public byte[] PH_PHOTO
		{
			get { return _PH_PHOTO; }
			set { _PH_PHOTO = value; }
		}



        public clsPhapararticlephoto() {}

        public clsPhapararticlephoto(string AR_CODEARTICLE, byte[] PH_PHOTO)
		{
			this.AR_CODEARTICLE = AR_CODEARTICLE;
			this.PH_PHOTO = PH_PHOTO;
		}

		public clsPhapararticlephoto(clsPhapararticlephoto clsPhapararticlephoto)
		{
			AR_CODEARTICLE = clsPhapararticlephoto.AR_CODEARTICLE;
			PH_PHOTO = clsPhapararticlephoto.PH_PHOTO;
		}
        }
}