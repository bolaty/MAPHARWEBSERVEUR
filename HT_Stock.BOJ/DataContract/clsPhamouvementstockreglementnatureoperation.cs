using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsPhamouvementstockreglementnatureoperation : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _NO_CODENATUREOPERATION = "";
		private string _NO_LIBELLE = "";
		private string _NO_ABREVIATION = "";
		private string _FO_CODEFAMILLEOPERATION = "";

        private string _RO_CODENATUREOPERATIONTYPE = "";


        private string _NF_CODENATUREFAMILLEOPERATION = "";

		private string _PL_CODENUMCOMPTE = "";
        private string _PL_NUMCOMPTE = "";

        private string _PL_CODENUMCOMPTECONTREPARTIE = "";
        private string _PL_NUMCOMPTECONTREPARTIE = "";

		private string _NO_SENS = "";
		private string _NO_PREFIXECOMPTE = "";
		private string _NO_REFPIECE = "";
		private double _NO_MONTANT = 0;
		private string _NO_AFFICHER = "";
		private string _PL_CODENUMCOMPTESURPLUS = "";
        private string _PL_NUMCOMPTESURPLUS = "";
		private string _NO_OPERATIONSYSTEME = "";
		private string _NO_ECRAN = "";
        private string _NO_MODIFIERMONTANT = "";
		private int _NO_NUMEROORDRE = 0;


        private string _NC_CODENATURECOMPTE = "";
        private string _NC_CODENATURECOMPTECONTREPARTIE = "";
        private string _JO_CODEJOURNAL = "";
        private string _JO_LIBELLE = "";
        private string _NC_LIBELLENATURECOMPTE = "";
        private string _NO_SENSLIBELLE = "";
        private string _NC_LIBELLENATURECOMPTECONTREPARTIE = "";
        #endregion

        #region ACCESSEURS

        public string NO_CODENATUREOPERATION
		{
			get { return _NO_CODENATUREOPERATION; }
			set {  _NO_CODENATUREOPERATION = value; }
		}

		public string NO_LIBELLE
		{
			get { return _NO_LIBELLE; }
			set {  _NO_LIBELLE = value; }
		}

		public string NO_ABREVIATION
		{
			get { return _NO_ABREVIATION; }
			set {  _NO_ABREVIATION = value; }
		}

		public string FO_CODEFAMILLEOPERATION
		{
			get { return _FO_CODEFAMILLEOPERATION; }
			set {  _FO_CODEFAMILLEOPERATION = value; }
		}

        public string RO_CODENATUREOPERATIONTYPE
        {
            get { return _RO_CODENATUREOPERATIONTYPE; }
            set { _RO_CODENATUREOPERATIONTYPE = value; }
        }



        public string NF_CODENATUREFAMILLEOPERATION
        {
	        get { return _NF_CODENATUREFAMILLEOPERATION; }
	        set { _NF_CODENATUREFAMILLEOPERATION = value; }
        }



		public string PL_CODENUMCOMPTE
		{
			get { return _PL_CODENUMCOMPTE; }
			set {  _PL_CODENUMCOMPTE = value; }
		}

        public string PL_NUMCOMPTE
		{
            get { return _PL_NUMCOMPTE; }
            set { _PL_NUMCOMPTE = value; }
		}



        public string PL_CODENUMCOMPTECONTREPARTIE
        {
	        get { return _PL_CODENUMCOMPTECONTREPARTIE; }
	        set { _PL_CODENUMCOMPTECONTREPARTIE = value; }
        }

        public string PL_NUMCOMPTECONTREPARTIE
        {
            get { return _PL_NUMCOMPTECONTREPARTIE; }
            set { _PL_NUMCOMPTECONTREPARTIE = value; }
        }


		public string NO_SENS
		{
			get { return _NO_SENS; }
			set {  _NO_SENS = value; }
		}

		public string NO_PREFIXECOMPTE
		{
			get { return _NO_PREFIXECOMPTE; }
			set {  _NO_PREFIXECOMPTE = value; }
		}

		public string NO_REFPIECE
		{
			get { return _NO_REFPIECE; }
			set {  _NO_REFPIECE = value; }
		}

		public double NO_MONTANT
		{
			get { return _NO_MONTANT; }
			set {  _NO_MONTANT = value; }
		}

		public string NO_AFFICHER
		{
			get { return _NO_AFFICHER; }
			set {  _NO_AFFICHER = value; }
		}

		public string PL_CODENUMCOMPTESURPLUS
		{
			get { return _PL_CODENUMCOMPTESURPLUS; }
			set {  _PL_CODENUMCOMPTESURPLUS = value; }
		}

        public string PL_NUMCOMPTESURPLUS
		{
            get { return _PL_NUMCOMPTESURPLUS; }
            set { _PL_NUMCOMPTESURPLUS = value; }
		}

		public string NO_OPERATIONSYSTEME
		{
			get { return _NO_OPERATIONSYSTEME; }
			set {  _NO_OPERATIONSYSTEME = value; }
		}

		public string NO_ECRAN
		{
			get { return _NO_ECRAN; }
			set {  _NO_ECRAN = value; }
		}

        public string NO_MODIFIERMONTANT
        {
	        get { return _NO_MODIFIERMONTANT; }
	        set { _NO_MODIFIERMONTANT = value; }
        }

		public int NO_NUMEROORDRE
		{
			get { return _NO_NUMEROORDRE; }
			set {  _NO_NUMEROORDRE = value; }
		}





        public string NC_CODENATURECOMPTE
        {
            get { return _NC_CODENATURECOMPTE; }
            set { _NC_CODENATURECOMPTE = value; }
        }

        public string NC_CODENATURECOMPTECONTREPARTIE
        {
            get { return _NC_CODENATURECOMPTECONTREPARTIE; }
            set { _NC_CODENATURECOMPTECONTREPARTIE = value; }
        }

        public string JO_CODEJOURNAL
        {
            get { return _JO_CODEJOURNAL; }
            set { _JO_CODEJOURNAL = value; }
        }
        public string JO_LIBELLE
        {
            get { return _JO_LIBELLE; }
            set { _JO_LIBELLE = value; }
        }
        public string NC_LIBELLENATURECOMPTE
        {
            get { return _NC_LIBELLENATURECOMPTE; }
            set { _NC_LIBELLENATURECOMPTE = value; }
        }
        public string NO_SENSLIBELLE
        {
            get { return _NO_SENSLIBELLE; }
            set { _NO_SENSLIBELLE = value; }
        }
        public string NC_LIBELLENATURECOMPTECONTREPARTIE
        {
            get { return _NC_LIBELLENATURECOMPTECONTREPARTIE; }
            set { _NC_LIBELLENATURECOMPTECONTREPARTIE = value; }
        }


        #endregion

        #region INSTANCIATEURS

        public clsPhamouvementstockreglementnatureoperation(){}
		
		public clsPhamouvementstockreglementnatureoperation(clsPhamouvementstockreglementnatureoperation clsPhamouvementstockreglementnatureoperation)
		{
			this.NO_CODENATUREOPERATION = clsPhamouvementstockreglementnatureoperation.NO_CODENATUREOPERATION;
			this.NO_LIBELLE = clsPhamouvementstockreglementnatureoperation.NO_LIBELLE;
			this.NO_ABREVIATION = clsPhamouvementstockreglementnatureoperation.NO_ABREVIATION;
			this.FO_CODEFAMILLEOPERATION = clsPhamouvementstockreglementnatureoperation.FO_CODEFAMILLEOPERATION;
            this.RO_CODENATUREOPERATIONTYPE = clsPhamouvementstockreglementnatureoperation.RO_CODENATUREOPERATIONTYPE;


			this.NF_CODENATUREFAMILLEOPERATION = clsPhamouvementstockreglementnatureoperation.NF_CODENATUREFAMILLEOPERATION;

			this.PL_CODENUMCOMPTE = clsPhamouvementstockreglementnatureoperation.PL_CODENUMCOMPTE;
            this.PL_NUMCOMPTE = clsPhamouvementstockreglementnatureoperation.PL_NUMCOMPTE;

            this.PL_CODENUMCOMPTECONTREPARTIE = clsPhamouvementstockreglementnatureoperation.PL_CODENUMCOMPTECONTREPARTIE;
            this.PL_NUMCOMPTECONTREPARTIE = clsPhamouvementstockreglementnatureoperation.PL_NUMCOMPTECONTREPARTIE;

			this.NO_SENS = clsPhamouvementstockreglementnatureoperation.NO_SENS;
			this.NO_PREFIXECOMPTE = clsPhamouvementstockreglementnatureoperation.NO_PREFIXECOMPTE;
			this.NO_REFPIECE = clsPhamouvementstockreglementnatureoperation.NO_REFPIECE;
			this.NO_MONTANT = clsPhamouvementstockreglementnatureoperation.NO_MONTANT;
			this.NO_AFFICHER = clsPhamouvementstockreglementnatureoperation.NO_AFFICHER;
			this.PL_CODENUMCOMPTESURPLUS = clsPhamouvementstockreglementnatureoperation.PL_CODENUMCOMPTESURPLUS;
            this.PL_NUMCOMPTESURPLUS = clsPhamouvementstockreglementnatureoperation.PL_NUMCOMPTESURPLUS;
			this.NO_OPERATIONSYSTEME = clsPhamouvementstockreglementnatureoperation.NO_OPERATIONSYSTEME;
			this.NO_ECRAN = clsPhamouvementstockreglementnatureoperation.NO_ECRAN;
			this.NO_NUMEROORDRE = clsPhamouvementstockreglementnatureoperation.NO_NUMEROORDRE;
            this.NO_MODIFIERMONTANT = clsPhamouvementstockreglementnatureoperation.NO_MODIFIERMONTANT;

            //this.TYPEOPERATION = clsPhamouvementstockreglementnatureoperation.TYPEOPERATION;

            this.NC_CODENATURECOMPTE = clsPhamouvementstockreglementnatureoperation.NC_CODENATURECOMPTE;
            this.NC_CODENATURECOMPTECONTREPARTIE = clsPhamouvementstockreglementnatureoperation.NC_CODENATURECOMPTECONTREPARTIE;
            this.JO_CODEJOURNAL = clsPhamouvementstockreglementnatureoperation.JO_CODEJOURNAL;
            this.JO_LIBELLE = clsPhamouvementstockreglementnatureoperation.JO_LIBELLE;
            this.NC_LIBELLENATURECOMPTE = clsPhamouvementstockreglementnatureoperation.NC_LIBELLENATURECOMPTE;
            this.NO_SENSLIBELLE = clsPhamouvementstockreglementnatureoperation.NO_SENSLIBELLE;
            this.NC_LIBELLENATURECOMPTECONTREPARTIE = clsPhamouvementstockreglementnatureoperation.NC_LIBELLENATURECOMPTECONTREPARTIE;

        }

		#endregion

	}
}
