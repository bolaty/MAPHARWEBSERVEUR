using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HT_Stock.BOJ
{
	public class clsFacturationTiers
	{

        private double _MONTANTHTUNITAIRE = 0;
        private double _MONTANTHTNETUNITAIRE = 0;
		private double _MONTANTHTTOTAL = 0;
        private double _MONTANTHTNETTOTAL = 0;
        private double _MONTANTTCUNITAIRE = 0;
        private double _MONTANTTCTOTAL = 0;
        private double _MONTANTTCTOTALAVECREMISE = 0;
        private double _MONTANTTCTOTALPLUSAIRSI = 0;

        private double _MONTANTASDIUNITAIRE = 0;
        private double _MONTANTASDITOTAL = 0;

        private double _MONTANTTVAUNITAIRE = 0;
        private double _MONTANTTVATOTAL = 0;
        private double _MONTANTREMISEUNITAIRE = 0;
        private double _MONTANTESCOMPTEUNITAIRE = 0;
        private double _MONTANTREMISETOTAL = 0;
        private double _MONTANTESCOMPTETOTAL = 0;
        private double _TAUXTVA = 0;
        private double _TAUXASDI = 0;
        private double _TR_MONTANTREMISEPALETTE = 0;
        private double _TR_MONTANTREMISECONTRACTUELLE = 0;
        private double _TR_MONTANTREMISEPALETTETOTAL = 0;
        private double _TR_MONTANTREMISECONTRACTUELLETOTAL = 0;
        private double _AR_MONTANTEMBALLAGE = 0;
        private double _TQ_QUANTITEPALETTECMD = 0;
        private double _MD_QUANTITEENTREE = 0;
        private double _MONTANTNET = 0;
        private double _MD_ARTICLETOTALHTPLUSAR_PRIXEMBALLAGETOTALE = 0;
        private double _MONTANTASSUREUR = 0;
        private double _TAUXASSUREUR = 0;



        private double _MONTANTREMISE = 0;
        private double _MONTANTESCOMPTE = 0;
        private double _TOTALREMISE = 0;
        private double _TOTALESCOMPTE = 0;
        private double _MD_PRIXUNITAIREVENTEHTAVANTREMISEETSCOMPTE = 0;


        public double MONTANTHTUNITAIRE
		{
            get { return _MONTANTHTUNITAIRE; }
            set { _MONTANTHTUNITAIRE = value; }
		}
        public double MONTANTHTNETUNITAIRE
		{
            get { return _MONTANTHTNETUNITAIRE; }
            set { _MONTANTHTNETUNITAIRE = value; }
		}

        public double MONTANTHTTOTAL
		{
            get { return _MONTANTHTTOTAL; }
            set { _MONTANTHTTOTAL = value; }
		}

        public double MONTANTHTNETTOTAL
        {
            get { return _MONTANTHTNETTOTAL; }
            set { _MONTANTHTNETTOTAL = value; }
        }

        public double MONTANTTCUNITAIRE
		{
            get { return _MONTANTTCUNITAIRE; }
            set { _MONTANTTCUNITAIRE = value; }
		}
        public double MONTANTTCTOTAL
		{
            get { return _MONTANTTCTOTAL; }
            set { _MONTANTTCTOTAL = value; }
		}
        public double MONTANTTCTOTALAVECREMISE
		{
            get { return _MONTANTTCTOTALAVECREMISE; }
            set { _MONTANTTCTOTALAVECREMISE = value; }
		}

        public double MONTANTTCTOTALPLUSAIRSI
		{
            get { return _MONTANTTCTOTALPLUSAIRSI; }
            set { _MONTANTTCTOTALPLUSAIRSI = value; }
		}

        public double MONTANTASDIUNITAIRE
		{
            get { return _MONTANTASDIUNITAIRE; }
            set { _MONTANTASDIUNITAIRE = value; }
		}
        public double MONTANTASDITOTAL
		{
            get { return _MONTANTASDITOTAL; }
            set { _MONTANTASDITOTAL = value; }
		}
        public double MONTANTTVAUNITAIRE
		{
            get { return _MONTANTTVAUNITAIRE; }
            set { _MONTANTTVAUNITAIRE = value; }
		}
        public double MONTANTTVATOTAL
		{
            get { return _MONTANTTVATOTAL; }
            set { _MONTANTTVATOTAL = value; }
		}
        public double MONTANTREMISEUNITAIRE
		{
            get { return _MONTANTREMISEUNITAIRE; }
            set { _MONTANTREMISEUNITAIRE = value; }
		}
        public double MONTANTESCOMPTEUNITAIRE
        {
            get { return _MONTANTESCOMPTEUNITAIRE; }
            set { _MONTANTESCOMPTEUNITAIRE = value; }
        }

        public double MONTANTREMISETOTAL
		{
            get { return _MONTANTREMISETOTAL; }
            set { _MONTANTREMISETOTAL = value; }
		}

        public double MONTANTESCOMPTETOTAL
        {
            get { return _MONTANTESCOMPTETOTAL; }
            set { _MONTANTESCOMPTETOTAL = value; }
        }
        public double TAUXTVA
        {
            get { return _TAUXTVA; }
            set { _TAUXTVA = value; }
        }

        public double TAUXASDI
        {
            get { return _TAUXASDI; }
            set { _TAUXASDI = value; }
        }

        public double TR_MONTANTREMISEPALETTE
        {
            get { return _TR_MONTANTREMISEPALETTE; }
            set { _TR_MONTANTREMISEPALETTE = value; }
        }

        public double TR_MONTANTREMISECONTRACTUELLE
        {
            get { return _TR_MONTANTREMISECONTRACTUELLE; }
            set { _TR_MONTANTREMISECONTRACTUELLE = value; }
        }

        public double TR_MONTANTREMISEPALETTETOTAL
        {
            get { return _TR_MONTANTREMISEPALETTETOTAL; }
            set { _TR_MONTANTREMISEPALETTETOTAL = value; }
        }
        public double TR_MONTANTREMISECONTRACTUELLETOTAL
        {
            get { return _TR_MONTANTREMISECONTRACTUELLETOTAL; }
            set { _TR_MONTANTREMISECONTRACTUELLETOTAL = value; }
        }

        public double AR_MONTANTEMBALLAGE
        {
            get { return _AR_MONTANTEMBALLAGE; }
            set { _AR_MONTANTEMBALLAGE = value; }
        }
        public double TQ_QUANTITEPALETTECMD
        {
            get { return _TQ_QUANTITEPALETTECMD; }
            set { _TQ_QUANTITEPALETTECMD = value; }
        }

        public double MD_QUANTITEENTREE
        {
            get { return _MD_QUANTITEENTREE; }
            set { _MD_QUANTITEENTREE = value; }
        }
        public double MONTANTNET
        {
            get { return _MONTANTNET; }
            set { _MONTANTNET = value; }
        }

        public double MD_ARTICLETOTALHTPLUSAR_PRIXEMBALLAGETOTALE
        {
            get { return _MD_ARTICLETOTALHTPLUSAR_PRIXEMBALLAGETOTALE; }
            set { _MD_ARTICLETOTALHTPLUSAR_PRIXEMBALLAGETOTALE = value; }
        }
        public double MONTANTASSUREUR
        {
            get { return _MONTANTASSUREUR; }
            set { _MONTANTASSUREUR = value; }
        }

        public double TAUXASSUREUR
        {
            get { return _TAUXASSUREUR; }
            set { _TAUXASSUREUR = value; }
        }

        public double MONTANTREMISE
        {
            get { return _MONTANTREMISE; }
            set { _MONTANTREMISE = value; }
        }

        public double MONTANTESCOMPTE
        {
            get { return _MONTANTESCOMPTE; }
            set { _MONTANTESCOMPTE = value; }
        }

        public double TOTALREMISE
        {
            get { return _TOTALREMISE; }
            set { _TOTALREMISE = value; }
        }
        public double TOTALESCOMPTE
        {
            get { return _TOTALESCOMPTE; }
            set { _TOTALESCOMPTE = value; }
        }
        public double MD_PRIXUNITAIREVENTEHTAVANTREMISEETSCOMPTE
        {
            get { return _MD_PRIXUNITAIREVENTEHTAVANTREMISEETSCOMPTE; }
            set { _MD_PRIXUNITAIREVENTEHTAVANTREMISEETSCOMPTE = value; }
        }
       

        public clsFacturationTiers() {}

       

		public clsFacturationTiers(clsFacturationTiers clsFacturationTiers)
		{
             
            MONTANTHTUNITAIRE = clsFacturationTiers.MONTANTHTUNITAIRE;
            MONTANTHTNETUNITAIRE = clsFacturationTiers.MONTANTHTNETUNITAIRE;
            MONTANTHTTOTAL = clsFacturationTiers.MONTANTHTTOTAL;
            MONTANTHTNETTOTAL = clsFacturationTiers.MONTANTHTNETTOTAL;
            MONTANTTCUNITAIRE = clsFacturationTiers.MONTANTTCUNITAIRE;
            MONTANTTCTOTAL = clsFacturationTiers.MONTANTTCTOTAL;
            MONTANTTCTOTALAVECREMISE = clsFacturationTiers.MONTANTTCTOTALAVECREMISE;
            MONTANTTCTOTALPLUSAIRSI = clsFacturationTiers.MONTANTTCTOTALPLUSAIRSI;

            MONTANTASDIUNITAIRE = clsFacturationTiers.MONTANTASDIUNITAIRE;
            MONTANTASDITOTAL = clsFacturationTiers.MONTANTASDITOTAL;
            MONTANTTVAUNITAIRE = clsFacturationTiers.MONTANTTVAUNITAIRE;
            MONTANTTVATOTAL = clsFacturationTiers.MONTANTTVATOTAL;
            MONTANTREMISEUNITAIRE = clsFacturationTiers.MONTANTREMISEUNITAIRE;
            MONTANTESCOMPTEUNITAIRE = clsFacturationTiers.MONTANTESCOMPTEUNITAIRE;
            MONTANTREMISETOTAL = clsFacturationTiers.MONTANTREMISETOTAL;
            MONTANTESCOMPTETOTAL = clsFacturationTiers.MONTANTESCOMPTETOTAL;
            TAUXTVA = clsFacturationTiers.TAUXTVA;
            TAUXASDI = clsFacturationTiers.TAUXASDI;
            TR_MONTANTREMISEPALETTE = clsFacturationTiers.TR_MONTANTREMISEPALETTE;
            TR_MONTANTREMISECONTRACTUELLE = clsFacturationTiers.TR_MONTANTREMISECONTRACTUELLE;
            TR_MONTANTREMISEPALETTETOTAL = clsFacturationTiers.TR_MONTANTREMISEPALETTETOTAL;
            TR_MONTANTREMISECONTRACTUELLETOTAL = clsFacturationTiers.TR_MONTANTREMISECONTRACTUELLETOTAL;
            AR_MONTANTEMBALLAGE = clsFacturationTiers.AR_MONTANTEMBALLAGE;
            TQ_QUANTITEPALETTECMD = clsFacturationTiers.TQ_QUANTITEPALETTECMD;
            MD_QUANTITEENTREE = clsFacturationTiers.MD_QUANTITEENTREE;
            MONTANTNET = clsFacturationTiers.MONTANTNET;
            MD_ARTICLETOTALHTPLUSAR_PRIXEMBALLAGETOTALE = clsFacturationTiers.MD_ARTICLETOTALHTPLUSAR_PRIXEMBALLAGETOTALE;
            MONTANTASSUREUR = clsFacturationTiers.MONTANTASSUREUR;
            TAUXASSUREUR = clsFacturationTiers.TAUXASSUREUR;

            MONTANTREMISE = clsFacturationTiers.MONTANTREMISE;
            MONTANTESCOMPTE = clsFacturationTiers.MONTANTESCOMPTE;
            TOTALREMISE = clsFacturationTiers.TOTALREMISE;
            MD_PRIXUNITAIREVENTEHTAVANTREMISEETSCOMPTE = clsFacturationTiers.MD_PRIXUNITAIREVENTEHTAVANTREMISEETSCOMPTE;

            //private double _MONTANTREMISE = 0;
            //private double _MONTANTESCOMPTE = 0;
            //private double _TOTALREMISE = 0;
            //private double _TOTALESCOMPTE = 0;
            //private double _MD_PRIXUNITAIREVENTEHTAVANTREMISEETSCOMPTE = 0;




        }
    }
}