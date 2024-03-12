using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsCtparcontratstatutdemande : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _SD_CODEPIECE = "";
		private string _SD_LIBELLEPIECE = "";
		private string _SD_ACTIF = "";

		#endregion

		#region ACCESSEURS

		public string SD_CODEPIECE
		{
			get { return _SD_CODEPIECE; }
			set {  _SD_CODEPIECE = value; }
		}

		public string SD_LIBELLEPIECE
		{
			get { return _SD_LIBELLEPIECE; }
			set {  _SD_LIBELLEPIECE = value; }
		}

		

		public string SD_ACTIF
		{
			get { return _SD_ACTIF; }
			set {  _SD_ACTIF = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCtparcontratstatutdemande(){}
		
		public clsCtparcontratstatutdemande(clsCtparcontratstatutdemande clsCtparcontratstatutdemande)
		{
			this.SD_CODEPIECE = clsCtparcontratstatutdemande.SD_CODEPIECE;
			this.SD_LIBELLEPIECE = clsCtparcontratstatutdemande.SD_LIBELLEPIECE;
			
			this.SD_ACTIF = clsCtparcontratstatutdemande.SD_ACTIF;
		}

		#endregion

	}
}
