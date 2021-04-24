using CrystalDecisions.CrystalReports.Engine;
using CrystalReportTutorial.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;












namespace CrystalReportTutorial.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext applicationDbContext = new ApplicationDbContext();
        public ActionResult ExportReportExcel()
        {
            var list = applicationDbContext.Employees.ToList();
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/CrystalReports"), "EmployeeReport.rpt"));
            rd.SetDataSource(list);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            try
            {
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.ExcelRecord);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, "application/vnd.ms-excel", "Employee_List_excel..xls");
            }
            catch (Exception ex)
            {
                throw;
            }
        }































        public ActionResult ExportReportPdf()
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/CrystalReports"), "EmployeeReport.rpt"));
            rd.SetDataSource(applicationDbContext.Employees.ToList());
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            try
            {
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, "application/pdf", "Employee_List.pdf");
            }
            catch (Exception ex)
            {
                throw;
            }
        }























































        public ActionResult Index()
        {
            return View(applicationDbContext.Employees.ToList());
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        
    }
}