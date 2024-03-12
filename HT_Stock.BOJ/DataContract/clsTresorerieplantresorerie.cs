using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsTresorerieplantresorerie
	{
		#region VARIABLES LOCALES

		private string _TB_CODEPLANTRESORERIE = "";
		private string _AG_CODEAGENCE = "";
		private string _PV_CODEPOINTVENTE = "";
		private string _TB_LIBELLE = "";
		private DateTime _TB_DATESAISIE = DateTime.Parse("01/01/1900");
		private string _TB_CODEPLANTRESORERIELIAISON = "";
		private string _OP_CODEOPERATEUR = "";
		private DateTime _TB_DATEDEBUT = DateTime.Parse("01/01/1900");
		private DateTime _TB_DATEFIN = DateTime.Parse("01/01/1900");

		#endregion

		#region ACCESSEURS

		public string TB_CODEPLANTRESORERIE
		{
			get { return _TB_CODEPLANTRESORERIE; }
			set {  _TB_CODEPLANTRESORERIE = value; }
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

		public string TB_LIBELLE
		{
			get { return _TB_LIBELLE; }
			set {  _TB_LIBELLE = value; }
		}

		public DateTime TB_DATESAISIE
		{
			get { return _TB_DATESAISIE; }
			set {  _TB_DATESAISIE = value; }
		}

		public string TB_CODEPLANTRESORERIELIAISON
		{
			get { return _TB_CODEPLANTRESORERIELIAISON; }
			set {  _TB_CODEPLANTRESORERIELIAISON = value; }
		}

		public string OP_CODEOPERATEUR
		{
			get { return _OP_CODEOPERATEUR; }
			set {  _OP_CODEOPERATEUR = value; }
		}

		public DateTime TB_DATEDEBUT
		{
			get { return _TB_DATEDEBUT; }
			set {  _TB_DATEDEBUT = value; }
		}

		public DateTime TB_DATEFIN
		{
			get { return _TB_DATEFIN; }
			set {  _TB_DATEFIN = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsTresorerieplantresorerie(){}
		public clsTresorerieplantresorerie( string TB_CODEPLANTRESORERIE,string AG_CODEAGENCE,string PV_CODEPOINTVENTE,string TB_LIBELLE,DateTime TB_DATESAISIE,string TB_CODEPLANTRESORERIELIAISON,string OP_CODEOPERATEUR,DateTime TB_DATEDEBUT,DateTime TB_DATEFIN)
		{
			this.TB_CODEPLANTRESORERIE = TB_CODEPLANTRESORERIE;
			this.AG_CODEAGENCE = AG_CODEAGENCE;
			this.PV_CODEPOINTVENTE = PV_CODEPOINTVENTE;
			this.TB_LIBELLE = TB_LIBELLE;
			this.TB_DATESAISIE = TB_DATESAISIE;
			this.TB_CODEPLANTRESORERIELIAISON = TB_CODEPLANTRESORERIELIAISON;
			this.OP_CODEOPERATEUR = OP_CODEOPERATEUR;
			this.TB_DATEDEBUT = TB_DATEDEBUT;
			this.TB_DATEFIN = TB_DATEFIN;
		}
		public clsTresorerieplantresorerie(clsTresorerieplantresorerie clsTresorerieplantresorerie)
		{
			this.TB_CODEPLANTRESORERIE = clsTresorerieplantresorerie.TB_CODEPLANTRESORERIE;
			this.AG_CODEAGENCE = clsTresorerieplantresorerie.AG_CODEAGENCE;
			this.PV_CODEPOINTVENTE = clsTresorerieplantresorerie.PV_CODEPOINTVENTE;
			this.TB_LIBELLE = clsTresorerieplantresorerie.TB_LIBELLE;
			this.TB_DATESAISIE = clsTresorerieplantresorerie.TB_DATESAISIE;
			this.TB_CODEPLANTRESORERIELIAISON = clsTresorerieplantresorerie.TB_CODEPLANTRESORERIELIAISON;
			this.OP_CODEOPERATEUR = clsTresorerieplantresorerie.OP_CODEOPERATEUR;
			this.TB_DATEDEBUT = clsTresorerieplantresorerie.TB_DATEDEBUT;
			this.TB_DATEFIN = clsTresorerieplantresorerie.TB_DATEFIN;
		}

		#endregion

	}
}
