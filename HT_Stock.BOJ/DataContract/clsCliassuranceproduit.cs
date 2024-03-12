using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsCliassuranceproduit
	{
		#region VARIABLES LOCALES

		private string _AG_CODEAGENCE = "";
		private string _TI_IDTIERS = "";
		private string _AP_CODEPRODUIT = "";
		private string _AP_LIBELLEPRODUIT = "";
		private double _AP_PLAFONDPRODUIT = 0;

		#endregion

		#region ACCESSEURS

		public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set {  _AG_CODEAGENCE = value; }
		}

		public string TI_IDTIERS
		{
			get { return _TI_IDTIERS; }
			set {  _TI_IDTIERS = value; }
		}

		public string AP_CODEPRODUIT
		{
			get { return _AP_CODEPRODUIT; }
			set {  _AP_CODEPRODUIT = value; }
		}

		public string AP_LIBELLEPRODUIT
		{
			get { return _AP_LIBELLEPRODUIT; }
			set {  _AP_LIBELLEPRODUIT = value; }
		}

		public double AP_PLAFONDPRODUIT
		{
			get { return _AP_PLAFONDPRODUIT; }
			set {  _AP_PLAFONDPRODUIT = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCliassuranceproduit(){}
		public clsCliassuranceproduit( string AG_CODEAGENCE,string TI_IDTIERS,string AP_CODEPRODUIT,string AP_LIBELLEPRODUIT,double AP_PLAFONDPRODUIT)
		{
			this.AG_CODEAGENCE = AG_CODEAGENCE;
			this.TI_IDTIERS = TI_IDTIERS;
			this.AP_CODEPRODUIT = AP_CODEPRODUIT;
			this.AP_LIBELLEPRODUIT = AP_LIBELLEPRODUIT;
			this.AP_PLAFONDPRODUIT = AP_PLAFONDPRODUIT;
		}
		public clsCliassuranceproduit(clsCliassuranceproduit clsCliassuranceproduit)
		{
			this.AG_CODEAGENCE = clsCliassuranceproduit.AG_CODEAGENCE;
			this.TI_IDTIERS = clsCliassuranceproduit.TI_IDTIERS;
			this.AP_CODEPRODUIT = clsCliassuranceproduit.AP_CODEPRODUIT;
			this.AP_LIBELLEPRODUIT = clsCliassuranceproduit.AP_LIBELLEPRODUIT;
			this.AP_PLAFONDPRODUIT = clsCliassuranceproduit.AP_PLAFONDPRODUIT;
		}

		#endregion

	}
}
