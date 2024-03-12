using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Stock.Common;

namespace HT_Stock.BOJ
{
    public class clsMobileSouscription : clsEntitieBase
    {
        #region VARIABLES LOCALES

        private string _TI_IDTIERS = "";
        private string _PY_CODEPAYS = "";
        private string _TI_TELEPHONE = "";
        private string _TI_EMAIL = "";
        private string _AG_CODEAGENCE = "";
        private string _EN_CODEENTREPOT = "";
        private String _LO_CODELOGICIEL = "";
        private string _DATEJOURNEE = "";
        private string _SO_CODESOUSCRIPTION = "";
        private string _SO_LIEURESIDENCE = "";
        private string _TI_DENOMINATION = "";
        private string _TI_NUMTIERS = "";
       // Objet[0].SO_CODESOUSCRIPTION, Objet[0].PY_CODEPAYS, Objet[0].SO_TELEPHONE, Objet[0].DATEJOURNEE, Objet[0].SO_EMAIL, Objet[0].SO_LIEURESIDENCE,


        #endregion

        #region ACCESSEURS
        public string TI_IDTIERS
        {
            get { return _TI_IDTIERS; }
            set { _TI_IDTIERS = value; }
        }
        public string PY_CODEPAYS
        {
            get { return _PY_CODEPAYS; }
            set { _PY_CODEPAYS = value; }
        }
        public string TI_TELEPHONE
        {
            get { return _TI_TELEPHONE; }
            set { _TI_TELEPHONE = value; }
        }
        public string TI_EMAIL
        {
            get { return _TI_EMAIL; }
            set { _TI_EMAIL = value; }
        }


        public string AG_CODEAGENCE
        {
            get { return _AG_CODEAGENCE; }
            set { _AG_CODEAGENCE = value; }
        }

        public string EN_CODEENTREPOT
        {
            get { return _EN_CODEENTREPOT; }
            set { _EN_CODEENTREPOT = value; }
        }
        public string SO_LIEURESIDENCE
        {
            get { return _SO_LIEURESIDENCE; }
            set { _SO_LIEURESIDENCE = value; }
        }






        public String LO_CODELOGICIEL
        {
            get { return _LO_CODELOGICIEL; }
            set { _LO_CODELOGICIEL = value; }
        }
        public String DATEJOURNEE
        {
            get { return _DATEJOURNEE; }
            set { _DATEJOURNEE = value; }
        }
        public String SO_CODESOUSCRIPTION
        {
            get { return _SO_CODESOUSCRIPTION; }
            set { _SO_CODESOUSCRIPTION = value; }
        }
        public String TI_NUMTIERS
        {
            get { return _TI_NUMTIERS; }
            set { _TI_NUMTIERS = value; }
        }
        public String TI_DENOMINATION
        {
            get { return _TI_DENOMINATION; }
            set { _TI_DENOMINATION = value; }
        }

        #endregion

        #region INSTANCIATEURS

        public clsMobileSouscription() { }

        public clsMobileSouscription(clsMobileSouscription clsMobileSouscription)
        {
            this.TI_IDTIERS = clsMobileSouscription.TI_IDTIERS;
            this.PY_CODEPAYS = clsMobileSouscription.PY_CODEPAYS;
            this.TI_TELEPHONE = clsMobileSouscription.TI_TELEPHONE;
            this.TI_EMAIL = clsMobileSouscription.TI_EMAIL;
            this.AG_CODEAGENCE = clsMobileSouscription.AG_CODEAGENCE;
            this.EN_CODEENTREPOT = clsMobileSouscription.EN_CODEENTREPOT;
            this.LO_CODELOGICIEL = clsMobileSouscription.LO_CODELOGICIEL;
            this.DATEJOURNEE = clsMobileSouscription.DATEJOURNEE;
            this.SO_CODESOUSCRIPTION = clsMobileSouscription.SO_CODESOUSCRIPTION;
            this.SO_LIEURESIDENCE = clsMobileSouscription.SO_LIEURESIDENCE;
            this.TI_DENOMINATION = clsMobileSouscription.TI_DENOMINATION;
            this.TI_NUMTIERS = clsMobileSouscription.TI_NUMTIERS;

        }

        #endregion

    }
}
