using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
	public class clsOperateurdroitCompteTresorerie : clsEntitieBase
    {
		#region VARIABLES LOCALES

		private string _AG_CODEAGENCE = "";
		private string _OP_CODEOPERATEUR = "";
        private string _NO_CODENATUREOPERATION = "";
        private string _OB_CODEOBJET = "";
		private string _PL_CODENUMCOMPTE= "";
		private string _LO_ACTIF = "";
        private string _COCHER = "";
        private string _PL_LIBELLE = "";
        private string _PL_NUMCOMPTE = "";


		#endregion

		#region ACCESSEURS

		public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set {  _AG_CODEAGENCE = value; }
		}


		public string OP_CODEOPERATEUR
		{
			get { return _OP_CODEOPERATEUR; }
			set {  _OP_CODEOPERATEUR = value; }
		}

        public string NO_CODENATUREOPERATION
        {
	        get { return _NO_CODENATUREOPERATION; }
	        set { _NO_CODENATUREOPERATION = value; }
        }



        public string OB_CODEOBJET
        {
	        get { return _OB_CODEOBJET; }
	        set { _OB_CODEOBJET = value; }
        }

		public string PL_CODENUMCOMPTE
		{
			get { return _PL_CODENUMCOMPTE; }
			set {  _PL_CODENUMCOMPTE= value; }
		}

		public string LO_ACTIF
		{
			get { return _LO_ACTIF; }
			set {  _LO_ACTIF = value; }
		}
        public string COCHER
		{
            get { return _COCHER; }
            set { _COCHER = value; }
		}
        public string PL_LIBELLE
        {
            get { return _PL_LIBELLE; }
            set { _PL_LIBELLE = value; }
		}
        public string PL_NUMCOMPTE
        {
            get { return _PL_NUMCOMPTE; }
            set { _PL_NUMCOMPTE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsOperateurdroitCompteTresorerie(){}
       
		public clsOperateurdroitCompteTresorerie(clsOperateurdroitCompteTresorerie clsOperateurdroitCompteTresorerie)
		{
			this.AG_CODEAGENCE = clsOperateurdroitCompteTresorerie.AG_CODEAGENCE;
			this.OP_CODEOPERATEUR = clsOperateurdroitCompteTresorerie.OP_CODEOPERATEUR;
	        this.NO_CODENATUREOPERATION = clsOperateurdroitCompteTresorerie.NO_CODENATUREOPERATION;
	        this.OB_CODEOBJET = clsOperateurdroitCompteTresorerie.OB_CODEOBJET;
			this.PL_CODENUMCOMPTE= clsOperateurdroitCompteTresorerie.PL_CODENUMCOMPTE;
			this.LO_ACTIF = clsOperateurdroitCompteTresorerie.LO_ACTIF;
            this.COCHER = clsOperateurdroitCompteTresorerie.COCHER;
            this.PL_LIBELLE = clsOperateurdroitCompteTresorerie.PL_LIBELLE;
            this.PL_NUMCOMPTE = clsOperateurdroitCompteTresorerie.PL_NUMCOMPTE;

		}

		#endregion

	}
}
