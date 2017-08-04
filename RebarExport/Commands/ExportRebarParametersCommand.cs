using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using RebarExport.Entities;

namespace RebarExport.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class ExportRebarParametersCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var uiapp = commandData.Application;
            var uidoc = uiapp.ActiveUIDocument;

            var query = new RebarQuery(uidoc);

            var rebar = query.Prompt();

            if (rebar == null)
                return Result.Cancelled;

            var revitRebar = new RevitRebar(rebar);

            TaskDialog.Show("dev", $"Масса 1пм: {revitRebar.MassPerUnitLength} кг/м\nДиаметр стержня: {revitRebar.Diameter} мм\n" +
                $"Класс арматуры: {revitRebar.Class}\nПолная длина стержня: {revitRebar.FullLength} мм");

            return Result.Succeeded;
        }
    }
}
