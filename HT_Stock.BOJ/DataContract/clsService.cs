using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsService : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _SR_CODESERVICE = "";
		private string _SR_LIBELLE = "";

		#endregion

		#region ACCESSEURS

		public string SR_CODESERVICE
		{
			get { return _SR_CODESERVICE; }
			set {  _SR_CODESERVICE = value; }
		}

		public string SR_LIBELLE
		{
			get { return _SR_LIBELLE; }
			set {  _SR_LIBELLE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsService(){}
		public clsService( string SR_CODESERVICE,string SR_LIBELLE)
		{
			this.SR_CODESERVICE = SR_CODESERVICE;
			this.SR_LIBELLE = SR_LIBELLE;
		}
		public clsService(clsService clsService)
		{
			this.SR_CODESERVICE = clsService.SR_CODESERVICE;
			this.SR_LIBELLE = clsService.SR_LIBELLE;
		}

		#endregion

	}
}
