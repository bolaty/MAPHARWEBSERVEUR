using System.Text;
using System.IO;
using System;
using System.Windows.Forms;
using System.Reflection;
using System.ComponentModel;
using System.Globalization;

namespace Stock.TOOLS
{
    public class clsFileINI
    {
        #region " Initialisation de la class "
        /// <summary>
        /// D�claration de la class
        /// </summary>
        public clsFileINI(){ }
        /// <summary>
        /// D�claration de la class
        /// </summary>
        /// <param name="fichier">Chemin complet et nom du fichier INI ainsi que son extension � ouvrir</param>
        public clsFileINI(string fichier)
        {
            FICHIER = fichier;
        }
        /// <summary>
        /// D�claration de la class
        /// </summary>
        /// <param name="encodage">Type d'encodage � utiliser dans le fichier. La valeur par d�faut est "ASCIIEncoding.Default"</param>
        public clsFileINI(Encoding encodage)
        {
            ENCODAGE = encodage;
        }
        /// <summary>
        /// D�claration de la class
        /// </summary>
        /// <param name="fichier">Chemin complet et nom du fichier INI ainsi que son extension � ouvrir</param>
        /// <param name="encodage">Type d'encodage � utiliser dans le fichier. La valeur par d�faut est "ASCIIEncoding.Default"</param>
        public clsFileINI(string fichier, Encoding encodage) 
        {
            FICHIER = fichier;
            ENCODAGE = encodage;
        }
        #endregion

        #region " Propri�t�s private "

        private string FICHIER = null;
        private Encoding ENCODAGE = ASCIIEncoding.Default;
        private string GROUPE = null;
        
        #endregion

        #region " Propri�t�s public "
        /// <summary>
        /// Retourne le chemin complet ainsi que le nom du fichier INI et son extension
        /// </summary>
        public string Fichier
        {
            get { return FICHIER; }
            set { FICHIER = value; }
        }
        /// <summary>
        /// Retourne le type d'encodage � utiliser dans le fichier. La valeur par d�faut
        /// est "ASCIIEncoding.Default"
        /// </summary>
        public Encoding Encodage
        {
            get { return ENCODAGE; }
            set { ENCODAGE = value; }
        }
        /// <summary>
        /// Retourne le nom du groupe du fichier INI
        /// </summary>
        public string Groupe
        {
            get { return GROUPE; }
            set { GROUPE = value; }
        }
        #endregion

        #region " M�thodes - GetValue "
        /// <summary>
        /// Cette m�thode retourne la valeur d'une variable � partir d'un groupe
        /// </summary>
        /// <param name="MonGroupe">Nom du groupe � chercher</param>
        /// <param name="MaVariable">Nom de la variable � chercher</param>
        /// <returns>Retourne la valeur</returns>
        private string GetValue(string MonGroupe, string MaVariable)
        {
            // D�claration de la variable de retour
            string MaValeur = null;

            // On v�rifie que le fichier existe bien
            if (File.Exists(Fichier))
            {
                // D�claration de divers variables
                string s, g = "[" + MonGroupe + "]"; string[] text;
                // Cr�ation d'une instance FileStream
                FileStream fs = new FileStream(Fichier, FileMode.Open); // on ouvre le fichier texte
                // Cr�ation d'une instance StreamReader
                StreamReader sr = new StreamReader(fs, Encodage);

                try
                {
                    // On d�marre la boucle pour lire le fichier ligne par ligne
                    do
                    {
                        // Lecture de la ligne
                        s = sr.ReadLine();

                        // On v�rifie qu'au moins une ligne valide est pr�sente dans le 
                        // fichier et qu'elle contient la variable et le groupe demand�
                        if (s != null)
                        {
                            // On v�rifie si le premier caract�re est un [, si oui,
                            // on stocke dans la variable 'g' le nom du groupe
                            if ((s.Length > 0) && (s.Substring(0, 1) == "[")) g = s;

                            // Si le nom du groupe et la variable existe
                            if ((g == "[" + MonGroupe + "]") && (s.StartsWith(MaVariable) == true))
                            {
                                // On s�pare la variable de sa valeur dans un tableau
                                text = s.Split(new char[] { '=' });
                                // On attribut la valeur a la variable de retour
                                MaValeur = text[1].Trim();
                            }
                        }
                    } while (s != null);

                    // On ferme le fichier
                    sr.Close();
                    fs.Close();
                }
                catch
                {
                    // On ferme le fichier
                    sr.Close();
                    fs.Close();
                }
            }
            // On retourne la valeur
            return MaValeur;
        }

