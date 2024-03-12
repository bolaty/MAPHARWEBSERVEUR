using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsPhamouvementstocklivraison
	{
		#region VARIABLES LOCALES

		private string _LV_NUMSEQUENCE = "";
		private string _AG_CODEAGENCE = "";
		private string _CH_IDCHAUFFEUR = "";
        private string _TR_IDTRANSPORTEUR = "";
        private string _EN_CODEENTREPOT = "";
		private string _AR_CODEARTICLE = "";
		private string _MS_NUMPIECE = "";
		private string _NO_CODENATUREOPERATION = "";
		private double _LV_QUANTITELIVRER = 0;
		private DateTime _LV_DATELIVRAISON = DateTime.Parse("01/01/1900");
		private string _LV_ANNULATIONPIECE = "";
		private double _LV_NUMEROPIECE = 0;
		private double _LV_MONTANTVERSE = 0;
		private string _LV_REMETTANT = "";
		private string _LV_AGENTLIVREUR = "";
        private string _LV_NUMERIMMATRICULATION = "";
        private int _VH_CODEVEHICULE = 0;
        private int _TYPEOPERATION = 0;

		#endregion

		#region ACCESSEURS

		public string LV_NUMSEQUENCE
		{
			get { return _LV_NUMSEQUENCE; }
			set {  _LV_NUMSEQUENCE = value; }
		}

		public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set {  _AG_CODEAGENCE = value; }
		}

		public string CH_IDCHAUFFEUR
		{
			get { return _CH_IDCHAUFFEUR; }
			set {  _CH_IDCHAUFFEUR = value; }
		}

        public string TR_IDTRANSPORTEUR
		{
            get { return _TR_IDTRANSPORTEUR; }
            set { _TR_IDTRANSPORTEUR = value; }
		}

        public string EN_CODEENTREPOT
		{
            get { return _EN_CODEENTREPOT; }
            set { _EN_CODEENTREPOT = value; }
		}

		public string AR_CODEARTICLE
		{
			get { return _AR_CODEARTICLE; }
			set {  _AR_CODEARTICLE = value; }
		}

		public string MS_NUMPIECE
		{
			get { return _MS_NUMPIECE; }
			set {  _MS_NUMPIECE = value; }
		}

		public string NO_CODENATUREOPERATION
		{
			get { return _NO_CODENATUREOPERATION; }
			set {  _NO_CODENATUREOPERATION = value; }
		}

		public double LV_QUANTITELIVRER
		{
			get { return _LV_QUANTITELIVRER; }
			set {  _LV_QUANTITELIVRER = value; }
		}

		public DateTime LV_DATELIVRAISON
		{
			get { return _LV_DATELIVRAISON; }
			set {  _LV_DATELIVRAISON = value; }
		}

		public string LV_ANNULATIONPIECE
		{
			get { return _LV_ANNULATIONPIECE; }
			set {  _LV_ANNULATIONPIECE = value; }
		}

		public double LV_NUMEROPIECE
		{
			get { return _LV_NUMEROPIECE; }
			set {  _LV_NUMEROPIECE = value; }
		}

		public double LV_MONTANTVERSE
		{
			get { return _LV_MONTANTVERSE; }
			set {  _LV_MONTANTVERSE = value; }
		}

		public string LV_REMETTANT
		{
			get { return _LV_REMETTANT; }
			set {  _LV_REMETTANT = value; }
		}

		public string LV_AGENTLIVREUR
		{
			get { return _LV_AGENTLIVREUR; }
			set {  _LV_AGENTLIVREUR = value; }
		}

        public string LV_NUMERIMMATRICULATION 
		{
            get { return _LV_NUMERIMMATRICULATION; }
            set { _LV_NUMERIMMATRICULATION = value; }
		}
        public int VH_CODEVEHICULE 
		{
            get { return _VH_CODEVEHICULE; }
            set { _VH_CODEVEHICULE = value; }
		}


        public int TYPEOPERATION
        {
            get { return _TYPEOPERATION; }
            set { _TYPEOPERATION = value; }
        }


		#endregion

		#region INSTANCIATEURS

		public clsPhamouvementstocklivraison(){}
		
		public clsPhamouvementstocklivraison(clsPhamouvementstocklivraison clsPhamouvementstocklivraison)
		{
			this.LV_NUMSEQUENCE = clsPhamouvementstocklivraison.LV_NUMSEQUENCE;
			this.AG_CODEAGENCE = clsPhamouvementstocklivraison.AG_CODEAGENCE;
			this.CH_IDCHAUFFEUR = clsPhamouvementstocklivraison.CH_IDCHAUFFEUR;
            this.TR_IDTRANSPORTEUR = clsPhamouvementstocklivraison.TR_IDTRANSPORTEUR;
            this.EN_CODEENTREPOT = clsPhamouvementstocklivraison.EN_CODEENTREPOT;
			this.AR_CODEARTICLE = clsPhamouvementstocklivraison.AR_CODEARTICLE;
			this.MS_NUMPIECE = clsPhamouvementstocklivraison.MS_NUMPIECE;
			this.NO_CODENATUREOPERATION = clsPhamouvementstocklivraison.NO_CODENATUREOPERATION;
			this.LV_QUANTITELIVRER = clsPhamouvementstocklivraison.LV_QUANTITELIVRER;
			this.LV_DATELIVRAISON = clsPhamouvementstocklivraison.LV_DATELIVRAISON;
			this.LV_ANNULATIONPIECE = clsPhamouvementstocklivraison.LV_ANNULATIONPIECE;
			this.LV_NUMEROPIECE = clsPhamouvementstocklivraison.LV_NUMEROPIECE;
			this.LV_MONTANTVERSE = clsPhamouvementstocklivraison.LV_MONTANTVERSE;
			this.LV_REMETTANT = clsPhamouvementstocklivraison.LV_REMETTANT;
			this.LV_AGENTLIVREUR = clsPhamouvementstocklivraison.LV_AGENTLIVREUR;
            this.LV_NUMERIMMATRICULATION = clsPhamouvementstocklivraison.LV_NUMERIMMATRICULATION;
            this.VH_CODEVEHICULE = clsPhamouvementstocklivraison.VH_CODEVEHICULE;
            this.TYPEOPERATION = clsPhamouvementstocklivraison.TYPEOPERATION;


		}

		#endregion

	}
}
