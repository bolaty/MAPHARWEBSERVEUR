using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Stock.BOJ
{
	public class clsPhaplantationPhoto
	{

        private string _PL_IDPLANTATION = "";
        private byte[] _PL_PHOTO = null;



        public string PL_IDPLANTATION
		{
			get { return _PL_IDPLANTATION; }
			set { _PL_IDPLANTATION = value; }
		}
		public byte[] PL_PHOTO
		{
			get { return _PL_PHOTO; }
			set { _PL_PHOTO = value; }
		}



        public clsPhaplantationPhoto() {}

        public clsPhaplantationPhoto(string PL_IDPLANTATION, byte[] PL_PHOTO)
		{
			this.PL_IDPLANTATION = PL_IDPLANTATION;
			this.PL_PHOTO = PL_PHOTO;
		}

		public clsPhaplantationPhoto(clsPhaplantationPhoto clsPhaplantationPhoto)
		{
			PL_IDPLANTATION = clsPhaplantationPhoto.PL_IDPLANTATION;
			PL_PHOTO = clsPhaplantationPhoto.PL_PHOTO;
		}
        }
}