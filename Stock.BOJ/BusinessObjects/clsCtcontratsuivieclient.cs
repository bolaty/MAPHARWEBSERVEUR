using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsCtcontratsuivieclient
	{
		#region VARIABLES LOCALES

		private string _AG_CODEAGENCE = "";
		private string _SU_INDEXSUIVIE = "";
		private DateTime _SU_DATESAISIE = DateTime.Parse("01/01/1900");
		private string _EN_CODEENTREPOT = "";
		private DateTime _SU_DATESUIVIE = DateTime.Parse("01/01/1900");
		private string _CA_CODECONTRAT = "";
		private string _SU_DESCRIPTIONEVENEMENT = "";
		private string _OP_CODEOPERATEUR = "";

		#endregion

		#region ACCESSEURS

		public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set {  _AG_CODEAGENCE = value; }
		}

		public string SU_INDEXSUIVIE
		{
			get { return _SU_INDEXSUIVIE; }
			set {  _SU_INDEXSUIVIE = value; }
		}

		public DateTime SU_DATESAISIE
		{
			get { return _SU_DATESAISIE; }
			set {  _SU_DATESAISIE = value; }
		}

		public string EN_CODEENTREPOT
		{
			get { return _EN_CODEENTREPOT; }
			set {  _EN_CODEENTREPOT = value; }
		}

		public DateTime SU_DATESUIVIE
		{
			get { return _SU_DATESUIVIE; }
			set {  _SU_DATESUIVIE = value; }
		}

		public string CA_CODECONTRAT
		{
			get { return _CA_CODECONTRAT; }
			set {  _CA_CODECONTRAT = value; }
		}

		public string SU_DESCRIPTIONEVENEMENT
		{
			get { return _SU_DESCRIPTIONEVENEMENT; }
			set {  _SU_DESCRIPTIONEVENEMENT = value; }
		}

		public string OP_CODEOPERATEUR
		{
			get { return _OP_CODEOPERATEUR; }
			set {  _OP_CODEOPERATEUR = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCtcontratsuivieclient(){}
		public clsCtcontratsuivieclient( string AG_CODEAGENCE,string SU_INDEXSUIVIE,DateTime SU_DATESAISIE,string EN_CODEENTREPOT,DateTime SU_DATESUIVIE,string CA_CODECONTRAT,string SU_DESCRIPTIONEVENEMENT,string OP_CODEOPERATEUR)
		{
			this.AG_CODEAGENCE = AG_CODEAGENCE;
			this.SU_INDEXSUIVIE = SU_INDEXSUIVIE;
			this.SU_DATESAISIE = SU_DATESAISIE;
			this.EN_CODEENTREPOT = EN_CODEENTREPOT;
			this.SU_DATESUIVIE = SU_DATESUIVIE;
			this.CA_CODECONTRAT = CA_CODECONTRAT;
			this.SU_DESCRIPTIONEVENEMENT = SU_DESCRIPTIONEVENEMENT;
			this.OP_CODEOPERATEUR = OP_CODEOPERATEUR;
		}
		public clsCtcontratsuivieclient(clsCtcontratsuivieclient clsCtcontratsuivieclient)
		{
			this.AG_CODEAGENCE = clsCtcontratsuivieclient.AG_CODEAGENCE;
			this.SU_INDEXSUIVIE = clsCtcontratsuivieclient.SU_INDEXSUIVIE;
			this.SU_DATESAISIE = clsCtcontratsuivieclient.SU_DATESAISIE;
			this.EN_CODEENTREPOT = clsCtcontratsuivieclient.EN_CODEENTREPOT;
			this.SU_DATESUIVIE = clsCtcontratsuivieclient.SU_DATESUIVIE;
			this.CA_CODECONTRAT = clsCtcontratsuivieclient.CA_CODECONTRAT;
			this.SU_DESCRIPTIONEVENEMENT = clsCtcontratsuivieclient.SU_DESCRIPTIONEVENEMENT;
			this.OP_CODEOPERATEUR = clsCtcontratsuivieclient.OP_CODEOPERATEUR;
		}

		#endregion

	}
}
