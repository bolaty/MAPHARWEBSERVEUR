using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsPhaparetatfacture
	{
		#region VARIABLES LOCALES

		private string _EF_INDEX = "";
		private string _MG_CODEMODEGESTION = "";
		private string _EC_CODECRAN = "";
		private string _EF_NOMGROUPE = "";
		private string _EF_NOMETAT = "";
		private string _EF_LIBELLEETAT = "";
		private string _EF_NOMETATSOUSETAT1 = "";
		private string _EF_NOMETATSOUSETAT2 = "";
		private string _EF_AFFICHER = "";
		private string _EF_DOSSIER = "";
		private string _EF_TYPEETAT = "";

		#endregion

		#region ACCESSEURS

		public string EF_INDEX
		{
			get { return _EF_INDEX; }
			set {  _EF_INDEX = value; }
		}

		public string MG_CODEMODEGESTION
		{
			get { return _MG_CODEMODEGESTION; }
			set {  _MG_CODEMODEGESTION = value; }
		}

		public string EC_CODECRAN
		{
			get { return _EC_CODECRAN; }
			set {  _EC_CODECRAN = value; }
		}

		public string EF_NOMGROUPE
		{
			get { return _EF_NOMGROUPE; }
			set {  _EF_NOMGROUPE = value; }
		}

		public string EF_NOMETAT
		{
			get { return _EF_NOMETAT; }
			set {  _EF_NOMETAT = value; }
		}

		public string EF_LIBELLEETAT
		{
			get { return _EF_LIBELLEETAT; }
			set {  _EF_LIBELLEETAT = value; }
		}

		public string EF_NOMETATSOUSETAT1
		{
			get { return _EF_NOMETATSOUSETAT1; }
			set {  _EF_NOMETATSOUSETAT1 = value; }
		}

		public string EF_NOMETATSOUSETAT2
		{
			get { return _EF_NOMETATSOUSETAT2; }
			set {  _EF_NOMETATSOUSETAT2 = value; }
		}

		public string EF_AFFICHER
		{
			get { return _EF_AFFICHER; }
			set {  _EF_AFFICHER = value; }
		}

		public string EF_DOSSIER
		{
			get { return _EF_DOSSIER; }
			set {  _EF_DOSSIER = value; }
		}

		public string EF_TYPEETAT
		{
			get { return _EF_TYPEETAT; }
			set {  _EF_TYPEETAT = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsPhaparetatfacture(){}
		public clsPhaparetatfacture( string EF_INDEX,string MG_CODEMODEGESTION,string EC_CODECRAN,string EF_NOMGROUPE,string EF_NOMETAT,string EF_LIBELLEETAT,string EF_NOMETATSOUSETAT1,string EF_NOMETATSOUSETAT2,string EF_AFFICHER,string EF_DOSSIER,string EF_TYPEETAT)
		{
			this.EF_INDEX = EF_INDEX;
			this.MG_CODEMODEGESTION = MG_CODEMODEGESTION;
			this.EC_CODECRAN = EC_CODECRAN;
			this.EF_NOMGROUPE = EF_NOMGROUPE;
			this.EF_NOMETAT = EF_NOMETAT;
			this.EF_LIBELLEETAT = EF_LIBELLEETAT;
			this.EF_NOMETATSOUSETAT1 = EF_NOMETATSOUSETAT1;
			this.EF_NOMETATSOUSETAT2 = EF_NOMETATSOUSETAT2;
			this.EF_AFFICHER = EF_AFFICHER;
			this.EF_DOSSIER = EF_DOSSIER;
			this.EF_TYPEETAT = EF_TYPEETAT;
		}
		public clsPhaparetatfacture(clsPhaparetatfacture clsPhaparetatfacture)
		{
			this.EF_INDEX = clsPhaparetatfacture.EF_INDEX;
			this.MG_CODEMODEGESTION = clsPhaparetatfacture.MG_CODEMODEGESTION;
			this.EC_CODECRAN = clsPhaparetatfacture.EC_CODECRAN;
			this.EF_NOMGROUPE = clsPhaparetatfacture.EF_NOMGROUPE;
			this.EF_NOMETAT = clsPhaparetatfacture.EF_NOMETAT;
			this.EF_LIBELLEETAT = clsPhaparetatfacture.EF_LIBELLEETAT;
			this.EF_NOMETATSOUSETAT1 = clsPhaparetatfacture.EF_NOMETATSOUSETAT1;
			this.EF_NOMETATSOUSETAT2 = clsPhaparetatfacture.EF_NOMETATSOUSETAT2;
			this.EF_AFFICHER = clsPhaparetatfacture.EF_AFFICHER;
			this.EF_DOSSIER = clsPhaparetatfacture.EF_DOSSIER;
			this.EF_TYPEETAT = clsPhaparetatfacture.EF_TYPEETAT;
		}

		#endregion

	}
}
