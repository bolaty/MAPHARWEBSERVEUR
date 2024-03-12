using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsMicbudgetparampostebudgetairenature
	{
		#region VARIABLES LOCALES

		private string _BN_CODENATUREPOSTEBUDGETAIRE = "";
		private string _BN_LIBELLE = "";
		private int _BN_NUMEROORDRE = 0;

		#endregion

		#region ACCESSEURS

		public string BN_CODENATUREPOSTEBUDGETAIRE
		{
			get { return _BN_CODENATUREPOSTEBUDGETAIRE; }
			set {  _BN_CODENATUREPOSTEBUDGETAIRE = value; }
		}

		public string BN_LIBELLE
		{
			get { return _BN_LIBELLE; }
			set {  _BN_LIBELLE = value; }
		}

		public int BN_NUMEROORDRE
		{
			get { return _BN_NUMEROORDRE; }
			set {  _BN_NUMEROORDRE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsMicbudgetparampostebudgetairenature(){}
		public clsMicbudgetparampostebudgetairenature( string BN_CODENATUREPOSTEBUDGETAIRE,string BN_LIBELLE,int BN_NUMEROORDRE)
		{
			this.BN_CODENATUREPOSTEBUDGETAIRE = BN_CODENATUREPOSTEBUDGETAIRE;
			this.BN_LIBELLE = BN_LIBELLE;
			this.BN_NUMEROORDRE = BN_NUMEROORDRE;
		}
		public clsMicbudgetparampostebudgetairenature(clsMicbudgetparampostebudgetairenature clsMicbudgetparampostebudgetairenature)
		{
			this.BN_CODENATUREPOSTEBUDGETAIRE = clsMicbudgetparampostebudgetairenature.BN_CODENATUREPOSTEBUDGETAIRE;
			this.BN_LIBELLE = clsMicbudgetparampostebudgetairenature.BN_LIBELLE;
			this.BN_NUMEROORDRE = clsMicbudgetparampostebudgetairenature.BN_NUMEROORDRE;
		}

		#endregion

	}
}
