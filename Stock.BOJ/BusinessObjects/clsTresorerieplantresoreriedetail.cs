using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsTresorerieplantresoreriedetail
	{
		#region VARIABLES LOCALES

		private string _TB_CODEPLANTRESORERIE = "";
		private string _TP_CODEPOSTETRESORERIE = "";
		private DateTime _TE_DATEDEBUT = DateTime.Parse("01/01/1900");
		private DateTime _TE_DATEFIN = DateTime.Parse("01/01/1900");
		private string _AG_CODEAGENCE = "";
		private string _PV_CODEPOINTVENTE = "";
		private string _PE_CODEPERIODICITE = "";
		private double _TE_MONTANT = 0;
		private DateTime _TE_DATESAISIE = DateTime.Parse("01/01/1900");
		private DateTime _TE_DATEVALIDATION = DateTime.Parse("01/01/1900");
		private string _OP_CODEOPERATEURVALIDATION = "";
		private string _OP_CODEOPERATEUR = "";

		#endregion

		#region ACCESSEURS

		public string TB_CODEPLANTRESORERIE
		{
			get { return _TB_CODEPLANTRESORERIE; }
			set {  _TB_CODEPLANTRESORERIE = value; }
		}

		public string TP_CODEPOSTETRESORERIE
		{
			get { return _TP_CODEPOSTETRESORERIE; }
			set {  _TP_CODEPOSTETRESORERIE = value; }
		}

		public DateTime TE_DATEDEBUT
		{
			get { return _TE_DATEDEBUT; }
			set {  _TE_DATEDEBUT = value; }
		}

		public DateTime TE_DATEFIN
		{
			get { return _TE_DATEFIN; }
			set {  _TE_DATEFIN = value; }
		}

		public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set {  _AG_CODEAGENCE = value; }
		}

		public string PV_CODEPOINTVENTE
		{
			get { return _PV_CODEPOINTVENTE; }
			set {  _PV_CODEPOINTVENTE = value; }
		}

		public string PE_CODEPERIODICITE
		{
			get { return _PE_CODEPERIODICITE; }
			set {  _PE_CODEPERIODICITE = value; }
		}

		public double TE_MONTANT
		{
			get { return _TE_MONTANT; }
			set {  _TE_MONTANT = value; }
		}

		public DateTime TE_DATESAISIE
		{
			get { return _TE_DATESAISIE; }
			set {  _TE_DATESAISIE = value; }
		}

		public DateTime TE_DATEVALIDATION
		{
			get { return _TE_DATEVALIDATION; }
			set {  _TE_DATEVALIDATION = value; }
		}

		public string OP_CODEOPERATEURVALIDATION
		{
			get { return _OP_CODEOPERATEURVALIDATION; }
			set {  _OP_CODEOPERATEURVALIDATION = value; }
		}

		public string OP_CODEOPERATEUR
		{
			get { return _OP_CODEOPERATEUR; }
			set {  _OP_CODEOPERATEUR = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsTresorerieplantresoreriedetail(){}
		public clsTresorerieplantresoreriedetail( string TB_CODEPLANTRESORERIE,string TP_CODEPOSTETRESORERIE,DateTime TE_DATEDEBUT,DateTime TE_DATEFIN,string AG_CODEAGENCE,string PV_CODEPOINTVENTE,string PE_CODEPERIODICITE,double TE_MONTANT,DateTime TE_DATESAISIE,DateTime TE_DATEVALIDATION,string OP_CODEOPERATEURVALIDATION,string OP_CODEOPERATEUR)
		{
			this.TB_CODEPLANTRESORERIE = TB_CODEPLANTRESORERIE;
			this.TP_CODEPOSTETRESORERIE = TP_CODEPOSTETRESORERIE;
			this.TE_DATEDEBUT = TE_DATEDEBUT;
			this.TE_DATEFIN = TE_DATEFIN;
			this.AG_CODEAGENCE = AG_CODEAGENCE;
			this.PV_CODEPOINTVENTE = PV_CODEPOINTVENTE;
			this.PE_CODEPERIODICITE = PE_CODEPERIODICITE;
			this.TE_MONTANT = TE_MONTANT;
			this.TE_DATESAISIE = TE_DATESAISIE;
			this.TE_DATEVALIDATION = TE_DATEVALIDATION;
			this.OP_CODEOPERATEURVALIDATION = OP_CODEOPERATEURVALIDATION;
			this.OP_CODEOPERATEUR = OP_CODEOPERATEUR;
		}
		public clsTresorerieplantresoreriedetail(clsTresorerieplantresoreriedetail clsTresorerieplantresoreriedetail)
		{
			this.TB_CODEPLANTRESORERIE = clsTresorerieplantresoreriedetail.TB_CODEPLANTRESORERIE;
			this.TP_CODEPOSTETRESORERIE = clsTresorerieplantresoreriedetail.TP_CODEPOSTETRESORERIE;
			this.TE_DATEDEBUT = clsTresorerieplantresoreriedetail.TE_DATEDEBUT;
			this.TE_DATEFIN = clsTresorerieplantresoreriedetail.TE_DATEFIN;
			this.AG_CODEAGENCE = clsTresorerieplantresoreriedetail.AG_CODEAGENCE;
			this.PV_CODEPOINTVENTE = clsTresorerieplantresoreriedetail.PV_CODEPOINTVENTE;
			this.PE_CODEPERIODICITE = clsTresorerieplantresoreriedetail.PE_CODEPERIODICITE;
			this.TE_MONTANT = clsTresorerieplantresoreriedetail.TE_MONTANT;
			this.TE_DATESAISIE = clsTresorerieplantresoreriedetail.TE_DATESAISIE;
			this.TE_DATEVALIDATION = clsTresorerieplantresoreriedetail.TE_DATEVALIDATION;
			this.OP_CODEOPERATEURVALIDATION = clsTresorerieplantresoreriedetail.OP_CODEOPERATEURVALIDATION;
			this.OP_CODEOPERATEUR = clsTresorerieplantresoreriedetail.OP_CODEOPERATEUR;
		}

		#endregion

	}
}
