using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsCtsinistresituationdossier
	{
		#region VARIABLES LOCALES

		private string _SI_CODESINISTRE = "";
		private string _SD_CODESITUATIONDOSSIER = "";
		private DateTime _SI_DATESAISIE = DateTime.Parse("01/01/1900");
		private string _OP_CODEOPERATEUR = "";

		#endregion

		#region ACCESSEURS

		public string SI_CODESINISTRE
		{
			get { return _SI_CODESINISTRE; }
			set {  _SI_CODESINISTRE = value; }
		}

		public string SD_CODESITUATIONDOSSIER
		{
			get { return _SD_CODESITUATIONDOSSIER; }
			set {  _SD_CODESITUATIONDOSSIER = value; }
		}

		public DateTime SI_DATESAISIE
		{
			get { return _SI_DATESAISIE; }
			set {  _SI_DATESAISIE = value; }
		}

		public string OP_CODEOPERATEUR
		{
			get { return _OP_CODEOPERATEUR; }
			set {  _OP_CODEOPERATEUR = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCtsinistresituationdossier(){}
		
		public clsCtsinistresituationdossier(clsCtsinistresituationdossier clsCtsinistresituationdossier)
		{
			this.SI_CODESINISTRE = clsCtsinistresituationdossier.SI_CODESINISTRE;
			this.SD_CODESITUATIONDOSSIER = clsCtsinistresituationdossier.SD_CODESITUATIONDOSSIER;
			this.SI_DATESAISIE = clsCtsinistresituationdossier.SI_DATESAISIE;
			this.OP_CODEOPERATEUR = clsCtsinistresituationdossier.OP_CODEOPERATEUR;
		}

		#endregion

	}
}
