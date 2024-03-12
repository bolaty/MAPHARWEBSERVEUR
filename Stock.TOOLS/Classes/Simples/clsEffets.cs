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
    /// FormFader, sert � faire apparaitre une fen�tre progressivement via la transparence (sympa pour les splash screens)
    /// </summary>
    public class clsEffets
    {
        /// <summary>
        /// Evenement(s) � d�clancher apr�s que le fading se soit termin�
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
        /// Nouveau fading avec les param�tres par d�faut
        /// </summary>
        public clsEffets() { }

        /// <summary>
        /// Nouveau fading avec un form donn�
        /// </summary>
        /// <param name="aForm">Formulaire � fader</param>
        public clsEffets(Form aForm)
        {
            form = aForm;
        }

        /// <summary>
        /// Nouveau fading avec un form et une dur�e donn�s
        /// </summary>
        /// <param name="aForm">Formulaire � fader</param>
        /// <param name="aDuration">Dur�e -approximative- du fading en millisecondes</param>
        public clsEffets(Form aForm, int aDuration)
        {
            form = aForm;
            vlpDuration = aDuration;
        }

        /// <summary>
        /// D�bute le fading
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
        /// Usage interne, appell� � chaque boucle pour changer l'opacit�
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
        /// Usage interne. Pour ne stopper le timer d�clanch� � la fin
        /// </summary>
        private void pvpStopEndTimer(object sender, System.EventArgs e)
        {
            endTimer.Dispose();
        }
        // Les propriet�es
        /// <summary>
        /// Formulaire qui sera mit en transparance
        /// </summary>
        public Form Form
        {
            get { return form;  }
            set {form = value;}
        }
        /// <summary>
        /// Dur�e approximative du fading (en millisecondes)
        /// La dur�e effective sera un peu plus longue
        /// Par d�faut : 1000
        /// </summary>
        public int pvgDuration
        {
            get{return vlpDuration;}
            set{vlpDuration = Math.Abs(value);}
        }

        /// <summary>
        /// Opacit� au d�part du fading
        /// Par d�faut : 0.0
        /// </summary>
        public double pvgStartingOpacity
        {
            get{return vlpStartingOpacity;}
            set{vlpStartingOpacity = Math.Abs(value);}
        }

        /// <summary>
        /// Opacit� � la fin du fading
        /// Par d�faut : 1
        /// </summary>
        public double pvgEndingOpacity
        {
            get{return vlpEndingOpacity;}
            set{vlpEndingOpacity = Math.Abs(value);}
        }

        /// <summary>
        /// Temps � attendre (en millisecondes) avant d'executer l'eventHandler 'atEnd'
        /// Par d�faut : 0 - pas d'execution
        /// </summary>
        public int pvgTimeToWait
        {
            get{return vlpTimeToWait; }
            set{vlpTimeToWait = Math.Abs(value);}
        }
    }
}
