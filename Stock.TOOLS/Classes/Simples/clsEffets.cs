#region CD Interactif - Copyright (c) Mechtaly Hamza 2008
//
// Ce fichier est une part du projet CD Interactif.
// pour plus d'info contactez nous a l'adresse mail: infos@mechtaly.com
//
#endregion

using System;
using System.Windows.Forms;

namespace Stock.TOOLS
{
    /// <summary>
    /// FormFader, sert à faire apparaitre une fenêtre progressivement via la transparence (sympa pour les splash screens)
    /// </summary>
    public class clsEffets
    {
        /// <summary>
        /// Evenement(s) à déclancher après que le fading se soit terminé
        /// </summary>
        public event EventHandler atEnd;
        private int vlpDuration = 1000;
        private double vlpStartingOpacity = 0.0;
        private double vlpEndingOpacity = 1;
        private int vlpTimeToWait = 0;
        private static int interval = 50;
        private double vlpAddValue;
        private Form form;
        private Timer loopTimer;
        private Timer endTimer;

        /// <summary>
        /// Nouveau fading avec les paramètres par défaut
        /// </summary>
        public clsEffets() { }

        /// <summary>
        /// Nouveau fading avec un form donné
        /// </summary>
        /// <param name="aForm">Formulaire à fader</param>
        public clsEffets(Form aForm)
        {
            form = aForm;
        }

        /// <summary>
        /// Nouveau fading avec un form et une durée donnés
        /// </summary>
        /// <param name="aForm">Formulaire à fader</param>
        /// <param name="aDuration">Durée -approximative- du fading en millisecondes</param>
        public clsEffets(Form aForm, int aDuration)
        {
            form = aForm;
            vlpDuration = aDuration;
        }

        /// <summary>
        /// Débute le fading
        /// </summary>
        public void pvgStart()
        {
            form.Opacity = vlpStartingOpacity;
            form.Show();
            form.Activate();
            loopTimer = new Timer();
            loopTimer.Interval = interval;
            loopTimer.Tick += new System.EventHandler(this.pvpLoop);
            loopTimer.Enabled = true;
            vlpAddValue = (vlpEndingOpacity - vlpStartingOpacity) / vlpDuration * interval;
        }
        /// <summary>
        /// Usage interne, appellé à chaque boucle pour changer l'opacité
        /// </summary>
        private void pvpLoop(object sender, System.EventArgs e)
        {
            form.Opacity += vlpAddValue;
            if (form.Opacity >= vlpEndingOpacity)
            {
                loopTimer.Dispose();
                if (atEnd != null && atEnd != null)
                {
                    endTimer = new Timer();
                    endTimer.Interval = vlpTimeToWait;
                    endTimer.Tick += new System.EventHandler(this.pvpStopEndTimer);
                    endTimer.Tick += atEnd;
                    endTimer.Start();
                }
            }
        }
        /// <summary>
        /// Usage interne. Pour ne stopper le timer déclanché à la fin
        /// </summary>
        private void pvpStopEndTimer(object sender, System.EventArgs e)
        {
            endTimer.Dispose();
        }
        // Les proprietées
        /// <summary>
        /// Formulaire qui sera mit en transparance
        /// </summary>
        public Form Form
        {
            get { return form;  }
            set {form = value;}
        }
        /// <summary>
        /// Durée approximative du fading (en millisecondes)
        /// La durée effective sera un peu plus longue
        /// Par défaut : 1000
        /// </summary>
        public int pvgDuration
        {
            get{return vlpDuration;}
            set{vlpDuration = Math.Abs(value);}
        }

        /// <summary>
        /// Opacité au départ du fading
        /// Par défaut : 0.0
        /// </summary>
        public double pvgStartingOpacity
        {
            get{return vlpStartingOpacity;}
            set{vlpStartingOpacity = Math.Abs(value);}
        }

        /// <summary>
        /// Opacité à la fin du fading
        /// Par défaut : 1
        /// </summary>
        public double pvgEndingOpacity
        {
            get{return vlpEndingOpacity;}
            set{vlpEndingOpacity = Math.Abs(value);}
        }

        /// <summary>
        /// Temps à attendre (en millisecondes) avant d'executer l'eventHandler 'atEnd'
        /// Par défaut : 0 - pas d'execution
        /// </summary>
        public int pvgTimeToWait
        {
            get{return vlpTimeToWait; }
            set{vlpTimeToWait = Math.Abs(value);}
        }
    }
}
