using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsTypejournal
	{
		#region VARIABLES LOCALES

		private string _TJ_CODETYPEJOURNAL = "";
		private string _TJ_LIBELLE = "";

		#endregion

		#region ACCESSEURS

		public string TJ_CODETYPEJOURNAL
		{
			get { return _TJ_CODETYPEJOURNAL; }
			set {  _TJ_CODETYPEJOURNAL = value; }
		}

		public string TJ_LIBELLE
		{
			get { return _TJ_LIBELLE; }
			set {  _TJ_LIBELLE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsTypejournal(){}
		public clsTypejournal( string TJ_CODETYPEJOURNAL,string TJ_LIBELLE)
		{
			this.TJ_CODETYPEJOURNAL = TJ_CODETYPEJOURNAL;
			this.TJ_LIBELLE = TJ_LIBELLE;
		}
		public clsTypejournal(clsTypejournal clsTypejournal)
		{
			this.TJ_CODETYPEJOURNAL = clsTypejournal.TJ_CODETYPEJOURNAL;
			this.TJ_LIBELLE = clsTypejournal.TJ_LIBELLE;
		}

		#endregion

	}
}
