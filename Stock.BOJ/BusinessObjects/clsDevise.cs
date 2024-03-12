using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsDevise
	{
		#region VARIABLES LOCALES

		private string _DE_CODEDEVISE = "";
		private string _DE_DEVISECODE = "";
		private string _DE_LIBELLEDEVISE = "";
		private string _DE_DEVISEREFERENCE = "";
		private string _DE_ACTIF = "";

		#endregion

		#region ACCESSEURS

		public string DE_CODEDEVISE
		{
			get { return _DE_CODEDEVISE; }
			set {  _DE_CODEDEVISE = value; }
		}

		public string DE_DEVISECODE
		{
			get { return _DE_DEVISECODE; }
			set {  _DE_DEVISECODE = value; }
		}

		public string DE_LIBELLEDEVISE
		{
			get { return _DE_LIBELLEDEVISE; }
			set {  _DE_LIBELLEDEVISE = value; }
		}

		public string DE_DEVISEREFERENCE
		{
			get { return _DE_DEVISEREFERENCE; }
			set {  _DE_DEVISEREFERENCE = value; }
		}

		public string DE_ACTIF
		{
			get { return _DE_ACTIF; }
			set {  _DE_ACTIF = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsDevise(){}
		public clsDevise( string DE_CODEDEVISE,string DE_DEVISECODE,string DE_LIBELLEDEVISE,string DE_DEVISEREFERENCE,string DE_ACTIF)
		{
			this.DE_CODEDEVISE = DE_CODEDEVISE;
			this.DE_DEVISECODE = DE_DEVISECODE;
			this.DE_LIBELLEDEVISE = DE_LIBELLEDEVISE;
			this.DE_DEVISEREFERENCE = DE_DEVISEREFERENCE;
			this.DE_ACTIF = DE_ACTIF;
		}
		public clsDevise(clsDevise clsDevise)
		{
			this.DE_CODEDEVISE = clsDevise.DE_CODEDEVISE;
			this.DE_DEVISECODE = clsDevise.DE_DEVISECODE;
			this.DE_LIBELLEDEVISE = clsDevise.DE_LIBELLEDEVISE;
			this.DE_DEVISEREFERENCE = clsDevise.DE_DEVISEREFERENCE;
			this.DE_ACTIF = clsDevise.DE_ACTIF;
		}

		#endregion

	}
}
