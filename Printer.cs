using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Data;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using Microsoft.Reporting.WinForms;
using System.Windows.Forms;
using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;

namespace SuperX
{
    public enum Output : int
    {
        NONE = 0,
        PDF = 1,
        Excel = 2,
        PrinterName = 3,
        Preview = 4,
        PDFandPrinterName = 5
    }
    public class Printer : IDisposable
    {
        private int m_currentPageIndex;
        private IList<Stream> m_streams;
        private PageSettings m_pageSettings;
        private bool LandScape = false;
        private Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            Stream retStream;
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            retStream = stream;
            return retStream;
        }
        public void Export(LocalReport Report, int OutputType, string OutPutFile)
        {
            string DeviceInfo = "";
            if(Report.ReportEmbeddedResource == "SuperX.Report.Reports.InBillThanhToan.rdlc")
            {
                DeviceInfo = "<DeviceInfo>";
                DeviceInfo += "     <OutputFormat>EMF</OutputFormat>";
                DeviceInfo += "     <PageWidth>3.14in</PageWidth>";
                DeviceInfo += "     <PageHeight>4.26in</PageHeight>";
                DeviceInfo += "     <MarginTop>0.1in</MarginTop>";
                DeviceInfo += "     <MarginLeft>0.0in</MarginLeft>";
                DeviceInfo += "     <MarginRight>0.0in</MarginRight>";
                DeviceInfo += "     <MarginBottom>0.1in</MarginBottom>";
                DeviceInfo += "</DeviceInfo>";
            }
            else if(OutputType == 1 || OutputType == 2){

            }
            else
            {
                DeviceInfo = "<DeviceInfo>";
                DeviceInfo += "     <OutputFormat>EMF</OutputFormat>";
                DeviceInfo += "     <PageWidth>8.5in</PageWidth>";
                DeviceInfo += "     <PageHeight>11in</PageHeight>";
                DeviceInfo += "     <MarginTop>0.1in</MarginTop>";
                DeviceInfo += "     <MarginLeft>0.1in</MarginLeft>";
                DeviceInfo += "     <MarginRight>0.1in</MarginRight>";
                DeviceInfo += "     <MarginBottom>0.1in</MarginBottom>";
                DeviceInfo += "</DeviceInfo>";
            }

            string[] streamIDs = null;
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string extension;
            switch (OutputType)
            {
                case 1:
                    {
                        byte[] Results;
                        Results = Report.Render("PDF", DeviceInfo, out mimeType, out encoding, out extension, out streamids, out warnings);
                        using (FileStream stream = File.OpenWrite(OutPutFile))
                        {
                            stream.Write(Results, 0, Results.Length);
                        }

                        break;
                    }

                case 2:
                    {
                        byte[] Results;
                        streamids = null;
                        Results = Report.Render("EXCEL", DeviceInfo, out mimeType, out encoding, out extension, out streamids, out warnings);
                        using (FileStream stream = File.OpenWrite(OutPutFile))
                        {
                            stream.Write(Results, 0, Results.Length);
                        }

                        break;
                    }

                default:
                    {
                        m_streams = new List<Stream>();
                        warnings = null;
                        Report.Render("Image", DeviceInfo, CreateStream, out warnings/* TODO Change to default(_) if this is not a reference type */);
                        foreach (Stream stream in m_streams)
                            stream.Position = 0;
                        break;
                    }
            }
        }
        
        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new Metafile(m_streams[m_currentPageIndex]);
            ev.Graphics.DrawImage(pageImage, ev.PageBounds);
            m_currentPageIndex += 1;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }
        private void Print(string PrinterName, int OutputType, string OutPutFile)
        {
            switch (OutputType)
            {
                case 1:
                case 2:
                    {
                        break;
                    }

                default:
                    {
                        foreach (string pkInstalledPrinters in PrinterSettings.InstalledPrinters)
                        {
                            if (pkInstalledPrinters.IndexOf(PrinterName) >= 0)
                            {
                                PrinterName = pkInstalledPrinters;
                                break;
                            }
                        }
                        if (m_streams == null || m_streams.Count == 0)
                            return;
                        PrintDocument PrintDoc = new PrintDocument();
                        if (PrinterName != string.Empty)
                            PrintDoc.PrinterSettings.PrinterName = PrinterName;
                        PrintDoc.DefaultPageSettings.Landscape = LandScape;
                        PrintDoc.DefaultPageSettings.PaperSize = m_pageSettings.PaperSize;
                        if (!PrintDoc.PrinterSettings.IsValid)
                            throw new Exception("Driver for printer " + PrinterName + " was not found");
                        PrintDoc.PrintPage += PrintPage;
                        PrintDoc.Print();
                        break;
                    }
            }
        }
        public void Run(LocalReport Report, string PrinterName, Output OutputType, string OutPutFile)
        {
            m_pageSettings = new PageSettings();
            ReportPageSettings reportPageSettings = Report.GetDefaultPageSettings();
            m_pageSettings.PaperSize = reportPageSettings.PaperSize;
            m_pageSettings.Margins = reportPageSettings.Margins;
            Export(Report, (int)OutputType, OutPutFile);
            m_currentPageIndex = 0;
            Print(PrinterName, (int)OutputType, OutPutFile);
            Dispose();
        }

        public string SelectPrinter()
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = new PrintDocument();
            DialogResult result = printDialog.ShowDialog();
            return result == DialogResult.OK ? printDialog.Document.PrinterSettings.PrinterName : "";
        }

        public bool ExportExcel(LocalReport Report, string fileName = "")
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Excel Files | *.xls";
            dlg.FileName = fileName;
            if (dlg.ShowDialog() != DialogResult.OK)
                return false;
            m_pageSettings = new PageSettings();
            ReportPageSettings reportPageSettings = Report.GetDefaultPageSettings();
            m_pageSettings.PaperSize = reportPageSettings.PaperSize;
            m_pageSettings.Margins = reportPageSettings.Margins;
            Export(Report, (int)Output.Excel, dlg.FileName);
            Dispose();
            return true;
        }

        public void ExportToFile(LocalReport Report, Action<LocalReport, string> reportFunction, string fileName = "")
        {
            if (MessageBox.Show("Print to Excel File", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Excel Files | *.xlsx";
            dlg.FileName = fileName;
            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            reportFunction(Report, dlg.FileName);
            MessageBox.Show("Export excel successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private static string ToInches(int hundrethsOfInch)
        {
            double inches = hundrethsOfInch / 100.0;
            return inches.ToString(CultureInfo.InvariantCulture) + "in";
        }
        public void Dispose()
        {
            if (m_streams != null)
            {
                foreach (Stream stream in m_streams)
                    stream.Close();
                m_streams = null;
            }
        }
    }

}