        /// <summary>
        /// Permet de r�cup�rer une valeur sous la forme Boolean d'une variable � partir d'un groupe
        /// </summary>
        /// <param name="groupe">Nom du groupe � rechercher</param>
        /// <param name="variable">Nom de la variable � chercher</param>
        /// <returns>Retourne la valeur</returns>
        public bool GetValueBoolean(string groupe, string variable)
        {
            return Convert.ToBoolean(GetValue(groupe, variable));
        }
        /// <summary>
        /// Permet de r�cup�rer une valeur sous la forme Byte d'une variable � partir d'un groupe
        /// </summary>
        /// <param name="groupe">Nom du groupe � rechercher</param>
        /// <param name="variable">Nom de la variable � chercher</param>
        /// <returns>Retourne la valeur</returns>
        public byte GetValueByte(string groupe, string variable)
        {
            return Convert.ToByte(GetValue(groupe, variable));
        }
        /// <summary>
        /// Permet de r�cup�rer une valeur sous la forme Char d'une variable � partir d'un groupe
        /// </summary>
        /// <param name="groupe">Nom du groupe � rechercher</param>
        /// <param name="variable">Nom de la variable � chercher</param>
        /// <returns>Retourne la valeur</returns>
        public char GetValueChar(string groupe, string variable)
        {
            return Convert.ToChar(GetValue(groupe, variable));
        }
        /// <summary>
        /// Permet de r�cup�rer une valeur sous la forme DateTime d'une variable � partir d'un groupe
        /// </summary>
        /// <param name="groupe">Nom du groupe � rechercher</param>
        /// <param name="variable">Nom de la variable � chercher</param>
        /// <returns>Retourne la valeur</returns>
        public DateTime GetValueDateTime(string groupe, string variable)
        {
            return Convert.ToDateTime(GetValue(groupe, variable));
        }
        /// <summary>
        /// Permet de r�cup�rer une valeur sous la forme Decimal d'une variable � partir d'un groupe
        /// </summary>
        /// <param name="groupe">Nom du groupe � rechercher</param>
        /// <param name="variable">Nom de la variable � chercher</param>
        /// <returns>Retourne la valeur</returns>
        public decimal GetValueDecimal(string groupe, string variable)
        {
            return Convert.ToDecimal(GetValue(groupe, variable));
        }
        /// <summary>
        /// Permet de r�cup�rer une valeur sous la forme Double d'une variable � partir d'un groupe
        /// </summary>
        /// <param name="groupe">Nom du groupe � rechercher</param>
        /// <param name="variable">Nom de la variable � chercher</param>
        /// <returns>Retourne la valeur</returns>
        public double GetValueDouble(string groupe, string variable)
        {
            return Convert.ToDouble(GetValue(groupe, variable));
        }
        /// <summary>
        /// Permet de r�cup�rer une valeur sous la forme Int16 d'une variable � partir d'un groupe
        /// </summary>
        /// <param name="groupe">Nom du groupe � rechercher</param>
        /// <param name="variable">Nom de la variable � chercher</param>
        /// <returns>Retourne la valeur</returns>
        public short GetValueInt16(string groupe, string variable)
        {
            return Convert.ToInt16(GetValue(groupe, variable));
        }
        /// <summary>
        /// Permet de r�cup�rer une valeur sous la forme Int32 d'une variable � partir d'un groupe
        /// </summary>
        /// <param name="groupe">Nom du groupe � rechercher</param>
        /// <param name="variable">Nom de la variable � chercher</param>
        /// <returns>Retourne la valeur</returns>
        public int GetValueInt32(string groupe, string variable)
        {
            return Convert.ToInt32(GetValue(groupe, variable));
        }
        /// <summary>
        /// Permet de r�cup�rer une valeur sous la forme Int64 d'une variable � partir d'un groupe
        /// </summary>
        /// <param name="groupe">Nom du groupe � rechercher</param>
        /// <param name="variable">Nom de la variable � chercher</param>
        /// <returns>Retourne la valeur</returns>
        public long GetValueInt64(string groupe, string variable)
        {
            return Convert.ToInt64(GetValue(groupe, variable));
        }
        /// <summary>
        /// Permet de r�cup�rer une valeur sous la forme SByte d'une variable � partir d'un groupe
        /// </summary>
        /// <param name="groupe">Nom du groupe � rechercher</param>
        /// <param name="variable">Nom de la variable � chercher</param>
        /// <returns>Retourne la valeur</returns>
        public sbyte GetValueSByte(string groupe, string variable)
        {
            return Convert.ToSByte(GetValue(groupe, variable));
        }
        /// <summary>
        /// Permet de r�cup�rer une valeur sous la forme Single d'une variable � partir d'un groupe
        /// </summary>
        /// <param name="groupe">Nom du groupe � rechercher</param>
        /// <param name="variable">Nom de la variable � chercher</param>
        /// <returns>Retourne la valeur</returns>
        public float GetValueSingle(string groupe, string variable)
        {
            return Convert.ToSingle(GetValue(groupe, variable));
        }
        /// <summary>
        /// Permet de r�cup�rer une valeur sous la forme String d'une variable � partir d'un groupe
        /// </summary>
        /// <param name="groupe">Nom du groupe � rechercher</param>
        /// <param name="variable">Nom de la variable � chercher</param>
        /// <returns>Retourne la valeur</returns>
        public string GetValueString(string groupe, string variable)
        {
            return GetValue(groupe, variable);
        }
        /// <summary>
        /// Permet de r�cup�rer une valeur sous la forme UInt16 d'une variable � partir d'un groupe
        /// </summary>
        /// <param name="groupe">Nom du groupe � rechercher</param>
        /// <param name="variable">Nom de la variable � chercher</param>
        /// <returns>Retourne la valeur</returns>
        public ushort GetValueUInt16(string groupe, string variable)
        {
            return Convert.ToUInt16(GetValue(groupe, variable));
        }
        /// <summary>
        /// Permet de r�cup�rer une valeur sous la forme UInt32 d'une variable � partir d'un groupe
        /// </summary>
        /// <param name="groupe">Nom du groupe � rechercher</param>
        /// <param name="variable">Nom de la variable � chercher</param>
        /// <returns>Retourne la valeur</returns>
        public uint GetValueUInt32(string groupe, string variable)
        {
            return Convert.ToUInt32(GetValue(groupe, variable));
        }
        /// <summary>
        /// Permet de r�cup�rer une valeur sous la forme UInt64 d'une variable � partir d'un groupe
        /// </summary>
        /// <param name="groupe">Nom du groupe � rechercher</param>
        /// <param name="variable">Nom de la variable � chercher</param>
        /// <returns>Retourne la valeur</returns>
        public ulong GetValueUInt64(string groupe, string variable)
        {
            return Convert.ToUInt64(GetValue(groupe, variable));
        }
        /// <summary>
        /// Permet de r�cup�rer une valeur sous la forme Boolean d'une variable � partir d'un groupe
        /// </summary>        
        /// <param name="variable">Nom de la variable � chercher</param>
        /// <returns>Retourne la valeur</returns>
        public bool GetValueBoolean(string variable)
        {
            return Convert.ToBoolean(GetValue(Groupe, variable));
        }
        /// <summary>
        /// Permet de r�cup�rer une valeur sous la forme Byte d'une variable � partir d'un groupe
        /// </summary>
        /// <param name="variable">Nom de la variable � chercher</param>
        /// <returns>Retourne la valeur</returns>
        public byte GetValueByte(string variable)
        {
            return Convert.ToByte(GetValue(Groupe, variable));
        }
        /// <summary>
        /// Permet de r�cup�rer une valeur sous la forme Char d'une variable � partir d'un groupe
        /// </summary>
        /// <param name="variable">Nom de la variable � chercher</param>
        /// <returns>Retourne la valeur</returns>
        public char GetValueChar(string variable)
        {
            return Convert.ToChar(GetValue(Groupe, variable));
        }
        /// <summary>
        /// Permet de r�cup�rer une valeur sous la forme DateTime d'une variable � partir d'un groupe
        /// </summary>
        /// <param name="variable">Nom de la variable � chercher</param>
        /// <returns>Retourne la valeur</returns>
        public DateTime GetValueDateTime(string variable)
        {
            return Convert.ToDateTime(GetValue(Groupe, variable));
        }
        /// <summary>
        /// Permet de r�cup�rer une valeur sous la forme Decimal d'une variable � partir d'un groupe
        /// </summary>
        /// <param name="variable">Nom de la variable � chercher</param>
        /// <returns>Retourne la valeur</returns>
        public decimal GetValueDecimal(string variable)
        {
            return Convert.ToDecimal(GetValue(Groupe, variable));
        }
        /// <summary>
        /// Permet de r�cup�rer une valeur sous la forme Double d'une variable � partir d'un groupe
        /// </summary>
        /// <param name="variable">Nom de la variable � chercher</param>
        /// <returns>Retourne la valeur</returns>
        public double GetValueDouble(string variable)
        {
            return Convert.ToDouble(GetValue(Groupe, variable));
        }
        /// <summary>
        /// Permet de r�cup�rer une valeur sous la forme Int16 d'une variable � partir d'un groupe
        /// </summary>
        /// <param name="variable">Nom de la variable � chercher</param>
        /// <returns>Retourne la valeur</returns>
        public short GetValueInt16(string variable)
        {
            return Convert.ToInt16(GetValue(Groupe, variable));
        }
        /// <summary>
        /// Permet de r�cup�rer une valeur sous la forme Int32 d'une variable � partir d'un groupe
        /// </summary>
        /// <param name="variable">Nom de la variable � chercher</param>
        /// <returns>Retourne la valeur</returns>
        public int GetValueInt32(string variable)
        {
            return Convert.ToInt32(GetValue(Groupe, variable));
        }
        /// <summary>
        /// Permet de r�cup�rer une valeur sous la forme Int64 d'une variable � partir d'un groupe
        /// </summary>
        /// <param name="variable">Nom de la variable � chercher</param>
        /// <returns>Retourne la valeur</returns>
        public long GetValueInt64(string variable)
        {
            return Convert.ToInt64(GetValue(Groupe, variable));
        }
        /// <summary>
        /// Permet de r�cup�rer une valeur sous la forme SByte d'une variable � partir d'un groupe
        /// </summary>
        /// <param name="variable">Nom de la variable � chercher</param>
        /// <returns>Retourne la valeur</returns>
        public sbyte GetValueSByte(string variable)
        {
            return Convert.ToSByte(GetValue(Groupe, variable));
        }
        /// <summary>
        /// Permet de r�cup�rer une valeur sous la forme Single d'une variable � partir d'un groupe
        /// </summary>
        /// <param name="variable">Nom de la variable � chercher</param>
        /// <returns>Retourne la valeur</returns>
        public float GetValueSingle(string variable)
        {
            return Convert.ToSingle(GetValue(Groupe, variable));
        }
        /// <summary>
        /// Permet de r�cup�rer une valeur sous la forme String d'une variable � partir d'un groupe
        /// </summary>
        /// <param name="variable">Nom de la variable � chercher</param>
        /// <returns>Retourne la valeur</returns>
        public string GetValueString(string variable)
        {
            return GetValue(Groupe, variable);
        }
        /// <summary>
        /// Permet de r�cup�rer une valeur sous la forme UInt16 d'une variable � partir d'un groupe
        /// </summary>
        /// <param name="variable">Nom de la variable � chercher</param>
        /// <returns>Retourne la valeur</returns>
        public ushort GetValueUInt16(string variable)
        {
            return Convert.ToUInt16(GetValue(Groupe, variable));
        }
        /// <summary>
        /// Permet de r�cup�rer une valeur sous la forme UInt32 d'une variable � partir d'un groupe
        /// </summary>
        /// <param name="variable">Nom de la variable � chercher</param>
        /// <returns>Retourne la valeur</returns>
        public uint GetValueUInt32(string variable)
        {
            return Convert.ToUInt32(GetValue(Groupe, variable));
        }
        /// <summary>
        /// Permet de r�cup�rer une valeur sous la forme UInt64 d'une variable � partir d'un groupe
        /// </summary>
        /// <param name="variable">Nom de la variable � chercher</param>
        /// <returns>Retourne la valeur</returns>
        public ulong GetValueUInt64(string variable)
        {
            return Convert.ToUInt64(GetValue(Groupe, variable));
        }
        #endregion
        
        #region " M�thodes - EditValue "
        /// <summary>
        /// Cette m�thode permet de modifier une valeur existante
        /// </summary>
        /// <param name="MonGroupe">Nom du groupe � chercher</param>
        /// <param name="MaVariable">Nom de la variable � chercher</param>
        /// <param name="MaValeur">Nouvelle valeur</param>
        private void EditValuePrivate(string MonGroupe, string MaVariable, string MaValeur)
        {
            // On verifie que le fichier existe
            if (File.Exists(Fichier))
            {
                // Cr�ation d'une instance StreamReader
                StreamReader sr = new StreamReader(Fichier, Encodage);
                // On met le contenu du fichier dans une variable
                string s = sr.ReadToEnd();
                // On ferme le fichier
                sr.Close();

                try
                {
                    // On r�cup�re la position du groupe demand�
                    int g = s.IndexOf("[" + MonGroupe + "]");
                    // On r�cup�re la position de la variable demand�e � partie de la
                    // position du groupe demand�
                    int v = s.IndexOf(MaVariable, g);
                    // On r�cup�re la position de la fin de la valeur
                    int n = s.IndexOf("\r\n", v);
                    // On extrait la chaine variable + valeur
                    string p = s.Substring(v, n - v);
                    // On remplace par la nouvelle valeur
                    s = s.Replace(p, MaVariable + "=" + MaValeur);

                    // Cr�ation d'une instance StreamWriter
                    StreamWriter sw = new StreamWriter(Fichier, false, Encodage);
                    // On modifie le fichier
                    sw.Write(s);
                    // On ferme le fichier
                    sw.Close();
                }
                catch
                {
                    sr.Close();
                }                
            }
        }

