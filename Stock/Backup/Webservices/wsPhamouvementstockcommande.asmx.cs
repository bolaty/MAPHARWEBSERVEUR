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
	[WebService(Namespace ="http://192.168.1.100:73/Webservices/wsPhamouvementStockcommande.asmx")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1) ]
	[System.ComponentModel.ToolboxItem(false)]
	// Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante.
	// [System.Web.Script.Services.ScriptService]
	public class wsPhamouvementStockcommande: System.Web.Services.WebService, IAsmx<clsPhamouvementStockcommande>
	{
		private clsDonnee _clsDonnee = new clsDonnee();
		private clsPhamouvementStockcommandeWSBLL clsPhamouvementStockcommandeWSBLL= new clsPhamouvementStockcommandeWSBLL();
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
				clsObjetRetour.SetValue(true,clsPhamouvementStockcommandeWSBLL.pvgValeurScalaireRequeteCount(clsDonnee, clsObjetEnvoi));
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
				clsObjetRetour.SetValue(true,clsPhamouvementStockcommandeWSBLL.pvgValeurScalaireRequeteMin(clsDonnee, clsObjetEnvoi));
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
				clsObjetRetour.SetValue(true,clsPhamouvementStockcommandeWSBLL.pvgValeurScalaireRequeteMax(clsDonnee, clsObjetEnvoi));
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
				clsObjetRetour.SetValue(true,clsPhamouvementStockcommandeWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi));
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
		public clsObjetRetour pvgAjouter(clsPhamouvementStockcommande clsPhamouvementStockcommande, clsObjetEnvoi clsObjetEnvoi)
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
					clsObjetRetour.SetValue(true,clsPhamouvementStockcommandeWSBLL.pvgAjouter(clsDonnee, clsPhamouvementStockcommande, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);
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

        [WebMethod(MessageName = "pvgAnnulerCommande", Description = "pvgAnnulerCommande", EnableSession = true)]
        public clsObjetRetour pvgAnnulerCommande(clsPhamouvementStockcommande clsPhamouvementStockcommande, clsObjetEnvoi clsObjetEnvoi)
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
                    clsObjetRetour.SetValue(true, clsPhamouvementStockcommandeWSBLL.pvgAnnulerCommande(clsDonnee, clsPhamouvementStockcommande, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);
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

        [WebMethod(MessageName = "pvgAjouterCommande", Description = "pvgAjouterCommande", EnableSession = true)]
        public clsObjetRetour pvgAjouterCommande(clsPhamouvementStockcommande clsPhamouvementStockcommande, List<clsPhamouvementStockdetailcommande> clsPhamouvementStockdetailcommandes, clsObjetEnvoi clsObjetEnvoi)
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
                    
                    clsObjetRetour.SetValue(true, clsPhamouvementStockcommandeWSBLL.pvgAjouter(clsDonnee, clsPhamouvementStockcommande, clsPhamouvementStockdetailcommandes, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);
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



        [WebMethod(MessageName = "pvgAjouterCommande1", Description = "pvgAjouterCommande1", EnableSession = true)]
        public clsObjetRetour pvgAjouterCommande1(clsPhamouvementStockcommande clsPhamouvementStockcommande, List<clsPhamouvementStockdetailcommande> clsPhamouvementStockdetailcommandes, List<clsPhamouvementstockcommandefacture> clsPhamouvementstockcommandefactures, clsObjetEnvoi clsObjetEnvoi)
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

                    clsObjetRetour.SetValue(true, clsPhamouvementStockcommandeWSBLL.pvgAjouter1(clsDonnee, clsPhamouvementStockcommande, clsPhamouvementStockdetailcommandes, clsPhamouvementstockcommandefactures, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);
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
		public clsObjetRetour pvgAjouterListe(List<clsPhamouvementStockcommande> clsPhamouvementStockcommandes, clsObjetEnvoi clsObjetEnvoi)
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
					clsObjetRetour.SetValue(true,clsPhamouvementStockcommandeWSBLL.pvgAjouterListe(clsDonnee, clsPhamouvementStockcommandes, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);
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
		public clsObjetRetour pvgModifier(clsPhamouvementStockcommande clsPhamouvementStockcommande, clsObjetEnvoi clsObjetEnvoi)
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
					clsObjetRetour.SetValue(true,clsPhamouvementStockcommandeWSBLL.pvgModifier(clsDonnee, clsPhamouvementStockcommande, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0068").MS_LIBELLEMESSAGE);
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

        [WebMethod(MessageName = "pvgModifierCommande", Description = "pvgModifierCommande", EnableSession = true)]
        public clsObjetRetour pvgModifierCommande(clsPhamouvementStockcommande clsPhamouvementStockcommande, List<clsPhamouvementStockdetailcommande> clsPhamouvementStockdetailcommandes, clsObjetEnvoi clsObjetEnvoi)
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
                    clsObjetRetour.SetValue(true, clsPhamouvementStockcommandeWSBLL.pvgModifier(clsDonnee, clsPhamouvementStockcommande, clsPhamouvementStockdetailcommandes, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0068").MS_LIBELLEMESSAGE);
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
					clsObjetRetour.SetValue(true,clsPhamouvementStockcommandeWSBLL.pvgSupprimer(clsDonnee,  clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
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
				clsObjetRetour.SetValue(true,clsPhamouvementStockcommandeWSBLL.pvgCharger(clsDonnee, clsObjetEnvoi));
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

        [WebMethod(MessageName = "pvgChargerCommandeFournisseur", Description = "pvgChargerCommandeFournisseur", EnableSession = true)]
        public clsObjetRetour pvgChargerCommandeFournisseur(clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsPhamouvementStockcommandeWSBLL.pvgChargerCommandeFournisseur(clsDonnee, clsObjetEnvoi));
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

        [WebMethod(MessageName = "pvgChargerCommandeClient", Description = "pvgChargerCommandeClient", EnableSession = true)]
        public clsObjetRetour pvgChargerCommandeClient(clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsPhamouvementStockcommandeWSBLL.pvgChargerCommandeClient(clsDonnee, clsObjetEnvoi));
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

		[WebMethod(MessageName = "pvgChargerAPartirDataSet", Description = "pvgChargerAPartirDataSet", EnableSession = true)]
		public clsObjetRetour pvgChargerAPartirDataSet(clsObjetEnvoi clsObjetEnvoi)
		{
			clsObjetRetour clsObjetRetour = new clsObjetRetour();
			try
			{
				clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
				clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
				clsDonnee.pvgConnectionBase();
				clsObjetRetour.SetValue(true,clsPhamouvementStockcommandeWSBLL.pvgChargerAPartirDataSet(clsDonnee, clsObjetEnvoi));
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
        [WebMethod(MessageName = "pvgChargerDataSetCommandeClient", Description = "pvgChargerDataSetCommandeClient", EnableSession = true)]
        public clsObjetRetour pvgChargerDataSetCommandeClient(clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsPhamouvementStockcommandeWSBLL.pvgChargerDataSetCommandeClient(clsDonnee, clsObjetEnvoi));
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
        [WebMethod(MessageName = "pvgChargerDataSetCommandeFournisseur", Description = "pvgChargerDataSetCommandeFournisseur", EnableSession = true)]
        public clsObjetRetour pvgChargerDataSetCommandeFournisseur(clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsPhamouvementStockcommandeWSBLL.pvgChargerDataSetCommandeFournisseur(clsDonnee, clsObjetEnvoi));
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

		[WebMethod(MessageName = "pvgChargerDansDataSet", Description = "pvgChargerDansDataSet", EnableSession = true)]
		public clsObjetRetour pvgChargerDansDataSet(clsObjetEnvoi clsObjetEnvoi)
		{
			clsObjetRetour clsObjetRetour = new clsObjetRetour();
			try
			{
				clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
				clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
				clsDonnee.pvgConnectionBase();
				clsObjetRetour.SetValue(true,clsPhamouvementStockcommandeWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi));
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
        [WebMethod(MessageName = "pvpChargerAccessoires", Description = "pvpChargerAccessoires", EnableSession = true)]
        public clsObjetRetour pvpChargerAccessoires(clsPhamouvementStockdetailcommande clsPhamouvementStockdetailcommande, List<clsPhamouvementStockdetailcommande> clsPhamouvementStockdetailcommandes, clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsPhamouvementStockcommandeWSBLL.pvpChargerAccessoires(clsDonnee,clsPhamouvementStockdetailcommande,clsPhamouvementStockdetailcommandes, clsObjetEnvoi));
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

		[WebMethod(MessageName = "pvgChargerDansDataSetPourCombo", Description = "pvgChargerDansDataSetPourCombo", EnableSession = true)]
		public clsObjetRetour pvgChargerDansDataSetPourCombo(clsObjetEnvoi clsObjetEnvoi)
		{
			clsObjetRetour clsObjetRetour = new clsObjetRetour();
			try
			{
				clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
				clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
				clsDonnee.pvgConnectionBase();
				clsObjetRetour.SetValue(true,clsPhamouvementStockcommandeWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi));
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
