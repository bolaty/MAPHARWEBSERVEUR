using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Hosting;

namespace Stock.WCF.Utilities
{
    public static class CrystalReport
    {
        public static string RenderReport(string reportPath, string reportFileName, string exportFilename,DataSet DataSet, string[] vappNomFormule, string[] vappValeurFormule)
        {
            string URL_ROOT_DOSSIER = ConfigurationManager.AppSettings["URL_ROOT_DOSSIER"];
            var rd = new ReportDocument();

            int VAL_RAND_MIN = 0;
            int VAL_RAND_MAX = 1000000;





            DataTable DataTable = new DataTable();
            DataTable = DataSet.Tables[0];
            rd.Load(Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath(reportPath), reportFileName));
            rd.SetDataSource(DataTable);

            //=====================
            //string[] vappNomFormule = new string[] { "Entete1", "Entete2", "Entete3", "Entete4" };
            //object[] vappValeurFormule = new string[] { "Entete1", "Entete2", "Entete3", "Entete4" };
            if (vappNomFormule != null && vappValeurFormule != null)
                pvpRenseignerFormule(vappNomFormule, vappValeurFormule, rd);
            //=====================


            MemoryStream ms = new MemoryStream();
            using (var stream = rd.ExportToStream(ExportFormatType.PortableDocFormat))
            {
                stream.CopyTo(ms);
            }

            //var result = new HttpResponseMessage(HttpStatusCode.OK)
            //{
            //    Content = new ByteArrayContent(ms.ToArray())
            //};
            //result.Content.Headers.ContentDisposition =
            //    new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
            //    {
            //        FileName = exportFilename
            //    };
            //result.Content.Headers.ContentType =
            //    new System.Net.Http.Headers.MediaTypeHeaderValue("application/pdf");



            string FileName1 = "";
            string CHEMIN_ETATS = HostingEnvironment.MapPath("~/Reports/");


            Random random = new Random(); // Création d'une instance de valeur aleatoir                
            int randomNumber = random.Next(VAL_RAND_MIN, VAL_RAND_MAX);  // Génération automatique d'un nombre compris entre 0 et 1000000

            FileName1 = extentionDocument("PDF", randomNumber.ToString(), rd, CHEMIN_ETATS); // Attribution d'un nom au fichier etat

            URL_ROOT_DOSSIER = URL_ROOT_DOSSIER + FileName1; // Xhemin d'acces du fichier etat


            return URL_ROOT_DOSSIER;
        }


        public static string RenderReport(string reportPath, string reportFileName, string exportFilename, DataSet DataSet, string[] vppFichierSousEtat, DataSet[] vppDataSetSousEtat, string[] vappNomFormule, string[] vappValeurFormule)
        {
            string URL_ROOT_DOSSIER = ConfigurationManager.AppSettings["URL_ROOT_DOSSIER"];
            var rd = new ReportDocument();

            int VAL_RAND_MIN = 0;
            int VAL_RAND_MAX = 1000000;
            string FormatFichier = "PDF";
            FormatFichier = vappValeurFormule[7];
            if (vappValeurFormule.Length > 0)
            {
                Array.Resize(ref vappValeurFormule, vappValeurFormule.Length - 1);
            }

            if (FormatFichier == "xls")
            {
                FormatFichier = "xls";
            }

            DataTable DataTable = new DataTable();
            DataTable = DataSet.Tables[0];
            rd.Load(Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath(reportPath), reportFileName));
            rd.SetDataSource(DataTable);

            for (int Idx = 0; Idx < vppFichierSousEtat.Length; Idx++)
                rd.Subreports[vppFichierSousEtat[Idx]].SetDataSource(vppDataSetSousEtat[Idx].Tables[0]);

            //=====================
            //string[] vappNomFormule = new string[] { "Entete1", "Entete2", "Entete3", "Entete4" };
            //object[] vappValeurFormule = new string[] { "Entete1", "Entete2", "Entete3", "Entete4" };
            if (vappNomFormule != null && vappValeurFormule != null)
                pvpRenseignerFormule(vappNomFormule, vappValeurFormule, rd);
            //=====================


