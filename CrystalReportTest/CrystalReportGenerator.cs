using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalReportTest
{
    public class CrystalReportGenerator
    {
        private ReportDocument _rd;
    
        public CrystalReportGenerator(string templatePath, ConnectionInfo connectionInfo)
        {
           
            TableLogOnInfo t = new TableLogOnInfo();
            t.ConnectionInfo = connectionInfo;
            _rd = new ReportDocument();
            _rd.Load(templatePath);
            foreach (Table table in _rd.Database.Tables)
            {
                table.ApplyLogOnInfo(t);
            }


        }
        public string GenerateReport(Dictionary<string, object> paras, string reportFileName)
        {
            try
            {
                foreach (var kv in paras)
                {
                    _rd.SetParameterValue(kv.Key, kv.Value);
                }
                var reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"report\" + reportFileName);


             
                _rd.ExportToDisk(ExportFormatType.PortableDocFormat, reportPath);
                return reportPath;
            }
            catch (Exception e)
            {
                Console.WriteLine("GenerateReport error " + e.Message);


                return string.Empty;
            }

        }
    }
}
