using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsOrgProspectsPhoto
	{
		#region VARIABLES LOCALES

		private string _AG_CODEAGENCE = "";
		private string _PR_IDTIERS = "";
        private Byte[] _PR_PHOTO = null;
        private Byte[] _PR_SIGNATURE = null;

		#endregion

		#region ACCESSEURS

		public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set {  _AG_CODEAGENCE = value; }
		}

		public string PR_IDTIERS
		{
			get { return _PR_IDTIERS; }
			set {  _PR_IDTIERS = value; }
		}

        public Byte[] PR_PHOTO
		{
			get { return _PR_PHOTO; }
			set {  _PR_PHOTO = value; }
		}


        public Byte[] PR_SIGNATURE
        {
	        get { return _PR_SIGNATURE; }
	        set { _PR_SIGNATURE = value; }
        }



		#endregion

		#region INSTANCIATEURS

		public clsOrgProspectsPhoto(){}
        public clsOrgProspectsPhoto(string AG_CODEAGENCE, string PR_IDTIERS, Byte[] PR_PHOTO, Byte[] PR_SIGNATURE)
		{
			this.AG_CODEAGENCE = AG_CODEAGENCE;
			this.PR_IDTIERS = PR_IDTIERS;
			this.PR_PHOTO = PR_PHOTO;
            this.PR_SIGNATURE = PR_SIGNATURE;

		}
		public clsOrgProspectsPhoto(clsOrgProspectsPhoto clsOrgProspectsPhoto)
		{
			this.AG_CODEAGENCE = clsOrgProspectsPhoto.AG_CODEAGENCE;
			this.PR_IDTIERS = clsOrgProspectsPhoto.PR_IDTIERS;
			this.PR_PHOTO = clsOrgProspectsPhoto.PR_PHOTO;
            this.PR_SIGNATURE = clsOrgProspectsPhoto.PR_SIGNATURE;
		}

		#endregion

	}
}
