using System;
using System.Security;
using System.Security.Permissions;
using System.IO;
using System.Xml;

#region CopyRight & Co
//*********************************************************************************
//**  File: ConfigFile.cs
//**  Name: Utilitaires.ConfigFile
//**  Desc: Classe permettant la manipulation de fichiers de configuration Xml (style app.config)
//**
//**
//**  Auth: Mouchi Eboule Eric
//**  Date: 20/10/2005
//*********************************************************************************
//**  Change History
//*********************************************************************************
//**  Date:       Author:          Description:
//**  ----------  --------------   -------------------------------------------
//**  02/08/2005  Mouchi Eboule Eric  Création de la classe
//**  19/09/2005  Mouchi Eboule Eric  Modification pour créer le fichier de config s'il n'existe pas
//**  20/09/2005  Mouchi Eboule Eric  Création de rubrique automatique si elle n'éxiste pas.
//**  20/10/2005  Mouchi Eboule Eric  Récupération possible de la liste des parametres d'un rubrique.
//**  28/11/2005  Mouchi Eboule Eric  Ajout des procédures de suppressino de parametre et de rubrique.
//**  28/03/2006  Mouchi Eboule Eric  Ajout des demandes d'autorisation sur les fichiers.
//**  09/08/2006  Mouchi Eboule Eric  Ajout du choix de l'encoding lors de la création.
//**  29/09/2006  Mouchi Eboule Eric  Ajout de la liste des rubriques.
//**
//*********************************************************************************
#endregion

namespace Stock.TOOLS
{
	/// <summary>Classe permettant la manipulation de fichiers de configuration Xml (style app.config)</summary>
	/// <author>Mouchi Eboule Eric</author>
	/// <history>
	/// <change date="02/08/2005" author="Mouchi Eboule Eric">Création de la classe.</change>
	/// <change date="19/09/2005" author="Mouchi Eboule Eric">Modification pour créer le fichier de config s'il n'existe pas.</change>
	/// <change date="20/09/2005" author="Mouchi Eboule Eric">Création de rubrique automatique si elle n'éxiste pas.</change>
	/// <change date="20/10/2005" author="Mouchi Eboule Eric">Récupération possible de la liste des parametres d'un rubrique.</change>
	/// <change date="28/11/2005" author="Mouchi Eboule Eric">Ajout des procédures de suppression de parametre et de rubrique.</change>
	/// <change date="28/03/2006" author="Mouchi Eboule Eric">Ajout des demandes d'autorisation sur les fichiers.</change>
	/// <change date="09/08/2006" author="Mouchi Eboule Eric">Ajout du choix de l'encoding lors de la création.</change>
	/// <change date="29/09/2006" author="Mouchi Eboule Eric">Ajout de la liste des rubriques.</change>
	/// </history>
	public sealed class clsConfigFile
	{
		#region Variables / Structures / Enums
		private XmlDocument _xdoc;
		private bool _fileopened;
		private string _filename;
		
		/// <summary>Parametre enregistré.</summary>
		/// <author>Mouchi Eboule Eric</author>
		/// <history>
		/// <change date="20/10/2005" author="Mouchi Eboule Eric">Création.</change>
		/// </history>
		public struct Parametre {
			/// <summary>Nom du parametre.</summary>
			public string Key;
			/// <summary>Valeur du parametre.</summary>
			public string Value;
		}
		#endregion
		
		#region Constructeur
		/// <summary>Constructeur de la classe</summary>
		/// <param name="Fichier">Chemin complet du fichier de configuration</param>
		/// <param name="Encode">Nom de l'encoding utilisé (par defaut : iso-8859-15)</param>
		/// <author>Mouchi Eboule Eric</author>
		/// <history>
		/// <change date="02/08/2005" author="Mouchi Eboule Eric">Création de la méthode.</change>
		/// <change date="19/09/2005" author="Mouchi Eboule Eric">Modification pour créer le fichier s'il n'existe pas.</change>
		/// <change date="28/03/2006" author="Mouchi Eboule Eric">Ajout des demandes d'autorisation sur les fichiers.</change>
		/// <change date="09/08/2006" author="Villard Grégory">Ajout du parametre d'encoding.</change>
		/// </history>
		public clsConfigFile(string Fichier) {
			NewConfigFile(Fichier, "iso-8859-15");
		}
		
		public clsConfigFile(string Fichier, string Encode) {
			NewConfigFile(Fichier, Encode);
		}
		
