using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsBusinessplanparamcouleur
	{
		#region VARIABLES LOCALES

		private string _PC_CODECOULEUR = "";
		private string _PC_LIBELLE = "";

		#endregion

		#region ACCESSEURS

		public string PC_CODECOULEUR
		{
			get { return _PC_CODECOULEUR; }
			set {  _PC_CODECOULEUR = value; }
		}

		public string PC_LIBELLE
		{
			get { return _PC_LIBELLE; }
			set {  _PC_LIBELLE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsBusinessplanparamcouleur(){}
		public clsBusinessplanparamcouleur( string PC_CODECOULEUR,string PC_LIBELLE)
		{
			this.PC_CODECOULEUR = PC_CODECOULEUR;
			this.PC_LIBELLE = PC_LIBELLE;
		}
		public clsBusinessplanparamcouleur(clsBusinessplanparamcouleur clsBusinessplanparamcouleur)
		{
			this.PC_CODECOULEUR = clsBusinessplanparamcouleur.PC_CODECOULEUR;
			this.PC_LIBELLE = clsBusinessplanparamcouleur.PC_LIBELLE;
		}

		#endregion

	}
}
