using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsCliparcoeficientcoutsupplementaire
	{
		#region VARIABLES LOCALES

		private string _JF_CODETYPEJOURFACTURATION = "";
		private string _NT_CODENATURETIERS = "";
		private string _CF_CODECOEFICIENT = "";
		private Double _CF_TAUXSUPLEMENTAIRE = 0;

		#endregion

		#region ACCESSEURS

		public string JF_CODETYPEJOURFACTURATION
		{
			get { return _JF_CODETYPEJOURFACTURATION; }
			set {  _JF_CODETYPEJOURFACTURATION = value; }
		}

		public string NT_CODENATURETIERS
		{
			get { return _NT_CODENATURETIERS; }
			set {  _NT_CODENATURETIERS = value; }
		}
        public string CF_CODECOEFICIENT
        {
	        get { return _CF_CODECOEFICIENT; }
	        set { _CF_CODECOEFICIENT = value; }
        }
		public Double CF_TAUXSUPLEMENTAIRE
		{
			get { return _CF_TAUXSUPLEMENTAIRE; }
			set {  _CF_TAUXSUPLEMENTAIRE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsCliparcoeficientcoutsupplementaire(){}
		public clsCliparcoeficientcoutsupplementaire( string JF_CODETYPEJOURFACTURATION,string NT_CODENATURETIERS,string CF_CODECOEFICIENT, float CF_TAUXSUPLEMENTAIRE)
		{
			this.JF_CODETYPEJOURFACTURATION = JF_CODETYPEJOURFACTURATION;
			this.NT_CODENATURETIERS = NT_CODENATURETIERS;
			this.CF_CODECOEFICIENT = CF_CODECOEFICIENT;
			this.CF_TAUXSUPLEMENTAIRE = CF_TAUXSUPLEMENTAIRE;
		}
		public clsCliparcoeficientcoutsupplementaire(clsCliparcoeficientcoutsupplementaire clsCliparcoeficientcoutsupplementaire)
		{
			this.JF_CODETYPEJOURFACTURATION = clsCliparcoeficientcoutsupplementaire.JF_CODETYPEJOURFACTURATION;
			this.NT_CODENATURETIERS = clsCliparcoeficientcoutsupplementaire.NT_CODENATURETIERS;
			this.CF_CODECOEFICIENT = clsCliparcoeficientcoutsupplementaire.CF_CODECOEFICIENT;
			this.CF_TAUXSUPLEMENTAIRE = clsCliparcoeficientcoutsupplementaire.CF_TAUXSUPLEMENTAIRE;
		}

		#endregion

	}
}
