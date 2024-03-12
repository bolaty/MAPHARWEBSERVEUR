using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsPhaparchassis
	{
		#region VARIABLES LOCALES

        private string _AG_CODEAGENCE = "";
        private string _CH_CODECHASSIS = "";
		private string _AR_CODEARTICLE = "";
		private int _CH_HAUTEUR = 0;
		private int _CH_LARGEUR = 0;
		private int _CH_LONGEUR = 0;
		private int _CH_POIDSENSERVICE = 0;
		private int _CH_POIDSAVIDE = 0;
		private int _CH_POIDSTOTALROULANT = 0;
		private string _CH_NUMEROSERIE = "";
		private int _CH_EMPLACEMENTVEHICULE = 0;
		private int _CH_EMPREINTEAUSOL = 0;
		private int _CH_NOMBREDEVOLUME = 0;
		private int _CH_NOMBREDEPORTE = 0;
		private int _CH_NOMBREDEPLACEASSISE = 0;
		private int _CH_EMPLACEMENT = 0;
		private int _CH_VOIEESSIEUAVANT = 0;
		private int _CH_VOIEESSIEUARRIERE = 0;
		private int _CH_PROPULSEURAVAR = 0;
		private DateTime _CH_DATEDERNIERECARTEGRISE = DateTime.Parse("01/01/1900");
        private DateTime _CH_DATEAVANTDERNIERECARTEGRISE = DateTime.Parse("01/01/1900");
		private int _CH_NOMBREDEMAINSVEHICULE = 0;
        private string _OP_CODEOPERATEUR = "";

		#endregion

		#region ACCESSEURS

        public string AG_CODEAGENCE
        {
            get { return _AG_CODEAGENCE; }
            set { _AG_CODEAGENCE = value; }
        }

		public string CH_CODECHASSIS
		{
			get { return _CH_CODECHASSIS; }
			set {  _CH_CODECHASSIS = value; }
		}

		public string AR_CODEARTICLE
		{
			get { return _AR_CODEARTICLE; }
			set {  _AR_CODEARTICLE = value; }
		}

		public int CH_HAUTEUR
		{
			get { return _CH_HAUTEUR; }
			set {  _CH_HAUTEUR = value; }
		}

		public int CH_LARGEUR
		{
			get { return _CH_LARGEUR; }
			set {  _CH_LARGEUR = value; }
		}

		public int CH_LONGEUR
		{
			get { return _CH_LONGEUR; }
			set {  _CH_LONGEUR = value; }
		}

		public int CH_POIDSENSERVICE
		{
			get { return _CH_POIDSENSERVICE; }
			set {  _CH_POIDSENSERVICE = value; }
		}

		public int CH_POIDSAVIDE
		{
			get { return _CH_POIDSAVIDE; }
			set {  _CH_POIDSAVIDE = value; }
		}

		public int CH_POIDSTOTALROULANT
		{
			get { return _CH_POIDSTOTALROULANT; }
			set {  _CH_POIDSTOTALROULANT = value; }
		}

		public string CH_NUMEROSERIE
		{
			get { return _CH_NUMEROSERIE; }
			set {  _CH_NUMEROSERIE = value; }
		}

		public int CH_EMPLACEMENTVEHICULE
		{
			get { return _CH_EMPLACEMENTVEHICULE; }
			set {  _CH_EMPLACEMENTVEHICULE = value; }
		}

		public int CH_EMPREINTEAUSOL
		{
			get { return _CH_EMPREINTEAUSOL; }
			set {  _CH_EMPREINTEAUSOL = value; }
		}

		public int CH_NOMBREDEVOLUME
		{
			get { return _CH_NOMBREDEVOLUME; }
			set {  _CH_NOMBREDEVOLUME = value; }
		}

		public int CH_NOMBREDEPORTE
		{
			get { return _CH_NOMBREDEPORTE; }
			set {  _CH_NOMBREDEPORTE = value; }
		}

		public int CH_NOMBREDEPLACEASSISE
		{
			get { return _CH_NOMBREDEPLACEASSISE; }
			set {  _CH_NOMBREDEPLACEASSISE = value; }
		}

		public int CH_EMPLACEMENT
		{
			get { return _CH_EMPLACEMENT; }
			set {  _CH_EMPLACEMENT = value; }
		}

		public int CH_VOIEESSIEUAVANT
		{
			get { return _CH_VOIEESSIEUAVANT; }
			set {  _CH_VOIEESSIEUAVANT = value; }
		}

		public int CH_VOIEESSIEUARRIERE
		{
			get { return _CH_VOIEESSIEUARRIERE; }
			set {  _CH_VOIEESSIEUARRIERE = value; }
		}

		public int CH_PROPULSEURAVAR
		{
			get { return _CH_PROPULSEURAVAR; }
			set {  _CH_PROPULSEURAVAR = value; }
		}

		public DateTime CH_DATEDERNIERECARTEGRISE
		{
			get { return _CH_DATEDERNIERECARTEGRISE; }
			set {  _CH_DATEDERNIERECARTEGRISE = value; }
		}


        public DateTime CH_DATEAVANTDERNIERECARTEGRISE
		{
            get { return _CH_DATEAVANTDERNIERECARTEGRISE; }
            set { _CH_DATEAVANTDERNIERECARTEGRISE = value; }
		}

		public int CH_NOMBREDEMAINSVEHICULE
		{
			get { return _CH_NOMBREDEMAINSVEHICULE; }
			set {  _CH_NOMBREDEMAINSVEHICULE = value; }
		}

        public string OP_CODEOPERATEUR
        {
            get { return _OP_CODEOPERATEUR; }
            set { _OP_CODEOPERATEUR = value; }
        }
		#endregion

		#region INSTANCIATEURS

		public clsPhaparchassis(){}
		
		public clsPhaparchassis(clsPhaparchassis clsPhaparchassis)
		{
            this.AG_CODEAGENCE = clsPhaparchassis.AG_CODEAGENCE;
            this.CH_CODECHASSIS = clsPhaparchassis.CH_CODECHASSIS;
			this.AR_CODEARTICLE = clsPhaparchassis.AR_CODEARTICLE;
			this.CH_HAUTEUR = clsPhaparchassis.CH_HAUTEUR;
			this.CH_LARGEUR = clsPhaparchassis.CH_LARGEUR;
			this.CH_LONGEUR = clsPhaparchassis.CH_LONGEUR;
			this.CH_POIDSENSERVICE = clsPhaparchassis.CH_POIDSENSERVICE;
			this.CH_POIDSAVIDE = clsPhaparchassis.CH_POIDSAVIDE;
			this.CH_POIDSTOTALROULANT = clsPhaparchassis.CH_POIDSTOTALROULANT;
			this.CH_NUMEROSERIE = clsPhaparchassis.CH_NUMEROSERIE;
			this.CH_EMPLACEMENTVEHICULE = clsPhaparchassis.CH_EMPLACEMENTVEHICULE;
			this.CH_EMPREINTEAUSOL = clsPhaparchassis.CH_EMPREINTEAUSOL;
			this.CH_NOMBREDEVOLUME = clsPhaparchassis.CH_NOMBREDEVOLUME;
			this.CH_NOMBREDEPORTE = clsPhaparchassis.CH_NOMBREDEPORTE;
			this.CH_NOMBREDEPLACEASSISE = clsPhaparchassis.CH_NOMBREDEPLACEASSISE;
			this.CH_EMPLACEMENT = clsPhaparchassis.CH_EMPLACEMENT;
			this.CH_VOIEESSIEUAVANT = clsPhaparchassis.CH_VOIEESSIEUAVANT;
			this.CH_VOIEESSIEUARRIERE = clsPhaparchassis.CH_VOIEESSIEUARRIERE;
			this.CH_PROPULSEURAVAR = clsPhaparchassis.CH_PROPULSEURAVAR;
			this.CH_DATEDERNIERECARTEGRISE = clsPhaparchassis.CH_DATEDERNIERECARTEGRISE;
			this.CH_NOMBREDEMAINSVEHICULE = clsPhaparchassis.CH_NOMBREDEMAINSVEHICULE;
            this.OP_CODEOPERATEUR = clsPhaparchassis.OP_CODEOPERATEUR;
		}

		#endregion

	}
}
