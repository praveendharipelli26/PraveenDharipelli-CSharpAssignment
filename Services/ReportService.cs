
using EmployeeTimeAssignment.Models;
using System.Net;
using System.Text;
using System.Globalization;
using EmployeeTimeAssignment.Services;

namespace EmployeeTimeAssignment.Services
{
    public class ReportService
    {
        public static void GenerateHtmlReport(List<EmployeeSummary> employees)
        {
            StringBuilder html = new StringBuilder();

            html.AppendLine("<!DOCTYPE html>");
            html.AppendLine("<html lang='en'>");
            html.AppendLine("<head>");
            html.AppendLine("<meta charset='UTF-8'>");
            html.AppendLine("<meta name='viewport' content='width=device-width, initial-scale=1.0'>");
            html.AppendLine("<title>Employee Work Report</title>");
            html.AppendLine("<style>");
            html.AppendLine("body { font-family: Arial, sans-serif; background: #f4f6f9; padding: 30px; }");
            html.AppendLine(".container { max-width: 850px; margin: auto; background: white; padding: 25px; border-radius: 10px; }");
            html.AppendLine("h2 { text-align: center; color: #263445; }");
            html.AppendLine("table { width: 100%; border-collapse: collapse; margin-top: 20px; }");
            html.AppendLine("th, td { padding: 14px; border: 1px solid #ddd; text-align: left; }");
            html.AppendLine("th { background: #263445; color: white; }");
            html.AppendLine("tr:nth-child(even) { background: #f2f2f2; }");
            html.AppendLine(".low-hours { background: #ffe0e0 !important; color: #b42318; }");
            html.AppendLine("</style>");
            html.AppendLine("</head>");
            html.AppendLine("<body>");
            html.AppendLine("<div class='container'>");
            html.AppendLine("<h2>Employee Working Hours Report</h2>");
            html.AppendLine("<table>");
            html.AppendLine("<tr><th>Employee Name</th><th>Total Time Worked (Hours)</th></tr>");

            foreach (var employee in employees)
            {
                string rowClass = employee.TotalHours < 100 ? "class='low-hours'" : "";
                string name = WebUtility.HtmlEncode(employee.EmployeeName);

                html.AppendLine(
                    $"<tr {rowClass}><td>{name}</td><td>{employee.TotalHours.ToString("F2", CultureInfo.InvariantCulture)}</td></tr>");
            }

            html.AppendLine("</table>");
            html.AppendLine("</div>");
            html.AppendLine("</body>");
            html.AppendLine("</html>");

            File.WriteAllText("EmployeeReport.html", html.ToString());
        }
    }
}
