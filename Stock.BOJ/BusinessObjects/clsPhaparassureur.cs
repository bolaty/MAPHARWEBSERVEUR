using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsPhaparassureur
	{
		#region VARIABLES LOCALES

		private string _AS_CODEASSUREUR = "";
		private string _AS_LIBELLE = "";
		private string _AS_CONTACT = "";

		#endregion

		#region ACCESSEURS

		public string AS_CODEASSUREUR
		{
			get { return _AS_CODEASSUREUR; }
			set {  _AS_CODEASSUREUR = value; }
		}

		public string AS_LIBELLE
		{
			get { return _AS_LIBELLE; }
			set {  _AS_LIBELLE = value; }
		}

		public string AS_CONTACT
		{
			get { return _AS_CONTACT; }
			set {  _AS_CONTACT = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsPhaparassureur(){}
		public clsPhaparassureur( string AS_CODEASSUREUR,string AS_LIBELLE,string AS_CONTACT)
		{
			this.AS_CODEASSUREUR = AS_CODEASSUREUR;
			this.AS_LIBELLE = AS_LIBELLE;
			this.AS_CONTACT = AS_CONTACT;
		}
		public clsPhaparassureur(clsPhaparassureur clsPhaparassureur)
		{
			this.AS_CODEASSUREUR = clsPhaparassureur.AS_CODEASSUREUR;
			this.AS_LIBELLE = clsPhaparassureur.AS_LIBELLE;
			this.AS_CONTACT = clsPhaparassureur.AS_CONTACT;
		}

		#endregion

	}
}
