using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsBusinessplanparampolice
	{
		#region VARIABLES LOCALES

		private string _PP_CODEPOLICE = "";
		private string _PP_ABREGE = "";
		private string _PP_LIBELLE = "";

		#endregion

		#region ACCESSEURS

		public string PP_CODEPOLICE
		{
			get { return _PP_CODEPOLICE; }
			set {  _PP_CODEPOLICE = value; }
		}

		public string PP_ABREGE
		{
			get { return _PP_ABREGE; }
			set {  _PP_ABREGE = value; }
		}

		public string PP_LIBELLE
		{
			get { return _PP_LIBELLE; }
			set {  _PP_LIBELLE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsBusinessplanparampolice(){}
		public clsBusinessplanparampolice( string PP_CODEPOLICE,string PP_ABREGE,string PP_LIBELLE)
		{
			this.PP_CODEPOLICE = PP_CODEPOLICE;
			this.PP_ABREGE = PP_ABREGE;
			this.PP_LIBELLE = PP_LIBELLE;
		}
		public clsBusinessplanparampolice(clsBusinessplanparampolice clsBusinessplanparampolice)
		{
			this.PP_CODEPOLICE = clsBusinessplanparampolice.PP_CODEPOLICE;
			this.PP_ABREGE = clsBusinessplanparampolice.PP_ABREGE;
			this.PP_LIBELLE = clsBusinessplanparampolice.PP_LIBELLE;
		}

		#endregion

	}
}
