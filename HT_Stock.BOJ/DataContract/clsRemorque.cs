using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsRemorque
	{
		#region VARIABLES LOCALES

		private string _AG_CODEAGENCE = "";
		private string _EN_CODEENTREPOT = "";
		private string _RM_CODEREMORQUE = "";
		private string _RM_IMMATRICULATION = "";

		#endregion

		#region ACCESSEURS

		public string AG_CODEAGENCE
		{
			get { return _AG_CODEAGENCE; }
			set {  _AG_CODEAGENCE = value; }
		}

		public string EN_CODEENTREPOT
		{
			get { return _EN_CODEENTREPOT; }
			set {  _EN_CODEENTREPOT = value; }
		}

		public string RM_CODEREMORQUE
		{
			get { return _RM_CODEREMORQUE; }
			set {  _RM_CODEREMORQUE = value; }
		}

		public string RM_IMMATRICULATION
		{
			get { return _RM_IMMATRICULATION; }
			set {  _RM_IMMATRICULATION = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsRemorque(){}
		public clsRemorque( string AG_CODEAGENCE,string EN_CODEENTREPOT,string RM_CODEREMORQUE,string RM_IMMATRICULATION)
		{
			this.AG_CODEAGENCE = AG_CODEAGENCE;
			this.EN_CODEENTREPOT = EN_CODEENTREPOT;
			this.RM_CODEREMORQUE = RM_CODEREMORQUE;
			this.RM_IMMATRICULATION = RM_IMMATRICULATION;
		}
		public clsRemorque(clsRemorque clsRemorque)
		{
			this.AG_CODEAGENCE = clsRemorque.AG_CODEAGENCE;
			this.EN_CODEENTREPOT = clsRemorque.EN_CODEENTREPOT;
			this.RM_CODEREMORQUE = clsRemorque.RM_CODEREMORQUE;
			this.RM_IMMATRICULATION = clsRemorque.RM_IMMATRICULATION;
		}

		#endregion

	}
}