		private void NewConfigFile(string Fichier, string Encode) {
			if(!CanReadFile(Fichier)) throw new SecurityException("Impossible de lire le fichier.");
			if (File.Exists(Fichier)) {
				this.Open(Fichier);
			} else {
				FileStream FS;
				StreamWriter SW;
				try {
					FS = new FileStream(Fichier, FileMode.OpenOrCreate);
					SW = new StreamWriter(FS);
					SW.WriteLine("<?xml version=\"1.0\" encoding=\"" + Encode + "\" ?>");
					SW.WriteLine("<configuration>");
					SW.WriteLine("  <appSettings>");
					SW.WriteLine("  </appSettings>");
					SW.WriteLine("</configuration>");
					SW.Close();
					SW = null;
					FS.Close();
					FS = null;
					this.Open(Fichier);
				} catch {
					this.Fin();
					throw new Exception("Erreur Initialisation");
				}
			}
		}
		#endregion

		#region Destructeur
		/// <summary>Destructeur de la classe</summary>
		/// <author>Mouchi Eboule Eric</author>
		/// <history>
		/// <change date="02/08/2005" author="Mouchi Eboule Eric">Création de la méthode.</change>
		/// </history>
		private void Fin()
		{
			_xdoc = null;
		}
		#endregion
		
		#region Procédure de demande de lecture
		/// <summary>Cette fonction demande une autorisation d'ecriture sur le fichier de config</summary>
		/// <param name="file">Fichier à lire</param>
		/// <returns>Un bool comme résultat de la demande</returns>
		/// <author>Mouchi Eboule Eric</author>
		/// <history>
		/// <change date="28/03/2006" author="Mouchi Eboule Eric">Création de la méthode.</change>
		/// </history>
		private bool CanReadFile(string file) {
			FileIOPermission perm = new FileIOPermission(FileIOPermissionAccess.Read, file);
			try { perm.Demand(); }
			catch(SecurityException) {
				return false;
			}
			return true;
		}
		#endregion
		
		#region Procédure de demande d'ecriture
		/// <summary>Cette fonction demande une autorisation d'ecriture sur le fichier de config</summary>
		/// <param name="file">Fichier à modifier</param>
		/// <returns>Un bool comme résultat de la demande</returns>
		/// <author>Mouchi Eboule Eric</author>
		/// <history>
		/// <change date="28/03/2006" author="Mouchi Eboule Eric">Création de la méthode.</change>
		/// </history>
		private bool CanWriteFile(string file) {
			FileIOPermission perm = new FileIOPermission(FileIOPermissionAccess.Write, file);
			try { perm.Demand(); }
			catch(SecurityException) {
				return false;
			}
			return true;
		}
		#endregion
		
		#region Procédure de fermeture du fichier de config
		/// <summary>Cette fonction permet de fermer un fichier de configuration ouvert</summary>
		/// <author>Mouchi Eboule Eric</author>
		/// <history>
		/// <change date="02/08/2005" author="Mouchi Eboule Eric">Création de la méthode.</change>
		/// </history>
		public void Close()
		{
			_fileopened = false;
			_xdoc = null;
			_filename = "";
		}
		#endregion
		
		#region Procédure d'ouverture du fichier de config
		/// <summary>Cette fonction permet d'ouvrir un fichier de configuration</summary>
		/// <param name="Fichier">Fichier à ouvrir</param>
		/// <author>Mouchi Eboule Eric</author>
		/// <history>
		/// <change date="02/08/2005" author="Mouchi Eboule Eric">Création de la méthode.</change>
		/// <change date="19/09/2005" author="Mouchi Eboule Eric">Modification pour créer le fichier s'il n'existe pas.</change>
		/// </history>
		public void Open(string Fichier) {
			_filename = Fichier;
			this.Open();
		}
		
		private void Open()
		{
			FileStream FS;
			StreamWriter SW;
			// Si le fichier n'existe pas on le créé
			if (!(File.Exists(_filename))) {
				
				try {
					FS = new FileStream(_filename, FileMode.OpenOrCreate);
					SW = new StreamWriter(FS);
					SW.WriteLine("<?xml version=\"1.0\" encoding=\"iso-8859-15\" ?>");
					SW.WriteLine("<configuration>");
					SW.WriteLine("  <appSettings>");
					SW.WriteLine("  </appSettings>");
					SW.WriteLine("</configuration>");
					SW.Close();
					SW = null;
					FS.Close();
					FS = null;
				} catch (Exception e) {
					_filename = "";
					throw new ConfigFileException(_filename, "Impossible de créer le fichier de config lors de la demande d'ouverture.", e.Message);
				}
			}
			
			if (_fileopened) {
				throw new ConfigFileException(_filename, "Un fichier est deja ouvert.", "");
			} else {
				// Demande de lecture du fichier
				if(!CanReadFile(_filename)) throw new SecurityException("Impossible de lire le fichier.");
				try {
					_xdoc = new XmlDocument();
					_xdoc.Load(_filename);
				} catch (System.Exception e) {
					throw new Exception(e.Message);
				}
				_fileopened = true;
			}
		}
		#endregion
		
