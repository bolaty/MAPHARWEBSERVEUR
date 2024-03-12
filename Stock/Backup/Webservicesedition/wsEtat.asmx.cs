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

	[WebService(Namespace = "http://192.168.1.100:73/Webservicesedition/wsEtat.asmx")] 
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1) ] 
	[System.ComponentModel.ToolboxItem(false)] 
	// Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante.  
	// [System.Web.Script.Services.ScriptService] 
	public class wsEtat : System.Web.Services.WebService//, IAsmx<clsEtat>
	{

        private clsDonnee _clsDonnee  = new clsDonnee(); 
		private clsEtatWSBLL clsEtatWSBLL  = new clsEtatWSBLL(); 
		private clsMessagesWSBLL clsMessagesWSBLL  = new  clsMessagesWSBLL();
		public clsDonnee clsDonnee 
		{ 
			get { return _clsDonnee; } 
			set { _clsDonnee= value; }
		} 

        
		[WebMethod(MessageName = "pvgValeurScalaireRequeteCount", Description = "pvgValeurScalaireRequeteCount", EnableSession = true)]
		public clsObjetRetour pvgValeurScalaireRequeteCount(  params string[] vppCritere)
		{
			clsObjetRetour clsObjetRetour =new clsObjetRetour() ;
			try
			{
				clsDonnee.pvgConnectionBase();
				clsObjetRetour.SetValue(true, clsEtatWSBLL.pvgValeurScalaireRequeteCount(clsDonnee, vppCritere));
			}
			catch (SqlException SQLEx)
			{
				clsObjetRetour.SetValueMessage (false,SQLEx.Message);
			}
			finally 
			{
				clsDonnee.pvgDeConnectionBase();
			}
			return clsObjetRetour ;
		}


        
		[WebMethod(MessageName = "pvgValeurScalaireRequeteMin", Description = "pvgValeurScalaireRequeteMin", EnableSession = true)]
		public clsObjetRetour pvgValeurScalaireRequeteMin(  params string[] vppCritere)
		{
			clsObjetRetour clsObjetRetour =new clsObjetRetour() ;
			try
			{
				clsDonnee.pvgConnectionBase();
				clsObjetRetour.SetValue(true, clsEtatWSBLL.pvgValeurScalaireRequeteMin(clsDonnee, vppCritere));
			}
			catch (SqlException SQLEx)
			{
				clsObjetRetour.SetValueMessage (false,SQLEx.Message);
			}
			finally 
			{
				clsDonnee.pvgDeConnectionBase();
			}
			return clsObjetRetour ;
		}


        
		[WebMethod(MessageName = "pvgValeurScalaireRequeteMax", Description = "pvgValeurScalaireRequeteMax", EnableSession = true)]
		public clsObjetRetour pvgValeurScalaireRequeteMax(  params string[] vppCritere)
		{
			clsObjetRetour clsObjetRetour =new clsObjetRetour() ;
			try
			{
				clsDonnee.pvgConnectionBase();
				clsObjetRetour.SetValue(true, clsEtatWSBLL.pvgValeurScalaireRequeteMax(clsDonnee, vppCritere));
			}
			catch (SqlException SQLEx)
			{
				clsObjetRetour.SetValueMessage (false,SQLEx.Message);
			}
			finally 
			{
				clsDonnee.pvgDeConnectionBase();
			}
			return clsObjetRetour ;
		}


        
		[WebMethod(MessageName = "pvgTableLibelle", Description = "pvgTableLibelle", EnableSession = true)]
		public clsObjetRetour pvgTableLibelle(  params string[] vppCritere)
		{
			clsObjetRetour clsObjetRetour =new clsObjetRetour() ;
			try
			{
				clsDonnee.pvgConnectionBase();
				clsObjetRetour.SetValue(true, clsEtatWSBLL.pvgTableLibelle(clsDonnee, vppCritere));
			}
			catch (SqlException SQLEx)
			{
				clsObjetRetour.SetValueMessage (false,SQLEx.Message);
			}
			finally 
			{
				clsDonnee.pvgDeConnectionBase();
			}
			return clsObjetRetour ;
		}


        
		[WebMethod(MessageName = "pvgAjouter", Description = "pvgAjouter", EnableSession = true)]
		public clsObjetRetour pvgAjouter( clsEtat clsEtat )
		{
			clsObjetRetour clsObjetRetour =new clsObjetRetour() ;
			try 
			{ 
				clsDonnee.pvgDemarrerTransaction();
				clsObjetRetour.SetValue(true, clsEtatWSBLL.pvgAjouter(clsDonnee,clsEtat ));
			} 
			catch (SqlException SQLEx)
			{ 
				string vlpMessage = (SQLEx.Number == 2601 || SQLEx.Number == 2627) ? clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0003").MS_LIBELLEMESSAGE : SQLEx.Message;
				clsObjetRetour.SetValueMessage(false, vlpMessage);
			} 
			finally 
			{ 
				clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);;
			} 
			return clsObjetRetour ;
		}


        
		[WebMethod(MessageName = "pvgAjouterListe", Description = "pvgAjouterListe", EnableSession = true)]
		public clsObjetRetour pvgAjouterListe(  List<clsEtat> clsEtats , params string[] vppCritere)
		{
			clsObjetRetour clsObjetRetour =new clsObjetRetour() ;
			try 
			{ 
				clsDonnee.pvgDemarrerTransaction();
				clsObjetRetour.SetValue(true, clsEtatWSBLL.pvgAjouter(clsDonnee,clsEtats, vppCritere));
			} 
			catch (SqlException SQLEx)
			{ 
				string vlpMessage = (SQLEx.Number == 2601 || SQLEx.Number == 2627) ? clsMessagesWSBLL.pvgTableLibelle(clsDonnee,"GNE0003").MS_LIBELLEMESSAGE : SQLEx.Message;
				clsObjetRetour.SetValueMessage(false, vlpMessage);
			} 
			finally 
			{ 
				clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);;
			} 
			return clsObjetRetour ;
		}


         
		[WebMethod(MessageName = "pvgModifier", Description = "pvgModifier", EnableSession = true)]
		public clsObjetRetour pvgModifier( clsEtat clsEtat, params string[] vppCritere)
		{
			clsObjetRetour clsObjetRetour =new clsObjetRetour() ;
			try 
			{ 
				clsDonnee.pvgDemarrerTransaction();
				clsObjetRetour.SetValue(true, clsEtatWSBLL.pvgModifier(clsDonnee,clsEtat, vppCritere));
			} 
			catch (SqlException SQLEx)
			{ 
				string vlpMessage = (SQLEx.Number == 2601 || SQLEx.Number == 2627) ? clsMessagesWSBLL.pvgTableLibelle(clsDonnee,"GNE0003").MS_LIBELLEMESSAGE : SQLEx.Message;
				clsObjetRetour.SetValueMessage(false, vlpMessage);
			} 
			finally 
			{ 
				clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);;
			} 
			return clsObjetRetour ;
		}


        
		[WebMethod(MessageName = "pvgSupprimer", Description = "pvgSupprimer", EnableSession = true)]
		public clsObjetRetour pvgSupprimer( params string[] vppCritere )
		{
			clsObjetRetour clsObjetRetour =new clsObjetRetour() ;
			try 
			{ 
				clsDonnee.pvgDemarrerTransaction();
				clsObjetRetour.SetValue(true, clsEtatWSBLL.pvgSupprimer(clsDonnee , vppCritere));
			} 
			catch (SqlException SQLEx)
			{ 
				string vlpMessage = (SQLEx.Number == 547) ? clsMessagesWSBLL.pvgTableLibelle(clsDonnee,"GNE0003").MS_LIBELLEMESSAGE : SQLEx.Message;
				clsObjetRetour.SetValueMessage(false, vlpMessage);
			} 
			finally 
			{ 
				clsDonnee.pvgTerminerTransaction(!clsObjetRetour.OR_BOOLEEN);;
			} 
			return clsObjetRetour ;
		}


        
		[WebMethod(MessageName = "pvgCharger", Description = "pvgCharger", EnableSession = true)]
		public clsObjetRetour pvgCharger(  params string[] vppCritere)
		{
			clsObjetRetour clsObjetRetour =new clsObjetRetour() ;
			try
			{
				clsDonnee.pvgConnectionBase();
				clsObjetRetour.SetValue(true, clsEtatWSBLL.pvgCharger(clsDonnee, vppCritere));
			}
			catch (SqlException SQLEx)
			{
				clsObjetRetour.SetValueMessage (false,SQLEx.Message);
			}
			finally 
			{
				clsDonnee.pvgDeConnectionBase();
			}
			return clsObjetRetour ;
		}


        
		[WebMethod(MessageName = "pvgChargerAPartirDataSet", Description = "pvgChargerAPartirDataSet", EnableSession = true)]
		public clsObjetRetour pvgChargerAPartirDataSet(  params string[] vppCritere)
		{
			clsObjetRetour clsObjetRetour =new clsObjetRetour() ;
			try
			{
				clsDonnee.pvgConnectionBase();
				clsObjetRetour.SetValue(true, clsEtatWSBLL.pvgChargerAPartirDataSet(clsDonnee, vppCritere));
			}
			catch (SqlException SQLEx)
			{
				clsObjetRetour.SetValueMessage (false,SQLEx.Message);
			}
			finally 
			{
				clsDonnee.pvgDeConnectionBase();
			}
			return clsObjetRetour ;
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
                clsObjetRetour.SetValue(true, clsEtatWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi));
            }
            catch (SqlException SQLEx)
            {
                clsObjetRetour.SetValueMessage(false, SQLEx.Message);
            }
            finally
            {
                clsDonnee.pvgDeConnectionBase();
            }
            return clsObjetRetour;
        }

       


        
		[WebMethod(MessageName = "pvgInsertIntoDatasetCombo", Description = "pvgInsertIntoDatasetCombo", EnableSession = true)]
		public clsObjetRetour pvgInsertIntoDatasetCombo(  params string[] vppCritere)
		{
			clsObjetRetour clsObjetRetour =new clsObjetRetour() ;
			try
			{
				clsDonnee.pvgConnectionBase();
				clsObjetRetour.SetValue(true, clsEtatWSBLL.pvgInsertIntoDatasetCombo(clsDonnee, vppCritere));
			}
			catch (SqlException SQLEx)
			{
				clsObjetRetour.SetValueMessage (false,SQLEx.Message);
			}
			finally 
			{
				clsDonnee.pvgDeConnectionBase();
			}
			return clsObjetRetour ;
		}


        
		[WebMethod(MessageName = "pvgInsertIntoDatasetComboOrdre", Description = "pvgInsertIntoDatasetComboOrdre", EnableSession = true)]
		public clsObjetRetour pvgInsertIntoDatasetComboOrdre(  string vppChamps, string vppChampOrdre, params string[] vppCritere)
		{
			clsObjetRetour clsObjetRetour =new clsObjetRetour() ;
			try
			{
				clsDonnee.pvgConnectionBase();
				clsObjetRetour.SetValue(true, clsEtatWSBLL.pvgInsertIntoDatasetCombo(clsDonnee, vppChamps, vppChampOrdre, vppCritere));
			}
			catch (SqlException SQLEx)
			{
				clsObjetRetour.SetValueMessage (false,SQLEx.Message);
			}
			finally 
			{
				clsDonnee.pvgDeConnectionBase();
			}
			return clsObjetRetour ;
		}


        
	}
}