        /// <summary>
        /// Cette m�thode permet de modifier une valeur sous la forme Boolean
        /// </summary>
        /// <param name="groupe">Nom du groupe � chercher dans le fichier INI</param>
        /// <param name="variable">Nom de la variable � chercher dans le fichier INI</param>
        /// <param name="NewValue">Nouvelle valeur � modifier</param>
        public void EditValue(string groupe, string variable, bool NewValue)
        {
            EditValuePrivate(groupe, variable, Convert.ToString(NewValue));
        }
        /// <summary>
        /// Cette m�thode permet de modifier une valeur sous la forme Byte
        /// </summary>
        /// <param name="groupe">Nom du groupe � chercher dans le fichier INI</param>
        /// <param name="variable">Nom de la variable � chercher dans le fichier INI</param>
        /// <param name="NewValue">Nouvelle valeur � modifier</param>
        public void EditValue(string groupe, string variable, byte NewValue)
        {
            EditValuePrivate(groupe, variable, Convert.ToString(NewValue));
        }
        /// <summary>
        /// Cette m�thode permet de modifier une valeur sous la forme Char
        /// </summary>
        /// <param name="groupe">Nom du groupe � chercher dans le fichier INI</param>
        /// <param name="variable">Nom de la variable � chercher dans le fichier INI</param>
        /// <param name="NewValue">Nouvelle valeur � modifier</param>
        public void EditValue(string groupe, string variable, char NewValue)
        {
            EditValuePrivate(groupe, variable, Convert.ToString(NewValue));
        }
        /// <summary>
        /// Cette m�thode permet de modifier une valeur sous la forme DateTime
        /// </summary>
        /// <param name="groupe">Nom du groupe � chercher dans le fichier INI</param>
        /// <param name="variable">Nom de la variable � chercher dans le fichier INI</param>
        /// <param name="NewValue">Nouvelle valeur � modifier</param>
        public void EditValue(string groupe, string variable, DateTime NewValue)
        {
            EditValuePrivate(groupe, variable, Convert.ToString(NewValue));
        }
        /// <summary>
        /// Cette m�thode permet de modifier une valeur sous la forme Decimal
        /// </summary>
        /// <param name="groupe">Nom du groupe � chercher dans le fichier INI</param>
        /// <param name="variable">Nom de la variable � chercher dans le fichier INI</param>
        /// <param name="NewValue">Nouvelle valeur � modifier</param>
        public void EditValue(string groupe, string variable, decimal NewValue)
        {
            EditValuePrivate(groupe, variable, Convert.ToString(NewValue));
        }
        /// <summary>
        /// Cette m�thode permet de modifier une valeur sous la forme Double
        /// </summary>
        /// <param name="groupe">Nom du groupe � chercher dans le fichier INI</param>
        /// <param name="variable">Nom de la variable � chercher dans le fichier INI</param>
        /// <param name="NewValue">Nouvelle valeur � modifier</param>
        public void EditValue(string groupe, string variable, double NewValue)
        {
            EditValuePrivate(groupe, variable, Convert.ToString(NewValue));
        }
        /// <summary>
        /// Cette m�thode permet de modifier une valeur sous la forme Int16
        /// </summary>
        /// <param name="groupe">Nom du groupe � chercher dans le fichier INI</param>
        /// <param name="variable">Nom de la variable � chercher dans le fichier INI</param>
        /// <param name="NewValue">Nouvelle valeur � modifier</param>
        public void EditValue(string groupe, string variable, short NewValue)
        {
            EditValuePrivate(groupe, variable, Convert.ToString(NewValue));
        }
        /// <summary>
        /// Cette m�thode permet de modifier une valeur sous la forme Int32
        /// </summary>
        /// <param name="groupe">Nom du groupe � chercher dans le fichier INI</param>
        /// <param name="variable">Nom de la variable � chercher dans le fichier INI</param>
        /// <param name="NewValue">Nouvelle valeur � modifier</param>
        public void EditValue(string groupe, string variable, int NewValue)
        {
            EditValuePrivate(groupe, variable, Convert.ToString(NewValue));
        }
        /// <summary>
        /// Cette m�thode permet de modifier une valeur sous la forme Int64
        /// </summary>
        /// <param name="groupe">Nom du groupe � chercher dans le fichier INI</param>
        /// <param name="variable">Nom de la variable � chercher dans le fichier INI</param>
        /// <param name="NewValue">Nouvelle valeur � modifier</param>
        public void EditValue(string groupe, string variable, long NewValue)
        {
            EditValuePrivate(groupe, variable, Convert.ToString(NewValue));
        }
        /// <summary>
        /// Cette m�thode permet de modifier une valeur sous la forme SByte
        /// </summary>
        /// <param name="groupe">Nom du groupe � chercher dans le fichier INI</param>
        /// <param name="variable">Nom de la variable � chercher dans le fichier INI</param>
        /// <param name="NewValue">Nouvelle valeur � modifier</param>
        public void EditValue(string groupe, string variable, sbyte NewValue)
        {
            EditValuePrivate(groupe, variable, Convert.ToString(NewValue));
        }
        /// <summary>
        /// Cette m�thode permet de modifier une valeur sous la forme Single
        /// </summary>
        /// <param name="groupe">Nom du groupe � chercher dans le fichier INI</param>
        /// <param name="variable">Nom de la variable � chercher dans le fichier INI</param>
        /// <param name="NewValue">Nouvelle valeur � modifier</param>
        public void EditValue(string groupe, string variable, float NewValue)
        {
            EditValuePrivate(groupe, variable, Convert.ToString(NewValue));
        }
        /// <summary>
        /// Cette m�thode permet de modifier une valeur sous la forme String
        /// </summary>
        /// <param name="groupe">Nom du groupe � chercher dans le fichier INI</param>
        /// <param name="variable">Nom de la variable � chercher dans le fichier INI</param>
        /// <param name="NewValue">Nouvelle valeur � modifier</param>
        public void EditValue(string groupe, string variable, string NewValue)
        {
            EditValuePrivate(groupe, variable, NewValue);
        }
        /// <summary>
        /// Cette m�thode permet de modifier une valeur sous la forme Unit16
        /// </summary>
        /// <param name="groupe">Nom du groupe � chercher dans le fichier INI</param>
        /// <param name="variable">Nom de la variable � chercher dans le fichier INI</param>
        /// <param name="NewValue">Nouvelle valeur � modifier</param>
        public void EditValue(string groupe, string variable, ushort NewValue)
        {
            EditValuePrivate(groupe, variable, Convert.ToString(NewValue));
        }
        /// <summary>
        /// Cette m�thode permet de modifier une valeur sous la forme Unit32
        /// </summary>
        /// <param name="groupe">Nom du groupe � chercher dans le fichier INI</param>
        /// <param name="variable">Nom de la variable � chercher dans le fichier INI</param>
        /// <param name="NewValue">Nouvelle valeur � modifier</param>
        public void EditValue(string groupe, string variable, uint NewValue)
        {
            EditValuePrivate(groupe, variable, Convert.ToString(NewValue));
        }
        /// <summary>
        /// Cette m�thode permet de modifier une valeur sous la forme Unit64
        /// </summary>
        /// <param name="groupe">Nom du groupe � chercher dans le fichier INI</param>
        /// <param name="variable">Nom de la variable � chercher dans le fichier INI</param>
        /// <param name="NewValue">Nouvelle valeur � modifier</param>
        public void EditValue(string groupe, string variable, ulong NewValue)
        {
            EditValuePrivate(groupe, variable, Convert.ToString(NewValue));
        }
        /// <summary>
        /// Cette m�thode permet de modifier une valeur sous la forme Boolean
        /// </summary>        
        /// <param name="variable">Nom de la variable � chercher dans le fichier INI</param>
        /// <param name="NewValue">Nouvelle valeur � modifier</param>
        public void EditValue(string variable, bool NewValue)
        {
            EditValuePrivate(Groupe, variable, Convert.ToString(NewValue));
        }
        /// <summary>
        /// Cette m�thode permet de modifier une valeur sous la forme Byte
        /// </summary>        
        /// <param name="variable">Nom de la variable � chercher dans le fichier INI</param>
        /// <param name="NewValue">Nouvelle valeur � modifier</param>
        public void EditValue(string variable, byte NewValue)
        {
            EditValuePrivate(Groupe, variable, Convert.ToString(NewValue));
        }
        /// <summary>
        /// Cette m�thode permet de modifier une valeur sous la forme Char
        /// </summary>        
        /// <param name="variable">Nom de la variable � chercher dans le fichier INI</param>
        /// <param name="NewValue">Nouvelle valeur � modifier</param>
        public void EditValue(string variable, char NewValue)
        {
            EditValuePrivate(Groupe, variable, Convert.ToString(NewValue));
        }
        /// <summary>
        /// Cette m�thode permet de modifier une valeur sous la forme DateTime
        /// </summary>        
        /// <param name="variable">Nom de la variable � chercher dans le fichier INI</param>
        /// <param name="NewValue">Nouvelle valeur � modifier</param>
        public void EditValue(string variable, DateTime NewValue)
        {
            EditValuePrivate(Groupe, variable, Convert.ToString(NewValue));
        }
        /// <summary>
        /// Cette m�thode permet de modifier une valeur sous la forme Decimal
        /// </summary>        
        /// <param name="variable">Nom de la variable � chercher dans le fichier INI</param>
        /// <param name="NewValue">Nouvelle valeur � modifier</param>
        public void EditValue(string variable, decimal NewValue)
        {
            EditValuePrivate(Groupe, variable, Convert.ToString(NewValue));
        }
        /// <summary>
        /// Cette m�thode permet de modifier une valeur sous la forme Double
        /// </summary>        
        /// <param name="variable">Nom de la variable � chercher dans le fichier INI</param>
        /// <param name="NewValue">Nouvelle valeur � modifier</param>
        public void EditValue(string variable, double NewValue)
        {
            EditValuePrivate(Groupe, variable, Convert.ToString(NewValue));
        }
        /// <summary>
        /// Cette m�thode permet de modifier une valeur sous la forme Int16
        /// </summary>        
        /// <param name="variable">Nom de la variable � chercher dans le fichier INI</param>
        /// <param name="NewValue">Nouvelle valeur � modifier</param>
        public void EditValue(string variable, short NewValue)
        {
            EditValuePrivate(Groupe, variable, Convert.ToString(NewValue));
        }
        /// <summary>
        /// Cette m�thode permet de modifier une valeur sous la forme Int32
        /// </summary>        
        /// <param name="variable">Nom de la variable � chercher dans le fichier INI</param>
        /// <param name="NewValue">Nouvelle valeur � modifier</param>
        public void EditValue(string variable, int NewValue)
        {
            EditValuePrivate(Groupe, variable, Convert.ToString(NewValue));
        }
        /// <summary>
        /// Cette m�thode permet de modifier une valeur sous la forme Int64
        /// </summary>        
        /// <param name="variable">Nom de la variable � chercher dans le fichier INI</param>
        /// <param name="NewValue">Nouvelle valeur � modifier</param>
        public void EditValue(string variable, long NewValue)
        {
            EditValuePrivate(Groupe, variable, Convert.ToString(NewValue));
        }
        /// <summary>
        /// Cette m�thode permet de modifier une valeur sous la forme SByte
        /// </summary>        
        /// <param name="variable">Nom de la variable � chercher dans le fichier INI</param>
        /// <param name="NewValue">Nouvelle valeur � modifier</param>
        public void EditValue(string variable, sbyte NewValue)
        {
            EditValuePrivate(Groupe, variable, Convert.ToString(NewValue));
        }
        /// <summary>
        /// Cette m�thode permet de modifier une valeur sous la forme Single
        /// </summary>        
        /// <param name="variable">Nom de la variable � chercher dans le fichier INI</param>
        /// <param name="NewValue">Nouvelle valeur � modifier</param>
        public void EditValue(string variable, float NewValue)
        {
            EditValuePrivate(Groupe, variable, Convert.ToString(NewValue));
        }
        /// <summary>
        /// Cette m�thode permet de modifier une valeur sous la forme String
        /// </summary>        
        /// <param name="variable">Nom de la variable � chercher dans le fichier INI</param>
        /// <param name="NewValue">Nouvelle valeur � modifier</param>
        public void EditValue(string variable, string NewValue)
        {
            EditValuePrivate(Groupe, variable, NewValue);
        }
        /// <summary>
        /// Cette m�thode permet de modifier une valeur sous la forme Unit16
        /// </summary>        
        /// <param name="variable">Nom de la variable � chercher dans le fichier INI</param>
        /// <param name="NewValue">Nouvelle valeur � modifier</param>
        public void EditValue(string variable, ushort NewValue)
        {
            EditValuePrivate(Groupe, variable, Convert.ToString(NewValue));
        }
        /// <summary>
        /// Cette m�thode permet de modifier une valeur sous la forme Unit32
        /// </summary>        
        /// <param name="variable">Nom de la variable � chercher dans le fichier INI</param>
        /// <param name="NewValue">Nouvelle valeur � modifier</param>
        public void EditValue(string variable, uint NewValue)
        {
            EditValuePrivate(Groupe, variable, Convert.ToString(NewValue));
        }
        /// <summary>
        /// Cette m�thode permet de modifier une valeur sous la forme Unit64
        /// </summary>        
        /// <param name="variable">Nom de la variable � chercher dans le fichier INI</param>
        /// <param name="NewValue">Nouvelle valeur � modifier</param>
        public void EditValue(string variable, ulong NewValue)
        {
            EditValuePrivate(Groupe, variable, Convert.ToString(NewValue));
        }
        #endregion

