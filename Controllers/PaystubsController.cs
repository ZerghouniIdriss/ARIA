 
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PdfSharpCore.Drawing;
using PdfSharpCore.Drawing.Layout;
using PdfSharpCore.Pdf;
using SPA.Data;
using SPA.Models;
using SPA.Utils;
using System.Net;
using System.Net.Mail; 
using System.IO;
using PdfSharpCore;
using TheArtOfDev.HtmlRenderer.PdfSharp;
using iText.Kernel.Pdf;

namespace SPA.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class PaystubsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PaystubsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Paystubs
        [HttpGet]
        public async Task<ActionResult<List<PayStub>>> GetPayStubs()
        {
            var result = new List<PayStub>();
            var employeeList = await _context.Employees.ToListAsync();

            foreach (var employee in employeeList)
            {
                var timeSheet = await _context.TimeSheets.Where(t => t.EmployeeId == employee.Id).
                    Include(x => x.Employee).
                    FirstOrDefaultAsync();
                if (timeSheet != null)
                {
                    var payStub = new PayStub(1, employee, timeSheet, timeSheet);
                    result.Add(payStub);

                }
            }

            return Ok(result.ToList());
        }

        [HttpGet("{employeeId}/{weekDate}")]
        public IActionResult GetPayStubsByEmployeeAndStartDate(string employeeId, string weekDate)
        {
            DateTime parsedWeekDate = DateTime.Parse(weekDate);
            var sunday1 = DateUtils.GetAssociatedSunday(parsedWeekDate).Date;
            var sunday2 = DateUtils.GetAssociatedSunday(parsedWeekDate.AddDays(6)).Date;
            var timeSheet1 = _context.TimeSheets.Where(t => t.EmployeeId == employeeId && t.WeekDate == sunday1).
                Include(x => x.Employee).FirstOrDefault();
            var timeSheet2 = _context.TimeSheets.Where(t => t.EmployeeId == employeeId && t.WeekDate == sunday2).
                Include(x => x.Employee).FirstOrDefault();

            var employee = _context.Employees.Where(e => e.Id == employeeId).FirstOrDefault();

            var payStub = new PayStub(1, employee, timeSheet1, timeSheet2);

            string pdfFileName = "wwwroot/PayStubs/" + "Paystub" + ".pdf";

            var html = PayStubCreator.GenerateHTML(payStub);

            var Renderer = new IronPdf.HtmlToPdf();
            var PDF = Renderer.RenderHtmlAsPdf(html);
            PDF.SaveAs(pdfFileName);

            return File(PDF.Stream, "application/pdf", pdfFileName);
        }


        [HttpGet("send/{employeeId}/{weekDate}")]
        public IActionResult SendPayStubsByEmployeeAndStartDate(string employeeId, string weekDate)
        {

            DateTime parsedWeekDate = DateTime.Parse(weekDate);
            var sunday1 = DateUtils.GetAssociatedSunday(parsedWeekDate).Date;
            var sunday2 = DateUtils.GetAssociatedSunday(parsedWeekDate.AddDays(6)).Date;
            var timeSheet1 = _context.TimeSheets.Where(t => t.EmployeeId == employeeId && t.WeekDate == sunday1).
                Include(x => x.Employee).FirstOrDefault();
            var timeSheet2 = _context.TimeSheets.Where(t => t.EmployeeId == employeeId && t.WeekDate == sunday2).
                Include(x => x.Employee).FirstOrDefault();

            var employee = _context.Employees.Where(e => e.Id == employeeId).FirstOrDefault();

            var payStub = new PayStub(1, employee, timeSheet1, timeSheet2);

            string pdfFileName = "wwwroot/PayStubs/" + "Paystub" + ".pdf";

            var html = PayStubCreator.GenerateHTML(payStub);
            
            var Renderer = new IronPdf.HtmlToPdf();
            var PDF = Renderer.RenderHtmlAsPdf(html);
            PDF.SaveAs("MyPdf.pdf");

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("idriss.zerghouni@iaxions.com");
            mail.To.Add("zerghouni.idriss@gmail.com");
            mail.CC.Add("rhita.ouliz @iaxions.com");
            mail.Subject = "Votre bultin de paie est prêt: " + sunday1.Date.ToShortDateString();
            mail.Body = "Vous trouverez en piéce jointe votre bultin de paie de la semaine: " + sunday1.Date.ToShortDateString() +
                ". Veuillez prendre note que ceci est une version bêta. Si vous remarquez des anomalies, veuillez les signaler à votre gestionnaire.";
            mail.IsBodyHtml = true;
            Attachment attachment = new Attachment(PDF.Stream, pdfFileName);
            mail.Attachments.Add(attachment);


            using (SmtpClient smtp = new SmtpClient("iaxions.com", 26))
            {
                smtp.Credentials = new NetworkCredential("idriss.zerghouni@iaxions.com", "Ix.161019");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.EnableSsl = false;
                smtp.Send(mail);
            }

            return File(PDF.Stream, "application/pdf", pdfFileName);
            //return new ContentResult { Content = html, ContentType = "text/html" };
        }




    }
}
