using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsCtparbranchecategorietarif
	{
		#region VARIABLES LOCALES

		private int _CB_IDBRANCHE = 0;
		private int _AU_CODECATEGORIE = 0;
		private int _TA_CODETARIF = 0;
		private int _BC_NUMEROORDRE = 0;

		#endregion

		#region ACCESSEURS

		public int CB_IDBRANCHE
		{
			get { return _CB_IDBRANCHE; }
			set {  _CB_IDBRANCHE = value; }
		}

		public int AU_CODECATEGORIE
		{
			get { return _AU_CODECATEGORIE; }
			set {  _AU_CODECATEGORIE = value; }
		}

		public int TA_CODETARIF
		{
			get { return _TA_CODETARIF; }
			set {  _TA_CODETARIF = value; }
		}

		public int BC_NUMEROORDRE
		{
			get { return _BC_NUMEROORDRE; }
			set {  _BC_NUMEROORDRE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCtparbranchecategorietarif(){}
		public clsCtparbranchecategorietarif( int CB_IDBRANCHE,int AU_CODECATEGORIE,int TA_CODETARIF,int BC_NUMEROORDRE)
		{
			this.CB_IDBRANCHE = CB_IDBRANCHE;
			this.AU_CODECATEGORIE = AU_CODECATEGORIE;
			this.TA_CODETARIF = TA_CODETARIF;
			this.BC_NUMEROORDRE = BC_NUMEROORDRE;
		}
		public clsCtparbranchecategorietarif(clsCtparbranchecategorietarif clsCtparbranchecategorietarif)
		{
			this.CB_IDBRANCHE = clsCtparbranchecategorietarif.CB_IDBRANCHE;
			this.AU_CODECATEGORIE = clsCtparbranchecategorietarif.AU_CODECATEGORIE;
			this.TA_CODETARIF = clsCtparbranchecategorietarif.TA_CODETARIF;
			this.BC_NUMEROORDRE = clsCtparbranchecategorietarif.BC_NUMEROORDRE;
		}

		#endregion

	}
}
