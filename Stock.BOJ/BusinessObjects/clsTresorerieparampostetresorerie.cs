using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsTresorerieparampostetresorerie
	{
		#region VARIABLES LOCALES

		private string _TP_CODEPOSTETRESORERIE = "";
		private string _TR_CODERUBRIQUETRESORERIE = "";
		private string _TN_CODENATUREPOSTETRESORERIE = "";
		private string _TV_CODETVA = "";
		private string _TP_LIBELLE = "";
		private decimal _TP_TAUX = 0;

		#endregion

		#region ACCESSEURS

		public string TP_CODEPOSTETRESORERIE
		{
			get { return _TP_CODEPOSTETRESORERIE; }
			set {  _TP_CODEPOSTETRESORERIE = value; }
		}

		public string TR_CODERUBRIQUETRESORERIE
		{
			get { return _TR_CODERUBRIQUETRESORERIE; }
			set {  _TR_CODERUBRIQUETRESORERIE = value; }
		}

		public string TN_CODENATUREPOSTETRESORERIE
		{
			get { return _TN_CODENATUREPOSTETRESORERIE; }
			set {  _TN_CODENATUREPOSTETRESORERIE = value; }
		}

		public string TV_CODETVA
		{
			get { return _TV_CODETVA; }
			set {  _TV_CODETVA = value; }
		}

		public string TP_LIBELLE
		{
			get { return _TP_LIBELLE; }
			set {  _TP_LIBELLE = value; }
		}

		public decimal TP_TAUX
		{
			get { return _TP_TAUX; }
			set {  _TP_TAUX = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsTresorerieparampostetresorerie(){}
		public clsTresorerieparampostetresorerie( string TP_CODEPOSTETRESORERIE,string TR_CODERUBRIQUETRESORERIE,string TN_CODENATUREPOSTETRESORERIE,string TV_CODETVA,string TP_LIBELLE,decimal TP_TAUX)
		{
			this.TP_CODEPOSTETRESORERIE = TP_CODEPOSTETRESORERIE;
			this.TR_CODERUBRIQUETRESORERIE = TR_CODERUBRIQUETRESORERIE;
			this.TN_CODENATUREPOSTETRESORERIE = TN_CODENATUREPOSTETRESORERIE;
			this.TV_CODETVA = TV_CODETVA;
			this.TP_LIBELLE = TP_LIBELLE;
			this.TP_TAUX = TP_TAUX;
		}
		public clsTresorerieparampostetresorerie(clsTresorerieparampostetresorerie clsTresorerieparampostetresorerie)
		{
			this.TP_CODEPOSTETRESORERIE = clsTresorerieparampostetresorerie.TP_CODEPOSTETRESORERIE;
			this.TR_CODERUBRIQUETRESORERIE = clsTresorerieparampostetresorerie.TR_CODERUBRIQUETRESORERIE;
			this.TN_CODENATUREPOSTETRESORERIE = clsTresorerieparampostetresorerie.TN_CODENATUREPOSTETRESORERIE;
			this.TV_CODETVA = clsTresorerieparampostetresorerie.TV_CODETVA;
			this.TP_LIBELLE = clsTresorerieparampostetresorerie.TP_LIBELLE;
			this.TP_TAUX = clsTresorerieparampostetresorerie.TP_TAUX;
		}

		#endregion

	}
}
