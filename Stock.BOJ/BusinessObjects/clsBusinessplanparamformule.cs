using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsBusinessplanparamformule
	{
		#region VARIABLES LOCALES

		private string _PF_CODEFORMULE = "";
		private string _PF_LIBELLE = "";

		#endregion

		#region ACCESSEURS

		public string PF_CODEFORMULE
		{
			get { return _PF_CODEFORMULE; }
			set {  _PF_CODEFORMULE = value; }
		}

		public string PF_LIBELLE
		{
			get { return _PF_LIBELLE; }
			set {  _PF_LIBELLE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsBusinessplanparamformule(){}
		public clsBusinessplanparamformule( string PF_CODEFORMULE,string PF_LIBELLE)
		{
			this.PF_CODEFORMULE = PF_CODEFORMULE;
			this.PF_LIBELLE = PF_LIBELLE;
		}
		public clsBusinessplanparamformule(clsBusinessplanparamformule clsBusinessplanparamformule)
		{
			this.PF_CODEFORMULE = clsBusinessplanparamformule.PF_CODEFORMULE;
			this.PF_LIBELLE = clsBusinessplanparamformule.PF_LIBELLE;
		}

		#endregion

	}
}