        #region " M�thodes - EditVariable "
        /// <summary>
        /// Cette m�thode permet de modifier une variable d'un groupe INI
        /// </summary>
        /// <param name="MonGroupe">Nom du groupe � chercher</param>
        /// <param name="MyOldVariable">Nom de la variable � remplacer</param>
        /// <param name="MyNewVariable">Nom de la nouvelle variable</param>
        private void EditVariablePrivate(string MonGroupe, string MyOldVariable, string MyNewVariable)
        {
            // On verifie que le fichier existe
            if (File.Exists(Fichier))
            {
                // Cr�ation d'une instance StreamReader
                StreamReader sr = new StreamReader(Fichier, Encodage);
                // On met le contenu du fichier dans une variable
                string s = sr.ReadToEnd();
                // On ferme le fichier
                sr.Close();

                try
                {
                    // On r�cup�re la position du groupe demand�
                    int g = s.IndexOf("[" + MonGroupe + "]");
                    // On r�cup�re la position de la variable demand�e � partie de la
                    // position du groupe demand�
                    int v = s.IndexOf(MyOldVariable, g);
                    // On r�cup�re la position de la fin de la valeur
                    int n = s.IndexOf("\r\n", v);
                    // On r�cup�re la valeur
                    string MaValeur = s.Substring(s.IndexOf("=", v) + 1, n - s.IndexOf("=", v) - 1);
                    // On extrait la chaine variable + valeur
                    string p = s.Substring(v, n - v);
                    // On remplace par la nouvelle variable
                    s = s.Replace(p, MyNewVariable + "=" + MaValeur);
                    
                    // Cr�ation d'une instance StreamWriter
                    StreamWriter sw = new StreamWriter(Fichier, false, Encodage);
                    // On modifie le fichier
                    sw.Write(s);
                    // On ferme le fichier
                    sw.Close();
                }
                catch
                {
                    sr.Close();
                }                
            }
        }
        /// <summary>
        /// Cette m�thode permet de modifier une variable d'un groupe INI
        /// </summary>
        /// <param name="MyGroupe">Nom du groupe � chercher</param>
        /// <param name="OldVariable">Nom de la variable � remplacer</param>
        /// <param name="NewVariable">Nom de la nouvelle variable</param>
        public void EditVariable(string MyGroupe, string OldVariable, string NewVariable)
        {
            EditValuePrivate(MyGroupe, OldVariable, NewVariable);
        }
        /// <summary>
        /// Cette m�thode permet de modifier une variable d'un groupe INI
        /// </summary>
        /// <param name="OldVariable">Nom de la variable � remplacer</param>
        /// <param name="NewVariable">Nom de la nouvelle variable</param>
        public void EditVariable(string OldVariable, string NewVariable)
        {
            EditValuePrivate(Groupe, OldVariable, NewVariable);
        }
        #endregion

        #region " M�thodes - EditGroup "
        /// <summary>
        /// Permet de modifier le nom d'un groupe
        /// </summary>
        /// <param name="MyOrdGroup">Nom du groupe � modifier</param>
        /// <param name="MyNewGroup">Nouveau nom du groupe</param>
        public void EditGroup(string MyOrdGroup, string MyNewGroup)
        {
            // On verifie que le fichier existe
            if (File.Exists(Fichier))
            {
                // Cr�ation d'une instance StreamReader
                StreamReader sr = new StreamReader(Fichier, Encodage);
                // On met le contenu du fichier dans une variable
                string s = sr.ReadToEnd();
                // On ferme le fichier
                sr.Close();

                try
                {           
                    // On r�cup�re la position du groupe demand�
                    int g = s.IndexOf("[" + MyOrdGroup + "]");
                    // On r�cup�re la position de la fin du groupe
                    int n = s.IndexOf("\r\n", g);
                    // On stocke le groupe dans une variable
                    string p = s.Substring(g, n - g);
                    // On remplace l'ancien groupe par le nouveau
                    s = s.Replace(p, "[" + MyNewGroup + "]");
                    
                    // Cr�ation d'une instance StreamWriter
                    StreamWriter sw = new StreamWriter(Fichier, false, Encodage);
                    // On modifie le fichier
                    sw.Write(s);
                    // On ferme le fichier
                    sw.Close();
                }
                catch
                {
                    sr.Close();
                }                
            }
        }
        #endregion

        #region " M�thodes - NewGroupVariableValue "
        /// <summary>
        /// Permet de cr�er un nouveau groupe, une nouvelle variable et une nouvelle valeur
        /// </summary>
        /// <param name="MyGroupe">Nom du groupe � cr�er</param>
        /// <param name="MyVariable">Nom de la variable � cr�er</param>
        /// <param name="MyValeur">Nom de la valeur � cr�er</param>
        private void NewGroupVariableValuePrivate(string MyGroupe, string MyVariable, string MyValeur)
        {
            // D�claration des variables
            string s = "";

            // On v�rifie que le fichier existe
            if (File.Exists(Fichier))
            {
                // Cr�ation d'une nouvelle instance StreamReader
                StreamReader sr = new StreamReader(Fichier, Encodage);
                // On retourne tout le contenu du fichier dans une variable
                s = sr.ReadToEnd();
                // On ferme le fichier
                sr.Close();
            }

            // On v�rifie si le fichier n'est pas vide
            if (s == null || s == "")
            {
                // Cr�ation d'une nouvelle instance StreamWriter avec le bool � false
                // qui permet d'�craser le fichier existant
                StreamWriter sw = new StreamWriter(Fichier, false, Encodage);
                // On �crit le groupe
                sw.Write("[" + MyGroupe + "]\r\n");
                // On �crit la variable et la valeur
                sw.Write(MyVariable + "=" + MyValeur + "\r\n");
                // On ferme le fichier
                sw.Close();
            }
            else
            {
                // Cr�ation d'une nouvelle instance StreamWriter avec le bool � true
                // qui permet de ne pas �crasser le fichier existant
                StreamWriter sw = new StreamWriter(Fichier, true, Encodage);
                // On �crit le groupe
                sw.Write("\r\n[" + MyGroupe + "]" + "\r\n");
                // On ajoute la variable et la valeur
                sw.Write(MyVariable + "=" + MyValeur + "\r\n");
                // On ferme le fichier
                sw.Close();
            }
        }

