using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace Stock.BOJ
{
	public class clsType_plan
	{
		#region VARIABLES LOCALES

		private string _TYPE_PLAN_CODE = "";
		private string _TYPE_PLAN_LIBELLE = "";

		#endregion

		#region ACCESSEURS

		public string TYPE_PLAN_CODE
		{
			get { return _TYPE_PLAN_CODE; }
			set {  _TYPE_PLAN_CODE = value; }
		}

		public string TYPE_PLAN_LIBELLE
		{
			get { return _TYPE_PLAN_LIBELLE; }
			set {  _TYPE_PLAN_LIBELLE = value; }
		}


		#endregion

		#region INSTANCIATEURS

		public clsType_plan(){}
		public clsType_plan( string TYPE_PLAN_CODE,string TYPE_PLAN_LIBELLE)
		{
			this.TYPE_PLAN_CODE = TYPE_PLAN_CODE;
			this.TYPE_PLAN_LIBELLE = TYPE_PLAN_LIBELLE;
		}
		public clsType_plan(clsType_plan clsType_plan)
		{
			this.TYPE_PLAN_CODE = clsType_plan.TYPE_PLAN_CODE;
			this.TYPE_PLAN_LIBELLE = clsType_plan.TYPE_PLAN_LIBELLE;
		}

		#endregion

	}
}
