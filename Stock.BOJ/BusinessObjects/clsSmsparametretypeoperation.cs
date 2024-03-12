using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsSmsparametretypeoperation
	{
		#region VARIABLES LOCALES

		private string _TE_CODESMSTYPEOPERATION = "";
		private string _TE_LIBELLE = "";
		private string _TE_ACTIF = "";

		#endregion

		#region ACCESSEURS

		public string TE_CODESMSTYPEOPERATION
		{
			get { return _TE_CODESMSTYPEOPERATION; }
			set {  _TE_CODESMSTYPEOPERATION = value; }
		}

		public string TE_LIBELLE
		{
			get { return _TE_LIBELLE; }
			set {  _TE_LIBELLE = value; }
		}

		public string TE_ACTIF
		{
			get { return _TE_ACTIF; }
			set {  _TE_ACTIF = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsSmsparametretypeoperation(){}
		public clsSmsparametretypeoperation( string TE_CODESMSTYPEOPERATION,string TE_LIBELLE,string TE_ACTIF)
		{
			this.TE_CODESMSTYPEOPERATION = TE_CODESMSTYPEOPERATION;
			this.TE_LIBELLE = TE_LIBELLE;
			this.TE_ACTIF = TE_ACTIF;
		}
		public clsSmsparametretypeoperation(clsSmsparametretypeoperation clsSmsparametretypeoperation)
		{
			this.TE_CODESMSTYPEOPERATION = clsSmsparametretypeoperation.TE_CODESMSTYPEOPERATION;
			this.TE_LIBELLE = clsSmsparametretypeoperation.TE_LIBELLE;
			this.TE_ACTIF = clsSmsparametretypeoperation.TE_ACTIF;
		}

		#endregion

	}
}
