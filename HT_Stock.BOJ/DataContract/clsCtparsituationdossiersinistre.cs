using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsCtparsituationdossiersinistre
	{
		#region VARIABLES LOCALES

		private string _SD_CODESITUATIONDOSSIER = "";
		private string _SD_LIBELLESITUATIONDOSSIER = "";
		private string _SD_ACTIFSITUATIONDOSSIER = "";
		private int _SD_NUMEROORDRESITUATIONDOSSIER = 0;

		#endregion

		#region ACCESSEURS

		public string SD_CODESITUATIONDOSSIER
		{
			get { return _SD_CODESITUATIONDOSSIER; }
			set {  _SD_CODESITUATIONDOSSIER = value; }
		}

		public string SD_LIBELLESITUATIONDOSSIER
		{
			get { return _SD_LIBELLESITUATIONDOSSIER; }
			set {  _SD_LIBELLESITUATIONDOSSIER = value; }
		}

		public string SD_ACTIFSITUATIONDOSSIER
		{
			get { return _SD_ACTIFSITUATIONDOSSIER; }
			set {  _SD_ACTIFSITUATIONDOSSIER = value; }
		}

		public int SD_NUMEROORDRESITUATIONDOSSIER
		{
			get { return _SD_NUMEROORDRESITUATIONDOSSIER; }
			set {  _SD_NUMEROORDRESITUATIONDOSSIER = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCtparsituationdossiersinistre(){}

		public clsCtparsituationdossiersinistre(clsCtparsituationdossiersinistre clsCtparsituationdossiersinistre)
		{
			this.SD_CODESITUATIONDOSSIER = clsCtparsituationdossiersinistre.SD_CODESITUATIONDOSSIER;
			this.SD_LIBELLESITUATIONDOSSIER = clsCtparsituationdossiersinistre.SD_LIBELLESITUATIONDOSSIER;
			this.SD_ACTIFSITUATIONDOSSIER = clsCtparsituationdossiersinistre.SD_ACTIFSITUATIONDOSSIER;
			this.SD_NUMEROORDRESITUATIONDOSSIER = clsCtparsituationdossiersinistre.SD_NUMEROORDRESITUATIONDOSSIER;
		}

		#endregion

	}
}