        /// <summary>
        /// Cette m�thode permet de cr�er un nouveau groupe et une nouvelle variable avec 
        /// une nouvelle valeur
        /// </summary>
        /// <param name="groupe">Nom du nouveau groupe</param>
        /// <param name="variable">Nom de la nouvelle variable</param>
        /// <param name="valeur">Valeur Boolean � ajouter</param>
        public void NewGroupVariableValue(string groupe, string variable, bool valeur)
        {
            NewGroupVariableValuePrivate(groupe, variable, Convert.ToString(valeur));
        }
        /// <summary>
        /// Cette m�thode permet de cr�er un nouveau groupe et une nouvelle variable avec 
        /// une nouvelle valeur
        /// </summary>
        /// <param name="groupe">Nom du nouveau groupe</param>
        /// <param name="variable">Nom de la nouvelle variable</param>
        /// <param name="valeur">Valeur Byte � ajouter</param>
        public void NewGroupVariableValue(string groupe, string variable, byte valeur)
        {
            NewGroupVariableValuePrivate(groupe, variable, Convert.ToString(valeur));
        }
        /// <summary>
        /// Cette m�thode permet de cr�er un nouveau groupe et une nouvelle variable avec 
        /// une nouvelle valeur
        /// </summary>
        /// <param name="groupe">Nom du nouveau groupe</param>
        /// <param name="variable">Nom de la nouvelle variable</param>
        /// <param name="valeur">Valeur Char � ajouter</param>
        public void NewGroupVariableValue(string groupe, string variable, char valeur)
        {
            NewGroupVariableValuePrivate(groupe, variable, Convert.ToString(valeur));
        }
        /// <summary>
        /// Cette m�thode permet de cr�er un nouveau groupe et une nouvelle variable avec 
        /// une nouvelle valeur
        /// </summary>
        /// <param name="groupe">Nom du nouveau groupe</param>
        /// <param name="variable">Nom de la nouvelle variable</param>
        /// <param name="valeur">Valeur DateTime � ajouter</param>
        public void NewGroupVariableValue(string groupe, string variable, DateTime valeur)
        {
            NewGroupVariableValuePrivate(groupe, variable, Convert.ToString(valeur));
        }
        /// <summary>
        /// Cette m�thode permet de cr�er un nouveau groupe et une nouvelle variable avec 
        /// une nouvelle valeur
        /// </summary>
        /// <param name="groupe">Nom du nouveau groupe</param>
        /// <param name="variable">Nom de la nouvelle variable</param>
        /// <param name="valeur">Valeur Decimal � ajouter</param>
        public void NewGroupVariableValue(string groupe, string variable, decimal valeur)
        {
            NewGroupVariableValuePrivate(groupe, variable, Convert.ToString(valeur));
        }
        /// <summary>
        /// Cette m�thode permet de cr�er un nouveau groupe et une nouvelle variable avec 
        /// une nouvelle valeur
        /// </summary>
        /// <param name="groupe">Nom du nouveau groupe</param>
        /// <param name="variable">Nom de la nouvelle variable</param>
        /// <param name="valeur">Valeur Double � ajouter</param>
        public void NewGroupVariableValue(string groupe, string variable, double valeur)
        {
            NewGroupVariableValuePrivate(groupe, variable, Convert.ToString(valeur));
        }
        /// <summary>
        /// Cette m�thode permet de cr�er un nouveau groupe et une nouvelle variable avec 
        /// une nouvelle valeur
        /// </summary>
        /// <param name="groupe">Nom du nouveau groupe</param>
        /// <param name="variable">Nom de la nouvelle variable</param>
        /// <param name="valeur">Valeur Int16 � ajouter</param>
        public void NewGroupVariableValue(string groupe, string variable, short valeur)
        {
            NewGroupVariableValuePrivate(groupe, variable, Convert.ToString(valeur));
        }
        /// <summary>
        /// Cette m�thode permet de cr�er un nouveau groupe et une nouvelle variable avec 
        /// une nouvelle valeur
        /// </summary>
        /// <param name="groupe">Nom du nouveau groupe</param>
        /// <param name="variable">Nom de la nouvelle variable</param>
        /// <param name="valeur">Valeur Int32 � ajouter</param>
        public void NewGroupVariableValue(string groupe, string variable, int valeur)
        {
            NewGroupVariableValuePrivate(groupe, variable, Convert.ToString(valeur));
        }
        /// <summary>
        /// Cette m�thode permet de cr�er un nouveau groupe et une nouvelle variable avec 
        /// une nouvelle valeur
        /// </summary>
        /// <param name="groupe">Nom du nouveau groupe</param>
        /// <param name="variable">Nom de la nouvelle variable</param>
        /// <param name="valeur">Valeur Int64 � ajouter</param>
        public void NewGroupVariableValue(string groupe, string variable, long valeur)
        {
            NewGroupVariableValuePrivate(groupe, variable, Convert.ToString(valeur));
        }
        /// <summary>
        /// Cette m�thode permet de cr�er un nouveau groupe et une nouvelle variable avec 
        /// une nouvelle valeur
        /// </summary>
        /// <param name="groupe">Nom du nouveau groupe</param>
        /// <param name="variable">Nom de la nouvelle variable</param>
        /// <param name="valeur">Valeur SByte � ajouter</param>
        public void NewGroupVariableValue(string groupe, string variable, sbyte valeur)
        {
            NewGroupVariableValuePrivate(groupe, variable, Convert.ToString(valeur));
        }
        /// <summary>
        /// Cette m�thode permet de cr�er un nouveau groupe et une nouvelle variable avec 
        /// une nouvelle valeur
        /// </summary>
        /// <param name="groupe">Nom du nouveau groupe</param>
        /// <param name="variable">Nom de la nouvelle variable</param>
        /// <param name="valeur">Valeur Single � ajouter</param>
        public void NewGroupVariableValue(string groupe, string variable, float valeur)
        {
            NewGroupVariableValuePrivate(groupe, variable, Convert.ToString(valeur));
        }
        /// <summary>
        /// Cette m�thode permet de cr�er un nouveau groupe et une nouvelle variable avec 
        /// une nouvelle valeur
        /// </summary>
        /// <param name="groupe">Nom du nouveau groupe</param>
        /// <param name="variable">Nom de la nouvelle variable</param>
        /// <param name="valeur">Valeur String � ajouter</param>
        public void NewGroupVariableValue(string groupe, string variable, string valeur)
        {
            NewGroupVariableValuePrivate(groupe, variable, valeur);
        }
        /// <summary>
        /// Cette m�thode permet de cr�er un nouveau groupe et une nouvelle variable avec 
        /// une nouvelle valeur
        /// </summary>
        /// <param name="groupe">Nom du nouveau groupe</param>
        /// <param name="variable">Nom de la nouvelle variable</param>
        /// <param name="valeur">Valeur UInt16 � ajouter</param>
        public void NewGroupVariableValue(string groupe, string variable, ushort valeur)
        {
            NewGroupVariableValuePrivate(groupe, variable, Convert.ToString(valeur));
        }
        /// <summary>
        /// Cette m�thode permet de cr�er un nouveau groupe et une nouvelle variable avec 
        /// une nouvelle valeur
        /// </summary>
        /// <param name="groupe">Nom du nouveau groupe</param>
        /// <param name="variable">Nom de la nouvelle variable</param>
        /// <param name="valeur">Valeur UInt32 � ajouter</param>
        public void NewGroupVariableValue(string groupe, string variable, uint valeur)
        {
            NewGroupVariableValuePrivate(groupe, variable, Convert.ToString(valeur));
        }
        /// <summary>
        /// Cette m�thode permet de cr�er un nouveau groupe et une nouvelle variable avec 
        /// une nouvelle valeur
        /// </summary>
        /// <param name="groupe">Nom du nouveau groupe</param>
        /// <param name="variable">Nom de la nouvelle variable</param>
        /// <param name="valeur">Valeur UInt64 � ajouter</param>
        public void NewGroupVariableValue(string groupe, string variable, ulong valeur)
        {
            NewGroupVariableValuePrivate(groupe, variable, Convert.ToString(valeur));
        }
        #endregion

        #region " M�thodes - NewVariableValue "
        /// <summary>
        /// Cette m�thode permet de cr�er une nouvelle variable et une nouvelle valeur 
        /// � partir d'un groupe
        /// </summary>
        /// <param name="MyGroupe">Nom du groupe � chercher</param>
        /// <param name="MyNewVariable">Nom de la nouvelle variable</param>
        /// <param name="MyNewValue">Nom de la nouvelle valeur</param>
        private void NewVariableValuePrivate(string MyGroupe, string MyNewVariable, string MyNewValue)
        {
            // On v�rifie que le fichier existe
            if ((File.Exists(Fichier)) && (MyGroupe != "" && MyNewVariable != "" && MyNewValue != ""))
            {
                // Cr�ation d'une nouvelle instance StreamReader
                StreamReader sr = new StreamReader(Fichier, Encodage);
                // On met le contenu du fichier dans une variable
                string s = sr.ReadToEnd();
                // On ferme le fichier
                sr.Close();

                try
                {
                    // On r�cup�re la position de d�part du groupe demand�
                    int g = s.IndexOf("[" + MyGroupe + "]");
                    // On r�cup�re la position de fin du groupe demand�
                    int n = s.IndexOf("\r\n", g);                    
                    // On ins�re la nouvelle valeur et la nouvelle variable
                    s = s.Insert(n, "\r\n" + MyNewVariable + "=" + MyNewValue);

                    // Cr�ation d'une instance StreamWriter
                    StreamWriter sw = new StreamWriter(Fichier, false, Encodage);
                    // On modifie le fichier
                    sw.Write(s);
                    // On ferme le fichier
                    sw.Close();
                }
                catch
                {
                    sr.Close();
                }                
            }            
        }

