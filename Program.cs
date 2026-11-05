
using EmployeeTimeAssignment.Models;
using Newtonsoft.Json;
using System.Linq;
using EmployeeTimeAssignment.Services;

string apiUrl = "https://rc-vault-fap-live-1.azurewebsites.net/api/gettimeentries?code=vO17RnE8vuzXzPJo5eaLLjXjmRW07law99QTD90zat9FfOQJKKUcgQ==";

using HttpClient client = new HttpClient();

try
{
    HttpResponseMessage response = await client.GetAsync(apiUrl);
    response.EnsureSuccessStatusCode();

    string jsonResponse = await response.Content.ReadAsStringAsync();

    List<TimeEntry>? timeEntries =
        JsonConvert.DeserializeObject<List<TimeEntry>>(jsonResponse);

    if (timeEntries == null || timeEntries.Count == 0)
    {
        Console.WriteLine("No time entries found.");
        return;
    }

    var employees = timeEntries
        .Where(x =>
            x.DeletedOn == null &&
            !string.IsNullOrWhiteSpace(x.EmployeeName) &&
            x.StarTimeUtc.HasValue &&
            x.EndTimeUtc.HasValue &&
            x.EndTimeUtc.Value > x.StarTimeUtc.Value)
        .GroupBy(x => x.EmployeeName!)
        .Select(group => new EmployeeSummary
{
    EmployeeName = group.Key,
    TotalHours = group.Sum(x =>
        (x.EndTimeUtc!.Value - x.StarTimeUtc!.Value).TotalHours)
})
        
        .OrderByDescending(x => x.TotalHours)
        .ToList();

    Console.WriteLine($"Total API records: {timeEntries.Count}");
    Console.WriteLine($"Total employees: {employees.Count}");
    Console.WriteLine();

    foreach (var employee in employees)
    {
        Console.WriteLine(
            $"{employee.EmployeeName,-25} {employee.TotalHours:F2} hours");
    }
    ReportService.GenerateHtmlReport(employees);

ChartService.GeneratePieChart(employees);

Console.WriteLine("HTML report generated successfully!");
Console.WriteLine("Pie chart generated successfully!");
}
catch (HttpRequestException ex)
{
    Console.WriteLine($"API Error: {ex.Message}");
}
catch (JsonException ex)
{
    Console.WriteLine($"JSON Error: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
finally
{
    Console.WriteLine();
    Console.WriteLine("Press any key to exit...");
    Console.ReadKey();
}