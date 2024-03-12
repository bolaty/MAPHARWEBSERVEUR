using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsPhainventairedetail
	{
		#region VARIABLES LOCALES

		private string _INV_CODEINVENTAIRE = "";
		private string _AG_CODEAGENCE = "";
		private string _AR_CODEARTICLE = "";
        private string _MD_NUMSEQUENCE = "";
		private double _INV_QTEPHYSIQUE = 0;
		private double _INV_QTELOGIQUE = 0;

		#endregion

		#region ACCESSEURS

		public string INV_CODEINVENTAIRE
		{
			get { return _INV_CODEINVENTAIRE; }
			set {  _INV_CODEINVENTAIRE = value; }
		}

		public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set {  _AG_CODEAGENCE = value; }
		}

		public string AR_CODEARTICLE
		{
			get { return _AR_CODEARTICLE; }
			set {  _AR_CODEARTICLE = value; }
		}

        public string MD_NUMSEQUENCE
		{
            get { return _MD_NUMSEQUENCE; }
            set { _MD_NUMSEQUENCE = value; }
		}

		public double INV_QTEPHYSIQUE
		{
			get { return _INV_QTEPHYSIQUE; }
			set {  _INV_QTEPHYSIQUE = value; }
		}

		public double INV_QTELOGIQUE
		{
			get { return _INV_QTELOGIQUE; }
			set {  _INV_QTELOGIQUE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsPhainventairedetail(){}
        public clsPhainventairedetail(string INV_CODEINVENTAIRE, string AG_CODEAGENCE, string AR_CODEARTICLE, string MD_NUMSEQUENCE, double INV_QTEPHYSIQUE, double INV_QTELOGIQUE)
		{
			this.INV_CODEINVENTAIRE = INV_CODEINVENTAIRE;
			this.AG_CODEAGENCE = AG_CODEAGENCE;
			this.AR_CODEARTICLE = AR_CODEARTICLE;
            this.MD_NUMSEQUENCE = MD_NUMSEQUENCE;
			this.INV_QTEPHYSIQUE = INV_QTEPHYSIQUE;
			this.INV_QTELOGIQUE = INV_QTELOGIQUE;
		}
		public clsPhainventairedetail(clsPhainventairedetail clsPhainventairedetail)
		{
			this.INV_CODEINVENTAIRE = clsPhainventairedetail.INV_CODEINVENTAIRE;
			this.AG_CODEAGENCE = clsPhainventairedetail.AG_CODEAGENCE;
			this.AR_CODEARTICLE = clsPhainventairedetail.AR_CODEARTICLE;
            this.MD_NUMSEQUENCE = clsPhainventairedetail.MD_NUMSEQUENCE;
			this.INV_QTEPHYSIQUE = clsPhainventairedetail.INV_QTEPHYSIQUE;
			this.INV_QTELOGIQUE = clsPhainventairedetail.INV_QTELOGIQUE;
		}

		#endregion

	}
}
