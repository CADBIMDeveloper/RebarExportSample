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

            TaskDialog.Show("dev", $"����� 1��: {revitRebar.MassPerUnitLength} ��/�\n������� �������: {revitRebar.Diameter} ��\n" +
                $"����� ��������: {revitRebar.Class}\n������ ����� �������: {revitRebar.FullLength} ��");

            return Result.Succeeded;
        }
    }
}
