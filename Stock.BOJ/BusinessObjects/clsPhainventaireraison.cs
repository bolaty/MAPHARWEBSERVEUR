using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsPhainventaireraison
	{
		#region VARIABLES LOCALES

		private string _INVR_CODERAISONINVENTAIRE = "";
		private string _INVR_LIBELLERAISONINVENTAIRE = "";

		#endregion

		#region ACCESSEURS

		public string INVR_CODERAISONINVENTAIRE
		{
			get { return _INVR_CODERAISONINVENTAIRE; }
			set {  _INVR_CODERAISONINVENTAIRE = value; }
		}

		public string INVR_LIBELLERAISONINVENTAIRE
		{
			get { return _INVR_LIBELLERAISONINVENTAIRE; }
			set {  _INVR_LIBELLERAISONINVENTAIRE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsPhainventaireraison(){}
		public clsPhainventaireraison( string INVR_CODERAISONINVENTAIRE,string INVR_LIBELLERAISONINVENTAIRE)
		{
			this.INVR_CODERAISONINVENTAIRE = INVR_CODERAISONINVENTAIRE;
			this.INVR_LIBELLERAISONINVENTAIRE = INVR_LIBELLERAISONINVENTAIRE;
		}
		public clsPhainventaireraison(clsPhainventaireraison clsPhainventaireraison)
		{
			this.INVR_CODERAISONINVENTAIRE = clsPhainventaireraison.INVR_CODERAISONINVENTAIRE;
			this.INVR_LIBELLERAISONINVENTAIRE = clsPhainventaireraison.INVR_LIBELLERAISONINVENTAIRE;
		}

		#endregion

	}
}
