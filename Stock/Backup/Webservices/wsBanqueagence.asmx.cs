using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Stock.WSTOOLS;
using Stock.WSBLL;
using Stock.BOJ;
using System.Web.Services;
using System.Web;


namespace Stock.WS
{

    [WebService(Namespace = "http://192.168.1.100:73/Webservices/wsBanqueagence.asmx")] 
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1) ] 
	[System.ComponentModel.ToolboxItem(false)] 
	// Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante.  
	// [System.Web.Script.Services.ScriptService] 
	public class wsBanqueagence : System.Web.Services.WebService, IAsmx<clsBanqueagence>
	{

        private clsDonnee _clsDonnee  = new clsDonnee(); 
		private clsBanqueagenceWSBLL clsBanqueagenceWSBLL  = new clsBanqueagenceWSBLL(); 
		private clsMessagesWSBLL clsMessagesWSBLL  = new  clsMessagesWSBLL();
		public clsDonnee clsDonnee 
		{ 
			get { return _clsDonnee; } 
			set { _clsDonnee= value; }
		} 

        
		[WebMethod(MessageName = "pvgValeurScalaireRequeteCount", Description = "pvgValeurScalaireRequeteCount", EnableSession = true)]
		public clsObjetRetour pvgValeurScalaireRequeteCount(clsObjetEnvoi clsObjetEnvoi)
		{
			clsObjetRetour clsObjetRetour = new clsObjetRetour();
			try
			{
				clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
				clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
				clsDonnee.pvgConnectionBase();
				clsObjetRetour.SetValue(true, clsBanqueagenceWSBLL.pvgValeurScalaireRequeteCount(clsDonnee, clsObjetEnvoi));
			}
			catch (SqlException SQLEx)
			{
				clsObjetRetour.SetValueMessage(false,SQLEx.Message);
			}
			finally 
			{
				clsDonnee.pvgDeConnectionBase();
			}
			return clsObjetRetour;
		}


        
		[WebMethod(MessageName = "pvgValeurScalaireRequeteMin", Description = "pvgValeurScalaireRequeteMin", EnableSession = true)]
		public clsObjetRetour pvgValeurScalaireRequeteMin(clsObjetEnvoi clsObjetEnvoi)
		{
			clsObjetRetour clsObjetRetour = new clsObjetRetour();
			try
			{
				clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
				clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
				clsDonnee.pvgConnectionBase();
				clsObjetRetour.SetValue(true, clsBanqueagenceWSBLL.pvgValeurScalaireRequeteMin(clsDonnee, clsObjetEnvoi));
			}
			catch (SqlException SQLEx)
			{
				clsObjetRetour.SetValueMessage(false,SQLEx.Message);
			}
			finally 
			{
				clsDonnee.pvgDeConnectionBase();
			}
			return clsObjetRetour;
		}


        
		[WebMethod(MessageName = "pvgValeurScalaireRequeteMax", Description = "pvgValeurScalaireRequeteMax", EnableSession = true)]
		public clsObjetRetour pvgValeurScalaireRequeteMax(clsObjetEnvoi clsObjetEnvoi)
		{
			clsObjetRetour clsObjetRetour = new clsObjetRetour();
			try
			{
				clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
				clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
				clsDonnee.pvgConnectionBase();
				clsObjetRetour.SetValue(true, clsBanqueagenceWSBLL.pvgValeurScalaireRequeteMax(clsDonnee, clsObjetEnvoi));
			}
			catch (SqlException SQLEx)
			{
				clsObjetRetour.SetValueMessage(false,SQLEx.Message);
			}
			finally 
			{
				clsDonnee.pvgDeConnectionBase();
			}
			return clsObjetRetour;
		}


        
		[WebMethod(MessageName = "pvgTableLibelle", Description = "pvgTableLibelle", EnableSession = true)]
		public clsObjetRetour pvgTableLibelle(clsObjetEnvoi clsObjetEnvoi)
		{
			clsObjetRetour clsObjetRetour = new clsObjetRetour();
			try
			{
				clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
				clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
				clsDonnee.pvgConnectionBase();
				clsObjetRetour.SetValue(true, clsBanqueagenceWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi));
			}
			catch (SqlException SQLEx)
			{
				clsObjetRetour.SetValueMessage(false,SQLEx.Message);
			}
			finally 
			{
				clsDonnee.pvgDeConnectionBase();
			}
			return clsObjetRetour;
		}


        
		[WebMethod(MessageName = "pvgAjouter", Description = "pvgAjouter", EnableSession = true)]
		public clsObjetRetour pvgAjouter(clsBanqueagence clsBanqueagence, clsObjetEnvoi clsObjetEnvoi)
		{
			clsObjetRetour clsObjetRetour = new clsObjetRetour();
			try 
			{ 
				clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
				clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
				clsDonnee.pvgDemarrerTransaction();
				clsObjetRetour.SetValue(true, clsBanqueagenceWSBLL.pvgAjouter(clsDonnee,clsBanqueagence, clsObjetEnvoi ),clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);
			} 
			catch (SqlException SQLEx)
			{ 
				string vlpMessage = (SQLEx.Number == 2601 || SQLEx.Number == 2627) ? clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0003").MS_LIBELLEMESSAGE : SQLEx.Message;
				clsObjetRetour.SetValueMessage(false, vlpMessage);
			} 
			finally 
			{ 
				clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
			} 
			return clsObjetRetour;
		}


        
		[WebMethod(MessageName = "pvgAjouterListe", Description = "pvgAjouterListe", EnableSession = true)]
		public clsObjetRetour pvgAjouterListe(List<clsBanqueagence> clsBanqueagences , clsObjetEnvoi clsObjetEnvoi)
		{
			clsObjetRetour clsObjetRetour = new clsObjetRetour();
			try 
			{ 
				clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
				clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
				clsDonnee.pvgDemarrerTransaction();
				clsObjetRetour.SetValue(true, clsBanqueagenceWSBLL.pvgAjouterListe(clsDonnee,clsBanqueagences, clsObjetEnvoi),clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);
			} 
			catch (SqlException SQLEx)
			{ 
				string vlpMessage = (SQLEx.Number == 2601 || SQLEx.Number == 2627) ? clsMessagesWSBLL.pvgTableLibelle(clsDonnee,"GNE0003").MS_LIBELLEMESSAGE : SQLEx.Message;
				clsObjetRetour.SetValueMessage(false, vlpMessage);
			} 
			finally 
			{ 
				clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
			} 
			return clsObjetRetour;
		}


         
		[WebMethod(MessageName = "pvgModifier", Description = "pvgModifier", EnableSession = true)]
		public clsObjetRetour pvgModifier(clsBanqueagence clsBanqueagence, clsObjetEnvoi clsObjetEnvoi)
		{
			clsObjetRetour clsObjetRetour = new clsObjetRetour();
			try 
			{ 
				clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
				clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
				clsDonnee.pvgDemarrerTransaction();
				clsObjetRetour.SetValue(true, clsBanqueagenceWSBLL.pvgModifier(clsDonnee,clsBanqueagence, clsObjetEnvoi),clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0068").MS_LIBELLEMESSAGE);
			} 
			catch (SqlException SQLEx)
			{ 
				string vlpMessage = (SQLEx.Number == 2601 || SQLEx.Number == 2627) ? clsMessagesWSBLL.pvgTableLibelle(clsDonnee,"GNE0003").MS_LIBELLEMESSAGE : SQLEx.Message;
				clsObjetRetour.SetValueMessage(false, vlpMessage);
			} 
			finally 
			{ 
				clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
			} 
			return clsObjetRetour;
		}


        
		[WebMethod(MessageName = "pvgSupprimer", Description = "pvgSupprimer", EnableSession = true)]
		public clsObjetRetour pvgSupprimer(clsObjetEnvoi clsObjetEnvoi)
		{
			clsObjetRetour clsObjetRetour = new clsObjetRetour();
			try 
			{ 
				clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
				clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
				clsDonnee.pvgDemarrerTransaction();
				clsObjetRetour.SetValue(true, clsBanqueagenceWSBLL.pvgSupprimer(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
			} 
			catch (SqlException SQLEx)
			{ 
				string vlpMessage = (SQLEx.Number == 547) ? clsMessagesWSBLL.pvgTableLibelle(clsDonnee,"GNE0003").MS_LIBELLEMESSAGE : SQLEx.Message;
				clsObjetRetour.SetValueMessage(false, vlpMessage);
			} 
			finally 
			{ 
				clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);
			} 
			return clsObjetRetour;
		}


        
		[WebMethod(MessageName = "pvgCharger", Description = "pvgCharger", EnableSession = true)]
		public clsObjetRetour pvgCharger(clsObjetEnvoi clsObjetEnvoi)
		{
			clsObjetRetour clsObjetRetour = new clsObjetRetour();
			try
			{
				clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
				clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
				clsDonnee.pvgConnectionBase();
				clsObjetRetour.SetValue(true, clsBanqueagenceWSBLL.pvgCharger(clsDonnee, clsObjetEnvoi));
			}
			catch (SqlException SQLEx)
			{
				clsObjetRetour.SetValueMessage(false,SQLEx.Message);
			}
			finally 
			{
				clsDonnee.pvgDeConnectionBase();
			}
			return clsObjetRetour;
		}


        
		[WebMethod(MessageName = "pvgChargerAPartirDataSet", Description = "pvgChargerAPartirDataSet", EnableSession = true)]
		public clsObjetRetour pvgChargerAPartirDataSet(clsObjetEnvoi clsObjetEnvoi)
		{
			clsObjetRetour clsObjetRetour = new clsObjetRetour();
			try
			{
				clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
				clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
				clsDonnee.pvgConnectionBase();
				clsObjetRetour.SetValue(true, clsBanqueagenceWSBLL.pvgChargerAPartirDataSet(clsDonnee, clsObjetEnvoi));
			}
			catch (SqlException SQLEx)
			{
				clsObjetRetour.SetValueMessage(false,SQLEx.Message);
			}
			finally 
			{
				clsDonnee.pvgDeConnectionBase();
			}
			return clsObjetRetour;
		}


        
		[WebMethod(MessageName = "pvgChargerDansDataSet", Description = "pvgChargerDansDataSet", EnableSession = true)]
		public clsObjetRetour pvgChargerDansDataSet(clsObjetEnvoi clsObjetEnvoi)
		{
			clsObjetRetour clsObjetRetour = new clsObjetRetour();
			try
			{
				clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
				clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
				clsDonnee.pvgConnectionBase();
				clsObjetRetour.SetValue(true, clsBanqueagenceWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi));
			}
			catch (SqlException SQLEx)
			{
				clsObjetRetour.SetValueMessage(false,SQLEx.Message);
			}
			finally 
			{
				clsDonnee.pvgDeConnectionBase();
			}
			return clsObjetRetour;
		}


        
		[WebMethod(MessageName = "pvgChargerDansDataSetPourCombo", Description = "pvgChargerDansDataSetPourCombo", EnableSession = true)]
		public clsObjetRetour pvgChargerDansDataSetPourCombo(clsObjetEnvoi clsObjetEnvoi)
		{
			clsObjetRetour clsObjetRetour = new clsObjetRetour();
			try
			{
				clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
				clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
				clsDonnee.pvgConnectionBase();
				clsObjetRetour.SetValue(true, clsBanqueagenceWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi));
			}
			catch (SqlException SQLEx)
			{
				clsObjetRetour.SetValueMessage(false,SQLEx.Message);
			}
			finally 
			{
				clsDonnee.pvgDeConnectionBase();
			}
			return clsObjetRetour;
		}


        
	}
}