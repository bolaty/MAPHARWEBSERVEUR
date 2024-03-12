using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock.BOJ
{
	public class clsPhaparprixtypefournisseur
	{

        private string _AR_CODEARTICLE = "";
		private string _TF_CODETYPEFOURNISSEUR = "";
		private double _PT_PRIXCESSION = 0;
		private DateTime _PT_DATETARIFICATION = DateTime.Parse("01/01/1900");



        public string AR_CODEARTICLE
		{
			get { return _AR_CODEARTICLE; }
			set { _AR_CODEARTICLE = value; }
		}
		public string TF_CODETYPEFOURNISSEUR
		{
			get { return _TF_CODETYPEFOURNISSEUR; }
			set { _TF_CODETYPEFOURNISSEUR = value; }
		}
		public double PT_PRIXCESSION
		{
			get { return _PT_PRIXCESSION; }
			set { _PT_PRIXCESSION = value; }
		}
		public DateTime PT_DATETARIFICATION
		{
			get { return _PT_DATETARIFICATION; }
			set { _PT_DATETARIFICATION = value; }
		}



        public clsPhaparprixtypefournisseur() {} 

		public clsPhaparprixtypefournisseur(string AR_CODEARTICLE,string TF_CODETYPEFOURNISSEUR,double PT_PRIXCESSION,DateTime PT_DATETARIFICATION)
		{
			this.AR_CODEARTICLE = AR_CODEARTICLE;
			this.TF_CODETYPEFOURNISSEUR = TF_CODETYPEFOURNISSEUR;
			this.PT_PRIXCESSION = PT_PRIXCESSION;
			this.PT_DATETARIFICATION = PT_DATETARIFICATION;
		}

		public clsPhaparprixtypefournisseur(clsPhaparprixtypefournisseur clsPhaparprixtypefournisseur)
		{
			AR_CODEARTICLE = clsPhaparprixtypefournisseur.AR_CODEARTICLE;
			TF_CODETYPEFOURNISSEUR = clsPhaparprixtypefournisseur.TF_CODETYPEFOURNISSEUR;
			PT_PRIXCESSION = clsPhaparprixtypefournisseur.PT_PRIXCESSION;
			PT_DATETARIFICATION = clsPhaparprixtypefournisseur.PT_DATETARIFICATION;
		}
        }
}