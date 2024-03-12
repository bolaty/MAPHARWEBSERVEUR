using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace HT_Stock.BOJ
{
	public class clsPhaecheancier
	{
		#region VARIABLES LOCALES

		private string _AG_CODEAGENCE = "";
		private string _TI_IDTIERS = "";
		private string _MS_NUMPIECE = "";
		private double _EC_MONTANTECHEANCE = 0;
		private DateTime _EC_DATEECHEANCE = DateTime.Parse("01/01/1900");


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

		public string MS_NUMPIECE
		{
			get { return _MS_NUMPIECE; }
			set {  _MS_NUMPIECE = value; }
		}

		public double EC_MONTANTECHEANCE
		{
			get { return _EC_MONTANTECHEANCE; }
			set {  _EC_MONTANTECHEANCE = value; }
		}

		public DateTime EC_DATEECHEANCE
		{
			get { return _EC_DATEECHEANCE; }
			set {  _EC_DATEECHEANCE = value; }
		}

		


		#endregion

		#region INSTANCIATEURS

		public clsPhaecheancier(){}
		public clsPhaecheancier( string AG_CODEAGENCE,string TI_IDTIERS,string MS_NUMPIECE,double EC_MONTANTECHEANCE,DateTime EC_DATEECHEANCE)
		{
			this.AG_CODEAGENCE = AG_CODEAGENCE;
			this.TI_IDTIERS = TI_IDTIERS;
			this.MS_NUMPIECE = MS_NUMPIECE;
			this.EC_MONTANTECHEANCE = EC_MONTANTECHEANCE;
			this.EC_DATEECHEANCE = EC_DATEECHEANCE;

		}
		public clsPhaecheancier(clsPhaecheancier clsPhaecheancier)
		{
			this.AG_CODEAGENCE = clsPhaecheancier.AG_CODEAGENCE;
			this.TI_IDTIERS = clsPhaecheancier.TI_IDTIERS;
			this.MS_NUMPIECE = clsPhaecheancier.MS_NUMPIECE;
			this.EC_MONTANTECHEANCE = clsPhaecheancier.EC_MONTANTECHEANCE;
			this.EC_DATEECHEANCE = clsPhaecheancier.EC_DATEECHEANCE;
		}

		#endregion

	}
}