		#region Procédure de création d'une nouvelle rubrique
		/// <summary>Cette fonction permet de créer une rubrique</summary>
		/// <param name="Rubrique">Rubrique à créer</param>
		/// <author>Mouchi Eboule Eric</author>
		/// <history>
		/// <change date="20/09/2005" author="Mouchi Eboule Eric">Création de la méthode.</change>
		/// </history>
		public void CreerRubrique(string Rubrique) {
			CreateNode(Rubrique);
		}
		
		private void CreateNode(string Rubrique)
		{
			XmlNode xn;
			XmlNode cXmlRoot;
			try {
				xn = _xdoc.DocumentElement.SelectSingleNode("/configuration/" + Rubrique);
				if (xn == null) {
					cXmlRoot = _xdoc.DocumentElement.SelectSingleNode("/configuration");
					xn = _xdoc.CreateNode(XmlNodeType.Element, Rubrique, "");
					cXmlRoot.AppendChild(xn);
				}
				_xdoc.Save(_filename);
			} catch(Exception e) {
				throw new ConfigFileException(_filename, "Impossible de créer la rubrique " + Rubrique + ".", e.Message);
			}
		}
		#endregion
		
		#region Procédure d'ecriture de parametres
		/// <summary>Cette fonction permet d'ecrire une valeur dans une clé</summary>
		/// <param name="Valeur">Valeur à ecrire</param>
		/// <param name="Key">Clé à modifier</param>
		/// <param name="Rubrique">Rubrique du fichier de config (par défaut : appSettings)</param>
		/// <author>Mouchi Eboule Eric</author>
		/// <history>
		/// <change date="02/08/2005" author="Mouchi Eboule Eric">Création de la méthode.</change>
		/// <change date="20/09/2005" author="Mouchi Eboule Eric">Ajout de la création de rubrique.</change>
		/// </history>
		public void SaveParam(string Valeur, string Key)
		{
			SaveParam(Valeur, Key, "appSettings");
		}
		
		public void SaveParam(string Valeur, string Key, string Rubrique)
		{
			// Demande d'ecriture du fichier
			if(!CanWriteFile(_filename)) throw new SecurityException("Impossible d'ecrire dans le fichier.");
			
			XmlNode xn;
			XmlNode cXmlRoot;
			XmlNode cXmlKey;
			XmlNode cXmlValue;
			if (!(_fileopened)) {
				throw new ConfigFileException("", "Aucun fichier ouvert.", "");
			}
			xn = _xdoc.DocumentElement.SelectSingleNode("/configuration/" + Rubrique);
			if (xn == null) {
				this.CreateNode(Rubrique);
			}
			xn = _xdoc.DocumentElement.SelectSingleNode("/configuration/" + Rubrique + "/add[@key=\"" + Key + "\"]");
			if (xn == null) {
				xn = _xdoc.CreateNode(XmlNodeType.Element, "add", "");
				cXmlKey = _xdoc.CreateNode(XmlNodeType.Attribute, "key", "");
				cXmlKey.Value = Key;
				xn.Attributes.SetNamedItem(cXmlKey);
				cXmlValue = _xdoc.CreateNode(XmlNodeType.Attribute, "value", "");
				cXmlValue.Value = Valeur;
				xn.Attributes.SetNamedItem(cXmlValue);
				cXmlRoot = _xdoc.DocumentElement.SelectSingleNode("/configuration/" + Rubrique);
				if (!(cXmlRoot == null)) {
					cXmlRoot.AppendChild(xn);
				} else {
					throw new ConfigFileException(_filename, "Impossible de sauver le parametre " + Rubrique + "\\" + Key + ".", "");
				}
			} else {
				xn.Attributes.GetNamedItem("value").Value = Valeur;
			}
			try {
				_xdoc.Save(_filename);
			} catch(Exception e) {
				throw new ConfigFileException(_filename, "Impossible de sauver le parametre " + Rubrique + "\\" + Key + ".", e.Message);
			}
		}
		#endregion
		
