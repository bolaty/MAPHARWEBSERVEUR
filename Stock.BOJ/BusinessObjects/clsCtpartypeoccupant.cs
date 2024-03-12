using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsCtpartypeoccupant
	{
		#region VARIABLES LOCALES

		private string _OC_CODETYPEOCCUPANT = "";
		private string _OC_LIBLLETYPEOCCUPANT = "";
		private string _OC_ACTIF = "";
		private int _OC_NUMEROORDRE = 0;

		#endregion

		#region ACCESSEURS

		public string OC_CODETYPEOCCUPANT
		{
			get { return _OC_CODETYPEOCCUPANT; }
			set {  _OC_CODETYPEOCCUPANT = value; }
		}

		public string OC_LIBLLETYPEOCCUPANT
		{
			get { return _OC_LIBLLETYPEOCCUPANT; }
			set {  _OC_LIBLLETYPEOCCUPANT = value; }
		}

		public string OC_ACTIF
		{
			get { return _OC_ACTIF; }
			set {  _OC_ACTIF = value; }
		}

		public int OC_NUMEROORDRE
		{
			get { return _OC_NUMEROORDRE; }
			set {  _OC_NUMEROORDRE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCtpartypeoccupant(){}
		public clsCtpartypeoccupant( string OC_CODETYPEOCCUPANT,string OC_LIBLLETYPEOCCUPANT,string OC_ACTIF,int OC_NUMEROORDRE)
		{
			this.OC_CODETYPEOCCUPANT = OC_CODETYPEOCCUPANT;
			this.OC_LIBLLETYPEOCCUPANT = OC_LIBLLETYPEOCCUPANT;
			this.OC_ACTIF = OC_ACTIF;
			this.OC_NUMEROORDRE = OC_NUMEROORDRE;
		}
		public clsCtpartypeoccupant(clsCtpartypeoccupant clsCtpartypeoccupant)
		{
			this.OC_CODETYPEOCCUPANT = clsCtpartypeoccupant.OC_CODETYPEOCCUPANT;
			this.OC_LIBLLETYPEOCCUPANT = clsCtpartypeoccupant.OC_LIBLLETYPEOCCUPANT;
			this.OC_ACTIF = clsCtpartypeoccupant.OC_ACTIF;
			this.OC_NUMEROORDRE = clsCtpartypeoccupant.OC_NUMEROORDRE;
		}

		#endregion

	}
}
