using SPA.Models;
using System.Text;
namespace SPA.Utils
{

    public class PayStubCreator
    {
 
       
        public static string GenerateHTML(PayStub payStub)
        {
 
            StringBuilder h = new StringBuilder();

            h.Append("<!DOCTYPE html >");
            h.Append("<html lang=\"fr-FR\"><head><meta charset = \"utf-8\"/>");
            h.Append("<link href = \"https://netdna.bootstrapcdn.com/bootstrap/3.1.0/css/bootstrap.min.css\" rel=\"stylesheet\" id=\"bootstrap-css\">");
            h.Append("</head>");
            h.Append("<body>");
            h.Append("<div class=\"container\">");

            h.Append("<div class=\"row\">");
            h.Append("<div class=\"col-xs-2\"><img src=\"Ressources//Logo.PNG\"  style =\"width:95px; height:80px;\"></div>");
            h.Append("<div class=\"col-xs-4 text-left\"><address><strong>IAxions Inc.</strong><br>2562, rue de Port-Royal<br>Québec, QC G1V 1A6 <br>418 559 4246</address></div>");
            h.Append("<div class=\"col-xs-6 text-right\"><address><strong>Bultin n° : " + payStub.Number + "<br>Date D'émission</strong> : " + payStub.CreationDate.ToShortDateString() + "</address></div>");
            h.Append("</div>");
            h.Append("<hr style=\"height:5px\">");

            h.Append("<div class=\"row\">");
            h.Append("<div class=\"col-xs-6\"><address><p><strong>EMPLOYÉ</strong></p>" + payStub.Employee.FullName + "<br>Poste: " + payStub.Employee.Title + "<br>Taux: " + payStub.Employee.Rate + "$/h" + "<br>" + "</address></div>");
            h.Append("<div class=\"col-xs-3\"><address><p><strong>PÉRIODE:</strong></p>" + "</br>Du: " + payStub.TimeSheet1.WeekDate.ToShortDateString() + "</br> À:  " + payStub.TimeSheet2.WeekDateEnd.ToShortDateString() + "</address></div>");
            h.Append("<div class=\"col-xs-3\"><address><p><strong>PAIEMENT:</strong></p>" + "</br>Du: " + payStub.TimeSheet1.WeekDate.ToShortDateString() + "</br> N de paie: " + payStub.Number + "</address></div>");
            h.Append("</div>");
            h.Append("</div>");
            h.Append("</div>");


            /*First Table*/
            h.Append("<div class=\"row\">");
            h.Append("<div class=\"col-md-5\">");
            h.Append("<div class=\"table-responsive\">");
            h.Append("<table class=\"table table-condensed\">");
            h.Append("<thead>");
            h.Append("<tr>");
            h.Append("<td><strong>TYPE D'HEURES TRAVAILLÉES</strong></td>"); h.Append("<td><strong>HEURES </strong></td>");
            h.Append("</tr>");
            h.Append("</thead>");
            h.Append("<tr><td> Nombre d’heures payées au taux normal </td><td>" + payStub.TotalRegular + "</td>");
            h.Append("<tr><td> Nombre d’heures payées non travaillées </td><td>" + payStub.TotalHoliday + "</td>");
            h.Append("<tr><td> Nombre d’heures supplémentaires payées </td><td>" + payStub.TotalOvertime + "</td>");
            h.Append("<tr><td> Nombre d’heures remplacées par un congé </td><td>" + payStub.TotalVacation + "</td>");

            // Total            
            h.Append("<tr><td class=\"thick-line\"> <strong>Total</strong> </td><td>" + payStub.TotalHours + "</td>");

            h.Append("</table>");
            h.Append("</div>");
            h.Append("</div>");
            h.Append("</div>");

            /*Seconde Table*/
            h.Append("<div class=\"row\">");
            h.Append("<div class=\"col-md-5\">");
            h.Append("<div class=\"table-responsive\">");
            h.Append("<table class=\"table table-condensed\">");
            h.Append("<thead>");
            h.Append("<tr>");
            h.Append("<td><strong>COTUSATIONS</strong></td>"); h.Append("<td><strong>TAUX %</strong></td>"); h.Append("<td class=\"text-right\"><strong>MONTANT</strong></td>");
            h.Append("</tr>");
            h.Append("</thead>");
            h.Append("<tr><td> Impot Féderal </td><td>" + payStub.Employee.FedTax + "</td><td class=\"text-right\">" + payStub.FedTax.ToString("#,##0.00 $") + "</td>");
            h.Append("<tr><td> Impot provaincial </td><td>" + payStub.Employee.ProvTax + "</td><td class=\"text-right\">" + payStub.ProvTax.ToString("#,##0.00 $") + "</td>");
            h.Append("<tr><td> RRQ </td><td>" + payStub.Employee.RRQ + "</td><td class=\"text-right\">" + payStub.RRQ.ToString("#,##0.00 $") + "</td>");
            h.Append("<tr><td> RQAP </td><td>" + payStub.Employee.RQAP + "</td><td class=\"text-right\">" + payStub.RQAP.ToString("#,##0.00 $") + "</td>");
            h.Append("<tr><td> Vacance </td><td>" + payStub.Employee.Vacation + "</td><td class=\"text-right\">" + payStub.Vacation.ToString("#,##0.00 $") + "</td>");

            // Total            
            h.Append("<tr><td class=\"thick-line\"> <strong>Total</strong> </td><td class=\"no-line\"></td><td class=\"text-right\">" + payStub.Deductions.ToString("#,##0.00 $") + "</td>");

            h.Append("</table>");
            h.Append("</div>");
            h.Append("</div>");
            h.Append("</div>");
            h.Append("<br>");
            h.Append("<br>");


            //Summury
            h.Append("<div class=\"row\">");
            h.Append("<div class=\"col-md-10\">");
            h.Append("</div>");

            h.Append("<div class=\"col-md-2\">");
            h.Append("<table>");
            h.Append("<tr>");
            h.Append("<td align=\"right\" class=\"text-left\">Déductions:   " + payStub.Deductions.ToString("#,##0.00 $") + "</td>");
            h.Append("</tr>");
            h.Append("</div>");
            h.Append("</div>");

            h.Append("<tr>");
            h.Append("<td align=\"right\" class=\"text-left\">Revenue brut: " + payStub.Gross.ToString("#,##0.00 $") + "</td>");
            h.Append("</tr>");
            h.Append("</table>");

            h.Append("<hr style=\"height:10px\">");

            h.Append("<table>");
            h.Append("<tr>");
            h.Append("<td align=\"right\" class=\"text-left\"><b>Revenue net:  " + payStub.Net.ToString("#,##0.00 $") + "</b></td>");
            h.Append("</tr>");
            h.Append("</table>");

            h.Append("<br>");
            h.Append("<p><b> Nous vous remercions pour votre implication.</p></b>");

            h.Append("</div>");
            h.Append("</body>");
            h.Append("</html>");

            return h.ToString();
        }

    }
}
