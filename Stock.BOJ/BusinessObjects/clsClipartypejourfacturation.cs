using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsClipartypejourfacturation
	{
		#region VARIABLES LOCALES

		private string _JF_CODETYPEJOURFACTURATION = "";
		private string _JF_LIBELLETYPEJOURFACTURATION = "";
		private string _JF_ACTIF = "";
		private int _JF_NUMEROORDRE = 0;

		#endregion

		#region ACCESSEURS

		public string JF_CODETYPEJOURFACTURATION
		{
			get { return _JF_CODETYPEJOURFACTURATION; }
			set {  _JF_CODETYPEJOURFACTURATION = value; }
		}

		public string JF_LIBELLETYPEJOURFACTURATION
		{
			get { return _JF_LIBELLETYPEJOURFACTURATION; }
			set {  _JF_LIBELLETYPEJOURFACTURATION = value; }
		}

		public string JF_ACTIF
		{
			get { return _JF_ACTIF; }
			set {  _JF_ACTIF = value; }
		}

		public int JF_NUMEROORDRE
		{
			get { return _JF_NUMEROORDRE; }
			set {  _JF_NUMEROORDRE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsClipartypejourfacturation(){}
		public clsClipartypejourfacturation( string JF_CODETYPEJOURFACTURATION,string JF_LIBELLETYPEJOURFACTURATION,string JF_ACTIF,int JF_NUMEROORDRE)
		{
			this.JF_CODETYPEJOURFACTURATION = JF_CODETYPEJOURFACTURATION;
			this.JF_LIBELLETYPEJOURFACTURATION = JF_LIBELLETYPEJOURFACTURATION;
			this.JF_ACTIF = JF_ACTIF;
			this.JF_NUMEROORDRE = JF_NUMEROORDRE;
		}
		public clsClipartypejourfacturation(clsClipartypejourfacturation clsClipartypejourfacturation)
		{
			this.JF_CODETYPEJOURFACTURATION = clsClipartypejourfacturation.JF_CODETYPEJOURFACTURATION;
			this.JF_LIBELLETYPEJOURFACTURATION = clsClipartypejourfacturation.JF_LIBELLETYPEJOURFACTURATION;
			this.JF_ACTIF = clsClipartypejourfacturation.JF_ACTIF;
			this.JF_NUMEROORDRE = clsClipartypejourfacturation.JF_NUMEROORDRE;
		}

		#endregion

	}
}
