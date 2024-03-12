using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsPhatiersphoto : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _AG_CODEAGENCE = "";
		private string _TI_IDTIERS = "";
        private string _TI_PHOTO = "";
        private string _TI_SIGNATURE = "";

		#endregion

		#region ACCESSEURS

		public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set {  _AG_CODEAGENCE = value; }
		}

		public string TI_IDTIERS
		{
			get { return _TI_IDTIERS; }
			set {  _TI_IDTIERS = value; }
		}

        public string TI_PHOTO
		{
			get { return _TI_PHOTO; }
			set {  _TI_PHOTO = value; }
		}


        public string TI_SIGNATURE
        {
	        get { return _TI_SIGNATURE; }
	        set { _TI_SIGNATURE = value; }
        }



		#endregion

		#region INSTANCIATEURS

		public clsPhatiersphoto(){}
       
		public clsPhatiersphoto(clsPhatiersphoto clsPhatiersphoto)
		{
			this.AG_CODEAGENCE = clsPhatiersphoto.AG_CODEAGENCE;
			this.TI_IDTIERS = clsPhatiersphoto.TI_IDTIERS;
			this.TI_PHOTO = clsPhatiersphoto.TI_PHOTO;
            this.TI_SIGNATURE = clsPhatiersphoto.TI_SIGNATURE;
		}

		#endregion

	}
}
