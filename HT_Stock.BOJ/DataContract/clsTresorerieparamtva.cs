using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsTresorerieparamtva
	{
		#region VARIABLES LOCALES

		private int _TV_CODETVA = 0;
		private string _TV_LIBELLE = "";

		#endregion

		#region ACCESSEURS

		public int TV_CODETVA
		{
			get { return _TV_CODETVA; }
			set {  _TV_CODETVA = value; }
		}

		public string TV_LIBELLE
		{
			get { return _TV_LIBELLE; }
			set {  _TV_LIBELLE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsTresorerieparamtva(){}
		public clsTresorerieparamtva( int TV_CODETVA,string TV_LIBELLE)
		{
			this.TV_CODETVA = TV_CODETVA;
			this.TV_LIBELLE = TV_LIBELLE;
		}
		public clsTresorerieparamtva(clsTresorerieparamtva clsTresorerieparamtva)
		{
			this.TV_CODETVA = clsTresorerieparamtva.TV_CODETVA;
			this.TV_LIBELLE = clsTresorerieparamtva.TV_LIBELLE;
		}

		#endregion

	}
}
