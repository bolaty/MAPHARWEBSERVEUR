using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsCtsinistresuivie : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _AG_CODEAGENCE = "";
		private string _SD_INDEXSUIVIE = "";
		private string _SD_DATESAISIE = "";
		private string _SD_DATESUIVIE = "";
		private string _EN_CODEENTREPOT = "";
		private string _SI_CODESINISTRE = "";
		private string _SD_DESCRIPTIONEVENEMENT = "";
		private string _OP_CODEOPERATEUR = "";

		#endregion

		#region ACCESSEURS

		public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set {  _AG_CODEAGENCE = value; }
		}

		public string SD_INDEXSUIVIE
		{
			get { return _SD_INDEXSUIVIE; }
			set {  _SD_INDEXSUIVIE = value; }
		}

		public string SD_DATESAISIE
        {
			get { return _SD_DATESAISIE; }
			set { _SD_DATESAISIE = value; }
		}
		public string SD_DATESUIVIE
		{
			get { return _SD_DATESUIVIE; }
			set {  _SD_DATESUIVIE = value; }
		}

		public string EN_CODEENTREPOT
		{
			get { return _EN_CODEENTREPOT; }
			set {  _EN_CODEENTREPOT = value; }
		}

		public string SI_CODESINISTRE
		{
			get { return _SI_CODESINISTRE; }
			set {  _SI_CODESINISTRE = value; }
		}

		public string SD_DESCRIPTIONEVENEMENT
		{
			get { return _SD_DESCRIPTIONEVENEMENT; }
			set {  _SD_DESCRIPTIONEVENEMENT = value; }
		}

		public string OP_CODEOPERATEUR
		{
			get { return _OP_CODEOPERATEUR; }
			set {  _OP_CODEOPERATEUR = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCtsinistresuivie(){}
		
		public clsCtsinistresuivie(clsCtsinistresuivie clsCtsinistresuivie)
		{
			this.AG_CODEAGENCE = clsCtsinistresuivie.AG_CODEAGENCE;
			this.SD_INDEXSUIVIE = clsCtsinistresuivie.SD_INDEXSUIVIE;
			this.SD_DATESAISIE = clsCtsinistresuivie.SD_DATESAISIE;
			this.SD_DATESUIVIE = clsCtsinistresuivie.SD_DATESUIVIE;
			this.EN_CODEENTREPOT = clsCtsinistresuivie.EN_CODEENTREPOT;
			this.SI_CODESINISTRE = clsCtsinistresuivie.SI_CODESINISTRE;
			this.SD_DESCRIPTIONEVENEMENT = clsCtsinistresuivie.SD_DESCRIPTIONEVENEMENT;
			this.OP_CODEOPERATEUR = clsCtsinistresuivie.OP_CODEOPERATEUR;
		}

		#endregion

	}
}
