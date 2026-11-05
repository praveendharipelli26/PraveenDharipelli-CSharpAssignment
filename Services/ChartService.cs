
using EmployeeTimeAssignment.Models;
using ScottPlot;

namespace EmployeeTimeAssignment.Services
{
    public class ChartService
    {
       
public static void GeneratePieChart(List<EmployeeSummary> employees)
{
    if (employees == null || employees.Count == 0)
    {
        Console.WriteLine("No employee data available for chart.");
        return;
    }

    double totalHours = employees.Sum(x => x.TotalHours);

    // Define different colours for employees
    var colors = new ScottPlot.Color[]
{
    ScottPlot.Color.FromHex("#547A91"),
    ScottPlot.Color.FromHex("#82A6A1"),
    ScottPlot.Color.FromHex("#C6A477"),
    ScottPlot.Color.FromHex("#A58AA8"),
    ScottPlot.Color.FromHex("#D28C82"),
    ScottPlot.Color.FromHex("#7995B5"),
    ScottPlot.Color.FromHex("#A3B18A"),
    ScottPlot.Color.FromHex("#D5BFA5"),
    ScottPlot.Color.FromHex("#8C9A9E"),
    ScottPlot.Color.FromHex("#B6A0A0")
};

    List<PieSlice> slices = employees
        .Where(x => x.TotalHours > 0)
        .Select((employee, index) => new PieSlice
        {
            Value = employee.TotalHours,
            FillColor = colors[index % colors.Length],
            Label = $"{employee.TotalHours / totalHours:P1}",
            LegendText = $"{employee.EmployeeName} ({employee.TotalHours:F2} hours)"
        })
        .ToList();

    Plot plot = new();

    var pie = plot.Add.Pie(slices);

    pie.ExplodeFraction = 0.03;
    pie.SliceLabelDistance = 0.6;

    plot.ShowLegend();
    plot.Axes.Frameless();
    plot.HideGrid();

    plot.SavePng("EmployeeWorkHours.png", 1000, 700);
}

    }
}
