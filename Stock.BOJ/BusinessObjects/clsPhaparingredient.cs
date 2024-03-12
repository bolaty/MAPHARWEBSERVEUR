using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsPhaparingredient
	{
		#region VARIABLES LOCALES

		private string _IN_CODEINGREDIENT = "";
		private string _IN_LIBELLE = "";

		#endregion

		#region ACCESSEURS

		public string IN_CODEINGREDIENT
		{
			get { return _IN_CODEINGREDIENT; }
			set {  _IN_CODEINGREDIENT = value; }
		}

		public string IN_LIBELLE
		{
			get { return _IN_LIBELLE; }
			set {  _IN_LIBELLE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsPhaparingredient(){}
		public clsPhaparingredient( string IN_CODEINGREDIENT,string IN_LIBELLE)
		{
			this.IN_CODEINGREDIENT = IN_CODEINGREDIENT;
			this.IN_LIBELLE = IN_LIBELLE;
		}
		public clsPhaparingredient(clsPhaparingredient clsPhaparingredient)
		{
			this.IN_CODEINGREDIENT = clsPhaparingredient.IN_CODEINGREDIENT;
			this.IN_LIBELLE = clsPhaparingredient.IN_LIBELLE;
		}

		#endregion

	}
}
