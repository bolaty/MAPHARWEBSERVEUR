using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsCtcontratdemandecreation : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _DE_CODEDEMANADE = "";
		private string _AG_CODEAGENCE = "";
		private string _DE_DATESAISIE = "01-01-1900";
		private string _DE_DATEVALIDATION = "01-01-1900";
		private string _DE_DATEANNULATION = "01-01-1900";
		private string _RQ_CODERISQUE = "";
		private string _TI_IDTIERSASSUREUR = "";
		private string _TI_IDTIERS = "";
		private string _CA_CODECONTRAT = "";
        private string _TI_NUMTIERS = "";
		#endregion

		#region ACCESSEURS

		public string DE_CODEDEMANADE
		{
			get { return _DE_CODEDEMANADE; }
			set {  _DE_CODEDEMANADE = value; }
		}

		public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set {  _AG_CODEAGENCE = value; }
		}

		public string DE_DATESAISIE
		{
			get { return _DE_DATESAISIE; }
			set {  _DE_DATESAISIE = value; }
		}

		public string DE_DATEVALIDATION
		{
			get { return _DE_DATEVALIDATION; }
			set {  _DE_DATEVALIDATION = value; }
		}
		public string DE_DATEANNULATION
        {
			get { return _DE_DATEANNULATION; }
			set { _DE_DATEANNULATION = value; }
		}
		public string RQ_CODERISQUE
		{
			get { return _RQ_CODERISQUE; }
			set {  _RQ_CODERISQUE = value; }
		}

		public string TI_IDTIERSASSUREUR
		{
			get { return _TI_IDTIERSASSUREUR; }
			set {  _TI_IDTIERSASSUREUR = value; }
		}

		public string TI_IDTIERS
		{
			get { return _TI_IDTIERS; }
			set {  _TI_IDTIERS = value; }
		}

		public string CA_CODECONTRAT
		{
			get { return _CA_CODECONTRAT; }
			set {  _CA_CODECONTRAT = value; }
		}
		public string TI_NUMTIERS
        {
			get { return _TI_NUMTIERS; }
			set { _TI_NUMTIERS = value; }
		}

		#endregion

		#region INSTANCIATEURS

		public clsCtcontratdemandecreation(){}
		
		public clsCtcontratdemandecreation(clsCtcontratdemandecreation clsCtcontratdemandecreation)
		{
			this.DE_CODEDEMANADE = clsCtcontratdemandecreation.DE_CODEDEMANADE;
			this.AG_CODEAGENCE = clsCtcontratdemandecreation.AG_CODEAGENCE;
			this.DE_DATESAISIE = clsCtcontratdemandecreation.DE_DATESAISIE;
			this.DE_DATEVALIDATION = clsCtcontratdemandecreation.DE_DATEVALIDATION;
			this.DE_DATEANNULATION = clsCtcontratdemandecreation.DE_DATEANNULATION;
			this.RQ_CODERISQUE = clsCtcontratdemandecreation.RQ_CODERISQUE;
			this.TI_IDTIERSASSUREUR = clsCtcontratdemandecreation.TI_IDTIERSASSUREUR;
			this.TI_IDTIERS = clsCtcontratdemandecreation.TI_IDTIERS;
			this.CA_CODECONTRAT = clsCtcontratdemandecreation.CA_CODECONTRAT;
			this.TI_NUMTIERS = clsCtcontratdemandecreation.TI_NUMTIERS;
		}

		#endregion

	}
}