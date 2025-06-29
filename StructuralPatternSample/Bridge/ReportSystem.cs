using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPatternSample.Bridge
{
    internal class ReportSystem
    {
        //هدف اصلی معماری پل جداسازی انتزاع از پیاده سازی هست
        //لایه انتزاع داریم که با کلاینت در ارتباط هستش abstraction
        // لایه پیاده ساز داریم که پیادی سازی ها رو تعریف می کنه  Implimentor

        public void Execute()
        {
            IReportFormat report=new JsonReport();

            UserReport userReport = new UserReport(report);

            userReport.Generate("Send Message");
        }
    }


    #region Abstraction
    public abstract class Report 
    {

        //abstraction

        protected readonly IReportFormat _reportFormat;

        protected Report(IReportFormat reportFormat)
        {
            _reportFormat = reportFormat;
        }

        public abstract void Generate(string content);
    }

    #endregion


    #region Implimentor 
    public interface IReportFormat
    {
        //implimentor interface

        void Export(string content);
    }
    #endregion


    #region Concreate implimentor
    //concreate implimentor

    public class JsonReport : IReportFormat
    {
        public void Export(string content)
        {
            Console.WriteLine("Export Json Report");
        }
    }

    //concreate implimentor
    public class XmlReport : IReportFormat
    {
        public void Export(string content)
        {
            Console.WriteLine("Export xml Report");
        }
    }
    #endregion


    #region Refind Abstraction

    public class SalesReport : Report
    {
        public SalesReport(IReportFormat reportFormat) : base(reportFormat)
        {
        }

        public override void Generate(string content)
        {
            _reportFormat.Export(content);
        }

       
    }

    public class UserReport : Report
    {
        public UserReport(IReportFormat reportFormat) : base(reportFormat)
        {
        }

        public override void Generate(string content)
        {
            _reportFormat.Export(content);
        }
    }

    #endregion

}