        /// <summary>
        /// Cette m�thode permet de cr�er une nouvelle variable et une nouvelle valeur 
        /// � partir d'un groupe
        /// </summary>
        /// <param name="groupe">Nom du groupe � chercher</param>
        /// <param name="NewVariable">Nom de la nouvelle variable</param>
        /// <param name="NewValue">Nom de la nouvelle valeur sous forme Boolean</param>
        public void NewVariableValue(string groupe, string NewVariable, bool NewValue)
        {
            NewVariableValuePrivate(groupe, NewVariable, Convert.ToString(NewValue));
        }
        /// <summary>
        /// Cette m�thode permet de cr�er une nouvelle variable et une nouvelle valeur 
        /// � partir d'un groupe
        /// </summary>
        /// <param name="groupe">Nom du groupe � chercher</param>
        /// <param name="NewVariable">Nom de la nouvelle variable</param>
        /// <param name="NewValue">Nom de la nouvelle valeur sous forme Byte</param>
        public void NewVariableValue(string groupe, string NewVariable, byte NewValue)
        {
            NewVariableValuePrivate(groupe, NewVariable, Convert.ToString(NewValue));
        }
        /// <summary>
        /// Cette m�thode permet de cr�er une nouvelle variable et une nouvelle valeur 
        /// � partir d'un groupe
        /// </summary>
        /// <param name="groupe">Nom du groupe � chercher</param>
        /// <param name="NewVariable">Nom de la nouvelle variable</param>
        /// <param name="NewValue">Nom de la nouvelle valeur sous forme Char</param>
        public void NewVariableValue(string groupe, string NewVariable, char NewValue)
        {
            NewVariableValuePrivate(groupe, NewVariable, Convert.ToString(NewValue));
        }
        /// <summary>
        /// Cette m�thode permet de cr�er une nouvelle variable et une nouvelle valeur 
        /// � partir d'un groupe
        /// </summary>
        /// <param name="groupe">Nom du groupe � chercher</param>
        /// <param name="NewVariable">Nom de la nouvelle variable</param>
        /// <param name="NewValue">Nom de la nouvelle valeur sous forme DateTime</param>
        public void NewVariableValue(string groupe, string NewVariable, DateTime NewValue)
        {
            NewVariableValuePrivate(groupe, NewVariable, Convert.ToString(NewValue));
        }
        /// <summary>
        /// Cette m�thode permet de cr�er une nouvelle variable et une nouvelle valeur 
        /// � partir d'un groupe
        /// </summary>
        /// <param name="groupe">Nom du groupe � chercher</param>
        /// <param name="NewVariable">Nom de la nouvelle variable</param>
        /// <param name="NewValue">Nom de la nouvelle valeur sous forme Decimal</param>
        public void NewVariableValue(string groupe, string NewVariable, decimal NewValue)
        {
            NewVariableValuePrivate(groupe, NewVariable, Convert.ToString(NewValue));
        }
        /// <summary>
        /// Cette m�thode permet de cr�er une nouvelle variable et une nouvelle valeur 
        /// � partir d'un groupe
        /// </summary>
        /// <param name="groupe">Nom du groupe � chercher</param>
        /// <param name="NewVariable">Nom de la nouvelle variable</param>
        /// <param name="NewValue">Nom de la nouvelle valeur sous forme Double</param>
        public void NewVariableValue(string groupe, string NewVariable, double NewValue)
        {
            NewVariableValuePrivate(groupe, NewVariable, Convert.ToString(NewValue));
        }
        /// <summary>
        /// Cette m�thode permet de cr�er une nouvelle variable et une nouvelle valeur 
        /// � partir d'un groupe
        /// </summary>
        /// <param name="groupe">Nom du groupe � chercher</param>
        /// <param name="NewVariable">Nom de la nouvelle variable</param>
        /// <param name="NewValue">Nom de la nouvelle valeur sous forme Int16</param>
        public void NewVariableValue(string groupe, string NewVariable, short NewValue)
        {
            NewVariableValuePrivate(groupe, NewVariable, Convert.ToString(NewValue));
        }
        /// <summary>
        /// Cette m�thode permet de cr�er une nouvelle variable et une nouvelle valeur 
        /// � partir d'un groupe
        /// </summary>
        /// <param name="groupe">Nom du groupe � chercher</param>
        /// <param name="NewVariable">Nom de la nouvelle variable</param>
        /// <param name="NewValue">Nom de la nouvelle valeur sous forme Int32</param>
        public void NewVariableValue(string groupe, string NewVariable, int NewValue)
        {
            NewVariableValuePrivate(groupe, NewVariable, Convert.ToString(NewValue));
        }
        /// <summary>
        /// Cette m�thode permet de cr�er une nouvelle variable et une nouvelle valeur 
        /// � partir d'un groupe
        /// </summary>
        /// <param name="groupe">Nom du groupe � chercher</param>
        /// <param name="NewVariable">Nom de la nouvelle variable</param>
        /// <param name="NewValue">Nom de la nouvelle valeur sous forme Int64</param>
        public void NewVariableValue(string groupe, string NewVariable, long NewValue)
        {
            NewVariableValuePrivate(groupe, NewVariable, Convert.ToString(NewValue));
        }
        /// <summary>
        /// Cette m�thode permet de cr�er une nouvelle variable et une nouvelle valeur 
        /// � partir d'un groupe
        /// </summary>
        /// <param name="groupe">Nom du groupe � chercher</param>
        /// <param name="NewVariable">Nom de la nouvelle variable</param>
        /// <param name="NewValue">Nom de la nouvelle valeur sous forme SByte</param>
        public void NewVariableValue(string groupe, string NewVariable, sbyte NewValue)
        {
            NewVariableValuePrivate(groupe, NewVariable, Convert.ToString(NewValue));
        }
        /// <summary>
        /// Cette m�thode permet de cr�er une nouvelle variable et une nouvelle valeur 
        /// � partir d'un groupe
        /// </summary>
        /// <param name="groupe">Nom du groupe � chercher</param>
        /// <param name="NewVariable">Nom de la nouvelle variable</param>
        /// <param name="NewValue">Nom de la nouvelle valeur sous forme Single</param>
        public void NewVariableValue(string groupe, string NewVariable, float NewValue)
        {
            NewVariableValuePrivate(groupe, NewVariable, Convert.ToString(NewValue));
        }
        /// <summary>
        /// Cette m�thode permet de cr�er une nouvelle variable et une nouvelle valeur 
        /// � partir d'un groupe
        /// </summary>
        /// <param name="groupe">Nom du groupe � chercher</param>
        /// <param name="NewVariable">Nom de la nouvelle variable</param>
        /// <param name="NewValue">Nom de la nouvelle valeur sous forme String</param>
        public void NewVariableValue(string groupe, string NewVariable, string NewValue)
        {
            NewVariableValuePrivate(groupe, NewVariable, NewValue);
        }
        /// <summary>
        /// Cette m�thode permet de cr�er une nouvelle variable et une nouvelle valeur 
        /// � partir d'un groupe
        /// </summary>
        /// <param name="groupe">Nom du groupe � chercher</param>
        /// <param name="NewVariable">Nom de la nouvelle variable</param>
        /// <param name="NewValue">Nom de la nouvelle valeur sous forme UInt16</param>
        public void NewVariableValue(string groupe, string NewVariable, ushort NewValue)
        {
            NewVariableValuePrivate(groupe, NewVariable, Convert.ToString(NewValue));
        }
        /// <summary>
        /// Cette m�thode permet de cr�er une nouvelle variable et une nouvelle valeur 
        /// � partir d'un groupe
        /// </summary>
        /// <param name="groupe">Nom du groupe � chercher</param>
        /// <param name="NewVariable">Nom de la nouvelle variable</param>
        /// <param name="NewValue">Nom de la nouvelle valeur sous forme UInt32</param>
        public void NewVariableValue(string groupe, string NewVariable, uint NewValue)
        {
            NewVariableValuePrivate(groupe, NewVariable, Convert.ToString(NewValue));
        }
        /// <summary>
        /// Cette m�thode permet de cr�er une nouvelle variable et une nouvelle valeur 
        /// � partir d'un groupe
        /// </summary>
        /// <param name="groupe">Nom du groupe � chercher</param>
        /// <param name="NewVariable">Nom de la nouvelle variable</param>
        /// <param name="NewValue">Nom de la nouvelle valeur sous forme UInt64</param>
        public void NewVariableValue(string groupe, string NewVariable, ulong NewValue)
        {
            NewVariableValuePrivate(groupe, NewVariable, Convert.ToString(NewValue));
        }
        #endregion

