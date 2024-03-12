using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsBusinessplanparampostenature
	{
		#region VARIABLES LOCALES

		private string _PN_CODENATUREPOSTEBUSINESSPLAN = "";
		private string _PN_LIBELLE = "";
		private int _PN_NUMEROORDRE = 0;

		#endregion

		#region ACCESSEURS

		public string PN_CODENATUREPOSTEBUSINESSPLAN
		{
			get { return _PN_CODENATUREPOSTEBUSINESSPLAN; }
			set {  _PN_CODENATUREPOSTEBUSINESSPLAN = value; }
		}

		public string PN_LIBELLE
		{
			get { return _PN_LIBELLE; }
			set {  _PN_LIBELLE = value; }
		}

		public int PN_NUMEROORDRE
		{
			get { return _PN_NUMEROORDRE; }
			set {  _PN_NUMEROORDRE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsBusinessplanparampostenature(){}
		public clsBusinessplanparampostenature( string PN_CODENATUREPOSTEBUSINESSPLAN,string PN_LIBELLE,int PN_NUMEROORDRE)
		{
			this.PN_CODENATUREPOSTEBUSINESSPLAN = PN_CODENATUREPOSTEBUSINESSPLAN;
			this.PN_LIBELLE = PN_LIBELLE;
			this.PN_NUMEROORDRE = PN_NUMEROORDRE;
		}
		public clsBusinessplanparampostenature(clsBusinessplanparampostenature clsBusinessplanparampostenature)
		{
			this.PN_CODENATUREPOSTEBUSINESSPLAN = clsBusinessplanparampostenature.PN_CODENATUREPOSTEBUSINESSPLAN;
			this.PN_LIBELLE = clsBusinessplanparampostenature.PN_LIBELLE;
			this.PN_NUMEROORDRE = clsBusinessplanparampostenature.PN_NUMEROORDRE;
		}

		#endregion

	}
}
