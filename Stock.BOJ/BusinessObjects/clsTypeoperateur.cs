using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsTypeoperateur
	{
		#region VARIABLES LOCALES

		private string _TO_CODETYPEOERATEUR = "";
		private string _TO_LIBELLE = "";

		#endregion

		#region ACCESSEURS

		public string TO_CODETYPEOERATEUR
		{
			get { return _TO_CODETYPEOERATEUR; }
			set {  _TO_CODETYPEOERATEUR = value; }
		}

		public string TO_LIBELLE
		{
			get { return _TO_LIBELLE; }
			set {  _TO_LIBELLE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsTypeoperateur(){}
		public clsTypeoperateur( string TO_CODETYPEOERATEUR,string TO_LIBELLE)
		{
			this.TO_CODETYPEOERATEUR = TO_CODETYPEOERATEUR;
			this.TO_LIBELLE = TO_LIBELLE;
		}
		public clsTypeoperateur(clsTypeoperateur clsTypeoperateur)
		{
			this.TO_CODETYPEOERATEUR = clsTypeoperateur.TO_CODETYPEOERATEUR;
			this.TO_LIBELLE = clsTypeoperateur.TO_LIBELLE;
		}

		#endregion

	}
}
