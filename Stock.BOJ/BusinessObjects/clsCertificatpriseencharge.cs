using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsCertificatpriseencharge
	{
		#region VARIABLES LOCALES

		private string _AG_CODEAGENCE = "";
		private string _MS_NUMPIECE= "";
        private Byte[] _CE_PHOTO = null;

		#endregion

		#region ACCESSEURS

		public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set {  _AG_CODEAGENCE = value; }
		}

		public string MS_NUMPIECE
		{
			get { return _MS_NUMPIECE; }
			set {  _MS_NUMPIECE= value; }
		}

        public Byte[] CE_PHOTO
		{
			get { return _CE_PHOTO; }
			set {  _CE_PHOTO = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCertificatpriseencharge(){}
        public clsCertificatpriseencharge(string AG_CODEAGENCE, string MS_NUMPIECE, Byte[] CE_PHOTO)
		{
			this.AG_CODEAGENCE = AG_CODEAGENCE;
			this.MS_NUMPIECE= MS_NUMPIECE;
			this.CE_PHOTO = CE_PHOTO;
		}
		public clsCertificatpriseencharge(clsCertificatpriseencharge clsCertificatpriseencharge)
		{
			this.AG_CODEAGENCE = clsCertificatpriseencharge.AG_CODEAGENCE;
			this.MS_NUMPIECE= clsCertificatpriseencharge.MS_NUMPIECE;
			this.CE_PHOTO = clsCertificatpriseencharge.CE_PHOTO;
		}

		#endregion

	}
}
