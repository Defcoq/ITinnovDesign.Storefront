using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalReportTest
{
    public class Stampa
    {
        private string _SPath;
      //  private ILogService _logService = new LogService("Blucrm.UTF.Logger");

        public enum TipoOutput
        {
            Excel = 0,
            PDF = 1,
            WORD = 2
        }

        public string PathFile
        {
            get
            {
                return _SPath;
            }
            set
            {
                _SPath = value;
            }
        }
        private string reportAttuale;

        public void CreaReport(string NomeReportIn, string sreportFormula
                              , string NomeReportOut
                              , string NomeServer, string NomeDatabase, string NomeUser, string NomePassword
                              , string PathExport, int FormatOutput
                              , string NomeFile
                              , System.Data.DataTable DataSource = null
    )
        {
           Console.WriteLine("CreaReport() => Sono dentro CreaReport e sono all'inizio");
            CrystalDecisions.Shared.TableLogOnInfos crtableLogoninfos = new CrystalDecisions.Shared.TableLogOnInfos();
            string NomeFilePDF;
            string LastError;
            System.Text.StringBuilder str = new System.Text.StringBuilder();
            ReportDocument crReportDocument = new ReportDocument();
            try
            {
                Console.WriteLine("CreaReport() => Sono dentro il try, richiamo il documento");
                crReportDocument.Load(NomeReportIn, OpenReportMethod.OpenReportByDefault);
                Console.WriteLine("CreaReport() => Fine creazione report");
            }
            catch (Exception ex)
            {
                Console.WriteLine("CreaReport() => Eccezione nel richiamo del documento: " + ex.ToString());
                LastError = ex.ToString();
                return;
            }

            if (Logon(crReportDocument, NomeServer, NomeDatabase, NomeUser, NomePassword) == false)
            {
                Console.WriteLine("CreaReport() => logon del report non riuscita: NomeServer = " + NomeServer + ";NomeDatabase = " + NomeDatabase + ";NomeUser = " + NomeUser + ";NomePassword = " + NomePassword);
                LastError = "CreaReport() => logon del report non riuscita";
                return;
            }

            int aaa;
            aaa = 0;

            Console.WriteLine("CreaReport() => Imposto la RecordSelectionFormula");
            crReportDocument.RecordSelectionFormula = crReportDocument.RecordSelectionFormula + sreportFormula; // existing formula + custom 


            if (DataSource != null)
            {
                Console.WriteLine("CreaReport() => Righe Datasource: " + DataSource.Rows.Count.ToString());
                crReportDocument.SetDataSource(DataSource);
                Console.WriteLine("CreaReport() => Imposto il datasource");
                crReportDocument.Database.Tables[0].SetDataSource(DataSource);
            }

            Console.WriteLine("CreaReport() => Faccio il refresh");
            crReportDocument.Refresh();

            try
            {
                Console.WriteLine("CreaReport() => PathExport: " + PathExport + "; NomeFile: " + NomeFile);
                NomeFilePDF = PathExport + NomeFile; // NomeReportOut

                ExportOptions crExportOptions;
                DiskFileDestinationOptions crDestOptions = new DiskFileDestinationOptions();

                Console.WriteLine("CreaReport() => ExportOptions fase 1");
                crExportOptions = crReportDocument.ExportOptions;
                Console.WriteLine("CreaReport() => ExportOptions fase 2");
                crExportOptions.DestinationOptions = crDestOptions;
                Console.WriteLine("CreaReport() => ExportOptions fase 3");
                crExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                Console.WriteLine("CreaReport() => ExportOptions fase 4");

                {
                    var withBlock = crExportOptions;
                    switch (FormatOutput)
                    {
                        case 0:
                            {
                                Console.WriteLine("CreaReport() => ExportOptions fase 5 xls");
                                crExportOptions.ExportFormatType = ExportFormatType.Excel;
                                NomeFilePDF = NomeFilePDF + ".xls";
                                break;
                            }

                        case 1:
                            {
                                Console.WriteLine("CreaReport() => ExportOptions fase 5 pdf");
                                crExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                                NomeFilePDF = NomeFilePDF + ".pdf";
                                break;
                            }

                        case 2:
                            {
                                Console.WriteLine("CreaReport() => ExportOptions fase 5 doc");
                                crExportOptions.ExportFormatType = ExportFormatType.WordForWindows;
                                NomeFilePDF = NomeFilePDF + ".doc";
                                break;
                            }
                    }
                }

                Console.WriteLine("CreaReport() => Controllo se il file esiste");

                if (System.IO.File.Exists(NomeFilePDF))
                {
                    Console.WriteLine("CreaReport() => Esiste già il file in CreaReport, quindi lo cancella");
                    System.IO.File.Delete(NomeFilePDF);
                }

                Console.WriteLine("CreaReport() => NomeFilePDF: " + NomeFilePDF);
                crDestOptions.DiskFileName = NomeFilePDF;

                Console.WriteLine("CreaReport() => Sto esportando il file");
                crReportDocument.Export();
                Console.WriteLine("CreaReport() => Ho esportato il file");

                crReportDocument.Close();
                crReportDocument.Dispose();
                crReportDocument = null/* TODO Change to default(_) if this is not a reference type */;
            }

            catch (Exception err)
            {
                Console.WriteLine("CreaReport() => Errore generico in CreaReport: " + err.ToString());
                LastError = err.ToString();
                throw err;
            }

            crtableLogoninfos.Clear();
            _SPath = NomeFilePDF;
        }

        public bool ApplyLogon(ReportDocument cr, ConnectionInfo ci)
        {
            //TableLogOnInfo li;
            //Table tbl;

            foreach (Table tbl in cr.Database.Tables)
            {
                TableLogOnInfo  li = tbl.LogOnInfo;
                li.ConnectionInfo = ci;
                tbl.ApplyLogOnInfo(li);
            }
            return true;
        }

        public bool Logon(ReportDocument cr, string server, string db, string id, string pass)
        {
            ConnectionInfo ci = new ConnectionInfo();
            SubreportObject subObj;

            ci.ServerName = server;
            ci.DatabaseName = db;
            ci.UserID = id;
            ci.Password = pass;

            if (!(ApplyLogon(cr, ci)))
                return false;

           

            foreach (ReportObject obj in cr.ReportDefinition.ReportObjects)
            {
                if (obj.Kind == ReportObjectKind.SubreportObject)
                {
                    subObj = (SubreportObject)obj;
                    if (!(ApplyLogon(cr.OpenSubreport(subObj.SubreportName), ci)))
                        return false;
                }
            }
            return true;
        }
    }

}