        #region " M�thodes - LoadFile "
        /// <summary>
        /// Permet de charger tout le contenu d'un fichier INI
        /// </summary>
        /// <returns>Retourne le contenu du fichier INI</returns>
        public string LoadFile()
        {
            string retour = null;

            // On v�rifie que le fichier existe
            if (File.Exists(Fichier))
            {
                // Cr�ation d'une nouvelle instance StreamReader
                StreamReader sr = new StreamReader(Fichier, Encodage);
                // On met le contenu du fichier dans une variable
                retour = sr.ReadToEnd();
                // On ferme le fichier
                sr.Close();
            }
            return retour;
        }
        /// <summary>
        /// Permet de charger tout le contenu d'un fichier INI
        /// </summary>
        /// <param name="fileOpen">Chemin complet et nom du fichier INI avec son extension � ouvrir</param>
        /// <returns>Retourne le contenu du fichier INI</returns>
        public string LoadFile(string fileOpen)
        {
            string retour = null;
            Fichier = fileOpen;
            // Cr�ation d'une nouvelle instance FileInfo
            FileInfo fi = new FileInfo(Fichier);

            // On v�rifie que le fichier existe
            if (fi.Exists)
            {
                // Cr�ation d'une nouvelle instance StreamReader
                StreamReader sr = new StreamReader(Fichier, Encodage);
                // On met le contenu du fichier dans une variable
                retour = sr.ReadToEnd();
                // On ferme le fichier
                sr.Close();
            }
            return retour;
        }
        /// <summary>
        /// Permet de charger tout le contenu d'un fichier INI
        /// </summary>
        /// <param name="fileOpen">Chemin complet et nom du fichier INI avec son extension � ouvrir</param>
        /// <param name="fileEncoding">Type d'encodage du fichier. La valeur par d�faut est "ASCIIEncoding.Default"</param>
        /// <returns>Retourne le contenu du fichier INI</returns>
        public string LoadFile(string fileOpen, Encoding fileEncoding)
        {
            string retour = null;
            Fichier = fileOpen;
            Encodage = fileEncoding;
            // Cr�ation d'une nouvelle instance FileInfo
            FileInfo fi = new FileInfo(Fichier);

            // On v�rifie que le fichier existe
            if (fi.Exists)
            {
                // Cr�ation d'une nouvelle instance StreamReader
                StreamReader sr = new StreamReader(Fichier, Encodage);
                // On met le contenu du fichier dans une variable
                retour = sr.ReadToEnd();
                // On ferme le fichier
                sr.Close();
            }
            return retour;
        }
        #endregion

        #region " M�thodes - SaveFile "
        /// <summary>
        /// Cette m�thode permet de sauvegarder un contenu INI dans un fichier
        /// </summary>
        /// <param name="ContenuINI">Texte INI � enregistrer dans un fichier</param>
        public void SaveFile(string ContenuINI)
        {
            // Cr�ation d'une instance StreamWriter
            StreamWriter sw = new StreamWriter(Fichier, false, Encodage);
            // On modifie le fichier
            sw.Write(ContenuINI);
            // On ferme le fichier
            sw.Close();
        }
        /// <summary>
        /// Cette m�thode permet de sauvegarder un contenu INI dans un fichier
        /// </summary>
        /// <param name="ContenuINI">Texte INI � enregistrer dans un fichier</param>
        /// <param name="fileOpen">Chemin complet et nom du fichier INI avec son extension � ouvrir</param>
        public void SaveFile(string ContenuINI, string fileOpen)
        {
            Fichier = fileOpen;
            // Cr�ation d'une instance StreamWriter
            StreamWriter sw = new StreamWriter(Fichier, false, Encodage);
            // On modifie le fichier
            sw.Write(ContenuINI);
            // On ferme le fichier
            sw.Close();
        }
        /// <summary>
        /// Cette m�thode permet de sauvegarder un contenu INI dans un fichier
        /// </summary>
        /// <param name="ContenuINI">Texte INI � enregistrer dans un fichier</param>
        /// <param name="fileEncod">Type d'encodage du fichier. La valeur par d�faut est "ASCIIEncoding.Default"</param>
        public void SaveFile(string ContenuINI, Encoding fileEncod)
        {
            Encodage = fileEncod;
            // Cr�ation d'une instance StreamWriter
            StreamWriter sw = new StreamWriter(Fichier, false, Encodage);
            // On modifie le fichier
            sw.Write(ContenuINI);
            // On ferme le fichier
            sw.Close();
        }
        /// <summary>
        /// Cette m�thode permet de sauvegarder un contenu INI dans un fichier
        /// </summary>
        /// <param name="ContenuINI">Texte INI � enregistrer dans un fichier</param>
        /// <param name="fileOpen">Chemin complet et nom du fichier INI avec son extension � ouvrir</param>
        /// <param name="fileEncod">Type d'encodage du fichier. La valeur par d�faut est "ASCIIEncoding.Default"</param>
        public void SaveFile(string ContenuINI, string fileOpen, Encoding fileEncod)
        {
            Fichier = fileOpen;
            Encodage = fileEncod;
            // Cr�ation d'une instance StreamWriter
            StreamWriter sw = new StreamWriter(Fichier, false, Encodage);
            // On modifie le fichier
            sw.Write(ContenuINI);
            // On ferme le fichier
            sw.Close();
        }
        #endregion

        #region " M�thodes - DelVariable "
        /// <summary>
        /// Cette m�thode vous permet de supprimer une variable ainsi que sa valeur
        /// � partir d'un groupe
        /// </summary>
        /// <param name="MonGroupe">Nom du groupe � chercher</param>
        /// <param name="MaVariable">Variable � supprimer</param>
        private void DelVariablePrivate(string MonGroupe, string MaVariable)
        {
            // V�rifie si le fichier existe
            if (File.Exists(Fichier))
            {
                // Cr�ation d'une instance StreamReader
                StreamReader sr = new StreamReader(Fichier, Encodage);
                // On met le contenu du fichier dans une variable
                string s = sr.ReadToEnd();
                // On ferme le fichier
                sr.Close();

                try
                {
                    // On r�cup�re la position du groupe demand�
                    int g = s.IndexOf("[" + MonGroupe + "]");
                    // On r�cup�re la position de la variable demand�e � partie de la
                    // position du groupe demand�
                    int v = s.IndexOf(MaVariable, g);
                    // On r�cup�re la position de fin de la valeur
                    int end = s.IndexOf("\r\n", v); 
                    // On supprime la variable et sa valeur
                    s = s.Remove(v, end - v);
                    s = s.Remove(v, 2);
                    
                    // Cr�ation d'une instance StreamWriter
                    StreamWriter sw = new StreamWriter(Fichier, false, Encodage);
                    // On modifie le fichier
                    sw.Write(s);
                    // On ferme le fichier
                    sw.Close();
                }
                catch
                {
                    sr.Close();
                }
            }
        }
        /// <summary>
        /// Cette m�thode vous permet de supprimer une variable ainsi que sa valeur
        /// � partir d'un groupe
        /// </summary>
        /// <param name="groupe">Nom du groupe � chercher</param>
        /// <param name="variable">Variable � supprimer</param>
        public void DelVariable(string groupe, string variable) 
        {
            DelVariablePrivate(groupe, variable);
        }
        /// <summary>
        /// Cette m�thode vous permet de supprimer une variable ainsi que sa valeur
        /// � partir d'un groupe
        /// </summary>
        /// <param name="variable">Variable � supprimer</param>
        public void DelVariable(string variable)
        {
            DelVariablePrivate(Groupe, variable);
        }
        /// <summary>
        /// Cette m�thode vous permet de supprimer une variable ainsi que sa valeur
        /// � partir d'un groupe
        /// </summary>
        /// <param name="fileOpen">Chemin complet et nom du fichier avec son extension � ouvrir</param>
        /// <param name="groupe">Nom du groupe � chercher</param>
        /// <param name="variable">Variable � supprimer</param>
        public void DelVariable(string fileOpen, string groupe, string variable)
        {
            Fichier = fileOpen;
            DelVariablePrivate(groupe, variable);
        }

        /// <summary>
        /// Cette m�thode vous permet de supprimer une variable ainsi que sa valeur
        /// � partir d'un groupe
        /// </summary> 
        /// <param name="groupe">Nom du groupe � chercher</param>
        /// <param name="variable">Variable � supprimer</param>
        /// <param name="encod">Type d'encodage � utiliser dans le fichier. La valeur par d�faut est "ASCIIEncoding.Default"</param>
        public void DelVariable(string groupe, string variable, Encoding encod)
        {
            Encodage = encod;
            DelVariablePrivate(groupe, variable);
        }
        /// <summary>
        /// Cette m�thode vous permet de supprimer une variable ainsi que sa valeur
        /// � partir d'un groupe
        /// </summary>
        /// <param name="fileOpen">Chemin complet et nom du fichier avec son extension � ouvrir</param>
        /// <param name="groupe">Nom du groupe � chercher</param>
        /// <param name="variable">Variable � supprimer</param>
        /// <param name="encod">Type d'encodage � utiliser dans le fichier. La valeur par d�faut est "ASCIIEncoding.Default"</param>
        public void DelVariable(string fileOpen, string groupe, string variable, Encoding encod)
        {
            Fichier = fileOpen;
            Encodage = encod;
            DelVariablePrivate(groupe, variable);
        }
        #endregion

