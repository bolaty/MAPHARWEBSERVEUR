using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Web;
using Stock.WSTOOLS;
using Stock.BOJ;
using Stock.WSBLL;

namespace Stock.WS
{
    [WebService(Namespace = "http://192.168.1.100:73/Webservices/wsOperateurdroitagence.asmx")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1) ]
	[System.ComponentModel.ToolboxItem(false)]
	// Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante.
	// [System.Web.Script.Services.ScriptService]
	public class wsOperateurdroitagence: System.Web.Services.WebService, IAsmx<clsOperateurdroitagence>
	{
		private clsDonnee _clsDonnee = new clsDonnee();
		private clsOperateurdroitagenceWSBLL clsOperateurdroitagenceWSBLL= new clsOperateurdroitagenceWSBLL();
		private clsMessagesWSBLL clsMessagesWSBLL  = new  clsMessagesWSBLL();
		private clsJourneetravailWSBLL clsJourneetravailWSBLL  = new  clsJourneetravailWSBLL();
		public clsDonnee clsDonnee
		{
			get { return _clsDonnee; } 
			set { _clsDonnee =value ; } 
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
				clsObjetRetour.SetValue(true,clsOperateurdroitagenceWSBLL.pvgValeurScalaireRequeteCount(clsDonnee, clsObjetEnvoi));
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
				clsObjetRetour.SetValue(true,clsOperateurdroitagenceWSBLL.pvgValeurScalaireRequeteMin(clsDonnee, clsObjetEnvoi));
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
				clsObjetRetour.SetValue(true,clsOperateurdroitagenceWSBLL.pvgValeurScalaireRequeteMax(clsDonnee, clsObjetEnvoi));
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
				clsObjetRetour.SetValue(true,clsOperateurdroitagenceWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi));
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
		public clsObjetRetour pvgAjouter(clsOperateurdroitagence clsOperateurdroitagence, clsObjetEnvoi clsObjetEnvoi)
		{
			clsObjetRetour clsObjetRetour = new clsObjetRetour();
			try
			{
				clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
				clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
				clsDonnee.pvgDemarrerTransaction();
				if (clsJourneetravailWSBLL.pvgValeurScalaireRequeteCount2(clsDonnee, clsObjetEnvoi) == "0")
				{
					clsObjetRetour.SetValue(false, "", clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0076").MS_LIBELLEMESSAGE);
				}
				else
				{
					clsObjetRetour.SetValue(true,clsOperateurdroitagenceWSBLL.pvgAjouter(clsDonnee, clsOperateurdroitagence, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);
				}
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
		public clsObjetRetour pvgAjouterListe(List<clsOperateurdroitagence> clsOperateurdroitagences, clsObjetEnvoi clsObjetEnvoi)
		{
			clsObjetRetour clsObjetRetour = new clsObjetRetour();
			try
			{
				clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
				clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
				clsDonnee.pvgDemarrerTransaction();
				if (clsJourneetravailWSBLL.pvgValeurScalaireRequeteCount2(clsDonnee, clsObjetEnvoi) == "0")
				{
					clsObjetRetour.SetValue(false, "", clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0076").MS_LIBELLEMESSAGE);
				}
				else
				{
					clsObjetRetour.SetValue(true,clsOperateurdroitagenceWSBLL.pvgAjouterListe(clsDonnee, clsOperateurdroitagences, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);
				}
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

		[WebMethod(MessageName = "pvgModifier", Description = "pvgModifier", EnableSession = true)]
		public clsObjetRetour pvgModifier(clsOperateurdroitagence clsOperateurdroitagence, clsObjetEnvoi clsObjetEnvoi)
		{
			clsObjetRetour clsObjetRetour = new clsObjetRetour();
			try
			{
				clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
				clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
				clsDonnee.pvgDemarrerTransaction();
				if (clsJourneetravailWSBLL.pvgValeurScalaireRequeteCount2(clsDonnee, clsObjetEnvoi) == "0")
				{
					clsObjetRetour.SetValue(false, "", clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0076").MS_LIBELLEMESSAGE);
				}
				else
				{
					clsObjetRetour.SetValue(true,clsOperateurdroitagenceWSBLL.pvgModifier(clsDonnee, clsOperateurdroitagence, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0068").MS_LIBELLEMESSAGE);
				}
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

		[WebMethod(MessageName = "pvgSupprimer", Description = "pvgSupprimer", EnableSession = true)]
		public clsObjetRetour pvgSupprimer( clsObjetEnvoi clsObjetEnvoi)
		{
			clsObjetRetour clsObjetRetour = new clsObjetRetour();
			try
			{
				clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
				clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
				clsDonnee.pvgDemarrerTransaction();
				if (clsJourneetravailWSBLL.pvgValeurScalaireRequeteCount2(clsDonnee, clsObjetEnvoi) == "0")
				{
					clsObjetRetour.SetValue(false, "", clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0076").MS_LIBELLEMESSAGE);
				}
				else
				{
					clsObjetRetour.SetValue(true,clsOperateurdroitagenceWSBLL.pvgSupprimer(clsDonnee,  clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
				}
			}
			catch (SqlException SQLEx)
			{
				string vlpMessage = (SQLEx.Number == 547) ? clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0003").MS_LIBELLEMESSAGE : SQLEx.Message;
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
				clsObjetRetour.SetValue(true,clsOperateurdroitagenceWSBLL.pvgCharger(clsDonnee, clsObjetEnvoi));
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
				clsObjetRetour.SetValue(true,clsOperateurdroitagenceWSBLL.pvgChargerAPartirDataSet(clsDonnee, clsObjetEnvoi));
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
				clsObjetRetour.SetValue(true,clsOperateurdroitagenceWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi));
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
				clsObjetRetour.SetValue(true,clsOperateurdroitagenceWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi));
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

        [WebMethod(MessageName = "pvgAjouterdroit", Description = "pvgAjouterdroit", EnableSession = true)]
        public clsObjetRetour pvgAjouterdroit(List<clsOperateurdroitagence> clsOperateurdroitagenceAjout, List<clsOperateurdroitagence> clsOperateurdroitagenceSuppression, clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgDemarrerTransaction();
                if (clsJourneetravailWSBLL.pvgValeurScalaireRequeteCount2(clsDonnee, clsObjetEnvoi) == "0")
                {
                    clsObjetRetour.SetValue(false, "", clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0076").MS_LIBELLEMESSAGE);
                }
                else
                {
                    clsObjetRetour.SetValue(true, clsOperateurdroitagenceWSBLL.pvgAjouterdroit(clsDonnee, clsOperateurdroitagenceAjout, clsOperateurdroitagenceSuppression, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);
                }
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


	}
}