            MemoryStream ms = new MemoryStream();
            using (var stream = rd.ExportToStream(ExportFormatType.PortableDocFormat))
            {
                stream.CopyTo(ms);
            }

            //var result = new HttpResponseMessage(HttpStatusCode.OK)
            //{
            //    Content = new ByteArrayContent(ms.ToArray())
            //};
            //result.Content.Headers.ContentDisposition =
            //    new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
            //    {
            //        FileName = exportFilename
            //    };
            //result.Content.Headers.ContentType =
            //    new System.Net.Http.Headers.MediaTypeHeaderValue("application/pdf");



            string FileName1 = "";
            string CHEMIN_ETATS = HostingEnvironment.MapPath("~/Reports/");


            Random random = new Random(); // Création d'une instance de valeur aleatoir                
            int randomNumber = random.Next(VAL_RAND_MIN, VAL_RAND_MAX);  // Génération automatique d'un nombre compris entre 0 et 1000000

            FileName1 = extentionDocument(FormatFichier, randomNumber.ToString(), rd, CHEMIN_ETATS); // Attribution d'un nom au fichier etat

            URL_ROOT_DOSSIER = URL_ROOT_DOSSIER + FileName1; // Xhemin d'acces du fichier etat


            return URL_ROOT_DOSSIER;
        }

        public static string extentionDocument(string extention, string fileName, ReportDocument documentRpt, string cheminFichier)
        {

            if (string.IsNullOrWhiteSpace(extention))
            {
                fileName += ".pdf";
                documentRpt.ExportToDisk(ExportFormatType.PortableDocFormat, cheminFichier + fileName);
            }
            else
            {
                switch (extention.ToLower())
                {
                    case "text":
                    case ".txt":
                    case "txt":
                        fileName += ".txt";
                        documentRpt.ExportToDisk(ExportFormatType.Text, cheminFichier + fileName);
                        break;
                    case "xml":
                    case ".xml":
                        fileName += ".xml";
                        documentRpt.ExportToDisk(ExportFormatType.Xml, cheminFichier + fileName);
                        break;
                    case "word":
                    case ".doc":
                    case ".docx":
                    case "doc":
                        fileName += ".doc";
                        documentRpt.ExportToDisk(ExportFormatType.WordForWindows, cheminFichier + fileName);
                        break;
                    case "excel":
                    case ".xls":
                    case "xls":
                        fileName += ".xls";
                        documentRpt.ExportToDisk(ExportFormatType.Text, cheminFichier + fileName);
                        break;
                    case ".xlsx":
                    case "xlsx":
                        fileName += ".xlsx";
                        documentRpt.ExportToDisk(ExportFormatType.ExcelWorkbook, cheminFichier + fileName);
                        break;
                    case ".pdf":
                    case "pdf":
                        fileName += ".pdf";
                        documentRpt.ExportToDisk(ExportFormatType.PortableDocFormat, cheminFichier + fileName);
                        break;
                    case "sansformat":
                        fileName += ".xls";
                        documentRpt.ExportToDisk(ExportFormatType.Text, cheminFichier + fileName);
                        break;
                    default:
                        fileName += ".pdf";
                        documentRpt.ExportToDisk(ExportFormatType.PortableDocFormat, cheminFichier + fileName);
                        break;
                }
            }

            return fileName;

        }

        private static void pvpRenseignerFormule(string[] vappNomFormule, object[] vappValeurFormule, ReportDocument rd)
        {
            for (int Idx = 0; Idx < vappNomFormule.GetLength(0); Idx++)
            {
                string vlpNomFormule = vappNomFormule[Idx].ToString();
                string vlpValeurFormule = vappValeurFormule[Idx].ToString();
                rd.DataDefinition.FormulaFields[vlpNomFormule].Text = "'" + vlpValeurFormule.Replace("'", "''") + "'";

            }
        }

    }
}