		#region Procédure de lecture de parametres
		/// <summary>Cette fonction permet de lire la valeur d'une clé</summary>
		/// <param name="Key">Clé à lire</param>
		/// <param name="Rubrique">Rubrique du fichier de config (par défaut : appSettings)</param>
		/// <returns>Une String comme valeur lue dans la clé</returns>
		/// <author>Mouchi Eboule Eric</author>
		/// <history>
		/// <change date="02/08/2005" author="Mouchi Eboule Eric">Création de la méthode.</change>
		/// <change date="20/09/2005" author="Mouchi Eboule Eric">Ajout de la création de rubrique.</change>
		/// </history>
		public string ReadParam(string Key)
		{
			return ReadParam(Key, "appSettings");
		}
		public string ReadParam(string Key, string Rubrique)
		{
			// Demande de lecture du fichier
			if(!CanReadFile(_filename)) throw new SecurityException("Impossible de lire le fichier.");
			
			XmlNode xn;
			if (!(_fileopened)) {
				throw new ConfigFileException("", "Aucun fichier ouvert.", "");
			}
			
			xn = _xdoc.DocumentElement.SelectSingleNode("/configuration/" + Rubrique + "/add[@key=\"" + Key + "\"]");
			if (xn == null) {
				return string.Empty;
			} else {
				return xn.Attributes.GetNamedItem("value").Value;
			}
		}
		#endregion

		#region Liste des rubriques
		/// <summary>Cette fonction permet de recupérer la liste de toutes les rubriques</summary>
		/// <returns>Un array de string</returns>
		/// <author>Mouchi Eboule Eric</author>
		/// <history>
		/// <change date="29/09/2006" author="Mouchi Eboule Eric">Création de la méthode.</change>
		/// </history>
		public string[] Rubriques() {
			// Demande de lecture du fichier
			if(!CanReadFile(_filename)) throw new SecurityException("Impossible de lire le fichier.");
			
			// Listage des nodes correspondant aux rubriques
			XmlNodeList xnl = _xdoc.DocumentElement.SelectNodes("/configuration");
			string[] rst = new string[xnl[0].ChildNodes.Count];
			int i = 0;
			
			foreach(XmlNode xn in xnl[0].ChildNodes) {
				rst.SetValue(xn.LocalName, i);
				i++;
			}

			return rst;
		}
		#endregion
		
		#region Liste des Parametres
		/// <summary>Cette fonction permet de recupérer les nodes d'une rubrique donnée</summary>
		/// <param name="Rubrique">Rubrique du fichier de config (par défaut : appSettings)</param>
		/// <returns>Un array de Parametre</returns>
		/// <author>Mouchi Eboule Eric</author>
		/// <history>
		/// <change date="20/10/2005" author="Mouchi Eboule Eric">Création de la méthode.</change>
		/// <change date="28/03/2006" author="Mouchi Eboule Eric">Ajout des demandes d'autorisation sur les fichiers.</change>
		/// </history>
		public Parametre[] Parametres() {
			return Parametres("appSettings");
		}
		public Parametre[] Parametres(string Rubrique) {
			// Demande de lecture du fichier
			if(!CanReadFile(_filename)) throw new SecurityException("Impossible de lire le fichier.");
			
			XmlNode xn;
			XmlNodeList xnl;
			Parametre par;
			int i = 0;
			
			par.Key = "";
			par.Value = "";
			
			if (!_fileopened) {
				throw new ConfigFileException("", "Aucun fichier ouvert.", "");
			}
			
			xn = _xdoc.DocumentElement.SelectSingleNode("/configuration/" + Rubrique);
			
			if (xn == null) {
				// Erreur si node inexistant
				return null;
			}else{
				// Lecture de la valeur
				xnl = _xdoc.SelectNodes("/configuration/" + Rubrique + "/descendant::add");
				i = xnl.Count;
				Parametre[] lst = new Parametre[i];
				i = lst.GetLowerBound(0);
				foreach (XmlNode cN in xnl) {
					par.Key = cN.Attributes.GetNamedItem("key").Value;
					par.Value = cN.Attributes.GetNamedItem("value").Value;
					if ((par.Key == "") && (par.Value == "")) break;
					lst.SetValue(par, i);
					i = i + 1;
				}
				return lst;
			}
		}
		#endregion
		
