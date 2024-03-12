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
	[WebService(Namespace ="http://192.168.1.100:73/Webservices/wsPhapararticle.asmx")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1) ]
	[System.ComponentModel.ToolboxItem(false)]
	// Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante.
	// [System.Web.Script.Services.ScriptService]
	public class wsPhapararticle: System.Web.Services.WebService, IAsmx<clsPhapararticle>
	{
		private clsDonnee _clsDonnee = new clsDonnee();
		private clsPhapararticleWSBLL clsPhapararticleWSBLL= new clsPhapararticleWSBLL();
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
				clsObjetRetour.SetValue(true,clsPhapararticleWSBLL.pvgValeurScalaireRequeteCount(clsDonnee, clsObjetEnvoi));
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

        [WebMethod(MessageName = "pvgValueScalarRequeteCountCodeBarre", Description = "pvgValueScalarRequeteCountCodeBarre", EnableSession = true)]
        public clsObjetRetour pvgValueScalarRequeteCountCodeBarre(clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsPhapararticleWSBLL.pvgValueScalarRequeteCountCodeBarre(clsDonnee, clsObjetEnvoi));
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

        [WebMethod(MessageName = "pvgStockActuel", Description = "pvgStockActuel", EnableSession = true)]
        public clsObjetRetour pvgStockActuel(clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsPhapararticleWSBLL.pvgStockActuel(clsDonnee, clsObjetEnvoi).ToString());
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

        [WebMethod(MessageName = "pvgValueScalarRequeteCountCodeCIP", Description = "pvgValueScalarRequeteCountCodeCIP", EnableSession = true)]
        public clsObjetRetour pvgValueScalarRequeteCountCodeCIP(clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsPhapararticleWSBLL.pvgValueScalarRequeteCountCodeCIP(clsDonnee, clsObjetEnvoi));
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

        [WebMethod(MessageName = "pvgTableLabelAvecCodeCIP", Description = "pvgTableLabelAvecCodeCIP", EnableSession = true)]
        public clsObjetRetour pvgTableLabelAvecCodeCIP(clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsPhapararticleWSBLL.pvgTableLabelAvecCodeCIP(clsDonnee, clsObjetEnvoi));
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

		[WebMethod(MessageName = "pvgValeurScalaireRequeteMin", Description = "pvgValeurScalaireRequeteMin", EnableSession = true)]
		public clsObjetRetour pvgValeurScalaireRequeteMin(clsObjetEnvoi clsObjetEnvoi)
		{
			clsObjetRetour clsObjetRetour = new clsObjetRetour();
			try
			{
				clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
				clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
				clsDonnee.pvgConnectionBase();
				clsObjetRetour.SetValue(true,clsPhapararticleWSBLL.pvgValeurScalaireRequeteMin(clsDonnee, clsObjetEnvoi));
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
				clsObjetRetour.SetValue(true,clsPhapararticleWSBLL.pvgValeurScalaireRequeteMax(clsDonnee, clsObjetEnvoi));
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
				clsObjetRetour.SetValue(true,clsPhapararticleWSBLL.pvgTableLibelle(clsDonnee, clsObjetEnvoi));
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

        [WebMethod(MessageName = "pvgTableLabel1", Description = "pvgTableLabel1", EnableSession = true)]
        public clsObjetRetour pvgTableLabel1(clsObjetEnvoi clsObjetEnvoi)
        {
	        clsObjetRetour clsObjetRetour = new clsObjetRetour();
	        try
	        {
		        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
		        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
		        clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsPhapararticleWSBLL.pvgTableLabel1(clsDonnee, clsObjetEnvoi));
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
		public clsObjetRetour pvgAjouter(clsPhapararticle clsPhapararticle, clsObjetEnvoi clsObjetEnvoi)
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
					clsObjetRetour.SetValue(true,clsPhapararticleWSBLL.pvgAjouter(clsDonnee, clsPhapararticle, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);
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


        [WebMethod(MessageName = "pvgAjouter1", Description = "pvgAjouter1", EnableSession = true)]
        public clsObjetRetour pvgAjouter1(clsPhapararticle clsPhapararticle, List<clsPhapartypequantitedetail> clsPhapartypequantitedetails, List<clsPhapartyperemisedetail> clsPhapartyperemisedetails, clsObjetEnvoi clsObjetEnvoi)
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
                    clsObjetRetour.SetValue(true, clsPhapararticleWSBLL.pvgAjouter1(clsDonnee, clsPhapararticle, clsPhapartypequantitedetails, clsPhapartyperemisedetails, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);
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




        [WebMethod(MessageName = "pvgAjouter2", Description = "pvgAjouter2", EnableSession = true)]
        public clsObjetRetour pvgAjouter2(clsPhapararticle clsPhapararticle, clsPhamouvementStock clsPhamouvementStock, clsPhamouvementStockdetail clsPhamouvementStockdetail, clsObjetEnvoi clsObjetEnvoi)
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
                    clsObjetRetour.SetValue(true, clsPhapararticleWSBLL.pvgAjouter2(clsDonnee, clsPhapararticle, clsPhamouvementStock, clsPhamouvementStockdetail, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);
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





        [WebMethod(MessageName = "pvgAjouterArticle", Description = "pvgAjouterArticle", EnableSession = true)]
        public clsObjetRetour pvgAjouterArticle(clsPhapararticle clsPhapararticle, clsPhapararticlephoto clsPhapararticlephoto, clsObjetEnvoi clsObjetEnvoi)
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
                    clsObjetRetour.SetValue(true, clsPhapararticleWSBLL.pvgAjouter(clsDonnee, clsPhapararticle,clsPhapararticlephoto, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);
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
		public clsObjetRetour pvgAjouterListe(List<clsPhapararticle> clsPhapararticles, clsObjetEnvoi clsObjetEnvoi)
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
					clsObjetRetour.SetValue(true,clsPhapararticleWSBLL.pvgAjouterListe(clsDonnee, clsPhapararticles, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0069").MS_LIBELLEMESSAGE);
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
		public clsObjetRetour pvgModifier(clsPhapararticle clsPhapararticle, clsObjetEnvoi clsObjetEnvoi)
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
					clsObjetRetour.SetValue(true,clsPhapararticleWSBLL.pvgModifier(clsDonnee, clsPhapararticle, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0068").MS_LIBELLEMESSAGE);
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

        [WebMethod(MessageName = "pvgModifierCodeCIP", Description = "pvgModifierCodeCIP", EnableSession = true)]
        public clsObjetRetour pvgModifierCodeCIP( clsObjetEnvoi clsObjetEnvoi)
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
                    clsObjetRetour.SetValue(true, clsPhapararticleWSBLL.pvgModifierCodeCIP(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0068").MS_LIBELLEMESSAGE);
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

        [WebMethod(MessageName = "pvgModifierCodeBarre", Description = "pvgModifierCodeBarre", EnableSession = true)]
        public clsObjetRetour pvgModifierCodeBarre(clsObjetEnvoi clsObjetEnvoi)
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
                    clsObjetRetour.SetValue(true, clsPhapararticleWSBLL.pvgModifierCodeBarre(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0068").MS_LIBELLEMESSAGE);
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

        [WebMethod(MessageName = "pvgModifierTauxRemise", Description = "pvgModifierTauxRemise", EnableSession = true)]
        public clsObjetRetour pvgModifierTauxRemise(clsObjetEnvoi clsObjetEnvoi)
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
                    clsObjetRetour.SetValue(true, clsPhapararticleWSBLL.pvgModifierTauxRemise(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0068").MS_LIBELLEMESSAGE);
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
					clsObjetRetour.SetValue(true,clsPhapararticleWSBLL.pvgSupprimer(clsDonnee,  clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
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



        [WebMethod(MessageName = "pvgSupprimer1", Description = "pvgSupprimer1", EnableSession = true)]
        public clsObjetRetour pvgSupprimer1(List<clsPhapartypequantitedetail> clsPhapartypequantitedetails, List<clsPhapartyperemisedetail> clsPhapartyperemisedetails,clsObjetEnvoi clsObjetEnvoi)
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
                    clsObjetRetour.SetValue(true, clsPhapararticleWSBLL.pvgSupprimer1(clsDonnee, clsPhapartypequantitedetails, clsPhapartyperemisedetails, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "VIT0002").MS_LIBELLEMESSAGE);
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
				clsObjetRetour.SetValue(true,clsPhapararticleWSBLL.pvgCharger(clsDonnee, clsObjetEnvoi));
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

        [WebMethod(MessageName = "pvgChargerArticle", Description = "pvgChargerArticle", EnableSession = true)]
        public clsObjetRetour pvgChargerArticle(clsObjetEnvoi clsObjetEnvoi)
		{
			clsObjetRetour clsObjetRetour = new clsObjetRetour();
			try
			{
				clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
				clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
				clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsPhapararticleWSBLL.pvgChargerArticle(clsDonnee, clsObjetEnvoi));
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

        [WebMethod(MessageName = "pvgChargerArticlesRecherche", Description = "pvgChargerArticlesRecherche", EnableSession = true)]
        public clsObjetRetour pvgChargerArticlesRecherche(clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsPhapararticleWSBLL.pvgChargerArticlesRecherche(clsDonnee, clsObjetEnvoi));
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

        [WebMethod(MessageName = "pvgInsertIntoDatasetArticleQuantite", Description = "pvgInsertIntoDatasetArticleQuantite", EnableSession = true)]
        public clsObjetRetour pvgInsertIntoDatasetArticleQuantite(clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsPhapararticleWSBLL.pvgInsertIntoDatasetArticleQuantite(clsDonnee, clsObjetEnvoi));
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

        [WebMethod(MessageName = "pvgInsertIntoDatasetFactureDDH", Description = "pvgInsertIntoDatasetFactureDDH", EnableSession = true)]
        public clsObjetRetour pvgInsertIntoDatasetFactureDDH(clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsPhapararticleWSBLL.pvgInsertIntoDatasetFactureDDH(clsDonnee, clsObjetEnvoi));
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

        [WebMethod(MessageName = "pvgInsertIntoDatasetFactureApproDDH", Description = "pvgInsertIntoDatasetFactureApproDDH", EnableSession = true)]
        public clsObjetRetour pvgInsertIntoDatasetFactureApproDDH(clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsPhapararticleWSBLL.pvgInsertIntoDatasetFactureApproDDH(clsDonnee, clsObjetEnvoi));
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
				clsObjetRetour.SetValue(true,clsPhapararticleWSBLL.pvgChargerAPartirDataSet(clsDonnee, clsObjetEnvoi));
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
				clsObjetRetour.SetValue(true,clsPhapararticleWSBLL.pvgChargerDansDataSet(clsDonnee, clsObjetEnvoi));
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

        [WebMethod(MessageName = "pvgChargerDansDataSetPgarage", Description = "pvgChargerDansDataSetPgarage", EnableSession = true)]
        public clsObjetRetour pvgChargerDansDataSetPgarage(clsObjetEnvoi clsObjetEnvoi)
        {
	        clsObjetRetour clsObjetRetour = new clsObjetRetour();
	        try
	        {
		        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
		        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
		        clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsPhapararticleWSBLL.pvgChargerDansDataSetPgarage(clsDonnee, clsObjetEnvoi));
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


        [WebMethod(MessageName = "pvgChargerDansDataSetPourComboPgarage", Description = "pvgChargerDansDataSetPourComboPgarage", EnableSession = true)]
        public clsObjetRetour pvgChargerDansDataSetPourComboPgarage(clsObjetEnvoi clsObjetEnvoi)
        {
	        clsObjetRetour clsObjetRetour = new clsObjetRetour();
	        try
	        {
		        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
		        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
		        clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsPhapararticleWSBLL.pvgChargerDansDataSetPourComboPgarage(clsDonnee, clsObjetEnvoi));
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


       
        [WebMethod(MessageName = "pvgChargerDansDataSetACCESSOIRS", Description = "pvgChargerDansDataSetACCESSOIRS", EnableSession = true)]
        public clsObjetRetour pvgChargerDansDataSetACCESSOIRS(clsObjetEnvoi clsObjetEnvoi)
        {
	        clsObjetRetour clsObjetRetour = new clsObjetRetour();
	        try
	        {
		        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
		        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
		        clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsPhapararticleWSBLL.pvgChargerDansDataSetACCESSOIRS(clsDonnee, clsObjetEnvoi));
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
        [WebMethod(MessageName = "pvgChargerDansDataSetVenteAlaCaisse", Description = "pvgChargerDansDataSetVenteAlaCaisse", EnableSession = true)]
        public clsObjetRetour pvgChargerDansDataSetVenteAlaCaisse(clsObjetEnvoi clsObjetEnvoi)
		{
			clsObjetRetour clsObjetRetour = new clsObjetRetour();
			try
			{
				clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
				clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
				clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsPhapararticleWSBLL.pvgChargerDansDataSetVenteAlaCaisse(clsDonnee, clsObjetEnvoi));
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



        [WebMethod(MessageName = "pvgInsertIntoDatasetPrestation", Description = "pvgInsertIntoDatasetPrestation", EnableSession = true)]
        public clsObjetRetour pvgInsertIntoDatasetPrestation(clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsPhapararticleWSBLL.pvgInsertIntoDatasetPrestation(clsDonnee, clsObjetEnvoi));
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


        [WebMethod(MessageName = "pvgClotureArticle", Description = "pvgClotureArticle", EnableSession = true)]
        public clsObjetRetour pvgClotureArticle(clsObjetEnvoi clsObjetEnvoi)
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
                    clsObjetRetour.SetValue(true, clsPhapararticleWSBLL.pvgClotureArticle(clsDonnee, clsObjetEnvoi), clsMessagesWSBLL.pvgTableLibelle(clsDonnee, "GNE0068").MS_LIBELLEMESSAGE);
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

        [WebMethod(MessageName = "pvgInsertIntoDatasetGestionPromotinnelle", Description = "pvgInsertIntoDatasetGestionPromotinnelle", EnableSession = true)]
        public clsObjetRetour pvgInsertIntoDatasetGestionPromotinnelle(clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsPhapararticleWSBLL.pvgInsertIntoDatasetGestionPromotinnelle(clsDonnee, clsObjetEnvoi));
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


        [WebMethod(MessageName = "pvgInsertIntoDatasetRetoursAccessoir", Description = "pvgInsertIntoDatasetRetoursAccessoir", EnableSession = true)]
        public clsObjetRetour pvgInsertIntoDatasetRetoursAccessoir(clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsPhapararticleWSBLL.pvgInsertIntoDatasetRetoursAccessoir(clsDonnee, clsObjetEnvoi));
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

        //[WebMethod(MessageName = "pvgStockActuel", Description = "pvgStockActuel", EnableSession = true)]
        //public clsObjetRetour pvgStockActuel(clsObjetEnvoi clsObjetEnvoi)
        //{
        //    clsObjetRetour clsObjetRetour = new clsObjetRetour();
        //    try
        //    {
        //        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        //        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
        //        clsDonnee.pvgConnectionBase();
        //        clsObjetRetour.SetValue(true, clsPhapararticleWSBLL.pvgStockActuel(clsDonnee, clsObjetEnvoi));
        //    }
        //    catch (SqlException SQLEx)
        //    {
        //        clsObjetRetour.SetValueMessage(false, SQLEx.Message);
        //    }
        //    finally
        //    {
        //        clsDonnee.pvgDeConnectionBase();
        //    }
        //    return clsObjetRetour;
        //}

        [WebMethod(MessageName = "pvgPrixActuel", Description = "pvgPrixActuel", EnableSession = true)]
        public clsObjetRetour pvgPrixActuel(clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsPhapararticleWSBLL.pvgPrixActuel(clsDonnee, clsObjetEnvoi));
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

        [WebMethod(MessageName = "pvgSelectArticleAvecPrixFournisseur", Description = "pvgSelectArticleAvecPrixFournisseur", EnableSession = true)]
        public clsObjetRetour pvgSelectArticleAvecPrixFournisseur(clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsPhapararticleWSBLL.pvgSelectArticleAvecPrixFournisseur(clsDonnee, clsObjetEnvoi));
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

        [WebMethod(MessageName = "pvgSelectArticleAvecPrixClient", Description = "pvgSelectArticleAvecPrixClient", EnableSession = true)]
        public clsObjetRetour pvgSelectArticleAvecPrixClient(clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsPhapararticleWSBLL.pvgSelectArticleAvecPrixClient(clsDonnee, clsObjetEnvoi));
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

        [WebMethod(MessageName = "pvgSelectArticleAccessoireAvecPrixClient", Description = "pvgSelectArticleAccessoireAvecPrixClient", EnableSession = true)]
        public clsObjetRetour pvgSelectArticleAccessoireAvecPrixClient(clsObjetEnvoi clsObjetEnvoi)
        {
            clsObjetRetour clsObjetRetour = new clsObjetRetour();
            try
            {
                clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
                clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
                clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsPhapararticleWSBLL.pvgSelectArticleAccessoireAvecPrixClient(clsDonnee, clsObjetEnvoi));
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

        //[WebMethod(MessageName = "pvgChargerDansDataSetRechercheparNom", Description = "pvgChargerDansDataSetRechercheparNom", EnableSession = true)]
        //public clsObjetRetour pvgChargerDansDataSetRechercheparNom(clsObjetEnvoi clsObjetEnvoi)
        //{
        //    clsObjetRetour clsObjetRetour = new clsObjetRetour();
        //    try
        //    {
        //        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        //        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
        //        clsDonnee.pvgConnectionBase();
        //        clsObjetRetour.SetValue(true, clsPhapararticleWSBLL.pvgChargerDansDataSetRechercheparNom(clsDonnee, clsObjetEnvoi));
        //    }
        //    catch (SqlException SQLEx)
        //    {
        //        clsObjetRetour.SetValueMessage(false, SQLEx.Message);
        //    }
        //    finally
        //    {
        //        clsDonnee.pvgDeConnectionBase();
        //    }
        //    return clsObjetRetour;
        //}

        //[WebMethod(MessageName = "pvgChargerDansDataSetConsultation", Description = "pvgChargerDansDataSetConsultation", EnableSession = true)]
        //public clsObjetRetour pvgChargerDansDataSetConsultation(clsObjetEnvoi clsObjetEnvoi)
        //{
        //    clsObjetRetour clsObjetRetour = new clsObjetRetour();
        //    try
        //    {
        //        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
        //        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
        //        clsDonnee.pvgConnectionBase();
        //        clsObjetRetour.SetValue(true, clsPhapararticleWSBLL.pvgChargerDansDataSetConsultation(clsDonnee, clsObjetEnvoi));
        //    }
        //    catch (SqlException SQLEx)
        //    {
        //        clsObjetRetour.SetValueMessage(false, SQLEx.Message);
        //    }
        //    finally
        //    {
        //        clsDonnee.pvgDeConnectionBase();
        //    }
        //    return clsObjetRetour;
        //}

		[WebMethod(MessageName = "pvgChargerDansDataSetPourCombo", Description = "pvgChargerDansDataSetPourCombo", EnableSession = true)]
		public clsObjetRetour pvgChargerDansDataSetPourCombo(clsObjetEnvoi clsObjetEnvoi)
		{
			clsObjetRetour clsObjetRetour = new clsObjetRetour();
			try
			{
				clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
				clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
				clsDonnee.pvgConnectionBase();
				clsObjetRetour.SetValue(true,clsPhapararticleWSBLL.pvgChargerDansDataSetPourCombo(clsDonnee, clsObjetEnvoi));
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


        [WebMethod(MessageName = "pvgChargerDansDataSetPourComboProduitFini", Description = "pvgChargerDansDataSetPourComboProduitFini", EnableSession = true)]
        public clsObjetRetour pvgChargerDansDataSetPourComboProduitFini(clsObjetEnvoi clsObjetEnvoi)
        {
	        clsObjetRetour clsObjetRetour = new clsObjetRetour();
	        try
	        {
		        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
		        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
		        clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsPhapararticleWSBLL.pvgChargerDansDataSetPourComboProduitFini(clsDonnee, clsObjetEnvoi));
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

        [WebMethod(MessageName = "pvgChargerDansDataSetMatierePremiere", Description = "pvgChargerDansDataSetMatierePremiere", EnableSession = true)]
        public clsObjetRetour pvgChargerDansDataSetMatierePremiere(clsObjetEnvoi clsObjetEnvoi)
        {
	        clsObjetRetour clsObjetRetour = new clsObjetRetour();
	        try
	        {
		        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
		        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
		        clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsPhapararticleWSBLL.pvgChargerDansDataSetMatierePremiere(clsDonnee, clsObjetEnvoi));
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

        [WebMethod(MessageName = "pvgChargerDansDataSetPourComboArticle", Description = "pvgChargerDansDataSetPourComboArticle", EnableSession = true)]
        public clsObjetRetour pvgChargerDansDataSetPourComboArticle(clsObjetEnvoi clsObjetEnvoi)
        {
	        clsObjetRetour clsObjetRetour = new clsObjetRetour();
	        try
	        {
		        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
		        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
		        clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsPhapararticleWSBLL.pvgChargerDansDataSetPourComboArticle(clsDonnee, clsObjetEnvoi));
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

        [WebMethod(MessageName = "pvgChargerDansDataSetMatierePremiereFabrication", Description = "pvgChargerDansDataSetMatierePremiereFabrication", EnableSession = true)]
    public clsObjetRetour pvgChargerDansDataSetMatierePremiereFabrication(clsObjetEnvoi clsObjetEnvoi)
        {
	        clsObjetRetour clsObjetRetour = new clsObjetRetour();
	        try
	        {
		        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
		        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
		        clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsPhapararticleWSBLL.pvgChargerDansDataSetMatierePremiereFabrication(clsDonnee, clsObjetEnvoi));
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




        [WebMethod(MessageName = "pvgChargerDansDataSetMatierePremiereChargement", Description = "pvgChargerDansDataSetMatierePremiereChargement", EnableSession = true)]
        public clsObjetRetour pvgChargerDansDataSetMatierePremiereChargement(clsObjetEnvoi clsObjetEnvoi)
        {
	        clsObjetRetour clsObjetRetour = new clsObjetRetour();
	        try
	        {
		        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
		        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
		        clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsPhapararticleWSBLL.pvgChargerDansDataSetMatierePremiereChargement(clsDonnee, clsObjetEnvoi));
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


        [WebMethod(MessageName = "pvgChargerDansDataSetAevcPrix", Description = "pvgChargerDansDataSetAevcPrix", EnableSession = true)]
        public clsObjetRetour pvgChargerDansDataSetAevcPrix(clsObjetEnvoi clsObjetEnvoi)
        {
	        clsObjetRetour clsObjetRetour = new clsObjetRetour();
	        try
	        {
		        clsDonnee.vogCleCryptage = clsObjetEnvoi.OE_D;
		        clsDonnee.vogUtilisateur = clsObjetEnvoi.OE_X;
		        clsDonnee.pvgConnectionBase();
                clsObjetRetour.SetValue(true, clsPhapararticleWSBLL.pvgChargerDansDataSetAevcPrix(clsDonnee, clsObjetEnvoi));
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
