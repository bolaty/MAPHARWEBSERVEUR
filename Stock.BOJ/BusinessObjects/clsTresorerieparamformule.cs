using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsTresorerieparamformule
	{
		#region VARIABLES LOCALES

		private string _TF_CODEFORMULE = "";
		private string _TF_LIBELLE = "";

		#endregion

		#region ACCESSEURS

		public string TF_CODEFORMULE
		{
			get { return _TF_CODEFORMULE; }
			set {  _TF_CODEFORMULE = value; }
		}

		public string TF_LIBELLE
		{
			get { return _TF_LIBELLE; }
			set {  _TF_LIBELLE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsTresorerieparamformule(){}
		public clsTresorerieparamformule( string TF_CODEFORMULE,string TF_LIBELLE)
		{
			this.TF_CODEFORMULE = TF_CODEFORMULE;
			this.TF_LIBELLE = TF_LIBELLE;
		}
		public clsTresorerieparamformule(clsTresorerieparamformule clsTresorerieparamformule)
		{
			this.TF_CODEFORMULE = clsTresorerieparamformule.TF_CODEFORMULE;
			this.TF_LIBELLE = clsTresorerieparamformule.TF_LIBELLE;
		}

		#endregion

	}
}
