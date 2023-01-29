 
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
        public async Task<ActionResult<List<PayStub>>> GetCurrent()
        {
            var weekNumber = DateUtils.GetWeekNumber(DateTime.Now);
            var weekStart = new DateTime();

            if (weekNumber % 2 == 0)
            {
                weekStart = DateTime.Now;
            }
            else if (weekNumber % 2 == 1)
            {
                weekStart = DateTime.Now.AddDays(-7);
            }

            var result = new List<PayStub>();

            var employeeList = await _context.Employees.ToListAsync();

            foreach (var employee in employeeList)
            {
                PayStub payStub = CreatePayStub(employee.Id, weekStart);
                result.Add(payStub);
            }

            return Ok(result.ToList());
        }

      

        [HttpGet("{employeeId}/{weekDate}")]
        public IActionResult GetPayStubsByEmployeeAndStartDate(string employeeId, string weekDate)
        {
            DateTime parsedWeekDate = DateTime.Parse(weekDate);
            PayStub payStub = CreatePayStub(employeeId, parsedWeekDate);

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
            PayStub payStub = CreatePayStub(employeeId, parsedWeekDate);

            string pdfFileName = "wwwroot/PayStubs/" + "Paystub" + ".pdf";

            var html = PayStubCreator.GenerateHTML(payStub);
            
            var Renderer = new IronPdf.HtmlToPdf();
            var PDF = Renderer.RenderHtmlAsPdf(html);
//            PDF.SaveAs("MyPdf.pdf");

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("idriss.zerghouni@iaxions.com");
            mail.To.Add("zerghouni.idriss@gmail.com");
            mail.CC.Add("rhita.ouliz@iaxions.com");
            mail.Subject = "Votre bultin de paie est prêt: " + payStub.StartDate.Date.ToShortDateString();
            mail.Body = "Vous trouverez en piéce jointe votre bultin de paie de la semaine: " + payStub.StartDate.Date.ToShortDateString() +
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
        }


        [HttpGet("send/{weekDate}")]
        public IActionResult SendToAll(string weekDate)
        {

            DateTime parsedWeekDate = DateTime.Parse(weekDate);

            //Loop en employee
            var employeeList = _context.Employees.ToList();

            foreach (var employee in employeeList)
            {
                SendPayStubsByEmployeeAndStartDate(employee.Id, weekDate);
            }

            return Ok("ok");
        }
       
        private PayStub CreatePayStub(string employeeId, DateTime weekStart)
        {
            var sunday1 = DateUtils.GetAssociatedSunday(weekStart).Date;
            var sunday2 = DateUtils.GetAssociatedSunday(weekStart.AddDays(7)).Date;
            var timeSheet1 = _context.TimeSheets.Where(t => t.EmployeeId == employeeId && t.WeekDate == sunday1).
                Include(x => x.Employee).FirstOrDefault();
            var timeSheet2 = _context.TimeSheets.Where(t => t.EmployeeId == employeeId && t.WeekDate == sunday2).
                Include(x => x.Employee).FirstOrDefault();


            if (timeSheet1 == null)
            {
                timeSheet1 = new TimeSheet();
            }
            if (timeSheet2 == null)
            {
                timeSheet2 = new TimeSheet();
            }


            var employee = _context.Employees.Where(e => e.Id == employeeId).FirstOrDefault();

            var payStub = new PayStub(1, employee, timeSheet1, timeSheet2);
            return payStub;
        }


    }
}
