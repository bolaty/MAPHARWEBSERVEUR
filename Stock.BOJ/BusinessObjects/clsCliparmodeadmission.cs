using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsCliparmodeadmission
	{
		#region VARIABLES LOCALES

		private string _MD_CODEMODEADMISSION = "";
		private string _MD_LIBELLEMODEADMISSION = "";

		#endregion

		#region ACCESSEURS

		public string MD_CODEMODEADMISSION
		{
			get { return _MD_CODEMODEADMISSION; }
			set {  _MD_CODEMODEADMISSION = value; }
		}

		public string MD_LIBELLEMODEADMISSION
		{
			get { return _MD_LIBELLEMODEADMISSION; }
			set {  _MD_LIBELLEMODEADMISSION = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCliparmodeadmission(){}
		public clsCliparmodeadmission( string MD_CODEMODEADMISSION,string MD_LIBELLEMODEADMISSION)
		{
			this.MD_CODEMODEADMISSION = MD_CODEMODEADMISSION;
			this.MD_LIBELLEMODEADMISSION = MD_LIBELLEMODEADMISSION;
		}
		public clsCliparmodeadmission(clsCliparmodeadmission clsCliparmodeadmission)
		{
			this.MD_CODEMODEADMISSION = clsCliparmodeadmission.MD_CODEMODEADMISSION;
			this.MD_LIBELLEMODEADMISSION = clsCliparmodeadmission.MD_LIBELLEMODEADMISSION;
		}

		#endregion

	}
}