		#region Procédure de suppression d'un parametre
		/// <summary>Cette fonction permet de supprimer un parametre</summary>
		/// <param name="Key">Clé à effacer</param>
		/// <param name="Rubrique">Rubrique du fichier de config (par défaut : appSettings)</param>
		/// <author>Mouchi Eboule Eric</author>
		/// <history>
		/// <change date="28/11/2005" author="Mouchi Eboule Eric">Création de la méthode.</change>
		/// <change date="28/03/2006" author="Mouchi Eboule Eric">Ajout des demandes d'autorisation sur les fichiers.</change>
		/// </history>
		public void DeleteParam(string Key) {
			DeleteParam(Key, "appSettings");
		}
		public void DeleteParam(string Key, string Rubrique) {
			// Demande d'ecriture du fichier
			if(!CanWriteFile(_filename)) throw new SecurityException("Impossible d'ecrire dans le fichier.");
			
			XmlNode xn, cRoot;
			if (!(_fileopened)) {
				throw new ConfigFileException("", "Aucun fichier ouvert.", "");
			}
			cRoot = _xdoc.DocumentElement.SelectSingleNode("/configuration/" + Rubrique);
			xn = _xdoc.DocumentElement.SelectSingleNode("/configuration/" + Rubrique + "/add[@key=\"" + Key + "\"]");
			if (xn == null) {
				// Si le parametre n'existe pas, ce n'est pas grave vu que l'on veux le supprimer ^^
				return;
			} else {
				cRoot.RemoveChild(xn);
				try {
					_xdoc.Save(_filename);
				} catch(Exception e) {
					throw new ConfigFileException(_filename, "Impossible de supprimer le parametre " + Rubrique + "\\" + Key + ".", e.Message);
				}
			}
		}
		#endregion
		
		#region Procédure de suppression d'une rubrique
		/// <summary>Cette fonction permet de supprimer une rubrique entière</summary>
		/// <param name="Rubrique">Rubrique du fichier de config (Sauf appSettings)</param>
		/// <author>Mouchi Eboule Eric</author>
		/// <history>
		/// <change date="28/11/2005" author="Mouchi Eboule Eric">Création de la méthode.</change>
		/// <change date="28/03/2006" author="Mouchi Eboule Eric">Ajout des demandes d'autorisation sur les fichiers.</change>
		/// </history>
		public void DeleteRubrique(string Rubrique) {
			// Demande d'ecriture du fichier
			if(!CanWriteFile(_filename)) throw new SecurityException("Impossible d'ecrire dans le fichier.");
			
			if(Rubrique == "appSettings") throw new Exception("Impossible de supprimer 'appSettings' !");
			XmlNode xn, cRoot;
			if (!(_fileopened)) {
				throw new ConfigFileException("", "Aucun fichier ouvert.", "");
			}
			xn = _xdoc.DocumentElement.SelectSingleNode("/configuration/" + Rubrique);
			cRoot = _xdoc.DocumentElement.SelectSingleNode("/configuration");
			if (xn == null) {
				// Si la rubrique n'existe pas, ce n'est pas grave vu que l'on veux la supprimer ^^
				return;
			} else {
				try {
					xn.RemoveAll();
					cRoot.RemoveChild(xn);
					_xdoc.Save(_filename);
				} catch (Exception e) {
					throw new ConfigFileException(_filename, "Impossible de supprimer la rubrique " + Rubrique + ".", e.Message);
				}
			}
		}
		#endregion
		
	}
	/// <summary>Exception utilisée par ConfigFile</summary>
	/// <author>Mouchi Eboule Eric</author>
	/// <history>
	/// <change date="02/08/2005" author="Mouchi Eboule Eric">Création de la classe.</change>
	/// </history>
	public class ConfigFileException : System.Exception {
		
		#region Variables
		private string _fichier = string.Empty;
		private string _message = string.Empty;
		private string _raison = string.Empty;
		#endregion
		
		#region Constructeur
		public ConfigFileException(string Fichier, string Raison, string MessageAdditionnel) {
			_raison = Raison;
			_message = MessageAdditionnel;
			_fichier = Fichier;
		}
		#endregion
		
		#region Propriétés
		public string Fichier {
			get {
				return this._fichier;
			}
		}
		
		public override string Message {
			get {
				return _raison + Environment.NewLine + Environment.NewLine + _message;
			}
		}
		#endregion
		
		#region ToString()
		public override string ToString() {
			return _raison + Environment.NewLine + Environment.NewLine + _message + Environment.NewLine + Environment.NewLine + base.ToString();
		}
		#endregion
		
	}

}
