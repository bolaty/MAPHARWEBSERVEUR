using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace Stock.TOOLS
{
    public class clsColor
    {
        #region  declaration unique de la classe
        //declaration unique de la classe clsColor pour tout le projet
        private readonly static clsColor ClassesColor = new clsColor();

        //constructeur privé de la classe clsDeclaration
        //empêchant l'utilisateur d'instancier lui même la classe
        private clsColor()
        {

        }
        //constructeur public de la classe fonction 
        public static clsColor ClasseColor
        {
            get { return ClassesColor; }
        }
        #endregion


        //procedure de chargement des couleurs
        public void pvgChargerCouleur()
        {
            //Constantes couleur

            clsDeclaration.JaunePale = Color.LightYellow;  //& H80000018;
            clsDeclaration.GrisClair = Color.FromArgb(224, 224, 224);
            clsDeclaration.VertClair = Color.FromArgb(204, 235, 204);
            clsDeclaration.VertFonce = Color.FromArgb(0, 153, 0);
            clsDeclaration.Gris = Color.FromArgb(212, 208, 200);

            clsDeclaration.Bleu = Color.FromArgb(64, 0, 128);
            clsDeclaration.BleuClair = Color.LightBlue;
            Stock.TOOLS.clsDeclaration.BleuCiel = Color.FromArgb(201, 221, 245); //Color.SkyBlue;// 16510691;
            //Stock.TOOLS.clsDeclaration.BleuCiel = Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(221)))), ((int)(((byte)(245)))));

            Stock.TOOLS.clsDeclaration.Blanc = Color.FromArgb(255, 255, 255);
            clsDeclaration.Noir = Color.FromArgb(0, 0, 0);
            clsDeclaration.Rouge = Color.FromArgb(128, 0, 0);
            clsDeclaration.Orange = Color.Orange;// 8438015;

            clsDeclaration.VertClair2 = Color.LightGreen;// 16056308;
            clsDeclaration.Anthracite = Color.AntiqueWhite;// 12632256;
            clsDeclaration.VertFluo = Color.LightGreen;// 12648384;
            clsDeclaration.Kaki = Color.FromArgb(236, 233, 216);
            clsDeclaration.vagCouleurFond = Stock.TOOLS.clsDeclaration.BleuCiel;// 'VertClair
            clsDeclaration.vagCouleurActivation = Stock.TOOLS.clsDeclaration.Blanc;
            clsDeclaration.vagCouleurDésactivation = Color.FromArgb(235, 235, 235); // 'Gris  'Kaki
            clsDeclaration.vagCouleurPolice = clsDeclaration.Noir;
            clsDeclaration.vagCouleurPoliceEtiquette = clsDeclaration.Bleu;
            clsDeclaration.vagCouleurPoliceListe = clsDeclaration.Bleu;
            clsDeclaration.vagCouleurPoliceFrame = clsDeclaration.Rouge;
        }
    }
}
