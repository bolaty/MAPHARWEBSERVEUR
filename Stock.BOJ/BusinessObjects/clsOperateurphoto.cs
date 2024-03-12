using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.BOJ
{
	public class clsOperateurphoto
	{

        private string _AG_CODEAGENCE = "";
        private string _OP_CODEOPERATEUR = "";
        private Byte[] _OH_PHOTO =null;
        private Byte[] _OH_SIGNATURE = null;


        public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set { _AG_CODEAGENCE = value; }
		}
        public string OP_CODEOPERATEUR
		{
			get { return _OP_CODEOPERATEUR; }
			set { _OP_CODEOPERATEUR = value; }
		}
        public Byte[] OH_PHOTO
		{
			get { return _OH_PHOTO; }
			set { _OH_PHOTO = value; }
		}
        public Byte[] OH_SIGNATURE
		{
            get { return _OH_SIGNATURE; }
            set { _OH_SIGNATURE = value; }
		}


        public clsOperateurphoto() {}

		public clsOperateurphoto(clsOperateurphoto clsOperateurphoto)
		{
			AG_CODEAGENCE = clsOperateurphoto.AG_CODEAGENCE;
			OP_CODEOPERATEUR = clsOperateurphoto.OP_CODEOPERATEUR;
			OH_PHOTO = clsOperateurphoto.OH_PHOTO;
            OH_SIGNATURE = clsOperateurphoto.OH_SIGNATURE;
		}
        }
}