        #region " M�thodes - DelGroup "
        /// <summary>
        /// Cette m�thode permet de supprimer un groupe du fichier INI ainsi que toutes
        /// les variables et les valeurs du groupe
        /// </summary>
        /// <param name="MonGroupe">Nom du groupe � chercher</param>
        private void DelGroupPrivate(string MonGroupe)
        {
            // V�rifie si le fichier existe
            if (File.Exists(Fichier))
            {
                // Cr�ation d'une instance StreamReader
                StreamReader sr = new StreamReader(Fichier, Encodage);
                // On met le contenu du fichier dans une variable
                string s = sr.ReadToEnd();
                // On ferme le fichier
                sr.Close();

                try
                {
                    // On r�cup�re la position du groupe demand�
                    int g = s.IndexOf("[" + MonGroupe + "]");
                    // On r�cup�re la position du prochain groupe
                    int n = s.IndexOf("[", g);
                    // On supprime le groupe et toutes les variables et valeurs de se groupe
                    s = s.Remove(g, n);

                    // Cr�ation d'une instance StreamWriter
                    StreamWriter sw = new StreamWriter(Fichier, false, Encodage);
                    // On modifie le fichier
                    sw.Write(s);
                    // On ferme le fichier
                    sw.Close();
                }
                catch
                {
                    sr.Close();
                }
            }
        }
        /// <summary>
        /// Cette m�thode permet de supprimer un groupe du fichier INI ainsi que toutes
        /// les variables et les valeurs du groupe
        /// </summary>
        /// <param name="fileOpen">Chemin complet et nom du fichier avec son extension � ouvrir</param>
        /// <param name="groupe">Nom du groupe � chercher</param>
        /// <param name="encod">Type d'encodage � utiliser dans le fichier. La valeur par d�faut est "ASCIIEncoding.Default"</param>
        public void DelGroup(string fileOpen, string groupe, Encoding encod)
        {
            Fichier = fileOpen;
            Encodage = encod;
            DelGroupPrivate(groupe);
        }
        /// <summary>
        /// Cette m�thode permet de supprimer un groupe du fichier INI ainsi que toutes
        /// les variables et les valeurs du groupe
        /// </summary>
        /// <param name="groupe">Nom du groupe � chercher</param>
        /// <param name="encod">Type d'encodage � utiliser dans le fichier. La valeur par d�faut est "ASCIIEncoding.Default"</param>
        public void DelGroup(string groupe, Encoding encod)
        {
            Encodage = encod;
            DelGroupPrivate(groupe);
        }
        /// <summary>
        /// Cette m�thode permet de supprimer un groupe du fichier INI ainsi que toutes
        /// les variables et les valeurs du groupe
        /// </summary>
        /// <param name="fileOpen">Chemin complet et nom du fichier avec son extension � ouvrir</param>
        /// <param name="groupe">Nom du groupe � chercher</param>
        public void DelGroup(string fileOpen, string groupe)
        {
            Fichier = fileOpen;
            DelGroupPrivate(groupe);
        }
        /// <summary>
        /// Cette m�thode permet de supprimer un groupe du fichier INI ainsi que toutes
        /// les variables et les valeurs du groupe
        /// </summary>
        /// <param name="groupe">Nom du groupe � chercher</param>
        public void DelGroup(string groupe)
        {
            DelGroupPrivate(groupe);
        }
        /// <summary>
        /// Cette m�thode permet de supprimer un groupe du fichier INI ainsi que toutes
        /// les variables et les valeurs du groupe
        /// </summary>
        public void DelGroup()
        {
            DelGroupPrivate(Groupe);
        }
        #endregion

        #region " M�thodes li�es a la langue du l'application "

        public string pvgLireDansUnFichierINI(string vppFichier, string vppEnteteGroupe, string vppVariable)
        {
            /// Extraction d'une valeur
            clsFileINI ini = new clsFileINI(vppFichier);
            // On r�cup�re le nom du groupe � chercher
            ini.Groupe = vppEnteteGroupe;
            // On r�cup�re la valeur de la variable
            return ini.GetValueString(vppVariable);
        }

        public void pvgInitialisationDeLaLangue(Form vppFeuille)
        {
            Stock.TOOLS.clsDeclaration.vagParametres.LangueParDefaut = "lang.ini";
            //-1-Chargement du fichier de langue
            string vppFichierLangue = Application.StartupPath + "\\Langues\\" + Stock.TOOLS.clsDeclaration.vagParametres.LangueParDefaut;
            string vlpChaine;
            string vlpLangue = clsChaineCaractere.ClasseChaineCaractere.pvgExtraireChaine(vppFichierLangue, "\\", "D");
            //-2-Chargement de la langue
            vlpLangue = clsChaineCaractere.ClasseChaineCaractere.pvgExtraireChaine(vlpLangue, ".", "G");

            //-3-Changement du libell� de l'�cran par son �quivalent 
            vlpChaine = pvgLireDansUnFichierINI(vppFichierLangue, vppFeuille.Name, vppFeuille.Name);
            if (vlpChaine != null && vlpChaine != "") vppFeuille.Text = vlpChaine;
            foreach (Control vlpControlPere in vppFeuille.Controls)
            {
                vlpControlPere.Text = pvgLireDansUnFichierINI(vppFichierLangue, vppFeuille.Name, vlpControlPere.Name);
                foreach (Control vlpObjetControlFils in vlpControlPere.Controls)
                {
                    //-3-Pour chaque composant plac� sur l'ecran nous allons changer le libell� par son �quivalent qui se trouve dans le fichier de langue
                    vlpChaine = pvgLireDansUnFichierINI(vppFichierLangue, vppFeuille.Name, vlpObjetControlFils.Name);
                    if (vlpChaine != null && vlpChaine != "") vlpObjetControlFils.Text = vlpChaine;
                }

                if (vlpControlPere.GetType() == typeof(ToolStrip))
                {
                    ToolStrip vlpControlToolStrip;
                    vlpControlToolStrip = (ToolStrip)vlpControlPere;
                    for (int vlpIndex = 0; vlpIndex < vlpControlToolStrip.Items.Count; vlpIndex++)
                    {
                        if (vlpControlToolStrip.Items[vlpIndex].GetType() == typeof(ToolStripButton))
                        {
                            vlpChaine = pvgLireDansUnFichierINI(vppFichierLangue, vppFeuille.Name, vlpControlToolStrip.Items[vlpIndex].Name);
                            if (vlpChaine != null && vlpChaine != "") vlpControlToolStrip.Items[vlpIndex].Text = vlpChaine;
                        }
                    }
                }
            }
        }




        public static void ApplyCulture(Form form, CultureInfo culture)
        {
            // Create a resource manager for this Form and determine its fields via reflection.
            ComponentResourceManager resources = new ComponentResourceManager(form.GetType());
            FieldInfo[] fieldInfos = form.GetType().GetFields(BindingFlags.Instance |
                BindingFlags.DeclaredOnly | BindingFlags.NonPublic);

            // Call SuspendLayout for Form and all fields derived from Control, so assignment of 
            //   localized text doesn't change layout immediately.
            form.SuspendLayout();
            for (int index = 0; index < fieldInfos.Length; index++)
            {
                if (fieldInfos[index].FieldType.IsSubclassOf(typeof(Control)))
                {
                    fieldInfos[index].FieldType.InvokeMember("SuspendLayout",
                        BindingFlags.InvokeMethod, null,
                        fieldInfos[index].GetValue(form), null);
                }
            }

            // If available, assign localized text to Form and fields with Text property.
            // If available, assign localized Localtion and Size to fields
            System.Drawing.Point point;
            System.Drawing.Size size;
            string vlpTest1 = "$this.Text";
            String text = resources.GetString(form.Name);
            if (text != null)
                form.Text = text;
            for (int index = 0; index < fieldInfos.Length; index++)
            {
                if (fieldInfos[index].FieldType.GetProperty("Text", typeof(String)) != null)
                {
                    string vlpTest = fieldInfos[index].Name + ".Text";
                    text = resources.GetString(vlpTest);
                    if (text != null)
                    {
                        fieldInfos[index].FieldType.InvokeMember("Text",
                            BindingFlags.SetProperty, null,
                            fieldInfos[index].GetValue(form), new object[] { text });
                    }
                }
                //if (fieldInfos[index].FieldType.GetProperty("Location", typeof(System.Drawing.Point)) != null)
                //{
                //    point = (System.Drawing.Point)resources.GetObject(fieldInfos[index].Name + ".Location");
                //    if (point != null)
                //    {
                //        fieldInfos[index].FieldType.InvokeMember("Location",
                //            BindingFlags.SetProperty, null,
                //            fieldInfos[index].GetValue(form), new object[] { point });
                //    }
                //}
                //if (fieldInfos[index].FieldType.GetProperty("Size", typeof(System.Drawing.Size)) != null)
                //{
                //    size = (System.Drawing.Size)resources.GetObject(fieldInfos[index].Name + ".Size");
                //    if (size != null)
                //    {
                //        fieldInfos[index].FieldType.InvokeMember("Size",
                //            BindingFlags.SetProperty, null,
                //            fieldInfos[index].GetValue(form), new object[] { size });
                //    }
                //}
            }

            // Call ResumeLayout for Form and all fields derived from Control to resume layout logic.
            // Call PerformLayout, so layout changes due to assignment of localized text are performed.
            for (int index = 0; index < fieldInfos.Length; index++)
            {
                if (fieldInfos[index].FieldType.IsSubclassOf(typeof(Control)))
                {
                    fieldInfos[index].FieldType.InvokeMember("ResumeLayout",
                            BindingFlags.InvokeMethod, null,
                            fieldInfos[index].GetValue(form), new object[] { true });
                }
            }
            form.ResumeLayout(false);
            form.PerformLayout();
        }



        #endregion
    }
}
