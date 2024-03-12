using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsPhaparmoteur
	{
		#region VARIABLES LOCALES
        private string _AG_CODEAGENCE = "";
		private string _MO_CODEMOTEUR = "";
		private string _AR_CODEARTICLE = "";
		private int _MO_CYLINDREE = 0;
		private int _MO_PUISSANCEENDIN = 0;
		private int _MO_PUISSANCEENKW = 0;
		private int _MO_PUISSANCEFISCALE = 0;
		private int _MO_NOMBREDEDECIBELS = 0;
		private int _MO_REGIMEMOTEUR = 0;
		private string _MO_NUMERODEBOITE = "";
		private string _MO_DEPOLUANTFAP = "";
		private string _BO_CODETYPEBOITE = "";
		private int _MO_NOMBREDESOUPAPES = 0;
		private int _MO_NOMBREDEVITESSES = 0;
		private string _IN_CODEMODEINJECTION = "";
		private string _MO_TURBOCOMPRESSEUR = "";
		private string _MO_NUMEROMOTEUR = "";
		private int _MO_NOMBREDECYLINDRE = 0;
		private int _MO_CONSOMMATIONEXTRAURBAINE = 0;
		private int _MO_CONSOMMATIONMIXTE = 0;
        private int _MO_CONSOMMATIONURBAINE = 0;
		private int _MO_CO2 = 0;
        private string _OP_CODEOPERATEUR = "";

		#endregion

		#region ACCESSEURS
        public string AG_CODEAGENCE
        {
            get { return _AG_CODEAGENCE; }
            set { _AG_CODEAGENCE = value; }
        }
		public string MO_CODEMOTEUR
		{
			get { return _MO_CODEMOTEUR; }
			set {  _MO_CODEMOTEUR = value; }
		}

		public string AR_CODEARTICLE
		{
			get { return _AR_CODEARTICLE; }
			set {  _AR_CODEARTICLE = value; }
		}

		public int MO_CYLINDREE
		{
			get { return _MO_CYLINDREE; }
			set {  _MO_CYLINDREE = value; }
		}

		public int MO_PUISSANCEENDIN
		{
			get { return _MO_PUISSANCEENDIN; }
			set {  _MO_PUISSANCEENDIN = value; }
		}

		public int MO_PUISSANCEENKW
		{
			get { return _MO_PUISSANCEENKW; }
			set {  _MO_PUISSANCEENKW = value; }
		}

		public int MO_PUISSANCEFISCALE
		{
			get { return _MO_PUISSANCEFISCALE; }
			set {  _MO_PUISSANCEFISCALE = value; }
		}

		public int MO_NOMBREDEDECIBELS
		{
			get { return _MO_NOMBREDEDECIBELS; }
			set {  _MO_NOMBREDEDECIBELS = value; }
		}

		public int MO_REGIMEMOTEUR
		{
			get { return _MO_REGIMEMOTEUR; }
			set {  _MO_REGIMEMOTEUR = value; }
		}

		public string MO_NUMERODEBOITE
		{
			get { return _MO_NUMERODEBOITE; }
			set {  _MO_NUMERODEBOITE = value; }
		}

		public string MO_DEPOLUANTFAP
		{
			get { return _MO_DEPOLUANTFAP; }
			set {  _MO_DEPOLUANTFAP = value; }
		}

		public string BO_CODETYPEBOITE
		{
			get { return _BO_CODETYPEBOITE; }
			set {  _BO_CODETYPEBOITE = value; }
		}

		public int MO_NOMBREDESOUPAPES
		{
			get { return _MO_NOMBREDESOUPAPES; }
			set {  _MO_NOMBREDESOUPAPES = value; }
		}

		public int MO_NOMBREDEVITESSES
		{
			get { return _MO_NOMBREDEVITESSES; }
			set {  _MO_NOMBREDEVITESSES = value; }
		}

		public string IN_CODEMODEINJECTION
		{
			get { return _IN_CODEMODEINJECTION; }
			set {  _IN_CODEMODEINJECTION = value; }
		}

		public string MO_TURBOCOMPRESSEUR
		{
			get { return _MO_TURBOCOMPRESSEUR; }
			set {  _MO_TURBOCOMPRESSEUR = value; }
		}

		public string MO_NUMEROMOTEUR
		{
			get { return _MO_NUMEROMOTEUR; }
			set {  _MO_NUMEROMOTEUR = value; }
		}

		public int MO_NOMBREDECYLINDRE
		{
			get { return _MO_NOMBREDECYLINDRE; }
			set {  _MO_NOMBREDECYLINDRE = value; }
		}

		public int MO_CONSOMMATIONEXTRAURBAINE
		{
			get { return _MO_CONSOMMATIONEXTRAURBAINE; }
			set {  _MO_CONSOMMATIONEXTRAURBAINE = value; }
		}

		public int MO_CONSOMMATIONMIXTE
		{
			get { return _MO_CONSOMMATIONMIXTE; }
			set {  _MO_CONSOMMATIONMIXTE = value; }
		}

        public int MO_CONSOMMATIONURBAINE
        {
            get { return _MO_CONSOMMATIONURBAINE; }
            set { _MO_CONSOMMATIONURBAINE = value; }
        }

		public int MO_CO2
		{
			get { return _MO_CO2; }
			set {  _MO_CO2 = value; }
		}

        public string OP_CODEOPERATEUR
        {
            get { return _OP_CODEOPERATEUR; }
            set { _OP_CODEOPERATEUR = value; }
        }
		#endregion

		#region INSTANCIATEURS

		public clsPhaparmoteur(){}
		
		public clsPhaparmoteur(clsPhaparmoteur clsPhaparmoteur)
		{
            this.AG_CODEAGENCE = clsPhaparmoteur.AG_CODEAGENCE;
            this.MO_CODEMOTEUR = clsPhaparmoteur.MO_CODEMOTEUR;
			this.AR_CODEARTICLE = clsPhaparmoteur.AR_CODEARTICLE;
			this.MO_CYLINDREE = clsPhaparmoteur.MO_CYLINDREE;
			this.MO_PUISSANCEENDIN = clsPhaparmoteur.MO_PUISSANCEENDIN;
			this.MO_PUISSANCEENKW = clsPhaparmoteur.MO_PUISSANCEENKW;
			this.MO_PUISSANCEFISCALE = clsPhaparmoteur.MO_PUISSANCEFISCALE;
			this.MO_NOMBREDEDECIBELS = clsPhaparmoteur.MO_NOMBREDEDECIBELS;
			this.MO_REGIMEMOTEUR = clsPhaparmoteur.MO_REGIMEMOTEUR;
			this.MO_NUMERODEBOITE = clsPhaparmoteur.MO_NUMERODEBOITE;
			this.MO_DEPOLUANTFAP = clsPhaparmoteur.MO_DEPOLUANTFAP;
			this.BO_CODETYPEBOITE = clsPhaparmoteur.BO_CODETYPEBOITE;
			this.MO_NOMBREDESOUPAPES = clsPhaparmoteur.MO_NOMBREDESOUPAPES;
			this.MO_NOMBREDEVITESSES = clsPhaparmoteur.MO_NOMBREDEVITESSES;
			this.IN_CODEMODEINJECTION = clsPhaparmoteur.IN_CODEMODEINJECTION;
			this.MO_TURBOCOMPRESSEUR = clsPhaparmoteur.MO_TURBOCOMPRESSEUR;
			this.MO_NUMEROMOTEUR = clsPhaparmoteur.MO_NUMEROMOTEUR;
			this.MO_NOMBREDECYLINDRE = clsPhaparmoteur.MO_NOMBREDECYLINDRE;
			this.MO_CONSOMMATIONEXTRAURBAINE = clsPhaparmoteur.MO_CONSOMMATIONEXTRAURBAINE;
			this.MO_CONSOMMATIONMIXTE = clsPhaparmoteur.MO_CONSOMMATIONMIXTE;
            this.MO_CONSOMMATIONURBAINE = clsPhaparmoteur.MO_CONSOMMATIONURBAINE;
			this.MO_CO2 = clsPhaparmoteur.MO_CO2;
            this.OP_CODEOPERATEUR = clsPhaparmoteur.OP_CODEOPERATEUR;
		}

		#endregion

	}
}
